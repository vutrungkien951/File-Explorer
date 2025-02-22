﻿using System;
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
using System.Diagnostics;

namespace WindowExplorers
{
    public partial class Form1 : Form
    {
        private string[] history = new string[100];
        private int historyCount = 0;
        private ListViewColumnSorter lvwColumnSorter;
        private string[] selectedItems = new string[100];
        private int count = 0;
        private string selectedPath;
        private bool copy = false;

        public static Form1 form1;
        public static ImageList listImageSmall;
        public static ImageList listImageLarge;
        public Form1()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView.ListViewItemSorter = lvwColumnSorter;
            form1 = this;
            listImageSmall = listView.SmallImageList;
            listImageLarge = listView.LargeImageList;
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
            treeView.Nodes.Clear();
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


                        long bytes = fileInfo.Length;
                        string[] strKiTu = new string[] { "B", "KB", "MB", "GB" };
                        int i = 0;
                        while (bytes / 1024 != 0)
                        {
                            bytes = bytes / 1024;
                            i++;
                        }
                        string str = Convert.ToString(bytes) + " " + strKiTu[i];
                        
                        item.SubItems.Add(str);

                        //Add icon 
                        if (!imageListSmallIcon.Images.ContainsKey(fileInfo.Extension))
                        {
                            iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName);
                            imageListSmallIcon.Images.Add(fileInfo.Extension, iconForFile);
                            imageListLargeIcon.Images.Add(fileInfo.Extension, iconForFile);
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
            try
            {
                history[historyCount] = txtPath.Text;
                historyCount++;
                string path = e.Node.FullPath;
                txtPath.Text = path;
                updateListView(txtPath.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            
            FrmCreateFolder f = new FrmCreateFolder(txtPath.Text);
            this.Hide();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                updateListView(txtPath.Text);
            }

        }
        public static void OpenWithDefaultProgram(string path)
        {
            using Process myProcess = new Process();

            myProcess.StartInfo.UseShellExecute = true;
            // You can start any process, HelloWorld is a do-nothing example.
            myProcess.StartInfo.FileName = path;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.Start();
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            history[historyCount] = txtPath.Text;
            historyCount++;
            ListViewItem selectedItem = listView.SelectedItems[0];
            if (listView.SelectedItems.Count == 1)
            {
                if(selectedItem.SubItems[2].Text == "File Folder")
                {
                    var path = txtPath.Text + "\\" + selectedItem.SubItems[0].Text;
                    updateListView(path);
                }
                else
                {
                    try
                    {
                        Form1.OpenWithDefaultProgram(txtPath.Text + "\\" + selectedItem.SubItems[0].Text);

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        private static void MoveFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath))
            {
                File.Move(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var path = txtPath.Text;
            selectedPath = path;
            count = 0;

            for(int i=0; i < listView.SelectedItems.Count; i++)
            {
                selectedItems[i] = listView.SelectedItems[i].SubItems[0].Text;
                count++;
            }
            copy = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if(!copy)
            {
                for(int i=0; i < count; i++)
                {
                    var pathFile = selectedPath + @"\" + selectedItems[i];
                    var newPathFile = txtPath.Text + @"\" + selectedItems[i];
                    if (File.Exists(pathFile))
                    {
                        File.Move(pathFile, newPathFile);
                    }
                    else
                    {
                        Directory.Move(pathFile, newPathFile);
                    }
                }
                updateListView(txtPath.Text);
                count = 0;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    var pathFile = selectedPath + @"\" + selectedItems[i];
                    var newPathFile = txtPath.Text + @"\" + selectedItems[i];
                    if (File.Exists(pathFile))
                    {
                        File.Copy(pathFile, newPathFile, true);
                    }
                    else
                    {
                        CopyFilesRecursively(pathFile, newPathFile);
                    }
                }
                updateListView(txtPath.Text);
            }
            InitFolder();
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            updateListView(txtPath.Text);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var path = txtPath.Text;
            selectedPath = path;
            count = 0;

            for (int i = 0; i < listView.SelectedItems.Count; i++)
            {
                selectedItems[i] = listView.SelectedItems[i].SubItems[0].Text;
                count++;
            }
            copy = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select 1 file to rename");
                return;
            }

            this.Hide();
            var path = txtPath.Text + "\\" + listView.SelectedItems[0].SubItems[0].Text;
            FrmRename f = new FrmRename(path, txtPath.Text);
            
            if(f.ShowDialog(this) == DialogResult.OK)
            {
                updateListView(txtPath.Text);
            }
            
        }

        private void tbSearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (tbSearchBar.Text.Length == 0)
                {
                    MessageBox.Show("Enter file to search!");
                    return;
                }
                this.Hide();
                FrmSearch f = new FrmSearch(tbSearchBar.Text.ToLower());
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    updateListView(txtPath.Text);
                }
            }
            
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (historyCount < 0)
                {
                    return;
                }
                historyCount--;
                updateListView(history[historyCount]);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btFoward_Click(object sender, EventArgs e)
        {
            try
            {
                if (historyCount < 0)
                {
                    return;
                }
                historyCount++;
                updateListView(history[historyCount]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackToParent_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dic = new DirectoryInfo(txtPath.Text);
                
                if(dic.Parent == null)
                {
                    MessageBox.Show("Current folder has no parent folder");
                }
                else
                {
                    updateListView(dic.Parent.FullName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
