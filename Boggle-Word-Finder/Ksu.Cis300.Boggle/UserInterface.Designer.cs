namespace Ksu.Cis300.Boggle
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
            uxNewBoard = new ToolStripMenuItem();
            uxFindWords = new ToolStripMenuItem();
            uxBoard = new FlowLayoutPanel();
            uxOpenDialog = new OpenFileDialog();
            uxMenuBar.SuspendLayout();
            SuspendLayout();
            // 
            // uxMenuBar
            // 
            uxMenuBar.ImageScalingSize = new Size(24, 24);
            uxMenuBar.Items.AddRange(new ToolStripItem[] { uxNewBoard, uxFindWords });
            uxMenuBar.Location = new Point(0, 0);
            uxMenuBar.Name = "uxMenuBar";
            uxMenuBar.Padding = new Padding(4, 1, 0, 1);
            uxMenuBar.Size = new Size(560, 24);
            uxMenuBar.TabIndex = 0;
            uxMenuBar.Text = "menuStrip1";
            // 
            // uxNewBoard
            // 
            uxNewBoard.Name = "uxNewBoard";
            uxNewBoard.Size = new Size(77, 22);
            uxNewBoard.Text = "New Board";
            uxNewBoard.Click += NewBoardClick;
            // 
            // uxFindWords
            // 
            uxFindWords.Name = "uxFindWords";
            uxFindWords.Size = new Size(79, 22);
            uxFindWords.Text = "Find Words";
            uxFindWords.Click += uxFindWords_Click;
            // 
            // uxBoard
            // 
            uxBoard.Location = new Point(8, 22);
            uxBoard.Margin = new Padding(2, 2, 2, 2);
            uxBoard.Name = "uxBoard";
            uxBoard.Size = new Size(210, 90);
            uxBoard.TabIndex = 1;
            // 
            // uxOpenDialog
            // 
            uxOpenDialog.Title = "Select Word List File";
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(560, 270);
            Controls.Add(uxBoard);
            Controls.Add(uxMenuBar);
            MainMenuStrip = uxMenuBar;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            Name = "UserInterface";
            Text = "Boggle Deluxe";
            uxMenuBar.ResumeLayout(false);
            uxMenuBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MenuStrip uxMenuBar;
        private ToolStripMenuItem uxNewBoard;
        private ToolStripMenuItem uxFindWords;
        private FlowLayoutPanel uxBoard;
        private OpenFileDialog uxOpenDialog;
    }
}
