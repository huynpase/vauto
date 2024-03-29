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
using Vibz.Report;
using Vibz.Contract.Log;
using Vibz.Contract;
using System.Xml;
using System.IO;

namespace Vibz.Report.Xml
{
    public class XmlReport : ReportBase
    {
        public override void Export(LogElement log)
        {
            SaveReport(FilePath, CreateNode(log));
        }
        string CreateNode(LogElement log)
        {
            string content = "<log severity=\"" + log.Severity.ToString() + 
                "\" time=\"" + log.Time.ToString("hh:mm:ss") + 
                "\"><message><![CDATA[" + log.Message + "]]></message>";
            foreach (LogElement iLog in log.InnerLog)
            {
                content+= CreateNode(iLog);
            }
            content += "</log>";
            return content;
        }
        public static bool SaveReport(string fileName, string xmlcontent)
        {
            if (File.Exists(fileName) && File.ReadAllText(fileName).Trim() != "")
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(fileName);
                    XmlNode xNode = doc.SelectSingleNode("//report");
                    xNode.InnerXml += xmlcontent;
                    doc.Save(fileName);
                    return true;
                }
                catch (Exception exc)
                {
                    throw new Exception("Xml file could not be created.", exc);
                }
            }
            else
            {
                string content = "<report>";
                content += xmlcontent;
                content += "</report>";
                XmlTextWriter writer = new XmlTextWriter(fileName, null);
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(content);
                    writer.Formatting = Formatting.Indented;
                    doc.Save(writer);
                    return true;
                }
                catch (Exception exc)
                {
                    throw new Exception("Xml file could not be created.", exc);
                }
                finally
                {
                    writer.Flush();
                    writer.Close();
                }
            }
        }
    }
}
