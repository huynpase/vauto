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
            txtLogPath.Text = App.Default.LogPath;

            Array list = Enum.GetValues(typeof(Vibz.Contract.Log.LogSeverity));
            object[] items = new object[list.Length];
            list.CopyTo(items, 0);
            cbLogSeverity.Items.AddRange(items);
            cbLogSeverity.SelectedItem = App.Default.LogSeverity;

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
                App.Default.LogPath = txtLogPath.Text;
                App.Default.LogSeverity = (Vibz.Contract.Log.LogSeverity)cbLogSeverity.SelectedItem;
                App.Default.Save();
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

        private void btnLogPath_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Log files (*.log)|*.log";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLogPath.Text = saveFileDialog1.FileName;
            }
        }
    }
}
