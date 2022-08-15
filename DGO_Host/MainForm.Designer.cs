namespace DGO
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.buttonSaveExit = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelMinCost = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.labelTotalSpeed = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelBoxMaxSize = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelBoxSizeCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelLastAutosave = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelSentPoints = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTotalPerfomance = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelRunning = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelComputers = new System.Windows.Forms.Label();
            this.labelTrials = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageClients = new System.Windows.Forms.TabPage();
            this.listViewClients = new System.Windows.Forms.ListView();
            this.columnHeaderID = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderProcessed = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderSpeed = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderEffPerfomance = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderUsefulTime = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLastReceived = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderActive = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLag = new System.Windows.Forms.ColumnHeader();
            this.tabPageDetails = new System.Windows.Forms.TabPage();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.textBoxCostTo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCostFrom = new System.Windows.Forms.TextBox();
            this.textBoxDetails = new System.Windows.Forms.TextBox();
            this.tabPageTop = new System.Windows.Forms.TabPage();
            this.textBoxTop = new System.Windows.Forms.TextBox();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.buttonDefaultBounds = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonRender = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxYTo = new System.Windows.Forms.TextBox();
            this.textBoxYFrom = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxXTo = new System.Windows.Forms.TextBox();
            this.textBoxXFrom = new System.Windows.Forms.TextBox();
            this.comboBoxYAxis = new System.Windows.Forms.ComboBox();
            this.comboBoxXAxis = new System.Windows.Forms.ComboBox();
            this.panelMap = new System.Windows.Forms.Panel();
            this.contextMenuStripMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.drawHorizontalLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawVerticalLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageBounds = new System.Windows.Forms.TabPage();
            this.buttonCancelBoundaries = new System.Windows.Forms.Button();
            this.buttonApplyBoundaries = new System.Windows.Forms.Button();
            this.tableLayoutPanelBoundaries = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxFarthestBoundaries = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxCurrentBoundaries = new System.Windows.Forms.TextBox();
            this.tabPageEstimate = new System.Windows.Forms.TabPage();
            this.buttonAppendEstimate = new System.Windows.Forms.Button();
            this.textBoxEstimateParams = new System.Windows.Forms.TextBox();
            this.textBoxEstimate = new System.Windows.Forms.TextBox();
            this.toolTipCoords = new System.Windows.Forms.ToolTip(this.components);
            this.saveMapDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl.SuspendLayout();
            this.tabPageSummary.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageClients.SuspendLayout();
            this.tabPageDetails.SuspendLayout();
            this.tabPageTop.SuspendLayout();
            this.tabPageMap.SuspendLayout();
            this.contextMenuStripMap.SuspendLayout();
            this.tabPageBounds.SuspendLayout();
            this.tableLayoutPanelBoundaries.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageEstimate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSummary);
            this.tabControl.Controls.Add(this.tabPageClients);
            this.tabControl.Controls.Add(this.tabPageDetails);
            this.tabControl.Controls.Add(this.tabPageTop);
            this.tabControl.Controls.Add(this.tabPageMap);
            this.tabControl.Controls.Add(this.tabPageBounds);
            this.tabControl.Controls.Add(this.tabPageEstimate);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(659, 348);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.Controls.Add(this.buttonSaveExit);
            this.tabPageSummary.Controls.Add(this.buttonPause);
            this.tabPageSummary.Controls.Add(this.groupBox1);
            this.tabPageSummary.Location = new System.Drawing.Point(4, 22);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSummary.Size = new System.Drawing.Size(651, 322);
            this.tabPageSummary.TabIndex = 0;
            this.tabPageSummary.Text = "Summary";
            this.tabPageSummary.UseVisualStyleBackColor = true;
            // 
            // buttonSaveExit
            // 
            this.buttonSaveExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveExit.Location = new System.Drawing.Point(560, 291);
            this.buttonSaveExit.Name = "buttonSaveExit";
            this.buttonSaveExit.Size = new System.Drawing.Size(83, 23);
            this.buttonSaveExit.TabIndex = 2;
            this.buttonSaveExit.Text = "Save and Exit";
            this.buttonSaveExit.UseVisualStyleBackColor = true;
            this.buttonSaveExit.Click += new System.EventHandler(this.buttonSaveExit_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPause.Location = new System.Drawing.Point(6, 291);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(54, 23);
            this.buttonPause.TabIndex = 1;
            this.buttonPause.Text = ">";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelMinCost);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.labelTotalSpeed);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.labelBoxMaxSize);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.labelBoxSizeCount);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.labelLastAutosave);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.labelSentPoints);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labelTotalPerfomance);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelRunning);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labelComputers);
            this.groupBox1.Controls.Add(this.labelTrials);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current state";
            // 
            // labelMinCost
            // 
            this.labelMinCost.AutoSize = true;
            this.labelMinCost.Location = new System.Drawing.Point(369, 62);
            this.labelMinCost.Name = "labelMinCost";
            this.labelMinCost.Size = new System.Drawing.Size(13, 13);
            this.labelMinCost.TabIndex = 19;
            this.labelMinCost.Text = "0";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(242, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 23);
            this.label16.TabIndex = 18;
            this.label16.Text = "Minimal cost:";
            // 
            // labelTotalSpeed
            // 
            this.labelTotalSpeed.AutoSize = true;
            this.labelTotalSpeed.Location = new System.Drawing.Point(133, 108);
            this.labelTotalSpeed.Name = "labelTotalSpeed";
            this.labelTotalSpeed.Size = new System.Drawing.Size(13, 13);
            this.labelTotalSpeed.TabIndex = 17;
            this.labelTotalSpeed.Text = "0";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 23);
            this.label12.TabIndex = 16;
            this.label12.Text = "Total speed:";
            // 
            // labelBoxMaxSize
            // 
            this.labelBoxMaxSize.AutoSize = true;
            this.labelBoxMaxSize.Location = new System.Drawing.Point(369, 39);
            this.labelBoxMaxSize.Name = "labelBoxMaxSize";
            this.labelBoxMaxSize.Size = new System.Drawing.Size(13, 13);
            this.labelBoxMaxSize.TabIndex = 15;
            this.labelBoxMaxSize.Text = "0";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(242, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 23);
            this.label11.TabIndex = 14;
            this.label11.Text = "Box max size:";
            // 
            // labelBoxSizeCount
            // 
            this.labelBoxSizeCount.AutoSize = true;
            this.labelBoxSizeCount.Location = new System.Drawing.Point(369, 16);
            this.labelBoxSizeCount.Name = "labelBoxSizeCount";
            this.labelBoxSizeCount.Size = new System.Drawing.Size(13, 13);
            this.labelBoxSizeCount.TabIndex = 13;
            this.labelBoxSizeCount.Text = "0";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(242, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Box size count:";
            // 
            // labelLastAutosave
            // 
            this.labelLastAutosave.AutoSize = true;
            this.labelLastAutosave.Location = new System.Drawing.Point(133, 154);
            this.labelLastAutosave.Name = "labelLastAutosave";
            this.labelLastAutosave.Size = new System.Drawing.Size(13, 13);
            this.labelLastAutosave.TabIndex = 11;
            this.labelLastAutosave.Text = "0";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Last autosave:";
            // 
            // labelSentPoints
            // 
            this.labelSentPoints.AutoSize = true;
            this.labelSentPoints.Location = new System.Drawing.Point(133, 131);
            this.labelSentPoints.Name = "labelSentPoints";
            this.labelSentPoints.Size = new System.Drawing.Size(13, 13);
            this.labelSentPoints.TabIndex = 9;
            this.labelSentPoints.Text = "0";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Sent points:";
            // 
            // labelTotalPerfomance
            // 
            this.labelTotalPerfomance.AutoSize = true;
            this.labelTotalPerfomance.Location = new System.Drawing.Point(133, 85);
            this.labelTotalPerfomance.Name = "labelTotalPerfomance";
            this.labelTotalPerfomance.Size = new System.Drawing.Size(13, 13);
            this.labelTotalPerfomance.TabIndex = 7;
            this.labelTotalPerfomance.Text = "0";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Total perfomance:";
            // 
            // labelRunning
            // 
            this.labelRunning.AutoSize = true;
            this.labelRunning.Location = new System.Drawing.Point(133, 16);
            this.labelRunning.Name = "labelRunning";
            this.labelRunning.Size = new System.Drawing.Size(13, 13);
            this.labelRunning.TabIndex = 5;
            this.labelRunning.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Running time:";
            // 
            // labelComputers
            // 
            this.labelComputers.AutoSize = true;
            this.labelComputers.Location = new System.Drawing.Point(133, 62);
            this.labelComputers.Name = "labelComputers";
            this.labelComputers.Size = new System.Drawing.Size(13, 13);
            this.labelComputers.TabIndex = 3;
            this.labelComputers.Text = "0";
            // 
            // labelTrials
            // 
            this.labelTrials.AutoSize = true;
            this.labelTrials.Location = new System.Drawing.Point(133, 39);
            this.labelTrials.Name = "labelTrials";
            this.labelTrials.Size = new System.Drawing.Size(13, 13);
            this.labelTrials.TabIndex = 2;
            this.labelTrials.Text = "0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Computers connected:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trials computed:";
            // 
            // tabPageClients
            // 
            this.tabPageClients.Controls.Add(this.listViewClients);
            this.tabPageClients.Location = new System.Drawing.Point(4, 22);
            this.tabPageClients.Name = "tabPageClients";
            this.tabPageClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClients.Size = new System.Drawing.Size(651, 322);
            this.tabPageClients.TabIndex = 1;
            this.tabPageClients.Text = "Clients";
            this.tabPageClients.UseVisualStyleBackColor = true;
            // 
            // listViewClients
            // 
            this.listViewClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderProcessed,
            this.columnHeaderSpeed,
            this.columnHeaderEffPerfomance,
            this.columnHeaderUsefulTime,
            this.columnHeaderLastReceived,
            this.columnHeaderActive,
            this.columnHeaderLag});
            this.listViewClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewClients.FullRowSelect = true;
            this.listViewClients.GridLines = true;
            this.listViewClients.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewClients.Location = new System.Drawing.Point(3, 3);
            this.listViewClients.Name = "listViewClients";
            this.listViewClients.Size = new System.Drawing.Size(645, 316);
            this.listViewClients.TabIndex = 0;
            this.listViewClients.UseCompatibleStateImageBehavior = false;
            this.listViewClients.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "ID";
            this.columnHeaderID.Width = 27;
            // 
            // columnHeaderProcessed
            // 
            this.columnHeaderProcessed.Text = "Processed";
            this.columnHeaderProcessed.Width = 64;
            // 
            // columnHeaderSpeed
            // 
            this.columnHeaderSpeed.Text = "Speed";
            this.columnHeaderSpeed.Width = 72;
            // 
            // columnHeaderEffPerfomance
            // 
            this.columnHeaderEffPerfomance.Text = "EffPerfomance";
            this.columnHeaderEffPerfomance.Width = 87;
            // 
            // columnHeaderUsefulTime
            // 
            this.columnHeaderUsefulTime.Text = "Useful time";
            this.columnHeaderUsefulTime.Width = 68;
            // 
            // columnHeaderLastReceived
            // 
            this.columnHeaderLastReceived.Text = "LastReceived";
            this.columnHeaderLastReceived.Width = 131;
            // 
            // columnHeaderActive
            // 
            this.columnHeaderActive.Text = "Is Active";
            // 
            // columnHeaderLag
            // 
            this.columnHeaderLag.Text = "Lag";
            // 
            // tabPageDetails
            // 
            this.tabPageDetails.Controls.Add(this.buttonCopy);
            this.tabPageDetails.Controls.Add(this.buttonShow);
            this.tabPageDetails.Controls.Add(this.textBoxCostTo);
            this.tabPageDetails.Controls.Add(this.label7);
            this.tabPageDetails.Controls.Add(this.label3);
            this.tabPageDetails.Controls.Add(this.textBoxCostFrom);
            this.tabPageDetails.Controls.Add(this.textBoxDetails);
            this.tabPageDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetails.Name = "tabPageDetails";
            this.tabPageDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetails.Size = new System.Drawing.Size(651, 322);
            this.tabPageDetails.TabIndex = 3;
            this.tabPageDetails.Text = "Details";
            this.tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(316, 4);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 6;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(235, 4);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(75, 23);
            this.buttonShow.TabIndex = 5;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // textBoxCostTo
            // 
            this.textBoxCostTo.Location = new System.Drawing.Point(163, 5);
            this.textBoxCostTo.Name = "textBoxCostTo";
            this.textBoxCostTo.Size = new System.Drawing.Size(66, 20);
            this.textBoxCostTo.TabIndex = 4;
            this.textBoxCostTo.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(138, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "to:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cost from:";
            // 
            // textBoxCostFrom
            // 
            this.textBoxCostFrom.Location = new System.Drawing.Point(66, 5);
            this.textBoxCostFrom.Name = "textBoxCostFrom";
            this.textBoxCostFrom.Size = new System.Drawing.Size(66, 20);
            this.textBoxCostFrom.TabIndex = 1;
            this.textBoxCostFrom.Text = "0";
            // 
            // textBoxDetails
            // 
            this.textBoxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDetails.Location = new System.Drawing.Point(3, 31);
            this.textBoxDetails.Multiline = true;
            this.textBoxDetails.Name = "textBoxDetails";
            this.textBoxDetails.ReadOnly = true;
            this.textBoxDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDetails.Size = new System.Drawing.Size(645, 283);
            this.textBoxDetails.TabIndex = 0;
            // 
            // tabPageTop
            // 
            this.tabPageTop.Controls.Add(this.textBoxTop);
            this.tabPageTop.Location = new System.Drawing.Point(4, 22);
            this.tabPageTop.Name = "tabPageTop";
            this.tabPageTop.Size = new System.Drawing.Size(651, 322);
            this.tabPageTop.TabIndex = 5;
            this.tabPageTop.Text = "Top";
            this.tabPageTop.UseVisualStyleBackColor = true;
            // 
            // textBoxTop
            // 
            this.textBoxTop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTop.Location = new System.Drawing.Point(0, 0);
            this.textBoxTop.Multiline = true;
            this.textBoxTop.Name = "textBoxTop";
            this.textBoxTop.ReadOnly = true;
            this.textBoxTop.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTop.Size = new System.Drawing.Size(651, 322);
            this.textBoxTop.TabIndex = 0;
            // 
            // tabPageMap
            // 
            this.tabPageMap.Controls.Add(this.buttonDefaultBounds);
            this.tabPageMap.Controls.Add(this.label14);
            this.tabPageMap.Controls.Add(this.buttonRender);
            this.tabPageMap.Controls.Add(this.label13);
            this.tabPageMap.Controls.Add(this.textBoxYTo);
            this.tabPageMap.Controls.Add(this.textBoxYFrom);
            this.tabPageMap.Controls.Add(this.label10);
            this.tabPageMap.Controls.Add(this.textBoxXTo);
            this.tabPageMap.Controls.Add(this.textBoxXFrom);
            this.tabPageMap.Controls.Add(this.comboBoxYAxis);
            this.tabPageMap.Controls.Add(this.comboBoxXAxis);
            this.tabPageMap.Controls.Add(this.panelMap);
            this.tabPageMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Size = new System.Drawing.Size(651, 322);
            this.tabPageMap.TabIndex = 2;
            this.tabPageMap.Text = "Map";
            this.tabPageMap.UseVisualStyleBackColor = true;
            // 
            // buttonDefaultBounds
            // 
            this.buttonDefaultBounds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDefaultBounds.Location = new System.Drawing.Point(16, 262);
            this.buttonDefaultBounds.Name = "buttonDefaultBounds";
            this.buttonDefaultBounds.Size = new System.Drawing.Size(95, 23);
            this.buttonDefaultBounds.TabIndex = 12;
            this.buttonDefaultBounds.Text = "Default bounds";
            this.buttonDefaultBounds.UseVisualStyleBackColor = true;
            this.buttonDefaultBounds.Click += new System.EventHandler(this.buttonDefaultBounds_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Select axes:";
            // 
            // buttonRender
            // 
            this.buttonRender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRender.Location = new System.Drawing.Point(24, 291);
            this.buttonRender.Name = "buttonRender";
            this.buttonRender.Size = new System.Drawing.Size(78, 23);
            this.buttonRender.TabIndex = 10;
            this.buttonRender.Text = "Render map";
            this.buttonRender.UseVisualStyleBackColor = true;
            this.buttonRender.Click += new System.EventHandler(this.buttonRender_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Y interval:";
            // 
            // textBoxYTo
            // 
            this.textBoxYTo.Location = new System.Drawing.Point(8, 216);
            this.textBoxYTo.Name = "textBoxYTo";
            this.textBoxYTo.Size = new System.Drawing.Size(111, 20);
            this.textBoxYTo.TabIndex = 8;
            // 
            // textBoxYFrom
            // 
            this.textBoxYFrom.Location = new System.Drawing.Point(8, 190);
            this.textBoxYFrom.Name = "textBoxYFrom";
            this.textBoxYFrom.Size = new System.Drawing.Size(111, 20);
            this.textBoxYFrom.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "X interval:";
            // 
            // textBoxXTo
            // 
            this.textBoxXTo.Location = new System.Drawing.Point(8, 142);
            this.textBoxXTo.Name = "textBoxXTo";
            this.textBoxXTo.Size = new System.Drawing.Size(111, 20);
            this.textBoxXTo.TabIndex = 5;
            // 
            // textBoxXFrom
            // 
            this.textBoxXFrom.Location = new System.Drawing.Point(8, 116);
            this.textBoxXFrom.Name = "textBoxXFrom";
            this.textBoxXFrom.Size = new System.Drawing.Size(111, 20);
            this.textBoxXFrom.TabIndex = 4;
            // 
            // comboBoxYAxis
            // 
            this.comboBoxYAxis.FormattingEnabled = true;
            this.comboBoxYAxis.Location = new System.Drawing.Point(8, 57);
            this.comboBoxYAxis.Name = "comboBoxYAxis";
            this.comboBoxYAxis.Size = new System.Drawing.Size(111, 21);
            this.comboBoxYAxis.TabIndex = 3;
            this.comboBoxYAxis.SelectedIndexChanged += new System.EventHandler(this.comboBoxXYAxis_SelectedIndexChanged);
            // 
            // comboBoxXAxis
            // 
            this.comboBoxXAxis.FormattingEnabled = true;
            this.comboBoxXAxis.Location = new System.Drawing.Point(8, 30);
            this.comboBoxXAxis.Name = "comboBoxXAxis";
            this.comboBoxXAxis.Size = new System.Drawing.Size(111, 21);
            this.comboBoxXAxis.TabIndex = 2;
            this.comboBoxXAxis.SelectedIndexChanged += new System.EventHandler(this.comboBoxXYAxis_SelectedIndexChanged);
            // 
            // panelMap
            // 
            this.panelMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMap.ContextMenuStrip = this.contextMenuStripMap;
            this.panelMap.Location = new System.Drawing.Point(125, 0);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(526, 322);
            this.panelMap.TabIndex = 0;
            this.panelMap.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMap_Paint);
            this.panelMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelMap_MouseClick);
            // 
            // contextMenuStripMap
            // 
            this.contextMenuStripMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.drawHorizontalLinesToolStripMenuItem,
            this.drawVerticalLinesToolStripMenuItem});
            this.contextMenuStripMap.Name = "contextMenuStripMap";
            this.contextMenuStripMap.Size = new System.Drawing.Size(185, 98);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveToolStripMenuItem.Text = "Save As";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // drawHorizontalLinesToolStripMenuItem
            // 
            this.drawHorizontalLinesToolStripMenuItem.Checked = true;
            this.drawHorizontalLinesToolStripMenuItem.CheckOnClick = true;
            this.drawHorizontalLinesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawHorizontalLinesToolStripMenuItem.Name = "drawHorizontalLinesToolStripMenuItem";
            this.drawHorizontalLinesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.drawHorizontalLinesToolStripMenuItem.Text = "Draw horizontal lines";
            // 
            // drawVerticalLinesToolStripMenuItem
            // 
            this.drawVerticalLinesToolStripMenuItem.Checked = true;
            this.drawVerticalLinesToolStripMenuItem.CheckOnClick = true;
            this.drawVerticalLinesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawVerticalLinesToolStripMenuItem.Name = "drawVerticalLinesToolStripMenuItem";
            this.drawVerticalLinesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.drawVerticalLinesToolStripMenuItem.Text = "Draw vertical lines";
            // 
            // tabPageBounds
            // 
            this.tabPageBounds.Controls.Add(this.buttonCancelBoundaries);
            this.tabPageBounds.Controls.Add(this.buttonApplyBoundaries);
            this.tabPageBounds.Controls.Add(this.tableLayoutPanelBoundaries);
            this.tabPageBounds.Location = new System.Drawing.Point(4, 22);
            this.tabPageBounds.Name = "tabPageBounds";
            this.tabPageBounds.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBounds.Size = new System.Drawing.Size(651, 322);
            this.tabPageBounds.TabIndex = 4;
            this.tabPageBounds.Text = "Bounds";
            this.tabPageBounds.UseVisualStyleBackColor = true;
            // 
            // buttonCancelBoundaries
            // 
            this.buttonCancelBoundaries.Location = new System.Drawing.Point(247, 169);
            this.buttonCancelBoundaries.Name = "buttonCancelBoundaries";
            this.buttonCancelBoundaries.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelBoundaries.TabIndex = 4;
            this.buttonCancelBoundaries.Text = "Cancel";
            this.buttonCancelBoundaries.UseVisualStyleBackColor = true;
            this.buttonCancelBoundaries.Click += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // buttonApplyBoundaries
            // 
            this.buttonApplyBoundaries.Location = new System.Drawing.Point(9, 169);
            this.buttonApplyBoundaries.Name = "buttonApplyBoundaries";
            this.buttonApplyBoundaries.Size = new System.Drawing.Size(75, 23);
            this.buttonApplyBoundaries.TabIndex = 3;
            this.buttonApplyBoundaries.Text = "Apply";
            this.buttonApplyBoundaries.UseVisualStyleBackColor = true;
            this.buttonApplyBoundaries.Click += new System.EventHandler(this.buttonApplyBoundaries_Click);
            // 
            // tableLayoutPanelBoundaries
            // 
            this.tableLayoutPanelBoundaries.ColumnCount = 2;
            this.tableLayoutPanelBoundaries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBoundaries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBoundaries.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanelBoundaries.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanelBoundaries.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelBoundaries.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelBoundaries.Name = "tableLayoutPanelBoundaries";
            this.tableLayoutPanelBoundaries.RowCount = 1;
            this.tableLayoutPanelBoundaries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBoundaries.Size = new System.Drawing.Size(645, 160);
            this.tableLayoutPanelBoundaries.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxFarthestBoundaries);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(325, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(317, 154);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Farthest boundaries";
            // 
            // textBoxFarthestBoundaries
            // 
            this.textBoxFarthestBoundaries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFarthestBoundaries.Location = new System.Drawing.Point(3, 16);
            this.textBoxFarthestBoundaries.Multiline = true;
            this.textBoxFarthestBoundaries.Name = "textBoxFarthestBoundaries";
            this.textBoxFarthestBoundaries.ReadOnly = true;
            this.textBoxFarthestBoundaries.Size = new System.Drawing.Size(311, 135);
            this.textBoxFarthestBoundaries.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxCurrentBoundaries);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 154);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current boundaries";
            // 
            // textBoxCurrentBoundaries
            // 
            this.textBoxCurrentBoundaries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCurrentBoundaries.Location = new System.Drawing.Point(3, 16);
            this.textBoxCurrentBoundaries.Multiline = true;
            this.textBoxCurrentBoundaries.Name = "textBoxCurrentBoundaries";
            this.textBoxCurrentBoundaries.Size = new System.Drawing.Size(310, 135);
            this.textBoxCurrentBoundaries.TabIndex = 0;
            // 
            // tabPageEstimate
            // 
            this.tabPageEstimate.Controls.Add(this.buttonAppendEstimate);
            this.tabPageEstimate.Controls.Add(this.textBoxEstimateParams);
            this.tabPageEstimate.Controls.Add(this.textBoxEstimate);
            this.tabPageEstimate.Location = new System.Drawing.Point(4, 22);
            this.tabPageEstimate.Name = "tabPageEstimate";
            this.tabPageEstimate.Size = new System.Drawing.Size(651, 322);
            this.tabPageEstimate.TabIndex = 6;
            this.tabPageEstimate.Text = "Estimate";
            this.tabPageEstimate.UseVisualStyleBackColor = true;
            // 
            // buttonAppendEstimate
            // 
            this.buttonAppendEstimate.Location = new System.Drawing.Point(568, 3);
            this.buttonAppendEstimate.Name = "buttonAppendEstimate";
            this.buttonAppendEstimate.Size = new System.Drawing.Size(75, 23);
            this.buttonAppendEstimate.TabIndex = 3;
            this.buttonAppendEstimate.Text = "Append";
            this.buttonAppendEstimate.UseVisualStyleBackColor = true;
            this.buttonAppendEstimate.Click += new System.EventHandler(this.buttonAppendEstimate_Click);
            // 
            // textBoxEstimateParams
            // 
            this.textBoxEstimateParams.Location = new System.Drawing.Point(8, 5);
            this.textBoxEstimateParams.Name = "textBoxEstimateParams";
            this.textBoxEstimateParams.Size = new System.Drawing.Size(554, 20);
            this.textBoxEstimateParams.TabIndex = 2;
            // 
            // textBoxEstimate
            // 
            this.textBoxEstimate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEstimate.Location = new System.Drawing.Point(0, 31);
            this.textBoxEstimate.Multiline = true;
            this.textBoxEstimate.Name = "textBoxEstimate";
            this.textBoxEstimate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEstimate.Size = new System.Drawing.Size(651, 291);
            this.textBoxEstimate.TabIndex = 1;
            // 
            // saveMapDialog
            // 
            this.saveMapDialog.DefaultExt = "png";
            this.saveMapDialog.Filter = "PNG files|*.png";
            this.saveMapDialog.Title = "Save Map As";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 348);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Distributed Global Optimization";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.tabControl.ResumeLayout(false);
            this.tabPageSummary.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageClients.ResumeLayout(false);
            this.tabPageDetails.ResumeLayout(false);
            this.tabPageDetails.PerformLayout();
            this.tabPageTop.ResumeLayout(false);
            this.tabPageTop.PerformLayout();
            this.tabPageMap.ResumeLayout(false);
            this.tabPageMap.PerformLayout();
            this.contextMenuStripMap.ResumeLayout(false);
            this.tabPageBounds.ResumeLayout(false);
            this.tableLayoutPanelBoundaries.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageEstimate.ResumeLayout(false);
            this.tabPageEstimate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSummary;
        private System.Windows.Forms.TabPage tabPageClients;
        private System.Windows.Forms.TabPage tabPageMap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelComputers;
        private System.Windows.Forms.Label labelTrials;
        private System.Windows.Forms.Label labelRunning;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPageDetails;
        private System.Windows.Forms.TextBox textBoxDetails;
        private System.Windows.Forms.ListView listViewClients;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderProcessed;
        private System.Windows.Forms.ColumnHeader columnHeaderSpeed;
        private System.Windows.Forms.ColumnHeader columnHeaderLastReceived;
        private System.Windows.Forms.ColumnHeader columnHeaderActive;
        private System.Windows.Forms.ColumnHeader columnHeaderLag;
        private System.Windows.Forms.ColumnHeader columnHeaderEffPerfomance;
        private System.Windows.Forms.Label labelTotalPerfomance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.ColumnHeader columnHeaderUsefulTime;
        private System.Windows.Forms.Label labelLastAutosave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelSentPoints;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCostFrom;
        private System.Windows.Forms.TextBox textBoxCostTo;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Label labelBoxSizeCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelBoxMaxSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelTotalSpeed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panelMap;
        private System.Windows.Forms.ComboBox comboBoxYAxis;
        private System.Windows.Forms.ComboBox comboBoxXAxis;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxXTo;
        private System.Windows.Forms.TextBox textBoxXFrom;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxYTo;
        private System.Windows.Forms.TextBox textBoxYFrom;
        private System.Windows.Forms.Button buttonRender;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonDefaultBounds;
        private System.Windows.Forms.ToolTip toolTipCoords;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMap;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveMapDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem drawHorizontalLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawVerticalLinesToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageBounds;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBoundaries;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxFarthestBoundaries;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxCurrentBoundaries;
        private System.Windows.Forms.Button buttonCancelBoundaries;
        private System.Windows.Forms.Button buttonApplyBoundaries;
        private System.Windows.Forms.Label labelMinCost;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage tabPageTop;
        private System.Windows.Forms.TextBox textBoxTop;
        private System.Windows.Forms.Button buttonSaveExit;
        private System.Windows.Forms.TabPage tabPageEstimate;
        private System.Windows.Forms.TextBox textBoxEstimate;
        private System.Windows.Forms.TextBox textBoxEstimateParams;
        private System.Windows.Forms.Button buttonAppendEstimate;
    }
}