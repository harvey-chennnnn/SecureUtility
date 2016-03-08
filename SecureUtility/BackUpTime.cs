using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecureUtility {
    public partial class BackUpTime : Form {
        public BackUpTime() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void BackUpTime_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            Form1 frm1 = (Form1)this.Owner;
            frm1.ServerPath = this.textBox1.Text;
            frm1.BackUpTime = this.numericUpDown1.Text;
            this.Close();
        }
    }
}
