using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;

namespace nsREDT
{
	public partial class Main : Form
    {
        #region ---- Data Members
		private FindFoldersWorker findFldWorker = null;

		private UInt32 maxFolders = 1000;

        private List<string> ignoreLwr = new List<string>();
        private List<Regex> ignoreRegex = new List<Regex>();
        
        private Dictionary<String, TreeNode> dir2Tree = null;
        private Dictionary<String, String> protectedFolders = new Dictionary<string, string>();

        // Empty folder list
        private List<DirectoryInfo> emptyFolders = null;

        // Registry keys
		private string menuName = "Folder\\shell\\{0}";
        private string command = "Folder\\shell\\{0}\\command";
        
		private bool stopDeleteProcess = false;

        // Process states
		private enum Processes
		{
			Scan, Search, Delete, Idle 
		}

		private Processes currentProcess = Processes.Idle;

        private cSettings settings = null;

        private PictureBox picIcon = new PictureBox();
        private Label picLabel = new Label();

        // private int DeleteStats = 0;

        private class Stats
        {
            // Directory scan stats.
            public UInt32 totalFound = 0;
            public UInt32 ignoredFolderCnt = 0;
            public Dictionary<string, UInt32> counts = new Dictionary<string, UInt32>();

            // Delete action stats.
            public UInt32 deleteCnt = 0;
            // Failed action stats
            public UInt32 failedCnt = 0;
        };

        private Stats stats = new Stats();
        private int iconKeyCount = 0;
        #endregion 

        /// <summary>
		/// Constructor
		/// </summary>
        public Main(string[] cmdLineArgs)
		{
			if (!IsRunningAsAdmin()) {
				if (RestartAsAdmin())
					return; // exit current non-admin instance
			}

			// Your privileged code here
			Console.WriteLine("Running with admin rights!");


			InitializeComponent();

            dirView.ListViewItemSorter = new ListViewColumnSorter(ListViewColumnSorter.SortDataType.eAlpha);

            // Parse any command line arguments as path values.
            if (cmdLineArgs.Length != 0)
            {
                string paths = "";
                for (int argIdx = 0; argIdx < cmdLineArgs.Length; argIdx++)
                {
                    if (argIdx != 0)
                        paths += ";";
                    paths += Path.GetFullPath(cmdLineArgs[argIdx]);
                }
                this.folderTx.Text = paths;
            }
		}


		bool IsRunningAsAdmin() {
			var identity = WindowsIdentity.GetCurrent();
			var principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}

		bool RestartAsAdmin() {
			var exeName = Assembly.GetExecutingAssembly().Location;
			var startInfo = new ProcessStartInfo(exeName) {
				UseShellExecute = true,
				Verb = "runas" // triggers UAC prompt
			};

			try {
				Process.Start(startInfo);
				return true;
			} catch {
				Console.WriteLine("User declined elevation.");
				return false;
			}
		}


		protected override void OnClosing(CancelEventArgs e)
        {
            CloseLogFile();
            base.OnClosing(e);
        }

