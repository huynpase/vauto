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

namespace Vibz.Studio.Document
{
    public partial class XDocument : BaseDocument
    {
        public XDocument():
            this("")
        {
        }
        public XDocument(string filePath)
            : base(filePath)
        {
            InitializeComponent();
            rtbTextArea.TabStop = true;
            OpenDocument();
        }
        void OpenDocument()
        {
            this.Text = ((Path == null || Path == "") ? "New Document" : Path);

            XmlTextReader reader = new XmlTextReader(Path);
            try
            {
                LoadStream(reader);
            }
            catch (Exception exc)
            {
                rtbTextArea.Text = File.ReadAllText(Path);
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        doc.LoadXml(rtbTextArea.Text);
                    }
                    catch (Exception exc)
                    {
                        err = exc.Message;
                    }
                    if (err == "" || MessageBox.Show("Document has failed basic Xml validation. \r\nError: " + err + "\r\nDo you still want to save the document.", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        rtbTextArea.SaveFile(filepath, RichTextBoxStreamType.PlainText);
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
        private void LoadStream(XmlTextReader reader)
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
                _isModified = false;
            }
        }

        private void rtbTextArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case ('<'):
                    // MessageBox.Show("<");
                    break;

                case ('>'):
                    // MessageBox.Show(">");
                    break;
            }
        }

        private void rtbTextArea_TextChanged(object sender, EventArgs e)
        {
            _isModified = true;
        }
    }
}