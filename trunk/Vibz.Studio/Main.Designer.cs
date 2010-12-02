namespace Vibz.Studio
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtbHeader = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtbSource = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rtbJS = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.rtbRedirects = new System.Windows.Forms.RichTextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.rtbImages = new System.Windows.Forms.RichTextBox();
            this.rtbProgress = new System.Windows.Forms.RichTextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tvAll = new System.Windows.Forms.TreeView();
            this.tvSelected = new System.Windows.Forms.TreeView();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnBrowseCrowler = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCrowler = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.cbClearOnPostBack = new System.Windows.Forms.CheckBox();
            this.cbExtractData = new System.Windows.Forms.CheckBox();
            this.btnExtractData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExtractData = new System.Windows.Forms.TextBox();
            this.cbDownload = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDownload = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtUrl);
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 61);
            this.panel1.TabIndex = 0;
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(38, 6);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(605, 20);
            this.txtUrl.TabIndex = 2;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(645, 6);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(38, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(687, 295);
            this.splitContainer1.SplitterDistance = 61;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(687, 230);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.rtbHeader);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(679, 204);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Headers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtbHeader
            // 
            this.rtbHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHeader.Location = new System.Drawing.Point(3, 3);
            this.rtbHeader.Name = "rtbHeader";
            this.rtbHeader.Size = new System.Drawing.Size(673, 198);
            this.rtbHeader.TabIndex = 1;
            this.rtbHeader.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtbSource);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(679, 204);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HTML Source";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtbSource
            // 
            this.rtbSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSource.Location = new System.Drawing.Point(3, 3);
            this.rtbSource.Name = "rtbSource";
            this.rtbSource.Size = new System.Drawing.Size(673, 198);
            this.rtbSource.TabIndex = 0;
            this.rtbSource.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rtbJS);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(679, 204);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "JS Links";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rtbJS
            // 
            this.rtbJS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbJS.Location = new System.Drawing.Point(0, 0);
            this.rtbJS.Name = "rtbJS";
            this.rtbJS.Size = new System.Drawing.Size(679, 204);
            this.rtbJS.TabIndex = 1;
            this.rtbJS.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rtbRedirects);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(679, 204);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Redirects";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // rtbRedirects
            // 
            this.rtbRedirects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRedirects.Location = new System.Drawing.Point(0, 0);
            this.rtbRedirects.Name = "rtbRedirects";
            this.rtbRedirects.Size = new System.Drawing.Size(679, 204);
            this.rtbRedirects.TabIndex = 1;
            this.rtbRedirects.Text = "";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.rtbImages);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(679, 204);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Images";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // rtbImages
            // 
            this.rtbImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbImages.Location = new System.Drawing.Point(0, 0);
            this.rtbImages.Name = "rtbImages";
            this.rtbImages.Size = new System.Drawing.Size(679, 204);
            this.rtbImages.TabIndex = 2;
            this.rtbImages.Text = "";
            // 
            // rtbProgress
            // 
            this.rtbProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbProgress.Location = new System.Drawing.Point(0, 0);
            this.rtbProgress.Name = "rtbProgress";
            this.rtbProgress.Size = new System.Drawing.Size(701, 97);
            this.rtbProgress.TabIndex = 2;
            this.rtbProgress.Text = "";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(701, 327);
            this.tabControl2.TabIndex = 4;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.splitContainer1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(693, 301);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Extract";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.splitContainer3);
            this.tabPage8.Controls.Add(this.btnExecute);
            this.tabPage8.Controls.Add(this.btnBrowseCrowler);
            this.tabPage8.Controls.Add(this.label4);
            this.tabPage8.Controls.Add(this.txtCrowler);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(693, 301);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "Crowl";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Location = new System.Drawing.Point(113, 33);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tvAll);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tvSelected);
            this.splitContainer3.Size = new System.Drawing.Size(572, 62);
            this.splitContainer3.SplitterDistance = 284;
            this.splitContainer3.TabIndex = 7;
            // 
            // tvAll
            // 
            this.tvAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAll.Location = new System.Drawing.Point(0, 0);
            this.tvAll.Name = "tvAll";
            this.tvAll.Size = new System.Drawing.Size(284, 62);
            this.tvAll.TabIndex = 0;
            // 
            // tvSelected
            // 
            this.tvSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSelected.Location = new System.Drawing.Point(0, 0);
            this.tvSelected.Name = "tvSelected";
            this.tvSelected.Size = new System.Drawing.Size(284, 62);
            this.tvSelected.TabIndex = 1;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(626, 98);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(60, 23);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnBrowseCrowler
            // 
            this.btnBrowseCrowler.Location = new System.Drawing.Point(635, 8);
            this.btnBrowseCrowler.Name = "btnBrowseCrowler";
            this.btnBrowseCrowler.Size = new System.Drawing.Size(51, 23);
            this.btnBrowseCrowler.TabIndex = 5;
            this.btnBrowseCrowler.Text = "Browse";
            this.btnBrowseCrowler.UseVisualStyleBackColor = true;
            this.btnBrowseCrowler.Click += new System.EventHandler(this.btnBrowseCrowler_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Crowler File Path";
            // 
            // txtCrowler
            // 
            this.txtCrowler.Location = new System.Drawing.Point(113, 8);
            this.txtCrowler.Name = "txtCrowler";
            this.txtCrowler.Size = new System.Drawing.Size(515, 20);
            this.txtCrowler.TabIndex = 3;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.cbClearOnPostBack);
            this.tabPage7.Controls.Add(this.cbExtractData);
            this.tabPage7.Controls.Add(this.btnExtractData);
            this.tabPage7.Controls.Add(this.label3);
            this.tabPage7.Controls.Add(this.txtExtractData);
            this.tabPage7.Controls.Add(this.cbDownload);
            this.tabPage7.Controls.Add(this.btnBrowse);
            this.tabPage7.Controls.Add(this.label2);
            this.tabPage7.Controls.Add(this.txtDownload);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(693, 301);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Settings";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // cbClearOnPostBack
            // 
            this.cbClearOnPostBack.AutoSize = true;
            this.cbClearOnPostBack.Location = new System.Drawing.Point(8, 10);
            this.cbClearOnPostBack.Name = "cbClearOnPostBack";
            this.cbClearOnPostBack.Size = new System.Drawing.Size(166, 17);
            this.cbClearOnPostBack.TabIndex = 8;
            this.cbClearOnPostBack.Text = "Clear records of last postback";
            this.cbClearOnPostBack.UseVisualStyleBackColor = true;
            // 
            // cbExtractData
            // 
            this.cbExtractData.AutoSize = true;
            this.cbExtractData.Location = new System.Drawing.Point(8, 73);
            this.cbExtractData.Name = "cbExtractData";
            this.cbExtractData.Size = new System.Drawing.Size(85, 17);
            this.cbExtractData.TabIndex = 7;
            this.cbExtractData.Text = "Extract Data";
            this.cbExtractData.UseVisualStyleBackColor = true;
            // 
            // btnExtractData
            // 
            this.btnExtractData.Enabled = false;
            this.btnExtractData.Location = new System.Drawing.Point(265, 89);
            this.btnExtractData.Name = "btnExtractData";
            this.btnExtractData.Size = new System.Drawing.Size(51, 23);
            this.btnExtractData.TabIndex = 6;
            this.btnExtractData.Text = "Browse";
            this.btnExtractData.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Extract Data Path";
            // 
            // txtExtractData
            // 
            this.txtExtractData.Enabled = false;
            this.txtExtractData.Location = new System.Drawing.Point(118, 89);
            this.txtExtractData.Name = "txtExtractData";
            this.txtExtractData.Size = new System.Drawing.Size(141, 20);
            this.txtExtractData.TabIndex = 4;
            // 
            // cbDownload
            // 
            this.cbDownload.AutoSize = true;
            this.cbDownload.Location = new System.Drawing.Point(8, 30);
            this.cbDownload.Name = "cbDownload";
            this.cbDownload.Size = new System.Drawing.Size(111, 17);
            this.cbDownload.TabIndex = 3;
            this.cbDownload.Text = "Download Images";
            this.cbDownload.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(263, 46);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(51, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Download Path";
            // 
            // txtDownload
            // 
            this.txtDownload.Enabled = false;
            this.txtDownload.Location = new System.Drawing.Point(116, 46);
            this.txtDownload.Name = "txtDownload";
            this.txtDownload.Size = new System.Drawing.Size(141, 20);
            this.txtDownload.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rtbProgress);
            this.splitContainer2.Size = new System.Drawing.Size(701, 428);
            this.splitContainer2.SplitterDistance = 327;
            this.splitContainer2.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(673, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.BackgroundImage")));
            this.toolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(106, 25);
            this.toolStripButton1.Text = "sdsdsasdasdasdasd";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 428);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Web Page Info Extractor - Powered by Vibzworld";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbSource;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox rtbHeader;
        private System.Windows.Forms.RichTextBox rtbJS;
        private System.Windows.Forms.RichTextBox rtbRedirects;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox rtbImages;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDownload;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox cbDownload;
        private System.Windows.Forms.CheckBox cbExtractData;
        private System.Windows.Forms.Button btnExtractData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExtractData;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox cbClearOnPostBack;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox rtbProgress;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button btnBrowseCrowler;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCrowler;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TreeView tvAll;
        private System.Windows.Forms.TreeView tvSelected;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

