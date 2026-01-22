namespace Ksu.Cis300.ShortestPaths
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
            this.uxMenuBar = new System.Windows.Forms.MenuStrip();
            this.uxTools = new System.Windows.Forms.ToolStripMenuItem();
            this.uxLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.uxEntireMap = new System.Windows.Forms.ToolStripMenuItem();
            this.uxSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uxControlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uxStartLabel = new System.Windows.Forms.Label();
            this.uxStartNodePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uxStartNode = new System.Windows.Forms.TextBox();
            this.uxSetStart = new System.Windows.Forms.Button();
            this.uxEndLabel = new System.Windows.Forms.Label();
            this.uxEndingNodePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uxEndNode = new System.Windows.Forms.TextBox();
            this.uxSetEnd = new System.Windows.Forms.Button();
            this.uxFindPath = new System.Windows.Forms.Button();
            this.uxDistanceLabel = new System.Windows.Forms.Label();
            this.uxDistance = new System.Windows.Forms.TextBox();
            this.uxPathLabel = new System.Windows.Forms.Label();
            this.uxNodeList = new System.Windows.Forms.ListBox();
            this.uxMap = new CefSharp.WinForms.ChromiumWebBrowser();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxSplitContainer)).BeginInit();
            this.uxSplitContainer.Panel1.SuspendLayout();
            this.uxSplitContainer.Panel2.SuspendLayout();
            this.uxSplitContainer.SuspendLayout();
            this.uxControlPanel.SuspendLayout();
            this.uxStartNodePanel.SuspendLayout();
            this.uxEndingNodePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxMenuBar
            // 
            this.uxMenuBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxTools});
            this.uxMenuBar.Location = new System.Drawing.Point(0, 0);
            this.uxMenuBar.Name = "uxMenuBar";
            this.uxMenuBar.Size = new System.Drawing.Size(1671, 33);
            this.uxMenuBar.TabIndex = 0;
            this.uxMenuBar.Text = "menuStrip1";
            // 
            // uxTools
            // 
            this.uxTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxLoad,
            this.uxEntireMap});
            this.uxTools.Name = "uxTools";
            this.uxTools.Size = new System.Drawing.Size(69, 29);
            this.uxTools.Text = "Tools";
            // 
            // uxLoad
            // 
            this.uxLoad.Name = "uxLoad";
            this.uxLoad.Size = new System.Drawing.Size(270, 34);
            this.uxLoad.Text = "Load a map";
            this.uxLoad.Click += new System.EventHandler(this.LoadClick);
            // 
            // uxEntireMap
            // 
            this.uxEntireMap.Enabled = false;
            this.uxEntireMap.Name = "uxEntireMap";
            this.uxEntireMap.Size = new System.Drawing.Size(270, 34);
            this.uxEntireMap.Text = "Show entire map";
            this.uxEntireMap.Click += new System.EventHandler(this.EntireMapClick);
            // 
            // uxSplitContainer
            // 
            this.uxSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.uxSplitContainer.Location = new System.Drawing.Point(0, 33);
            this.uxSplitContainer.Name = "uxSplitContainer";
            // 
            // uxSplitContainer.Panel1
            // 
            this.uxSplitContainer.Panel1.Controls.Add(this.uxControlPanel);
            // 
            // uxSplitContainer.Panel2
            // 
            this.uxSplitContainer.Panel2.Controls.Add(this.uxMap);
            this.uxSplitContainer.Size = new System.Drawing.Size(1671, 910);
            this.uxSplitContainer.SplitterDistance = 500;
            this.uxSplitContainer.SplitterWidth = 6;
            this.uxSplitContainer.TabIndex = 1;
            // 
            // uxControlPanel
            // 
            this.uxControlPanel.AutoScroll = true;
            this.uxControlPanel.Controls.Add(this.uxStartLabel);
            this.uxControlPanel.Controls.Add(this.uxStartNodePanel);
            this.uxControlPanel.Controls.Add(this.uxEndLabel);
            this.uxControlPanel.Controls.Add(this.uxEndingNodePanel);
            this.uxControlPanel.Controls.Add(this.uxFindPath);
            this.uxControlPanel.Controls.Add(this.uxDistanceLabel);
            this.uxControlPanel.Controls.Add(this.uxDistance);
            this.uxControlPanel.Controls.Add(this.uxPathLabel);
            this.uxControlPanel.Controls.Add(this.uxNodeList);
            this.uxControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxControlPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uxControlPanel.Location = new System.Drawing.Point(0, 0);
            this.uxControlPanel.Name = "uxControlPanel";
            this.uxControlPanel.Size = new System.Drawing.Size(500, 910);
            this.uxControlPanel.TabIndex = 0;
            this.uxControlPanel.WrapContents = false;
            // 
            // uxStartLabel
            // 
            this.uxStartLabel.AutoSize = true;
            this.uxStartLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxStartLabel.Location = new System.Drawing.Point(3, 20);
            this.uxStartLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.uxStartLabel.Name = "uxStartLabel";
            this.uxStartLabel.Size = new System.Drawing.Size(167, 32);
            this.uxStartLabel.TabIndex = 0;
            this.uxStartLabel.Text = "Starting Node:";
            // 
            // uxStartNodePanel
            // 
            this.uxStartNodePanel.AutoSize = true;
            this.uxStartNodePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uxStartNodePanel.Controls.Add(this.uxStartNode);
            this.uxStartNodePanel.Controls.Add(this.uxSetStart);
            this.uxStartNodePanel.Location = new System.Drawing.Point(3, 55);
            this.uxStartNodePanel.Name = "uxStartNodePanel";
            this.uxStartNodePanel.Size = new System.Drawing.Size(387, 45);
            this.uxStartNodePanel.TabIndex = 1;
            this.uxStartNodePanel.WrapContents = false;
            // 
            // uxStartNode
            // 
            this.uxStartNode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxStartNode.Location = new System.Drawing.Point(30, 3);
            this.uxStartNode.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.uxStartNode.Name = "uxStartNode";
            this.uxStartNode.Size = new System.Drawing.Size(278, 39);
            this.uxStartNode.TabIndex = 2;
            this.uxStartNode.TextChanged += new System.EventHandler(this.StartNodeTextChanged);
            // 
            // uxSetStart
            // 
            this.uxSetStart.Enabled = false;
            this.uxSetStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxSetStart.Location = new System.Drawing.Point(314, 3);
            this.uxSetStart.Name = "uxSetStart";
            this.uxSetStart.Size = new System.Drawing.Size(70, 39);
            this.uxSetStart.TabIndex = 3;
            this.uxSetStart.Text = "<";
            this.uxSetStart.UseVisualStyleBackColor = true;
            this.uxSetStart.Click += new System.EventHandler(this.SetStartClick);
            // 
            // uxEndLabel
            // 
            this.uxEndLabel.AutoSize = true;
            this.uxEndLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxEndLabel.Location = new System.Drawing.Point(3, 123);
            this.uxEndLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.uxEndLabel.Name = "uxEndLabel";
            this.uxEndLabel.Size = new System.Drawing.Size(159, 32);
            this.uxEndLabel.TabIndex = 2;
            this.uxEndLabel.Text = "Ending Node:";
            // 
            // uxEndingNodePanel
            // 
            this.uxEndingNodePanel.AutoSize = true;
            this.uxEndingNodePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uxEndingNodePanel.Controls.Add(this.uxEndNode);
            this.uxEndingNodePanel.Controls.Add(this.uxSetEnd);
            this.uxEndingNodePanel.Location = new System.Drawing.Point(3, 158);
            this.uxEndingNodePanel.Name = "uxEndingNodePanel";
            this.uxEndingNodePanel.Size = new System.Drawing.Size(387, 45);
            this.uxEndingNodePanel.TabIndex = 3;
            this.uxEndingNodePanel.WrapContents = false;
            // 
            // uxEndNode
            // 
            this.uxEndNode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxEndNode.Location = new System.Drawing.Point(30, 3);
            this.uxEndNode.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.uxEndNode.Name = "uxEndNode";
            this.uxEndNode.Size = new System.Drawing.Size(278, 39);
            this.uxEndNode.TabIndex = 2;
            this.uxEndNode.TextChanged += new System.EventHandler(this.EndNodeTextChanged);
            // 
            // uxSetEnd
            // 
            this.uxSetEnd.Enabled = false;
            this.uxSetEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxSetEnd.Location = new System.Drawing.Point(314, 3);
            this.uxSetEnd.Name = "uxSetEnd";
            this.uxSetEnd.Size = new System.Drawing.Size(70, 39);
            this.uxSetEnd.TabIndex = 3;
            this.uxSetEnd.Text = "<";
            this.uxSetEnd.UseVisualStyleBackColor = true;
            this.uxSetEnd.Click += new System.EventHandler(this.SetEndClick);
            // 
            // uxFindPath
            // 
            this.uxFindPath.Enabled = false;
            this.uxFindPath.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxFindPath.Location = new System.Drawing.Point(3, 236);
            this.uxFindPath.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.uxFindPath.Name = "uxFindPath";
            this.uxFindPath.Size = new System.Drawing.Size(387, 52);
            this.uxFindPath.TabIndex = 4;
            this.uxFindPath.Text = "Find Shortest Path";
            this.uxFindPath.UseVisualStyleBackColor = true;
            // 
            // uxDistanceLabel
            // 
            this.uxDistanceLabel.AutoSize = true;
            this.uxDistanceLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxDistanceLabel.Location = new System.Drawing.Point(3, 311);
            this.uxDistanceLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.uxDistanceLabel.Name = "uxDistanceLabel";
            this.uxDistanceLabel.Size = new System.Drawing.Size(110, 32);
            this.uxDistanceLabel.TabIndex = 5;
            this.uxDistanceLabel.Text = "Distance:";
            // 
            // uxDistance
            // 
            this.uxDistance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxDistance.Location = new System.Drawing.Point(30, 346);
            this.uxDistance.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.uxDistance.Name = "uxDistance";
            this.uxDistance.ReadOnly = true;
            this.uxDistance.Size = new System.Drawing.Size(357, 39);
            this.uxDistance.TabIndex = 6;
            // 
            // uxPathLabel
            // 
            this.uxPathLabel.AutoSize = true;
            this.uxPathLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxPathLabel.Location = new System.Drawing.Point(3, 408);
            this.uxPathLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.uxPathLabel.Name = "uxPathLabel";
            this.uxPathLabel.Size = new System.Drawing.Size(160, 32);
            this.uxPathLabel.TabIndex = 7;
            this.uxPathLabel.Text = "Shortest Path:";
            // 
            // uxNodeList
            // 
            this.uxNodeList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxNodeList.FormattingEnabled = true;
            this.uxNodeList.ItemHeight = 32;
            this.uxNodeList.Location = new System.Drawing.Point(30, 443);
            this.uxNodeList.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.uxNodeList.Name = "uxNodeList";
            this.uxNodeList.Size = new System.Drawing.Size(360, 260);
            this.uxNodeList.TabIndex = 8;
            this.uxNodeList.SelectedIndexChanged += new System.EventHandler(this.NodeListSelectedIndexChanged);
            // 
            // uxMap
            // 
            this.uxMap.ActivateBrowserOnCreation = false;
            this.uxMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxMap.Location = new System.Drawing.Point(0, 0);
            this.uxMap.Name = "uxMap";
            this.uxMap.Size = new System.Drawing.Size(1165, 910);
            this.uxMap.TabIndex = 0;
            this.uxMap.AddressChanged += new System.EventHandler<CefSharp.AddressChangedEventArgs>(this.MapAddressChanged);
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.Filter = "Comma-separated value files (*.csv)|*.csv";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1671, 943);
            this.Controls.Add(this.uxSplitContainer);
            this.Controls.Add(this.uxMenuBar);
            this.MainMenuStrip = this.uxMenuBar;
            this.Name = "UserInterface";
            this.Text = "Shortest Path Finder";
            this.uxMenuBar.ResumeLayout(false);
            this.uxMenuBar.PerformLayout();
            this.uxSplitContainer.Panel1.ResumeLayout(false);
            this.uxSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxSplitContainer)).EndInit();
            this.uxSplitContainer.ResumeLayout(false);
            this.uxControlPanel.ResumeLayout(false);
            this.uxControlPanel.PerformLayout();
            this.uxStartNodePanel.ResumeLayout(false);
            this.uxStartNodePanel.PerformLayout();
            this.uxEndingNodePanel.ResumeLayout(false);
            this.uxEndingNodePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip uxMenuBar;
        private ToolStripMenuItem uxTools;
        private ToolStripMenuItem uxLoad;
        private ToolStripMenuItem uxEntireMap;
        private SplitContainer uxSplitContainer;
        private CefSharp.WinForms.ChromiumWebBrowser uxMap;
        private OpenFileDialog uxOpenDialog;
        private FlowLayoutPanel uxControlPanel;
        private Label uxStartLabel;
        private FlowLayoutPanel uxStartNodePanel;
        private TextBox uxStartNode;
        private Button uxSetStart;
        private Label uxEndLabel;
        private FlowLayoutPanel uxEndingNodePanel;
        private TextBox uxEndNode;
        private Button uxSetEnd;
        private Button uxFindPath;
        private Label uxDistanceLabel;
        private TextBox uxDistance;
        private Label uxPathLabel;
        private ListBox uxNodeList;
    }
}
