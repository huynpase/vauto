using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vibz.Interpreter.Plugin;
using Vibz.Interpreter;
using Vibz.Plugin;
using Vibz.Contract;
using Vibz.Contract.Log;
using Vibz.Solution.Element;

namespace Vibz.Studio
{
    public partial class ReportManager : UserControl
    {
        Project _project;
        public ReportManager(Project project)
        {
            InitializeComponent();
            _project = project;
            LoadAvailableReports();
            LoadProjectReports();
        }
        void LoadAvailableReports()
        {
            try
            {
                tvAvailableReport.Nodes.Clear();
                List<IReport> list = PluginManager.GetReportInfoList();
                if (list.Count == 0)
                    return;

                foreach (IReport rep in list)
                {
                    TreeNode tn = new TreeNode(rep.ReportName);
                    tn.Tag = rep;
                    tvAvailableReport.Nodes.Add(tn);
                }
                
                tvAvailableReport.ImageList = imageList1;

                LogQueue.Instance.Enqueue(new LogQueueElement("Available reports loaded successfully.", LogSeverity.Trace));

            }
            catch (Exception exc)
            {
                Vibz.Contract.Log.LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement("Error occured while loading report plugins. " + exc.Message, Vibz.Contract.Log.LogSeverity.Error));
            }
        }

        void LoadProjectReports()
        {
            try
            {
                tvPlugin.Nodes.Clear();
                List<IReport> list = _project.AppConfig.ReportList;
                if (list.Count == 0)
                    return;
                tvPlugin.ImageList = imageList1;

                foreach (IReport rep in list)
                {
                    TreeNode tn = new TreeNode(rep.ReportName);
                    tn.Tag = rep;
                    if (rep.Status == ReportStatus.Active)
                        tn.ImageIndex = 2;
                    else tn.ImageIndex = 1;
                    tn.SelectedImageIndex = tn.ImageIndex;
                    tvPlugin.Nodes.Add(tn);
                }
                if (tvAvailableReport.Nodes.Count > 0)
                {
                    tvPlugin.SelectedNode = tvPlugin.Nodes[0];
                    ShowConfigurations((IReport)tvPlugin.Nodes[0].Tag);
                }


                LogQueue.Instance.Enqueue(new LogQueueElement("Project reports loaded successfully.", LogSeverity.Trace));

            }
            catch (Exception exc)
            {
                Vibz.Contract.Log.LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement("Error occured while loading report plugins. " + exc.Message, Vibz.Contract.Log.LogSeverity.Error));
            }
        }

        private void tvPlugin_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            IReport rep = (IReport)e.Node.Tag;
            ShowConfigurations(rep);
            tsbRemoveReport.Enabled = true;
            tsbActivate.Enabled = (rep.Status != ReportStatus.Active);
            tsbDeactivate.Enabled = (rep.Status == ReportStatus.Active);
        }

        private void tvPlugin_Leave(object sender, EventArgs e)
        {
            tsbRemoveReport.Enabled = false;
            tsbActivate.Enabled = false;
            tsbDeactivate.Enabled = false;
        }

        void ShowConfigurations(IReport report)
        {
            dgConfiguration.Rows.Clear();
            if (report == null || report.Configuration == null || report.Configuration.Count == 0)
            {
                btnSaveConfiguration.Enabled = false;
                return;
            }
            btnSaveConfiguration.Enabled = true;
            foreach (string key in report.Configuration.Keys)
            {
                DataGridViewRow dgvRow = new DataGridViewRow();

                DataGridViewCell dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = key;
                dgvRow.Cells.Add(dgvCell);

                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = (report.Configuration[key] == null ? "" : report.Configuration[key].ToString());
                dgvRow.Cells.Add(dgvCell);

                dgConfiguration.Rows.Add(dgvRow);
            }
        }

        private void tvAvailableReport_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tsbAddReport.Enabled = true;
        }

        private void tvAvailableReport_Leave(object sender, EventArgs e)
        {
            tsbAddReport.Enabled = false;
        }
        private void tsbAddReport_Click(object sender, EventArgs e)
        {
            bool isAdded = false;
            IReport report = (IReport)tvAvailableReport.SelectedNode.Tag;
            foreach (TreeNode tn in tvPlugin.Nodes)
            {
                if (((IReport)tn.Tag).ReportName == report.ReportName)
                {
                    isAdded = true;
                    break;
                }
            }
            if (isAdded)
            {
                ShowMessageBox("Selected report is already added to this project.");
                return;
            }
            _project.AppConfig.AddReport(report);
            LoadProjectReports();
            lblMessage.Text = "Selected report added to the project successfully.";
        }
        
        private void tsbRemoveReport_Click(object sender, EventArgs e)
        {
            IReport report = (IReport)tvPlugin.SelectedNode.Tag;
            _project.AppConfig.RemoveReport(report);
            LoadProjectReports();
            lblMessage.Text = "Selected report removed from the project successfully.";
        }

        private void tsbActivate_Click(object sender, EventArgs e)
        {
            IReport report = (IReport)tvPlugin.SelectedNode.Tag;
            _project.AppConfig.SetReportStatus(report, true);
            LoadProjectReports();
            lblMessage.Text = "Selected report activated successfully.";
        }

        private void tsbDeactivate_Click(object sender, EventArgs e)
        {
            IReport report = (IReport)tvPlugin.SelectedNode.Tag;
            _project.AppConfig.SetReportStatus(report, false);
            LoadProjectReports();
            lblMessage.Text = "Selected report deactivated successfully.";
        }

        private void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
            IReport report = (IReport)tvPlugin.SelectedNode.Tag;
            Dictionary<string, string> param = new Dictionary<string, string>();
            foreach (DataGridViewRow dr in dgConfiguration.Rows)
            {
                param.Add(dr.Cells[0].Value.ToString(), dr.Cells[1].Value.ToString());
            }
            _project.AppConfig.SetParameters(report, param);
            LoadProjectReports();
            lblMessage.Text = "Changes to configuration parameters are saved successfully.";
        }

        #region Common Function
        void ShowMessageBox(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion


    }
}
