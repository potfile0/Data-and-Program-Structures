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
            uxMenuBar = new MenuStrip();
            uxTools = new ToolStripMenuItem();
            uxLoad = new ToolStripMenuItem();
            uxEntireMap = new ToolStripMenuItem();
            uxSplitContainer = new SplitContainer();
            uxControlPanel = new FlowLayoutPanel();
            uxStartLabel = new Label();
            uxStartNodePanel = new FlowLayoutPanel();
            uxStartNode = new TextBox();
            uxSetStart = new Button();
            uxEndLabel = new Label();
            uxEndingNodePanel = new FlowLayoutPanel();
            uxEndNode = new TextBox();
            uxSetEnd = new Button();
            uxFindPath = new Button();
            uxDistanceLabel = new Label();
            uxDistance = new TextBox();
            uxPathLabel = new Label();
            uxNodeList = new ListBox();
            uxMap = new CefSharp.WinForms.ChromiumWebBrowser();
            uxOpenDialog = new OpenFileDialog();
            uxMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uxSplitContainer).BeginInit();
            uxSplitContainer.Panel1.SuspendLayout();
            uxSplitContainer.Panel2.SuspendLayout();
            uxSplitContainer.SuspendLayout();
            uxControlPanel.SuspendLayout();
            uxStartNodePanel.SuspendLayout();
            uxEndingNodePanel.SuspendLayout();
            SuspendLayout();
            // 
            // uxMenuBar
            // 
            uxMenuBar.ImageScalingSize = new Size(24, 24);
            uxMenuBar.Items.AddRange(new ToolStripItem[] { uxTools });
            uxMenuBar.Location = new Point(0, 0);
            uxMenuBar.Name = "uxMenuBar";
            uxMenuBar.Padding = new Padding(4, 1, 0, 1);
            uxMenuBar.Size = new Size(1170, 24);
            uxMenuBar.TabIndex = 0;
            uxMenuBar.Text = "menuStrip1";
            // 
            // uxTools
            // 
            uxTools.DropDownItems.AddRange(new ToolStripItem[] { uxLoad, uxEntireMap });
            uxTools.Name = "uxTools";
            uxTools.Size = new Size(47, 22);
            uxTools.Text = "Tools";
            // 
            // uxLoad
            // 
            uxLoad.Name = "uxLoad";
            uxLoad.Size = new Size(163, 22);
            uxLoad.Text = "Load a map";
            uxLoad.Click += LoadClick;
            // 
            // uxEntireMap
            // 
            uxEntireMap.Enabled = false;
            uxEntireMap.Name = "uxEntireMap";
            uxEntireMap.Size = new Size(163, 22);
            uxEntireMap.Text = "Show entire map";
            uxEntireMap.Click += EntireMapClick;
            // 
            // uxSplitContainer
            // 
            uxSplitContainer.Dock = DockStyle.Fill;
            uxSplitContainer.FixedPanel = FixedPanel.Panel1;
            uxSplitContainer.Location = new Point(0, 24);
            uxSplitContainer.Margin = new Padding(2, 2, 2, 2);
            uxSplitContainer.Name = "uxSplitContainer";
            // 
            // uxSplitContainer.Panel1
            // 
            uxSplitContainer.Panel1.Controls.Add(uxControlPanel);
            // 
            // uxSplitContainer.Panel2
            // 
            uxSplitContainer.Panel2.Controls.Add(uxMap);
            uxSplitContainer.Size = new Size(1170, 542);
            uxSplitContainer.SplitterDistance = 350;
            uxSplitContainer.TabIndex = 1;
            // 
            // uxControlPanel
            // 
            uxControlPanel.AutoScroll = true;
            uxControlPanel.Controls.Add(uxStartLabel);
            uxControlPanel.Controls.Add(uxStartNodePanel);
            uxControlPanel.Controls.Add(uxEndLabel);
            uxControlPanel.Controls.Add(uxEndingNodePanel);
            uxControlPanel.Controls.Add(uxFindPath);
            uxControlPanel.Controls.Add(uxDistanceLabel);
            uxControlPanel.Controls.Add(uxDistance);
            uxControlPanel.Controls.Add(uxPathLabel);
            uxControlPanel.Controls.Add(uxNodeList);
            uxControlPanel.Dock = DockStyle.Fill;
            uxControlPanel.FlowDirection = FlowDirection.TopDown;
            uxControlPanel.Location = new Point(0, 0);
            uxControlPanel.Margin = new Padding(2, 2, 2, 2);
            uxControlPanel.Name = "uxControlPanel";
            uxControlPanel.Size = new Size(350, 542);
            uxControlPanel.TabIndex = 0;
            uxControlPanel.WrapContents = false;
            // 
            // uxStartLabel
            // 
            uxStartLabel.AutoSize = true;
            uxStartLabel.Font = new Font("Segoe UI", 12F);
            uxStartLabel.Location = new Point(2, 12);
            uxStartLabel.Margin = new Padding(2, 12, 2, 0);
            uxStartLabel.Name = "uxStartLabel";
            uxStartLabel.Size = new Size(109, 21);
            uxStartLabel.TabIndex = 0;
            uxStartLabel.Text = "Starting Node:";
            // 
            // uxStartNodePanel
            // 
            uxStartNodePanel.AutoSize = true;
            uxStartNodePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uxStartNodePanel.Controls.Add(uxStartNode);
            uxStartNodePanel.Controls.Add(uxSetStart);
            uxStartNodePanel.Location = new Point(2, 35);
            uxStartNodePanel.Margin = new Padding(2, 2, 2, 2);
            uxStartNodePanel.Name = "uxStartNodePanel";
            uxStartNodePanel.Size = new Size(272, 33);
            uxStartNodePanel.TabIndex = 1;
            uxStartNodePanel.WrapContents = false;
            // 
            // uxStartNode
            // 
            uxStartNode.Font = new Font("Segoe UI", 12F);
            uxStartNode.Location = new Point(21, 2);
            uxStartNode.Margin = new Padding(21, 2, 2, 2);
            uxStartNode.Name = "uxStartNode";
            uxStartNode.Size = new Size(196, 29);
            uxStartNode.TabIndex = 2;
            uxStartNode.TextChanged += StartNodeTextChanged;
            // 
            // uxSetStart
            // 
            uxSetStart.Enabled = false;
            uxSetStart.Font = new Font("Segoe UI", 12F);
            uxSetStart.Location = new Point(221, 2);
            uxSetStart.Margin = new Padding(2, 2, 2, 2);
            uxSetStart.Name = "uxSetStart";
            uxSetStart.Size = new Size(49, 23);
            uxSetStart.TabIndex = 3;
            uxSetStart.Text = "<";
            uxSetStart.UseVisualStyleBackColor = true;
            uxSetStart.Click += SetStartClick;
            // 
            // uxEndLabel
            // 
            uxEndLabel.AutoSize = true;
            uxEndLabel.Font = new Font("Segoe UI", 12F);
            uxEndLabel.Location = new Point(2, 82);
            uxEndLabel.Margin = new Padding(2, 12, 2, 0);
            uxEndLabel.Name = "uxEndLabel";
            uxEndLabel.Size = new Size(103, 21);
            uxEndLabel.TabIndex = 2;
            uxEndLabel.Text = "Ending Node:";
            // 
            // uxEndingNodePanel
            // 
            uxEndingNodePanel.AutoSize = true;
            uxEndingNodePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uxEndingNodePanel.Controls.Add(uxEndNode);
            uxEndingNodePanel.Controls.Add(uxSetEnd);
            uxEndingNodePanel.Location = new Point(2, 105);
            uxEndingNodePanel.Margin = new Padding(2, 2, 2, 2);
            uxEndingNodePanel.Name = "uxEndingNodePanel";
            uxEndingNodePanel.Size = new Size(272, 33);
            uxEndingNodePanel.TabIndex = 3;
            uxEndingNodePanel.WrapContents = false;
            // 
            // uxEndNode
            // 
            uxEndNode.Font = new Font("Segoe UI", 12F);
            uxEndNode.Location = new Point(21, 2);
            uxEndNode.Margin = new Padding(21, 2, 2, 2);
            uxEndNode.Name = "uxEndNode";
            uxEndNode.Size = new Size(196, 29);
            uxEndNode.TabIndex = 2;
            uxEndNode.TextChanged += EndNodeTextChanged;
            // 
            // uxSetEnd
            // 
            uxSetEnd.Enabled = false;
            uxSetEnd.Font = new Font("Segoe UI", 12F);
            uxSetEnd.Location = new Point(221, 2);
            uxSetEnd.Margin = new Padding(2, 2, 2, 2);
            uxSetEnd.Name = "uxSetEnd";
            uxSetEnd.Size = new Size(49, 23);
            uxSetEnd.TabIndex = 3;
            uxSetEnd.Text = "<";
            uxSetEnd.UseVisualStyleBackColor = true;
            uxSetEnd.Click += SetEndClick;
            // 
            // uxFindPath
            // 
            uxFindPath.Enabled = false;
            uxFindPath.Font = new Font("Segoe UI", 12F);
            uxFindPath.Location = new Point(2, 158);
            uxFindPath.Margin = new Padding(2, 18, 2, 2);
            uxFindPath.Name = "uxFindPath";
            uxFindPath.Size = new Size(271, 31);
            uxFindPath.TabIndex = 4;
            uxFindPath.Text = "Find Shortest Path";
            uxFindPath.UseVisualStyleBackColor = true;
            uxFindPath.Click += uxFindPath_Click;
            // 
            // uxDistanceLabel
            // 
            uxDistanceLabel.AutoSize = true;
            uxDistanceLabel.Font = new Font("Segoe UI", 12F);
            uxDistanceLabel.Location = new Point(2, 203);
            uxDistanceLabel.Margin = new Padding(2, 12, 2, 0);
            uxDistanceLabel.Name = "uxDistanceLabel";
            uxDistanceLabel.Size = new Size(72, 21);
            uxDistanceLabel.TabIndex = 5;
            uxDistanceLabel.Text = "Distance:";
            // 
            // uxDistance
            // 
            uxDistance.Font = new Font("Segoe UI", 12F);
            uxDistance.Location = new Point(21, 226);
            uxDistance.Margin = new Padding(21, 2, 2, 2);
            uxDistance.Name = "uxDistance";
            uxDistance.ReadOnly = true;
            uxDistance.Size = new Size(251, 29);
            uxDistance.TabIndex = 6;
            // 
            // uxPathLabel
            // 
            uxPathLabel.AutoSize = true;
            uxPathLabel.Font = new Font("Segoe UI", 12F);
            uxPathLabel.Location = new Point(2, 269);
            uxPathLabel.Margin = new Padding(2, 12, 2, 0);
            uxPathLabel.Name = "uxPathLabel";
            uxPathLabel.Size = new Size(105, 21);
            uxPathLabel.TabIndex = 7;
            uxPathLabel.Text = "Shortest Path:";
            // 
            // uxNodeList
            // 
            uxNodeList.Font = new Font("Segoe UI", 12F);
            uxNodeList.FormattingEnabled = true;
            uxNodeList.ItemHeight = 21;
            uxNodeList.Location = new Point(21, 292);
            uxNodeList.Margin = new Padding(21, 2, 2, 2);
            uxNodeList.Name = "uxNodeList";
            uxNodeList.Size = new Size(253, 151);
            uxNodeList.TabIndex = 8;
            uxNodeList.SelectedIndexChanged += NodeListSelectedIndexChanged;
            // 
            // uxMap
            // 
            uxMap.ActivateBrowserOnCreation = false;
            uxMap.Dock = DockStyle.Fill;
            uxMap.Location = new Point(0, 0);
            uxMap.Margin = new Padding(2, 2, 2, 2);
            uxMap.Name = "uxMap";
            uxMap.Size = new Size(816, 542);
            uxMap.TabIndex = 0;
            uxMap.AddressChanged += MapAddressChanged;
            // 
            // uxOpenDialog
            // 
            uxOpenDialog.Filter = "Comma-separated value files (*.csv)|*.csv";
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 566);
            Controls.Add(uxSplitContainer);
            Controls.Add(uxMenuBar);
            MainMenuStrip = uxMenuBar;
            Margin = new Padding(2, 2, 2, 2);
            Name = "UserInterface";
            Text = "Shortest Path Finder";
            uxMenuBar.ResumeLayout(false);
            uxMenuBar.PerformLayout();
            uxSplitContainer.Panel1.ResumeLayout(false);
            uxSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)uxSplitContainer).EndInit();
            uxSplitContainer.ResumeLayout(false);
            uxControlPanel.ResumeLayout(false);
            uxControlPanel.PerformLayout();
            uxStartNodePanel.ResumeLayout(false);
            uxStartNodePanel.PerformLayout();
            uxEndingNodePanel.ResumeLayout(false);
            uxEndingNodePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
