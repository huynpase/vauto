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
namespace Vibz.Options
{
    partial class CartBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartBox));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvPlugin = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlElement = new System.Windows.Forms.Panel();
            this.tvProperties = new System.Windows.Forms.TreeView();
            this.lblInfo = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgConfiguration = new System.Windows.Forms.DataGridView();
            this.configName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configvalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlElement.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConfiguration)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvPlugin);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(357, 366);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvPlugin
            // 
            this.tvPlugin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPlugin.Location = new System.Drawing.Point(0, 25);
            this.tvPlugin.Name = "tvPlugin";
            this.tvPlugin.Size = new System.Drawing.Size(150, 341);
            this.tvPlugin.TabIndex = 1;
            this.tvPlugin.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPlugin_NodeMouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(150, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Controls.Add(this.pnlElement);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(1);
            this.panel3.Size = new System.Drawing.Size(203, 216);
            this.panel3.TabIndex = 4;
            // 
            // pnlElement
            // 
            this.pnlElement.BackColor = System.Drawing.SystemColors.Control;
            this.pnlElement.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlElement.Controls.Add(this.tvProperties);
            this.pnlElement.Controls.Add(this.lblInfo);
            this.pnlElement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlElement.Location = new System.Drawing.Point(1, 26);
            this.pnlElement.Name = "pnlElement";
            this.pnlElement.Size = new System.Drawing.Size(201, 189);
            this.pnlElement.TabIndex = 1;
            // 
            // tvProperties
            // 
            this.tvProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvProperties.Location = new System.Drawing.Point(0, 0);
            this.tvProperties.Name = "tvProperties";
            this.tvProperties.Size = new System.Drawing.Size(197, 142);
            this.tvProperties.TabIndex = 0;
            this.tvProperties.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvProperties_NodeMouseClick);
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblInfo.Location = new System.Drawing.Point(0, 142);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.ReadOnly = true;
            this.lblInfo.Size = new System.Drawing.Size(197, 43);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(201, 25);
            this.panel4.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 25);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Components";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Controls.Add(this.dgConfiguration);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 216);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(203, 150);
            this.panel1.TabIndex = 3;
            // 
            // dgConfiguration
            // 
            this.dgConfiguration.AllowUserToAddRows = false;
            this.dgConfiguration.AllowUserToDeleteRows = false;
            this.dgConfiguration.BackgroundColor = System.Drawing.Color.White;
            this.dgConfiguration.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgConfiguration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConfiguration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.configName,
            this.configvalue});
            this.dgConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgConfiguration.Location = new System.Drawing.Point(1, 26);
            this.dgConfiguration.Name = "dgConfiguration";
            this.dgConfiguration.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgConfiguration.RowHeadersVisible = false;
            this.dgConfiguration.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgConfiguration.Size = new System.Drawing.Size(201, 123);
            this.dgConfiguration.TabIndex = 2;
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
            this.configvalue.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(201, 25);
            this.panel2.TabIndex = 3;
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
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuration";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "fetch.ico");
            this.imageList1.Images.SetKeyName(1, "action.ico");
            this.imageList1.Images.SetKeyName(2, "assert.ico");
            this.imageList1.Images.SetKeyName(3, "macro.ico");
            this.imageList1.Images.SetKeyName(4, "instruction.ico");
            this.imageList1.Images.SetKeyName(5, "macrovar.png");
            this.imageList1.Images.SetKeyName(6, "macrofunc.ico");
            // 
            // CartBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CartBox";
            this.Size = new System.Drawing.Size(357, 366);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pnlElement.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgConfiguration)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TreeView tvProperties;
        private System.Windows.Forms.TreeView tvPlugin;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pnlElement;
        private System.Windows.Forms.DataGridView dgConfiguration;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn configName;
        private System.Windows.Forms.DataGridViewTextBoxColumn configvalue;
        private System.Windows.Forms.RichTextBox lblInfo;
    }
}
