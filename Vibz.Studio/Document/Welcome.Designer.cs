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
namespace Vibz.Studio.Document
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlWeb = new System.Windows.Forms.Panel();
            this.wbVauto = new System.Windows.Forms.WebBrowser();
            this.btnRecentProject = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlUserSession = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnlWeb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pnlWeb);
            this.panel1.Controls.Add(this.btnRecentProject);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pnlUserSession);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 361);
            this.panel1.TabIndex = 0;
            // 
            // pnlWeb
            // 
            this.pnlWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWeb.BackColor = System.Drawing.Color.Transparent;
            this.pnlWeb.Controls.Add(this.wbVauto);
            this.pnlWeb.Location = new System.Drawing.Point(10, 142);
            this.pnlWeb.Name = "pnlWeb";
            this.pnlWeb.Size = new System.Drawing.Size(549, 186);
            this.pnlWeb.TabIndex = 7;
            // 
            // wbVauto
            // 
            this.wbVauto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbVauto.Location = new System.Drawing.Point(0, 0);
            this.wbVauto.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbVauto.Name = "wbVauto";
            this.wbVauto.ScriptErrorsSuppressed = true;
            this.wbVauto.ScrollBarsEnabled = false;
            this.wbVauto.Size = new System.Drawing.Size(549, 186);
            this.wbVauto.TabIndex = 0;
            // 
            // btnRecentProject
            // 
            this.btnRecentProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecentProject.FlatAppearance.BorderSize = 0;
            this.btnRecentProject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRecentProject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecentProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecentProject.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRecentProject.Location = new System.Drawing.Point(113, 334);
            this.btnRecentProject.Name = "btnRecentProject";
            this.btnRecentProject.Size = new System.Drawing.Size(446, 23);
            this.btnRecentProject.TabIndex = 6;
            this.btnRecentProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecentProject.UseVisualStyleBackColor = true;
            this.btnRecentProject.Click += new System.EventHandler(this.btnRecentProject_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Recent Project:";
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(181, 36);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(0, 13);
            this.lblVersion.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(135, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(170, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vibz Automation Studio";
            // 
            // pnlUserSession
            // 
            this.pnlUserSession.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUserSession.BackColor = System.Drawing.Color.Transparent;
            this.pnlUserSession.Location = new System.Drawing.Point(10, 54);
            this.pnlUserSession.Name = "pnlUserSession";
            this.pnlUserSession.Size = new System.Drawing.Size(549, 82);
            this.pnlUserSession.TabIndex = 0;
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(573, 365);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlWeb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlUserSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRecentProject;
        private System.Windows.Forms.Panel pnlWeb;
        private System.Windows.Forms.WebBrowser wbVauto;
    }
}
