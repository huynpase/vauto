using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Vibz.Studio.Wizard
{
    public partial class ProjectSettings : Wizard
    {
        public const string BuildPath = "Build Path";
        public ProjectSettings()
        {
            InitializeComponent();
            txtBuildLocation.Text = System.Configuration.ConfigurationManager.AppSettings["defaultBuildPath"];
            lblInfo.Text = "Build path will be relative to project path.";
        }
        public override void Init(WizardParams parameters)
        {
            _parameters = parameters;
            if (parameters == null)
                return;

            if (!parameters.ContainsKey(ProjectSettings.BuildPath))
                throw new Exception(ProjectSettings.BuildPath + " is missing.");

            txtBuildLocation.Text = parameters[ProjectSettings.BuildPath].ToString();
            return;
        }
        public override bool CanNavigate(ref List<string> errors)
        {
            errors = new List<string>();
            if (txtBuildLocation.Text.Trim() == "")
                errors.Add("Build path can not be empty.");

            if (txtBuildLocation.Text.IndexOfAny(new char[] { ':', '*', '?', '"', '<', '>', '|' }) != -1)
                errors.Add("Build path can not have special characters.");

            if (errors.Count != 0)
                return false;

            return true;
        }
        public override WizardParams Parameters
        {
            get
            {
                _parameters = new WizardParams();
                _parameters.Add(ProjectSettings.BuildPath, txtBuildLocation.Text);
                return _parameters;
            }
        }
        public override string Title
        {
            get { return "Project Settings"; }
        }
    }
}
