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
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "Frequency", "" }, -1);
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "Rank", "" }, -1);
            uxMenuBar = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            uxFileMenu = new ToolStripMenuItem();
            uxOpen = new ToolStripMenuItem();
            uxNameLabel = new ToolStripTextBox();
            uxName = new ToolStripTextBox();
            uxLookup = new ToolStripMenuItem();
            uxTable = new ListView();
            uxAttributeHeader = new ColumnHeader();
            uxValueHeader = new ColumnHeader();
            uxOpenDialog = new OpenFileDialog();
            uxMenuBar.SuspendLayout();
            SuspendLayout();
            // 
            // uxMenuBar
            // 
            uxMenuBar.ImageScalingSize = new Size(24, 24);
            uxMenuBar.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, uxFileMenu, uxNameLabel, uxName, uxLookup });
            uxMenuBar.Location = new Point(0, 0);
            uxMenuBar.Name = "uxMenuBar";
            uxMenuBar.Padding = new Padding(4, 1, 0, 1);
            uxMenuBar.Size = new Size(560, 25);
            uxMenuBar.TabIndex = 0;
            uxMenuBar.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(12, 23);
            // 
            // uxFileMenu
            // 
            uxFileMenu.DropDownItems.AddRange(new ToolStripItem[] { uxOpen });
            uxFileMenu.Name = "uxFileMenu";
            uxFileMenu.Size = new Size(37, 23);
            uxFileMenu.Text = "File";
            // 
            // uxOpen
            // 
            uxOpen.Name = "uxOpen";
            uxOpen.Size = new Size(180, 22);
            uxOpen.Text = "Open . . .";
            uxOpen.Click += UxOpenClick;
            // 
            // uxNameLabel
            // 
            uxNameLabel.Name = "uxNameLabel";
            uxNameLabel.ReadOnly = true;
            uxNameLabel.Size = new Size(57, 23);
            uxNameLabel.Text = "Name:";
            uxNameLabel.TextBoxTextAlign = HorizontalAlignment.Right;
            // 
            // uxName
            // 
            uxName.Name = "uxName";
            uxName.Size = new Size(211, 23);
            // 
            // uxLookup
            // 
            uxLookup.Name = "uxLookup";
            uxLookup.Size = new Size(59, 23);
            uxLookup.Text = "Lookup";
            uxLookup.Click += UxLookup_Click;
            // 
            // uxTable
            // 
            uxTable.Columns.AddRange(new ColumnHeader[] { uxAttributeHeader, uxValueHeader });
            uxTable.Dock = DockStyle.Fill;
            uxTable.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2 });
            uxTable.Location = new Point(0, 25);
            uxTable.Margin = new Padding(2);
            uxTable.Name = "uxTable";
            uxTable.Size = new Size(560, 245);
            uxTable.TabIndex = 1;
            uxTable.UseCompatibleStateImageBehavior = false;
            uxTable.View = View.Details;
            // 
            // uxAttributeHeader
            // 
            uxAttributeHeader.Text = "Attribute";
            uxAttributeHeader.Width = 120;
            // 
            // uxValueHeader
            // 
            uxValueHeader.Text = "Value";
            uxValueHeader.Width = 120;
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(uxTable);
            Controls.Add(uxMenuBar);
            MainMenuStrip = uxMenuBar;
            Margin = new Padding(2);
            Name = "UserInterface";
            Text = "Name Lookup";
            uxMenuBar.ResumeLayout(false);
            uxMenuBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
    }
}
