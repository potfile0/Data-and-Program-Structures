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
            this.uxMenuBar = new System.Windows.Forms.MenuStrip();
            this.uxNewBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.uxFindWords = new System.Windows.Forms.ToolStripMenuItem();
            this.uxBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxMenuBar
            // 
            this.uxMenuBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxNewBoard,
            this.uxFindWords});
            this.uxMenuBar.Location = new System.Drawing.Point(0, 0);
            this.uxMenuBar.Name = "uxMenuBar";
            this.uxMenuBar.Size = new System.Drawing.Size(800, 33);
            this.uxMenuBar.TabIndex = 0;
            this.uxMenuBar.Text = "menuStrip1";
            // 
            // uxNewBoard
            // 
            this.uxNewBoard.Name = "uxNewBoard";
            this.uxNewBoard.Size = new System.Drawing.Size(115, 29);
            this.uxNewBoard.Text = "New Board";
            this.uxNewBoard.Click += new System.EventHandler(this.NewBoardClick);
            // 
            // uxFindWords
            // 
            this.uxFindWords.Name = "uxFindWords";
            this.uxFindWords.Size = new System.Drawing.Size(119, 29);
            this.uxFindWords.Text = "Find Words";
            // 
            // uxBoard
            // 
            this.uxBoard.Location = new System.Drawing.Point(12, 36);
            this.uxBoard.Name = "uxBoard";
            this.uxBoard.Size = new System.Drawing.Size(300, 150);
            this.uxBoard.TabIndex = 1;
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.Title = "Select Word List File";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uxBoard);
            this.Controls.Add(this.uxMenuBar);
            this.MainMenuStrip = this.uxMenuBar;
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Boggle Deluxe";
            this.uxMenuBar.ResumeLayout(false);
            this.uxMenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip uxMenuBar;
        private ToolStripMenuItem uxNewBoard;
        private ToolStripMenuItem uxFindWords;
        private FlowLayoutPanel uxBoard;
        private OpenFileDialog uxOpenDialog;
    }
}
