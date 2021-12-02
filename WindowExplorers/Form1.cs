using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowExplorers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitFolder();
        }

        private void InitFolder()
        {
            string[] drives = Directory.GetLogicalDrives();
            TreeNode node = null;
            foreach (string drive in drives)
            {
                node = new TreeNode(drive);
                treeView.Nodes.Add(node);
                node.Nodes.Add("temp");
            }
        }

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            node.Nodes.Clear();
            node.ImageIndex = 1;
            //
            try
            {
                foreach (string dir in Directory.GetDirectories(node.FullPath))
                {
                    TreeNode newNode = node.Nodes.Add(Path.GetFileName(dir));
                    newNode.Nodes.Add("Temp");
                }
            }
            catch
            {

            }
        }

        private void treeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 0;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            string path = e.Node.FullPath;
            txtPath.Text = path;
            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    listView.Items.Clear();
                    string[] dirs = Directory.GetDirectories(path);


                    foreach (string dir in dirs)
                    {

                        var item = new ListViewItem(Path.GetFileName(dir));
                        var date = Directory.GetLastWriteTime(path);
                        var strDate = date.ToShortDateString();
                        item.SubItems.Add(strDate);
                        var stringType = "File Folder";
                        item.SubItems.Add(stringType);
                        item.ImageIndex = 0;

                        listView.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Folder can't open");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
