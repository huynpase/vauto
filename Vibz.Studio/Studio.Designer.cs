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
namespace Vibz.Studio
{
    partial class Studio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Studio));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCompile = new System.Windows.Forms.ToolStripButton();
            this.btnRun = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.tvLeft = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.playSoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeBuildOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPISupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutVibzworldAutomationStudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ProjectElementIcons = new System.Windows.Forms.ImageList(this.components);
            this.cmsTVLeft = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlSol = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.pbPnlLog = new System.Windows.Forms.PictureBox();
            this.rtbLogSummary = new System.Windows.Forms.RichTextBox();
            this.timerLog = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.timerExecution = new System.Windows.Forms.Timer(this.components);
            this.mdiStudio = new Vibz.Forms.MdiTabStrip();
            this.pnlTool = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlToolHead = new System.Windows.Forms.Panel();
            this.lblDictTitle = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlSol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPnlLog)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.pnlTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlToolHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.btnCompile,
            this.btnRun,
            this.btnStop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(566, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCompile
            // 
            this.btnCompile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCompile.Enabled = false;
            this.btnCompile.Image = ((System.Drawing.Image)(resources.GetObject("btnCompile.Image")));
            this.btnCompile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(23, 22);
            this.btnCompile.Text = "toolStripButton1";
            this.btnCompile.Click += new System.EventHandler(this.compileToolStripMenuItem_Click);
            // 
            // btnRun
            // 
            this.btnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRun.Enabled = false;
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(23, 22);
            this.btnRun.Text = "toolStripButton3";
            this.btnRun.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Enabled = false;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(23, 22);
            this.btnStop.Text = "toolStripButton1";
            this.btnStop.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // tvLeft
            // 
            this.tvLeft.AllowDrop = true;
            this.tvLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLeft.LineColor = System.Drawing.Color.SteelBlue;
            this.tvLeft.Location = new System.Drawing.Point(2, 0);
            this.tvLeft.Name = "tvLeft";
            this.tvLeft.ShowNodeToolTips = true;
            this.tvLeft.Size = new System.Drawing.Size(187, 261);
            this.tvLeft.TabIndex = 0;
            this.tvLeft.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvLeft_NodeMouseDoubleClick);
            this.tvLeft.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvLeft_AfterCollapse);
            this.tvLeft.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvLeft_NodeMouseClick);
            this.tvLeft.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvLeft_DragEnter);
            this.tvLeft.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvLeft_AfterExpand);
            this.tvLeft.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvLeft_ItemDrag);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.buildToolStripMenuItem,
            this.optionsToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(566, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newProjectToolStripMenuItem.Image")));
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openProjectToolStripMenuItem.Image")));
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(115, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(115, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(12, 20);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolbarToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // showToolbarToolStripMenuItem
            // 
            this.showToolbarToolStripMenuItem.Checked = true;
            this.showToolbarToolStripMenuItem.CheckOnClick = true;
            this.showToolbarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showToolbarToolStripMenuItem.Name = "showToolbarToolStripMenuItem";
            this.showToolbarToolStripMenuItem.Size = new System.Drawing.Size(78, 22);
            this.showToolbarToolStripMenuItem.Click += new System.EventHandler(this.showToolbarToolStripMenuItem_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compileToolStripMenuItem,
            this.runToolStripMenuItem,
            this.toolStripSeparator4,
            this.stopToolStripMenuItem});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.Enabled = false;
            this.compileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("compileToolStripMenuItem.Image")));
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.compileToolStripMenuItem.Click += new System.EventHandler(this.compileToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Enabled = false;
            this.runToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("runToolStripMenuItem.Image")));
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.runToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(104, 6);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripMenuItem.Image")));
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.stopToolStripMenuItem.Text = " ";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem,
            this.settingsStripMenuItem3,
            this.toolStripSeparator5,
            this.playSoundToolStripMenuItem,
            this.encodeBuildOutputToolStripMenuItem,
            this.loggerToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configurationToolStripMenuItem.Image")));
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(78, 22);
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // settingsStripMenuItem3
            // 
            this.settingsStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("settingsStripMenuItem3.Image")));
            this.settingsStripMenuItem3.Name = "settingsStripMenuItem3";
            this.settingsStripMenuItem3.Size = new System.Drawing.Size(78, 22);
            this.settingsStripMenuItem3.Click += new System.EventHandler(this.settingsStripMenuItem3_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(75, 6);
            // 
            // playSoundToolStripMenuItem
            // 
            this.playSoundToolStripMenuItem.Checked = true;
            this.playSoundToolStripMenuItem.CheckOnClick = true;
            this.playSoundToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playSoundToolStripMenuItem.Name = "playSoundToolStripMenuItem";
            this.playSoundToolStripMenuItem.Size = new System.Drawing.Size(78, 22);
            this.playSoundToolStripMenuItem.Click += new System.EventHandler(this.playSoundToolStripMenuItem_Click);
            // 
            // encodeBuildOutputToolStripMenuItem
            // 
            this.encodeBuildOutputToolStripMenuItem.Checked = true;
            this.encodeBuildOutputToolStripMenuItem.CheckOnClick = true;
            this.encodeBuildOutputToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.encodeBuildOutputToolStripMenuItem.Name = "encodeBuildOutputToolStripMenuItem";
            this.encodeBuildOutputToolStripMenuItem.Size = new System.Drawing.Size(78, 22);
            this.encodeBuildOutputToolStripMenuItem.Click += new System.EventHandler(this.encodeBuildOutputToolStripMenuItem_Click);
            // 
            // loggerToolStripMenuItem
            // 
            this.loggerToolStripMenuItem.Checked = true;
            this.loggerToolStripMenuItem.CheckOnClick = true;
            this.loggerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loggerToolStripMenuItem.Name = "loggerToolStripMenuItem";
            this.loggerToolStripMenuItem.Size = new System.Drawing.Size(78, 22);
            this.loggerToolStripMenuItem.Click += new System.EventHandler(this.loggerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPISupportToolStripMenuItem,
            this.aboutVibzworldAutomationStudioToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // aPISupportToolStripMenuItem
            // 
            this.aPISupportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aPISupportToolStripMenuItem.Image")));
            this.aPISupportToolStripMenuItem.Name = "aPISupportToolStripMenuItem";
            this.aPISupportToolStripMenuItem.Size = new System.Drawing.Size(78, 22);
            this.aPISupportToolStripMenuItem.Click += new System.EventHandler(this.aPISupportToolStripMenuItem_Click);
            // 
            // aboutVibzworldAutomationStudioToolStripMenuItem
            // 
            this.aboutVibzworldAutomationStudioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutVibzworldAutomationStudioToolStripMenuItem.Image")));
            this.aboutVibzworldAutomationStudioToolStripMenuItem.Name = "aboutVibzworldAutomationStudioToolStripMenuItem";
            this.aboutVibzworldAutomationStudioToolStripMenuItem.Size = new System.Drawing.Size(78, 22);
            this.aboutVibzworldAutomationStudioToolStripMenuItem.Click += new System.EventHandler(this.aboutVibzworldAutomationStudioToolStripMenuItem_Click);
            // 
            // ProjectElementIcons
            // 
            this.ProjectElementIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ProjectElementIcons.ImageStream")));
            this.ProjectElementIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ProjectElementIcons.Images.SetKeyName(0, "Function.ico");
            this.ProjectElementIcons.Images.SetKeyName(1, "Identifier.ico");
            this.ProjectElementIcons.Images.SetKeyName(2, "Case.ico");
            this.ProjectElementIcons.Images.SetKeyName(3, "Suite.ico");
            this.ProjectElementIcons.Images.SetKeyName(4, "Folder.ico");
            this.ProjectElementIcons.Images.SetKeyName(5, "FolderOpen.ico");
            this.ProjectElementIcons.Images.SetKeyName(6, "Exit.ico");
            this.ProjectElementIcons.Images.SetKeyName(7, "Error.ico");
            // 
            // cmsTVLeft
            // 
            this.cmsTVLeft.Name = "cmsTVLeft";
            this.cmsTVLeft.Size = new System.Drawing.Size(61, 4);
            // 
            // pnlSol
            // 
            this.pnlSol.Controls.Add(this.tvLeft);
            this.pnlSol.Controls.Add(this.pictureBox1);
            this.pnlSol.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSol.Location = new System.Drawing.Point(377, 74);
            this.pnlSol.Name = "pnlSol";
            this.pnlSol.Size = new System.Drawing.Size(189, 261);
            this.pnlSol.TabIndex = 7;
            this.pnlSol.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 261);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbSolPanel_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbSolPanel_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbSolPanel_MouseUp);
            // 
            // pnlLog
            // 
            this.pnlLog.Controls.Add(this.pbPnlLog);
            this.pnlLog.Controls.Add(this.rtbLogSummary);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLog.Location = new System.Drawing.Point(0, 234);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(377, 101);
            this.pnlLog.TabIndex = 12;
            this.pnlLog.Visible = false;
            // 
            // pbPnlLog
            // 
            this.pbPnlLog.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.pbPnlLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbPnlLog.Location = new System.Drawing.Point(0, 0);
            this.pbPnlLog.Name = "pbPnlLog";
            this.pbPnlLog.Size = new System.Drawing.Size(377, 2);
            this.pbPnlLog.TabIndex = 1;
            this.pbPnlLog.TabStop = false;
            this.pbPnlLog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPnlLog_MouseDown);
            this.pbPnlLog.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPnlLog_MouseMove);
            this.pbPnlLog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPnlLog_MouseUp);
            // 
            // rtbLogSummary
            // 
            this.rtbLogSummary.BackColor = System.Drawing.Color.White;
            this.rtbLogSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogSummary.Location = new System.Drawing.Point(0, 0);
            this.rtbLogSummary.Name = "rtbLogSummary";
            this.rtbLogSummary.ReadOnly = true;
            this.rtbLogSummary.Size = new System.Drawing.Size(377, 101);
            this.rtbLogSummary.TabIndex = 0;
            this.rtbLogSummary.Text = "";
            this.rtbLogSummary.TextChanged += new System.EventHandler(this.rtbLogSummary_TextChanged);
            // 
            // timerLog
            // 
            this.timerLog.Interval = 500;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 335);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(566, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // mdiStudio
            // 
            this.mdiStudio.ActiveBorderColor = System.Drawing.Color.Red;
            this.mdiStudio.ActiveCloseBoxColor = System.Drawing.Color.Red;
            this.mdiStudio.BackColor = System.Drawing.SystemColors.Window;
            this.mdiStudio.ButtonBackgroundImage = ((System.Drawing.Image)(resources.GetObject("mdiStudio.ButtonBackgroundImage")));
            this.mdiStudio.CloseBackgroundImage = ((System.Drawing.Image)(resources.GetObject("mdiStudio.CloseBackgroundImage")));
            this.mdiStudio.DrawBorder = true;
            this.mdiStudio.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mdiStudio.InactiveBorderColor = System.Drawing.Color.LightCoral;
            this.mdiStudio.InactiveCloseBoxColor = System.Drawing.Color.LightCoral;
            this.mdiStudio.InactiveForeColor = System.Drawing.Color.DimGray;
            this.mdiStudio.Location = new System.Drawing.Point(0, 49);
            this.mdiStudio.Name = "mdiStudio";
            this.mdiStudio.Padding = new System.Windows.Forms.Padding(0);
            this.mdiStudio.SelectedTab = null;
            this.mdiStudio.ShowItemToolTips = false;
            this.mdiStudio.Size = new System.Drawing.Size(566, 25);
            this.mdiStudio.Stretch = true;
            this.mdiStudio.TabIndex = 14;
            this.mdiStudio.Text = "mdiTabStrip1";
            // 
            // pnlTool
            // 
            this.pnlTool.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlTool.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTool.Controls.Add(this.pictureBox2);
            this.pnlTool.Controls.Add(this.pnlToolHead);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTool.Location = new System.Drawing.Point(0, 74);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Padding = new System.Windows.Forms.Padding(1);
            this.pnlTool.Size = new System.Drawing.Size(178, 160);
            this.pnlTool.TabIndex = 16;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Location = new System.Drawing.Point(171, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(2, 131);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // pnlToolHead
            // 
            this.pnlToolHead.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlToolHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToolHead.Controls.Add(this.lblDictTitle);
            this.pnlToolHead.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pnlToolHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolHead.ForeColor = System.Drawing.Color.Black;
            this.pnlToolHead.Location = new System.Drawing.Point(1, 1);
            this.pnlToolHead.Name = "pnlToolHead";
            this.pnlToolHead.Size = new System.Drawing.Size(172, 23);
            this.pnlToolHead.TabIndex = 0;
            this.pnlToolHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlToolHead_MouseDown);
            this.pnlToolHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlToolHead_MouseMove);
            this.pnlToolHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlToolHead_MouseUp);
            // 
            // lblDictTitle
            // 
            this.lblDictTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDictTitle.AutoSize = true;
            this.lblDictTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDictTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblDictTitle.Location = new System.Drawing.Point(1, 4);
            this.lblDictTitle.Name = "lblDictTitle";
            this.lblDictTitle.Size = new System.Drawing.Size(0, 13);
            this.lblDictTitle.TabIndex = 0;
            this.lblDictTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlToolHead_MouseDown);
            this.lblDictTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlToolHead_MouseMove);
            this.lblDictTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlToolHead_MouseUp);
            // 
            // Studio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 357);
            this.Controls.Add(this.pnlTool);
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.pnlSol);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mdiStudio);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Studio_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlSol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPnlLog)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlTool.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlToolHead.ResumeLayout(false);
            this.pnlToolHead.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCompile;
        private System.Windows.Forms.ToolStripButton btnRun;
        private System.Windows.Forms.TreeView tvLeft;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ImageList ProjectElementIcons;
        private System.Windows.Forms.ContextMenuStrip cmsTVLeft;
        private System.Windows.Forms.Panel pnlSol;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.RichTextBox rtbLogSummary;
        private System.Windows.Forms.PictureBox pbPnlLog;
        private System.Windows.Forms.Timer timerLog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Timer timerExecution;
        private System.Windows.Forms.ToolStripMenuItem aboutVibzworldAutomationStudioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private Vibz.Forms.MdiTabStrip mdiStudio;
        private System.Windows.Forms.ToolStripMenuItem playSoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem encodeBuildOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPISupportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showToolbarToolStripMenuItem;
        private System.Windows.Forms.Panel pnlTool;
        private System.Windows.Forms.Panel pnlToolHead;
        private System.Windows.Forms.Label lblDictTitle;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem loggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripMenuItem settingsStripMenuItem3;
    }
}
