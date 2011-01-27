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
using Vibz.Contract.Log;

namespace Vibz.Options
{
    public partial class Main : Form
    {
        string _errorMessage = "";
        public Main()
        {
            InitializeComponent();
            timerStatus.Tick+=new EventHandler(timerStatus_Tick);
            timerStatus.Start();

            InstallControl ic = new InstallControl(new InstallControl.PostInstallationEvent(Load));
            ic.Dock = DockStyle.Fill;
            pnlInstallControl.Controls.Add(ic);

            Load();
        }
        public void Load()
        {
            try
            {
                tpInstruction.Controls.Clear();
                CartBox cb = new CartBox(Vibz.Interpreter.Plugin.PluginType.Instruction);
                cb.Dock = DockStyle.Fill;
                tpInstruction.Controls.Add(cb);

                tpMacro.Controls.Clear();
                cb = new CartBox(Vibz.Interpreter.Plugin.PluginType.Macro);
                cb.Dock = DockStyle.Fill;
                tpMacro.Controls.Add(cb);

                tpReport.Controls.Clear();
                ReportManager rm = new ReportManager();
                rm.Dock = DockStyle.Fill;
                tpReport.Controls.Add(rm);

                lblStatus.Click += new EventHandler(lblStatus_Click);

                LogQueue.Instance.Enqueue(new LogQueueElement("Plugin information loaded successfully.", LogSeverity.Trace));
            }
            catch (Exception exception)
            {
                LogQueue.Instance.Enqueue(new LogQueueElement("Plugin information could not be loaded. " + exception.Message, LogSeverity.Error));            
            }
        }

        void lblStatus_Click(object sender, EventArgs e)
        {
            if (_errorMessage != "")
                MessageBox.Show(_errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region Log
        private void UpdateProgress()
        {
            while (LogQueue.Instance.Count > 0)
            {
                LogQueueElement ele = LogQueue.Instance.Dequeue();
                lblStatus.Text = ele.Message;
                switch (ele.Severity)
                {
                    case LogSeverity.Trace:
                    case LogSeverity.Warn:
                        break;
                    case LogSeverity.Error:
                        lblStatus.Text = "Done with error. Click here to see error message.";
                        _errorMessage = ele.Message + "\r\n" + _errorMessage;
                        break;
                    default:
                        break;
                }
            }
        }
        void timerStatus_Tick(object sender, EventArgs e)
        {
            UpdateProgress();
        }
        #endregion
    }
}
