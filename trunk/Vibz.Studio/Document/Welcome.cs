using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vibz.Solution.Element;

namespace Vibz.Studio.Document
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            UserSession us = new UserSession();
            us.Dock = DockStyle.Fill;
            us.Height = 110;
            pnlUserSession.Controls.Add(us);
            lblVersion.Text = "Version : " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            btnRecentProject.Text = App.Default.ProjectLocation;
            btnRecentProject.Tag = App.Default.ProjectLocation;
            
            wbVauto.Navigate(System.Configuration.ConfigurationManager.AppSettings["webhelp"]);
        }

        private void btnRecentProject_Click(object sender, EventArgs e)
        {
            Studio stdMain = (Studio)this.MdiParent;
            stdMain.OpenProject(((Button)sender).Tag.ToString());
        }
    }
}