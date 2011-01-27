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
using System.Reflection;
using Vibz.Interpreter.Plugin;
using Vibz.Contract;

namespace Vibz.Studio
{
    public partial class AboutStudio : Form
    {
        public AboutStudio()
        {
            this.Text = LangResource.TextManager.GetString("Txt_AboutStudio");
            
            InitializeComponent();
            lblStudioVersion.Text += LangResource.TextManager.GetString("Txt_StudioTitle");
            lblStudioVersion.Text += "\r\nVersion: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblStudioVersion.Text += "\r\n" + LangResource.TextManager.GetString("Txt_Copyright");

            lblFrameworkVersion.Text += LangResource.TextManager.GetString("Txt_FrameworkTitle");
            lblFrameworkVersion.Text += "\r\nVersion: " + typeof(Vibz.Contract.IInstruction).Assembly.GetName().Version.ToString();
            lblFrameworkVersion.Text += "\r\n" + LangResource.TextManager.GetString("Txt_Copyright");

            lblAdditionalInfo.Text += "Note: " + LangResource.TextManager.GetString("Txt_License");

            foreach (PluginType pType in new PluginType[] { PluginType.Instruction, PluginType.Macro })
            {
                rtbPlugins.SelectionFont = new Font("Arial", (float)8, FontStyle.Bold);
                rtbPlugins.AppendText(pType.ToString());
                rtbPlugins.SelectionFont = new Font("Arial", (float)8, FontStyle.Regular);
                PluginAssemblyInfo[] list = PluginManager.GetPluginInfoList(pType);
                foreach (PluginAssemblyInfo pInfo in list)
                {
                    rtbPlugins.AppendText("\r\n  " + pInfo.Name);
                    rtbPlugins.SelectionBullet = true;
                }
                rtbPlugins.AppendText("\r\n");
                rtbPlugins.SelectionBullet = false;
            }
            rtbPlugins.SelectionFont = new Font("Arial", (float)8, FontStyle.Bold);
            rtbPlugins.AppendText(PluginType.Report.ToString());
            rtbPlugins.SelectionFont = new Font("Arial", (float)8, FontStyle.Regular);
            List<IReport> listR = PluginManager.GetReportInfoList();
            foreach (IReport rep in listR)
            {
                rtbPlugins.AppendText("\r\n  " + rep.ReportName);
                rtbPlugins.SelectionBullet = true;
            }
            rtbPlugins.AppendText("\r\n");
            rtbPlugins.SelectionBullet = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore", System.Configuration.ConfigurationManager.AppSettings["web"]);
        }
    }
}
