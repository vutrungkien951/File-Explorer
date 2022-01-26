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

                    foreach (String subFolder in Directory.GetDirectories(currentPath))
                    {
                        DirectoryInfo dic = new DirectoryInfo(subFolder);
                        
                        if (dic.Name.ToLower().Contains(text))
                        {
                            addFolderToListView(dic);
                        }
                        
                    }

                    foreach(String subFile in Directory.GetFiles(currentPath))
                    {
                        FileInfo file = new FileInfo(subFile);

                        if (file.Name.ToLower().Contains(text))
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
                    foreach(String subFolder in Directory.GetDirectories(drive))
                    {
                        search(subFolder);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView.Items)
            {
                String type = item.SubItems[2].Text;
                var pathFile = item.SubItems[4].Text + "\\" + item.SubItems[0].Text;

                if(type == "File Folder")
                {
                    if (Directory.Exists(pathFile))
                    {
                        try
                        {
                            System.IO.Directory.Delete(pathFile, true);
                        }

                        catch (IOException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else
                {
                    if (File.Exists(pathFile))
                    {
                        try
                        {
                            File.Delete(pathFile);
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine(ex.Message);
                            return;
                        }
                    }

                }
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
