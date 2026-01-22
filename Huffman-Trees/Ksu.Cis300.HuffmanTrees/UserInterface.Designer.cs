namespace Ksu.Cis300.HuffmanTrees
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
            this.uxSelectFile = new System.Windows.Forms.Button();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uxSelectFile
            // 
            this.uxSelectFile.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxSelectFile.Location = new System.Drawing.Point(12, 12);
            this.uxSelectFile.Name = "uxSelectFile";
            this.uxSelectFile.Size = new System.Drawing.Size(373, 69);
            this.uxSelectFile.TabIndex = 0;
            this.uxSelectFile.Text = "Select a File";
            this.uxSelectFile.UseVisualStyleBackColor = true;
            this.uxSelectFile.Click += new System.EventHandler(this.SelectFileClick);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uxSelectFile);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Huffman Trees";
            this.ResumeLayout(false);

        }

        #endregion

        private Button uxSelectFile;
        private OpenFileDialog uxOpenDialog;
    }
}
