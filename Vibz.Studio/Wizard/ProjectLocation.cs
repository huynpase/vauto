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
    public partial class ProjectLocation : Wizard
    {
        public const string FolderPath = "Folder Path";
        public const string ProjectName = "Prject Name";
        public ProjectLocation()
        {
            InitializeComponent();
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
            if(parameters==null)
                return;

            if (!parameters.ContainsKey(ProjectLocation.FolderPath))
                throw new Exception(ProjectLocation.FolderPath + " is missing.");

            if (!parameters.ContainsKey(ProjectLocation.ProjectName))
                throw new Exception(ProjectLocation.ProjectName + " is missing.");

            txtProjectName.Text = parameters[ProjectLocation.ProjectName].ToString();
            txtFolderPath.Text = parameters[ProjectLocation.FolderPath].ToString();
            return;
        }
        public override bool CanNavigate(ref List<string> errors)
        {
            errors = new List<string>();
            if (txtProjectName.Text.Trim() == "")
                errors.Add("Project name can not be empty.");
            else if (txtProjectName.Text.IndexOfAny(new char[] { '/', '\\', ':', '*', '?', '"', '<', '>', '|' }) != -1)
                errors.Add("Project name can not have special characters.");

            if(txtFolderPath.Text.Trim()=="")
                errors.Add("Folder path for project can not be empty.");
            else if(!System.IO.Directory.Exists(txtFolderPath.Text))
                errors.Add("Folder path should be a valid directory location.");

            if (errors.Count != 0)
                return false;

            return true;
        }
        public override WizardParams Parameters
        {
            get {
                _parameters = new WizardParams();
                _parameters.Add(ProjectLocation.ProjectName, txtProjectName.Text);
                _parameters.Add(ProjectLocation.FolderPath, txtFolderPath.Text);
                return _parameters; 
            }
        }
        public override string Title
        {
            get { return "Project Location"; }
        }
    }
}
