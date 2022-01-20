using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowExplorers
{
    public partial class FrmCreateFolder : Form
    {
        String path;
        public FrmCreateFolder()
        {
            InitializeComponent();
        }

        public FrmCreateFolder(String text) : this()
        {
            path = text;
        }

        private void FrmCreateFolder_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            if (txtNameFolder.Text == "") return;
            var newFolderPath = path + "\\" + txtNameFolder.Text;

            if (!Directory.Exists(newFolderPath))
            {
                Directory.CreateDirectory(newFolderPath);
                MessageBox.Show("The folder \\" + newFolderPath + " is created!");
                this.Close();
            }
            else
            {
                MessageBox.Show("The folder " + newFolderPath + " can't created");
            }
        }

        private void FrmCreateFolder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.form1.Show();
        }
    }
}
