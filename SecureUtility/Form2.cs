using System;
using System.Windows.Forms;

namespace SecureUtility {
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void button1_Click(object sender, EventArgs e) {
            Form1 frm1 = (Form1)this.Owner;
            frm1.TextBox1Text = this.textBox1.Text;
            frm1.TextBox2Text = this.textBox2.Text;
            this.Close();
        }
    }
}
