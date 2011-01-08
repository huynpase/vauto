using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vibz.Interpreter.Plugin;
using Vibz.Contract.Attribute;
using Vibz.Contract;

namespace Vibz.Studio.Controls
{
    public partial class Toolbox : UserControl
    {
        public Toolbox()
        {
            InitializeComponent();
            PopulateInstructions();
        }
        public void PopulateInstructions()
        {
            TreeNode tn = new TreeNode("Common");
            tn.BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
            tn.ForeColor = Color.FromKnownColor(KnownColor.White);
            //tn.Tag = pInfo;
            foreach (FunctionTypeInfo ftInfo in Vibz.Interpreter.Configuration.InstructionManager.InternalInstructions)
            {
                if (ftInfo.Information.HasIndeviduality)
                    tn.Nodes.Add(GetInstructionNode(ftInfo));
            }
            tn.ImageIndex = 4;
            tn.SelectedImageIndex = tn.ImageIndex;
            tvContainer.Nodes.Add(tn);

            PluginAssemblyInfo[] list = PluginManager.GetPluginInfoList(PluginType.Instruction);
            foreach (PluginAssemblyInfo pInfo in list)
            {
                tn = new TreeNode(pInfo.Name);
                tn.BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
                tn.ForeColor = Color.FromKnownColor(KnownColor.White);
                tn.Tag = pInfo;

                foreach (string key in pInfo.Keys)
                {
                    if (pInfo[key].Information.HasIndeviduality)
                        tn.Nodes.Add(GetInstructionNode(pInfo[key]));
                }
                tn.ImageIndex = 4;
                tn.SelectedImageIndex = tn.ImageIndex;
                tvContainer.Nodes.Add(tn);
            }

            tvContainer.ExpandAll();
            tvContainer.ShowNodeToolTips = true;
        }
        TreeNode GetInstructionNode(FunctionTypeInfo ftInfo)
        {
            TreeNode tnIns = new TreeNode(ftInfo.TypeName);
            tnIns.Tag = ftInfo;
            switch (ftInfo.Type.ToLower())
            {
                case "action":
                    tnIns.ImageIndex = 1;
                    break;
                case "assert":
                    tnIns.ImageIndex = 2;
                    break;
                case "fetch":
                    tnIns.ImageIndex = 0;
                    break;
            }
            tnIns.ToolTipText = ReframeText(ftInfo.Information.Details, 50);
            tnIns.SelectedImageIndex = tnIns.ImageIndex;
            return tnIns;
        }
        string ReframeText(string text, int length)
        { 
            int i=0;
            string retValue = "";
            while (true)
            {
                if (i + length >= text.Length)
                {
                    retValue += text.Substring(i);
                    break;
                }
                int j = text.IndexOfAny(new char[] { ' ', '\t' }, i + length);
                if (j == -1)
                {
                    retValue += text.Substring(i);
                    break;
                }

                retValue += text.Substring(i, j - i) + "\r\n";
                i = j;
            }

            return retValue.Trim();
        }
        private void tvContainer_ItemDrag(object sender, ItemDragEventArgs e)
        {
            tvContainer.SelectedNode = (TreeNode)e.Item;
            if (((TreeNode)e.Item).Tag != null)
                ((TreeView)sender).DoDragDrop(((TreeNode)e.Item).Tag, DragDropEffects.Move);
        }
    }
}
