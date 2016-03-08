using System;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;

namespace SecureUtility {
    public partial class Form1 : Form {
        public string TextBox1Text { get; set; }
        public string TextBox2Text { get; set; }

        static System.Media.SoundPlayer sPlay = new System.Media.SoundPlayer();
        public static DriveInfo foundDrives;
        public Form1() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Load += new EventHandler(Form1_Load);
            Closed += new EventHandler(Form1_Closed);
            RemovableDriveWatcher rdw = new RemovableDriveWatcher();
            rdw.NewDriveFound += NewDriveFound;
            rdw.DriveRemoved += DriveRemoved;
            rdw.Start();
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

        private void Form1_Closed(object sender, EventArgs e) {
            //注销Id号为100的热键设定
            HotKey.UnregisterHotKey(Handle, 100);
            //注销Id号为101的热键设定
            HotKey.UnregisterHotKey(Handle, 101);
            //注销Id号为102的热键设定
            HotKey.UnregisterHotKey(Handle, 102);
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
        private static void NewDriveFound(object sender, RemovableDriveWatcherEventArgs e) {
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
                            listBox3.Items.Add(path);
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
                    if (!string.IsNullOrEmpty(blog["User"]))
                    {
                        listBox4.Items.Add(blog["User"] + "\\********");
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
        private static void DriveRemoved(object sender, RemovableDriveWatcherEventArgs e) {
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
                    foreach (string path in listBox3.Items) {
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
                listBox3.Items.Clear();
                listBox4.Items.Clear();
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
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message.ToString());

                    }
                    listBox3.Items.Add(path);
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
                    //MessageBox.Show("写入成功");
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message.ToString());

                }
                listBox4.Items.Add(TextBox1Text + "\\********");
            }
        }
    }
}


