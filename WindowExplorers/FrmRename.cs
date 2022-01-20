using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowExplorers
{
    public partial class FrmRename : Form
    {
        String filePath;
        public FrmRename()
        {
            InitializeComponent();
        }

        public FrmRename(String text):this()
        {
            filePath = text;
        }
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (txtNewName.Text.Length == 0) return;

        }
    }
}
