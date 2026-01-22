namespace Ksu.Cis300.CapitalGainCalculator
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
            this.uxNumberLabel = new System.Windows.Forms.Label();
            this.uxNumber = new System.Windows.Forms.NumericUpDown();
            this.uxCostLabel = new System.Windows.Forms.Label();
            this.uxCost = new System.Windows.Forms.NumericUpDown();
            this.uxBuy = new System.Windows.Forms.Button();
            this.uxSell = new System.Windows.Forms.Button();
            this.uxOwnedLabel = new System.Windows.Forms.Label();
            this.uxOwned = new System.Windows.Forms.TextBox();
            this.uxGainLabel = new System.Windows.Forms.Label();
            this.uxGain = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxCost)).BeginInit();
            this.SuspendLayout();
            // 
            // uxNumberLabel
            // 
            this.uxNumberLabel.AutoSize = true;
            this.uxNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxNumberLabel.Location = new System.Drawing.Point(29, 38);
            this.uxNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxNumberLabel.Name = "uxNumberLabel";
            this.uxNumberLabel.Size = new System.Drawing.Size(437, 33);
            this.uxNumberLabel.TabIndex = 0;
            this.uxNumberLabel.Text = "Number of shares in transaction:";
            // 
            // uxNumber
            // 
            this.uxNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxNumber.Location = new System.Drawing.Point(470, 35);
            this.uxNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxNumber.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.uxNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxNumber.Name = "uxNumber";
            this.uxNumber.Size = new System.Drawing.Size(109, 40);
            this.uxNumber.TabIndex = 1;
            this.uxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxCostLabel
            // 
            this.uxCostLabel.AutoSize = true;
            this.uxCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxCostLabel.Location = new System.Drawing.Point(29, 97);
            this.uxCostLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxCostLabel.Name = "uxCostLabel";
            this.uxCostLabel.Size = new System.Drawing.Size(267, 33);
            this.uxCostLabel.TabIndex = 2;
            this.uxCostLabel.Text = "Cost of each share:";
            // 
            // uxCost
            // 
            this.uxCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxCost.DecimalPlaces = 2;
            this.uxCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxCost.Location = new System.Drawing.Point(314, 93);
            this.uxCost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxCost.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uxCost.Name = "uxCost";
            this.uxCost.Size = new System.Drawing.Size(264, 40);
            this.uxCost.TabIndex = 3;
            this.uxCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxBuy
            // 
            this.uxBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxBuy.Location = new System.Drawing.Point(29, 160);
            this.uxBuy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxBuy.Name = "uxBuy";
            this.uxBuy.Size = new System.Drawing.Size(251, 70);
            this.uxBuy.TabIndex = 4;
            this.uxBuy.Text = "Buy";
            this.uxBuy.UseVisualStyleBackColor = true;
            // 
            // uxSell
            // 
            this.uxSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxSell.Location = new System.Drawing.Point(327, 160);
            this.uxSell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxSell.Name = "uxSell";
            this.uxSell.Size = new System.Drawing.Size(251, 70);
            this.uxSell.TabIndex = 5;
            this.uxSell.Text = "Sell";
            this.uxSell.UseVisualStyleBackColor = true;
            // 
            // uxOwnedLabel
            // 
            this.uxOwnedLabel.AutoSize = true;
            this.uxOwnedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxOwnedLabel.Location = new System.Drawing.Point(29, 260);
            this.uxOwnedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxOwnedLabel.Name = "uxOwnedLabel";
            this.uxOwnedLabel.Size = new System.Drawing.Size(348, 33);
            this.uxOwnedLabel.TabIndex = 6;
            this.uxOwnedLabel.Text = "Number of shares owned:";
            // 
            // uxOwned
            // 
            this.uxOwned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxOwned.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxOwned.Location = new System.Drawing.Point(384, 258);
            this.uxOwned.Name = "uxOwned";
            this.uxOwned.ReadOnly = true;
            this.uxOwned.Size = new System.Drawing.Size(194, 39);
            this.uxOwned.TabIndex = 7;
            this.uxOwned.Text = "0";
            this.uxOwned.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxGainLabel
            // 
            this.uxGainLabel.AutoSize = true;
            this.uxGainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxGainLabel.Location = new System.Drawing.Point(29, 312);
            this.uxGainLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxGainLabel.Name = "uxGainLabel";
            this.uxGainLabel.Size = new System.Drawing.Size(224, 33);
            this.uxGainLabel.TabIndex = 8;
            this.uxGainLabel.Text = "Net capital gain:";
            // 
            // uxGain
            // 
            this.uxGain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxGain.Location = new System.Drawing.Point(260, 312);
            this.uxGain.Name = "uxGain";
            this.uxGain.ReadOnly = true;
            this.uxGain.Size = new System.Drawing.Size(318, 39);
            this.uxGain.TabIndex = 9;
            this.uxGain.Text = "0.00";
            this.uxGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 373);
            this.Controls.Add(this.uxGain);
            this.Controls.Add(this.uxGainLabel);
            this.Controls.Add(this.uxOwned);
            this.Controls.Add(this.uxOwnedLabel);
            this.Controls.Add(this.uxSell);
            this.Controls.Add(this.uxBuy);
            this.Controls.Add(this.uxCost);
            this.Controls.Add(this.uxCostLabel);
            this.Controls.Add(this.uxNumber);
            this.Controls.Add(this.uxNumberLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserInterface";
            this.Text = "Capital Gain Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.uxNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label uxNumberLabel;
        private NumericUpDown uxNumber;
        private Label uxCostLabel;
        private NumericUpDown uxCost;
        private Button uxBuy;
        private Button uxSell;
        private Label uxOwnedLabel;
        private TextBox uxOwned;
        private Label uxGainLabel;
        private TextBox uxGain;
    }
}
