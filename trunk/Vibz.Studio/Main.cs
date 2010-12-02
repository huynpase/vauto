using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Vibz.Contract.Log;
using Vibz.Interpreter;
using System.Threading;
using System.Reflection;

namespace Vibz.Studio
{
    public partial class Main : Form
    {
        Thread _fetcher;
        Executer _ex;
        Dictionary<string, string> _objFetched = new Dictionary<string, string>();
        delegate void WorkerDelegate(object param);
        bool _suspendDocumentLoadEvent = false;

        public Main()
        {
            InitializeComponent();
            //wbPage.ScriptErrorsSuppressed = true;
            //txtUrl.Text = "http://money.rediff.com/gainers";
            //txtDownload.Text = Path.GetFullPath(Application.StartupPath) + "\\..\\..\\..\\Document\\Images";
            //txtExtractData.Text = Path.GetFullPath(Application.StartupPath) + "\\..\\..\\..\\Document\\data.txt";
            txtCrowler.Text = Path.GetFullPath(Application.StartupPath) + "\\..\\..\\Document\\testhtml.vibz";
        }
        #region Old
        //private void ResetAll()
        //{
        //    if (cbClearOnPostBack.Checked)
        //    {
        //        rtbHeader.Clear();
        //        rtbJS.Clear();
        //        rtbRedirects.Clear();
        //        rtbSource.Clear();
        //        rtbImages.Clear();
        //    }
        //}
        
        //public void FetchDetails(object objInput)
        //{
        //    ResetAll();

        //    _ex = Spider.Load(((object[])objInput).GetValue(0).ToString());

        //    string value = "";
        //    // Source View
        //    _objFetched.Add("Source", _ex.Document.SourceCode);

        //    // JS Links
        //    value = "";
        //    foreach (string js in _ex.Document.JSLinks)
        //        value += js + "\r\n";
        //    _objFetched.Add("JS", value);

        //    // Redirects Links
        //    value = "";
        //    foreach (Vibz.Web.Url lnk in _ex.Document.RedirectLinks)
        //        value += lnk.Text + " : " + lnk.Link + "\r\n";
        //    _objFetched.Add("Link", value);

        //    // Page Headers
        //    value = "";
        //    foreach (string header in _ex.PageHeaders.Keys)
        //        value += header + " : " + _ex.PageHeaders[header] + "\r\n";
        //    _objFetched.Add("Header", value);

        //    // Images
        //    value = "";
        //    foreach (string img in _ex.Document.ImageLinks.Keys)
        //        value += img + "\r\n";
        //    _objFetched.Add("Image", value);

        //    if ((bool)((object[])objInput).GetValue(3))
        //        _ex.DownloadAllImages(((object[])objInput).GetValue(1).ToString());

        //    if ((bool)((object[])objInput).GetValue(4))
        //    {
        //        string[] list = _ex.Document.GetAllInnerText("//table[@class='dataTable']/tbody/tr/td[1]/a/text()");
        //        foreach (string text in list)
        //            File.AppendAllText(((object[])objInput).GetValue(2).ToString(), "\r\n" + text);

        //        Dictionary<string, string> cols = new Dictionary<string, string>();
        //        cols.Add("Company", "td[1]/a/text()");
        //        cols.Add("Group", "td[2]/text()");
        //        DataTable dt = _ex.Document.GetTableContent("//table[@class='dataTable']/tbody/tr", cols);
        //        foreach (DataRow dr in dt.Rows)
        //            File.AppendAllText(((object[])objInput).GetValue(2).ToString(), "\r\n" + dr["Company"] + "\t" + dr["Group"]);
        //    }
        //}

        

        //private void btnGo_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        _suspendDocumentLoadEvent = false;
        //        wbPage.Navigate(txtUrl.Text);
        //    }
        //    catch (Exception exc)
        //    {
        //        ShowMessageBox("Error while processing request." + exc.Message);
        //    }
        //}

        //private void wbPage_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    if (wbPage.ReadyState == WebBrowserReadyState.Complete && !_suspendDocumentLoadEvent)
        //    {
        //        WorkerDelegate del = new WorkerDelegate(FetchDetails);
        //        RunAsWorkerProcess(del, new object[] { wbPage.Document.Url.AbsoluteUri, txtDownload.Text, txtExtractData.Text, cbDownload.Checked, cbExtractData.Checked });
        //    }
        //}
        //private void btnBrowse_Click(object sender, EventArgs e)
        //{
        //    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        txtDownload.Text = folderBrowserDialog1.SelectedPath;
        //    }
        //}

        //private void cbDownload_CheckedChanged(object sender, EventArgs e)
        //{
        //    txtDownload.Enabled = cbDownload.Checked;
        //    btnBrowse.Enabled = cbDownload.Checked;
        //}

        //private void cbExtractData_CheckedChanged(object sender, EventArgs e)
        //{
        //    txtExtractData.Enabled = cbExtractData.Checked;
        //    btnExtractData.Enabled = cbExtractData.Checked;
        //}

