using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Vibz.Solution.Element;
using Vibz.Contract.Data;
namespace Vibz.Studio.Document
{
    public partial class TestSuite : BaseDocument
    {
        SuiteFile _suite;
        bool _doCellValidation = true;
        public override Document.DocumentType Type { get { return Vibz.Studio.Document.DocumentType.TestSuite; } }
        public override string DocumentName { get { if (_suite == null) return "Untitled Suite"; else return _suite.Name; } }
        TestSuite(string path, Project prj)
            : base(path)
        {
            if (prj == null)
                throw new Exception("Document type test suite can only be accessed within a project.");

            InitializeComponent();
            dgvArguments.CellContentClick += new DataGridViewCellEventHandler(dgvArguments_CellContentClick);
            if (path != null && System.IO.File.Exists(path))
            {
                _path = path;
                _suite = prj.CreateSuite(new FileInfo(path));
                _suite.Load();
                Render();

                if (tvRight.Nodes.Count != 0)
                {
                    tvRight.SelectedNode = tvRight.Nodes[_suite.SuiteElements.Count - 1];
                    ShowProperties();
                }
            }
            else
                _suite = prj.CreateSuite();
            this.Text = DocumentName;
        }
        public static TestSuite Create(Project prj)
        {
            return new TestSuite(null, prj);
        }
        public static TestSuite Open(string path, Project prj)
        {
            return new TestSuite(path, prj);
        }
        public override void Add(IElement element)
        {
            if (element.Type != ElementType.Function && element.Type != ElementType.Suite)
                throw new Exception("Element of '" + element.Type.ToString() + "' can not be added to a suite.");

            _suite.SuiteElements.Add((SuiteElement)element);
            Render();
            _isModified = true;
            ShowProperties();
        }
        public override void Render()
        {
            tvRight.Nodes.Clear();
            tvRight.ImageList = ProjectElementIcons;
            foreach (IElement ele in _suite.SuiteElements)
            {
                TreeNode tn = new TreeNode(ele.FullName);
                tn.Tag = ele;
                tn.ImageIndex = (ele.Type == ElementType.Function ? 0 : 3);
                tn.SelectedImageIndex = tn.ImageIndex;
                tvRight.Nodes.Add(tn);
            }
            if (_suite.SuiteElements.Count != 0)
                tvRight.SelectedNode = tvRight.Nodes[_suite.SuiteElements.Count - 1];
        }
        public SuiteFile Suite
        {
            get { return _suite; }
        }
        void tvRight_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            cmsTV.Items.Clear();
            tvRight.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                ToolStripMenuItem tsi = new ToolStripMenuItem("Properties");
                tsi.MergeAction = MergeAction.Replace;
                tsi.Click += new EventHandler(tsiPropertiesFunction_Click);
                cmsTV.Items.Add(tsi);

                tsi = new ToolStripMenuItem("Delete");
                tsi.MergeAction = MergeAction.Replace;
                tsi.Click += new EventHandler(deleteToolStripMenuItem_Click);
                cmsTV.Items.Add(tsi);

