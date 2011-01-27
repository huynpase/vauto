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
using Vibz.Contract;
using Vibz.Contract.Log;

namespace Vibz.Interpreter.Configuration
{
    public class ReportManager
    {
        public const string NodeName = "report";
        static List<IReport> _reports = null;
        public static void Reset()
        {
            _reports = null;
        }
        static internal List<IReport> ReportList
        {
            get
            {
                if (_reports == null)
                {
                    _reports = new List<IReport>();
                    XmlNodeList xnlCS = ConfigManager.Instance.ExecutionUnit.ConfigSection.SelectNodes("//" + ReportManager.NodeName + "/" + Register.Include.NodeName);
                    foreach (XmlNode xnCS in xnlCS)
                    {
                        if (xnCS.Attributes == null)
                            continue;
                        string name = (xnCS.Attributes[Register.Include.Name] == null ? "" : xnCS.Attributes[Register.Include.Name].Value);
                        if (name == "")
                            continue;
                        XmlNode xn = Plugin.PluginManager.Document.SelectSingleNode("//" + Register.NodeName + "/" + ReportManager.NodeName + "/" + Register.Include.NodeName + "[@" + Register.Include.Name + "='" + name + "']");
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
                        Dictionary<string, string> param = Vibz.Helper.Xml.GetParameters(xn);

                        Dictionary<string, string> paramApp = Vibz.Helper.Xml.GetParameters(xnCS);
                        foreach (string key in paramApp.Keys)
                        {
                            if (!param.ContainsKey(key))
                                LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement(key + " is not a valid parameter for report " + name, Vibz.Contract.Log.LogSeverity.Warn));
                            else
                                param[key] = paramApp[key];
                        }
                        IReport report = (IReport)Reflection.Runtime.CreateInstanceAndInitialize(assembly, clas, "Init", new object[] { param });
                        report.ReportPath = ConfigManager.Instance.ExecutionUnit.ReportPath;
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
