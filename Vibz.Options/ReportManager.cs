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

namespace Vibz.Options
{
    public partial class ReportManager : UserControl
    {
        public ReportManager()
        {
            InitializeComponent();
            LoadPligin();
        }
        void LoadPligin()
        {
            try
            {
                tvPlugin.Nodes.Clear();
                List<IReport> list = PluginManager.GetReportInfoList();
                if (list.Count == 0)
                    return;

                foreach (IReport rep in list)
                {
                    TreeNode tn = new TreeNode(rep.ReportName);
                    tn.Tag = rep;
                    tvPlugin.Nodes.Add(tn);
                }
                if (tvPlugin.Nodes.Count > 0)
                    ShowConfigurations((IReport)tvPlugin.Nodes[0].Tag);

                tvPlugin.ImageList = imageList1;

                LogQueue.Instance.Enqueue(new LogQueueElement("Report plugins loaded successfully.", LogSeverity.Trace));

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
        }

        void ShowConfigurations(IReport report)
        {
            dgConfiguration.Rows.Clear();
            if (report == null || report.Configuration == null || report.Configuration.Count == 0)
                return;
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
    }
}
