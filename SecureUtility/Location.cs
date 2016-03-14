using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecureUtility {
    public partial class Location : Form {
        public Location() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.pictureBox1.SendToBack();//将背景图片放到最下面
            this.panel1.BackColor = Color.Transparent;//将Panel设为透明
            this.panel1.Parent = this.pictureBox1;//将panel父控件设为背景图片控件
            this.panel1.BringToFront();//将panel放在前面

            panel2.BackColor = Color.Transparent;
            panel2.Parent = this.pictureBox1;
            panel2.BringToFront();

            panel3.BackColor = Color.Transparent;
            panel3.Parent = this.pictureBox1;
            panel3.BringToFront();

            panel4.BackColor = Color.Transparent;
            panel4.Parent = this.pictureBox1;
            panel4.BringToFront();

            panel5.BackColor = Color.Transparent;
            panel5.Parent = this.pictureBox1;
            panel5.BringToFront();

            panel6.BackColor = Color.Transparent;
            panel6.Parent = this.pictureBox1;
            panel6.BringToFront();
        }

        private void 查看历史轨迹ToolStripMenuItem_Click(object sender, EventArgs e) {
            pictureBox1.Image = Properties.Resources.防盗定位2;
            //Form2 form2 = new Form2();
            //this.Hide();
            //form2.Show();
        }



        private void 发消息ToolStripMenuItem_Click(object sender, EventArgs e) {
            //Form3 form2 = new Form3();
            //DialogResult result = form2.ShowDialog(this);
        }

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e) {
            pictureBox1.Image = Properties.Resources.防盗定位3;
        }

        private void panel3_MouseDoubleClick(object sender, MouseEventArgs e) {
            pictureBox1.Image = Properties.Resources.防盗定位4;
        }

        private void panel4_MouseDoubleClick(object sender, MouseEventArgs e) {
            pictureBox1.Image = Properties.Resources.防盗定位6;
        }

        private void panel5_MouseDoubleClick(object sender, MouseEventArgs e) {
            pictureBox1.Image = Properties.Resources.防盗定位6;
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e) {
            pictureBox1.Image = Properties.Resources.防盗定位2;
        }

        private void panel6_MouseDoubleClick(object sender, MouseEventArgs e) {
            pictureBox1.Image = Properties.Resources.防盗定位5;
        }


    }
}
