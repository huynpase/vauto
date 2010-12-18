using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;
using Vibz.Contract.Data;

namespace Vibz.Web.Browser.Instruction.Fetch
{
    [TypeInfo(Author="Vibzworld", Details = "Returns content of HTML table into a datatable object.",
        Version = "2.0")]
    public class GetTableContent : FetchBase
    {
        [XmlAttribute("repeaterxpath")]
        public string RepeaterXPath;

        [XmlAttribute("columnxpathset")]
        public string ColumnXPathSet;

        [XmlAttribute("xpathseperator")]
        public string XPathSeperator;
        
        public GetTableContent()
            : base()
        {
                    
        }
        public GetTableContent(string repeaterXPath, string columnXPathSet, string xPathSeperator, string assignto)
            : base()
        {
            RepeaterXPath = repeaterXPath;
            Output = assignto;
            ColumnXPathSet = columnXPathSet;
            XPathSeperator = xPathSeperator;
        }
        public override IData Fetch(Vibz.Contract.Data.DataHandler vList)
        {
            Dictionary<string, string> cols = new Dictionary<string, string>();
            string[] seps = XPathSeperator == "," ? new string[] { "," } : XPathSeperator.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string[] eles = ColumnXPathSet.Split(seps, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < eles.Length; i++)
            {
                cols.Add("Column_" + i.ToString(), eles[i]);
            }
            return Browser.Document.GetTableContent(RepeaterXPath, cols);
                    
            //return new Vibz.Contract.Data.Text(Browser.Document.GetInnerText(Locator));
        }
    }
}
