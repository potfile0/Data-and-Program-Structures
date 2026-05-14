
namespace KSU.CIS300.Checkers
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uxFlowLayoutPanel_board = new System.Windows.Forms.FlowLayoutPanel();
            uxMenuStrip = new System.Windows.Forms.MenuStrip();
            uxfileToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            uxNewGame = new System.Windows.Forms.ToolStripMenuItem();
            uxStatusStrip = new System.Windows.Forms.StatusStrip();
            uxToolStripStatusLabel_Turn = new System.Windows.Forms.ToolStripStatusLabel();
            uxMenuStrip.SuspendLayout();
            uxStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // uxFlowLayoutPanel_board
            // 
            uxFlowLayoutPanel_board.Location = new System.Drawing.Point(8, 30);
            uxFlowLayoutPanel_board.Margin = new System.Windows.Forms.Padding(2);
            uxFlowLayoutPanel_board.Name = "uxFlowLayoutPanel_board";
            uxFlowLayoutPanel_board.Size = new System.Drawing.Size(808, 368);
            uxFlowLayoutPanel_board.TabIndex = 0;
            // 
            // uxMenuStrip
            // 
            uxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { uxfileToolStripMenu });
            uxMenuStrip.Location = new System.Drawing.Point(0, 0);
            uxMenuStrip.Name = "uxMenuStrip";
            uxMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            uxMenuStrip.Size = new System.Drawing.Size(827, 24);
            uxMenuStrip.TabIndex = 1;
            uxMenuStrip.Text = "menuStrip1";
            // 
            // uxfileToolStripMenu
            // 
            uxfileToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { uxNewGame });
            uxfileToolStripMenu.Name = "uxfileToolStripMenu";
            uxfileToolStripMenu.Size = new System.Drawing.Size(37, 20);
            uxfileToolStripMenu.Text = "File";
            // 
            // uxNewGame
            // 
            uxNewGame.Name = "uxNewGame";
            uxNewGame.Size = new System.Drawing.Size(180, 22);
            uxNewGame.Text = "New Game";
            uxNewGame.Click += uxNewGame_Click;
            // 
            // uxStatusStrip
            // 
            uxStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { uxToolStripStatusLabel_Turn });
            uxStatusStrip.Location = new System.Drawing.Point(0, 410);
            uxStatusStrip.Name = "uxStatusStrip";
            uxStatusStrip.Padding = new System.Windows.Forms.Padding(16, 0, 1, 0);
            uxStatusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            uxStatusStrip.Size = new System.Drawing.Size(827, 22);
            uxStatusStrip.TabIndex = 2;
            uxStatusStrip.Text = "statusStrip1";
            // 
            // uxToolStripStatusLabel_Turn
            // 
            uxToolStripStatusLabel_Turn.Name = "uxToolStripStatusLabel_Turn";
            uxToolStripStatusLabel_Turn.Size = new System.Drawing.Size(31, 17);
            uxToolStripStatusLabel_Turn.Text = "Turn";
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(827, 432);
            Controls.Add(uxStatusStrip);
            Controls.Add(uxFlowLayoutPanel_board);
            Controls.Add(uxMenuStrip);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            MainMenuStrip = uxMenuStrip;
            Margin = new System.Windows.Forms.Padding(1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserInterface";
            Text = "Checkers";
            uxMenuStrip.ResumeLayout(false);
            uxMenuStrip.PerformLayout();
            uxStatusStrip.ResumeLayout(false);
            uxStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel uxFlowLayoutPanel_board;
        private System.Windows.Forms.MenuStrip uxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem uxfileToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem uxNewGame;
        private System.Windows.Forms.StatusStrip uxStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel uxToolStripStatusLabel_Turn;
    }
}

