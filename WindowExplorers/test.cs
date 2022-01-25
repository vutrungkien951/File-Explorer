using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowExplorers
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long x = long.Parse(textBox1.Text);
            string[] mang = new string[] { "B", "KB", "MB", "GB" };
            int i = 0;
            while(x / 1024 != 0)
            {
                x = x / 1024;
                i++;
            }
            string str = Convert.ToString(x) + " " +mang[i];
            label2.Text = str;
        }
    }

}
