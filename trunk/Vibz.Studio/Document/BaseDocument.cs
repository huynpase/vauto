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
using System.Windows.Forms;
using Vibz.Solution.Element;

namespace Vibz.Studio.Document
{
    public abstract partial class BaseDocument : Form, IDocument
    {
        protected bool _isModified = false;
        bool _doClose = true;
        public bool DoClose
        {
            get {
                return _doClose;
            }
        }
        public BaseDocument(string path)
        {
            InitializeComponent();
            if (path != null && File.Exists(path))
            {
                _path = path;
            }
        }
        public virtual void Close()
        {
            base.Close();
        }
        public abstract void Save();
        public abstract void SaveAs();
        public void Focus()
        {
            base.Focus();
        }
        public bool IsModified
        {
            get { return _isModified; }
        }
        protected string _path;
        public virtual string Path { get { return _path; } }
        public abstract DocumentType Type { get; }
        public abstract string DocumentName { get; }
        public abstract void Add(IElement element);
        public abstract void Render();
        private void BaseDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isModified)
            {
                DialogResult dr = MessageBox.Show("Document '" + Path + "' is not saved. Do you want to save it before closing.", "File not saved", MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        Save();
                        _doClose = true;
                        break;
                    case DialogResult.No:
                        _doClose = true;
                        break;
                    case DialogResult.Cancel:
                        _doClose = false;
                        break;
                }
            }
            else
            {
                _doClose = true;
            }
        }

        private void BaseDocument_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
