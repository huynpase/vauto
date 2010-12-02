namespace Vibz.Studio
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpApplication = new System.Windows.Forms.TabPage();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnReportBrowse = new System.Windows.Forms.Button();
            this.txtReportPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuildBrowse = new System.Windows.Forms.Button();
            this.txtBuildPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpReport = new System.Windows.Forms.TabPage();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tpApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpApplication);
            this.tabControl1.Controls.Add(this.tpReport);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(645, 440);
            this.tabControl1.TabIndex = 0;
            // 
            // tpApplication
            // 
            this.tpApplication.Controls.Add(this.btnApply);
            this.tpApplication.Controls.Add(this.btnReportBrowse);
            this.tpApplication.Controls.Add(this.txtReportPath);
            this.tpApplication.Controls.Add(this.label2);
            this.tpApplication.Controls.Add(this.btnBuildBrowse);
            this.tpApplication.Controls.Add(this.txtBuildPath);
            this.tpApplication.Controls.Add(this.label1);
            this.tpApplication.Location = new System.Drawing.Point(4, 22);
            this.tpApplication.Name = "tpApplication";
            this.tpApplication.Size = new System.Drawing.Size(637, 414);
            this.tpApplication.TabIndex = 1;
            this.tpApplication.Text = "Application";
            this.tpApplication.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(571, 385);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(59, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnReportBrowse
            // 
            this.btnReportBrowse.Location = new System.Drawing.Point(230, 59);
            this.btnReportBrowse.Name = "btnReportBrowse";
            this.btnReportBrowse.Size = new System.Drawing.Size(59, 23);
            this.btnReportBrowse.TabIndex = 8;
            this.btnReportBrowse.Text = "Browse";
            this.btnReportBrowse.UseVisualStyleBackColor = true;
            this.btnReportBrowse.Click += new System.EventHandler(this.btnReportBrowse_Click);
            // 
            // txtReportPath
            // 
            this.txtReportPath.Location = new System.Drawing.Point(92, 61);
            this.txtReportPath.Name = "txtReportPath";
            this.txtReportPath.Size = new System.Drawing.Size(132, 20);
            this.txtReportPath.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Report Path";
            // 
            // btnBuildBrowse
            // 
            this.btnBuildBrowse.Location = new System.Drawing.Point(230, 19);
            this.btnBuildBrowse.Name = "btnBuildBrowse";
            this.btnBuildBrowse.Size = new System.Drawing.Size(59, 23);
            this.btnBuildBrowse.TabIndex = 5;
            this.btnBuildBrowse.Text = "Browse";
            this.btnBuildBrowse.UseVisualStyleBackColor = true;
            this.btnBuildBrowse.Click += new System.EventHandler(this.btnBuildBrowse_Click);
            // 
            // txtBuildPath
            // 
            this.txtBuildPath.Location = new System.Drawing.Point(92, 21);
            this.txtBuildPath.Name = "txtBuildPath";
            this.txtBuildPath.Size = new System.Drawing.Size(132, 20);
            this.txtBuildPath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Build Path";
            // 
            // tpReport
            // 
            this.tpReport.Location = new System.Drawing.Point(4, 22);
            this.tpReport.Name = "tpReport";
            this.tpReport.Padding = new System.Windows.Forms.Padding(3);
            this.tpReport.Size = new System.Drawing.Size(637, 414);
            this.tpReport.TabIndex = 0;
            this.tpReport.Text = "Reports";
            this.tpReport.UseVisualStyleBackColor = true;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 440);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            this.Text = "Project Configuration";
            this.tabControl1.ResumeLayout(false);
            this.tpApplication.ResumeLayout(false);
            this.tpApplication.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpReport;
        private System.Windows.Forms.TabPage tpApplication;
        private System.Windows.Forms.Button btnReportBrowse;
        private System.Windows.Forms.TextBox txtReportPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuildBrowse;
        private System.Windows.Forms.TextBox txtBuildPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnApply;
    }
}