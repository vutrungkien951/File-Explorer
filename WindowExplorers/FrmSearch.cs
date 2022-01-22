using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowExplorers
{
    public partial class FrmSearch : Form
    {
        public FrmSearch()
        {
            InitializeComponent();
        }

        private void FrmSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.form1.Show();
        }
    }
}
