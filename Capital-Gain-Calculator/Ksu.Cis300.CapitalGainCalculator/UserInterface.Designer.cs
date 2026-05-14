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
            uxNumberLabel = new Label();
            uxNumber = new NumericUpDown();
            uxCostLabel = new Label();
            uxCost = new NumericUpDown();
            uxBuy = new Button();
            uxSell = new Button();
            uxOwnedLabel = new Label();
            uxOwned = new TextBox();
            uxGainLabel = new Label();
            uxGain = new TextBox();
            ((System.ComponentModel.ISupportInitialize)uxNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uxCost).BeginInit();
            SuspendLayout();
            // 
            // uxNumberLabel
            // 
            uxNumberLabel.AutoSize = true;
            uxNumberLabel.Font = new Font("Microsoft Sans Serif", 14.25F);
            uxNumberLabel.Location = new Point(20, 23);
            uxNumberLabel.Name = "uxNumberLabel";
            uxNumberLabel.Size = new Size(280, 24);
            uxNumberLabel.TabIndex = 0;
            uxNumberLabel.Text = "Number of shares in transaction:";
            // 
            // uxNumber
            // 
            uxNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            uxNumber.Font = new Font("Microsoft Sans Serif", 14.25F);
            uxNumber.Location = new Point(329, 21);
            uxNumber.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            uxNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            uxNumber.Name = "uxNumber";
            uxNumber.Size = new Size(76, 29);
            uxNumber.TabIndex = 1;
            uxNumber.TextAlign = HorizontalAlignment.Right;
            uxNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // uxCostLabel
            // 
            uxCostLabel.AutoSize = true;
            uxCostLabel.Font = new Font("Microsoft Sans Serif", 14.25F);
            uxCostLabel.Location = new Point(20, 58);
            uxCostLabel.Name = "uxCostLabel";
            uxCostLabel.Size = new Size(171, 24);
            uxCostLabel.TabIndex = 2;
            uxCostLabel.Text = "Cost of each share:";
            // 
            // uxCost
            // 
            uxCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            uxCost.DecimalPlaces = 2;
            uxCost.Font = new Font("Microsoft Sans Serif", 14.25F);
            uxCost.Location = new Point(220, 56);
            uxCost.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            uxCost.Name = "uxCost";
            uxCost.Size = new Size(185, 29);
            uxCost.TabIndex = 3;
            uxCost.TextAlign = HorizontalAlignment.Right;
            // 
            // uxBuy
            // 
            uxBuy.Font = new Font("Microsoft Sans Serif", 14.25F);
            uxBuy.Location = new Point(20, 96);
            uxBuy.Name = "uxBuy";
            uxBuy.Size = new Size(176, 42);
            uxBuy.TabIndex = 4;
            uxBuy.Text = "Buy";
            uxBuy.UseVisualStyleBackColor = true;
            uxBuy.Click += uxBuy_Click;
            // 
            // uxSell
            // 
            uxSell.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            uxSell.Font = new Font("Microsoft Sans Serif", 14.25F);
            uxSell.Location = new Point(229, 96);
            uxSell.Name = "uxSell";
            uxSell.Size = new Size(176, 42);
            uxSell.TabIndex = 5;
            uxSell.Text = "Sell";
            uxSell.UseVisualStyleBackColor = true;
            uxSell.Click += uxSell_Click;
            // 
            // uxOwnedLabel
            // 
            uxOwnedLabel.AutoSize = true;
            uxOwnedLabel.Font = new Font("Microsoft Sans Serif", 14.25F);
            uxOwnedLabel.Location = new Point(20, 156);
            uxOwnedLabel.Name = "uxOwnedLabel";
            uxOwnedLabel.Size = new Size(228, 24);
            uxOwnedLabel.TabIndex = 6;
            uxOwnedLabel.Text = "Number of shares owned:";
            // 
            // uxOwned
            // 
            uxOwned.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            uxOwned.Font = new Font("Microsoft Sans Serif", 14F);
            uxOwned.Location = new Point(269, 155);
            uxOwned.Margin = new Padding(2);
            uxOwned.Name = "uxOwned";
            uxOwned.ReadOnly = true;
            uxOwned.Size = new Size(137, 29);
            uxOwned.TabIndex = 7;
            uxOwned.Text = "0";
            uxOwned.TextAlign = HorizontalAlignment.Right;
            // 
            // uxGainLabel
            // 
            uxGainLabel.AutoSize = true;
            uxGainLabel.Font = new Font("Microsoft Sans Serif", 14.25F);
            uxGainLabel.Location = new Point(20, 187);
            uxGainLabel.Name = "uxGainLabel";
            uxGainLabel.Size = new Size(143, 24);
            uxGainLabel.TabIndex = 8;
            uxGainLabel.Text = "Net capital gain:";
            // 
            // uxGain
            // 
            uxGain.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            uxGain.Font = new Font("Microsoft Sans Serif", 14F);
            uxGain.Location = new Point(182, 187);
            uxGain.Margin = new Padding(2);
            uxGain.Name = "uxGain";
            uxGain.ReadOnly = true;
            uxGain.Size = new Size(224, 29);
            uxGain.TabIndex = 9;
            uxGain.Text = "0.00";
            uxGain.TextAlign = HorizontalAlignment.Right;
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 224);
            Controls.Add(uxGain);
            Controls.Add(uxGainLabel);
            Controls.Add(uxOwned);
            Controls.Add(uxOwnedLabel);
            Controls.Add(uxSell);
            Controls.Add(uxBuy);
            Controls.Add(uxCost);
            Controls.Add(uxCostLabel);
            Controls.Add(uxNumber);
            Controls.Add(uxNumberLabel);
            Name = "UserInterface";
            Text = "Capital Gain Calculator";
            ((System.ComponentModel.ISupportInitialize)uxNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)uxCost).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