                cmsTV.Show(this.tvRight, e.Location);
            }
            else
                ShowProperties();
        }
        void tsiPropertiesFunction_Click(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(ToolStripMenuItem))
                return;
            ShowProperties();
        }

        void ShowProperties()
        {
            SuiteElement se = (SuiteElement)tvRight.SelectedNode.Tag;
            PopulateProperties(se);
        }

        void PopulateProperties(SuiteElement se)
        {
            _doCellValidation = false;
            dgvArguments.Rows.Clear();
            _doCellValidation = true;
            switch (se.Type)
            {
                case ElementType.Function:
                    foreach (Variable dm in ((Function)se).DataSet.DataList)
                    {
                        DataGridViewRow dgvRow = new DataGridViewRow();

                        DataGridViewCell dgvCell = new DataGridViewTextBoxCell();
                        dgvCell.Value = dm.Name;
                        dgvRow.Cells.Add(dgvCell);

                        dgvCell = new DataGridViewTextBoxCell();
                        dgvCell.Value = dm;

                        dgvRow.Cells.Add(dgvCell);

                        if (!dm.IsInternal)
                        {
                            dgvCell.ReadOnly = true;
                            dgvCell.Style.BackColor = Color.GhostWhite;
                        }
                        dgvArguments.Rows.Add(dgvRow);
                    }
                    if (dgvArguments.Rows.Count > 0)
                    {
                        dgvArguments.Rows[0].Selected = true;
                        DisplayParameter(((Variable)dgvArguments.Rows[0].Cells[1].Value), true);
                    }
                    break;
                case ElementType.Suite:
                    break;
            }
        }
        private void dgvArguments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ArgumentClicked(e);
        }
        void dgvArguments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ArgumentClicked(e);
        }
        void ArgumentClicked(DataGridViewCellEventArgs e)
        {
            _isModified = true;
            DisplayParameter((Variable)dgvArguments[e.ColumnIndex, e.RowIndex].Value, (e.ColumnIndex == 1));        
        }
        void DisplayParameter(Variable dm, bool dodisplay)
        {
            dgvDataParameter.Rows.Clear();
            if (dodisplay && !dm.IsInternal)
            {
                foreach (Parameter param in dm.ParamList)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();

                    DataGridViewCell dgvCell = new DataGridViewTextBoxCell();
                    dgvCell.Value = param.Name;
                    dgvRow.Cells.Add(dgvCell);

                    dgvCell = new DataGridViewTextBoxCell();
                    dgvCell.Value = param.Value;

                    dgvRow.Cells.Add(dgvCell);

                    dgvDataParameter.Rows.Add(dgvRow);
                }
                pnlDataParameter.Visible = true;
                dgvDataParameter.Visible = true;
            }
            else
            {
                dgvDataParameter.Rows.Clear();
                pnlDataParameter.Visible = false;
                dgvDataParameter.Visible = false;
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuiteElement se = (SuiteElement)tvRight.SelectedNode.Tag;
            _suite.SuiteElements.Remove(se);
            _isModified = true;
            Render();
        }

        private void dgvArguments_Leave(object sender, EventArgs e)
        {
            UpdateSuiteElement();
            _isModified = true;
        }

        
        private void dgvDataParameter_Leave(object sender, EventArgs e)
        {
            UpdateCurrentProperty();
            _isModified = true;
        }
        public override void Save() 
        {
            UpdateSuiteElement();
            _suite.Save();
            _isModified = false;
        }
        public override void SaveAs()
        {
            saveFileDialog1.Filter = "Testsuite files (*.ts)|*.ts";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                UpdateSuiteElement();
                _suite.SaveAs(saveFileDialog1.FileName);
            }
            _isModified = false;
        }

   
        private void dgvDataParameter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _isModified = true;
        }
        private void tvRight_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvRight_DragDrop(object sender, DragEventArgs e)
        {
            IElement element = (IElement)e.Data.GetData(typeof(Vibz.Solution.Element.SuiteFile));
            if(element==null)
                element = (IElement)e.Data.GetData(typeof(Vibz.Solution.Element.Function));
            if (element != null)
                Add(element);
        }

        private void tvRight_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void dgvArguments_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (_doCellValidation)
                UpdateCurrentProperty();
        }
        private void dgvArguments_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgvArguments.CurrentCell.Value = dgvArguments.CurrentCell.Tag;
        }
        void UpdateSuiteElement()
        {
            IElement ele = (IElement)tvRight.SelectedNode.Tag;
            switch (ele.Type)
            {
                case ElementType.Function:
                    foreach (DataGridViewRow row in dgvArguments.Rows)
                    {
                        row.Cells[1].Value = GetProperty(row);
                    }
                    break;
                case ElementType.Suite:
                    break;
            }
        }
        void UpdateCurrentProperty()
        {
            dgvArguments.CurrentCell.Value = GetProperty(dgvArguments.CurrentRow);
            dgvArguments.CurrentCell.Tag = dgvArguments.CurrentCell.Value;
        }
        Variable GetProperty(DataGridViewRow row)
        {
            Function func = (Function)tvRight.SelectedNode.Tag;
            if (dgvArguments.CurrentCell == row.Cells[1])
            {
                Variable dm = (Variable)dgvArguments.CurrentCell.Value;
                if (dm.IsInternal)
                    dm.InnerText = dgvArguments.CurrentCell.EditedFormattedValue.ToString();
                else
                    dm = UpdateVariable(dm);
                func.UpdateData(dm);
                return dm;
            }
            else
                return (Variable)row.Cells[1].Value;
        }

        Variable UpdateVariable(Variable var)
        {
            foreach (DataGridViewRow row in dgvDataParameter.Rows)
            {
                if (dgvDataParameter.CurrentCell == row.Cells[1])
                    row.Cells[1].Value = dgvDataParameter.CurrentCell.EditedFormattedValue;
                var.ParamList.GetParameter(row.Cells[0].Value.ToString()).Value = row.Cells[1].Value.ToString();
            }
            return var;
        }
        
    }
}