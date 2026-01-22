namespace Ksu.Cis300.Prefixes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
            uxMenuBar = new ToolStrip();
            uxOpen = new ToolStripButton();
            uxPrefixLabel = new ToolStripLabel();
            uxPrefix = new ToolStripTextBox();
            uxLookUp = new ToolStripButton();
            uxCompletions = new ListBox();
            uxOpenDialog = new OpenFileDialog();
            uxMenuBar.SuspendLayout();
            SuspendLayout();
            // 
            // uxMenuBar
            // 
            uxMenuBar.ImageScalingSize = new Size(24, 24);
            uxMenuBar.Items.AddRange(new ToolStripItem[] { uxOpen, uxPrefixLabel, uxPrefix, uxLookUp });
            uxMenuBar.Location = new Point(0, 0);
            uxMenuBar.Name = "uxMenuBar";
            uxMenuBar.Padding = new Padding(0, 0, 3, 0);
            uxMenuBar.Size = new Size(490, 34);
            uxMenuBar.TabIndex = 0;
            uxMenuBar.Text = "toolStrip1";
            // 
            // uxOpen
            // 
            uxOpen.DisplayStyle = ToolStripItemDisplayStyle.Text;
            uxOpen.Image = (Image)resources.GetObject("uxOpen.Image");
            uxOpen.ImageTransparentColor = Color.Magenta;
            uxOpen.Name = "uxOpen";
            uxOpen.Size = new Size(140, 29);
            uxOpen.Text = "Open Word List";
            uxOpen.Click += OpenClick;
            // 
            // uxPrefixLabel
            // 
            uxPrefixLabel.Name = "uxPrefixLabel";
            uxPrefixLabel.Size = new Size(59, 29);
            uxPrefixLabel.Text = "Prefix:";
            // 
            // uxPrefix
            // 
            uxPrefix.Name = "uxPrefix";
            uxPrefix.Size = new Size(100, 34);
            // 
            // uxLookUp
            // 
            uxLookUp.DisplayStyle = ToolStripItemDisplayStyle.Text;
            uxLookUp.Image = (Image)resources.GetObject("uxLookUp.Image");
            uxLookUp.ImageTransparentColor = Color.Magenta;
            uxLookUp.Name = "uxLookUp";
            uxLookUp.Size = new Size(83, 29);
            uxLookUp.Text = "Look Up";
            uxLookUp.Click += LookUpClick;
            // 
            // uxCompletions
            // 
            uxCompletions.Dock = DockStyle.Fill;
            uxCompletions.FormattingEnabled = true;
            uxCompletions.ItemHeight = 25;
            uxCompletions.Location = new Point(0, 34);
            uxCompletions.Margin = new Padding(4, 5, 4, 5);
            uxCompletions.Name = "uxCompletions";
            uxCompletions.Size = new Size(490, 716);
            uxCompletions.TabIndex = 1;
            // 
            // uxOpenDialog
            // 
            uxOpenDialog.Filter = "Text Files|*.txt";
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 750);
            Controls.Add(uxCompletions);
            Controls.Add(uxMenuBar);
            Margin = new Padding(4, 5, 4, 5);
            Name = "UserInterface";
            Text = "Prefix Lookup";
            uxMenuBar.ResumeLayout(false);
            uxMenuBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip uxMenuBar;
        private ToolStripButton uxOpen;
        private ToolStripLabel uxPrefixLabel;
        private ToolStripTextBox uxPrefix;
        private ToolStripButton uxLookUp;
        private ListBox uxCompletions;
        private OpenFileDialog uxOpenDialog;
    }
}
