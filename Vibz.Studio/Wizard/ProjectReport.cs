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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Vibz.Studio.Wizard
{
    public partial class ProjectReport : Wizard
    {
        public const string FolderPath = "Folder Path";
        public const string Overwrite = "Overwrite";
        public ProjectReport()
        {
            InitializeComponent();
            lblInfo.Text = "If you select to overwrite past report, the selected folder will be updated with the latest report.\r\ni.e. Past reports will be lost.\r\n To preserve past reports uncheck this control. \r\nNew report will be created using timestamp every time a test is executed.";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFolderPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        public override void Init(WizardParams parameters)
        {
            _parameters = parameters;
            if (parameters == null)
                return;

            if (!parameters.ContainsKey(ProjectReport.FolderPath))
                throw new Exception(ProjectReport.FolderPath + " is missing.");
            txtFolderPath.Text = parameters[ProjectReport.FolderPath].ToString();

            if (!parameters.ContainsKey(ProjectReport.Overwrite))
                throw new Exception(ProjectReport.Overwrite + " is missing.");
            bool addTimestamp = true;
            bool.TryParse(parameters[ProjectReport.Overwrite].ToString(), out addTimestamp);
            cbTimestamp.Checked = addTimestamp;

            return;
        }
        public override bool CanNavigate(ref List<string> errors)
        {
            errors = new List<string>();
            
            if (txtFolderPath.Text.Trim() == "")
                errors.Add("Folder path for report can not be empty.");
            
            if (errors.Count != 0)
                return false;

            return true;
        }
        public override WizardParams Parameters
        {
            get
            {
                _parameters = new WizardParams();
                string folderPath = txtFolderPath.Text;
                if (!cbTimestamp.Checked)
                    folderPath += "\\{DATETIMESTAMP}";
                _parameters.Add(ProjectReport.FolderPath, folderPath);
                _parameters.Add(ProjectReport.Overwrite, cbTimestamp.Checked);
                return _parameters;
            }
        }
        public override string Title
        {
            get { return "Report Location"; }
        }
    }
}
