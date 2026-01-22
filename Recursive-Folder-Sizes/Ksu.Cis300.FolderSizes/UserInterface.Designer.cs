namespace Ksu.Cis300.FolderSizes
{
    partial class UserInterface
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxMenuBar = new System.Windows.Forms.MenuStrip();
            this.uxOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.uxCurrentFolder = new System.Windows.Forms.ToolStripTextBox();
            this.uxSizeLabel = new System.Windows.Forms.ToolStripTextBox();
            this.uxSize = new System.Windows.Forms.ToolStripTextBox();
            this.uxUp = new System.Windows.Forms.ToolStripMenuItem();
            this.uxFolderList = new System.Windows.Forms.ListBox();
            this.uxFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.uxMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxMenuBar
            // 
            this.uxMenuBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxOpen,
            this.uxCurrentFolder,
            this.uxUp,
            this.uxSizeLabel,
            this.uxSize});
            this.uxMenuBar.Location = new System.Drawing.Point(0, 0);
            this.uxMenuBar.Name = "uxMenuBar";
            this.uxMenuBar.Size = new System.Drawing.Size(958, 35);
            this.uxMenuBar.TabIndex = 0;
            this.uxMenuBar.Text = "menuStrip1";
            // 
            // uxOpen
            // 
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(82, 31);
            this.uxOpen.Text = "Folder:";
            this.uxOpen.Click += new System.EventHandler(this.OpenClick);
            // 
            // uxCurrentFolder
            // 
            this.uxCurrentFolder.Name = "uxCurrentFolder";
            this.uxCurrentFolder.ReadOnly = true;
            this.uxCurrentFolder.Size = new System.Drawing.Size(300, 31);
            // 
            // uxSizeLabel
            // 
            this.uxSizeLabel.Name = "uxSizeLabel";
            this.uxSizeLabel.ReadOnly = true;
            this.uxSizeLabel.Size = new System.Drawing.Size(100, 31);
            this.uxSizeLabel.Text = "Size:";
            this.uxSizeLabel.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxSize
            // 
            this.uxSize.Name = "uxSize";
            this.uxSize.ReadOnly = true;
            this.uxSize.Size = new System.Drawing.Size(200, 31);
            this.uxSize.Text = "0";
            // 
            // uxUp
            // 
            this.uxUp.Enabled = false;
            this.uxUp.Name = "uxUp";
            this.uxUp.Size = new System.Drawing.Size(40, 31);
            this.uxUp.Text = "^";
            this.uxUp.Click += new System.EventHandler(this.UpClick);
            // 
            // uxFolderList
            // 
            this.uxFolderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxFolderList.FormattingEnabled = true;
            this.uxFolderList.ItemHeight = 25;
            this.uxFolderList.Location = new System.Drawing.Point(0, 35);
            this.uxFolderList.Name = "uxFolderList";
            this.uxFolderList.Size = new System.Drawing.Size(958, 415);
            this.uxFolderList.TabIndex = 2;
            this.uxFolderList.SelectedIndexChanged += new System.EventHandler(this.FolderListSelectedIndexChanged);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 450);
            this.Controls.Add(this.uxFolderList);
            this.Controls.Add(this.uxMenuBar);
            this.MainMenuStrip = this.uxMenuBar;
            this.Name = "UserInterface";
            this.Text = "Folder Sizes";
            this.uxMenuBar.ResumeLayout(false);
            this.uxMenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip uxMenuBar;
        private ListBox uxFolderList;
        private ToolStripMenuItem uxOpen;
        private ToolStripTextBox uxSizeLabel;
        private ToolStripTextBox uxSize;
        private ToolStripMenuItem uxUp;
        private ToolStripTextBox uxCurrentFolder;
        private FolderBrowserDialog uxFolderBrowser;
    }
}
