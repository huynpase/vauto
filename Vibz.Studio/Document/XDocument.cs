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
using System.Drawing;
using System.Data;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Vibz.Solution.Element;
using Vibz.Contract.Attribute;
using Vibz.Studio.Document.XDoc;
using System.Runtime.InteropServices;

namespace Vibz.Studio.Document
{
    public delegate void DragEvent(object sender, DragEventArgs e);
    public delegate void ChangeEvent(object sender, EventArgs e);
    public delegate void KeyEvent(object sender, KeyEventArgs e);
    public delegate void KeyPressEvent(object sender, KeyPressEventArgs e);

    public partial class XDocument : UserControl
    {
        #region Public fields
        public DragEvent DragDrop = null;
        public DragEvent DragEnter = null;
        public ChangeEvent TextChange = null;
        public KeyEvent KeyUp = null;
        public KeyEvent KeyDown = null;
        public KeyPressEvent KeyPress = null;
        #endregion
        #region Constructor
        public XDocument()
        {
            InitializeComponent();
            rtbTextArea.AllowDrop = true;
            rtbTextArea.DragEnter += new DragEventHandler(rtbTextArea_DragEnter);
            rtbTextArea.DragDrop += new DragEventHandler(rtbTextArea_DragDrop);
            rtbTextArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbTextArea_KeyDown);
            rtbTextArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbTextArea_KeyPress);
            rtbTextArea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtbTextArea_KeyUp);
            rtbTextArea.TextChanged += new System.EventHandler(this.rtbTextArea_TextChanged);
            rtbTextArea.SelectionChanged += new EventHandler(rtbTextArea_SelectionChanged);
            rtbTextArea.TabStop = true;
        }

        void rtbTextArea_SelectionChanged(object sender, EventArgs e)
        {
            UpdateCaretPosition();
        }
        #endregion
        #region Richtextbox Members
        public RichTextBox RichTextArea
        {
            get { return rtbTextArea; }
        }
        public string Text
        {
            get { return rtbTextArea.Text; }
            set { rtbTextArea.Text = value; }
        }
        public string SelectedText
        {
            get { return rtbTextArea.SelectedText; }
            set { rtbTextArea.SelectedText = value; }
        }
        public Color SelectionColor
        {
            get { return rtbTextArea.SelectionColor; }
            set { rtbTextArea.SelectionColor = value; }
        }
        public int SelectionStart
        {
            get { return rtbTextArea.SelectionStart; }
            set { rtbTextArea.SelectionStart = value; }
        }
        public Point PointToClient(Point p)
        {
            return rtbTextArea.PointToClient(p);
        }
        public int GetCharIndexFromPosition(Point p)
        {
            return rtbTextArea.GetCharIndexFromPosition(p);
        }
        public int GetLineFromCharIndex(int index)
        {
            return rtbTextArea.GetLineFromCharIndex(index);
        }
        public int GetLineIndexAtPoint(Point p)
        {
            Point pt = rtbTextArea.PointToClient(p);
            return rtbTextArea.GetLineFromCharIndex(rtbTextArea.GetCharIndexFromPosition(pt));
        }
        public int GetFirstCharIndexFromLine(int lineNumber)
        {
            return rtbTextArea.GetFirstCharIndexFromLine(lineNumber);
        }
        public string[] Lines
        {
            get { return rtbTextArea.Lines; }
            set { rtbTextArea.Lines = value; }
        }
        #endregion
        public void SaveFile(string filepath, RichTextBoxStreamType streamType)
        {
            rtbTextArea.SaveFile(filepath, RichTextBoxStreamType.PlainText);
        }
        void rtbTextArea_DragDrop(object sender, DragEventArgs e)
        {
            if (DragDrop != null)
                DragDrop(sender, e);
        }
        void rtbTextArea_DragEnter(object sender, DragEventArgs e)
        {
            if (DragEnter != null)
                DragEnter(sender, e);
        }
        void rtbTextArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.rtbTextArea.SelectionColor = ContextColor;
            switch (CurrentContext.Mode)
            {
                case XMode.AttributeName:
                    if (CurrentContext.Word.Trim() != "" && e.KeyChar == '=')
                    {
                        this.rtbTextArea.SelectionColor = Color.Blue;
                        this.rtbTextArea.SelectedText = "=";
                        this.rtbTextArea.SelectionColor = Color.Black;
                        this.rtbTextArea.SelectedText = "\"";
                        this.rtbTextArea.SelectedText = "\"";
                        this.rtbTextArea.SelectionStart--;
                        this.rtbTextArea.SelectionColor = Color.Blue;
                        e.Handled = true;
                    }
                    else ProcessEndCharacter(CurrentContext, ref e);
                    break;
                case XMode.InnerTextSibling:
                case XMode.InnerText:
                    if (e.KeyChar == '<')
                        this.rtbTextArea.SelectionColor = Color.Blue;
                    break;
                case XMode.NodeNameBegin:
                case XMode.AttributeSeperation:
                    ProcessEndCharacter(CurrentContext, ref e);
                    break;
            }
            if (KeyPress != null)
                KeyPress(sender, e);
        }
        void rtbTextArea_TextChanged(object sender, EventArgs e)
        {
            if (TextChange != null)
                TextChange(sender, e);
        }
        void rtbTextArea_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    string indentText = "\r\n" + StringHelper.GetLineIndentation(CurrentLine);
                    rtbTextArea.SelectedText = indentText;
                    if (CurrentContext.Mode == XMode.InnerTextSibling)
                    {
                        // todo: if first child add tab space
                        //rtbTextArea.SelectedText = "\t";

                    }
                    if (CurrentContext.Mode == XMode.InnerText || CurrentContext.Mode == XMode.AttributeSeperation)
                    {
                        rtbTextArea.SelectedText = "\t";
                        int pos = rtbTextArea.SelectionStart;
                        rtbTextArea.SelectedText = indentText;
                        rtbTextArea.SelectionStart = pos;
                    }
                    e.Handled = true;
                    break;
            }
            if (KeyDown != null)
                KeyDown(sender, e);
        }
        void rtbTextArea_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                { 
                    case Keys.G:
                        UserInput.GetUserValue guv = new Vibz.Studio.UserInput.GetUserValue("Go to Line", "Line number:", "Go");
                        if (guv.ShowDialog() == DialogResult.OK)
                        {
                            int line=Vibz.Helper.Math.TryGetInteger(guv.Value);
                            if (line < RichTextArea.Lines.Length)
                                RichTextArea.SelectionStart = RichTextArea.GetFirstCharIndexFromLine(line - 1);
                        }
                        break;
                }
            }
            if (KeyUp != null)
                KeyUp(sender, e);
            Reset();
        }
        private static int EM_LINEINDEX = 0xbb;
        void LoadContext()
        {
            Context context = CurrentContext;
            lblPosition.Text = " [" + context.Mode.ToString() + "]";
        }
        void UpdateCaretPosition()
        {
            //return;
            int line, col, index;
            index = rtbTextArea.SelectionStart;
            line = rtbTextArea.GetLineFromCharIndex(index);
            col = index - SendMessage(rtbTextArea.Handle, EM_LINEINDEX, -1, 0);
            lblPosition.Text = "Ln " + (++line).ToString() + ", Ch " + (++col).ToString();
        }
        void ProcessEndCharacter(Context context, ref KeyPressEventArgs e)
        {
            // TODO: Handle auto indentation for node complete
            switch (e.KeyChar)
            {
                case '/':
                    this.rtbTextArea.SelectionColor = Color.Blue;
                    this.rtbTextArea.SelectedText = "/>";
                    e.Handled = true;
                    break;
                case '>':
                    this.rtbTextArea.SelectionColor = Color.Blue;
                    this.rtbTextArea.SelectedText = "></";
                    this.rtbTextArea.SelectionColor = Color.Brown;
                    this.rtbTextArea.SelectedText = context.Instruction;
                    this.rtbTextArea.SelectionColor = Color.Blue;
                    this.rtbTextArea.SelectedText = ">";
                    e.Handled = true;
                    break;
            }
        }
        public void LoadStream(XmlTextReader reader)
        {
            this.rtbTextArea.Clear();
            this.rtbTextArea.AcceptsTab = true;
            try
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                        case XmlNodeType.XmlDeclaration:
                            this.rtbTextArea.SelectionColor = Color.Blue;
                            this.rtbTextArea.AppendText("<");
                            if (reader.NodeType == XmlNodeType.XmlDeclaration)
                                this.rtbTextArea.AppendText("?");
                            this.rtbTextArea.SelectionColor = Color.Brown;
                            this.rtbTextArea.AppendText(reader.Name.ToLower());

                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    this.rtbTextArea.AppendText(" ");
                                    this.rtbTextArea.SelectionColor = Color.Red;
                                    this.rtbTextArea.AppendText(reader.Name.ToLower());
                                    this.rtbTextArea.SelectionColor = Color.Blue;
                                    this.rtbTextArea.AppendText("=");
                                    this.rtbTextArea.SelectionColor = Color.Black;
                                    this.rtbTextArea.AppendText("\"");
                                    this.rtbTextArea.SelectionColor = Color.Blue;
                                    this.rtbTextArea.AppendText(Vibz.Helper.Xml.Encode(reader.Value));
                                    this.rtbTextArea.SelectionColor = Color.Black;
                                    this.rtbTextArea.AppendText("\"");
                                }
                                reader.MoveToElement();
                            }

                            this.rtbTextArea.SelectionColor = Color.Blue;
                            if (reader.NodeType == XmlNodeType.XmlDeclaration)
                                this.rtbTextArea.AppendText("?");
                            if (reader.IsEmptyElement)
                                this.rtbTextArea.AppendText("/");
                            this.rtbTextArea.AppendText(">");
                            break;
                        case XmlNodeType.Text: //Display the text in each element.
                            this.rtbTextArea.SelectionColor = Color.Black;
                            this.rtbTextArea.AppendText(Vibz.Helper.Xml.Encode(reader.Value));
                            break;
                        case XmlNodeType.EndElement: //Display the end of the element.
                            this.rtbTextArea.SelectionColor = Color.Blue;
                            this.rtbTextArea.AppendText("</");
                            this.rtbTextArea.SelectionColor = Color.Brown;
                            this.rtbTextArea.AppendText(reader.Name.ToLower());
                            this.rtbTextArea.SelectionColor = Color.Blue;
                            this.rtbTextArea.AppendText(">");
                            break;
                        case XmlNodeType.Comment:
                            this.rtbTextArea.SelectionColor = Color.Blue;
                            this.rtbTextArea.AppendText("<!--");
                            this.rtbTextArea.SelectionColor = Color.Green;
                            this.rtbTextArea.AppendText(Vibz.Helper.Xml.Encode(reader.Value));
                            this.rtbTextArea.SelectionColor = Color.Blue;
                            this.rtbTextArea.AppendText("-->");
                            break;
                        case XmlNodeType.CDATA:
                            this.rtbTextArea.SelectionColor = Color.Blue;
                            this.rtbTextArea.AppendText("<![CDATA[");
                            this.rtbTextArea.SelectionColor = Color.Gray;
                            this.rtbTextArea.AppendText(reader.Value);
                            this.rtbTextArea.SelectionColor = Color.Blue;
                            this.rtbTextArea.AppendText("]]>");
                            break;
                        case XmlNodeType.Whitespace:
                            this.rtbTextArea.AppendText(reader.Value);
                            break;
                    }
                }
                rtbTextArea.SelectionStart = 0;
                rtbTextArea.ScrollToCaret();
                rtbTextArea.SelectionTabs = new int[] { 4 };
            }
            finally
            {
                reader.Close();
                Validate();
            }
        }
        public void SetStatusMessage(string message)
        {
            lblStatusMessage.Text = message;
        }
        public void SetCurrentWord(string word)
        {
            int currentPosition = rtbTextArea.SelectionStart;
            if (word == ""
                || CurrentContext.WordStartIndex == -1
                || CurrentContext.WordStartIndex > rtbTextArea.SelectionStart)
                return;

            string currentWord = CurrentContext.Word;
            rtbTextArea.Select(rtbTextArea.SelectionStart - currentWord.Length, currentWord.Length);
            rtbTextArea.Cut();
            rtbTextArea.SelectionColor = ContextColor;
            rtbTextArea.SelectedText = word;
        }
        public Color ContextColor
        {
            get
            {
                Color retValue = this.rtbTextArea.SelectionColor;
                switch (CurrentContext.Mode)
                {
                    case XMode.CDATA:
                        retValue = Color.Gray;
                        break;
                    case XMode.AttributeValue:
                    case XMode.AttributeValueEnd:
                        retValue = Color.Blue;
                        break;
                    case XMode.NodeNameBegin:
                        retValue = Color.Brown;
                        break;
                    case XMode.NodeBeginClose:
                    case XMode.NodeNameEnd:
                        retValue = Color.Brown;
                        break;
                    case XMode.AttributeName:
                        retValue = Color.Red;
                        break;
                    case XMode.AttributeEqual:
                        retValue = Color.Red;
                        break;
                    case XMode.InnerTextSibling:
                    case XMode.InnerText:
                        retValue = Color.Black;
                        break;
                    case XMode.AttributeValueStart:
                    case XMode.NodeBeginOpen:
                    default:
                        retValue = Color.Black;
                        break;
                }
                return retValue;
            }
        }
        Context _context = null;
        public Context CurrentContext
        {
            get
            {
                if (_context == null)
                {
                    try
                    {
                        _context = new Context();
                        int index = rtbTextArea.SelectionStart;
                        int cdataStart = 0;
                        while (cdataStart != -1)
                        {
                            cdataStart = rtbTextArea.Text.Substring(cdataStart, index - cdataStart).ToLower().LastIndexOf("<![cdata[");
                            if (cdataStart != -1)
                            {
                                int cdataEnd = rtbTextArea.Text.Substring(cdataStart, index - cdataStart).ToLower().IndexOf("]]>");
                                if (cdataEnd == -1)
                                {
                                    _context.Mode = XMode.CDATA;
                                    return _context;
                                }
                                else
                                    cdataStart += cdataEnd;
                            }
                        }
                        _context.Mode = XMode.InnerText;
                        int startIndex = index - 1;
                        while (true)
                        {
                            if (startIndex == -1)
                            {
                                _context.Mode = XMode.PageBegin;
                                break;
                            }
                            char c = rtbTextArea.GetCharFromPosition(rtbTextArea.GetPositionFromCharIndex(startIndex));
                            if (c == '<') // In a node
                            {
                                int endIndex = index;
                                while (true)
                                {
                                    c = rtbTextArea.GetCharFromPosition(rtbTextArea.GetPositionFromCharIndex(endIndex));
                                    if (c == '/')
                                    {
                                        if (rtbTextArea.GetCharFromPosition(rtbTextArea.GetPositionFromCharIndex(endIndex + 1)) == '>')
                                        {
                                            endIndex = endIndex + 2;
                                            break;
                                        }
                                    }
                                    else if (c == '>')
                                    {
                                        endIndex = endIndex + 1;
                                        break;
                                    }
                                    else if (c == '<')
                                    {
                                        break;
                                    }
                                    else if (endIndex >= rtbTextArea.Text.Length) // End of file
                                    {
                                        endIndex = endIndex + 1;
                                        break;
                                    }
                                    endIndex++;
                                }
                                string nodeText = rtbTextArea.Text.Substring(startIndex, endIndex - startIndex);
                                _context.Load(nodeText, index - startIndex);
                                _context.WordStartIndex = _context.WordStartIndex + startIndex;
                                break;
                            }
                            else if (c == '>') // Inner Text
                            {
                                _context.Mode = XMode.InnerTextSibling;
                                startIndex--;
                                c = rtbTextArea.GetCharFromPosition(rtbTextArea.GetPositionFromCharIndex(startIndex));
                                if (c == '/')
                                {
                                    break;
                                }
                                while (true)
                                {
                                    c = rtbTextArea.GetCharFromPosition(rtbTextArea.GetPositionFromCharIndex(startIndex));
                                    if (c == '<')
                                        break;
                                    if (c == '/')
                                    {
                                        startIndex--;
                                        c = rtbTextArea.GetCharFromPosition(rtbTextArea.GetPositionFromCharIndex(startIndex));
                                        if (c == '<')
                                        {
                                            break;
                                        }
                                    }
                                    startIndex--;
                                }
                                break;
                            }
                            else if (startIndex <= 0) // Start of file
                            {
                                _context.Mode = XMode.InnerText;
                                break;
                            }
                            startIndex--;
                        }
                    }
                    catch (Exception exc)
                    { }
                }
                return _context;
            }
        }
        public void Reset()
        {
            _context = null;
        }
        public string CurrentLine
        {
            get
            {
                return rtbTextArea.Lines[rtbTextArea.GetLineFromCharIndex(rtbTextArea.SelectionStart)];
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        public void MarkErrorLine(int lineNumber, int charPosition)
        {
            lineNumber--;
            if (RichTextArea.Lines.Length > lineNumber)
            {
                int stIndex = RichTextArea.GetFirstCharIndexFromLine(lineNumber);
                int indent = 0;
                while (RichTextArea.Text[stIndex].ToString().Trim() == "")
                {
                    indent++;
                    stIndex++;
                }
                int length = RichTextArea.Lines[lineNumber - 1].Length - indent;
                if (length <= 0 || stIndex >= RichTextArea.Text.Length)
                    return;
                RichTextArea.SelectionStart = stIndex;
                RichTextArea.SelectionLength = length;
                RichTextArea.SelectionFont = new Font(RichTextArea.SelectionFont, FontStyle.Bold);
                RichTextArea.SelectionBackColor = Color.Pink;
                RichTextArea.SelectionLength = 0;
            }
        }
    }
}
