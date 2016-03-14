using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecureUtility {
    public partial class BackUpDetails : Form {
        public List<ChangedFile> ChangedFiles { get; set; }
        public BackUpDetails() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BackUpDetails_Activated(object sender, EventArgs e) {
            dataGridView1.DataSource = ChangedFiles;
        }
    }
}
