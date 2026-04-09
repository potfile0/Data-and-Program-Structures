// Author: Josh Weese
namespace KSU.CIS300.Wordle
{
    partial class WordleGUI
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
            uxMain_MenuStrip = new MenuStrip();
            uxFile_ToolStripMenuItem = new ToolStripMenuItem();
            uxLoadWords_ToolStripMenuItem = new ToolStripMenuItem();
            uxNewGame_ToolStripMenuItem = new ToolStripMenuItem();
            uxExit_ToolStripMenuItem = new ToolStripMenuItem();
            uxGuess_TextBox = new TextBox();
            uxSubmit_Button = new Button();
            uxHint_Button = new Button();
            uxGuesses_Panel = new Panel();
            uxStatus_Label = new Label();
            uxRemaining_Label = new Label();
            uxGame_Panel = new Panel();
            uxWordList_OpenFileDialog = new OpenFileDialog();
            uxMain_MenuStrip.SuspendLayout();
            uxGame_Panel.SuspendLayout();
            SuspendLayout();
            // 
            // uxMain_MenuStrip
            // 
            uxMain_MenuStrip.ImageScalingSize = new Size(32, 32);
            uxMain_MenuStrip.Items.AddRange(new ToolStripItem[] { uxFile_ToolStripMenuItem });
            uxMain_MenuStrip.Location = new Point(0, 0);
            uxMain_MenuStrip.Name = "uxMain_MenuStrip";
            uxMain_MenuStrip.Size = new Size(414, 24);
            uxMain_MenuStrip.TabIndex = 0;
            uxMain_MenuStrip.Text = "menuStrip1";
            // 
            // uxFile_ToolStripMenuItem
            // 
            uxFile_ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uxLoadWords_ToolStripMenuItem, uxNewGame_ToolStripMenuItem, uxExit_ToolStripMenuItem });
            uxFile_ToolStripMenuItem.Name = "uxFile_ToolStripMenuItem";
            uxFile_ToolStripMenuItem.Size = new Size(37, 20);
            uxFile_ToolStripMenuItem.Text = "File";
            // 
            // uxLoadWords_ToolStripMenuItem
            // 
            uxLoadWords_ToolStripMenuItem.Name = "uxLoadWords_ToolStripMenuItem";
            uxLoadWords_ToolStripMenuItem.Size = new Size(180, 22);
            uxLoadWords_ToolStripMenuItem.Text = "Load Word List...";
            uxLoadWords_ToolStripMenuItem.Click += LoadWordsMenuItem_Click;
            // 
            // uxNewGame_ToolStripMenuItem
            // 
            uxNewGame_ToolStripMenuItem.Name = "uxNewGame_ToolStripMenuItem";
            uxNewGame_ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            uxNewGame_ToolStripMenuItem.Size = new Size(180, 22);
            uxNewGame_ToolStripMenuItem.Text = "New Game";
            uxNewGame_ToolStripMenuItem.Click += NewGameMenuItem_Click;
            // 
            // uxExit_ToolStripMenuItem
            // 
            uxExit_ToolStripMenuItem.Name = "uxExit_ToolStripMenuItem";
            uxExit_ToolStripMenuItem.Size = new Size(180, 22);
            uxExit_ToolStripMenuItem.Text = "Exit";
            uxExit_ToolStripMenuItem.Click += ExitMenuItem_Click;
            // 
            // uxGuess_TextBox
            // 
            uxGuess_TextBox.Font = new Font("Consolas", 14F, FontStyle.Bold);
            uxGuess_TextBox.Location = new Point(20, 20);
            uxGuess_TextBox.MaxLength = 5;
            uxGuess_TextBox.Name = "uxGuess_TextBox";
            uxGuess_TextBox.Size = new Size(150, 29);
            uxGuess_TextBox.TabIndex = 1;
            uxGuess_TextBox.TextAlign = HorizontalAlignment.Center;
            uxGuess_TextBox.KeyPress += GuessTextBox_KeyPress;
            // 
            // uxSubmit_Button
            // 
            uxSubmit_Button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            uxSubmit_Button.Location = new Point(180, 20);
            uxSubmit_Button.Name = "uxSubmit_Button";
            uxSubmit_Button.Size = new Size(80, 29);
            uxSubmit_Button.TabIndex = 2;
            uxSubmit_Button.Text = "Submit";
            uxSubmit_Button.UseVisualStyleBackColor = true;
            uxSubmit_Button.Click += SubmitButton_Click;
            // 
            // uxHint_Button
            // 
            uxHint_Button.Font = new Font("Segoe UI", 10F);
            uxHint_Button.Location = new Point(270, 20);
            uxHint_Button.Name = "uxHint_Button";
            uxHint_Button.Size = new Size(80, 29);
            uxHint_Button.TabIndex = 3;
            uxHint_Button.Text = "Hint";
            uxHint_Button.UseVisualStyleBackColor = true;
            uxHint_Button.Click += HintButton_Click;
            // 
            // uxGuesses_Panel
            // 
            uxGuesses_Panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uxGuesses_Panel.AutoScroll = true;
            uxGuesses_Panel.BorderStyle = BorderStyle.FixedSingle;
            uxGuesses_Panel.Location = new Point(20, 60);
            uxGuesses_Panel.Name = "uxGuesses_Panel";
            uxGuesses_Panel.Size = new Size(369, 350);
            uxGuesses_Panel.TabIndex = 4;
            // 
            // uxStatus_Label
            // 
            uxStatus_Label.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            uxStatus_Label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            uxStatus_Label.Location = new Point(20, 417);
            uxStatus_Label.Name = "uxStatus_Label";
            uxStatus_Label.Size = new Size(372, 25);
            uxStatus_Label.TabIndex = 5;
            uxStatus_Label.Text = "Load a word list to start playing!";
            uxStatus_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uxRemaining_Label
            // 
            uxRemaining_Label.Font = new Font("Segoe UI", 9F);
            uxRemaining_Label.Location = new Point(20, 442);
            uxRemaining_Label.Name = "uxRemaining_Label";
            uxRemaining_Label.Size = new Size(368, 20);
            uxRemaining_Label.TabIndex = 6;
            uxRemaining_Label.Text = "Remaining possibilities: 0";
            uxRemaining_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uxGame_Panel
            // 
            uxGame_Panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uxGame_Panel.Controls.Add(uxGuess_TextBox);
            uxGame_Panel.Controls.Add(uxRemaining_Label);
            uxGame_Panel.Controls.Add(uxSubmit_Button);
            uxGame_Panel.Controls.Add(uxStatus_Label);
            uxGame_Panel.Controls.Add(uxHint_Button);
            uxGame_Panel.Controls.Add(uxGuesses_Panel);
            uxGame_Panel.Location = new Point(0, 27);
            uxGame_Panel.Name = "uxGame_Panel";
            uxGame_Panel.Size = new Size(392, 474);
            uxGame_Panel.TabIndex = 7;
            // 
            // uxWordList_OpenFileDialog
            // 
            uxWordList_OpenFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            uxWordList_OpenFileDialog.Title = "Select Word List File";
            // 
            // WordleGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 501);
            Controls.Add(uxMain_MenuStrip);
            Controls.Add(uxGame_Panel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = uxMain_MenuStrip;
            MaximizeBox = false;
            Name = "WordleGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Wordle Solver";
            uxMain_MenuStrip.ResumeLayout(false);
            uxMain_MenuStrip.PerformLayout();
            uxGame_Panel.ResumeLayout(false);
            uxGame_Panel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip uxMain_MenuStrip;
        private ToolStripMenuItem uxFile_ToolStripMenuItem;
        private ToolStripMenuItem uxLoadWords_ToolStripMenuItem;
        private ToolStripMenuItem uxNewGame_ToolStripMenuItem;
        private ToolStripMenuItem uxExit_ToolStripMenuItem;
        private TextBox uxGuess_TextBox;
        private Button uxSubmit_Button;
        private Button uxHint_Button;
        private Panel uxGuesses_Panel;
        private Label uxStatus_Label;
        private Label uxRemaining_Label;
        private Panel uxGame_Panel;
        private OpenFileDialog uxWordList_OpenFileDialog;
    }
}
