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
using System.Text;
using Vibz.Solution.Element;

namespace Vibz.Studio.Document
{
    public class DocumentList : List<Document.IDocument>
    {
        Project _project;
        Document.IDocument _current;
        System.Windows.Forms.Form _parentForm;
        public DocumentList(System.Windows.Forms.Form parentForm)
        {
            _parentForm = parentForm;
        }
        public DocumentList(System.Windows.Forms.Form parentForm, Project project)
        {
            _parentForm = parentForm;
            _project = project;
        }
        public Document.IDocument Find(string path)
        {
            foreach (Document.IDocument doc in this)
            {
                if (doc.Path == path)
                    return doc;
            }
            return null;
        }
        public Document.IDocument Current
        {
            get 
            {
                if (this.Count == 0)
                    return null;
                if (_current == null)
                    _current = this[this.Count - 1];
                return _current;
            }
        }
        public void OpenDocument(Document.DocumentType type, string path)
        {
            BaseDocument doc = null;
            switch (type)
            {
                case Vibz.Studio.Document.DocumentType.TestCase:
                    doc = new CaseDocument(path);
                    break;
                case Vibz.Studio.Document.DocumentType.Identifier:
                    doc = new IdentifierDocument(path);
                    break;
                case Vibz.Studio.Document.DocumentType.XML:
                    doc = new ElementDocument(path);
                    break;
                case Vibz.Studio.Document.DocumentType.TestSuite:
                    doc = TestSuite.Open(path, _project);
                    break;
            }
            doc.Activated += new EventHandler(doc_Activated);
            doc.FormClosing += new System.Windows.Forms.FormClosingEventHandler(doc_FormClosing);
            doc.MdiParent = _parentForm;
            if (doc.Text.Length > 25)
                doc.Text = "..." + doc.Text.Substring(doc.Text.Length - 24);
            doc.Show();
            this.Add(doc);
        }
        public void CreateDocument(Document.DocumentType type, string path)
        {
            System.IO.File.WriteAllText(path, DocumentFactory.GetDocumentInitialContent(type));
            OpenDocument(type, path);
        }
        public void CreateDocument(Document.DocumentType type)
        {
            BaseDocument doc = null;
            switch (type)
            {
                case Vibz.Studio.Document.DocumentType.TestCase:
                    doc = new CaseDocument();
                    break;
                case Vibz.Studio.Document.DocumentType.Identifier:
                    doc = new IdentifierDocument();
                    break;
                case Vibz.Studio.Document.DocumentType.XML:
                    doc = new ElementDocument();
                    break;
                case Vibz.Studio.Document.DocumentType.TestSuite:
                    doc = TestSuite.Create(_project);
                    break;
            }
            doc.Activated += new EventHandler(doc_Activated);
            doc.FormClosing += new System.Windows.Forms.FormClosingEventHandler(doc_FormClosing);
            doc.MdiParent = _parentForm;
            doc.Show();
            this.Add(doc);
        }

        void doc_Activated(object sender, EventArgs e)
        {
            this._current = (Document.IDocument)sender;
        }

        void doc_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (((Document.IDocument)sender).DoClose)
                this.Remove((Document.IDocument)sender);
            else
                e.Cancel = true;
        }
    }
}
