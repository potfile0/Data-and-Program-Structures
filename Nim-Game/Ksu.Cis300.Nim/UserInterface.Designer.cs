namespace Ksu.Cis300.Nim
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
            this.uxMainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uxStatus = new System.Windows.Forms.TextBox();
            this.uxStart = new System.Windows.Forms.Button();
            this.uxValuesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uxValuesLabel = new System.Windows.Forms.Label();
            this.uxValue1 = new System.Windows.Forms.NumericUpDown();
            this.uxValue2 = new System.Windows.Forms.NumericUpDown();
            this.uxValue3 = new System.Windows.Forms.NumericUpDown();
            this.uxLimitsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uxLimitsLabel = new System.Windows.Forms.Label();
            this.uxLimit1 = new System.Windows.Forms.NumericUpDown();
            this.uxLimit2 = new System.Windows.Forms.NumericUpDown();
            this.uxLimit3 = new System.Windows.Forms.NumericUpDown();
            this.uxRemovePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uxRemoveLabel = new System.Windows.Forms.Label();
            this.uxRemove = new System.Windows.Forms.NumericUpDown();
            this.uxStonesLabel = new System.Windows.Forms.Label();
            this.uxFromPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uxFromLabel = new System.Windows.Forms.Label();
            this.uxRemovePile = new System.Windows.Forms.ComboBox();
            this.uxPlay = new System.Windows.Forms.Button();
            this.uxMainPanel.SuspendLayout();
            this.uxValuesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxValue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxValue3)).BeginInit();
            this.uxLimitsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxLimit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxLimit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxLimit3)).BeginInit();
            this.uxRemovePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxRemove)).BeginInit();
            this.uxFromPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxMainPanel
            // 
            this.uxMainPanel.AutoSize = true;
            this.uxMainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uxMainPanel.Controls.Add(this.uxStatus);
            this.uxMainPanel.Controls.Add(this.uxStart);
            this.uxMainPanel.Controls.Add(this.uxValuesPanel);
            this.uxMainPanel.Controls.Add(this.uxLimitsPanel);
            this.uxMainPanel.Controls.Add(this.uxRemovePanel);
            this.uxMainPanel.Controls.Add(this.uxFromPanel);
            this.uxMainPanel.Controls.Add(this.uxPlay);
            this.uxMainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uxMainPanel.Location = new System.Drawing.Point(17, 20);
            this.uxMainPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxMainPanel.Name = "uxMainPanel";
            this.uxMainPanel.Size = new System.Drawing.Size(346, 420);
            this.uxMainPanel.TabIndex = 0;
            this.uxMainPanel.WrapContents = false;
            // 
            // uxStatus
            // 
            this.uxStatus.Location = new System.Drawing.Point(4, 5);
            this.uxStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxStatus.Name = "uxStatus";
            this.uxStatus.ReadOnly = true;
            this.uxStatus.Size = new System.Drawing.Size(330, 31);
            this.uxStatus.TabIndex = 0;
            // 
            // uxStart
            // 
            this.uxStart.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxStart.Location = new System.Drawing.Point(4, 46);
            this.uxStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxStart.Name = "uxStart";
            this.uxStart.Size = new System.Drawing.Size(336, 55);
            this.uxStart.TabIndex = 1;
            this.uxStart.Text = "Start Game";
            this.uxStart.UseVisualStyleBackColor = true;
            this.uxStart.Click += new System.EventHandler(this.StartClick);
            // 
            // uxValuesPanel
            // 
            this.uxValuesPanel.AutoSize = true;
            this.uxValuesPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uxValuesPanel.Controls.Add(this.uxValuesLabel);
            this.uxValuesPanel.Controls.Add(this.uxValue1);
            this.uxValuesPanel.Controls.Add(this.uxValue2);
            this.uxValuesPanel.Controls.Add(this.uxValue3);
            this.uxValuesPanel.Location = new System.Drawing.Point(4, 111);
            this.uxValuesPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxValuesPanel.Name = "uxValuesPanel";
            this.uxValuesPanel.Size = new System.Drawing.Size(338, 49);
            this.uxValuesPanel.TabIndex = 2;
            this.uxValuesPanel.WrapContents = false;
            // 
            // uxValuesLabel
            // 
            this.uxValuesLabel.AutoSize = true;
            this.uxValuesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxValuesLabel.Location = new System.Drawing.Point(4, 0);
            this.uxValuesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxValuesLabel.Name = "uxValuesLabel";
            this.uxValuesLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.uxValuesLabel.Size = new System.Drawing.Size(87, 42);
            this.uxValuesLabel.TabIndex = 3;
            this.uxValuesLabel.Text = "Values:";
            // 
            // uxValue1
            // 
            this.uxValue1.Enabled = false;
            this.uxValue1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxValue1.Location = new System.Drawing.Point(99, 5);
            this.uxValue1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxValue1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.uxValue1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxValue1.Name = "uxValue1";
            this.uxValue1.Size = new System.Drawing.Size(73, 39);
            this.uxValue1.TabIndex = 3;
            this.uxValue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxValue1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxValue2
            // 
            this.uxValue2.Enabled = false;
            this.uxValue2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxValue2.Location = new System.Drawing.Point(180, 5);
            this.uxValue2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxValue2.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.uxValue2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxValue2.Name = "uxValue2";
            this.uxValue2.Size = new System.Drawing.Size(73, 39);
            this.uxValue2.TabIndex = 4;
            this.uxValue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxValue2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxValue3
            // 
            this.uxValue3.Enabled = false;
            this.uxValue3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxValue3.Location = new System.Drawing.Point(261, 5);
            this.uxValue3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxValue3.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.uxValue3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxValue3.Name = "uxValue3";
            this.uxValue3.Size = new System.Drawing.Size(73, 39);
            this.uxValue3.TabIndex = 5;
            this.uxValue3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxValue3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxLimitsPanel
            // 
            this.uxLimitsPanel.AutoSize = true;
            this.uxLimitsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uxLimitsPanel.Controls.Add(this.uxLimitsLabel);
            this.uxLimitsPanel.Controls.Add(this.uxLimit1);
            this.uxLimitsPanel.Controls.Add(this.uxLimit2);
            this.uxLimitsPanel.Controls.Add(this.uxLimit3);
            this.uxLimitsPanel.Location = new System.Drawing.Point(4, 170);
            this.uxLimitsPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxLimitsPanel.Name = "uxLimitsPanel";
            this.uxLimitsPanel.Size = new System.Drawing.Size(337, 49);
            this.uxLimitsPanel.TabIndex = 3;
            this.uxLimitsPanel.WrapContents = false;
            // 
            // uxLimitsLabel
            // 
            this.uxLimitsLabel.AutoSize = true;
            this.uxLimitsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxLimitsLabel.Location = new System.Drawing.Point(4, 0);
            this.uxLimitsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 9, 0);
            this.uxLimitsLabel.Name = "uxLimitsLabel";
            this.uxLimitsLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.uxLimitsLabel.Size = new System.Drawing.Size(81, 42);
            this.uxLimitsLabel.TabIndex = 4;
            this.uxLimitsLabel.Text = "Limits:";
            // 
            // uxLimit1
            // 
            this.uxLimit1.Enabled = false;
            this.uxLimit1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxLimit1.Location = new System.Drawing.Point(98, 5);
            this.uxLimit1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxLimit1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.uxLimit1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxLimit1.Name = "uxLimit1";
            this.uxLimit1.Size = new System.Drawing.Size(73, 39);
            this.uxLimit1.TabIndex = 6;
            this.uxLimit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxLimit1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxLimit2
            // 
            this.uxLimit2.Enabled = false;
            this.uxLimit2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxLimit2.Location = new System.Drawing.Point(179, 5);
            this.uxLimit2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxLimit2.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.uxLimit2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxLimit2.Name = "uxLimit2";
            this.uxLimit2.Size = new System.Drawing.Size(73, 39);
            this.uxLimit2.TabIndex = 7;
            this.uxLimit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxLimit2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxLimit3
            // 
            this.uxLimit3.Enabled = false;
            this.uxLimit3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxLimit3.Location = new System.Drawing.Point(260, 5);
            this.uxLimit3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxLimit3.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.uxLimit3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxLimit3.Name = "uxLimit3";
            this.uxLimit3.Size = new System.Drawing.Size(73, 39);
            this.uxLimit3.TabIndex = 8;
            this.uxLimit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxLimit3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxRemovePanel
            // 
            this.uxRemovePanel.AutoSize = true;
            this.uxRemovePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uxRemovePanel.Controls.Add(this.uxRemoveLabel);
            this.uxRemovePanel.Controls.Add(this.uxRemove);
            this.uxRemovePanel.Controls.Add(this.uxStonesLabel);
            this.uxRemovePanel.Location = new System.Drawing.Point(4, 241);
            this.uxRemovePanel.Margin = new System.Windows.Forms.Padding(4, 17, 4, 5);
            this.uxRemovePanel.Name = "uxRemovePanel";
            this.uxRemovePanel.Size = new System.Drawing.Size(287, 49);
            this.uxRemovePanel.TabIndex = 4;
            this.uxRemovePanel.WrapContents = false;
            // 
            // uxRemoveLabel
            // 
            this.uxRemoveLabel.AutoSize = true;
            this.uxRemoveLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxRemoveLabel.Location = new System.Drawing.Point(4, 0);
            this.uxRemoveLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxRemoveLabel.Name = "uxRemoveLabel";
            this.uxRemoveLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.uxRemoveLabel.Size = new System.Drawing.Size(105, 42);
            this.uxRemoveLabel.TabIndex = 5;
            this.uxRemoveLabel.Text = "Remove:";
            // 
            // uxRemove
            // 
            this.uxRemove.Enabled = false;
            this.uxRemove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxRemove.Location = new System.Drawing.Point(117, 5);
            this.uxRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxRemove.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxRemove.Name = "uxRemove";
            this.uxRemove.Size = new System.Drawing.Size(73, 39);
            this.uxRemove.TabIndex = 7;
            this.uxRemove.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxRemove.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxStonesLabel
            // 
            this.uxStonesLabel.AutoSize = true;
            this.uxStonesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxStonesLabel.Location = new System.Drawing.Point(198, 0);
            this.uxStonesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxStonesLabel.Name = "uxStonesLabel";
            this.uxStonesLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.uxStonesLabel.Size = new System.Drawing.Size(85, 42);
            this.uxStonesLabel.TabIndex = 8;
            this.uxStonesLabel.Text = "Stones";
            // 
            // uxFromPanel
            // 
            this.uxFromPanel.AutoSize = true;
            this.uxFromPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uxFromPanel.Controls.Add(this.uxFromLabel);
            this.uxFromPanel.Controls.Add(this.uxRemovePile);
            this.uxFromPanel.Location = new System.Drawing.Point(4, 300);
            this.uxFromPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxFromPanel.Name = "uxFromPanel";
            this.uxFromPanel.Size = new System.Drawing.Size(335, 50);
            this.uxFromPanel.TabIndex = 5;
            this.uxFromPanel.WrapContents = false;
            // 
            // uxFromLabel
            // 
            this.uxFromLabel.AutoSize = true;
            this.uxFromLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxFromLabel.Location = new System.Drawing.Point(4, 0);
            this.uxFromLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxFromLabel.Name = "uxFromLabel";
            this.uxFromLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.uxFromLabel.Size = new System.Drawing.Size(74, 42);
            this.uxFromLabel.TabIndex = 6;
            this.uxFromLabel.Text = "From:";
            // 
            // uxRemovePile
            // 
            this.uxRemovePile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxRemovePile.Enabled = false;
            this.uxRemovePile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxRemovePile.FormattingEnabled = true;
            this.uxRemovePile.Location = new System.Drawing.Point(86, 5);
            this.uxRemovePile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxRemovePile.Name = "uxRemovePile";
            this.uxRemovePile.Size = new System.Drawing.Size(245, 40);
            this.uxRemovePile.TabIndex = 6;
            this.uxRemovePile.SelectedIndexChanged += new System.EventHandler(this.RemovePileSelectedIndexChanged);
            // 
            // uxPlay
            // 
            this.uxPlay.Enabled = false;
            this.uxPlay.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxPlay.Location = new System.Drawing.Point(4, 360);
            this.uxPlay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxPlay.Name = "uxPlay";
            this.uxPlay.Size = new System.Drawing.Size(336, 55);
            this.uxPlay.TabIndex = 6;
            this.uxPlay.Text = "Play";
            this.uxPlay.UseVisualStyleBackColor = true;
            this.uxPlay.Click += new System.EventHandler(this.PlayClick);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1143, 750);
            this.Controls.Add(this.uxMainPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Nim";
            this.uxMainPanel.ResumeLayout(false);
            this.uxMainPanel.PerformLayout();
            this.uxValuesPanel.ResumeLayout(false);
            this.uxValuesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxValue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxValue3)).EndInit();
            this.uxLimitsPanel.ResumeLayout(false);
            this.uxLimitsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxLimit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxLimit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxLimit3)).EndInit();
            this.uxRemovePanel.ResumeLayout(false);
            this.uxRemovePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxRemove)).EndInit();
            this.uxFromPanel.ResumeLayout(false);
            this.uxFromPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel uxMainPanel;
        private TextBox uxStatus;
        private Button uxStart;
        private FlowLayoutPanel uxValuesPanel;
        private Label uxValuesLabel;
        private NumericUpDown uxValue1;
        private NumericUpDown uxValue2;
        private NumericUpDown uxValue3;
        private FlowLayoutPanel uxLimitsPanel;
        private Label uxLimitsLabel;
        private NumericUpDown uxLimit1;
        private NumericUpDown uxLimit2;
        private NumericUpDown uxLimit3;
        private FlowLayoutPanel uxRemovePanel;
        private Label uxRemoveLabel;
        private NumericUpDown uxRemove;
        private Label uxStonesLabel;
        private FlowLayoutPanel uxFromPanel;
        private Label uxFromLabel;
        private ComboBox uxRemovePile;
        private Button uxPlay;
    }
}
