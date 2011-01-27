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
using System.IO;
using System.Xml;

namespace Vibz.Plugin.Plug.XML
{
    internal abstract class XmlPlugBase : PlugBase
    {
        StreamReader _sr;
        XmlDocument _xDoc = null;
        XmlNode _xNode = null;
        protected string _xPath;
        public override PlugType Type { get { return PlugType.XmlElement; } }
        public override NegateSeverity Severity { get { return NegateSeverity.NonFatal; } }
        public XmlPlugBase(string filePath, string xPath)
            : base(filePath)
        {
            _xPath = xPath;
        }
        public override bool ExecutionNeeded
        {
            get
            {
                return true;
            }
        }
        public override bool CanExecute
        { 
            get {
                try
                {
                    if (IsPlugUsedbyAnotherProcess)
                        return false;
                    TryLoadXml();
                }
                catch (Exception exc)
                {
                    Message = exc.Message;
                    return false;
                }
                return true;
            } 
        }
        protected XmlDocument TryLoadXml()
        {
            try
            {
                if (_xDoc == null)
                {
                    _xDoc = new XmlDocument();
                    _sr = new StreamReader(_filePath);
                    _xDoc.Load(_sr);
                }
                return _xDoc;
            }
            catch (Exception exc)
            {
                throw new Exception("File '" + _filePath + "' is not a valid Xml.");
            }
            finally
            {
                _sr.Close();
                _sr.Dispose();
            }
        }
        protected XmlNode TrySelectNode()
        {
            if (_xNode == null)
            {
                _xNode = TrySelectNode(_xPath);
            }
            return _xNode;
        }

        protected XmlNode TrySelectNode(string xPath)
        {
            XmlDocument xDoc = TryLoadXml();
            return xDoc.SelectSingleNode(xPath);
        }
        protected void Commit()
        {
            _xDoc.Save(_filePath);
        }
        protected bool IsPlugUsedbyAnotherProcess
        {
            get
            {
                bool isBeingUsed = false;
                if (!File.Exists(_filePath))
                    throw new FileNotFoundException("File '" + _filePath + "' not found.");
                FileStream fs = null;
                try
                {
                    fs = File.Open(_filePath, FileMode.Open, FileAccess.Read, FileShare.None);
                }
                catch (System.IO.IOException exp)
                {
                    Message = "File '" + _filePath + "' is in use. Please close the file and try again.";
                    isBeingUsed = true;
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }
                return isBeingUsed;
            }
        }
        protected bool ValidateContent(string content)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(content);
                return true;
            }
            catch (Exception exc)
            {
                Message = "Content should be a valid Xml Node.";
                return false;
            }
        }
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _sr.Close();
                    _sr.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
