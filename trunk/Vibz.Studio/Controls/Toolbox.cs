using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vibz.Interpreter.Plugin;
using Vibz.Contract.Attribute;

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
            PluginAssemblyInfo[] list = PluginManager.GetPluginInfoList(PluginType.Instruction);
            foreach (PluginAssemblyInfo pInfo in list)
            {
                TreeNode tn = new TreeNode(pInfo.Name);
                tn.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                tn.Tag = pInfo;

                foreach (string key in pInfo.Keys)
                {
                    FunctionTypeInfo ftInfo = pInfo[key];
                    TreeNode tnIns = new TreeNode(ftInfo.TypeName);
                    tnIns.Tag = ftInfo;
                    switch (pInfo[key].Type.ToLower())
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
                    tnIns.SelectedImageIndex = tnIns.ImageIndex;
                    tn.Nodes.Add(tnIns);
                }
                tn.SelectedImageIndex = tn.ImageIndex;
                tvContainer.Nodes.Add(tn);
            }
            tvContainer.ExpandAll();
        }

        private void tvContainer_ItemDrag(object sender, ItemDragEventArgs e)
        {
            tvContainer.SelectedNode = (TreeNode)e.Item;
            FunctionTypeInfo inst = (FunctionTypeInfo)((TreeNode)e.Item).Tag;
            if (inst != null)
                ((TreeView)sender).DoDragDrop(inst, DragDropEffects.Move);
        }
    }
}
