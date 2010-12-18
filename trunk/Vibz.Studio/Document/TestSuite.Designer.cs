namespace Vibz.Studio.Document
{
    partial class TestSuite
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestSuite));
            this.tvRight = new System.Windows.Forms.TreeView();
            this.ProjectElementIcons = new System.Windows.Forms.ImageList(this.components);
            this.cmsTV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvArguments = new System.Windows.Forms.DataGridView();
            this.ArgumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArgumentValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDataParameter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDataParameter = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArguments)).BeginInit();
            this.pnlDataParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataParameter)).BeginInit();
            this.SuspendLayout();
            // 
            // tvRight
            // 
            this.tvRight.AllowDrop = true;
            this.tvRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRight.FullRowSelect = true;
            this.tvRight.HideSelection = false;
            this.tvRight.Location = new System.Drawing.Point(0, 0);
            this.tvRight.Name = "tvRight";
            this.tvRight.Size = new System.Drawing.Size(242, 279);
            this.tvRight.TabIndex = 1;
            this.tvRight.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvRight_DragDrop);
            this.tvRight.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvRight_NodeMouseClick);
            this.tvRight.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvRight_DragEnter);
            this.tvRight.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvRight_ItemDrag);
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
            // 
            // cmsTV
            // 
            this.cmsTV.Name = "cmsTV";
            this.cmsTV.Size = new System.Drawing.Size(61, 4);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvRight);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(429, 279);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(183, 279);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvArguments);
            this.tabPage1.Controls.Add(this.pnlDataParameter);
            this.tabPage1.Controls.Add(this.dgvDataParameter);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(175, 253);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DataSet";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvArguments
            // 
            this.dgvArguments.AllowUserToAddRows = false;
            this.dgvArguments.AllowUserToDeleteRows = false;
            this.dgvArguments.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvArguments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvArguments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ArgumentName,
            this.ArgumentValue});
            this.dgvArguments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArguments.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvArguments.Location = new System.Drawing.Point(3, 3);
            this.dgvArguments.Name = "dgvArguments";
            this.dgvArguments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvArguments.RowHeadersVisible = false;
            this.dgvArguments.Size = new System.Drawing.Size(169, 134);
            this.dgvArguments.TabIndex = 1;
            this.dgvArguments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArguments_CellClick);
            this.dgvArguments.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArguments_CellValidated);
            this.dgvArguments.Leave += new System.EventHandler(this.dgvArguments_Leave);
            this.dgvArguments.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvArguments_CellValidating);
            // 
            // ArgumentName
            // 
            this.ArgumentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ArgumentName.HeaderText = "Name";
            this.ArgumentName.Name = "ArgumentName";
            this.ArgumentName.ReadOnly = true;
            // 
            // ArgumentValue
            // 
            this.ArgumentValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ArgumentValue.HeaderText = "Value";
            this.ArgumentValue.Name = "ArgumentValue";
            // 
            // pnlDataParameter
            // 
            this.pnlDataParameter.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDataParameter.Controls.Add(this.label1);
            this.pnlDataParameter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDataParameter.Location = new System.Drawing.Point(3, 137);
            this.pnlDataParameter.Name = "pnlDataParameter";
            this.pnlDataParameter.Size = new System.Drawing.Size(169, 24);
            this.pnlDataParameter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Parameters";
            // 
            // dgvDataParameter
            // 
            this.dgvDataParameter.AllowUserToAddRows = false;
            this.dgvDataParameter.AllowUserToDeleteRows = false;
            this.dgvDataParameter.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvDataParameter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDataParameter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvDataParameter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDataParameter.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvDataParameter.Location = new System.Drawing.Point(3, 161);
            this.dgvDataParameter.Name = "dgvDataParameter";
            this.dgvDataParameter.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDataParameter.RowHeadersVisible = false;
            this.dgvDataParameter.Size = new System.Drawing.Size(169, 89);
            this.dgvDataParameter.TabIndex = 2;
            this.dgvDataParameter.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataParameter_CellClick);
            this.dgvDataParameter.Leave += new System.EventHandler(this.dgvDataParameter_Leave);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // TestSuite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 279);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestSuite";
            this.Text = "Test Suite";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArguments)).EndInit();
            this.pnlDataParameter.ResumeLayout(false);
            this.pnlDataParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataParameter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvRight;
        private System.Windows.Forms.ImageList ProjectElementIcons;
        private System.Windows.Forms.ContextMenuStrip cmsTV;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvArguments;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArgumentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArgumentValue;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dgvDataParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Panel pnlDataParameter;
        private System.Windows.Forms.Label label1;
    }
}