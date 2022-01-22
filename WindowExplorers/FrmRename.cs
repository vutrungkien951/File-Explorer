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
    public partial class FrmRename : Form
    {
        String filePath;
        String path;
        public FrmRename()
        {
            InitializeComponent();
        }

        public FrmRename(String text, String p):this()
        {
            filePath = text;
            path = p;
        }
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (txtNewName.Text.Length == 0) return;
            String newFilePath = path + "\\" + txtNewName.Text;
            

            if (Directory.Exists(filePath))
            {
                //file rename la folder
                try
                {
                    Directory.Move(filePath, newFilePath);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //file rename la file binh thuong
                try
                {
                    File.Move(filePath, newFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Close();
        }

        private void FrmRename_Load(object sender, EventArgs e)
        {
            lbPath.Text = filePath;
        }

        private void FrmRename_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.form1.Show();
        }
    }
}
