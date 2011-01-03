using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Vibz.Studio
{
    public partial class ApiDocument : Form
    {
        public ApiDocument()
        {
            InitializeComponent();
            string resultFile = "apidoc.xml";
            CreateResultFile(resultFile);
            if (File.Exists(resultFile))
                wbDocument.Navigate(new FileInfo(resultFile).FullName);
        }

        private void CreateResultFile(string resultFile)
        {
            try
            {
                FileStream fs = new FileStream(resultFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    try
                    {
                        sw.WriteLine("<?xml-stylesheet type=\"text/xsl\" href=\"apidoc.xsl\" ?>" +
                            "<Document>" +
                            DocumentInfo +
                            Vibz.Interpreter.Document.Doc.XmlDocument.DocumentElement.OuterXml +
                            "</Document>");

                    }
                    catch (Exception exc)
                    {
                        sw.WriteLine("<![CDATA[Error occured while parsing. " + exc.Message + " ]]>");
                    }
                    finally
                    {
                        sw.Close();
                        fs.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Error occured while generating report text.", exc);
            }
        }
        string DocumentInfo
        {
            get {
                string retValue = "";
                retValue += "<title><![CDATA[" + LangResource.TextManager.GetString("Txt_APIDocument") + "]]></title>";
                retValue += "<copyright><![CDATA[" + LangResource.TextManager.GetString("Txt_FrameworkTitle") + " " + LangResource.TextManager.GetString("Txt_Copyright") + "]]></copyright>";
                retValue += "<author><![CDATA[" + LangResource.TextManager.GetString("Txt_Doc_Author") + "]]></author>";
                retValue += "<version><![CDATA[" + LangResource.TextManager.GetString("Txt_Version") + "]]></version>";
                retValue += "<frameversion><![CDATA[" + typeof(Vibz.Contract.IInstruction).Assembly.GetName().Version.ToString() + "]]></frameversion>";
                retValue += "<preface><![CDATA[" + LangResource.TextManager.GetString("Txt_Doc_Preface") + "]]></preface>";
                retValue += "<note><![CDATA[" + LangResource.TextManager.GetString("Txt_Doc_Note") + "]]></note>";
                retValue += "<properties><![CDATA[" + LangResource.TextManager.GetString("Txt_Doc_Properties") + "]]></properties>";
                return retValue;
            }
        }
    }
}