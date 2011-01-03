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
    public partial class ElementDocument : BaseDocument
    {
        protected XDocument _doc;
        public ElementDocument()
            :
            this("")
        {
        }
        public ElementDocument(string filePath)
            : base(filePath)
        {
            InitializeComponent();
            _doc = new XDocument();
            _doc.DragDrop=new DragEvent(Document_DragDrop);
            _doc.DragEnter=new DragEvent(Document_DragEnter);
            _doc.TextChange = new ChangeEvent(Document_TextChanged);
            _doc.KeyUp = new KeyEvent(Document_KeyUp);
            _doc.KeyDown = new KeyEvent(Document_KeyDown);
            OpenDocument();
            _doc.Dock = DockStyle.Fill;
            this.Controls.Add(_doc);
        }
        public Context CurrentContext
        {
            get { return _doc.CurrentContext; }
        }
        public void Reset()
        {
            _doc.Reset();
        }
        public Color ContextColor
        {
            get { return _doc.ContextColor; }
        }
        public RichTextBox RichTextArea
        {
            get { return _doc.RichTextArea; }
        }
        public virtual void Document_DragDrop(object sender, DragEventArgs e)
        { }
        public virtual void Document_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
        }
        public virtual void Document_TextChanged(object sender, EventArgs e)
        {
            _isModified = true;
        }
        public virtual void Document_KeyUp(object sender, KeyEventArgs e)
        { }
        public virtual void Document_KeyDown(object sender, KeyEventArgs e)
        { }
        public virtual void Document_KeyPress(object sender, KeyPressEventArgs e)
        { }
        void OpenDocument()
        {
            this.Text = ((Path == null || Path == "") ? "New Document" : Path);

            XmlTextReader reader = new XmlTextReader(Path);
            try
            {
                _doc.LoadStream(reader);
            }
            catch (Exception exc)
            {
                _doc.Text = File.ReadAllText(Path);
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isModified = false;
            }
        }
        public override void Save()
        {
            Save(Path);
        }
        void Save(string filepath)
        {
            try
            {
                if (_isModified)
                {
                    string err = "";
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(_doc.Text);
                    }
                    catch (Exception exc)
                    {
                        err = exc.Message;
                    }
                    if (err == "" || MessageBox.Show("Document has failed basic Xml validation. \r\nError: " + err + "\r\nDo you still want to save the document.", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        _doc.SaveFile(filepath, RichTextBoxStreamType.PlainText);
                        _isModified = false;
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Unable to save. " + exc.Message);
            }
        }
        public override void SaveAs()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Save(saveFileDialog1.FileName);
            }
        }
        public override void Render()
        {
            
        }
        public override void Add(IElement element)
        {
            throw new Exception("Invalid command.");
        }
        public override Document.DocumentType Type { get { return Vibz.Studio.Document.DocumentType.XML; } }
        public override string DocumentName { get { if (Path == null) return "Untitled Document"; else return Path; } }
        public void SetStatusMessage(string message)
        {
            _doc.SetStatusMessage(message);
        }
        public void SetCurrentWord(string word)
        {
            _doc.SetCurrentWord(word);
        }
    }
}