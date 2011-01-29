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
using mshtml;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Net;
using System.IO;
using System.Data;
using Vibz.Web;
using Vibz.Helper;
using Vibz.Web.Browser;
using System.Xml;
namespace Vibz.HTMLExtractor
{
    public class Extractor : IBrowser
    {
        int MaxWait = 60000;
        HttpWebResponse _response;
        Uri _baseUrl;
        Dictionary<string, string> _pageHeaders = new Dictionary<string, string>();
        bool _showBrowser = true;
        public void Init(bool showBrowser)
        {
            try
            {
                Log("Init");
                _showBrowser = showBrowser;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message, exc);
            }
        }
        public void Init(Uri url, string htmlSource)
        {
            try
            {
                Log("Init: url:" + url.AbsolutePath + ".");
                ((WBrowser)Document).LoadDocument(htmlSource);
                _baseUrl = url;
            }
            catch (Exception exc)
            {
                throw new Exception("Error occured while initializing Web Instance,", exc);
            }
        }

        public void LoadUrl(string url, int maxWait)
        {
            try
            {
                Log("LoadUrl: Url '" + url + "' load complete.");
                _baseUrl = new Uri(url);
                Document.Navigate(url, maxWait);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message + ". Url: " + url, exc);
            }
        }
        public Dictionary<string, string> PageHeaders
        {
            get { return _pageHeaders; }
        }
        public int DownloadAllImages(string absPath, string relPath, bool linkedImages)
        {
            string path = Vibz.Helper.IO.CreateRelativePath(absPath, relPath);
            if (!Directory.Exists(path))
            {
                try
                {
                    Vibz.Helper.IO.CreateFolderPath(path, IOType.Folder);
                }
                catch (Exception exc)
                {
                    throw new Exception("Download path is not valid.");
                }
            }
            foreach (Image img in Document.Images)
            {
                try
                {
                    img.ImageObject.Save(path + "/" + img.FileName);
                    Vibz.Contract.Log.LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement("Downloaded image '" + img.FileName + "'", Vibz.Contract.Log.LogSeverity.Trace));
                }
                catch (Exception exc) { }
            }
            if (linkedImages)
            {
                foreach (Url url in Document.RedirectLinks)
                {
                    try
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(url.Link, @"\.(?:jpe?g|png|gif)$"))
                        {
                            System.Drawing.Image img = DownloadImage(url.Link);
                            img.Save(path + "/" + url.Text);
                            Vibz.Contract.Log.LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement("Downloaded image '" + url.Text + "'", Vibz.Contract.Log.LogSeverity.Trace));
                        }
                    }
                    catch (Exception exc) { }
                }
            }
            return Document.Images.Count;
        }

        public IWebDocument Document
        {
            get
            {
                return GetDocument();
            }
        }
        WBrowser _webControl;
        delegate WBrowser SetDocumentDelegate();
        WBrowser GetDocument()
        {
            Log("GetDocument");
            if (_webControl == null || _webControl.IsDisposed)
            {
                _webControl = new WBrowser();
                _webControl.ShowIcon = true;
                if (!_showBrowser)
                {
                    _webControl.ShowInTaskbar = false;
                    _webControl.WindowState = FormWindowState.Minimized;
                    _webControl.Visible = false;
                }
                _webControl.Show();
                Log("GetDocument: Document Initialized.");
            }
            else if (this._webControl.InvokeRequired)
            {
                Log("GetDocument: Document Invokation Required.");
                _webControl = (WBrowser)_webControl.Invoke(new SetDocumentDelegate(GetDocument), null);
            }
            return _webControl;
        }
        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _webControl.Dispose();
                }
                _disposed = true;
                Log("Dispose: Extractor disposed");
            }
        }

        void Log(string message)
        {
            Vibz.Contract.Log.LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement("[Extractor] - " + message, Vibz.Contract.Log.LogSeverity.Trace));
        }
        public System.Drawing.Image DownloadImage(string _URL)
        {
            System.Drawing.Image _tmpImage = null;
            try
            {
                System.Net.HttpWebRequest _HttpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(_URL);
                _HttpWebRequest.AllowWriteStreamBuffering = true;
                _HttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                _HttpWebRequest.Referer = "http://www.google.com/";
                _HttpWebRequest.Timeout = 20000;
                System.Net.WebResponse _WebResponse = _HttpWebRequest.GetResponse();
                System.IO.Stream _WebStream = _WebResponse.GetResponseStream();
                _tmpImage = System.Drawing.Image.FromStream(_WebStream);
                _WebResponse.Close();
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
                return null;
            }

            return _tmpImage;
        }
    }
}
