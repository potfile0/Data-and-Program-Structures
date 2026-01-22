namespace Ksu.Cis300.NameLookup
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Frequency",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Rank",
            ""}, -1);
            this.uxMenuBar = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uxFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.uxOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.uxNameLabel = new System.Windows.Forms.ToolStripTextBox();
            this.uxName = new System.Windows.Forms.ToolStripTextBox();
            this.uxLookup = new System.Windows.Forms.ToolStripMenuItem();
            this.uxRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.uxTable = new System.Windows.Forms.ListView();
            this.uxAttributeHeader = new System.Windows.Forms.ColumnHeader();
            this.uxValueHeader = new System.Windows.Forms.ColumnHeader();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.uxSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.uxMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxMenuBar
            // 
            this.uxMenuBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.uxFileMenu,
            this.uxNameLabel,
            this.uxName,
            this.uxLookup,
            this.uxRemove});
            this.uxMenuBar.Location = new System.Drawing.Point(0, 0);
            this.uxMenuBar.Name = "uxMenuBar";
            this.uxMenuBar.Size = new System.Drawing.Size(800, 35);
            this.uxMenuBar.TabIndex = 0;
            this.uxMenuBar.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(16, 31);
            // 
            // uxFileMenu
            // 
            this.uxFileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxOpen,
            this.uxSaveAs});
            this.uxFileMenu.Name = "uxFileMenu";
            this.uxFileMenu.Size = new System.Drawing.Size(54, 31);
            this.uxFileMenu.Text = "File";
            // 
            // uxOpen
            // 
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(270, 34);
            this.uxOpen.Text = "Open . . .";
            this.uxOpen.Click += new System.EventHandler(this.OpenClick);
            // 
            // uxNameLabel
            // 
            this.uxNameLabel.Name = "uxNameLabel";
            this.uxNameLabel.ReadOnly = true;
            this.uxNameLabel.Size = new System.Drawing.Size(80, 31);
            this.uxNameLabel.Text = "Name:";
            this.uxNameLabel.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxName
            // 
            this.uxName.Name = "uxName";
            this.uxName.Size = new System.Drawing.Size(300, 31);
            // 
            // uxLookup
            // 
            this.uxLookup.Name = "uxLookup";
            this.uxLookup.Size = new System.Drawing.Size(88, 31);
            this.uxLookup.Text = "Lookup";
            this.uxLookup.Click += new System.EventHandler(this.LookupClick);
            // 
            // uxRemove
            // 
            this.uxRemove.Name = "uxRemove";
            this.uxRemove.Size = new System.Drawing.Size(92, 31);
            this.uxRemove.Text = "Remove";
            this.uxRemove.Click += new System.EventHandler(this.RemoveClick);
            // 
            // uxTable
            // 
            this.uxTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uxAttributeHeader,
            this.uxValueHeader});
            this.uxTable.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewItem1.Tag = "";
            this.uxTable.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.uxTable.Location = new System.Drawing.Point(0, 35);
            this.uxTable.Name = "uxTable";
            this.uxTable.Size = new System.Drawing.Size(800, 415);
            this.uxTable.TabIndex = 1;
            this.uxTable.UseCompatibleStateImageBehavior = false;
            this.uxTable.View = System.Windows.Forms.View.Details;
            // 
            // uxAttributeHeader
            // 
            this.uxAttributeHeader.Text = "Attribute";
            this.uxAttributeHeader.Width = 120;
            // 
            // uxValueHeader
            // 
            this.uxValueHeader.Text = "Value";
            this.uxValueHeader.Width = 120;
            // 
            // uxSaveAs
            // 
            this.uxSaveAs.Name = "uxSaveAs";
            this.uxSaveAs.Size = new System.Drawing.Size(270, 34);
            this.uxSaveAs.Text = "Save As . . .";
            this.uxSaveAs.Click += new System.EventHandler(this.SaveAsClick);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uxTable);
            this.Controls.Add(this.uxMenuBar);
            this.MainMenuStrip = this.uxMenuBar;
            this.Name = "UserInterface";
            this.Text = "Name Lookup";
            this.uxMenuBar.ResumeLayout(false);
            this.uxMenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip uxMenuBar;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem uxFileMenu;
        private ToolStripMenuItem uxOpen;
        private ToolStripTextBox uxNameLabel;
        private ToolStripTextBox uxName;
        private ListView uxTable;
        private ColumnHeader uxAttributeHeader;
        private ColumnHeader uxValueHeader;
        private OpenFileDialog uxOpenDialog;
        private ToolStripMenuItem uxLookup;
        private ToolStripMenuItem uxRemove;
        private ToolStripMenuItem uxSaveAs;
        private SaveFileDialog uxSaveDialog;
    }
}
