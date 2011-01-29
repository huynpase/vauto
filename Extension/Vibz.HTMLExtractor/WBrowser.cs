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
//using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Vibz.Web.Browser;
using Vibz.Web.Browser.Collection;
using System.Collections;
using Vibz.Helper;
using System.Net;
using mshtml;
using Vibz.Contract.Data;

namespace Vibz.HTMLExtractor
{
    public partial class WBrowser : Form, IWebDocument
    {
        const string Title = "Vibz Browser";
        string _docText = "";
        Uri _baseUrl;
        string _currentUrl = "";
        const string NodeId = "__nodeId";
        object _padLock = new object();
        WebBrowserReadyState _readyState = WebBrowserReadyState.Uninitialized;
        public int NavigationCounter; 
        ScriptCallback scriptCallback;
        XmlDocument _document = null;
        Dictionary<int, HtmlElement> _elements = new Dictionary<int, HtmlElement>();
        internal WBrowser()
        {
            //ShowInTaskbar = false; 
            //WindowState = FormWindowState.Minimized;
            InitializeComponent();
            Load += new EventHandler(Browser_Load);
            _disposed = false;
            Log("Constructor");
            NavigationCounter = 0;
        }
        bool _reloadingSGML = false;
        public int SleepTime = 250;
        internal XmlDocument XDocument
        {
            get
            {
                if (_document == null)
                    throw new Exception("Browser document is undefined.");
                return _document;
            }
        }
        internal XmlNode XBody
        {
            get
            {
                return XDocument.SelectSingleNode("//body");
            }
        }
        internal HtmlDocument Document
        {
            get 
            {
                return wb.Document; 
            }
        }
        public string DocumentText
        {
            get 
            {
                try
                {
                    return wb.DocumentText;
                }
                catch (InvalidCastException ex)
                {
                    return "";
                }
                catch (ExecutionEngineException ex)
                {
                    return "";
                }
                catch(Exception ex)
                {
                    return "";
                }
            } 
        }
        Vibz.Web.Browser.Collection.ImageList _images = null;
        void Browser_Load(object sender, EventArgs e)
        {
            Log("Loading");
            wb.Dock = DockStyle.Fill;
            wb.AllowNavigation = true;
            wb.ScriptErrorsSuppressed = true;
            wb.ProgressChanged += new WebBrowserProgressChangedEventHandler(wb_ProgressChanged);
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
            wb.Navigating += new WebBrowserNavigatingEventHandler(wb_Navigating);
            wb.Navigated += new WebBrowserNavigatedEventHandler(wb_Navigated);
            this.Controls.Add(wb);
            scriptCallback = new ScriptCallback(this);
        }

        void wb_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            Log("Status - " + _readyState.ToString());
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = (int)e.MaximumProgress;
            toolStripProgressBar1.Value = (int)e.CurrentProgress;

            toolStripStatusLabel1.Text = wb.ReadyState == WebBrowserReadyState.Loading ? "Loading " + wb.Url.ToString() :
                (wb.ReadyState == WebBrowserReadyState.Complete ? "Done" : "Website found." + wb.Url.ToString());
        }

