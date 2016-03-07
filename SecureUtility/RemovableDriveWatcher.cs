﻿using System;
using System.IO;
using System.Threading;

namespace SecureUtility
{
    /// <summary>
    /// Repesents a watcher class for removable drives.
    /// </summary>
    public class RemovableDriveWatcher {
        /// <summary>
        /// Represents the watcher thread which watches for new drives.
        /// </summary>
        private Thread watcherThread;

        /// <summary>
        /// Continas all found logical drives of this system.
        /// </summary>
        private DriveInfo foundDrives;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemovableDriveWatcher"/> class.
        /// </summary>
        public RemovableDriveWatcher() {
            this.foundDrives = null;
            this.watcherThread = new Thread(new ThreadStart(ScanLogicalDrives));
            this.WaitBetweenScansDelay = 1000;
        }

        /// <summary>
        /// Is fired if a new drive has been detected.
        /// </summary>
        public event EventHandler<RemovableDriveWatcherEventArgs> NewDriveFound;

        /// <summary>
        /// Is fired if a drive has been removed.
        /// </summary>
        public event EventHandler<RemovableDriveWatcherEventArgs> DriveRemoved;

        /// <summary>
        /// Gets or sets the delay in ms between two scans.
        /// </summary>
        public int WaitBetweenScansDelay {
            get;
            set;
        }

        /// <summary>
        /// Starts the watcher.
        /// </summary>
        public void Start() {
            if (!this.watcherThread.IsAlive) {
                this.watcherThread.Start();
            }
        }

        /// <summary>
        /// Stops the watcher.
        /// </summary>
        public void Stop() {
            if (this.watcherThread.IsAlive) {
                this.watcherThread.Abort();
                this.watcherThread.Join();
            }
        }

        /// <summary>
        /// Scans for logical drives and fires an event every time a new
        /// drive has been found or a drive was removed.
        /// </summary>
        private void ScanLogicalDrives() {
            do {
                var drives = DriveInfo.GetDrives();

                if (foundDrives == null) {
                    // Check for new drives
                    foreach (DriveInfo drive in drives) {
                        if (drive.DriveType != DriveType.Removable) {
                            continue;
                        }

                        if (!drive.IsReady) {
                            continue;
                        }
                        string filename = drive.RootDirectory + "\\" + "Sec.ini";
                        if (!File.Exists(filename)) {
                            continue;
                        }
                        this.foundDrives = drive;

                        if (this.NewDriveFound != null) {
                            this.NewDriveFound(this, new RemovableDriveWatcherEventArgs(drives, drive));
                        }
                    }
                }

                // Check for removed drives
                //for (int i = this.foundDrives.Count - 1; i >= 0; i--) {
                //    DriveInfo drive = this.foundDrives[i];
                //    if (!drives.ContainsWithName(drive)) {
                //        if (this.DriveRemoved != null) {
                //            this.DriveRemoved(this, new RemovableDriveWatcherEventArgs(drives, drive));
                //        }

                //        this.foundDrives.RemoveWithName(drive);
                //    }
                //}

                if (foundDrives != null && !foundDrives.IsReady) {
                    if (DriveRemoved != null) DriveRemoved(this, new RemovableDriveWatcherEventArgs(drives, foundDrives));
                    foundDrives = null;
                }

                // Sleep
                Thread.Sleep(this.WaitBetweenScansDelay);
            }
            while (true);
        }
    }
}
