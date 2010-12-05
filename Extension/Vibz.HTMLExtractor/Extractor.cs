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
        WBrowser _webControl;
        bool _showBrowser = true;
        public void Init(bool showBrowser)
        {
            try
            {
                _showBrowser = showBrowser;
                SetDocument();
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
                SetDocument();
                ((WBrowser)Document).LoadDocument(htmlSource, MaxWait);
                _baseUrl = url;
            }
            catch (Exception exc)
            {
                //_webControl.Progress.Enqueue(new ProgressElement(exc.Message, ProgressElementType.Error));
                throw new Exception("", exc);
            }
        }
        
        public void LoadUrl(string url, int maxWait)
        {
            try
            {
                SetDocument();
                _baseUrl = new Uri(url);
                Document.Navigate(url, maxWait);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message, exc);
            }
        }
        public Dictionary<string, string> PageHeaders
        {
            get { return _pageHeaders; }
        }
        public void DownloadAllImages(string path)
        {
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
                }
                catch (Exception exc) { }
            }
        }

        public IWebDocument Document
        {
            get
            {
                SetDocument();
                return _webControl;
            }
        }
        delegate void SetDocumentDelegate();
        public void SetDocument()
        {
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
                return;
            }
            if (this._webControl.InvokeRequired)
            {
                try
                {
                    this._webControl.Invoke(new SetDocumentDelegate(SetDocument), null);
                }
                catch (Exception exc)
                {
                    _webControl = new WBrowser();
                    _webControl.Show();
                    return;
                }
            }
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
            }
        }
    }
}
