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
                int lineIndex = _doc.GetLineIndexAtPoint(new Point(e.X, e.Y)); 
                int index = _doc.GetFirstCharIndexFromLine(lineIndex);

                _doc.SelectionStart = index;

                _doc.SelectedText = StringHelper.GetLineIndentation(_doc.Lines[lineIndex]);
                _doc.SelectionColor = Color.Blue;
                _doc.SelectedText = "<";
                _doc.SelectionColor = Color.Brown;
                _doc.SelectedText = inst.TypeName;
                foreach (FunctionAttribute attr in inst.Attributes)
                {
                    if (attr.IsRequired)
                    {
                        _doc.SelectionColor = Color.Red;
                        _doc.SelectedText = " " + attr.Name;
                        _doc.SelectionColor = Color.Blue;
                        _doc.SelectedText = "=";
                        _doc.SelectionColor = Color.Black;
                        _doc.SelectedText = "\"\"";
                    }
                }
                _doc.SelectedText = " />\r\n";
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
            _debugMessage += " D_KD[" + e.KeyCode.ToString() + "]";
        }
        public override void Document_KeyUp(object sender, KeyEventArgs e)
        {
            _debugMessage += " D_KU[" + e.KeyCode.ToString() + "]";
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
            _cMenu.MaximumSize = new Size(100, 100);
            _cMenu.ShowItemToolTips = true;
            _cMenu.AutoClose = true;
            _cMenu.Show(RichTextArea, p);
            RichTextArea.SelectionStart = RichTextArea.SelectionStart;
        }

        Keys _currentKey = Keys.None;
        void _cMenu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            _debugMessage += " C_PKD[" + e.KeyCode.ToString() + "]";
            if (char.IsLetterOrDigit((char)e.KeyCode))
                _currentKey = e.KeyCode;
        }

        void cm_KeyDown(object sender, KeyEventArgs e)
        {
            _debugMessage += " C_KD[" + e.KeyCode.ToString() + "]";
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
        void cm_KeyUp(object sender, KeyEventArgs e)
        {
            _debugMessage += " C_KU[" + e.KeyCode.ToString() + "]";
            ContextMenuStrip cm = (ContextMenuStrip)sender;
            string keyValue = "";
            
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
                case Keys.Tab: keyValue = "{TAB}"; break;
                case Keys.Escape: keyValue = "{ESC}"; break;
                default: break; // keyValue = Convert.ToString((char)e.KeyValue);
            }
            if (keyValue == "" && _currentKey != Keys.None)
            {
                keyValue = ((e.Shift != Console.CapsLock) ? _currentKey.ToString() : _currentKey.ToString().ToLower());
            }
            if (keyValue != "")
            {
                RichTextArea.Focus();
                SimulateKey(keyValue);
                cm.Close();
                cm.Dispose();
                e.Handled = true;
            }
            Debug();
            RichTextArea.SelectionStart = RichTextArea.SelectionStart;
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
                //SetStatusMessage(_debugMessage);
            }
            _debugMessage = "";
        }

    }
}