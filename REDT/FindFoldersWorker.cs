using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace nsREDT
{
    /// <summary>
    /// Background worker thread to Find Empty or Trash filled directories.
    /// </summary>
	public class FindFoldersWorker : BackgroundWorker
	{
        #region Class variables

        public List<DirectoryInfo> emptyDirectories = null;

        private string[] ignoreFiles = null;
        private string[] ignoreFolders = null;

        public bool Ignore0kbFiles { get; set; }
        public bool IgnoreHiddenFolders { get; set; }
        public bool KeepSystemFolders {   get; set; }

        public UInt16 MaxDepth { get; set; }

        public UInt32 FolderCount { get; set; }
        public UInt32 EmptyFolderCount { get; set; }
        public UInt32 IgnoredFolderCount { get; set; }

        #endregion
	
		public FindFoldersWorker()
        {			
			WorkerReportsProgress = true;
			WorkerSupportsCancellation = true;
		}

		public bool SetIgnoreFiles(string file_pattern) 
        {
			try
			{
                file_pattern = file_pattern.Replace("\r", "");
                file_pattern = file_pattern.Trim();
                this.ignoreFiles = file_pattern.Split('\n');
				return true;
			}
			catch 
            {
				return false;
			}
		}

        public bool SetIgnoreFolders(string file_pattern)
        {
            try
            {
                file_pattern = file_pattern.Replace("\r", "");
                file_pattern = file_pattern.Trim();

                if (file_pattern.Length != 0)
                    this.ignoreFolders = file_pattern.Split('\n');

                return true;
            }
            catch
            {
                return false;
            }
        }

        Stopwatch stopwatch = new Stopwatch();

		protected override void OnDoWork(DoWorkEventArgs e)
		{
			//Here we receive the necessary data 
			string dirPaths = (string)e.Argument;

            // Clean dir list
            this.emptyDirectories = new List<DirectoryInfo>();

            //Here we tell the manager that we start the job..
            this.ReportProgress(0, "Starting scan process...");
            stopwatch.Start();

            foreach (string dirPath in dirPaths.Split(';'))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                bool isEmpty = this.ScanFolders(dirInfo, 1);

                if (isEmpty)
                    this.emptyDirectories.Add(dirInfo);

                if (CancellationPending)
                {
                    e.Cancel = true;
                    e.Result = 0;
                    return;
                }
            }

			ReportProgress((int)this.FolderCount, "Finished!");

			//Here we pass the final result of the Job
			e.Result = 1;
		}

	
		private bool ScanFolders(DirectoryInfo startFolder, int dirDepth)
		{
            if (dirDepth > this.MaxDepth)
				return false;
	
			// Cancel process if the user hits stop
			if (CancellationPending)
				return false;

			// increase folder count
            this.FolderCount++;

			// update status progress bar .5 seconds
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                ReportProgress((int)FolderCount, "Checking folder: " + startFolder.Name);
                stopwatch.Reset();
                stopwatch.Start();
            }

			// Is the folder really empty?
			bool ContainsFiles = false;

            // Read files:
            FileInfo[] Files = null;

            // some folders trigger a exception:
            try
            {
                Files = startFolder.GetFiles();
            }
            catch 
            {
                Files = null;
            }

            if (Files == null)
            {
                // CF = true = folder does not get deleted:
                ContainsFiles = true; // secure way
            }
            else if (Files.Length == 0)
            {
                ContainsFiles = false;
            }
            else
            {
                // loop trough files and cancel if containsFiles == true
                for (int f = 0; (f < Files.Length && !ContainsFiles); f++)
                {
                    FileInfo file = Files[f];

                    int filesize = 0;
                    try
                    {
                        filesize = (int)file.Length;
                    }
                    catch {
                        // keep folder if there is a strange file that
                        // triggers a exception:
                        ContainsFiles = true;
                        continue;
                    }

                    bool matches_a_pattern = false;

                    for (int p = 0; (p < this.ignoreFiles.Length && !matches_a_pattern); p++)
                    {
                        string pattern = this.ignoreFiles[p];

                        if (this.Ignore0kbFiles && filesize == 0)
                            matches_a_pattern = true;
                        else if (pattern.ToLower() == file.Name.ToLower())
                            matches_a_pattern = true;
                        else if (pattern.Contains("*"))
                        {
                            pattern = Regex.Escape(pattern);
                            pattern = pattern.Replace("\\*", ".*");

                            Regex RgxPattern = new Regex("^" + pattern + "$");

                            if (RgxPattern.IsMatch(file.Name))
                                matches_a_pattern = true;
                        }
                        else if (pattern.StartsWith("/") && pattern.EndsWith("/"))
                        {
                            Regex RgxPattern = new Regex(pattern.Substring(1, pattern.Length - 2));

                            if (RgxPattern.IsMatch(file.Name))
                                matches_a_pattern = true;
                        }

                    }

                    // If only one file is good, then stop.
                    if (!matches_a_pattern)
                        ContainsFiles = true;

                }
            }

			// If the folder does not contain any files -> get subfolders:
            DirectoryInfo[] SubFolders = null;

            try
            {
                SubFolders = startFolder.GetDirectories();
            }
            catch 
            {
                // If we can not read the folder 
                // don't delete it:
                return false;
            }
			
			// The folder is empty, break here:
			if (!ContainsFiles && SubFolders.Length == 0)
				return true;

			bool AreTheSubFoldersEmpty = true;

			foreach (DirectoryInfo Folder in SubFolders)
			{
				// Hidden folder?
				bool ignoreFolder = (this.IgnoreHiddenFolders && 
                    ((Folder.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden));
				
				// System folder:
				ignoreFolder = (this.KeepSystemFolders && 
                    ((Folder.Attributes & FileAttributes.System) == FileAttributes.System)) ? true : ignoreFolder;

                // Ignore folder if the user wishes that
                if (this.ignoreFolders != null)
                {
                    foreach (string f in this.ignoreFolders)
                    {
                        if (Folder.FullName.ToLower().Contains(f.ToLower()))
                        {
                            ignoreFolder = true;
                            this.IgnoredFolderCount++;
                            break;
                        }
                    }
                }

				// Scan sub folder:
				bool isSubFolderEmpty = false;
				if (!ignoreFolder)
                    isSubFolderEmpty = this.ScanFolders(Folder, dirDepth + 1);

				// is empty?
                if (isSubFolderEmpty && !ignoreFolder)
                {
                    this.EmptyFolderCount++;

                    // Folder is empty, report that to the gui:
                    this.ReportProgress(-1, Folder);
                }
                

				// this folder is not empty:
				if (!isSubFolderEmpty || ignoreFolder)
					AreTheSubFoldersEmpty = false;
			}

			// All subdirectories are empty
			return (AreTheSubFoldersEmpty && !ContainsFiles);
		}
    }
}
