using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Sudoku
{
    partial class UserInterface
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.uxMenuStrip = new System.Windows.Forms.MenuStrip();
            this.uxFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.uxOpenPuzzleFile = new System.Windows.Forms.ToolStripMenuItem();
            this.uxLoadRandomPuzzle = new System.Windows.Forms.ToolStripMenuItem();
            this.uxPuzzleMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.uxSolve = new System.Windows.Forms.ToolStripMenuItem();
            this.uxCheckSolution = new System.Windows.Forms.ToolStripMenuItem();
            this.uxPuzzleLabel = new System.Windows.Forms.Label();
            this.uxPuzzleNumber = new System.Windows.Forms.NumericUpDown();
            this.uxPuzzleNumber.Minimum = 0;
            this.uxPuzzleLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uxOpenPuzzleDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxPuzzleNumber)).BeginInit();
            this.SuspendLayout();

            this.uxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxFileMenu,
            this.uxPuzzleMenu});
            this.uxMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uxMenuStrip.Name = "uxMenuStrip";
            this.uxMenuStrip.Size = new System.Drawing.Size(400, 24);
            this.uxMenuStrip.TabIndex = 0;
            this.uxMenuStrip.Text = "uxMenuStrip";

            this.uxFileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxOpenPuzzleFile,
            this.uxLoadRandomPuzzle});
            this.uxFileMenu.Name = "uxFileMenu";
            this.uxFileMenu.Size = new System.Drawing.Size(37, 20);
            this.uxFileMenu.Text = "File";

            this.uxOpenPuzzleFile.Name = "uxOpenPuzzleFile";
            this.uxOpenPuzzleFile.Size = new System.Drawing.Size(184, 22);
            this.uxOpenPuzzleFile.Text = "Open Puzzle File";
            this.uxOpenPuzzleFile.Click += new System.EventHandler(this.uxOpenPuzzleFile_Click);

            this.uxLoadRandomPuzzle.Name = "uxLoadRandomPuzzle";
            this.uxLoadRandomPuzzle.Size = new System.Drawing.Size(184, 22);
            this.uxLoadRandomPuzzle.Text = "Load Random Puzzle";
            this.uxLoadRandomPuzzle.Click += new System.EventHandler(this.uxLoadRandomPuzzle_Click);

            this.uxPuzzleMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxSolve,
            this.uxCheckSolution});
            this.uxPuzzleMenu.Name = "uxPuzzleMenu";
            this.uxPuzzleMenu.Size = new System.Drawing.Size(56, 20);
            this.uxPuzzleMenu.Text = "Puzzle";

            this.uxSolve.Name = "uxSolve";
            this.uxSolve.Size = new System.Drawing.Size(155, 22);
            this.uxSolve.Text = "Solve Puzzle";
            this.uxSolve.Click += new System.EventHandler(this.uxSolve_Click);

            this.uxCheckSolution.Enabled = false;
            this.uxCheckSolution.Name = "uxCheckSolution";
            this.uxCheckSolution.Size = new System.Drawing.Size(155, 22);
            this.uxCheckSolution.Text = "Check Solution";
            this.uxCheckSolution.Click += new System.EventHandler(this.uxCheckSolution_Click);

            this.uxPuzzleLabel.AutoSize = true;
            this.uxPuzzleLabel.Location = new System.Drawing.Point(12, 32);
            this.uxPuzzleLabel.Name = "uxPuzzleLabel";
            this.uxPuzzleLabel.Size = new System.Drawing.Size(43, 13);
            this.uxPuzzleLabel.TabIndex = 1;
            this.uxPuzzleLabel.Text = "Puzzle:";

            this.uxPuzzleNumber.Location = new System.Drawing.Point(61, 30);
            this.uxPuzzleNumber.Name = "uxPuzzleNumber";
            this.uxPuzzleNumber.Size = new System.Drawing.Size(70, 20);
            this.uxPuzzleNumber.TabIndex = 2;
            this.uxPuzzleNumber.ValueChanged += new System.EventHandler(this.uxPuzzleNumber_ValueChanged);

            this.uxPuzzleLayoutPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.uxPuzzleLayoutPanel.Location = new System.Drawing.Point(12, 56);
            this.uxPuzzleLayoutPanel.Name = "uxPuzzleLayoutPanel";
            this.uxPuzzleLayoutPanel.Size = new System.Drawing.Size(380, 380);
            this.uxPuzzleLayoutPanel.TabIndex = 3;

            this.uxOpenPuzzleDialog.FileName = "";
            this.uxOpenPuzzleDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(404, 448);
            this.Controls.Add(this.uxPuzzleLayoutPanel);
            this.Controls.Add(this.uxPuzzleNumber);
            this.Controls.Add(this.uxPuzzleLabel);
            this.Controls.Add(this.uxMenuStrip);
            this.MainMenuStrip = this.uxMenuStrip;
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Sudoku Solver";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.uxMenuStrip.ResumeLayout(false);
            this.uxMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxPuzzleNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip uxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem uxFileMenu;
        private System.Windows.Forms.ToolStripMenuItem uxOpenPuzzleFile;
        private System.Windows.Forms.ToolStripMenuItem uxLoadRandomPuzzle;
        private System.Windows.Forms.ToolStripMenuItem uxPuzzleMenu;
        private System.Windows.Forms.ToolStripMenuItem uxSolve;
        private System.Windows.Forms.ToolStripMenuItem uxCheckSolution;
        private System.Windows.Forms.Label uxPuzzleLabel;
        private System.Windows.Forms.NumericUpDown uxPuzzleNumber;
        private System.Windows.Forms.FlowLayoutPanel uxPuzzleLayoutPanel;
        private System.Windows.Forms.OpenFileDialog uxOpenPuzzleDialog;
    }
}
