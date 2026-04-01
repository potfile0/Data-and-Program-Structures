namespace KSU.CIS300.RBTrees
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
            uxTextBox_Name = new System.Windows.Forms.TextBox();
            uxButton_LookupName = new System.Windows.Forms.Button();
            uxLabel_Rank = new System.Windows.Forms.Label();
            uxLabel_Freq = new System.Windows.Forms.Label();
            uxButton_LoadNames = new System.Windows.Forms.Button();
            uxTextBox_Rank = new System.Windows.Forms.TextBox();
            uxTextBox_Freq = new System.Windows.Forms.TextBox();
            uxOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            uxButton_RemoveName = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // uxTextBox_Name
            // 
            uxTextBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            uxTextBox_Name.Location = new System.Drawing.Point(9, 61);
            uxTextBox_Name.Margin = new System.Windows.Forms.Padding(1);
            uxTextBox_Name.Name = "uxTextBox_Name";
            uxTextBox_Name.Size = new System.Drawing.Size(330, 29);
            uxTextBox_Name.TabIndex = 3;
            // 
            // uxButton_LookupName
            // 
            uxButton_LookupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            uxButton_LookupName.Location = new System.Drawing.Point(9, 97);
            uxButton_LookupName.Margin = new System.Windows.Forms.Padding(1);
            uxButton_LookupName.Name = "uxButton_LookupName";
            uxButton_LookupName.Size = new System.Drawing.Size(329, 45);
            uxButton_LookupName.TabIndex = 4;
            uxButton_LookupName.Text = "Lookup Name";
            uxButton_LookupName.UseVisualStyleBackColor = true;
            uxButton_LookupName.Click += LookupName_Click;
            // 
            // uxLabel_Rank
            // 
            uxLabel_Rank.AutoSize = true;
            uxLabel_Rank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            uxLabel_Rank.Location = new System.Drawing.Point(51, 147);
            uxLabel_Rank.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            uxLabel_Rank.Name = "uxLabel_Rank";
            uxLabel_Rank.Size = new System.Drawing.Size(58, 24);
            uxLabel_Rank.TabIndex = 5;
            uxLabel_Rank.Text = "Rank:";
            // 
            // uxLabel_Freq
            // 
            uxLabel_Freq.AutoSize = true;
            uxLabel_Freq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            uxLabel_Freq.Location = new System.Drawing.Point(1, 187);
            uxLabel_Freq.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            uxLabel_Freq.Name = "uxLabel_Freq";
            uxLabel_Freq.Size = new System.Drawing.Size(107, 24);
            uxLabel_Freq.TabIndex = 6;
            uxLabel_Freq.Text = "Frequency:";
            // 
            // uxButton_LoadNames
            // 
            uxButton_LoadNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            uxButton_LoadNames.Location = new System.Drawing.Point(9, 12);
            uxButton_LoadNames.Margin = new System.Windows.Forms.Padding(1);
            uxButton_LoadNames.Name = "uxButton_LoadNames";
            uxButton_LoadNames.Size = new System.Drawing.Size(328, 47);
            uxButton_LoadNames.TabIndex = 2;
            uxButton_LoadNames.Text = "Load Names";
            uxButton_LoadNames.UseVisualStyleBackColor = true;
            uxButton_LoadNames.Click += LoadNames_Click;
            // 
            // uxTextBox_Rank
            // 
            uxTextBox_Rank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            uxTextBox_Rank.Location = new System.Drawing.Point(118, 144);
            uxTextBox_Rank.Margin = new System.Windows.Forms.Padding(1);
            uxTextBox_Rank.Name = "uxTextBox_Rank";
            uxTextBox_Rank.ReadOnly = true;
            uxTextBox_Rank.Size = new System.Drawing.Size(218, 29);
            uxTextBox_Rank.TabIndex = 7;
            // 
            // uxTextBox_Freq
            // 
            uxTextBox_Freq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            uxTextBox_Freq.Location = new System.Drawing.Point(118, 187);
            uxTextBox_Freq.Margin = new System.Windows.Forms.Padding(1);
            uxTextBox_Freq.Name = "uxTextBox_Freq";
            uxTextBox_Freq.ReadOnly = true;
            uxTextBox_Freq.Size = new System.Drawing.Size(218, 29);
            uxTextBox_Freq.TabIndex = 8;
            // 
            // uxButton_RemoveName
            // 
            uxButton_RemoveName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            uxButton_RemoveName.Location = new System.Drawing.Point(9, 223);
            uxButton_RemoveName.Margin = new System.Windows.Forms.Padding(1);
            uxButton_RemoveName.Name = "uxButton_RemoveName";
            uxButton_RemoveName.Size = new System.Drawing.Size(327, 42);
            uxButton_RemoveName.TabIndex = 9;
            uxButton_RemoveName.Text = "Remove Name";
            uxButton_RemoveName.UseVisualStyleBackColor = true;
            uxButton_RemoveName.Click += RemoveName_Click;
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(348, 270);
            Controls.Add(uxButton_RemoveName);
            Controls.Add(uxTextBox_Freq);
            Controls.Add(uxTextBox_Rank);
            Controls.Add(uxLabel_Freq);
            Controls.Add(uxLabel_Rank);
            Controls.Add(uxButton_LookupName);
            Controls.Add(uxTextBox_Name);
            Controls.Add(uxButton_LoadNames);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UserInterface";
            Text = "RBTrees";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox uxTextBox_Name;
        private System.Windows.Forms.Button uxButton_LookupName;
        private System.Windows.Forms.Label uxLabel_Rank;
        private System.Windows.Forms.Label uxLabel_Freq;
        private System.Windows.Forms.Button uxButton_LoadNames;
        private System.Windows.Forms.TextBox uxTextBox_Rank;
        private System.Windows.Forms.TextBox uxTextBox_Freq;
        private System.Windows.Forms.OpenFileDialog uxOpenFileDialog;
        private System.Windows.Forms.Button uxButton_RemoveName;
    }
}

