/*
*	Copyright © 2011, The Vibzworld Team
*	All rights reserved.
*	http://code.google.com/p/vauto/
*	
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions
*	are met:
*	
*	- Redistributions of source code must retain the above copyright
*	notice, this list of conditions and the following disclaimer.
*	
*	- Neither the name of the Vibzworld Team, nor the names of its
*	contributors may be used to endorse or promote products
*	derived from this software without specific prior written
*	permission.
*/
namespace Vibz.Scheduler
{
    partial class SchedulerUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedulerUI));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvRunningTask = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgConfiguration = new System.Windows.Forms.DataGridView();
            this.configName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configvalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ddlElementType = new System.Windows.Forms.ComboBox();
            this.lblElementType = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblNewPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tvHistory = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbClearAll = new System.Windows.Forms.ToolStripButton();
            this.tsbReload = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.lblServiceStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTickValue = new System.Windows.Forms.Label();
            this.cbLogLevel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBarTick = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbStart = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tsbRestart = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmsScheduleTask = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConfiguration)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarTick)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.cmsScheduleTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(647, 425);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(639, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Schedule Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvRunningTask);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 318);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Running Tasks";
            // 
            // tvRunningTask
            // 
            this.tvRunningTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRunningTask.FullRowSelect = true;
            this.tvRunningTask.HotTracking = true;
            this.tvRunningTask.Location = new System.Drawing.Point(3, 16);
            this.tvRunningTask.Name = "tvRunningTask";
            this.tvRunningTask.Size = new System.Drawing.Size(410, 299);
            this.tvRunningTask.TabIndex = 0;
            this.tvRunningTask.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRunningTask_AfterSelect);
            this.tvRunningTask.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvRunningTask_NodeMouseClick);
            this.tvRunningTask.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvRunningTask_BeforeSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgConfiguration);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(413, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 299);
            this.panel1.TabIndex = 1;
            // 
            // dgConfiguration
            // 
            this.dgConfiguration.AllowUserToAddRows = false;
            this.dgConfiguration.AllowUserToDeleteRows = false;
            this.dgConfiguration.BackgroundColor = System.Drawing.Color.White;
            this.dgConfiguration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConfiguration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.configName,
            this.configvalue});
            this.dgConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgConfiguration.Location = new System.Drawing.Point(0, 53);
            this.dgConfiguration.Name = "dgConfiguration";
            this.dgConfiguration.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgConfiguration.RowHeadersVisible = false;
            this.dgConfiguration.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgConfiguration.Size = new System.Drawing.Size(217, 246);
            this.dgConfiguration.TabIndex = 4;
            // 
            // configName
            // 
            this.configName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.configName.HeaderText = "Name";
            this.configName.Name = "configName";
            this.configName.ReadOnly = true;
            // 
            // configvalue
            // 
            this.configvalue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.configvalue.HeaderText = "Value";
            this.configvalue.Name = "configvalue";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ddlElementType);
            this.panel3.Controls.Add(this.lblElementType);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(217, 28);
            this.panel3.TabIndex = 11;
            // 
            // ddlElementType
            // 
            this.ddlElementType.FormattingEnabled = true;
            this.ddlElementType.Location = new System.Drawing.Point(87, 3);
            this.ddlElementType.Name = "ddlElementType";
            this.ddlElementType.Size = new System.Drawing.Size(124, 21);
            this.ddlElementType.TabIndex = 6;
            this.ddlElementType.SelectedIndexChanged += new System.EventHandler(this.ddlElementType_SelectedIndexChanged);
            // 
            // lblElementType
            // 
            this.lblElementType.AutoSize = true;
            this.lblElementType.Location = new System.Drawing.Point(2, 8);
            this.lblElementType.Name = "lblElementType";
            this.lblElementType.Size = new System.Drawing.Size(79, 13);
            this.lblElementType.TabIndex = 10;
            this.lblElementType.Text = "Schedule Type";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 25);
            this.panel2.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(189, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 25);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Properties";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.lblNewPath);
            this.groupBox2.Controls.Add(this.txtPath);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 321);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(633, 75);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Task";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(555, 19);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblNewPath
            // 
            this.lblNewPath.AutoSize = true;
            this.lblNewPath.Location = new System.Drawing.Point(7, 23);
            this.lblNewPath.Name = "lblNewPath";
            this.lblNewPath.Size = new System.Drawing.Size(64, 13);
            this.lblNewPath.TabIndex = 9;
            this.lblNewPath.Text = "Select Task";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(77, 20);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(475, 20);
            this.txtPath.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(555, 47);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Task";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tvHistory);
            this.tabPage2.Controls.Add(this.toolStrip2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(639, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Execution History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tvHistory
            // 
            this.tvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvHistory.Location = new System.Drawing.Point(3, 28);
            this.tvHistory.Name = "tvHistory";
            this.tvHistory.Size = new System.Drawing.Size(633, 368);
            this.tvHistory.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClearAll,
            this.tsbReload});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(633, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbClearAll
            // 
            this.tsbClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClearAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearAll.Image")));
            this.tsbClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearAll.Name = "tsbClearAll";
            this.tsbClearAll.Size = new System.Drawing.Size(23, 22);
            this.tsbClearAll.Text = "toolStripButton1";
            this.tsbClearAll.Click += new System.EventHandler(this.tsbClearAll_Click);
            // 
            // tsbReload
            // 
            this.tsbReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReload.Image = ((System.Drawing.Image)(resources.GetObject("tsbReload.Image")));
            this.tsbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReload.Name = "tsbReload";
            this.tsbReload.Size = new System.Drawing.Size(23, 22);
            this.tsbReload.Text = "toolStripButton2";
            this.tsbReload.Click += new System.EventHandler(this.tsbReload_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.lblTickValue);
            this.tabPage3.Controls.Add(this.cbLogLevel);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.tBarTick);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.txtThreadCount);
            this.tabPage3.Controls.Add(this.toolStrip1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(639, 399);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Service Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.pBar);
            this.panel4.Controls.Add(this.lblServiceStatus);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(639, 20);
            this.panel4.TabIndex = 19;
            // 
            // pBar
            // 
            this.pBar.BackColor = System.Drawing.Color.White;
            this.pBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pBar.Location = new System.Drawing.Point(448, 0);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(191, 20);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pBar.TabIndex = 20;
            this.pBar.Visible = false;
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.AutoSize = true;
            this.lblServiceStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblServiceStatus.Cursor = System.Windows.Forms.Cursors.No;
            this.lblServiceStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblServiceStatus.Font = new System.Drawing.Font("Gautami", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceStatus.Location = new System.Drawing.Point(45, 0);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(42, 14);
            this.lblServiceStatus.TabIndex = 18;
            this.lblServiceStatus.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.No;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Gautami", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 14);
            this.label6.TabIndex = 19;
            this.label6.Text = "Status:";
            // 
            // lblTickValue
            // 
            this.lblTickValue.AutoSize = true;
            this.lblTickValue.Location = new System.Drawing.Point(445, 111);
            this.lblTickValue.Name = "lblTickValue";
            this.lblTickValue.Size = new System.Drawing.Size(0, 13);
            this.lblTickValue.TabIndex = 17;
            // 
            // cbLogLevel
            // 
            this.cbLogLevel.FormattingEnabled = true;
            this.cbLogLevel.Location = new System.Drawing.Point(192, 172);
            this.cbLogLevel.Name = "cbLogLevel";
            this.cbLogLevel.Size = new System.Drawing.Size(227, 21);
            this.cbLogLevel.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Log Level";
            // 
            // tBarTick
            // 
            this.tBarTick.LargeChange = 30000;
            this.tBarTick.Location = new System.Drawing.Point(191, 102);
            this.tBarTick.Maximum = 300000;
            this.tBarTick.Minimum = 5000;
            this.tBarTick.Name = "tBarTick";
            this.tBarTick.Size = new System.Drawing.Size(228, 45);
            this.tBarTick.SmallChange = 5000;
            this.tBarTick.TabIndex = 14;
            this.tBarTick.TickFrequency = 5000;
            this.tBarTick.Value = 30000;
            this.tBarTick.Scroll += new System.EventHandler(this.tBarTick_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tick Interval";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Maximum parallel execution";
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThreadCount.Location = new System.Drawing.Point(191, 58);
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(228, 20);
            this.txtThreadCount.TabIndex = 10;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbStart,
            this.tsbStop,
            this.tsbRestart});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(639, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "Save Settings";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbStart
            // 
            this.tsbStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbStart.Image")));
            this.tsbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStart.Name = "tsbStart";
            this.tsbStart.Size = new System.Drawing.Size(23, 22);
            this.tsbStart.Text = "Start Service";
            this.tsbStart.Click += new System.EventHandler(this.tsbStart_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbStop.Image")));
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(23, 22);
            this.tsbStop.Text = "Stop Service";
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // tsbRestart
            // 
            this.tsbRestart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRestart.Image = ((System.Drawing.Image)(resources.GetObject("tsbRestart.Image")));
            this.tsbRestart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRestart.Name = "tsbRestart";
            this.tsbRestart.Size = new System.Drawing.Size(23, 22);
            this.tsbRestart.Text = "Restart Service";
            this.tsbRestart.Click += new System.EventHandler(this.tsbRestart_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Comments.png");
            this.imageList1.Images.SetKeyName(1, "Event.png");
            this.imageList1.Images.SetKeyName(2, "Error.png");
            this.imageList1.Images.SetKeyName(3, "info.ico");
            this.imageList1.Images.SetKeyName(4, "cons.ico");
            this.imageList1.Images.SetKeyName(5, "Protect Blue.png");
            this.imageList1.Images.SetKeyName(6, "Protect Red.png");
            this.imageList1.Images.SetKeyName(7, "Protect Yellow.png");
            this.imageList1.Images.SetKeyName(8, "Protect Green.png");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmsScheduleTask
            // 
            this.cmsScheduleTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsScheduleTask.Name = "cmsScheduleTask";
            this.cmsScheduleTask.Size = new System.Drawing.Size(153, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // SchedulerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 425);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SchedulerUI";
            this.Text = "Automation Scheduler";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgConfiguration)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarTick)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmsScheduleTask.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView tvRunningTask;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgConfiguration;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblNewPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox ddlElementType;
        private System.Windows.Forms.Label lblElementType;
        private System.Windows.Forms.TreeView tvHistory;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbClearAll;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbStart;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.ToolStripButton tsbRestart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtThreadCount;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tBarTick;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLogLevel;
        private System.Windows.Forms.Label lblTickValue;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton tsbReload;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.Label lblServiceStatus;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn configName;
        private System.Windows.Forms.DataGridViewTextBoxColumn configvalue;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip cmsScheduleTask;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

