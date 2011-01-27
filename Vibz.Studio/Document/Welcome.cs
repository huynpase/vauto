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
            if (System.Windows.Forms.SystemInformation.Network)
                NavigateToLink(System.Configuration.ConfigurationManager.AppSettings["webhelp"]);
            else
                NavigateToLink(System.IO.Path.Combine(new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName, System.Configuration.ConfigurationManager.AppSettings["webhelpLocal"]));
        }
        private delegate void ObjectDelegate(string url);
        public void NavigateToLink(string url)
        {
            if (wbVauto.InvokeRequired)
            {
                ObjectDelegate method = new ObjectDelegate(NavigateToLink);
                Invoke(method, url);
            }
            else
            {
                wbVauto.Navigate(url);
            }
        }
        private void btnRecentProject_Click(object sender, EventArgs e)
        {
            Studio stdMain = (Studio)this.MdiParent;
            //System.Threading.Thread tProjectLoader = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(stdMain.OpenProject));
            //tProjectLoader.Start(((Button)sender).Tag.ToString());
            stdMain.OpenProject(((Button)sender).Tag.ToString());
        }
    }
}
