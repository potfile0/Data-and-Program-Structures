namespace Ksu.Cis300.MazeSolver
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
            this.uxNew = new System.Windows.Forms.ToolStripMenuItem();
            this.uxMaze = new Ksu.Cis300.MazeLibrary.Maze();
            this.uxMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxMenuBar
            // 
            this.uxMenuBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxNew});
            this.uxMenuBar.Location = new System.Drawing.Point(0, 0);
            this.uxMenuBar.Name = "uxMenuBar";
            this.uxMenuBar.Size = new System.Drawing.Size(800, 33);
            this.uxMenuBar.TabIndex = 0;
            this.uxMenuBar.Text = "menuStrip1";
            // 
            // uxNew
            // 
            this.uxNew.Name = "uxNew";
            this.uxNew.Size = new System.Drawing.Size(110, 29);
            this.uxNew.Text = "New Maze";
            this.uxNew.Click += new System.EventHandler(this.NewClick);
            // 
            // uxMaze
            // 
            this.uxMaze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxMaze.Location = new System.Drawing.Point(0, 33);
            this.uxMaze.Name = "uxMaze";
            this.uxMaze.PathColor = System.Drawing.SystemColors.Highlight;
            this.uxMaze.Size = new System.Drawing.Size(800, 417);
            this.uxMaze.TabIndex = 1;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uxMaze);
            this.Controls.Add(this.uxMenuBar);
            this.MainMenuStrip = this.uxMenuBar;
            this.Name = "UserInterface";
            this.Text = "Maze Solver";
            this.uxMenuBar.ResumeLayout(false);
            this.uxMenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip uxMenuBar;
        private ToolStripMenuItem uxNew;
        private MazeLibrary.Maze uxMaze;
    }
}
