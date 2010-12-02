namespace Vibz.Studio
{
    partial class ReportManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportManager));
            this.tvPlugin = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbRemoveReport = new System.Windows.Forms.ToolStripButton();
            this.tsbActivate = new System.Windows.Forms.ToolStripButton();
            this.tsbDeactivate = new System.Windows.Forms.ToolStripButton();
            this.dgConfiguration = new System.Windows.Forms.DataGridView();
            this.configName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configvalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSaveConfiguration = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddReport = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvAvailableReport = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConfiguration)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvPlugin
            // 
            this.tvPlugin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPlugin.Location = new System.Drawing.Point(0, 25);
            this.tvPlugin.Name = "tvPlugin";
            this.tvPlugin.Size = new System.Drawing.Size(154, 108);
            this.tvPlugin.TabIndex = 3;
            this.tvPlugin.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPlugin_NodeMouseClick);
            this.tvPlugin.Leave += new System.EventHandler(this.tvPlugin_Leave);
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
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgConfiguration);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(325, 133);
            this.splitContainer1.SplitterDistance = 154;
            this.splitContainer1.TabIndex = 5;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRemoveReport,
            this.tsbActivate,
            this.tsbDeactivate});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(154, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // tsbRemoveReport
            // 
            this.tsbRemoveReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveReport.Enabled = false;
            this.tsbRemoveReport.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveReport.Image")));
            this.tsbRemoveReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveReport.Name = "tsbRemoveReport";
            this.tsbRemoveReport.Size = new System.Drawing.Size(23, 22);
            this.tsbRemoveReport.Text = "Remove project report";
            this.tsbRemoveReport.ToolTipText = "Remove project report";
            this.tsbRemoveReport.Click += new System.EventHandler(this.tsbRemoveReport_Click);
            // 
            // tsbActivate
            // 
            this.tsbActivate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbActivate.Enabled = false;
            this.tsbActivate.Image = ((System.Drawing.Image)(resources.GetObject("tsbActivate.Image")));
            this.tsbActivate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActivate.Name = "tsbActivate";
            this.tsbActivate.Size = new System.Drawing.Size(23, 22);
            this.tsbActivate.Text = "Activate Report";
            this.tsbActivate.Click += new System.EventHandler(this.tsbActivate_Click);
            // 
            // tsbDeactivate
            // 
            this.tsbDeactivate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeactivate.Enabled = false;
            this.tsbDeactivate.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeactivate.Image")));
            this.tsbDeactivate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeactivate.Name = "tsbDeactivate";
            this.tsbDeactivate.Size = new System.Drawing.Size(23, 22);
            this.tsbDeactivate.Text = "Deactivate Report";
            this.tsbDeactivate.Click += new System.EventHandler(this.tsbDeactivate_Click);
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
            this.dgConfiguration.Location = new System.Drawing.Point(0, 25);
            this.dgConfiguration.Name = "dgConfiguration";
            this.dgConfiguration.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgConfiguration.RowHeadersVisible = false;
            this.dgConfiguration.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgConfiguration.Size = new System.Drawing.Size(167, 108);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.btnSaveConfiguration);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 25);
            this.panel2.TabIndex = 5;
            // 
            // btnSaveConfiguration
            // 
            this.btnSaveConfiguration.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveConfiguration.Enabled = false;
            this.btnSaveConfiguration.FlatAppearance.BorderSize = 0;
            this.btnSaveConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveConfiguration.Image")));
            this.btnSaveConfiguration.Location = new System.Drawing.Point(144, 0);
            this.btnSaveConfiguration.Name = "btnSaveConfiguration";
            this.btnSaveConfiguration.Size = new System.Drawing.Size(23, 25);
            this.btnSaveConfiguration.TabIndex = 2;
            this.btnSaveConfiguration.UseVisualStyleBackColor = true;
            this.btnSaveConfiguration.Click += new System.EventHandler(this.btnSaveConfiguration_Click);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(0, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Project Reports";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "report.ico");
            this.imageList1.Images.SetKeyName(1, "Inactive.ico");
            this.imageList1.Images.SetKeyName(2, "Active.ico");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddReport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 13);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(325, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // tsbAddReport
            // 
            this.tsbAddReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddReport.Enabled = false;
            this.tsbAddReport.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddReport.Image")));
            this.tsbAddReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddReport.Name = "tsbAddReport";
            this.tsbAddReport.Size = new System.Drawing.Size(23, 22);
            this.tsbAddReport.Text = "Add to Project";
            this.tsbAddReport.ToolTipText = "Add to project";
            this.tsbAddReport.Click += new System.EventHandler(this.tsbAddReport_Click);
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
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer2.Panel1.Controls.Add(this.tvAvailableReport);
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(325, 219);
            this.splitContainer2.SplitterDistance = 82;
            this.splitContainer2.TabIndex = 6;
            // 
            // tvAvailableReport
            // 
            this.tvAvailableReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAvailableReport.Location = new System.Drawing.Point(0, 38);
            this.tvAvailableReport.Name = "tvAvailableReport";
            this.tvAvailableReport.Size = new System.Drawing.Size(325, 31);
            this.tvAvailableReport.TabIndex = 4;
            this.tvAvailableReport.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvAvailableReport_NodeMouseClick);
            this.tvAvailableReport.Leave += new System.EventHandler(this.tvAvailableReport_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Available Reports";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 219);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(325, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // ReportManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ReportManager";
            this.Size = new System.Drawing.Size(325, 241);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConfiguration)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvPlugin;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgConfiguration;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView tvAvailableReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbRemoveReport;
        private System.Windows.Forms.ToolStripButton tsbAddReport;
        private System.Windows.Forms.Button btnSaveConfiguration;
        private System.Windows.Forms.DataGridViewTextBoxColumn configName;
        private System.Windows.Forms.DataGridViewTextBoxColumn configvalue;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.ToolStripButton tsbActivate;
        private System.Windows.Forms.ToolStripButton tsbDeactivate;
    }
}
