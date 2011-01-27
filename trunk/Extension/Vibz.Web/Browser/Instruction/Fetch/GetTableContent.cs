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
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract.Attribute;
using Vibz.Contract.Data;

namespace Vibz.Web.Browser.Instruction.Fetch
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Returns content of HTML table into a datatable object.",
        Version = WebInstructionBase.Vesrion)]
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
        public override IData Fetch()
        {
            Dictionary<string, string> cols = new Dictionary<string, string>();
            string[] seps = XPathSeperator == "," ? new string[] { "," } : XPathSeperator.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string[] eles = ColumnXPathSet.Split(seps, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < eles.Length; i++)
            {
                cols.Add("Column_" + i.ToString(), eles[i]);
            }
            Vibz.Contract.Data.DataTable retValue = Browser.Document.GetTableContent(RepeaterXPath, cols);
            if (retValue != null)
                SetInfo(retValue.Rows.Count.ToString() + " records fetched for.");
            return retValue;
        }
    }
}
