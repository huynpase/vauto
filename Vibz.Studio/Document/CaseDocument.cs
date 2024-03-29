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
using System.IO;
using System.Xml;
using System.Windows.Forms;
using Vibz.Solution.Element;
using Vibz.Contract.Attribute;
using Vibz.Studio.Document.XDoc;

namespace Vibz.Studio.Document
{
    public partial class CaseDocument : ElementDocument
    {
        ContextMenuStrip _cMenu;
        public CaseDocument():
            this("")
        {
        }
        public CaseDocument(string filePath)
            : base(filePath)
        { }
        protected override bool ProcessKeyPreview(ref System.Windows.Forms.Message m)
        {
            // _debugMessage += " PKP[" + m.WParam.ToString() + "]";
            switch (m.WParam.ToString())
            {
                case "37":
                    if (_cMenu != null && !_cMenu.IsDisposed)
                        RichTextArea.SelectionStart--;
                    break;
                case "39":
                    if (_cMenu != null && !_cMenu.IsDisposed)
                        RichTextArea.SelectionStart++;
                    break;
            }
            return false;
        }
        public override void Document_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(FunctionTypeInfo)))
            {
                FunctionTypeInfo inst = (FunctionTypeInfo)e.Data.GetData(typeof(FunctionTypeInfo));
                int charIndex = _doc.GetCharIndexFromPosition(new Point(e.X, e.Y));
                int index=0;
                int lineIndex = _doc.GetLineFromCharIndex(charIndex, out index);
                _doc.SelectionStart = index;
                string indentText = StringHelper.GetLineIndentation(_doc.Lines[lineIndex]);
                RenderFunctionNode(inst, indentText);
            }
        }
        void RenderFunctionNode(FunctionTypeInfo inst, string indentText)
        {
            _doc.SelectedText = indentText;
            _doc.SelectionColor = Color.Blue;
            _doc.SelectedText = "<";
            _doc.SelectionColor = Color.Brown;
            _doc.SelectedText = inst.TypeName.ToLower();
            foreach (FunctionAttribute attr in inst.Attributes)
            {
                if (attr.Information.IsRequired)
                {
                    _doc.SelectionColor = Color.Red;
                    _doc.SelectedText = " " + attr.Name;
                    _doc.SelectionColor = Color.Blue;
                    _doc.SelectedText = "=";
                    _doc.SelectionColor = Color.Black;
                    _doc.SelectedText = "\"\"";
                }
            }
            _doc.SelectionColor = Color.Blue;
            if (!inst.IsContainer)
                _doc.SelectedText = " />\r\n";
            else
                _doc.SelectedText = ">\r\n";
            foreach (FunctionTypeInfo node in inst.ChildNodes)
            {
                RenderFunctionNode(node, indentText + "\t");
            }
            if (inst.IsContainer)
            {
                _doc.SelectedText = indentText;
                _doc.SelectionColor = Color.Blue;
                _doc.SelectedText = "</";
                _doc.SelectionColor = Color.Brown;
                _doc.SelectedText = inst.TypeName.ToLower();
                _doc.SelectionColor = Color.Blue;
                _doc.SelectedText = ">\r\n";
            }
        }
        public override void Document_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(FunctionTypeInfo)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        public override void Document_KeyDown(object sender, KeyEventArgs e)
        {
            _debugMessage += " D_KD[" + GetKeyString(e) + "]";
        }
        public override void Document_KeyUp(object sender, KeyEventArgs e)
        {
            _debugMessage += " D_KU[" + GetKeyString(e) + "]";
            Point p = RichTextArea.GetPositionFromCharIndex(RichTextArea.SelectionStart);
            p.Y = p.Y + 15;
            Reset();
            ToolStripItem[] tsic = GetContextMenu();
            if (tsic == null || tsic.Length == 0)
                return;
            if (tsic.Length == 1 && tsic[0].Text.ToLower() == CurrentContext.Word)
                return;
            _cMenu = new ContextMenuStrip();
            _cMenu.Items.AddRange(tsic);
            this.KeyPreview = true;
            _cMenu.KeyUp += new KeyEventHandler(cm_KeyUp);
            _cMenu.KeyDown += new KeyEventHandler(cm_KeyDown);
            _cMenu.KeyPress += new KeyPressEventHandler(cm_KeyPress);
            _cMenu.ItemClicked += new ToolStripItemClickedEventHandler(cm_ItemClicked);
            _cMenu.PreviewKeyDown += new PreviewKeyDownEventHandler(_cMenu_PreviewKeyDown);
            _cMenu.AutoSize = false;
            _cMenu.ShowCheckMargin = false;
            _cMenu.MaximumSize = new Size(200, 100);
            _cMenu.ShowItemToolTips = true;
            _cMenu.AutoClose = true;
            _cMenu.Show(RichTextArea, p);
            RichTextArea.SelectionStart = RichTextArea.SelectionStart;
            Debug();
        }

        Keys _currentKey = Keys.None;
        void _cMenu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            _debugMessage += " C_PKD[" + GetKeyString(e) + "]";
            if (char.IsLetterOrDigit((char)e.KeyCode))
                _currentKey = e.KeyCode;
        }

        void cm_KeyDown(object sender, KeyEventArgs e)
        {
            _debugMessage += " C_KD[" + GetKeyString(e) + "]";
        }
        
        void cm_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _debugMessage += " C_IC[" + e.ClickedItem.Text + "]";
            ContextMenuStrip cm = (ContextMenuStrip)sender;
            if (e.ClickedItem.Selected)
            {
                RichTextArea.Focus();
                SetCurrentWord(e.ClickedItem.Text);
                RichTextArea.SelectionStart = RichTextArea.SelectionStart;
            }
            else
            {
                TypeIntoTextarea(e.ClickedItem.Text[0]);
                _currentKey = Keys.None;
            }
            cm.Dispose();
        }

        void cm_KeyPress(object sender, KeyPressEventArgs e)
        {
            _debugMessage += " C_KP[" + e.KeyChar.ToString() + "]";
            ContextMenuStrip cm = (ContextMenuStrip)sender;
            TypeIntoTextarea(e.KeyChar);
            _currentKey = Keys.None;
            cm.Dispose();
        }
        void TypeIntoTextarea(char c)
        {
            switch (c)
            {
                case ' ':
                    RichTextArea.SelectedText = " ";
                    break;
                default:
                    RichTextArea.Focus();
                    SimulateKey(c);
                    break;
            }
        }
        string GetSelectionOffset(ContextMenuStrip cm, int offset)
        {
            int i = GetSelectedIndex(cm);
            if (i == 0)
                return cm.Items[0].Text;
            if (i != -1
                && (i + offset) <= cm.Items.Count
                && cm.Items[i + offset] != null)
            {
                return cm.Items[i + offset].Text;
            }
            return "";
        }
        int GetSelectedIndex(ContextMenuStrip cm)
        {
            foreach (ToolStripItem tsi in cm.Items)
            {
                if (tsi.Selected)
                    return cm.Items.IndexOf(tsi);
            }
            return -1;
        }
        void cm_KeyUp(object sender, KeyEventArgs e)
        {
            _debugMessage += " C_KU[" + GetKeyString(e) + "]";
            ContextMenuStrip cm = (ContextMenuStrip)sender;
            string keyValue = "";
            bool isChar = true;
            switch (e.KeyData)
            {
                //case Keys.Space: keyValue = " "; break;
                case Keys.Delete: keyValue = "{DELETE}"; break;
                case Keys.Back: keyValue = "{BACKSPACE}"; break;
                case Keys.CapsLock: keyValue = "{CAPSLOCK}"; break;
                case Keys.Home: keyValue = "{HOME}"; break;
                case Keys.End: keyValue = "{END}"; break;
                case Keys.PageDown: keyValue = "{PGDN}"; break;
                case Keys.PageUp: keyValue = "{PGUP}"; break;
                case Keys.Insert: keyValue = "{INSERT}"; break;
                case Keys.Tab:
                    keyValue = "{TAB}";
                    string selMenu = GetSelectionOffset(cm, -1);
                    if (selMenu != null && selMenu != "")
                    {
                        keyValue = selMenu;
                        isChar = false;
                    }
                    break;
                case Keys.Escape: keyValue = "{ESC}"; break;
                default: break; 
            }
            if (keyValue == "" && _currentKey != Keys.None)
            {
                keyValue = ((e.Shift != Console.CapsLock) ? _currentKey.ToString() : _currentKey.ToString().ToLower());
            }
            if (keyValue != "")
            {
                RichTextArea.Focus();
                if (isChar)
                    SimulateKey(keyValue);
                else
                    SetCurrentWord(keyValue);
                RichTextArea.SelectionStart = RichTextArea.SelectionStart;
                e.Handled = true;
                cm.Dispose();
            }
            Debug();
            _currentKey = Keys.None;
        }
        void SimulateKey(char c)
        {
            SimulateKey(c.ToString());
        }
        void SimulateKey(string text)
        {
            RichTextArea.SelectionColor = ContextColor;
            SendKeys.Send(text);
        }
        public override void Document_KeyPress(object sender, KeyPressEventArgs e)
        {
            _debugMessage += " D_KP[" + e.KeyChar.ToString() + "]";
        }
        #region Context Menu
        ToolStripMenuItem[] GetContextMenu()
        {
            try
            {
                System.Collections.ArrayList list = new System.Collections.ArrayList();
                DataRow[] dlist = null;
                switch (CurrentContext.Mode)
                {
                    case XMode.NodeNameBegin:
                        dlist = GetMatchingInsructions(CurrentContext.Instruction);
                        if (dlist == null)
                            return new ToolStripMenuItem[0];
                        foreach (DataRow dr in dlist)
                        {
                            ToolStripMenuItem tsi = new ToolStripMenuItem(dr[Context.InstructionNode.Name].ToString());
                            switch ((ContextSubType)Enum.Parse(typeof(ContextSubType), dr[Context.InstructionNode.Subtype].ToString()))
                            {
                                case ContextSubType.Action:
                                    tsi.Image = Vibz.Studio.Properties.Resources.Comments;
                                    break;
                                case ContextSubType.Assert:
                                    tsi.Image = Vibz.Studio.Properties.Resources.assert.ToBitmap();
                                    break;
                                case ContextSubType.Fetch:
                                    tsi.Image = Vibz.Studio.Properties.Resources.fetch.ToBitmap();
                                    break;
                            }
                            tsi.ToolTipText = dr[Context.InstructionNode.Description].ToString();
                            list.Add(tsi);
                        }
                        break;
                    case XMode.AttributeName:
                        dlist = GetMatchingAttributeNames(CurrentContext.Word, CurrentContext.Instruction);
                        if (dlist == null)
                            return new ToolStripMenuItem[0];
                        foreach (DataRow dr in dlist)
                        {
                            if (CurrentContext.ContainsAttribute(dr[Context.InstructionNode.Name].ToString()))
                                continue;
                            ToolStripMenuItem tsi = new ToolStripMenuItem(dr[Context.InstructionNode.Name].ToString());
                            switch ((ContextSubType)Enum.Parse(typeof(ContextSubType), dr[Context.InstructionNode.Subtype].ToString()))
                            {
                                case ContextSubType.Required:
                                    tsi.Image = Vibz.Studio.Properties.Resources.Required;
                                    break;
                                case ContextSubType.NonRequired:
                                    tsi.Image = Vibz.Studio.Properties.Resources.NonRequired;
                                    break;
                            }
                            tsi.ToolTipText = dr[Context.InstructionNode.Description].ToString();
                            list.Add(tsi);
                        }
                        break;
                    case XMode.AttributeValue:
                    case XMode.AttributeValueEnd:
                        dlist = GetMatchingAttributeValues(CurrentContext.Word, CurrentContext.Instruction, CurrentContext.Attribute);
                        if (dlist == null)
                            return new ToolStripMenuItem[0];
                        foreach (DataRow dr in dlist)
                        {
                            ToolStripMenuItem tsi = new ToolStripMenuItem(dr[Context.InstructionNode.Name].ToString());
                            tsi.ToolTipText = dr[Context.InstructionNode.Description].ToString();
                            list.Add(tsi);
                        }
                        break;
                }
                ToolStripMenuItem[] tsic = new ToolStripMenuItem[list.Count];
                list.CopyTo(tsic);
                return tsic;
            }
            catch (Exception exc)
            {
                return new ToolStripMenuItem[0];
            }

        }

        DataRow[] GetMatchingInsructions(string pattern)
        {
            string filter = Context.InstructionNode.Name + " like '" + pattern.ToLower() + "%' AND "+Context.InstructionNode.Type+" = " + (int)ContextType.Instruction;
            string sort = Context.InstructionNode.Name + " ASC";

            return Context.Instructions.Select(filter, sort);
        }
        DataRow[] GetMatchingAttributeNames(string pattern, string instruction)
        {
            string filter = Context.InstructionNode.Name + " like '" + pattern.ToLower() + 
                "%' AND " + Context.InstructionNode.Type + " = " + (int)ContextType.AttributeName + 
                " AND " + Context.InstructionNode.Owner + " = '" + instruction + "'";
            string sort = Context.InstructionNode.Name + " ASC";

            return Context.Instructions.Select(filter, sort);
        }
        DataRow[] GetMatchingAttributeValues(string pattern, string instruction, string attribute)
        {
            string filter = Context.InstructionNode.Name + " like '" + pattern.ToLower() +
                "%' AND " + Context.InstructionNode.Type + " = " + (int)ContextType.AttributeValue +
                " AND " + Context.InstructionNode.Owner + " = '" + instruction + "|" + attribute + "'";
            string sort = Context.InstructionNode.Name + " ASC";

            return Context.Instructions.Select(filter, sort);
        }
        #endregion
        string _debugMessage = "";
        void Debug()
        {
            if (false)
            {
                System.IO.File.AppendAllText("C:/log1.txt", "\r\n" + DateTime.Now.ToShortTimeString() + ":\t" + _debugMessage);
            }
            _debugMessage = "";
        }
        
        string GetKeyString(PreviewKeyDownEventArgs kArg)
        {
            return kArg.KeyCode.ToString() + ":" + kArg.KeyData.ToString() + ":" + kArg.KeyValue.ToString() + kArg;
        }
        string GetKeyString(KeyEventArgs kArg)
        {
            return kArg.KeyCode.ToString() + ":" + kArg.KeyData.ToString() + ":" + kArg.KeyValue.ToString() + kArg;
        }
    }
}