		/// <summary>
		/// On load
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Main_Load(object sender, EventArgs e)
        {
            Assembly REDAssembly = Assembly.GetExecutingAssembly();
            AssemblyName AssemblyName = REDAssembly.GetName();

            this.appTitleLb.Text += string.Format("{0}", AssemblyName.Version.ToString());
            this.Text = string.Format("RED/T v{0}.{1} - Remove Empty Directories w/ Trash", 
                    AssemblyName.Version.Major, AssemblyName.Version.Minor);

            this.menuName = String.Format(menuName, nsREDT.Properties.Resources.registry_name);
            this.command = String.Format(command, nsREDT.Properties.Resources.registry_name);

            this.statusBar.Maximum = 100;
            this.statusBar.Minimum = 0;
            this.statusBar.Step = 5;
            this.statusBar.MarqueeAnimationSpeed = 0;

            #region Check for the registry key

            RegistryKey RegistryShellKey = Registry.ClassesRoot.OpenSubKey(menuName);
            if (RegistryShellKey == null)
                this.cbIntegrateIntoWindowsExplorer.Checked = false;
            else
                this.cbIntegrateIntoWindowsExplorer.Checked = true;

            #endregion

            #region Set and display folder status icons

            Dictionary<string, string> legendIcons = new Dictionary<string, string>();

            legendIcons.Add("home", nsREDT.Properties.Resources.icon_root);
            legendIcons.Add("folder", nsREDT.Properties.Resources.icon_default);
            legendIcons.Add("folder_trash_files", nsREDT.Properties.Resources.icon_contains_trash);

            legendIcons.Add("folder_hidden", nsREDT.Properties.Resources.icon_hidden_folder);
            legendIcons.Add("folder_hidden_trash_files", nsREDT.Properties.Resources.icon_hidden_trash);

            legendIcons.Add("folder_lock", nsREDT.Properties.Resources.icon_locked_folder);
            legendIcons.Add("folder_lock_trash_files", nsREDT.Properties.Resources.icon_locked_trash);

            legendIcons.Add("folder_readonly", nsREDT.Properties.Resources.icon_readonly_folder);
            legendIcons.Add("folder_readonly_trash", nsREDT.Properties.Resources.icon_readonly_trash);
            this.iconKeyCount = legendIcons.Count;

            // Add icons to legend
            ImageList imageList = new ImageList();
            iconList.SmallImageList = imageList;
            iconList.StateImageList = imageList;

            foreach (string key in legendIcons.Keys)
            {
                Image Icon = (Image)this.ilFolderIcons.Images[key];
                int iconIdx = imageList.Images.Count;
                imageList.Images.Add(key, Icon);
                // iconList.Items.Add(legendIcons[key], iconIdx).SubItems.Add("");
                iconList.Items.Add(legendIcons[key], key).SubItems.Add("");
                stats.counts.Add(key, 0);
            }

            // Add directory tree color code icons
            {
                int imageIdx = imageList.Images.Count;
                Bitmap image = new Bitmap(15, 15);
                Graphics.FromImage(image).Clear(Color.Transparent);
                imageList.Images.Add(image);
                iconList.Items.Add("", imageIdx);
                iconList.Items.Add("ColorKey:", imageIdx);
            }

            legendIcons.Clear();
            legendIcons.Add("folder_warning", nsREDT.Properties.Resources.icon_warning);
            legendIcons.Add("protected", nsREDT.Properties.Resources.icon_protected_folder);
            legendIcons.Add("deleted", nsREDT.Properties.Resources.icon_deleted_folder);
            foreach (string key in legendIcons.Keys)
            {
                Image Icon = (Image)this.ilFolderIcons.Images[key];
                int iconIdx = imageList.Images.Count;
                imageList.Images.Add(key, Icon);
                // iconList.Items.Add(Icons[key], iconIdx).SubItems.Add("");
                iconList.Items.Add(legendIcons[key], key).SubItems.Add("");
                stats.counts.Add(key, 0);
            }

            {
                int imageIdx = imageList.Images.Count;
                Bitmap image = new Bitmap(15, 15);
                Graphics.FromImage(image).Clear(Color.Gray);
                imageList.Images.Add(image);
                iconList.Items.Add("Will not touch", imageIdx);
            }
            {
                int imageIdx = imageList.Images.Count;
                Bitmap image = new Bitmap(15, 15);
                Graphics.FromImage(image).Clear(Color.Red);
                imageList.Images.Add(image);
                iconList.Items.Add("Will be delete", imageIdx);
            }
            {
                int imageIdx = imageList.Images.Count;
                Bitmap image = new Bitmap(15, 15);
                Graphics.FromImage(image).Clear(Color.Blue);
                imageList.Images.Add(image);
                iconList.Items.Add("Protected", imageIdx);
            }

            Main_ResziseEnd(null, EventArgs.Empty);     // resize dialogs
            #endregion

            #region Read config settings

            // settings path:
            string configPath = Path.Combine(Application.StartupPath, nsREDT.Properties.Resources.config_file);

            // Settings object:
            settings = new cSettings(configPath);

            // Read folder from the config file
			if (this.folderTx.Text == "C:\\")
                this.folderTx.Text = this.settings.Read("folder", nsREDT.Properties.Resources.start_folder);

            bool KeepSystemFolders = this.settings.Read("keep_system_folders", Boolean.Parse(nsREDT.Properties.Resources.keep_system_folders));

            if (!KeepSystemFolders)
                this.cbKeepSystemFolders.Tag = 1; // this disables the warning message

            this.cbKeepSystemFolders.Checked = KeepSystemFolders;
            this.cbIgnoreHiddenFolders.Checked = this.settings.Read("dont_scan_hidden_folders", Boolean.Parse(nsREDT.Properties.Resources.dont_scan_hidden_folders));
            this.cbIgnore0kbFiles.Checked = this.settings.Read("ignore_0kb_files", Boolean.Parse(nsREDT.Properties.Resources.ignore_0kb_files));
            this.cbDeleteReadonly.Checked = this.settings.Read("delete_readonly", Boolean.Parse(nsREDT.Properties.Resources.delete_readonly));

            this.nuMaxDepth.Value = (int)this.settings.Read("max_depth", Int32.Parse(nsREDT.Properties.Resources.max_depth));
            this.nuMaxFolder.Value = (int)this.settings.Read("max_folders", Int32.Parse(nsREDT.Properties.Resources.max_folders));

            this.ignoreFilesTx.Text = FixText(this.settings.Read("ignore_files", nsREDT.Properties.Resources.ignore_files));

            this.ignoreFoldersTx.Text = FixText(this.settings.Read("ignore_folders", nsREDT.Properties.Resources.ignore_folders));

            this.logTb.Text = this.settings.Read("log_file", nsREDT.Properties.Resources.log_file);

            if (string.IsNullOrEmpty(this.logTb.Text))
                this.logTb.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "redt.log");
			if (!File.Exists(logTb.Text))
				this.logTb.ForeColor = Color.Red;
			else
				this.logTb.ForeColor = Color.Black;
            #endregion
        }

        #region ---- Legend Stats and methods
        /// <summary>
        /// Clear statistic counters shown in legend.
        /// </summary>
        private void ClearStats()
        {
            this.stats.deleteCnt =  
                this.stats.ignoredFolderCnt = 
                this.stats.totalFound = 0;

			this.stats.counts["deleted"] = 0; ;
			this.stats.counts["protected"] = 0;   
			this.stats.counts["folder_warning"] = 0;  

			List<string> keyList = new List<string>(this.stats.counts.Keys);
            foreach (string key in keyList)
                this.stats.counts[key] = 0;
        }

        /// <summary>
        /// Expand empty tree nodes which match clicked legend items.
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="imageKey"></param>
        /// <returns></returns>
        private bool ExpandOnly(TreeNodeCollection nodes, string imageKey)
        {
            bool expanded = false;
            foreach (TreeNode node in nodes)
            {
                if (ExpandOnly(node.Nodes, imageKey) || node.ImageKey == imageKey)
                {
                    node.Expand();
                    expanded = true;
                }
            }

            return expanded;
        }
        
