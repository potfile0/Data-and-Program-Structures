namespace Ksu.Cis300.TextEditor
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
            uxMenuBar = new MenuStrip();
            uxFile = new ToolStripMenuItem();
            uxOpen = new ToolStripMenuItem();
            uxSaveAs = new ToolStripMenuItem();
            encryptToolStripMenuItem = new ToolStripMenuItem();
            withStringToolStripMenuItem = new ToolStripMenuItem();
            withStringBuilderToolStripMenuItem = new ToolStripMenuItem();
            uxEditBuffer = new TextBox();
            uxOpenDialog = new OpenFileDialog();
            uxSaveDialog = new SaveFileDialog();
            uxMenuBar.SuspendLayout();
            SuspendLayout();
            // 
            // uxMenuBar
            // 
            uxMenuBar.Items.AddRange(new ToolStripItem[] { uxFile, encryptToolStripMenuItem });
            uxMenuBar.Location = new Point(0, 0);
            uxMenuBar.Name = "uxMenuBar";
            uxMenuBar.Size = new Size(800, 24);
            uxMenuBar.TabIndex = 0;
            uxMenuBar.Text = "menuStrip1";
            // 
            // uxFile
            // 
            uxFile.DropDownItems.AddRange(new ToolStripItem[] { uxOpen, uxSaveAs });
            uxFile.Name = "uxFile";
            uxFile.Size = new Size(37, 20);
            uxFile.Text = "File";
            // 
            // uxOpen
            // 
            uxOpen.Name = "uxOpen";
            uxOpen.Size = new Size(180, 22);
            uxOpen.Text = "Open . . .";
            uxOpen.Click += OpenClick;
            // 
            // uxSaveAs
            // 
            uxSaveAs.Name = "uxSaveAs";
            uxSaveAs.Size = new Size(180, 22);
            uxSaveAs.Text = "Save As . . .";
            uxSaveAs.Click += SaveAsClick;
            // 
            // encryptToolStripMenuItem
            // 
            encryptToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { withStringToolStripMenuItem, withStringBuilderToolStripMenuItem });
            encryptToolStripMenuItem.Name = "encryptToolStripMenuItem";
            encryptToolStripMenuItem.Size = new Size(59, 20);
            encryptToolStripMenuItem.Text = "Encrypt";
            // 
            // withStringToolStripMenuItem
            // 
            withStringToolStripMenuItem.Name = "withStringToolStripMenuItem";
            withStringToolStripMenuItem.Size = new Size(180, 22);
            withStringToolStripMenuItem.Text = "With String";
            withStringToolStripMenuItem.Click += WithStringClick;
            // 
            // withStringBuilderToolStripMenuItem
            // 
            withStringBuilderToolStripMenuItem.Name = "withStringBuilderToolStripMenuItem";
            withStringBuilderToolStripMenuItem.Size = new Size(180, 22);
            withStringBuilderToolStripMenuItem.Text = "With StringBuilder";
            withStringBuilderToolStripMenuItem.Click += WithStringBuilderClick;
            // 
            // uxEditBuffer
            // 
            uxEditBuffer.Dock = DockStyle.Fill;
            uxEditBuffer.Location = new Point(0, 24);
            uxEditBuffer.MaxLength = 0;
            uxEditBuffer.Multiline = true;
            uxEditBuffer.Name = "uxEditBuffer";
            uxEditBuffer.ScrollBars = ScrollBars.Vertical;
            uxEditBuffer.Size = new Size(800, 426);
            uxEditBuffer.TabIndex = 1;
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(uxEditBuffer);
            Controls.Add(uxMenuBar);
            MainMenuStrip = uxMenuBar;
            Name = "UserInterface";
            Text = "Text Editor";
            uxMenuBar.ResumeLayout(false);
            uxMenuBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MenuStrip uxMenuBar;
        private ToolStripMenuItem uxFile;
        private ToolStripMenuItem uxOpen;
        private ToolStripMenuItem uxSaveAs;
        private TextBox uxEditBuffer;
        private OpenFileDialog uxOpenDialog;
        private SaveFileDialog uxSaveDialog;
        private ToolStripMenuItem encryptToolStripMenuItem;
        private ToolStripMenuItem withStringToolStripMenuItem;
        private ToolStripMenuItem withStringBuilderToolStripMenuItem;
    }
}
