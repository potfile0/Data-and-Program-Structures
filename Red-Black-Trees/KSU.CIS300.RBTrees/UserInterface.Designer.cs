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
            this.uxTextBox_Name = new System.Windows.Forms.TextBox();
            this.uxButton_LookupName = new System.Windows.Forms.Button();
            this.uxLabel_Rank = new System.Windows.Forms.Label();
            this.uxLabel_Freq = new System.Windows.Forms.Label();
            this.uxButton_LoadNames = new System.Windows.Forms.Button();
            this.uxTextBox_Rank = new System.Windows.Forms.TextBox();
            this.uxTextBox_Freq = new System.Windows.Forms.TextBox();
            this.uxOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxButton_RemoveName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxTextBox_Name
            // 
            this.uxTextBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxTextBox_Name.Location = new System.Drawing.Point(8, 53);
            this.uxTextBox_Name.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.uxTextBox_Name.Name = "uxTextBox_Name";
            this.uxTextBox_Name.Size = new System.Drawing.Size(283, 29);
            this.uxTextBox_Name.TabIndex = 3;
            // 
            // uxButton_LookupName
            // 
            this.uxButton_LookupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButton_LookupName.Location = new System.Drawing.Point(8, 84);
            this.uxButton_LookupName.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.uxButton_LookupName.Name = "uxButton_LookupName";
            this.uxButton_LookupName.Size = new System.Drawing.Size(282, 39);
            this.uxButton_LookupName.TabIndex = 4;
            this.uxButton_LookupName.Text = "Lookup Name";
            this.uxButton_LookupName.UseVisualStyleBackColor = true;
            // 
            // uxLabel_Rank
            // 
            this.uxLabel_Rank.AutoSize = true;
            this.uxLabel_Rank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLabel_Rank.Location = new System.Drawing.Point(44, 127);
            this.uxLabel_Rank.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.uxLabel_Rank.Name = "uxLabel_Rank";
            this.uxLabel_Rank.Size = new System.Drawing.Size(58, 24);
            this.uxLabel_Rank.TabIndex = 5;
            this.uxLabel_Rank.Text = "Rank:";
            // 
            // uxLabel_Freq
            // 
            this.uxLabel_Freq.AutoSize = true;
            this.uxLabel_Freq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLabel_Freq.Location = new System.Drawing.Point(1, 162);
            this.uxLabel_Freq.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.uxLabel_Freq.Name = "uxLabel_Freq";
            this.uxLabel_Freq.Size = new System.Drawing.Size(107, 24);
            this.uxLabel_Freq.TabIndex = 6;
            this.uxLabel_Freq.Text = "Frequency:";
            // 
            // uxButton_LoadNames
            // 
            this.uxButton_LoadNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButton_LoadNames.Location = new System.Drawing.Point(8, 10);
            this.uxButton_LoadNames.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.uxButton_LoadNames.Name = "uxButton_LoadNames";
            this.uxButton_LoadNames.Size = new System.Drawing.Size(281, 41);
            this.uxButton_LoadNames.TabIndex = 2;
            this.uxButton_LoadNames.Text = "Load Names";
            this.uxButton_LoadNames.UseVisualStyleBackColor = true;
            // 
            // uxTextBox_Rank
            // 
            this.uxTextBox_Rank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxTextBox_Rank.Location = new System.Drawing.Point(101, 125);
            this.uxTextBox_Rank.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.uxTextBox_Rank.Name = "uxTextBox_Rank";
            this.uxTextBox_Rank.ReadOnly = true;
            this.uxTextBox_Rank.Size = new System.Drawing.Size(187, 29);
            this.uxTextBox_Rank.TabIndex = 7;
            // 
            // uxTextBox_Freq
            // 
            this.uxTextBox_Freq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxTextBox_Freq.Location = new System.Drawing.Point(101, 162);
            this.uxTextBox_Freq.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.uxTextBox_Freq.Name = "uxTextBox_Freq";
            this.uxTextBox_Freq.ReadOnly = true;
            this.uxTextBox_Freq.Size = new System.Drawing.Size(187, 29);
            this.uxTextBox_Freq.TabIndex = 8;
            // 
            // uxButton_RemoveName
            // 
            this.uxButton_RemoveName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButton_RemoveName.Location = new System.Drawing.Point(8, 193);
            this.uxButton_RemoveName.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.uxButton_RemoveName.Name = "uxButton_RemoveName";
            this.uxButton_RemoveName.Size = new System.Drawing.Size(280, 36);
            this.uxButton_RemoveName.TabIndex = 9;
            this.uxButton_RemoveName.Text = "Remove Name";
            this.uxButton_RemoveName.UseVisualStyleBackColor = true;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 234);
            this.Controls.Add(this.uxButton_RemoveName);
            this.Controls.Add(this.uxTextBox_Freq);
            this.Controls.Add(this.uxTextBox_Rank);
            this.Controls.Add(this.uxLabel_Freq);
            this.Controls.Add(this.uxLabel_Rank);
            this.Controls.Add(this.uxButton_LookupName);
            this.Controls.Add(this.uxTextBox_Name);
            this.Controls.Add(this.uxButton_LoadNames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserInterface";
            this.Text = "RBTrees";
            this.ResumeLayout(false);
            this.PerformLayout();

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