        void wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Log("Navigated");
        }
        void wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Log("Navigating");
            NavigationCounter++; 
        }
        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //Ref: http://www.codeproject.com/KB/aspnet/WebBrowser.aspx
            Log("Document load completed");
            HtmlDocument doc = ((WebBrowser)sender).Document;

            doc.InvokeScript("setTimeout", new object[] {
            string.Format("window.external.getHtmlResult({0})",
            NavigationCounter), 10 });

            NavigationCounter = 0;

            _readyState = WebBrowserReadyState.Complete;

            ProcessPage();
        }
        void ProcessPage()
        {
            if (_reloadingSGML)
            {
                lock (_padLock)
                {
                    Log("CheckStatus - Browser Status is Complete");
                    _readyState = WebBrowserReadyState.Complete;
                    _reloadingSGML = false;
                }
            }
            else
            {
                _currentUrl = wb.Url.AbsoluteUri;
                Log("CheckStatus - Current Url: " + _currentUrl);
                if (wb.DocumentText == null)
                    throw new Exception("Browser document is not available. You must navigate to an url before accessing document elements.");

                byte[] byteArray = Encoding.ASCII.GetBytes(wb.DocumentText);
                MemoryStream stream = new MemoryStream(byteArray);
                _document = new XmlDocument();
                _document = FromHtml(new StreamReader(stream));
                _reloadingSGML = true;
                wb.Document.Body.InnerHtml = _document.SelectSingleNode("//body").InnerXml;
                _elements.Clear();
                foreach (HtmlElement ele in wb.Document.All)
                {
                    string snodeId = ele.GetAttribute(NodeId);
                    if (snodeId == null) continue;
                    int nodeId = -1;
                    int.TryParse(snodeId, out nodeId);
                    if (nodeId > 0 && !_elements.ContainsKey(nodeId))
                        _elements.Add(nodeId, ele);
                }
                this.Text = wb.DocumentTitle + " - " + Title;
            }
        }
        internal void LoadDocument(string html)
        {
            Log("Loading Document");
            _reloadingSGML = false;
            wb.DocumentText = html;
            _readyState = WebBrowserReadyState.Loading;
        }
        public void Navigate(string url, int maxWait)
        {
            Log("Navigate: Url - " + url);
            _baseUrl = new Uri(url);
            _reloadingSGML = false;
            wb.Navigate(url);
            _readyState = WebBrowserReadyState.Loading;
            WaitForPageLoad(maxWait, true);
        }
        private XmlDocument FromHtml(TextReader reader)
        {
            // setup SgmlReader
            Sgml.SgmlReader sgmlReader = new Sgml.SgmlReader();
            sgmlReader.DocType = "HTML";
            sgmlReader.WhitespaceHandling = WhitespaceHandling.All;
            sgmlReader.CaseFolding = Sgml.CaseFolding.ToLower;
            sgmlReader.InputStream = reader;

            // create document
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.XmlResolver = null;
            doc.Load(sgmlReader);

            ModulatePage(ref doc);

            return doc;
        }
        internal void ModulatePage(ref XmlDocument doc)
        {
            // Absolutify Urls
            XmlNodeList xnl;
            foreach (string urlAttr in new string[] { "//*/@href", "//*/@src", "//*/@action" })
            {
                xnl = doc.SelectNodes(urlAttr);
                foreach (XmlNode xn in xnl)
                {
                    Uri uri;
                    if (Uri.TryCreate(_baseUrl, xn.Value, out uri))
                        xn.Value = uri.AbsoluteUri;
                }
            }
            // Add tbody to tables
            xnl = doc.SelectNodes("//table");
            foreach (XmlNode xn in xnl)
            {
                if (xn.FirstChild.Name.ToLower() == "tbody")
                    continue;
                XmlNode tbody = doc.CreateElement("tbody");
                while (xn.HasChildNodes)
                    tbody.AppendChild(xn.ChildNodes[0]);      
          
                xn.AppendChild(tbody);
            }

            // Add identity
            xnl = doc.SelectNodes("//*");
            int i = 0;
            foreach (XmlNode xn in xnl)
            {
                XmlAttribute attr = doc.CreateAttribute(NodeId);
                attr.Value = Convert.ToString(i++);
                xn.Attributes.Append(attr);
            }
        }

        #region Locator
        private LocatorType GetLoacatorType(string locator)
        {
            if (locator.Contains("//"))
                return LocatorType.XPath;
            else if (locator.Contains("="))
                return LocatorType.AttributeValue;
            else return LocatorType.ID;
        }
        private HtmlElement GetElement(string locator)
        {
            return GetElement(locator, true);
        }
        private HtmlElement GetElement(string locator, bool throwExceptionWhenNotFound)
        {
            if (wb.Document == null)
                throw new Exception("Browser document is not available. You must navigate to an url before accessing document elements.");
            HtmlElement retValue = null;
            switch (GetLoacatorType(locator))
            { 
                case LocatorType.XPath:
                    retValue = WSelectSingleNode(locator);
                    break;
                case LocatorType.AttributeValue:
                    string[] locs = locator.Split(new char[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    if (locs.Length != 2)
                        throw new Exception("Invalid locator. " + locator + "");
                    HtmlElementCollection col = wb.Document.GetElementsByTagName("input");
                    foreach (HtmlElement element in col)
                    {
                        if (element.GetAttribute(locs.GetValue(0).ToString()).Equals(locs.GetValue(1).ToString()))
                        {
                            retValue = element;
                            break;
                        }
                    }
                    break;
                default:
                case LocatorType.ID:
                    retValue = wb.Document.GetElementById(locator);
                    break;
            }
            if (throwExceptionWhenNotFound && retValue == null)
                throw new Exception("Control '" + locator + "' not found.");
            return retValue;
        }
        private HtmlElement GetElement(int index)
        {
            if (wb.Document == null)
                throw new Exception("Browser document is not available. You must navigate to an url before accessing document elements.");
            
            return (index < 0 ? null : _elements[index]);//wb.Document.All[index]);   
        }
        private HtmlElement WSelectSingleNode(string xpath)
        {
            int i = -1;
            GetNode(xpath, ref i);

            return GetElement(i);
        }
        internal XmlNode SelectSingleNode(string xpath)
        {
            int i = -1;
            return GetNode(xpath, ref i);
        }
        internal XmlNode GetNode(string locator, ref int nodeId)
        {
            return GetNode(locator, ref nodeId, false);
        }
        internal XmlNode GetNode(string locator, ref int nodeId, bool throwExceptionOnNotFound)
        {
            if (wb.Document == null)
                throw new Exception("Browser document is not available. You must navigate to an url before accessing document elements.");
            
            // XmlDocument xDoc = new XmlDocument();
            // xDoc.LoadXml(wb.Document.Body.OuterHtml);
                    
            string xpath = "";
            switch (GetLoacatorType(locator))
            {
                case LocatorType.XPath:
                    xpath = locator;
                    break;
                case LocatorType.AttributeValue:
                    string[] av = locator.Split(new char[] { '=' }, 2);
                    xpath = "//*[@" + av.GetValue(0).ToString() + "='" + av.GetValue(1).ToString() + "']";
                    break;
                default:
                case LocatorType.ID:
                    xpath = "//*[@id='" + locator + "']";
                    break;
            }
            XmlNode xnode = XBody.SelectSingleNode(xpath);
            if (xnode != null && xnode.Attributes == null)
                return xnode;
            string nId = "-1";
            if (xnode != null && xnode.Attributes != null && xnode.Attributes[NodeId] != null)
                nId = xnode.Attributes[NodeId].Value;

            if (xnode == null && throwExceptionOnNotFound)
                throw new Exception("Control '" + locator + "' not found.");

            nodeId = Convert.ToInt32(nId);
            return (nodeId == 0 ? null : xnode);
        }
        internal List<XmlNode> SelectNodes(string xpath)
        {
            if (wb.Document == null)
                throw new Exception("Browser document is not available. You must navigate to an url before accessing document elements.");
            
            //XmlDocument xDoc = new XmlDocument();
            //xDoc.LoadXml(wb.DocumentText);
            XmlNodeList xnodes = XBody.SelectNodes(xpath);
            List<XmlNode> list = new List<XmlNode>();
            if (xnodes != null)
            {
                foreach (XmlNode xn in xnodes)
                {
                    if (xn.Attributes[NodeId] == null)
                        continue;
                    string nodeId = "-1";
                    nodeId = xn.Attributes[NodeId].Value;
                    if (nodeId != "-1")
                    {
                        list.Add(xn);
                    }
                }
            }
            return list;
        }
        #endregion

        #region Action
        public void Click(string locator)
        {
            HtmlElement el = GetElement(locator);
            el.InvokeMember("click");
            _readyState = WebBrowserReadyState.Uninitialized;
        }
        public void Check(string locator)
        {
            HtmlElement el = GetElement(locator);
            el.SetAttribute("checked", "true");
            _readyState = WebBrowserReadyState.Uninitialized;
        }
        public void UnCheck(string locator)
        {
            HtmlElement el = GetElement(locator);
            el.SetAttribute("checked", "");
            _readyState = WebBrowserReadyState.Uninitialized;
        }
        public void SelectOption(string locator, string optionText)
        {
            int index = 0;
            XmlNode xNode = GetNode(locator, ref index, true);
            XmlNode xNodeCurrentSelection = xNode.SelectSingleNode("//option[@selected='true']");
            XmlAttribute nodeIdAttr = null;
            if (xNodeCurrentSelection != null)
            {
                nodeIdAttr = xNodeCurrentSelection.Attributes[NodeId];
                if (nodeIdAttr != null)
                {
                    HtmlElement ele = GetElement(Convert.ToInt32(nodeIdAttr.Value));
                    ele.SetAttribute("selected", "false");
                }
            }
            XmlNode xNodeNewSelection = xNode.SelectSingleNode("//option[text()='" + optionText + "']");
            if (xNodeNewSelection == null)
                throw new Exception("No option found with text " + optionText);
            nodeIdAttr = xNodeNewSelection.Attributes[NodeId];
            if (nodeIdAttr != null)
            {
                HtmlElement ele = GetElement(Convert.ToInt32(nodeIdAttr.Value));
                ele.SetAttribute("selected", "true");
            }
            _readyState = WebBrowserReadyState.Uninitialized;
        }
        public void Type(string locator, string value)
        {
            HtmlElement el = GetElement(locator);
            el.SetAttribute("value", value);
            _readyState = WebBrowserReadyState.Uninitialized;
        }
        public void DoubleClick(string locator)
        {
            HtmlElement el = GetElement(locator);
            el.InvokeMember("click");
            el.InvokeMember("click");
            _readyState = WebBrowserReadyState.Uninitialized;
        }
        public void KeyPress(string locator, char c)
        {
            HtmlElement el = GetElement(locator);
            el.Focus();
            System.Windows.Forms.SendKeys.SendWait(c.ToString());
        }
        public void MouseOver(string locator)
        {
            HtmlElement el = GetElement(locator);
            el.RaiseEvent("onMouseOver");
            //((IHTMLElement3)el.DomElement).FireEvent("onmouseover", ref el.DomElement);
        }
        public void TypeIntoFileUpload(string locator, string value)
        {
            throw new Exception("Function not implemented.");
        }
        public void WaitForPageLoad(int maxWait, bool exceptionOnTimeout)
        {
            Log("WaitForPageLoad begin");
            DateTime dtStart = DateTime.Now;
            bool isTimeOut = true;
            do
            {
                Application.DoEvents();
                Log("Status - " + _readyState.ToString());
                if (_readyState == WebBrowserReadyState.Complete)
                {
                    isTimeOut = false;
                    break;
                }
                System.Threading.Thread.Sleep(SleepTime);
            } while (((TimeSpan)DateTime.Now.Subtract(dtStart)).TotalMilliseconds < maxWait);
            Log("WaitForPageLoad end: Status - " + _readyState.ToString());
            if (isTimeOut && exceptionOnTimeout)
            {
                Log("URL - " + wb.Url.PathAndQuery);
                throw new Exception("Time out occured before page is completely loaded.");
            }
        }
        public void WaitForControlLoad(string locator, int maxWait)
        {
            Log("WaitForControlLoad begin");
            DateTime dtStart = DateTime.Now;
            bool isTimeOut = true;
            do
            {
                Application.DoEvents();
                HtmlElement el = GetElement(locator, false);

                if (el != null)
                {
                    isTimeOut = false;
                    break;
                }
                System.Threading.Thread.Sleep(SleepTime);
            } while (((TimeSpan)DateTime.Now.Subtract(dtStart)).TotalMilliseconds < maxWait);
            Log("WaitForControlLoad end");
            if (isTimeOut)
                throw new Exception("Time out occured before control '" + locator + "' is loaded.");
        }
        public void WaitForTextLoad(string text, int maxWait)
        {
            DateTime dtStart = DateTime.Now;
            bool isTimeOut = true;
            do
            {
                Application.DoEvents();

                if (IsTextPresent(text))
                {
                    isTimeOut = false;
                    break;
                }
                System.Threading.Thread.Sleep(SleepTime);
            } while (((TimeSpan)DateTime.Now.Subtract(dtStart)).TotalMilliseconds < maxWait);
            if (isTimeOut)
                throw new Exception("Time out occured before text '" + text + "' is loaded.");
        }
        public void WaitForControlEnable(string locator, int maxWait)
        {
            DateTime dtStart = DateTime.Now;
            bool isTimeOut = true;
            do
            {
                Application.DoEvents();
                if (IsEnabled(locator))
                {
                    isTimeOut = false;
                    break;
                }
                System.Threading.Thread.Sleep(SleepTime);
            } while (((TimeSpan)DateTime.Now.Subtract(dtStart)).TotalMilliseconds < maxWait);
            if (isTimeOut)
                throw new Exception("Time out occured before control '" + locator + "' is loaded.");
        }
        public void DragAndDrop(string sourceLocator, string destinationLocator)
        {
            throw new Exception("Function not implemented.");
        }
        public void FireEvent(string locator, string eventName)
        {
            HtmlElement el = GetElement(locator, true);
            el.RaiseEvent(eventName);
            //((IHTMLElement3)el).FireEvent(eventName, ref eobj);
        }
        public void Focus(string locator)
        {
            HtmlElement el = GetElement(locator);
            el.Focus();
        }
        public void GoBack(int maxWait)
        {
            wb.GoBack();
            _readyState = WebBrowserReadyState.Uninitialized;
        }
        public void Close()
        {
            base.Close();
        }
        public void OpenWindow(string url, int maxWait)
        {
            throw new Exception("Function not implemented.");
        }
        public void Refresh(int maxWait)
        {
            wb.Refresh();
            _readyState = WebBrowserReadyState.Uninitialized;
        }
        public void SelectFrame(string frameLocator)
        {
            throw new Exception("Function not implemented.");
        }
        public void SelectWindow(string windowId)
        {
            throw new Exception("Function not implemented.");
        }
        #endregion

        #region Fetch
        public Vibz.Web.Browser.Collection.URLList RedirectLinks
        {
            get
            {
                if (wb.Document == null)
                    throw new Exception("Browser document is not available. You must navigate to an url before accessing document elements.");
            
                URLList retValue = new URLList();
                foreach (HtmlElement ele in wb.Document.Links)
                {
                    try
                    {
                        HTMLAnchorElement anchor = (HTMLAnchorElement)ele.DomElement;
                        retValue.Add(new Url(((ele.InnerText == null || ele.InnerText.Trim() == "") ? "{No TEXT}" : ele.InnerText), anchor.href));
                    }
                    catch (Exception exc)
                    { }
                }
                //_progres.Enqueue(new ProgressElement("Fetched all Redirect links from the page."));
                return retValue;
            }
        }
        public Dictionary<string, string> ImageLinks
        {
            get
            {
                if (wb.Document == null)
                    throw new Exception("Browser document is not available. You must navigate to an url before accessing document elements.");
            
                Dictionary<string, string> retValue = new Dictionary<string, string>();
                foreach (HtmlElement ele in wb.Document.Images)
                {
                    try
                    {
                        HTMLImgClass img = (HTMLImgClass)ele.DomElement;
                        if (img.src != null && img.src != "")
                        {
                            string link = Url.AbsolutifyUrl(_baseUrl, img.src.Replace("about:", "")).AbsoluteUri;
                            if (!retValue.ContainsKey(link))
                                retValue.Add(link, (img.nameProp.Contains("&") ? img.nameProp.Substring(0, img.nameProp.IndexOf("&")) : img.nameProp));
                        }
                    }
                    catch (Exception exc)
                    { }
                }
                //_progres.Enqueue(new ProgressElement("Fetched all Image url from the page."));
                return retValue;
            }
        }
        public Vibz.Web.Browser.Collection.ImageList Images
        {
            get
            {
                if (_images == null)
                {
                    _images = new Vibz.Web.Browser.Collection.ImageList();
                    foreach (string imgLink in ImageLinks.Keys)
                    {
                        try
                        {
                            byte[] imageData = DownloadData(imgLink);
                            MemoryStream stream = new MemoryStream(imageData);
                            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                            // stream should not be closed to allow file save.
                            // stream.Close();
                            _images.Add(new Vibz.Web.Browser.Image(ImageLinks[imgLink], imgLink, img));

                        }
                        catch (Exception exc) { }
                    }
                    //_progres.Enqueue(new ProgressElement("Fetched all Images from the page."));
                }
                return _images;
            }
        }
        public string SourceCode
        {
            get
            {
                if (wb.Document == null)
                    throw new Exception("Browser document is not available. You must navigate to an url before accessing document elements.");
            
                if (wb.DocumentText != null)
                {
                    int stIndex = wb.DocumentText.ToLower().IndexOf("<body");
                    int endIndex = wb.DocumentText.ToLower().IndexOf("</body>") + 7;
                    int length = 0;
                    if (stIndex != -1 && endIndex != -1 && endIndex > stIndex)
                    {
                        length = endIndex - stIndex;
                        return wb.DocumentText.Remove(stIndex, length).Insert(stIndex, wb.Document.Body.OuterHtml);
                    }
                    return wb.DocumentText;
                }
                else
                    return "";
            }
        }
        public string[] JSLinks
        {
            get
            {
                if (wb.Document == null)
                    throw new Exception("Browser document is not available. You must navigate to an url before accessing document elements.");
            
                HtmlElementCollection eleCol = wb.Document.GetElementsByTagName("script");
                ArrayList retValue = new ArrayList();
                foreach (HtmlElement ele in eleCol)
                {
                    try
                    {
                        HTMLScriptElement script = (HTMLScriptElement)ele.DomElement;
                        if (script.src != null && script.src != "")
                            retValue.Add(Vibz.Web.Browser.Url.AbsolutifyUrl(_baseUrl, script.src).AbsoluteUri);
                    }
                    catch (Exception exc) { }
                }
                //_progres.Enqueue(new ProgressElement("Fetched JS urls from the page."));
                return ArrayListToArray<string>(retValue);
            }
        }
        
        public string GetFirstInnerText(string xpath)
        {
            HtmlElement n = GetElement(xpath);
            if (n != null)
            {
                return n.InnerText;
            }
            return null;
        }
        public string[] GetAllInnerText(string xpath)
        {
            List<XmlNode> nc = SelectNodes(xpath);
            ArrayList retValue = new ArrayList();
            if (nc != null)
            {
                foreach (XmlNode n in nc)
                {
                    try
                    {
                        retValue.Add(n.InnerText);
                    }
                    catch (Exception exc)
                    { }
                }
            }
            string[] retVal = ArrayListToArray<string>(retValue);
            //_progres.Enqueue(new ProgressElement("GetAllInnerText(" + xpath + ") :" + (retVal.Length > 10 ? retVal.Length + " records fetched." : String.Join(",", retVal))));
            return retVal;
        }
        public string GetFirstAttribute(string attrxpath)
        {
            XmlNode n = SelectSingleNode(attrxpath);
            if (n != null)
            {
                return n.Value;
            }
            return null;
        }
        public string GetFirstAttribute(string xpath, string attributeName)
        {
            XmlNode n = SelectSingleNode(xpath);
            if (n != null)
            {
                if (n.Attributes.Count != 0)
                {
                    //_progres.Enqueue(new ProgressElement("GetFirstAttribute(" + xpath + ", " + attributeName + ")" + " : " + n.Attributes[attributeName].Value));
                    return n.Attributes[attributeName].Value;
                }
            }
            return null;
        }
        public string[] GetAllAttributes(string xpath, string attributeName)
        {
            List<XmlNode> nc = SelectNodes(xpath);
            ArrayList retValue = new ArrayList();
            if (nc != null)
            {
                foreach (XmlNode n in nc)
                {
                    try
                    {
                        if (n.Attributes.Count != 0)
                            retValue.Add(n.Attributes[attributeName].Value);
                    }
                    catch (Exception exc)
                    { }
                }
            }
            string[] retVal = ArrayListToArray<string>(retValue);
            //_progres.Enqueue(new ProgressElement("GetAllInnerText(" + xpath + ") :" + (retVal.Length > 10 ? retVal.Length + " records fetched." : String.Join(",", retVal))));
            return retVal;
        }
        public DataTable GetTableContent(string repeaterXPath, Dictionary<string, string> offsetXPath)
        {
            DataTable dt = new DataTable();
            foreach (string key in offsetXPath.Keys)
                dt.Columns.Add(key);
            List<XmlNode> nc = SelectNodes(repeaterXPath);
            if (nc == null)
                return null;
            int cnt = nc.Count;
            for (int i = 1; i <= cnt; i++)
            {
                Vibz.Contract.Log.LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement("Fetching data in row " + i.ToString(), Vibz.Contract.Log.LogSeverity.Trace)); 
                System.Data.DataRow dr = dt.RowTemplate;
                foreach (string key in offsetXPath.Keys)
                {
                    XmlNode n = SelectSingleNode(repeaterXPath + "[" + i.ToString() + "]" + (offsetXPath[key].StartsWith("/") ? offsetXPath[key] : "/" + offsetXPath[key]));
                    if (n != null)
                        dr[key] = n.InnerText;
                }
                dt.Rows.Add(dr);
            }
            //_progres.Enqueue(new ProgressElement("GetTableContent(" + repeaterXPath + ",{cols}) :" + dt.Rows.Count.ToString() + " rows fetched."));
            return dt;
        }
        private byte[] DownloadData(string url)
        {
            try
            {
                WebClient client = new WebClient();
                return client.DownloadData(url);
            }
            catch (Exception exc) { }
            return null;
        }
        private T[] ArrayListToArray<T>(ArrayList list)
        {
            T[] returnValue = new T[list.Count];
            list.CopyTo(returnValue);
            return returnValue;
        }

        public Dictionary<string, string> GetAttributes(string locator)
        {
            int index = 0;
            Dictionary<string, string> retValue = new Dictionary<string, string>();
            XmlNode n = GetNode(locator, ref index, true);
            if (n == null)
                return retValue;
            if (n.NodeType != XmlNodeType.Element)
                throw new Exception("Element mismatch. Expected element is 'Node'. Element with locator '" + locator + "' is '" + n.NodeType + "'.");
            XmlAttributeCollection attrCol = n.Attributes;
            if (attrCol == null)
                return retValue;
            for (int i = 0; i < attrCol.Count; i++)
            {
                retValue.Add(attrCol[i].Name, attrCol[i].Value);
            }
            return retValue;
        }
        public int GetElementIndex(string locator)
        {
            int index = 0;
            GetNode(locator, ref index, true);
            return index;
        }
        public string GetLocation()
        {
            return _currentUrl;
        }
        public string GetInnerText(string locator)
        {
            HtmlElement ele = GetElement(locator);
            return ele.InnerText;
        }
        public string GetTitle()
        {
            if (wb.Document == null)
                throw new Exception("Browser document is not available. You must navigate to an url before accessing document elements.");
            
            return wb.Document.Title;
        }
        public string GetValue(string locator)
        {
            HtmlElement el = GetElement(locator);
            return el.GetAttribute("value");
        }
        #endregion

        #region Assert
        public bool IsExists(string locator)
        {
            HtmlElement el = GetElement(locator, false);
            return (el != null);
        }
        public bool IsChecked(string locator)
        {
            return CheckProperty(locator, "checked");
        }
        public bool IsTextPresent(string text)
        {
            if (wb.Document == null)
                throw new Exception("Browser document is not available. You must navigate to an url before accessing document elements.");
            
            return wb.Document.Body.InnerText.Contains(text);
        }
        public bool IsEditable(string locator)
        {
            return !CheckProperty(locator, "readonly");
        }
        public bool IsEnabled(string locator)
        {
            return !CheckProperty(locator, "disabled");
        }
        public bool IsVisible(string locator)
        {
            HtmlElement el = GetElement(locator);
            if (el.Style == null)
                return true;
            StyleList styles = new StyleList(el.Style);
            return (
                (styles.Get("visibility") == null || (styles.Get("visibility") != null && styles.Get("visibility").ToLower() != "hidden"))
                &&
                (styles.Get("display") == null || (styles.Get("display") != null && styles.Get("display").ToLower() != "none"))
                );
        }
        private bool CheckProperty(string locator, string propertyName)
        {
            HtmlElement el = GetElement(locator);
            return ((el.GetAttribute(propertyName) != null) && ((el.GetAttribute(propertyName).ToLower() == "true") || (el.GetAttribute(propertyName).ToLower() == propertyName)));
        }
        #endregion

        #region Dispose
        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        internal bool IsDisposed
        {
            get 
            {
                if (this.wb.IsDisposed)
                    return true;
                return _disposed; 
            }
            set { _disposed = value; }
        }
        #endregion

        void Log(string message)
        {
            toolStripStatusLabel1.Text = message;
            Vibz.Contract.Log.LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement("[WBrowser] - " + message, Vibz.Contract.Log.LogSeverity.Trace));
        }
    }
}
