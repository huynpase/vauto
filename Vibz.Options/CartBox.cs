using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vibz.Interpreter.Plugin;
using Vibz.Interpreter;
using Vibz.Plugin;
using Vibz.Contract;
using Vibz.Contract.Log;

namespace Vibz.Options
{
    public partial class CartBox : UserControl
    {
        public string NewPath = "Plugin path";
        PluginType _type = PluginType.Instruction;
        public CartBox(PluginType type)
        {
            InitializeComponent();
            tvProperties.ImageList = imageList1;
            LoadPlugins(type);

            _type = type;
        }

        private void LoadPlugins(PluginType type)
        {
            try
            {
                tvPlugin.Nodes.Clear();
                PluginAssemblyInfo[] list = PluginManager.GetPluginInfoList(type);
                if (list == null)
                    return;
                tvPlugin.ImageList = imageList1;
                int imgIndex = 0;
                switch (type)
                {
                    case PluginType.Instruction:
                    case PluginType.Macro:
                        imgIndex = 4;
                        break;
                }
                foreach (PluginAssemblyInfo tList in list)
                {
                    TreeNode tn = new TreeNode(tList.Name);
                    tn.ImageIndex = imgIndex;
                    tn.SelectedImageIndex = tn.ImageIndex;
                    tn.Tag = tList;
                    tvPlugin.Nodes.Add(tn);
                }
                if (tvPlugin.Nodes.Count > 0)
                    ShowDetails(tvPlugin.Nodes[0]);

                LogQueue.Instance.Enqueue(new LogQueueElement(type.ToString() + " type plugins loaded successfully.", LogSeverity.Info));

            }
            catch (Exception exc)
            {
                Vibz.Contract.Log.LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement("Error occured while loading plugins. " + exc.Message, Vibz.Contract.Log.LogSeverity.Error));
            }
        }
        private void tvPlugin_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowDetails(e.Node);
        }
        void ShowDetails(TreeNode nodePlugin)
        {
            try
            {
                PluginAssemblyInfo plug = (PluginAssemblyInfo)nodePlugin.Tag;
                ShowComponents(plug);
                ShowConfigurations(plug);
            }
            catch (Exception exc)
            {
                lblInfo.Text = "Invalid plugin. " + exc.Message;
            }
        }
        void ShowComponents(PluginAssemblyInfo plug)
        {
            tvProperties.Nodes.Clear();
            if (plug == null || plug.Count == 0)
                return;
            foreach (string key in plug.Keys)
            {
                TreeNode tn = new TreeNode(plug[key].TypeName);
                tn.Tag = plug[key];
                switch (plug[key].InterfaceName.ToLower())
                {
                    case "iaction":
                        tn.ImageIndex = 1;
                        break;
                    case "iassert":
                        tn.ImageIndex = 2;
                        break;
                    case "ifetch":
                        tn.ImageIndex = 0;
                        break;
                    case "imacrovariable":
                        tn.ImageIndex = 5;
                        break;
                    case "imacrofunction":
                        tn.ImageIndex = 6;
                        break;
                }
                tn.SelectedImageIndex = tn.ImageIndex;
                tvProperties.Nodes.Add(tn);
            }
            if (tvProperties.Nodes.Count > 0)
                ShowInfo(tvProperties.Nodes[0]);
        }

        void ShowConfigurations(PluginAssemblyInfo plug)
        {
            dgConfiguration.Rows.Clear();
            if (plug == null || plug.Settings == null || plug.Settings.Count == 0)
                return;
            foreach (string key in plug.Settings.Keys)
            {
                DataGridViewRow dgvRow = new DataGridViewRow();

                DataGridViewCell dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = key;
                dgvRow.Cells.Add(dgvCell);

                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = (plug.Settings[key] == null ? "" : plug.Settings[key].ToString());
                dgvRow.Cells.Add(dgvCell);

                dgConfiguration.Rows.Add(dgvRow);
            }
        }
        void tvProperties_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowInfo(e.Node);
        }

        void ShowInfo(TreeNode nodeType)
        {
            lblInfo.Clear();
            FunctionTypeInfo type = (FunctionTypeInfo)nodeType.Tag;
            if (type == null)
                return;
            //lblInfo.AppendText(type.TypeName + ": Information not available.");
            lblInfo.Clear();
            lblInfo.SelectionBullet = false;
            lblInfo.SelectionColor = Color.DarkGreen;
            lblInfo.SelectionFont = new Font("Arial", (float)8, FontStyle.Bold);
            lblInfo.AppendText(type.TypeName);
            lblInfo.AppendText("\r\n");
            lblInfo.SelectionBullet = true;
            lblInfo.SelectionFont = new Font("Arial", (float)8, FontStyle.Bold);
            lblInfo.AppendText("Version: ");
            lblInfo.SelectionFont = new Font("Arial", (float)8, FontStyle.Regular);
            lblInfo.AppendText(type.Information.Version);
            lblInfo.SelectionFont = new Font("Arial", (float)8, FontStyle.Bold);
            lblInfo.AppendText("\r\n Details: ");
            lblInfo.SelectionFont = new Font("Arial", (float)8, FontStyle.Regular);
            lblInfo.AppendText(type.Information.Details);
        }
    }
}
