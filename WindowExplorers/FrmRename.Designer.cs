
namespace WindowExplorers
{
    partial class FrmRename
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbPath = new System.Windows.Forms.Label();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.btnRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rename to";
            // 
            // lbPath
            // 
            this.lbPath.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbPath.Location = new System.Drawing.Point(186, 24);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(354, 30);
            this.lbPath.TabIndex = 1;
            this.lbPath.Text = "Name file/folder to be renamed";
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(186, 82);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(354, 32);
            this.txtNewName.TabIndex = 2;
            // 
            // btnRename
            // 
            this.btnRename.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRename.Location = new System.Drawing.Point(203, 155);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(160, 47);
            this.btnRename.TabIndex = 3;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // FrmRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 258);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.lbPath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRename";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rename Folder";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRename_FormClosing);
            this.Load += new System.EventHandler(this.FrmRename_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Button btnRename;
    }
}