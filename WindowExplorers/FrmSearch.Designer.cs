
namespace WindowExplorers
{
    partial class FrmSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView = new System.Windows.Forms.ListView();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnDateModified = new System.Windows.Forms.ColumnHeader();
            this.columnType = new System.Windows.Forms.ColumnHeader();
            this.columnSize = new System.Windows.Forms.ColumnHeader();
            this.columnFolder = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnDateModified,
            this.columnType,
            this.columnSize,
            this.columnFolder});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(654, 327);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 100;
            // 
            // columnDateModified
            // 
            this.columnDateModified.Text = "Date modified";
            this.columnDateModified.Width = 100;
            // 
            // columnType
            // 
            this.columnType.Text = "Type";
            this.columnType.Width = 100;
            // 
            // columnSize
            // 
            this.columnSize.Text = "Size";
            this.columnSize.Width = 100;
            // 
            // columnFolder
            // 
            this.columnFolder.Text = "Folder";
            this.columnFolder.Width = 130;
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 327);
            this.Controls.Add(this.listView);
            this.Name = "FrmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search File/Folder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSearch_FormClosing);
            this.Load += new System.EventHandler(this.FrmSearch_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnDateModified;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.ColumnHeader columnFolder;
    }
}