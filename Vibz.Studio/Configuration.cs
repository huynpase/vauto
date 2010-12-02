using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vibz.Solution.Element;

namespace Vibz.Studio
{
    public partial class Configuration : Form
    {
        Project _project;
        public Configuration(Project project)
        {
            InitializeComponent();

            _project = project;
            LoadConfigurations();
        }
        void LoadConfigurations()
        {
            txtBuildPath.Text = _project.BuildLocation;
            txtReportPath.Text = _project.ReportDirectory;

            tpReport.Controls.Clear();
            ReportManager rm = new ReportManager(_project);
            rm.Dock = DockStyle.Fill;
            tpReport.Controls.Add(rm);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add(Project.BuildPath, txtBuildPath.Text.Replace('/', '\\'));
                param.Add(Project.ReportPath, txtReportPath.Text.Replace('/', '\\'));
                _project.Reset(param);
                MessageBox.Show("Changes have been saved successfully", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: "+exc.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }
        }

        private void btnBuildBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBuildPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnReportBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtReportPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}