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
    partial class AboutStudio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutStudio));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblStudioVersion = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblAdditionalInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbPlugins = new System.Windows.Forms.RichTextBox();
            this.lblFrameworkVersion = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlHeader.BackgroundImage")));
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.linkLabel1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(518, 73);
            this.pnlHeader.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(3, 57);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(80, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Find updates";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblStudioVersion
            // 
            this.lblStudioVersion.AutoSize = true;
            this.lblStudioVersion.Location = new System.Drawing.Point(12, 6);
            this.lblStudioVersion.Name = "lblStudioVersion";
            this.lblStudioVersion.Size = new System.Drawing.Size(0, 13);
            this.lblStudioVersion.TabIndex = 0;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.lblAdditionalInfo);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Controls.Add(this.rtbPlugins);
            this.pnlBody.Controls.Add(this.lblFrameworkVersion);
            this.pnlBody.Controls.Add(this.lblStudioVersion);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 73);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(518, 211);
            this.pnlBody.TabIndex = 1;
            // 
            // lblAdditionalInfo
            // 
            this.lblAdditionalInfo.AutoSize = true;
            this.lblAdditionalInfo.Location = new System.Drawing.Point(12, 189);
            this.lblAdditionalInfo.Name = "lblAdditionalInfo";
            this.lblAdditionalInfo.Size = new System.Drawing.Size(0, 13);
            this.lblAdditionalInfo.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Installed Plugins";
            // 
            // rtbPlugins
            // 
            this.rtbPlugins.BackColor = System.Drawing.SystemColors.Info;
            this.rtbPlugins.Location = new System.Drawing.Point(4, 83);
            this.rtbPlugins.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.rtbPlugins.Name = "rtbPlugins";
            this.rtbPlugins.ReadOnly = true;
            this.rtbPlugins.Size = new System.Drawing.Size(509, 96);
            this.rtbPlugins.TabIndex = 2;
            this.rtbPlugins.Text = "";
            // 
            // lblFrameworkVersion
            // 
            this.lblFrameworkVersion.AutoSize = true;
            this.lblFrameworkVersion.Location = new System.Drawing.Point(262, 3);
            this.lblFrameworkVersion.Name = "lblFrameworkVersion";
            this.lblFrameworkVersion.Size = new System.Drawing.Size(0, 13);
            this.lblFrameworkVersion.TabIndex = 1;
            // 
            // AboutStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 284);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutStudio";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblStudioVersion;
        private System.Windows.Forms.Label lblFrameworkVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbPlugins;
        private System.Windows.Forms.Label lblAdditionalInfo;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
