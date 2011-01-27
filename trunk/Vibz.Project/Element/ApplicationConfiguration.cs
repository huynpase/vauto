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
using Vibz.Contract;
using Vibz.Helper;
using Vibz.Interpreter.Plugin;
using Vibz.Contract.Log;
using Vibz.Interpreter.Configuration;

namespace Vibz.Solution.Element
{
    public class ApplicationConfiguration
    {
        XmlDocument xDoc;
        List<IReport> _reports = null;
        string _filePath;
        public ApplicationConfiguration(string filePath)
        {
            xDoc = new XmlDocument();
            if (!File.Exists(filePath))
                throw new Exception("Application Configuration file not found.");
            try
            {
                Vibz.Contract.Log.LogElement progress = new Vibz.Contract.Log.LogElement("Initializing application environment.");
                xDoc.Load(filePath);
                _filePath = filePath;
            }
            catch (Exception exc)
            {
                throw new Exception("Error occured during application configuration settings. " + exc.Message);
            }
        }
        public string ToString()
        {
            XmlNode xn = xDoc.SelectSingleNode("//" + Register.NodeName);
            if (xn == null) return "";
            return xn.OuterXml;
        }
        public void SetReportStatus(IReport report, bool status)
        {
            XmlNode xnReports = xDoc.SelectSingleNode("//" + ReportManager.NodeName);
            XmlNodeList xnlCS = xnReports.SelectNodes(Register.Include.NodeName);
            foreach (XmlNode xnCS in xnlCS)
            {
                if (xnCS.Attributes == null)
                    continue;
                string name = (xnCS.Attributes[Register.Include.Name] == null ? "" : xnCS.Attributes[Register.Include.Name].Value);
                if (name == report.ReportName)
                {
                    if (xnCS.Attributes[Register.Include.Status] == null)
                    {
                        XmlAttribute attr = xDoc.CreateAttribute(Register.Include.Status);
                        attr.Value = (status ? "active" : "inactive");
                        xnCS.Attributes.Append(attr);
                    }
                    else
                        xnCS.Attributes[Register.Include.Status].Value = (status ? "active" : "inactive");
                    break;
                }
            }
            xDoc.Save(_filePath);
        }
        public void RemoveReport(IReport report)
        {
            XmlNode xnReports = xDoc.SelectSingleNode("//" + ReportManager.NodeName);
            XmlNodeList xnlCS = xnReports.SelectNodes(Register.Include.NodeName);
            foreach (XmlNode xnCS in xnlCS)
            {
                if (xnCS.Attributes == null)
                    continue;
                string name = (xnCS.Attributes[Register.Include.Name] == null ? "" : xnCS.Attributes[Register.Include.Name].Value);
                if (name == report.ReportName)
                {
                    xnReports.RemoveChild(xnCS);
                    break;
                }
            }
            xDoc.Save(_filePath);
        }
        public void AddReport(IReport report)
        {
            string content = "<" + Register.Include.NodeName +
                " " + Register.Include.Name + "=\"" + report.ReportName + "\"" +
                " " + Register.Include.Status + "=\"active\">";
            foreach (string key in report.Configuration.Keys)
            {
                content += "<" + Register.Include.Param.NodeName + " " + Register.Include.Param.Name + "=\"" + key + "\" " + Register.Include.Param.Value + "=\"" + report.Configuration[key] + "\"></" + Register.Include.Param.NodeName + ">";
            }
            content += "</" + Register.Include.NodeName + ">";
            XmlNode xnReports = xDoc.SelectSingleNode("//" + ReportManager.NodeName);
            xnReports.InnerXml += content;
            xDoc.Save(_filePath);
        }
        public void SetParameters(IReport report, Dictionary<string, string> parameters)
        {
            foreach (string key in parameters.Keys)
            {
                if (report.Configuration.ContainsKey(key))
                {
                    report.Configuration[key] = parameters[key];
                }
            }
            XmlNodeList xnl = xDoc.SelectNodes("//" + ReportManager.NodeName + "/" + Register.Include.NodeName + "[@" + Register.Include.Name + "='" + report.ReportName + "']/" + Register.Include.Param.NodeName);
            foreach (XmlNode xn in xnl)
            {
                if (xn.Attributes == null)
                    continue;
                string name = (xn.Attributes[Register.Include.Param.Name] == null ? "" : xn.Attributes[Register.Include.Param.Name].Value);
                if (name == "")
                    continue;

                if (report.Configuration.ContainsKey(name))
                {
                    if (xn.Attributes[Register.Include.Param.Value] == null)
                    {
                        XmlAttribute attr = xDoc.CreateAttribute(Register.Include.Param.Value);
                        attr.Value = report.Configuration[name];
                        xn.Attributes.Append(attr);
                    }
                    else
                        xn.Attributes[Register.Include.Param.Value].Value = report.Configuration[name];
                }
            }
            xDoc.Save(_filePath);
        }
        public List<IReport> ReportList
        {
            get
            {
                if (_reports == null)
                {
                    _reports = new List<IReport>();
                    XmlNodeList xnlCS = xDoc.SelectNodes("//" + ReportManager.NodeName + "/" + Register.Include.NodeName);
                    foreach (XmlNode xnCS in xnlCS)
                    {
                        if (xnCS.Attributes == null)
                            continue;
                        string name = (xnCS.Attributes[Register.Include.Name] == null ? "" : xnCS.Attributes[Register.Include.Name].Value);
                        if (name == "")
                            continue;
                        XmlNode xn = PluginManager.Document.SelectSingleNode("//" + Register.NodeName + "/" + ReportManager.NodeName + "/" + Register.Include.NodeName + "[@" + Register.Include.Name + "='" + name + "']");
                        if (xn == null)
                            throw new Exception("Report processor '" + name + "' is not registered.");
                        string reference = (xn.Attributes[Register.Include.Reference] == null ? "" : xn.Attributes[Register.Include.Reference].Value);
                        if (reference == "")
                            throw new Exception("Report processor '" + name + "' is corrupted. Reference is missing.");
                        string[] refPart = reference.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (refPart.Length != 2)
                            throw new Exception("Reference for Report processor should be specified with assembly path and the class fullname seperated by a comma.");
                        string assembly = Vibz.Reflection.Runtime.GetAbsolutePath(refPart.GetValue(0).ToString());
                        string clas = refPart.GetValue(1).ToString();
                        Dictionary<string, string> param = Xml.GetParameters(xn);

                        Dictionary<string, string> paramApp = Xml.GetParameters(xnCS);
                        foreach (string key in paramApp.Keys)
                        {
                            if (!param.ContainsKey(key))
                                LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement(key + " is not a valid parameter for report " + name, Vibz.Contract.Log.LogSeverity.Warn));
                            else
                                param[key] = paramApp[key];
                        }
                        IReport report = (IReport)Reflection.Runtime.CreateInstanceAndInitialize(assembly, clas, "Init", new object[] { param });
                        report.Configuration = param;
                        report.Status = (xnCS.Attributes[Register.Include.Status] != null && xnCS.Attributes[Register.Include.Status].Value.ToLower() == "inactive" ? ReportStatus.Inactive : ReportStatus.Active);
                        report.ReportName = name;
                        _reports.Add(report);
                    }
                }
                return _reports;
            }
        }
    }
}