        //private void btnExtractData_Click(object sender, EventArgs e)
        //{
        //    openFileDialog1.Filter = "Text files (*.txt)|*.txt";
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        txtExtractData.Text = openFileDialog1.FileName;
        //    }
        //}
        #endregion
        private void UpdateProgress()
        {
            //while (Progress.Instance.Count > 0)
            //{
            //    ILog log = Progress.Instance.Dequeue();
            //    switch (log.Type)
            //    { 
            //        case ProgressType.Element:
            //            switch (((ProgressElement)log).ElementType)
            //            {
            //                case ProgressElementType.Error:
            //                    rtbProgress.SelectionFont = new Font("Arial", (float)8, FontStyle.Bold);
            //                    rtbProgress.SelectionColor = Color.Red;
            //                    break;
            //                case ProgressElementType.Warn:
            //                    rtbProgress.SelectionFont = new Font("Arial", (float)8, FontStyle.Regular);
            //                    rtbProgress.SelectionColor = Color.OrangeRed;
            //                    break;
            //                default:
            //                    rtbProgress.SelectionFont = new Font("Arial", (float)8, FontStyle.Regular);
            //                    rtbProgress.SelectionColor = Color.Black;
            //                    break;
            //            }
            //            break;
            //        case ProgressType.Set:
            //            rtbProgress.SelectionFont = new Font("Arial", (float)8, FontStyle.Regular);
            //            rtbProgress.SelectionColor = Color.Black;
            //            break;
            //    }
            //    rtbProgress.AppendText("\r\n" + log.Time.ToString("hh:mm:ss") + " : " + log.Message);
            //    System.IO.File.AppendAllText("C:/amit/amit.log", "\r\n" + log.Message);
            //    rtbProgress.ScrollToCaret();
            //}
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            if (_ex != null)
                UpdateProgress();
            //if (!_fetcher.IsAlive)
            //{
            //    if (_objFetched.ContainsKey("Header"))
            //        rtbHeader.AppendText(_objFetched["Header"]);
            //    if (_objFetched.ContainsKey("Image"))
            //        rtbImages.AppendText(_objFetched["Image"]);
            //    if (_objFetched.ContainsKey("JS"))
            //        rtbJS.AppendText(_objFetched["JS"]);
            //    if (_objFetched.ContainsKey("Link"))
            //        rtbRedirects.AppendText(_objFetched["Link"]);
            //    if (_objFetched.ContainsKey("Source"))
            //        rtbSource.AppendText(_objFetched["Source"]);
            //    timer1.Stop();
            //    UpdateProgress();
            //    rtbProgress.AppendText("\r\n" + DateTime.Now.ToString("hh:mm:ss") + " : Execution Complete.");
            //    rtbProgress.ScrollToCaret();
            //}
        }

        private void btnBrowseCrowler_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Crowl files (*.vibz)|*.vibz";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtCrowler.Text = openFileDialog1.FileName;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //TestWrite();
            _suspendDocumentLoadEvent = true;
            WorkerDelegate del = new WorkerDelegate(ProcessScriptFile);
            RunAsWorkerProcess(del, new object[] { txtCrowler.Text, "test" });
            
        }

        

        private void RunAsWorkerProcess(WorkerDelegate del, object param)
        {
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            rtbProgress.SelectionFont = new Font("Arial", (float)8, FontStyle.Bold);
            rtbProgress.SelectionColor = Color.Black;
            rtbProgress.AppendText("\r\n" + DateTime.Now.ToString("hh:mm:ss") + " : Extraction of data started.");
            _fetcher = new Thread(new ParameterizedThreadStart(del));
            _fetcher.SetApartmentState(ApartmentState.STA);
            _fetcher.Start(param);
            timer1.Start();
        }

        public void ProcessScriptFile(object param)
        {
            try
            {
                _ex = new Vibz.Interpreter.Executer();
                _ex.Process(null);
            }
            catch (Exception exc)
            {
                //Progress.Instance.Enqueue(new ProgressElement("Execution failed. " + GetFullException(exc), ProgressElementType.Error));
            }
        }
        public string GetFullException(Exception exc)
        {
            return exc.Message + "\r\n\t" + ((exc.InnerException != null) ? GetFullException(exc.InnerException) : "");
        }

        

        
        
        //private void TestWrite()
        //{
        //    Vibz.Web.Interpreter.Script.FileScript f = new Vibz.Web.Interpreter.Script.FileScript();
        //    Vibz.Web.Interpreter.Script.CrowlScript c = new Vibz.Web.Interpreter.Script.CrowlScript();
        //    c.Name = "yahoo";
        //    c.BaseURL = "http://www.yahoo.com";

        //    Vibz.Web.Interpreter.Script.Instruction.Action.Synchronize.OpenURL openUrl = new Vibz.Web.Interpreter.Script.Instruction.Action.Synchronize.OpenURL("http://www.yahoo.com", 30000);
        //    c.Operation.Add(openUrl);
        //    Vibz.Web.Interpreter.Script.Instruction.Fetch.GetHtmlSource html = new Vibz.Web.Interpreter.Script.Instruction.Fetch.GetHtmlSource("abc");
        //    c.Operation.Add(html);
        //    Vibz.Web.Interpreter.Script.Instruction.IO.Write wr = new Vibz.Web.Interpreter.Script.Instruction.IO.Write("C://Amit/spider.txt", "hahaha");
        //    c.Operation.Add(wr);
            
        //    Vibz.Web.Interpreter.Script.Variables.String str = new Vibz.Web.Interpreter.Script.Variables.String("text", "amit");
        //    c.Variables.Add(str);
        //    Vibz.Web.Interpreter.Script.Variables.Integer i = new Vibz.Web.Interpreter.Script.Variables.Integer("Num", 3267);
        //    c.Variables.Add(i);

        //    f.AddCrowler(c);

        //    _ex = Spider.GetUIExtractor(new object[] { wbPage });
        //    Vibz.Web.Interpreter.FileParser.Save(f, "C:\\Amit\\Vibz.Studio\\Document\\unittest2.vibz");

        //}
    }
}