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
    public partial class FrmSearch : Form
    {
        String text;
        
        public FrmSearch()
        {
            InitializeComponent();
        }
        public FrmSearch(String txt) : this()
        {
            text = txt;
        }

        private void FrmSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.form1.Show();
        }

        private void addFolderToListView(DirectoryInfo dic)
        {
            var path = dic.FullName;
            var item = new ListViewItem(dic.Name);
            var date = Directory.GetLastAccessTime(dic.FullName);
            var strDate = date.ToShortDateString();
            item.SubItems.Add(strDate);
            item.SubItems.Add("File Folder");
            item.SubItems.Add("");

            DirectoryInfo parent = dic.Parent;
            item.SubItems.Add(parent.FullName);
            item.ImageIndex = 0;

            listView.Items.Add(item);
        }

        private void addFileToListView(FileInfo file, String path)
        {
            var item = new ListViewItem(file.Name);
            var date = Directory.GetLastAccessTime(file.FullName);
            var strDate = date.ToShortDateString();
            item.SubItems.Add(strDate);
            var extension = file.Extension;
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

            item.SubItems.Add(file.Length.ToString());
            item.SubItems.Add(path);

            Icon iconForFile = SystemIcons.WinLogo;
            if (!listView.SmallImageList.Images.ContainsKey(file.Extension))
            {
                iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(file.FullName);
                listView.SmallImageList.Images.Add(file.Extension, iconForFile);
                listView.LargeImageList.Images.Add(file.Extension, iconForFile);
            }
            item.ImageKey = file.Extension;

            listView.Items.Add(item);
        }

        private void search(String currentPath)
        {
            try
            {
                if (Directory.Exists(currentPath))
                {
                    var temp = new DirectoryInfo(currentPath);
                    if (temp.Name.Contains(text))
                    {
                        addFolderToListView(temp);
                    }
                    
                    foreach (String subFolder in Directory.GetDirectories(currentPath))
                    {
                        DirectoryInfo dic = new DirectoryInfo(subFolder);
                        
                        if (dic.Name.Contains(text))
                        {
                            addFolderToListView(dic);
                        }
                        
                    }

                    foreach(String subFile in Directory.GetFiles(currentPath))
                    {
                        FileInfo file = new FileInfo(subFile);

                        if (file.Name.Contains(text))
                        {
                            addFileToListView(file, currentPath);
                        }
                    }
                }
            }
            catch {
                
            }

        }
        private void FrmSearch_Load(object sender, EventArgs e)
        {
            listView.SmallImageList = Form1.listImageSmall;
            listView.LargeImageList = Form1.listImageLarge;
            string[] drives = Directory.GetLogicalDrives();
            foreach (String drive in drives)
            {
                try
                {
                    search(drive);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