        /// <summary>
        /// Expand only items selected in legend.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iconList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iconList.SelectedIndices.Count == 0 || iconList.SelectedIndices[0] == 0)
            {
                tvFolders.ExpandAll();
            }
            else if (iconList.SelectedIndices[0] < iconKeyCount)
            {
                tvFolders.CollapseAll();
                foreach (ListViewItem  iconItem in iconList.SelectedItems)
                    ExpandOnly(tvFolders.Nodes, iconItem.ImageKey);
            }
        }

        private int IndexOfImageKey(ListView.ListViewItemCollection items, string imageKey)
        {
            foreach (ListViewItem item in items)
                if (item.ImageKey == imageKey)
                    return item.Index;
            throw new Exception("out of range");
        }

        /// <summary>
        /// Display current statistics (in legend).
        /// </summary>
        private void DisplayStats()
        {
            // Update stats.
            foreach (string key in this.stats.counts.Keys)
            {
                try
                {
                    int idx = IndexOfImageKey(this.iconList.Items, key);
                    this.iconList.Items[idx].SubItems[1].Text = this.stats.counts[key].ToString("N0");
                }
                catch (Exception ex)
                {
                    LogMessage(ex.Message);
                }
            }
        }

        /// <summary>
        /// Update Statistic counters based on image key.
        /// </summary>
        /// <param name="chg"></param>
        /// <param name="key"></param>
        /// <param name="_isEmpty"></param>
        private void UpdateStats(int chg, string key, bool _isEmpty)
        {
            this.stats.counts[key]++;
            this.stats.totalFound++;
        }
        #endregion

        #region ---- Misc Stuff
        /// <summary>
        /// Column header click fires sort.
        /// Supports two tier sorting.
        /// </summary>
        private void ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView listView = sender as ListView;
            ListViewColumnSorter sorter = listView.ListViewItemSorter as ListViewColumnSorter;
            if (sorter == null)
                return;

            if (listView.Groups.Count != 0)
                showMsg("Sorting does not work when in 'Group' mode");

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == sorter.SortColumn1)
            {
                // Reverse the current sort direction for this column.
                if (sorter.Order1 == SortOrder.Ascending)
                    sorter.Order1 = SortOrder.Descending;
                else
                    sorter.Order1 = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.SortColumn2 = sorter.SortColumn1;
                sorter.Order2 = sorter.Order1;
                sorter.SortColumn1 = e.Column;
                sorter.Order1 = SortOrder.Ascending;
            }

            // Clear old arrows and set new arrow
            foreach (ColumnHeader colHdr in listView.Columns)
                colHdr.ImageIndex = -1;

            if (sorter.SortColumn1 != sorter.SortColumn2)
                listView.Columns[sorter.SortColumn2].ImageIndex = (sorter.Order2 == SortOrder.Ascending) ? 2 : 3;

            listView.Columns[sorter.SortColumn1].ImageIndex = (sorter.Order1 == SortOrder.Ascending) ? 0 : 1;

            // Perform the sort with these new sort options.
            if (listView != null)
                listView.Sort();
        }

        public static string FixText(string _str) 
        {
			return _str.Replace(@"\r", "")
				.Replace("\n", "\r\n")
				.Replace(@"\n", "\r\n") // Environment.NewLine
				.Replace("\r\r", "\r");
		}

		private void UpdateDeleteStats()
        {
			this.stats.counts["deleted"] = this.stats.deleteCnt;
			this.stats.counts["protected"] = this.stats.failedCnt;  // or "folder_warning"

			this.statusLbl.Text = String.Format(nsREDT.Properties.Resources.red_deleted, this.stats.deleteCnt);
			DisplayStats();
        }

		/// <summary>
		/// Exit
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExitBtn_Click(object sender, EventArgs e)
		{
			this.Close();
        }
        #endregion

        #region ---- Scan Folders for Empty or Trash

        /// <summary>
		/// Starts the Scan-Progress
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void ScanBtn_Click(object sender, EventArgs e)
        {
            ScanDirectories();
        }

        private void pause()
        {
            if ((this.findFldWorker.IsBusy == true) || (findFldWorker.CancellationPending == false))
                findFldWorker.CancelAsync();
        }

		private bool ScanDirectories()
		{
            // OpenLogFile();
            this.currentProcess = Processes.Search;

            protectedFolders = new Dictionary<string, string>();
            emptyFolders = new List<DirectoryInfo>();
            dir2Tree = new Dictionary<string, TreeNode>();
            ClearStats();

			// Scan specified folders
            string dirPaths = string.Empty;
            foreach (string folderPath in this.folderTx.Text.Split(';'))
            {
                DirectoryInfo folderInfo = new DirectoryInfo(this.folderTx.Text);

                if (!folderInfo.Exists)
                {
                    showMsg(nsREDT.Properties.Resources.error_dir_does_not_exist);
                    LogMessage("Invalid " + folderPath);
                    continue;
                }
                if (dirPaths.Length != 0)
                    dirPaths += ";";
                dirPaths += folderInfo.FullName;
            }

            if (dirPaths.Length == 0)
                return false;

            this.folderTx.Text = dirPaths;
            this.settings.Write("folder", dirPaths);


			// Update button states
			this.cancelBtn.Enabled = true;
			this.deleteBtn.Enabled = false;
            this.scanBtn.Enabled = false;

            // Reset TreeView
            this.tvFolders.Nodes.Clear();


			// Set marquee mode
			this.statusBar.Style = ProgressBarStyle.Marquee;
            this.statusLbl.Text = nsREDT.Properties.Resources.scanning_folders;

            this.statusBar.Style = ProgressBarStyle.Marquee;
            this.statusBar.MarqueeAnimationSpeed = 100;
            this.StartFindProcess(dirPaths);
            return true;
        }

		/// <summary>
		/// Start searching for empty folders:
		/// </summary>
		void StartFindProcess(string dirPaths)
		{
            // OpenLogFile();
            LogMessage("Find Started on " + dirPaths);
			this.currentProcess = Processes.Scan;

			emptyFolders = new List<DirectoryInfo>();

			dir2Tree = new Dictionary<String, TreeNode>();
            this.statusLbl.Text = nsREDT.Properties.Resources.searching_empty_folders;

            #region Create root node

            foreach (string dirPath in dirPaths.Split(';'))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                TreeNode rootNode = new TreeNode(dirInfo.Name);
                rootNode.Tag = dirInfo;
                rootNode.ImageKey = "home";
                rootNode.SelectedImageKey = "home";
                this.tvFolders.Nodes.Add(rootNode);
                dir2Tree.Add(dirInfo.FullName.TrimEnd('\\'), rootNode);
            }

            #endregion

            #region Initialize the FolderFindWorker-Object

            findFldWorker = new FindFoldersWorker();
            findFldWorker.ProgressChanged += new ProgressChangedEventHandler(FFWorker_ProgressChanged);
            findFldWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FFWorker_RunWorkerCompleted);

            // set options:
            if (!findFldWorker.SetIgnoreFiles(this.ignoreFilesTx.Text))
                showMsg(nsREDT.Properties.Resources.error_ignore_settings);

            if (!findFldWorker.SetIgnoreFolders(this.ignoreFoldersTx.Text))
                showMsg(nsREDT.Properties.Resources.error_ignore_settings);

            findFldWorker.Ignore0kbFiles = this.cbIgnore0kbFiles.Checked;
            findFldWorker.IgnoreHiddenFolders = this.cbIgnoreHiddenFolders.Checked;
            findFldWorker.KeepSystemFolders = this.cbKeepSystemFolders.Checked;

            findFldWorker.MaxDepth = (UInt16)this.nuMaxDepth.Value;

            // Start worker
            findFldWorker.RunWorkerAsync(dirPaths); 

            #endregion
		}

        /// <summary>
        /// This function gets called on a status update of the find folder worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		void FFWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if ((int)e.ProgressPercentage != -1)
			{
				// Just update the progress bar
				this.statusLbl.Text = (string)e.UserState;
                if (this.statusBar.Style != ProgressBarStyle.Marquee)
				    this.statusBar.Value = (int)e.ProgressPercentage;
			}
			else
			{
				// Found a empty folder:
				DirectoryInfo dirInfo = (DirectoryInfo)e.UserState;
                emptyFolders.Add(dirInfo);
                this.AddFolderToTreeView(dirInfo, true);
			}

            // Update of status slows down app and prevents foreground from reacting to user actions.
            // TODO - throttle update of DisplayStats

            if (((int)e.ProgressPercentage % 5) == 0)
                DisplayStats();
        }

        /// <summary>
        /// Adds a folder to the treeview
        /// </summary>
        /// <param name="Folder"></param>
        /// <param name="_isEmpty"></param>
        /// <returns></returns>
		private TreeNode AddFolderToTreeView(DirectoryInfo Folder, bool _isEmpty)
		{
			// exists already:
			if (dir2Tree.ContainsKey(Folder.FullName))
			{
				//dir2Tree[Folder.FullName].ImageKey = "folder_delete";
                if (dir2Tree[Folder.FullName].ForeColor != Color.Red)
                    UpdateStats(+1, "folder", true);

				dir2Tree[Folder.FullName].ForeColor = Color.Red;
				return dir2Tree[Folder.FullName];
			}

			TreeNode NewNode = new TreeNode(Folder.Name);
			if (_isEmpty)
            {
				//NewNode.ImageKey = "folder_delete";
				NewNode.ForeColor = Color.Red;
            }
			else
            {
				NewNode.ForeColor = Color.Gray;
            }

            bool ContainsTrash = (!(Folder.GetFiles().Length == 0) && _isEmpty);

            NewNode.ImageKey = ContainsTrash ? "folder_trash_files" : "folder";
        
			if ((Folder.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                NewNode.ImageKey = ContainsTrash ? "folder_hidden_trash_files" : "folder_hidden";

		//	if ((Folder.Attributes & FileAttributes.Encrypted) == FileAttributes.Encrypted)
        //        NewNode.ImageKey = ContainsTrash ? "folder_lock_trash_files" : "folder_lock";

            if ((Folder.Attributes & FileAttributes.System) == FileAttributes.System)
            {
                NewNode.ImageKey = ContainsTrash ? "folder_lock_trash_files" : "folder_lock";
                if (cbKeepSystemFolders.Checked)
                    NewNode.ForeColor = Color.Gray;
            }

            if ((Folder.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                NewNode.ImageKey = ContainsTrash ? "folder_readonly_trash" : "folder_readonly";
                if (!cbDeleteReadonly.Checked)
                    NewNode.ForeColor = Color.Gray;
            }

            UpdateStats(+1, NewNode.ImageKey, _isEmpty);
            

            // DEBUG
            // System.Diagnostics.Debug.WriteLine(this.stats.emptyCnt.ToString()+ ", " + Folder.FullName + " " + NewNode.ImageKey);
          
            NewNode.SelectedImageKey = NewNode.ImageKey;

			NewNode.Tag = Folder;

#if false
			if (Folder.Parent.FullName.Trim('\\') == this.startFolder.FullName.Trim('\\'))
				this.rootNode.Nodes.Add(NewNode);
			else 
#endif
            {
                TreeNode ParentNode;
                if (Folder.Parent != null)
                {
                    ParentNode = this.FindTreeNodeByFolder(Folder.Parent);
                    ParentNode.Nodes.Add(NewNode);
                }
                else
                {
                    // Should never get here
                    string err = Folder.Name;
                }
			}

			dir2Tree.Add(Folder.FullName, NewNode);

			NewNode.EnsureVisible();

			return NewNode;
		}


        /// <summary>
        /// Returns a TreeNode Object for a given Folder
        /// </summary>
        /// <param name="Folder"></param>
        /// <returns></returns>
        private TreeNode FindTreeNodeByFolder(DirectoryInfo dirInfo)
		{
			// Folder exists already:
            if (dir2Tree.ContainsKey(dirInfo.FullName))
                return dir2Tree[dirInfo.FullName];
			else
                return AddFolderToTreeView(dirInfo, false);
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		void FFWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			FindFoldersWorker FindWorker = sender as FindFoldersWorker;

			// First, handle the case where an exception was thrown.
			if (e.Error != null)
                showMsg(nsREDT.Properties.Resources.error + "\n\n" + e.Error.Message);
			else if (e.Cancelled)
                this.statusLbl.Text = nsREDT.Properties.Resources.process_cancelled;	
			else
			{
				int cnt = dir2Tree.Count;
                this.statusLbl.Text = String.Format(
                    nsREDT.Properties.Resources.found_x_empty_folders, 
                    FindWorker.EmptyFolderCount, 
                    FindWorker.FolderCount);
				e = null;
                this.stats.ignoredFolderCnt += FindWorker.IgnoredFolderCount;
			}

            this.DisplayStats();
            this.statusBar.MarqueeAnimationSpeed = 0;
            this.statusBar.Style = ProgressBarStyle.Blocks;
            this.statusBar.Value = this.statusBar.Maximum;

			this.scanBtn.Enabled = true;
			this.cancelBtn.Enabled = false;

			findFldWorker.Dispose();
			findFldWorker = null;

            if (this.tvFolders.Nodes.Count != 0)
                this.tvFolders.Nodes[0].EnsureVisible();

            if (FindWorker.EmptyFolderCount != 0)
			    this.deleteBtn.Enabled = true;

			this.scanBtn.Text = nsREDT.Properties.Resources.btn_scan_again;

			this.currentProcess = Processes.Idle;
            LogMessage(this.statusLbl.Text);
            // CloseLogFile();
        }
        #endregion

        /// <summary>
		/// Let's the user select a folder
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChooseFolderBtn_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dlgFolder = new FolderBrowserDialog();

			dlgFolder.Description = nsREDT.Properties.Resources.please_select;
			dlgFolder.ShowNewFolderButton = false;

            if (this.folderTx.Text != "")
            {
                DirectoryInfo dir = new DirectoryInfo(this.folderTx.Text);

                if (dir.Exists)
                    dlgFolder.SelectedPath = this.folderTx.Text;
            }

			if (dlgFolder.ShowDialog() == DialogResult.OK)
				this.folderTx.Text = dlgFolder.SelectedPath;	

			dlgFolder.Dispose();
			dlgFolder = null;
		}

        /// <summary>
        /// User clicks twice on a folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderTree_DoubleClick(object sender, EventArgs e)
        {
            this.OpenFolder();
        }

        private void FolderTree_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode TvNode = this.tvFolders.GetNodeAt(e.X, e.Y);
            this.tvFolders.SelectedNode = TvNode;
        }

		/// <summary>
		/// User hit's cancel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CancelScanBtn_Click(object sender, EventArgs e)
		{
			if (this.currentProcess == Processes.Scan && this.findFldWorker != null)
			{
				if ((this.findFldWorker.IsBusy == true) || (findFldWorker.CancellationPending == false))
					findFldWorker.CancelAsync();

				this.scanBtn.Enabled = true;
				
			}
			else if (this.currentProcess == Processes.Delete)
			{
				this.stopDeleteProcess = true;
				this.scanBtn.Enabled = true;
				this.deleteBtn.Enabled = false;
			}

			this.cancelBtn.Enabled = false;

			this.currentProcess = Processes.Idle;
		}

        /// <summary>
        /// Opens a folder
        /// </summary>
        private void OpenFolder()
        {
            string path = this.GetSelectedFolderPath();

            if (path == "")
                return;

            string windows_folder = Environment.GetEnvironmentVariable("SystemRoot");

            Process.Start(windows_folder + "\\explorer.exe", "/e,\"" + path + "\"");
        }


        /// <summary>
        /// Returns the selected folder path
        /// </summary>
        /// <returns></returns>
		private string GetSelectedFolderPath()
		{
			if (this.tvFolders.SelectedNode != null && this.tvFolders.SelectedNode.Tag != null)
			{
				DirectoryInfo folder = (DirectoryInfo)this.tvFolders.SelectedNode.Tag;
				return folder.FullName;
			}
			return "";
		}


		/// <summary>
		/// Integrates RED into the Windows explorer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddToExplorer_CheckedChanged(object sender, EventArgs e)
		{
			RegistryKey regmenu = null;
			RegistryKey regcmd = null;

			CheckBox cb = (CheckBox)sender;

			if (cb.Checked)
			{
				try
				{
					if (IsRunningAsAdmin()) {
						regmenu = Registry.ClassesRoot.CreateSubKey(menuName);
						if (regmenu != null)
							regmenu.SetValue("", nsREDT.Properties.Resources.registry_name);

						regcmd = Registry.ClassesRoot.CreateSubKey(command);
						if (regcmd != null)
							regcmd.SetValue("", Application.ExecutablePath + " \"%1\"");
					} else {
						showMsg("Warning\nNormal permission does not allow registering REDT into windows explorer menu");
					}
				}
				catch (Exception ex)
				{
					showMsg( ex.ToString());
				}
				finally
				{
					if (regmenu != null)
						regmenu.Close();
					if (regcmd != null)
						regcmd.Close();
				}
			}
			else 
            {
				try
				{
					RegistryKey reg = Registry.ClassesRoot.OpenSubKey(command);
					if (reg != null)
					{
						reg.Close();
						Registry.ClassesRoot.DeleteSubKey(command);
					}
					reg = Registry.ClassesRoot.OpenSubKey(menuName);
					if (reg != null)
					{
						reg.Close();
						Registry.ClassesRoot.DeleteSubKey(menuName);
					}
				}
				catch (Exception ex)
				{
					showMsg(nsREDT.Properties.Resources.error + "\n\n" + this, ex.ToString());
				}
			}
        }

        #region ---- Delete Empty (or w/trash) Directory Folders

        /// <summary>
        /// Deletes all empty folders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void DeleteBtn_Click(object sender, EventArgs e)
		{
            DoDelete(emptyFolders, string.Empty);
        }

        /// <summary>
        /// Parse Ignore File list (convert all to lowercase).
        ///   If the file pattern contains * convert to regular expression ".*"
        ///   If the file pattern is wrapped in slashes, convert to regular expression
        ///   Else assume text
        /// </summary>
        private void GetIgnoreFiles()
        {
            ignoreLwr.Clear();
            ignoreRegex.Clear();

            string[] ignoreFiles = FormatAndSplit(this.ignoreFilesTx.Text);
            foreach (string pattern in ignoreFiles)
            {
                if (pattern.Contains("*"))
                {
                    string regStr = Regex.Escape(pattern.ToLower());
                    regStr = regStr.Replace("\\*", ".*");
                    ignoreRegex.Add(new Regex("^" + regStr + "$"));
                }
                else if (pattern.StartsWith("/") && pattern.EndsWith("/"))
                {
                    ignoreRegex.Add(new Regex(pattern.ToLower().Substring(1, pattern.Length - 2)));
                }
                else
                {
                    ignoreLwr.Add(pattern.ToLower());
                }
            }
        }

        private void DoDelete(List<DirectoryInfo> emptyDirs, string baseDir)
        {
            this.statusLbl.Text = nsREDT.Properties.Resources.rem_empty_folders;

			this.currentProcess = Processes.Delete;
			this.stopDeleteProcess = false;

			this.scanBtn.Enabled = false;
			this.cancelBtn.Enabled = true;

			UInt32 deletedFolderCount = 0;
            UInt32 failedFolderCount = 0;

            this.statusBar.Maximum = emptyDirs.Count;
            this.statusBar.Minimum = 0;
            this.statusBar.Step = 5;

            GetIgnoreFiles();

            UInt32 FolderCount = (UInt32)emptyDirs.Count;

			for (int i = 0; (i < emptyDirs.Count && !this.stopDeleteProcess); i++)
			{
				DirectoryInfo Folder = emptyDirs[i];

                if (Folder.FullName.Contains(baseDir) == false)
                    continue;

                // Do not delete protected folders:
                if (!this.protectedFolders.ContainsKey(Folder.FullName))
                {
                    if (this.SecureDelete(Folder))
                    {
                        this.statusLbl.Text = String.Format(nsREDT.Properties.Resources.removing_empty_folders, (i + 1), FolderCount);
                        this.MarkAsDeleted(Folder);
                        deletedFolderCount++;
                    }
                    else
                    {
                        this.MarkAsWarning(Folder);
                        failedFolderCount++;
                    }

                    Application.DoEvents();

                    // Thread.Sleep(TimeSpan.FromMilliseconds((double)this.nuMaxFolder.Value));
                }
				
                this.statusBar.Value = i;

			}

            this.statusBar.Value = this.statusBar.Maximum;

            this.statusLbl.Text = String.Format(nsREDT.Properties.Resources.found_x_empty_folders, 
                    deletedFolderCount, failedFolderCount);

            #region Update delete stats
            this.stats.deleteCnt += deletedFolderCount;
            this.stats.failedCnt += failedFolderCount;

			UpdateDeleteStats();
            LogMessage(string.Format("Deleted {0}, Failed to delete {1}", 
                    deletedFolderCount, failedFolderCount));

            #endregion

			this.deleteBtn.Enabled = false;
			this.scanBtn.Enabled = true;
			this.cancelBtn.Enabled = false;

			this.currentProcess = Processes.Idle;
		}


        /// <summary>
        /// Marks a folder with the "warning" icon
        /// </summary>
        /// <param name="Folder"></param>
		private void MarkAsWarning(DirectoryInfo Folder)
		{
			TreeNode FNode = this.FindTreeNodeByFolder(Folder);
            FNode.ImageKey = "folder_warning";
            FNode.SelectedImageKey = "folder_warning";
            FNode.EnsureVisible();
		}


        /// <summary>
        /// Marks a folder with the "deleted" icon
        /// </summary>
        /// <param name="Folder"></param>
		private void MarkAsDeleted(DirectoryInfo Folder)
		{
			TreeNode FNode = this.FindTreeNodeByFolder(Folder);
			FNode.ImageKey = "deleted";
            FNode.SelectedImageKey = "deleted";
            FNode.EnsureVisible();
		}

        /// <summary>
        /// Finally delete a folder (with security checks before)
        /// </summary>
        /// <param name="Folder"></param>
        /// <returns></returns>
		private bool SecureDelete(DirectoryInfo Folder)
		{
            if (!Directory.Exists(Folder.FullName))
                return false;

            if (cbDeleteReadonly.Checked &&
                        (Folder.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                try
                { 
                    Folder.Attributes -= FileAttributes.ReadOnly;
                }
                catch (Exception ex)
                {
                    LogMessage(ex.Message);
                }
            }

            this.CleanupFolder(Folder);

            // last security check (for files):
			if (Folder.GetFiles().Length == 0 && Folder.GetDirectories().Length == 0)
			{
                try
                {
                    Folder.Delete();
                    LogMessage(Folder.FullName);
                    return true;
                }
                catch (Exception ex)
                {
                    LogMessage(ex.Message);
                    return false;
                }
			}
			return false;
		}

        
        /// <summary>
        /// This function deletes file trash (0 kb files or user given files)
        /// </summary>
        /// <param name="_StartFolder"></param>
        private void CleanupFolder(DirectoryInfo startFolder)
        {
            // Read files:
            FileInfo[] Files = startFolder.GetFiles();

            if (Files != null && Files.Length != 0)
            {
                // loop trough files and cancel if containsFiles == true
                for (int f = 0; f < Files.Length; f++)
                {
                    try
                    {
                        FileInfo file = Files[f];

                        bool matches_a_pattern = false;
                        if (this.cbIgnore0kbFiles.Checked && file.Length == 0)
                            matches_a_pattern = true;

                        string fileLwr = file.Name.ToLower();
                        for (int p = 0; (p < ignoreLwr.Count && !matches_a_pattern); p++)
                        {
                            string pattern = ignoreLwr[p];
                            if (pattern == fileLwr)
                                matches_a_pattern = true;
                        }

                        for (int p = 0; (p < ignoreRegex.Count && !matches_a_pattern); p++)
                        {
                            Regex pattern = ignoreRegex[p];
                            if (pattern.IsMatch(fileLwr))
                                matches_a_pattern = true;
                        }

                        // If only one file is good, then stop.
                        if (matches_a_pattern)
                        {
                            if (cbDeleteReadonly.Checked &&
                                (file.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                                file.Attributes -= FileAttributes.ReadOnly;
                            file.Delete();
                        }

                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Failed to access " + Files[f] + " " + ex.Message);
                    }
                }
            }
        }
 
        private String[] FormatAndSplit(string _pattern)
        {
            _pattern = _pattern.Replace("\r\n", "\n");
            _pattern = _pattern.Replace("\r", "\n");            
            return _pattern.Split('\n');
        }
        #endregion


        /// <summary>
        /// Part of the drag & drop functions 
        /// (you can drag a folder into RED)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Main_DragDrop(object sender, DragEventArgs e)
		{
			string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			if (s.Length == 1)
				this.folderTx.Text = s[0];
			else
                showMsg(nsREDT.Properties.Resources.error_only_one_folder);
		}

        /// <summary>
        /// Part of the drag & drop functions 
        /// (you can drag a folder into RED)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Main_DragEnter(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			else 
				e.Effect = DragDropEffects.Copy;			
		}

        #region ---- Save setting functions

        private void cbKeepSystemFolders_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbKeepSystemFolders.Tag == null)
            {
                if (!this.cbKeepSystemFolders.Checked)
                {
                    if (MessageBox.Show(this, FixText(
                            nsREDT.Properties.Resources.warning_really_delete), 
                            nsREDT.Properties.Resources.warning, 
                            MessageBoxButtons.OKCancel, 
                            MessageBoxIcon.Asterisk) == DialogResult.Cancel)
                        this.cbKeepSystemFolders.Checked = true;
                }

                this.settings.Write("keep_system_folders", this.cbKeepSystemFolders.Checked);
            }
            else
            {
                this.cbKeepSystemFolders.Tag = null;
            }
        }

        private void cbIgnoreHiddenFolders_CheckedChanged(object sender, EventArgs e)
        {
            this.settings.Write("dont_scan_hidden_folders", this.cbIgnoreHiddenFolders.Checked);
        }

        private void cbIgnore0kbFiles_CheckedChanged(object sender, EventArgs e)
        {
            this.settings.Write("ignore_0kb_files", this.cbIgnore0kbFiles.Checked);
        }

        private void cbDeleteReadonly_CheckedChanged(object sender, EventArgs e)
        {
            this.settings.Write("delete_readonly", cbDeleteReadonly.Checked);
        }

        private void nuMaxDepth_ValueChanged(object sender, EventArgs e)
        {
            this.settings.Write("max_depth", (int)this.nuMaxDepth.Value);
        }
        private void nuFolder_ValueChanged(object sender, EventArgs e)
        {
            this.settings.Write("max_folder", (int)this.nuMaxFolder.Value);
            this.maxFolders = (uint)this.nuMaxFolder.Value;
        }

        private void tbIgnoreFiles_TextChanged(object sender, EventArgs e)
        {
            this.settings.Write("ignore_files", ignoreFilesTx.Text);
        }

        private void tbIgnoreFolders_TextChanged(object sender, EventArgs e)
        {
            this.settings.Write("ignore_folders", ignoreFoldersTx.Text);
        }

     
        #endregion	

        #region ---- Weblinks

        private void JonasJohn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.jonasjohn.de/");
        }

        private void DennisLang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://landenlabs.com/index.html");
        }

        #endregion

        #region ---- Context menu items 
        private void OpenFolderMenu_Click(object sender, EventArgs e)
        {
            this.OpenFolder();
        }

        private void DeleteFoldersOnBranchMenu_Click(object sender, EventArgs e)
        {
            // string path = this.GetSelectedFolderPath();
            TreeNode Node = this.tvFolders.SelectedNode;

            if (Node != null)
            {
                DirectoryInfo Folder = (DirectoryInfo)Node.Tag;
                DoDelete(emptyFolders, Folder.FullName);
                DisplayStats();
            }
        }

        private void ProtectFolderFromBeingDeletedMenu_Click(object sender, EventArgs e)
        {
            TreeNode Node = this.tvFolders.SelectedNode;

            if (Node != null)
            {
                ProtectNode(Node);
                DisplayStats();
            }
        }

        private void ProtectNode(TreeNode Node)
        {
            DirectoryInfo Folder = (DirectoryInfo)Node.Tag;

            if (!this.protectedFolders.ContainsKey(Folder.FullName))
            {
                this.protectedFolders.Add(Folder.FullName, Node.ImageKey + "|" + Node.ForeColor.ToArgb().ToString());
                bool _isEmpty = (Node.ForeColor == Color.Red);
                UpdateStats(-1, Node.ImageKey, _isEmpty); // back out previous counting of this object.
                UpdateStats(+1, "protected", _isEmpty);
            }

            Node.ImageKey = "protected";
            Node.SelectedImageKey = "protected";
            Node.ForeColor = Color.Blue;

            if (Node.Parent != null)            
                ProtectNode(Node.Parent);            
        }

        private void UnProtectFolderMenu_Click(object sender, EventArgs e)
        {
            TreeNode Node = this.tvFolders.SelectedNode;

            if (Node != null)
                UnProtectNode(Node);
        }

        private void UnProtectNode(TreeNode Node)
        {          
            DirectoryInfo Folder = (DirectoryInfo)Node.Tag;

            if (this.protectedFolders.ContainsKey(Folder.FullName))
            {
                string[] BackupValues = ((string)this.protectedFolders[Folder.FullName]).Split('|');

                string ImageKey = BackupValues[0];
                Color NodeColor = Color.FromArgb(Int32.Parse(BackupValues[1]));

                Node.ImageKey = ImageKey;
                Node.SelectedImageKey = ImageKey;
                Node.ForeColor = NodeColor;

                this.protectedFolders.Remove(Folder.FullName);

                foreach (TreeNode SubNode in Node.Nodes) {
                    this.UnProtectNode(SubNode);                
                }
            }
        }

        private void ProtectFolderMenu_Click(object sender, EventArgs e)
        {
            this.mainTab.SelectedIndex = 1;

            TreeNode Node = this.tvFolders.SelectedNode;
            DirectoryInfo Folder = (DirectoryInfo)Node.Tag;

            this.ignoreFoldersTx.Text += "\r\n" + Folder.FullName;
        }

        private void MakeWriteableNode(TreeNode Node, bool recurse)
        {
            DirectoryInfo Folder = (DirectoryInfo)Node.Tag;
            bool readOnly = (Folder.Attributes & FileAttributes.ReadOnly) != 0;
            DirectorySecurity security = Directory.GetAccessControl(Folder.FullName);

            if (readOnly && !this.protectedFolders.ContainsKey(Folder.FullName))
            {
                try
                {
                    Folder.Attributes -= FileAttributes.ReadOnly;

                    // folder_readonly -> folder
                    // folder_readonly_trash -> folder_trash_files
                    string newImageKey = null;
                    if (Node.ImageKey == "folder_readonly")
                    {
                        newImageKey = "folder";
                        this.stats.counts[Node.ImageKey]--;
                        this.stats.counts[newImageKey]++;
                    }
                    else if (Node.ImageKey == "folder_readonly_trash")
                    {
                        newImageKey = "folder_trash_files";
                        this.stats.counts[Node.ImageKey]--;
                        this.stats.counts[newImageKey]++;
                    }

                    if (!string.IsNullOrEmpty(newImageKey))
                    {
                        Node.ImageKey = newImageKey;
                        Node.SelectedImageKey = newImageKey;
                        Node.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    this.statusLbl.Text = ex.Message;
                    LogMessage("Make Writable " + Folder.FullName + " " + ex.Message);
                }

                if (recurse)
                {
                    foreach (TreeNode SubNode in Node.Nodes)
                    {
                        this.MakeWriteableNode(SubNode, true);
                    }
                }
            }
        }

        private void MakeFolderWriteableMenu_Click(object sender, EventArgs e)
        {
            TreeNode Node = this.tvFolders.SelectedNode;

            if (Node != null)
                MakeWriteableNode(Node, false);
            DisplayStats();
        }

        private void MakeFoldersWriteableMenu_Click(object sender, EventArgs e)
        {
            TreeNode Node = this.tvFolders.SelectedNode;

            if (Node != null)
                MakeWriteableNode(Node, true);
            DisplayStats();
        }

        #endregion


        private void Main_ResziseEnd(object sender, EventArgs e)
        {
            splitLeftRight.SplitterDistance = splitLeftRight.Width - 200;
            iconList.Columns[0].Width = iconList.Width *2 / 3;
            iconList.Columns[1].Width = iconList.Width / 3;
        }

        private void tbFolder_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }

        #region ---- Directory View
        private void MainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTab.SelectedTab == tabEmpDir)
            {
                // Directory Tabular view just opened so fill UI now.
                LoadDirView();
            }
        }

        private void LoadDirView()
        {
            Regex regEx = null;
            try
            {
                regEx = new Regex(filterTx.Text);
            }
            catch (Exception ex)
            {
                string regHelp = 
                          " ---\n"
                        + " .  Match any character except newline \n"
                        + "\\w  Match any alphanumeric character \n"
                        + "\\s  Match any whitespace character \n"
                        + "\\d  Match any digit \n"
                        + "\\b  Match the beginning or end of a word \n"
                        + "^   Match the beginning of the string \n"
                        + "$   Match the end of the string \n" 
                        + "\n"
                        + "*   Repeat previous any number of times \n" 
                        + "?   Repeat previous zero or one time \n"
                        + "+   Repeat previous one or more \n";
                MessageBox.Show("Invalid Filter, " + ex.Message + regHelp);
                regEx = new Regex(".*");
            }

            dirView.Items.Clear();
            dirView.BeginUpdate();
            ListViewItem item;

            if (emptyFolders != null)
            foreach (DirectoryInfo dirInfo in emptyFolders)
            {
                if (dirView.Items.Count > maxFolders)
                    break;
                if (regEx.IsMatch(dirInfo.FullName))
                {
                    item = dirView.Items.Add(dirInfo.FullName);
                    item.SubItems.Add(dirInfo.Name);
                    item.SubItems.Add(dirInfo.LastAccessTime.ToString("G"));
                    item.SubItems.Add(dirInfo.CreationTime.ToString("G"));
                    item.SubItems.Add(dirInfo.Attributes.ToString());
                    item.Tag = dirInfo;
                }
            }
            dirView.EndUpdate();
            dirViewCountTxt.Text = dirView.Items.Count.ToString("d");
            dirViewDelBtn.Enabled = dirViewIgnoreBtn.Enabled = false;
        }

        private void applyFltBtn_Click(object sender, EventArgs e)
        {
            LoadDirView();
        }

        /// <summary>
        /// Delete items from Empty Directory Tabular View.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dirViewDelBtn_Click(object sender, EventArgs e)
        {
            UInt32 deletedFolderCount = 0;
            UInt32 failedFolderCount = 0;

            foreach (ListViewItem item in dirView.SelectedItems)
            {
                DirectoryInfo Folder = (DirectoryInfo)item.Tag;

                if (this.SecureDelete(Folder))
                {
                    // this.statusLbl.Text = String.Format(nsREDT.Properties.Resources.removing_empty_folders, (i + 1), FolderCount);
                    this.MarkAsDeleted(Folder);
                    deletedFolderCount++;
                    dirView.Items.Remove(item);
                }
                else
                {
                    this.statusLbl.Text = this.lastMsg;
                    item.BackColor = Color.LightPink;
                    this.MarkAsWarning(Folder);
                    failedFolderCount++;
                    item.BackColor = Color.LightPink;
                }
            }

            this.stats.failedCnt += failedFolderCount;
            this.stats.deleteCnt += deletedFolderCount;
            if (failedFolderCount != 0 || deletedFolderCount != 0)
                UpdateDeleteStats(); 
        }

        private void dirViewIgnBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in dirView.SelectedItems)
            {
                DirectoryInfo Folder = (DirectoryInfo)item.Tag;
                emptyFolders.Remove(Folder);
                dirView.Items.Remove(item);
            }
        }

        private void dirView_SelectedIndexChanged(object sender, EventArgs e)
        {
            dirViewCountTxt.Text = dirView.SelectedItems.Count.ToString("d");
            dirViewDelBtn.Enabled = dirViewIgnoreBtn.Enabled = (dirView.SelectedItems.Count > 0);
        }
        #endregion

        #region ---- Log File
        /// <summary>
        /// Allow Tab to auto-complete built-in file search.
        /// </summary>
        private void LogTb_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                e.IsInputKey = true;
        }

        /// <summary>
        /// If Log File present, display it.
        /// </summary>
        private void ShowLogBtn_Click(object sender, EventArgs e)
        {
            CloseLogFile();
            if (logTb.Text.Length != 0 && File.Exists(logTb.Text))
            {
                try
                {
                    Process.Start(logTb.Text);
                }
                catch {
					showMsg("Empty log file or invalid log file path, see settings");
				}
            }
        }

        private void LogTb_TextChanged(object sender, EventArgs e)
        {
            this.showLogBtn.Enabled = logTb.Text.Length != 0;
			if (!File.Exists(logTb.Text))
				this.logTb.ForeColor = Color.Red;
			else
				this.logTb.ForeColor = Color.Black;
		}

        TextWriter logWriter = null;
        string lastMsg = string.Empty;

        /// <summary>
        /// Open Log file for writting.
        /// </summary>
        private void OpenLogFile()
        {
            settings.Write("log_file", logTb.Text);
            CloseLogFile();

            // bool append = true;
            try
            {
                var fileStream = new FileStream(logTb.Text, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                logWriter = new StreamWriter(fileStream);   // logTb.Text, append);
            }
            catch (Exception ex)
            {
                showMsg(ex + " " + logTb.Text);
            }
        }

        /// <summary>
        /// Save message to log file (if present).
        /// </summary>
        /// <param name="msg"></param>
        private void LogMessage(string msg)
        {
            if (logWriter == null)
                OpenLogFile();
            this.lastMsg = msg;
            string logMsg = DateTime.Now.ToString() + " " + msg;
            if (logWriter != null)
                logWriter.WriteLine(logMsg);
            else
                System.Diagnostics.Trace.WriteLine(logMsg);
        }

        private void CloseLogFile()
        {
            if (logWriter != null)
                logWriter.Close();
            logWriter = null;
        }
        #endregion

        private void logBtn_Click(object sender, EventArgs e)
        {
            this.setLogFileDlg.FileName = logTb.Text;
            if (this.setLogFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (this.setLogFileDlg.FileName != logTb.Text)
                {
                    CloseLogFile();
                    logTb.Text = this.setLogFileDlg.FileName;
                }
            }
        }

        private void showLogBtn2_Click(object sender, EventArgs e)
        {
            ShowLogBtn_Click(sender, e);
        }

		HashSet<string> shownMsgs = new HashSet<string>();
		private void showMsg(string msg) {
			showMsg(msg, "");
		}
		private void showMsg(string msg, string arg) {
			if (!shownMsgs.Contains(msg) && shownMsgs.Count < 20) {
				shownMsgs.Add(msg);
				MessageBox.Show(msg, arg);
			}
		}
    }
}