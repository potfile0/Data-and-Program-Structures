namespace Ksu.Cis300.Boggle
{
    partial class WordList
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
            this.uxWords = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // uxWords
            // 
            this.uxWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxWords.FormattingEnabled = true;
            this.uxWords.ItemHeight = 25;
            this.uxWords.Location = new System.Drawing.Point(0, 0);
            this.uxWords.Name = "uxWords";
            this.uxWords.Size = new System.Drawing.Size(377, 559);
            this.uxWords.TabIndex = 0;
            // 
            // WordList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 559);
            this.Controls.Add(this.uxWords);
            this.Name = "WordList";
            this.Text = "Word List";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox uxWords;
    }
}
