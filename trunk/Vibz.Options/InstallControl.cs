using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vibz.Contract.Log;

namespace Vibz.Options
{
    public partial class InstallControl : UserControl
    {
        public delegate void PostInstallationEvent();
        PostInstallationEvent _pie;
        public InstallControl(PostInstallationEvent pEvent)
        {
            InitializeComponent();
            _pie = pEvent;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Automation Plugin files (*.zip)|*.zip";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txtPath.Text = openFileDialog1.FileName;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPath.Text.Trim() == "")
                    throw new Exception("Please select a valid plugin path to install.");
                if (!System.IO.File.Exists(txtPath.Text))
                    throw new Exception("Invalid Plugin path.");
                Vibz.Plugin.PluginProcessor pProcessor = new Vibz.Plugin.PluginProcessor(txtPath.Text);
                pProcessor.Execute();
                _pie();
                LogQueue.Instance.Enqueue(new LogQueueElement("Plugin installed successfully.", LogSeverity.Trace));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
