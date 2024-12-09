namespace nsREDT
{
	partial class Main
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.cbIntegrateIntoWindowsExplorer = new System.Windows.Forms.CheckBox();
            this.ilFolderIcons = new System.Windows.Forms.ImageList(this.components);
            this.mainTab = new System.Windows.Forms.TabControl();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.showLogBtn = new System.Windows.Forms.Button();
            this.splitLeftRight = new System.Windows.Forms.SplitContainer();
            this.tvFolders = new System.Windows.Forms.TreeView();
            this.cmStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFolderMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFoldersOnBranchMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.protectFolderFromBeingDeletedMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.unprotectFolderMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.protectFolderMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.makeFolderWriteableMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.makeFoldersWriteableMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.label12 = new System.Windows.Forms.Label();
            this.iconList = new System.Windows.Forms.ListView();
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancelBtn = new System.Windows.Forms.Button();
            this.scanBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.chooseFolderLb = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.ProgressBar();
            this.exitBtn = new System.Windows.Forms.Button();
            this.folderTx = new System.Windows.Forms.TextBox();
            this.chooseFolderBtn = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.settingTable = new System.Windows.Forms.TableLayoutPanel();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.cbDeleteReadonly = new System.Windows.Forms.CheckBox();
            this.cbIgnoreHiddenFolders = new System.Windows.Forms.CheckBox();
            this.cbKeepSystemFolders = new System.Windows.Forms.CheckBox();
            this.cbIgnore0kbFiles = new System.Windows.Forms.CheckBox();
            this.grpAdvanced = new System.Windows.Forms.GroupBox();
            this.maxValueTbl = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.nuMaxDepth = new System.Windows.Forms.NumericUpDown();
            this.nuMaxFolder = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.innerTable = new System.Windows.Forms.TableLayoutPanel();
            this.grpIgnoreFiles = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ignoreFilesTx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpFolders = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ignoreFoldersTx = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.showLogBtn2 = new System.Windows.Forms.Button();
            this.logBtn = new System.Windows.Forms.Button();
            this.logTb = new System.Windows.Forms.TextBox();
            this.tabEmpDir = new System.Windows.Forms.TabPage();
            this.filterGrp = new System.Windows.Forms.GroupBox();
            this.filterTx = new System.Windows.Forms.TextBox();
            this.applyFltBtn = new System.Windows.Forms.Button();
            this.dirViewCountTxt = new System.Windows.Forms.TextBox();
            this.dirViewLbl = new System.Windows.Forms.Label();
            this.dirViewIgnoreBtn = new System.Windows.Forms.Button();
            this.dirViewDelBtn = new System.Windows.Forms.Button();
            this.dirView = new System.Windows.Forms.ListView();
            this.col_path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_dir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_mdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_cdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_cat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.website1Lb = new System.Windows.Forms.Label();
            this.dlangLink = new System.Windows.Forms.LinkLabel();
            this.dlangLb = new System.Windows.Forms.Label();
            this.horzLine = new System.Windows.Forms.Panel();
            this.hintsLb = new System.Windows.Forms.Label();
            this.hints1Lb = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.jJohnLink = new System.Windows.Forms.LinkLabel();
            this.appTitleLb = new System.Windows.Forms.Label();
            this.setLogFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.mainTab.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.splitLeftRight.Panel1.SuspendLayout();
            this.splitLeftRight.Panel2.SuspendLayout();
            this.splitLeftRight.SuspendLayout();
            this.cmStrip.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.settingTable.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.grpAdvanced.SuspendLayout();
            this.maxValueTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuMaxDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuMaxFolder)).BeginInit();
            this.innerTable.SuspendLayout();
            this.grpIgnoreFiles.SuspendLayout();
            this.grpFolders.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.tabEmpDir.SuspendLayout();
            this.filterGrp.SuspendLayout();
            this.tabAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cbIntegrateIntoWindowsExplorer
            // 
            this.cbIntegrateIntoWindowsExplorer.AutoSize = true;
            this.cbIntegrateIntoWindowsExplorer.Location = new System.Drawing.Point(13, 26);
            this.cbIntegrateIntoWindowsExplorer.Name = "cbIntegrateIntoWindowsExplorer";
            this.cbIntegrateIntoWindowsExplorer.Size = new System.Drawing.Size(176, 17);
            this.cbIntegrateIntoWindowsExplorer.TabIndex = 1;
            this.cbIntegrateIntoWindowsExplorer.Text = "Integrate into Windows Explorer";
            this.cbIntegrateIntoWindowsExplorer.UseVisualStyleBackColor = true;
            this.cbIntegrateIntoWindowsExplorer.CheckedChanged += new System.EventHandler(this.AddToExplorer_CheckedChanged);
            // 
            // ilFolderIcons
            // 
            this.ilFolderIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilFolderIcons.ImageStream")));
            this.ilFolderIcons.TransparentColor = System.Drawing.Color.White;
            this.ilFolderIcons.Images.SetKeyName(0, "trash");
            this.ilFolderIcons.Images.SetKeyName(1, "cancel");
            this.ilFolderIcons.Images.SetKeyName(2, "deleted");
            this.ilFolderIcons.Images.SetKeyName(3, "folder");
            this.ilFolderIcons.Images.SetKeyName(4, "folder_hidden");
            this.ilFolderIcons.Images.SetKeyName(5, "folder_lock");
            this.ilFolderIcons.Images.SetKeyName(6, "folder_lock_trash_files");
            this.ilFolderIcons.Images.SetKeyName(7, "folder_trash_files");
            this.ilFolderIcons.Images.SetKeyName(8, "folder_warning");
            this.ilFolderIcons.Images.SetKeyName(9, "help");
            this.ilFolderIcons.Images.SetKeyName(10, "home");
            this.ilFolderIcons.Images.SetKeyName(11, "search");
            this.ilFolderIcons.Images.SetKeyName(12, "folder_hidden_trash_files");
            this.ilFolderIcons.Images.SetKeyName(13, "preferences");
            this.ilFolderIcons.Images.SetKeyName(14, "exit");
            this.ilFolderIcons.Images.SetKeyName(15, "protected");
            this.ilFolderIcons.Images.SetKeyName(16, "folder_readonly");
            this.ilFolderIcons.Images.SetKeyName(17, "folder_readonly_trash");
            // 
            // mainTab
            // 
            this.mainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTab.Controls.Add(this.tabSearch);
            this.mainTab.Controls.Add(this.tabSettings);
            this.mainTab.Controls.Add(this.tabEmpDir);
            this.mainTab.Controls.Add(this.tabAbout);
            this.mainTab.ImageList = this.ilFolderIcons;
            this.mainTab.Location = new System.Drawing.Point(7, 6);
            this.mainTab.Multiline = true;
            this.mainTab.Name = "mainTab";
            this.mainTab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainTab.SelectedIndex = 0;
            this.mainTab.ShowToolTips = true;
            this.mainTab.Size = new System.Drawing.Size(592, 541);
            this.mainTab.TabIndex = 18;
            this.mainTab.SelectedIndexChanged += new System.EventHandler(this.MainTab_SelectedIndexChanged);
            // 
            // tabSearch
            // 
            this.tabSearch.AccessibleDescription = "";
            this.tabSearch.AccessibleName = "";
            this.tabSearch.BackColor = System.Drawing.Color.Transparent;
            this.tabSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabSearch.Controls.Add(this.pauseBtn);
            this.tabSearch.Controls.Add(this.showLogBtn);
            this.tabSearch.Controls.Add(this.splitLeftRight);
            this.tabSearch.Controls.Add(this.cancelBtn);
            this.tabSearch.Controls.Add(this.scanBtn);
            this.tabSearch.Controls.Add(this.deleteBtn);
            this.tabSearch.Controls.Add(this.chooseFolderLb);
            this.tabSearch.Controls.Add(this.statusLbl);
            this.tabSearch.Controls.Add(this.statusBar);
            this.tabSearch.Controls.Add(this.exitBtn);
            this.tabSearch.Controls.Add(this.folderTx);
            this.tabSearch.Controls.Add(this.chooseFolderBtn);
            this.tabSearch.ImageKey = "search";
            this.tabSearch.Location = new System.Drawing.Point(4, 23);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(584, 514);
            this.tabSearch.TabIndex = 0;
            this.tabSearch.Text = "Scan";
            this.tabSearch.ToolTipText = "Search for empty directories";
            // 
            // pauseBtn
            // 
            this.pauseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pauseBtn.Image = ((System.Drawing.Image)(resources.GetObject("pauseBtn.Image")));
            this.pauseBtn.Location = new System.Drawing.Point(169, 426);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(32, 21);
            this.pauseBtn.TabIndex = 19;
            this.pauseBtn.UseVisualStyleBackColor = true;
            // 
            // showLogBtn
            // 
            this.showLogBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showLogBtn.Enabled = false;
            this.showLogBtn.ImageKey = "(none)";
            this.showLogBtn.Location = new System.Drawing.Point(336, 457);
            this.showLogBtn.Name = "showLogBtn";
            this.showLogBtn.Size = new System.Drawing.Size(88, 34);
            this.showLogBtn.TabIndex = 18;
            this.showLogBtn.Text = "Show &Log";
            this.showLogBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showLogBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.showLogBtn.UseVisualStyleBackColor = true;
            this.showLogBtn.Click += new System.EventHandler(this.ShowLogBtn_Click);
            // 
            // splitLeftRight
            // 
            this.splitLeftRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitLeftRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitLeftRight.BackgroundImage")));
            this.splitLeftRight.Location = new System.Drawing.Point(10, 65);
            this.splitLeftRight.Name = "splitLeftRight";
            // 
            // splitLeftRight.Panel1
            // 
            this.splitLeftRight.Panel1.Controls.Add(this.tvFolders);
            // 
            // splitLeftRight.Panel2
            // 
            this.splitLeftRight.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitLeftRight.Panel2.Controls.Add(this.label12);
            this.splitLeftRight.Panel2.Controls.Add(this.iconList);
            this.splitLeftRight.Size = new System.Drawing.Size(560, 359);
            this.splitLeftRight.SplitterDistance = 400;
            this.splitLeftRight.SplitterWidth = 6;
            this.splitLeftRight.TabIndex = 17;
            // 
            // tvFolders
            // 
            this.tvFolders.ContextMenuStrip = this.cmStrip;
            this.tvFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFolders.ImageKey = "folder";
            this.tvFolders.ImageList = this.ilFolderIcons;
            this.tvFolders.Location = new System.Drawing.Point(0, 0);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.SelectedImageKey = "folder";
            this.tvFolders.Size = new System.Drawing.Size(400, 359);
            this.tvFolders.TabIndex = 3;
            this.tvFolders.DoubleClick += new System.EventHandler(this.FolderTree_DoubleClick);
            this.tvFolders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FolderTree_MouseClick);
            // 
            // cmStrip
            // 
            this.cmStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderMenu,
            this.deleteFoldersOnBranchMenu,
            this.toolStripSeparator1,
            this.protectFolderFromBeingDeletedMenu,
            this.unprotectFolderMenu,
            this.protectFolderMenu,
            this.toolStripSeparator2,
            this.makeFolderWriteableMenu,
            this.makeFoldersWriteableMenu});
            this.cmStrip.Name = "cmStrip";
            this.cmStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmStrip.ShowImageMargin = false;
            this.cmStrip.Size = new System.Drawing.Size(188, 170);
            // 
            // openFolderMenu
            // 
            this.openFolderMenu.Name = "openFolderMenu";
            this.openFolderMenu.Size = new System.Drawing.Size(187, 22);
            this.openFolderMenu.Text = "&Open folder";
            this.openFolderMenu.Click += new System.EventHandler(this.OpenFolderMenu_Click);
            // 
            // deleteFoldersOnBranchMenu
            // 
            this.deleteFoldersOnBranchMenu.Name = "deleteFoldersOnBranchMenu";
            this.deleteFoldersOnBranchMenu.Size = new System.Drawing.Size(187, 22);
            this.deleteFoldersOnBranchMenu.Text = "Delete folders on branch";
            this.deleteFoldersOnBranchMenu.Click += new System.EventHandler(this.DeleteFoldersOnBranchMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // protectFolderFromBeingDeletedMenu
            // 
            this.protectFolderFromBeingDeletedMenu.Name = "protectFolderFromBeingDeletedMenu";
            this.protectFolderFromBeingDeletedMenu.Size = new System.Drawing.Size(187, 22);
            this.protectFolderFromBeingDeletedMenu.Text = "Protect folder (once)";
            this.protectFolderFromBeingDeletedMenu.Click += new System.EventHandler(this.ProtectFolderFromBeingDeletedMenu_Click);
            // 
            // unprotectFolderMenu
            // 
            this.unprotectFolderMenu.Name = "unprotectFolderMenu";
            this.unprotectFolderMenu.Size = new System.Drawing.Size(187, 22);
            this.unprotectFolderMenu.Text = "Unprotect folder";
            this.unprotectFolderMenu.Click += new System.EventHandler(this.UnProtectFolderMenu_Click);
            // 
            // protectFolderMenu
            // 
            this.protectFolderMenu.Name = "protectFolderMenu";
            this.protectFolderMenu.Size = new System.Drawing.Size(187, 22);
            this.protectFolderMenu.Text = "Protect folder (every time)";
            this.protectFolderMenu.Click += new System.EventHandler(this.ProtectFolderMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // makeFolderWriteableMenu
            // 
            this.makeFolderWriteableMenu.Name = "makeFolderWriteableMenu";
            this.makeFolderWriteableMenu.Size = new System.Drawing.Size(187, 22);
            this.makeFolderWriteableMenu.Text = "Make folder writeable";
            this.makeFolderWriteableMenu.Click += new System.EventHandler(this.MakeFolderWriteableMenu_Click);
            // 
            // makeFoldersWriteableMenu
            // 
            this.makeFoldersWriteableMenu.Name = "makeFoldersWriteableMenu";
            this.makeFoldersWriteableMenu.Size = new System.Drawing.Size(187, 22);
            this.makeFoldersWriteableMenu.Text = "Make folders writeable";
            this.makeFoldersWriteableMenu.Click += new System.EventHandler(this.MakeFoldersWriteableMenu_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Icon Legend:";
            // 
            // iconList
            // 
            this.iconList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.iconList.BackgroundImage = global::nsREDT.Properties.Resources.redt_bg;
            this.iconList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colType,
            this.colCount});
            this.iconList.FullRowSelect = true;
            this.iconList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.iconList.Location = new System.Drawing.Point(0, 29);
            this.iconList.Margin = new System.Windows.Forms.Padding(0);
            this.iconList.Name = "iconList";
            this.iconList.Scrollable = false;
            this.iconList.Size = new System.Drawing.Size(151, 330);
            this.iconList.TabIndex = 1;
            this.iconList.UseCompatibleStateImageBehavior = false;
            this.iconList.View = System.Windows.Forms.View.Details;
            this.iconList.SelectedIndexChanged += new System.EventHandler(this.iconList_SelectedIndexChanged);
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 100;
            // 
            // colCount
            // 
            this.colCount.Text = "Count";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelBtn.Enabled = false;
            this.cancelBtn.ImageKey = "cancel";
            this.cancelBtn.ImageList = this.ilFolderIcons;
            this.cancelBtn.Location = new System.Drawing.Point(232, 457);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(98, 34);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "&Cancel";
            this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelScanBtn_Click);
            // 
            // scanBtn
            // 
            this.scanBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scanBtn.ImageKey = "search";
            this.scanBtn.ImageList = this.ilFolderIcons;
            this.scanBtn.Location = new System.Drawing.Point(10, 457);
            this.scanBtn.Name = "scanBtn";
            this.scanBtn.Size = new System.Drawing.Size(98, 35);
            this.scanBtn.TabIndex = 4;
            this.scanBtn.Text = "&Scan folders";
            this.scanBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scanBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.scanBtn.UseVisualStyleBackColor = true;
            this.scanBtn.Click += new System.EventHandler(this.ScanBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteBtn.Enabled = false;
            this.deleteBtn.ImageKey = "trash";
            this.deleteBtn.ImageList = this.ilFolderIcons;
            this.deleteBtn.Location = new System.Drawing.Point(114, 457);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(112, 35);
            this.deleteBtn.TabIndex = 5;
            this.deleteBtn.Text = "&Delete folders";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // chooseFolderLb
            // 
            this.chooseFolderLb.AutoSize = true;
            this.chooseFolderLb.BackColor = System.Drawing.Color.Transparent;
            this.chooseFolderLb.Location = new System.Drawing.Point(7, 13);
            this.chooseFolderLb.Name = "chooseFolderLb";
            this.chooseFolderLb.Size = new System.Drawing.Size(118, 13);
            this.chooseFolderLb.TabIndex = 15;
            this.chooseFolderLb.Text = "Please choose a folder:";
            // 
            // statusLbl
            // 
            this.statusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(207, 430);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(140, 13);
            this.statusLbl.TabIndex = 13;
            this.statusLbl.Text = "Press Scan to start search...";
            // 
            // statusBar
            // 
            this.statusBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusBar.Location = new System.Drawing.Point(10, 430);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(153, 13);
            this.statusBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.statusBar.TabIndex = 12;
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.ImageKey = "exit";
            this.exitBtn.ImageList = this.ilFolderIcons;
            this.exitBtn.Location = new System.Drawing.Point(510, 457);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(68, 34);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.Text = "&Exit";
            this.exitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // folderTx
            // 
            this.folderTx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.folderTx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.folderTx.Location = new System.Drawing.Point(9, 30);
            this.folderTx.Name = "folderTx";
            this.folderTx.Size = new System.Drawing.Size(486, 20);
            this.folderTx.TabIndex = 1;
            this.folderTx.Text = "C:\\";
            this.folderTx.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbFolder_PreviewKeyDown);
            // 
            // chooseFolderBtn
            // 
            this.chooseFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseFolderBtn.Location = new System.Drawing.Point(499, 30);
            this.chooseFolderBtn.Name = "chooseFolderBtn";
            this.chooseFolderBtn.Size = new System.Drawing.Size(63, 20);
            this.chooseFolderBtn.TabIndex = 2;
            this.chooseFolderBtn.Text = "Browse...";
            this.chooseFolderBtn.UseVisualStyleBackColor = true;
            this.chooseFolderBtn.Click += new System.EventHandler(this.ChooseFolderBtn_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.settingTable);
            this.tabSettings.ImageKey = "preferences";
            this.tabSettings.Location = new System.Drawing.Point(4, 23);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(584, 514);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.ToolTipText = "Application settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // settingTable
            // 
            this.settingTable.ColumnCount = 1;
            this.settingTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingTable.Controls.Add(this.grpOptions, 0, 0);
            this.settingTable.Controls.Add(this.grpAdvanced, 0, 2);
            this.settingTable.Controls.Add(this.innerTable, 0, 1);
            this.settingTable.Controls.Add(this.grpLog, 0, 3);
            this.settingTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingTable.Location = new System.Drawing.Point(3, 3);
            this.settingTable.Name = "settingTable";
            this.settingTable.RowCount = 4;
            this.settingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.settingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.settingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.settingTable.Size = new System.Drawing.Size(578, 508);
            this.settingTable.TabIndex = 23;
            // 
            // grpOptions
            // 
            this.grpOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.grpOptions.Controls.Add(this.cbDeleteReadonly);
            this.grpOptions.Controls.Add(this.cbIntegrateIntoWindowsExplorer);
            this.grpOptions.Controls.Add(this.cbIgnoreHiddenFolders);
            this.grpOptions.Controls.Add(this.cbKeepSystemFolders);
            this.grpOptions.Controls.Add(this.cbIgnore0kbFiles);
            this.grpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOptions.Location = new System.Drawing.Point(3, 3);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(572, 114);
            this.grpOptions.TabIndex = 19;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "General options";
            // 
            // cbDeleteReadonly
            // 
            this.cbDeleteReadonly.AutoSize = true;
            this.cbDeleteReadonly.Location = new System.Drawing.Point(13, 85);
            this.cbDeleteReadonly.Name = "cbDeleteReadonly";
            this.cbDeleteReadonly.Size = new System.Drawing.Size(105, 17);
            this.cbDeleteReadonly.TabIndex = 5;
            this.cbDeleteReadonly.Text = "Delete Readonly";
            this.cbDeleteReadonly.UseVisualStyleBackColor = true;
            this.cbDeleteReadonly.CheckedChanged += new System.EventHandler(this.cbDeleteReadonly_CheckedChanged);
            // 
            // cbIgnoreHiddenFolders
            // 
            this.cbIgnoreHiddenFolders.AutoSize = true;
            this.cbIgnoreHiddenFolders.Location = new System.Drawing.Point(239, 55);
            this.cbIgnoreHiddenFolders.Name = "cbIgnoreHiddenFolders";
            this.cbIgnoreHiddenFolders.Size = new System.Drawing.Size(146, 17);
            this.cbIgnoreHiddenFolders.TabIndex = 4;
            this.cbIgnoreHiddenFolders.Text = "Don\'t scan hidden folders";
            this.cbIgnoreHiddenFolders.UseVisualStyleBackColor = true;
            this.cbIgnoreHiddenFolders.CheckedChanged += new System.EventHandler(this.cbIgnoreHiddenFolders_CheckedChanged);
            // 
            // cbKeepSystemFolders
            // 
            this.cbKeepSystemFolders.AutoSize = true;
            this.cbKeepSystemFolders.Checked = true;
            this.cbKeepSystemFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeepSystemFolders.Location = new System.Drawing.Point(239, 26);
            this.cbKeepSystemFolders.Name = "cbKeepSystemFolders";
            this.cbKeepSystemFolders.Size = new System.Drawing.Size(196, 17);
            this.cbKeepSystemFolders.TabIndex = 2;
            this.cbKeepSystemFolders.Text = "Keep system folders (recommended)";
            this.cbKeepSystemFolders.UseVisualStyleBackColor = true;
            this.cbKeepSystemFolders.CheckedChanged += new System.EventHandler(this.cbKeepSystemFolders_CheckedChanged);
            // 
            // cbIgnore0kbFiles
            // 
            this.cbIgnore0kbFiles.AutoSize = true;
            this.cbIgnore0kbFiles.Checked = true;
            this.cbIgnore0kbFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIgnore0kbFiles.Location = new System.Drawing.Point(13, 49);
            this.cbIgnore0kbFiles.Name = "cbIgnore0kbFiles";
            this.cbIgnore0kbFiles.Size = new System.Drawing.Size(158, 30);
            this.cbIgnore0kbFiles.TabIndex = 3;
            this.cbIgnore0kbFiles.Text = "Folders with files that are all \r\n0kb count as empty";
            this.cbIgnore0kbFiles.UseVisualStyleBackColor = true;
            this.cbIgnore0kbFiles.CheckedChanged += new System.EventHandler(this.cbIgnore0kbFiles_CheckedChanged);
            // 
            // grpAdvanced
            // 
            this.grpAdvanced.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.grpAdvanced.Controls.Add(this.maxValueTbl);
            this.grpAdvanced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAdvanced.Location = new System.Drawing.Point(3, 386);
            this.grpAdvanced.Name = "grpAdvanced";
            this.grpAdvanced.Size = new System.Drawing.Size(572, 69);
            this.grpAdvanced.TabIndex = 21;
            this.grpAdvanced.TabStop = false;
            this.grpAdvanced.Text = "Advanced";
            // 
            // maxValueTbl
            // 
            this.maxValueTbl.ColumnCount = 2;
            this.maxValueTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.maxValueTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.maxValueTbl.Controls.Add(this.label3, 0, 0);
            this.maxValueTbl.Controls.Add(this.nuMaxDepth, 0, 1);
            this.maxValueTbl.Controls.Add(this.nuMaxFolder, 1, 1);
            this.maxValueTbl.Controls.Add(this.label7, 1, 0);
            this.maxValueTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxValueTbl.Location = new System.Drawing.Point(3, 16);
            this.maxValueTbl.Name = "maxValueTbl";
            this.maxValueTbl.RowCount = 2;
            this.maxValueTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.maxValueTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.maxValueTbl.Size = new System.Drawing.Size(566, 50);
            this.maxValueTbl.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Max depth:";
            // 
            // nuMaxDepth
            // 
            this.nuMaxDepth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuMaxDepth.Location = new System.Drawing.Point(3, 23);
            this.nuMaxDepth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nuMaxDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuMaxDepth.Name = "nuMaxDepth";
            this.nuMaxDepth.Size = new System.Drawing.Size(277, 20);
            this.nuMaxDepth.TabIndex = 7;
            this.nuMaxDepth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nuMaxDepth.ValueChanged += new System.EventHandler(this.nuMaxDepth_ValueChanged);
            // 
            // nuMaxFolder
            // 
            this.nuMaxFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuMaxFolder.Location = new System.Drawing.Point(286, 23);
            this.nuMaxFolder.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.nuMaxFolder.Name = "nuMaxFolder";
            this.nuMaxFolder.Size = new System.Drawing.Size(277, 20);
            this.nuMaxFolder.TabIndex = 8;
            this.nuMaxFolder.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nuMaxFolder.ValueChanged += new System.EventHandler(this.nuFolder_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(286, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Max folders:";
            // 
            // innerTable
            // 
            this.innerTable.ColumnCount = 2;
            this.innerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.innerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.innerTable.Controls.Add(this.grpIgnoreFiles, 0, 0);
            this.innerTable.Controls.Add(this.grpFolders, 1, 0);
            this.innerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerTable.Location = new System.Drawing.Point(3, 123);
            this.innerTable.Name = "innerTable";
            this.innerTable.RowCount = 1;
            this.innerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.innerTable.Size = new System.Drawing.Size(572, 257);
            this.innerTable.TabIndex = 20;
            // 
            // grpIgnoreFiles
            // 
            this.grpIgnoreFiles.Controls.Add(this.label9);
            this.grpIgnoreFiles.Controls.Add(this.ignoreFilesTx);
            this.grpIgnoreFiles.Controls.Add(this.label2);
            this.grpIgnoreFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpIgnoreFiles.Location = new System.Drawing.Point(3, 3);
            this.grpIgnoreFiles.Name = "grpIgnoreFiles";
            this.grpIgnoreFiles.Size = new System.Drawing.Size(280, 251);
            this.grpIgnoreFiles.TabIndex = 20;
            this.grpIgnoreFiles.TabStop = false;
            this.grpIgnoreFiles.Text = "Ignore these files";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(6, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "(Put each pattern in a new line)";
            // 
            // ignoreFilesTx
            // 
            this.ignoreFilesTx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ignoreFilesTx.Location = new System.Drawing.Point(9, 49);
            this.ignoreFilesTx.Multiline = true;
            this.ignoreFilesTx.Name = "ignoreFilesTx";
            this.ignoreFilesTx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ignoreFilesTx.Size = new System.Drawing.Size(265, 183);
            this.ignoreFilesTx.TabIndex = 5;
            this.ignoreFilesTx.WordWrap = false;
            this.ignoreFilesTx.TextChanged += new System.EventHandler(this.tbIgnoreFiles_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mark folders as empty if they only contain \r\nfiles that matches these patterns:";
            // 
            // grpFolders
            // 
            this.grpFolders.Controls.Add(this.label11);
            this.grpFolders.Controls.Add(this.ignoreFoldersTx);
            this.grpFolders.Controls.Add(this.label10);
            this.grpFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFolders.Location = new System.Drawing.Point(289, 3);
            this.grpFolders.Name = "grpFolders";
            this.grpFolders.Size = new System.Drawing.Size(280, 251);
            this.grpFolders.TabIndex = 22;
            this.grpFolders.TabStop = false;
            this.grpFolders.Text = "Skip these folders";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label11.Location = new System.Drawing.Point(6, 235);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "(Put each pattern in a new line)";
            // 
            // ignoreFoldersTx
            // 
            this.ignoreFoldersTx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ignoreFoldersTx.Location = new System.Drawing.Point(9, 49);
            this.ignoreFoldersTx.Multiline = true;
            this.ignoreFoldersTx.Name = "ignoreFoldersTx";
            this.ignoreFoldersTx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ignoreFoldersTx.Size = new System.Drawing.Size(265, 183);
            this.ignoreFoldersTx.TabIndex = 6;
            this.ignoreFoldersTx.WordWrap = false;
            this.ignoreFoldersTx.TextChanged += new System.EventHandler(this.tbIgnoreFolders_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Ignore these folders:";
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.showLogBtn2);
            this.grpLog.Controls.Add(this.logBtn);
            this.grpLog.Controls.Add(this.logTb);
            this.grpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLog.Location = new System.Drawing.Point(3, 461);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(572, 44);
            this.grpLog.TabIndex = 22;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Log File";
            // 
            // showLogBtn2
            // 
            this.showLogBtn2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showLogBtn2.Location = new System.Drawing.Point(488, 18);
            this.showLogBtn2.Name = "showLogBtn2";
            this.showLogBtn2.Size = new System.Drawing.Size(75, 20);
            this.showLogBtn2.TabIndex = 2;
            this.showLogBtn2.Text = "Show Log";
            this.showLogBtn2.UseVisualStyleBackColor = true;
            this.showLogBtn2.Click += new System.EventHandler(this.showLogBtn2_Click);
            // 
            // logBtn
            // 
            this.logBtn.Location = new System.Drawing.Point(3, 17);
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(75, 20);
            this.logBtn.TabIndex = 1;
            this.logBtn.Text = "Browse";
            this.logBtn.UseVisualStyleBackColor = true;
            this.logBtn.Click += new System.EventHandler(this.logBtn_Click);
            // 
            // logTb
            // 
            this.logTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.logTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.logTb.Location = new System.Drawing.Point(87, 18);
            this.logTb.Name = "logTb";
            this.logTb.Size = new System.Drawing.Size(395, 20);
            this.logTb.TabIndex = 0;
            this.logTb.TextChanged += new System.EventHandler(this.LogTb_TextChanged);
            this.logTb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.LogTb_PreviewKeyDown);
            // 
            // tabEmpDir
            // 
            this.tabEmpDir.BackColor = System.Drawing.Color.Transparent;
            this.tabEmpDir.Controls.Add(this.filterGrp);
            this.tabEmpDir.Controls.Add(this.dirViewCountTxt);
            this.tabEmpDir.Controls.Add(this.dirViewLbl);
            this.tabEmpDir.Controls.Add(this.dirViewIgnoreBtn);
            this.tabEmpDir.Controls.Add(this.dirViewDelBtn);
            this.tabEmpDir.Controls.Add(this.dirView);
            this.tabEmpDir.ImageKey = "folder";
            this.tabEmpDir.Location = new System.Drawing.Point(4, 23);
            this.tabEmpDir.Name = "tabEmpDir";
            this.tabEmpDir.Size = new System.Drawing.Size(584, 514);
            this.tabEmpDir.TabIndex = 3;
            this.tabEmpDir.Text = "EmptyDirs";
            this.tabEmpDir.UseVisualStyleBackColor = true;
            // 
            // filterGrp
            // 
            this.filterGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterGrp.Controls.Add(this.filterTx);
            this.filterGrp.Controls.Add(this.applyFltBtn);
            this.filterGrp.Location = new System.Drawing.Point(307, 5);
            this.filterGrp.Name = "filterGrp";
            this.filterGrp.Size = new System.Drawing.Size(260, 44);
            this.filterGrp.TabIndex = 5;
            this.filterGrp.TabStop = false;
            this.filterGrp.Text = "Filter";
            // 
            // filterTx
            // 
            this.filterTx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterTx.Location = new System.Drawing.Point(73, 17);
            this.filterTx.Name = "filterTx";
            this.filterTx.Size = new System.Drawing.Size(181, 20);
            this.filterTx.TabIndex = 1;
            this.filterTx.Text = ".*";
            // 
            // applyFltBtn
            // 
            this.applyFltBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.applyFltBtn.Location = new System.Drawing.Point(4, 17);
            this.applyFltBtn.Margin = new System.Windows.Forms.Padding(1);
            this.applyFltBtn.Name = "applyFltBtn";
            this.applyFltBtn.Size = new System.Drawing.Size(55, 18);
            this.applyFltBtn.TabIndex = 0;
            this.applyFltBtn.Text = "Apply";
            this.applyFltBtn.UseVisualStyleBackColor = true;
            this.applyFltBtn.Click += new System.EventHandler(this.applyFltBtn_Click);
            // 
            // dirViewCountTxt
            // 
            this.dirViewCountTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dirViewCountTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dirViewCountTxt.Location = new System.Drawing.Point(69, 468);
            this.dirViewCountTxt.Name = "dirViewCountTxt";
            this.dirViewCountTxt.ReadOnly = true;
            this.dirViewCountTxt.Size = new System.Drawing.Size(100, 20);
            this.dirViewCountTxt.TabIndex = 4;
            // 
            // dirViewLbl
            // 
            this.dirViewLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dirViewLbl.AutoSize = true;
            this.dirViewLbl.Location = new System.Drawing.Point(14, 471);
            this.dirViewLbl.Name = "dirViewLbl";
            this.dirViewLbl.Size = new System.Drawing.Size(38, 13);
            this.dirViewLbl.TabIndex = 3;
            this.dirViewLbl.Text = "Count:";
            // 
            // dirViewIgnoreBtn
            // 
            this.dirViewIgnoreBtn.Location = new System.Drawing.Point(162, 20);
            this.dirViewIgnoreBtn.Name = "dirViewIgnoreBtn";
            this.dirViewIgnoreBtn.Size = new System.Drawing.Size(139, 23);
            this.dirViewIgnoreBtn.TabIndex = 2;
            this.dirViewIgnoreBtn.Text = "Ignore Selected Dirs";
            this.dirViewIgnoreBtn.UseVisualStyleBackColor = true;
            this.dirViewIgnoreBtn.Click += new System.EventHandler(this.dirViewIgnBtn_Click);
            // 
            // dirViewDelBtn
            // 
            this.dirViewDelBtn.Location = new System.Drawing.Point(17, 19);
            this.dirViewDelBtn.Name = "dirViewDelBtn";
            this.dirViewDelBtn.Size = new System.Drawing.Size(139, 23);
            this.dirViewDelBtn.TabIndex = 1;
            this.dirViewDelBtn.Text = "Delete Selected Dirs";
            this.dirViewDelBtn.UseVisualStyleBackColor = true;
            this.dirViewDelBtn.Click += new System.EventHandler(this.dirViewDelBtn_Click);
            // 
            // dirView
            // 
            this.dirView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dirView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_path,
            this.col_dir,
            this.col_mdate,
            this.col_cdate,
            this.col_cat});
            this.dirView.FullRowSelect = true;
            this.dirView.GridLines = true;
            this.dirView.Location = new System.Drawing.Point(17, 55);
            this.dirView.Name = "dirView";
            this.dirView.Size = new System.Drawing.Size(539, 413);
            this.dirView.TabIndex = 0;
            this.dirView.UseCompatibleStateImageBehavior = false;
            this.dirView.View = System.Windows.Forms.View.Details;
            this.dirView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnClick);
            this.dirView.SelectedIndexChanged += new System.EventHandler(this.dirView_SelectedIndexChanged);
            // 
            // col_path
            // 
            this.col_path.Text = "Path";
            this.col_path.Width = 300;
            // 
            // col_dir
            // 
            this.col_dir.Text = "Dir";
            // 
            // col_mdate
            // 
            this.col_mdate.Text = "Mod Date";
            this.col_mdate.Width = 120;
            // 
            // col_cdate
            // 
            this.col_cdate.Text = "Create Date";
            this.col_cdate.Width = 120;
            // 
            // col_cat
            // 
            this.col_cat.Text = "Category";
            // 
            // tabAbout
            // 
            this.tabAbout.BackColor = System.Drawing.Color.Gray;
            this.tabAbout.BackgroundImage = global::nsREDT.Properties.Resources.redt_bg;
            this.tabAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabAbout.Controls.Add(this.website1Lb);
            this.tabAbout.Controls.Add(this.dlangLink);
            this.tabAbout.Controls.Add(this.dlangLb);
            this.tabAbout.Controls.Add(this.horzLine);
            this.tabAbout.Controls.Add(this.hintsLb);
            this.tabAbout.Controls.Add(this.hints1Lb);
            this.tabAbout.Controls.Add(this.label14);
            this.tabAbout.Controls.Add(this.label13);
            this.tabAbout.Controls.Add(this.logoBox);
            this.tabAbout.Controls.Add(this.label5);
            this.tabAbout.Controls.Add(this.label4);
            this.tabAbout.Controls.Add(this.jJohnLink);
            this.tabAbout.Controls.Add(this.appTitleLb);
            this.tabAbout.ImageKey = "help";
            this.tabAbout.Location = new System.Drawing.Point(4, 23);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(584, 514);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "About";
            this.tabAbout.ToolTipText = "Shows the help and about screen";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // website1Lb
            // 
            this.website1Lb.AutoSize = true;
            this.website1Lb.BackColor = System.Drawing.Color.Transparent;
            this.website1Lb.Location = new System.Drawing.Point(120, 69);
            this.website1Lb.Name = "website1Lb";
            this.website1Lb.Size = new System.Drawing.Size(49, 13);
            this.website1Lb.TabIndex = 27;
            this.website1Lb.Text = "Website:";
            // 
            // dlangLink
            // 
            this.dlangLink.AutoSize = true;
            this.dlangLink.BackColor = System.Drawing.Color.Transparent;
            this.dlangLink.Location = new System.Drawing.Point(120, 82);
            this.dlangLink.Name = "dlangLink";
            this.dlangLink.Size = new System.Drawing.Size(243, 13);
            this.dlangLink.TabIndex = 26;
            this.dlangLink.TabStop = true;
            this.dlangLink.Text = "http://home.comcast.net/~lang.dennis/index.html";
            this.dlangLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DennisLang_LinkClicked);
            // 
            // dlangLb
            // 
            this.dlangLb.AutoSize = true;
            this.dlangLb.BackColor = System.Drawing.Color.Transparent;
            this.dlangLb.Location = new System.Drawing.Point(120, 43);
            this.dlangLb.Name = "dlangLb";
            this.dlangLb.Size = new System.Drawing.Size(94, 13);
            this.dlangLb.TabIndex = 20;
            this.dlangLb.Text = "Dennis Lang 2012";
            // 
            // horzLine
            // 
            this.horzLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.horzLine.BackColor = System.Drawing.Color.White;
            this.horzLine.Location = new System.Drawing.Point(18, 137);
            this.horzLine.Name = "horzLine";
            this.horzLine.Size = new System.Drawing.Size(530, 2);
            this.horzLine.TabIndex = 19;
            // 
            // hintsLb
            // 
            this.hintsLb.AutoSize = true;
            this.hintsLb.BackColor = System.Drawing.Color.Transparent;
            this.hintsLb.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintsLb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hintsLb.Location = new System.Drawing.Point(15, 275);
            this.hintsLb.Name = "hintsLb";
            this.hintsLb.Size = new System.Drawing.Size(38, 14);
            this.hintsLb.TabIndex = 12;
            this.hintsLb.Text = "Hints:";
            // 
            // hints1Lb
            // 
            this.hints1Lb.AutoSize = true;
            this.hints1Lb.BackColor = System.Drawing.Color.Transparent;
            this.hints1Lb.Location = new System.Drawing.Point(41, 304);
            this.hints1Lb.Name = "hints1Lb";
            this.hints1Lb.Size = new System.Drawing.Size(206, 13);
            this.hints1Lb.TabIndex = 11;
            this.hints1Lb.Text = "Right click on a folder to get more options.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(41, 207);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(176, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "RED is Open Source (GPL License)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(15, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(373, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = "Credits (RED/t is 90% code provided by Jonas John\'s RED):";
            // 
            // logoBox
            // 
            this.logoBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoBox.BackgroundImage")));
            this.logoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoBox.InitialImage = null;
            this.logoBox.Location = new System.Drawing.Point(18, 19);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(96, 96);
            this.logoBox.TabIndex = 6;
            this.logoBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "Copyright © 2006 - 2007 Jonas John";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(41, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Website:";
            // 
            // jJohnLink
            // 
            this.jJohnLink.AutoSize = true;
            this.jJohnLink.BackColor = System.Drawing.Color.Transparent;
            this.jJohnLink.Location = new System.Drawing.Point(96, 229);
            this.jJohnLink.Name = "jJohnLink";
            this.jJohnLink.Size = new System.Drawing.Size(94, 13);
            this.jJohnLink.TabIndex = 19;
            this.jJohnLink.TabStop = true;
            this.jJohnLink.Text = "www.jonasjohn.de";
            this.jJohnLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.JonasJohn_LinkClicked);
            // 
            // appTitleLb
            // 
            this.appTitleLb.AutoSize = true;
            this.appTitleLb.BackColor = System.Drawing.Color.Transparent;
            this.appTitleLb.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appTitleLb.ForeColor = System.Drawing.Color.Black;
            this.appTitleLb.Location = new System.Drawing.Point(118, 18);
            this.appTitleLb.Name = "appTitleLb";
            this.appTitleLb.Size = new System.Drawing.Size(243, 16);
            this.appTitleLb.TabIndex = 0;
            this.appTitleLb.Text = "Remove Empty Directories w/ Trash v";
            // 
            // setLogFileDlg
            // 
            this.setLogFileDlg.Filter = "Log|*.log|Text|*.txt|All|*.*";
            this.setLogFileDlg.Title = "Set Log File";
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(610, 558);
            this.Controls.Add(this.mainTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RED/t v3.0 - Remove Empty Directories with Trash";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResizeEnd += new System.EventHandler(this.Main_ResziseEnd);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.mainTab.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.splitLeftRight.Panel1.ResumeLayout(false);
            this.splitLeftRight.Panel2.ResumeLayout(false);
            this.splitLeftRight.Panel2.PerformLayout();
            this.splitLeftRight.ResumeLayout(false);
            this.cmStrip.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.settingTable.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.grpAdvanced.ResumeLayout(false);
            this.maxValueTbl.ResumeLayout(false);
            this.maxValueTbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuMaxDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuMaxFolder)).EndInit();
            this.innerTable.ResumeLayout(false);
            this.grpIgnoreFiles.ResumeLayout(false);
            this.grpIgnoreFiles.PerformLayout();
            this.grpFolders.ResumeLayout(false);
            this.grpFolders.PerformLayout();
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            this.tabEmpDir.ResumeLayout(false);
            this.tabEmpDir.PerformLayout();
            this.filterGrp.ResumeLayout(false);
            this.filterGrp.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.CheckBox cbIntegrateIntoWindowsExplorer;
		private System.Windows.Forms.TabControl mainTab;
		private System.Windows.Forms.TabPage tabSettings;
		private System.Windows.Forms.TabPage tabAbout;
		private System.Windows.Forms.Label appTitleLb;
		private System.Windows.Forms.CheckBox cbIgnore0kbFiles;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ignoreFilesTx;
		private System.Windows.Forms.CheckBox cbKeepSystemFolders;
		private System.Windows.Forms.CheckBox cbIgnoreHiddenFolders;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage tabSearch;
		private System.Windows.Forms.Label statusLbl;
		private System.Windows.Forms.ProgressBar statusBar;
		private System.Windows.Forms.TreeView tvFolders;
		private System.Windows.Forms.Button exitBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.TextBox folderTx;
        private System.Windows.Forms.Button chooseFolderBtn;
		private System.Windows.Forms.Button scanBtn;
		private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.LinkLabel jJohnLink;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label chooseFolderLb;
		private System.Windows.Forms.NumericUpDown nuMaxDepth;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nuMaxFolder;
        private System.Windows.Forms.GroupBox grpAdvanced;
        private System.Windows.Forms.GroupBox grpIgnoreFiles;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpFolders;
        private System.Windows.Forms.TextBox ignoreFoldersTx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ImageList ilFolderIcons;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label hints1Lb;
        private System.Windows.Forms.Label hintsLb;
        private System.Windows.Forms.Panel horzLine;
        private System.Windows.Forms.Label dlangLb;
        private System.Windows.Forms.ContextMenuStrip cmStrip;
        private System.Windows.Forms.ToolStripMenuItem openFolderMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem protectFolderFromBeingDeletedMenu;
        private System.Windows.Forms.ToolStripMenuItem unprotectFolderMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem protectFolderMenu;
        private System.Windows.Forms.SplitContainer splitLeftRight;
        private System.Windows.Forms.ListView iconList;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colCount;
        private System.Windows.Forms.LinkLabel dlangLink;
        private System.Windows.Forms.ToolStripMenuItem deleteFoldersOnBranchMenu;
        private System.Windows.Forms.TabPage tabEmpDir;
        private System.Windows.Forms.ListView dirView;
        private System.Windows.Forms.ColumnHeader col_path;
        private System.Windows.Forms.ColumnHeader col_mdate;
        private System.Windows.Forms.ColumnHeader col_cdate;
        private System.Windows.Forms.Button dirViewIgnoreBtn;
        private System.Windows.Forms.Button dirViewDelBtn;
        private System.Windows.Forms.ColumnHeader col_dir;
        private System.Windows.Forms.TextBox dirViewCountTxt;
        private System.Windows.Forms.Label dirViewLbl;
        private System.Windows.Forms.ToolStripMenuItem makeFolderWriteableMenu;
        private System.Windows.Forms.ToolStripMenuItem makeFoldersWriteableMenu;
        private System.Windows.Forms.TableLayoutPanel settingTable;
        private System.Windows.Forms.TableLayoutPanel innerTable;
        private System.Windows.Forms.CheckBox cbDeleteReadonly;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.Button logBtn;
        private System.Windows.Forms.TextBox logTb;
        private System.Windows.Forms.Button showLogBtn;
        private System.Windows.Forms.Label website1Lb;
        private System.Windows.Forms.ColumnHeader col_cat;
        private System.Windows.Forms.TableLayoutPanel maxValueTbl;
        private System.Windows.Forms.GroupBox filterGrp;
        private System.Windows.Forms.Button applyFltBtn;
        private System.Windows.Forms.TextBox filterTx;
        private System.Windows.Forms.SaveFileDialog setLogFileDlg;
        private System.Windows.Forms.Button showLogBtn2;
        private System.Windows.Forms.Button pauseBtn;
    }
}

