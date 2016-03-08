namespace SecureUtility {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.备份ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_BackUp = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_BackUpTime = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_ManullyBackUp = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowMainWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.Exits = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI1,
            this.备份ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(522, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSMI1
            // 
            this.TSMI1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.TSMI1.Name = "TSMI1";
            this.TSMI1.Size = new System.Drawing.Size(45, 20);
            this.TSMI1.Text = "设置";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(139, 22);
            this.toolStripMenuItem2.Text = "隐藏文件夹";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(139, 22);
            this.toolStripMenuItem3.Text = "微博帐号";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // 备份ToolStripMenuItem
            // 
            this.备份ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_BackUp,
            this.TSMI_BackUpTime,
            this.TSMI_ManullyBackUp});
            this.备份ToolStripMenuItem.Name = "备份ToolStripMenuItem";
            this.备份ToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.备份ToolStripMenuItem.Text = "备份";
            // 
            // TSMI_BackUp
            // 
            this.TSMI_BackUp.Name = "TSMI_BackUp";
            this.TSMI_BackUp.Size = new System.Drawing.Size(139, 22);
            this.TSMI_BackUp.Text = "备份文件夹";
            this.TSMI_BackUp.Click += new System.EventHandler(this.TSMI_BackUp_Click);
            // 
            // TSMI_BackUpTime
            // 
            this.TSMI_BackUpTime.Name = "TSMI_BackUpTime";
            this.TSMI_BackUpTime.Size = new System.Drawing.Size(139, 22);
            this.TSMI_BackUpTime.Text = "备份计划";
            this.TSMI_BackUpTime.Click += new System.EventHandler(this.TSMI_BackUpTime_Click);
            // 
            // TSMI_ManullyBackUp
            // 
            this.TSMI_ManullyBackUp.Name = "TSMI_ManullyBackUp";
            this.TSMI_ManullyBackUp.Size = new System.Drawing.Size(139, 22);
            this.TSMI_ManullyBackUp.Text = "手动备份";
            this.TSMI_ManullyBackUp.Click += new System.EventHandler(this.TSMI_ManullyBackUp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "隐藏的文件夹:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "保存的微博帐号-热键ALT+D:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(53, 63);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(408, 82);
            this.listBox1.TabIndex = 5;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(53, 175);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(408, 30);
            this.listBox2.TabIndex = 6;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(53, 235);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(408, 82);
            this.listBox3.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "备份的文件夹-备份时间:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 9;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SecureUtility";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowMainWindow,
            this.Exits});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 48);
            // 
            // ShowMainWindow
            // 
            this.ShowMainWindow.Name = "ShowMainWindow";
            this.ShowMainWindow.Size = new System.Drawing.Size(139, 22);
            this.ShowMainWindow.Text = "显示主界面";
            this.ShowMainWindow.Click += new System.EventHandler(this.ShowMainWindow_Click);
            // 
            // Exits
            // 
            this.Exits.Name = "Exits";
            this.Exits.Size = new System.Drawing.Size(139, 22);
            this.Exits.Text = "退出";
            this.Exits.Click += new System.EventHandler(this.Exits_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 405);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SecureUtility";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMI1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ToolStripMenuItem 备份ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_BackUp;
        private System.Windows.Forms.ToolStripMenuItem TSMI_BackUpTime;
        private System.Windows.Forms.ToolStripMenuItem TSMI_ManullyBackUp;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowMainWindow;
        private System.Windows.Forms.ToolStripMenuItem Exits;
    }
}

