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
            uxMenuBar = new MenuStrip();
            uxNew = new ToolStripMenuItem();
            uxMaze = new Ksu.Cis300.MazeLibrary.Maze();
            uxMenuBar.SuspendLayout();
            SuspendLayout();
            // 
            // uxMenuBar
            // 
            uxMenuBar.ImageScalingSize = new Size(24, 24);
            uxMenuBar.Items.AddRange(new ToolStripItem[] { uxNew });
            uxMenuBar.Location = new Point(0, 0);
            uxMenuBar.Name = "uxMenuBar";
            uxMenuBar.Padding = new Padding(4, 1, 0, 1);
            uxMenuBar.Size = new Size(560, 24);
            uxMenuBar.TabIndex = 0;
            uxMenuBar.Text = "menuStrip1";
            // 
            // uxNew
            // 
            uxNew.Name = "uxNew";
            uxNew.Size = new Size(74, 22);
            uxNew.Text = "New Maze";
            uxNew.Click += NewClick;
            // 
            // uxMaze
            // 
            uxMaze.Dock = DockStyle.Fill;
            uxMaze.Location = new Point(0, 24);
            uxMaze.Margin = new Padding(1, 1, 1, 1);
            uxMaze.Name = "uxMaze";
            uxMaze.PathColor = SystemColors.Highlight;
            uxMaze.Size = new Size(560, 246);
            uxMaze.TabIndex = 1;
            uxMaze.MouseClick += uxMaze_MouseClick;
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(uxMaze);
            Controls.Add(uxMenuBar);
            MainMenuStrip = uxMenuBar;
            Margin = new Padding(2, 2, 2, 2);
            Name = "UserInterface";
            Text = "Maze Solver";
            uxMenuBar.ResumeLayout(false);
            uxMenuBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MenuStrip uxMenuBar;
        private ToolStripMenuItem uxNew;
        private MazeLibrary.Maze uxMaze;
    }
}
