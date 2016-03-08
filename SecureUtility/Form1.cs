using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SecureUtility {
    public partial class Form1 : Form {
        public string TextBox1Text { get; set; }
        public string TextBox2Text { get; set; }

        static System.Media.SoundPlayer sPlay = new System.Media.SoundPlayer();
        public static DriveInfo foundDrives;

        private IniFiles iniFiles = new IniFiles(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "SecUti.ini");

        public string ServerPath { get; set; }
        public string BackUpTime { get; set; }
        NameValueCollection BackPath = new NameValueCollection();
        private System.Timers.Timer timersTimer = new System.Timers.Timer();
        private delegate void SetTextCallback(string text);

        public static List<ChangedFile> ChangedFiles = new List<ChangedFile>();
        public Form1() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Load += new EventHandler(Form1_Load);
            Closed += new EventHandler(Form1_Closed);
            RemovableDriveWatcher rdw = new RemovableDriveWatcher();
            rdw.NewDriveFound += NewDriveFound;
            rdw.DriveRemoved += DriveRemoved;
            rdw.Start();

            ServerPath = iniFiles.ReadString("Service", "ServerPath", "");
            BackUpTime = iniFiles.ReadString("Service", "BackUpTime", "");
            if (!string.IsNullOrEmpty(BackUpTime)) {
                label4.Text = BackUpTime + " 点";
            }
            if (!string.IsNullOrEmpty(ServerPath)) {
                label4.Text += " 路径: " + ServerPath;
            }
            iniFiles.ReadSectionValues("BackPath", BackPath);
            timersTimer.Enabled = true;
            timersTimer.Interval = 5000;
            timersTimer.Elapsed += new System.Timers.ElapsedEventHandler(timersTimer_Elapsed);
            //rdw.Stop();
        }
        private void Form1_Load(object sender, EventArgs e) {
            //注册热键Shift+S，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Shift, Keys.S);
            //注册热键Ctrl+B，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.Ctrl, Keys.B);
            //注册热键Alt+D，Id号为102。HotKey.KeyModifiers.Alt也可以直接使用数字1来表示。
            HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.Alt, Keys.D);
        }

        void timersTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            string curtime = System.DateTime.Now.Hour.ToString();
            notifyIcon1.ShowBalloonTip(3000, "", "自动备份完成，点击查看详情", ToolTipIcon.Info);
            notifyIcon1.BalloonTipClicked += BalloonTipClicked;
            if (!string.IsNullOrEmpty(ServerPath) && BackPath.Count > 0 && curtime == BackUpTime) {
                BackUpProcess();
            }
        }
        private void BalloonTipClicked(object sender, EventArgs e) {
            BackUpDetails backUpDetails = new BackUpDetails();
            DialogResult result = backUpDetails.ShowDialog(this);
            foreach (ChangedFile changedFile in ChangedFiles) {

            }
        }
        void BackUpProcess() {
            ChangedFiles.Clear();
            DirectoryInfo serFolder = new DirectoryInfo(ServerPath);
            if (serFolder.Exists) {
                foreach (string key in BackPath) {
                    var path = BackPath[key];
                    var p = new DirectoryInfo(path);
                    if (!string.IsNullOrEmpty(path) && p.Exists) {
                        CopyDirectory(p.FullName, serFolder.FullName);
                    }
                }
            }
            notifyIcon1.ShowBalloonTip(3000, "", "自动备份完成，点击查看详情", ToolTipIcon.Info);
            notifyIcon1.BalloonTipClicked += BalloonTipClicked;
            //SetTextCallback d = new SetTextCallback(SetText);
            //this.Invoke(d, new object[] { text });
        }

        public static void CopyDirectory(String sourcePath, String destinationPath) {
            DirectoryInfo destFolder = new DirectoryInfo(destinationPath);
            List<string> destSubFoders = destFolder.GetDirectories().Select(f => f.Name).ToList();
            DirectoryInfo sourceFolder = new DirectoryInfo(sourcePath);
            if (destSubFoders.Contains(sourceFolder.Name)) {
                var destPath = Path.Combine(destinationPath, sourceFolder.Name);
                foreach (FileSystemInfo fsi in sourceFolder.GetFileSystemInfos()) {
                    String destName = Path.Combine(destPath, fsi.Name);
                    if (fsi is System.IO.FileInfo) {
                        var dfsi = new FileInfo(Path.Combine(destPath, fsi.Name));
                        var file = fsi as FileInfo;
                        if (dfsi.Exists || dfsi.Length != file.Length) {
                            File.Copy(fsi.FullName, destName, true);
                            ChangedFiles.Add(new ChangedFile { FileName = file.Name, Status = "修改" });
                        }
                    }
                    else {
                        CopyDirectory(fsi.FullName, destName);
                    }
                }
            }
            else {
                var destPath = Path.Combine(destinationPath, sourceFolder.Name);
                Directory.CreateDirectory(destPath);
                foreach (FileSystemInfo fsi in sourceFolder.GetFileSystemInfos()) {
                    String destName = Path.Combine(destPath, fsi.Name);
                    if (fsi is System.IO.FileInfo) {
                        var file = fsi as FileInfo;
                        File.Copy(fsi.FullName, destName);
                        ChangedFiles.Add(new ChangedFile { FileName = file.Name, Status = "新增" });
                    }
                    else {
                        CopyDirectory(fsi.FullName, destName);
                    }
                }
            }
        }
        private void SetText(string text) {
            label1.Text += text;
        }

        private void Form1_Closed(object sender, EventArgs e) {
            //注销Id号为100的热键设定
            HotKey.UnregisterHotKey(Handle, 100);
            //注销Id号为101的热键设定
            HotKey.UnregisterHotKey(Handle, 101);
            //注销Id号为102的热键设定
            HotKey.UnregisterHotKey(Handle, 102);
            System.Environment.Exit(0);
        }
        private void Form1_SizeChanged(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Minimized) {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (WindowState == FormWindowState.Minimized) {
                Visible = true;
                WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
            }
        }

        private void ShowMainWindow_Click(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Minimized) {
                Visible = true;
                WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
            }
        }

        private void Exits_Click(object sender, EventArgs e) {
            sPlay.Stop();
            notifyIcon1.Visible = false;
            Close();
            Dispose();
            System.Environment.Exit(0);
        }

        protected override void WndProc(ref Message m) {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg) {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32()) {
                        case 100:    //按下的是Shift+S
                            //此处填写快捷键响应代码         
                            break;
                        case 101:    //按下的是Ctrl+B
                            //此处填写快捷键响应代码
                            break;
                        case 102:    //按下的是Alt+D
                            //此处填写快捷键响应代码
                            IeHelper.AutoComplete(foundDrives);
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Is executed when a new drive has been found.
        /// </summary>
        /// <param name="sender">The sender of this event.</param>
        /// <param name="e">The event arguments containing the changed drive.</param>
        private void NewDriveFound(object sender, RemovableDriveWatcherEventArgs e) {
            try {
                foundDrives = e.ChangedDrive;
                try {
                    sPlay.SoundLocation = System.AppDomain.CurrentDomain.BaseDirectory + "指纹识别成功.wav";
                    sPlay.Load();
                    sPlay.Play();
                    //Thread.Sleep(1000);
                    sPlay.SoundLocation = System.AppDomain.CurrentDomain.BaseDirectory + "杨先生您好，欢迎使用.wav";
                    sPlay.Load();
                    sPlay.Play();
                }
                catch (Exception) {
                }
                var ih = new IniFiles(foundDrives.RootDirectory + "\\" + "Sec.ini");
                NameValueCollection Values = new NameValueCollection();
                ih.ReadSectionValues("HiddenFolders", Values);
                foreach (string key in Values) {
                    try {
                        var path = Values[key];
                        if (path != "") {
                            listBox1.Items.Add(path);
                            //path += ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";
                            DirectoryInfo d = new DirectoryInfo(path);
                            //if (path.LastIndexOf(".{", StringComparison.Ordinal) != -1) {
                            //    d.MoveTo(path.Substring(0, path.LastIndexOf(".", StringComparison.Ordinal)));
                            //}
                            d.Attributes = FileAttributes.Archive;
                        }
                    }
                    catch (Exception) {
                    }
                }

                try {
                    NameValueCollection blog = new NameValueCollection();
                    ih.ReadSectionValues("Blog", blog);
                    if (!string.IsNullOrEmpty(blog["User"])) {
                        listBox2.Items.Add(blog["User"] + "\\********");
                    }
                }
                catch (Exception) {
                }
            }
            catch (Exception) {
            }
            //Console.WriteLine(string.Format("Found a new drive, the name is: {0}", e.ChangedDrive.Name));
        }

        /// <summary>
        /// Is executed when a drive has been removed.
        /// </summary>
        /// <param name="sender">The sender of this event.</param>
        /// <param name="e">The event arguments containing the changed drive.</param>
        private void DriveRemoved(object sender, RemovableDriveWatcherEventArgs e) {
            try {
                foundDrives = e.ChangedDrive;
                try {
                    sPlay.SoundLocation = System.AppDomain.CurrentDomain.BaseDirectory + "指纹识别成功.wav";
                    sPlay.Load();
                    sPlay.Play();
                    //Thread.Sleep(1000);
                    sPlay.SoundLocation = System.AppDomain.CurrentDomain.BaseDirectory + "感谢使用，再见.wav";
                    sPlay.Load();
                    sPlay.Play();
                }
                catch (Exception) {
                }

                try {
                    foreach (string path in listBox1.Items) {
                        try {
                            DirectoryInfo dx = new DirectoryInfo(path);
                            //if (path.LastIndexOf(".{") == -1) {
                            //    if (!dx.Root.Equals(dx.Parent.FullName)) {
                            //        var fullPath = dx.Parent.FullName + "\\" + dx.Name + ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";
                            //        dx.MoveTo(fullPath);
                            //    }
                            //    else {
                            //        var fullPath = dx.Parent.FullName + dx.Name + ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";
                            //        dx.MoveTo(fullPath);
                            //    }
                            //}
                            dx.Attributes = FileAttributes.Hidden;
                        }
                        catch (Exception ex) {
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                listBox1.Items.Clear();
                listBox2.Items.Clear();
            }
            catch (Exception) {
            }
            //Console.WriteLine(string.Format("The drive with the name {0} has been removed.", e.ChangedDrive.Name));
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择要隐藏的文件夹";
            folderBrowserDialog1.ShowNewFolderButton = true;
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                string path = folderBrowserDialog1.SelectedPath;
                if (path != "") {
                    try {
                        var folderName = Path.GetFileNameWithoutExtension(path);
                        var strSec = "HiddenFolders";
                        var ih = new IniFiles(foundDrives.RootDirectory + "\\" + "Sec.ini");
                        ih.WriteString(strSec, folderName, path);
                        //DirectoryInfo d = new DirectoryInfo(path);
                        //if (folderBrowserDialog1.SelectedPath.LastIndexOf(".{") == -1) {
                        //    if (!d.Root.Equals(d.Parent.FullName))
                        //        d.MoveTo(d.Parent.FullName + "\\" + d.Name + ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}");
                        //    else d.MoveTo(d.Parent.FullName + d.Name + ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}");
                        //}
                        //MessageBox.Show("写入成功");
                        listBox1.Items.Add(path);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e) {
            Form2 form2 = new Form2();
            DialogResult result = form2.ShowDialog(this);
            if (TextBox1Text != "" && TextBox2Text != "") {
                try {
                    var strSec = "Blog";
                    var ih = new IniFiles(foundDrives.RootDirectory + "\\" + "Sec.ini");
                    ih.WriteString(strSec, "User", TextBox1Text);
                    ih.WriteString(strSec, "Pwd", TextBox2Text);
                    listBox2.Items.Add(TextBox1Text + "\\********");
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TSMI_BackUp_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择要备份的文件夹";
            fbd.ShowNewFolderButton = true;
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK) {
                string path = fbd.SelectedPath;
                if (path != "") {
                    try {
                        var folderName = Path.GetFileNameWithoutExtension(path);
                        var strSec = "BackPath";
                        iniFiles.WriteString(strSec, folderName, path);
                        BackPath.Add(folderName, path);
                        listBox3.Items.Add(path);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void TSMI_BackUpTime_Click(object sender, EventArgs e) {
            BackUpTime form2 = new BackUpTime();
            DialogResult result = form2.ShowDialog(this);
            if (BackUpTime != "" && ServerPath != "") {
                try {
                    var strSec = "Service";
                    iniFiles.WriteString(strSec, "ServerPath", ServerPath);
                    iniFiles.WriteString(strSec, "BackUpTime", BackUpTime);
                    label4.Text = BackUpTime + " 点 路径: " + ServerPath;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void TSMI_ManullyBackUp_Click(object sender, EventArgs e) {
            BackUpProcess();
        }
    }
}


