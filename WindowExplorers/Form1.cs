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
using System.Runtime.InteropServices;

namespace WindowExplorers
{
    public partial class Form1 : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        public Form1()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView.ListViewItemSorter = lvwColumnSorter;
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
        private void updateListView(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    listView.Items.Clear();
                    string[] dirs = Directory.GetDirectories(path);


                    foreach (string dir in dirs)
                    {

                        var item = new ListViewItem(Path.GetFileName(dir));
                        var date = Directory.GetLastWriteTime(dir);
                        var strDate = date.ToShortDateString();
                        item.SubItems.Add(strDate);
                        var stringType = "File Folder";
                        item.SubItems.Add(stringType);
                        item.SubItems.Add("");
                        item.ImageIndex = 0;

                        listView.Items.Add(item);
                    }

                    DirectoryInfo dirParent = new DirectoryInfo(path);
                    listView.BeginUpdate();
                    foreach (FileInfo fileInfo in dirParent.GetFiles())
                    {
                        Icon iconForFile = SystemIcons.WinLogo;

                        var item = new ListViewItem(fileInfo.Name);
                        var date = fileInfo.LastWriteTime;
                        var strDate = date.ToShortDateString();
                        item.SubItems.Add(strDate);
                        var extension = fileInfo.Extension;
                        var key = extension.Substring(1);
                        var type = Extension.getType(key);
                        


                        if (type != null)
                        {
                            item.SubItems.Add(type);
                        }
                        else
                        {
                            item.SubItems.Add("Unknown type file");
                        }


                        var bytes = fileInfo.Length / 1024;
                        var size = bytes + " KB";
                        item.SubItems.Add(size);

                        //Add icon 
                        if (!imageListSmallIcon.Images.ContainsKey(fileInfo.Extension))
                        {
                            iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName);
                            imageListSmallIcon.Images.Add(fileInfo.Extension, iconForFile);
                        }
                        item.ImageKey = fileInfo.Extension;

                        listView.Items.Add(item);
                    }
                    txtPath.Text = path;
                    listView.EndUpdate();
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
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

            string path = e.Node.FullPath;
            txtPath.Text = path;
            updateListView(path);
        }
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        private const int SW_SHOW = 5;
        private const uint SEE_MASK_INVOKEIDLIST = 12;
        public static bool ShowFileProperties(string Filename)
        {
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
            info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
            info.lpVerb = "properties";
            info.lpFile = Filename;
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            return ShellExecuteEx(ref info);
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            string strSelectedItem = listView.SelectedItems[0].SubItems[0].Text;
            string path = txtPath.Text + strSelectedItem;

            ShowFileProperties(path);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = Directory.CreateDirectory(txtPath.Text);
            updateListView(txtPath.Text);
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listView.SelectedItems.Count == 1)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                if(selectedItem.SubItems[2].Text == "File Folder")
                {
                    var path = txtPath.Text + "\\" + selectedItem.SubItems[0].Text;
                    updateListView(path);
                }
            }
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView.Sort();
        }
    }
}
