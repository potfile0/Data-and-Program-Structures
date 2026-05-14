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
            uxEncrypt = new ToolStripMenuItem();
            uxEncryptWithString = new ToolStripMenuItem();
            uxEncryptWithStringBuilder = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            uxEditBuffer = new TextBox();
            uxOpenDialog = new OpenFileDialog();
            uxSaveDialog = new SaveFileDialog();
            uxMenuBar.SuspendLayout();
            SuspendLayout();
            // 
            // uxMenuBar
            // 
            uxMenuBar.Items.AddRange(new ToolStripItem[] { uxFile, uxEncrypt, editToolStripMenuItem });
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
            uxOpen.Size = new Size(132, 22);
            uxOpen.Text = "Open . . .";
            uxOpen.Click += OpenClick;
            // 
            // uxSaveAs
            // 
            uxSaveAs.Name = "uxSaveAs";
            uxSaveAs.Size = new Size(132, 22);
            uxSaveAs.Text = "Save As . . .";
            uxSaveAs.Click += SaveAsClick;
            // 
            // uxEncrypt
            // 
            uxEncrypt.DropDownItems.AddRange(new ToolStripItem[] { uxEncryptWithString, uxEncryptWithStringBuilder });
            uxEncrypt.Name = "uxEncrypt";
            uxEncrypt.Size = new Size(59, 20);
            uxEncrypt.Text = "Encrypt";
            // 
            // uxEncryptWithString
            // 
            uxEncryptWithString.Name = "uxEncryptWithString";
            uxEncryptWithString.Size = new Size(170, 22);
            uxEncryptWithString.Text = "With String";
            uxEncryptWithString.Click += EncryptWithStringClick;
            // 
            // uxEncryptWithStringBuilder
            // 
            uxEncryptWithStringBuilder.Name = "uxEncryptWithStringBuilder";
            uxEncryptWithStringBuilder.Size = new Size(170, 22);
            uxEncryptWithStringBuilder.Text = "With StringBuilder";
            uxEncryptWithStringBuilder.Click += EncryptWithStringBuilderClick;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(180, 22);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += UndoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(180, 22);
            redoToolStripMenuItem.Text = "Redo";
            redoToolStripMenuItem.Click += RedoToolStripMenuItem_Click;
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
            uxEditBuffer.TextChanged += uxEditBuffer_TextChanged;
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
        private ToolStripMenuItem uxEncrypt;
        private ToolStripMenuItem uxEncryptWithString;
        private ToolStripMenuItem uxEncryptWithStringBuilder;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
    }
}
