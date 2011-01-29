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
using Vibz.Contract.Common;
using Vibz.Contract;
using Vibz.Contract.Attribute;
using System.IO;
using System.Reflection;
using Vibz;
namespace Vibz.Web.Browser.Instruction
{
    public abstract class WebInstructionBase : InstructionBase, IError 
    {
        public const string Author = "Vibzworld";
        public const string Vesrion = "2.2";
        public const string OnTimeOutInfo = "This setting determines how the execution should proceed when time out occurs before instruction has completed.";
        public const string MaxWaitInfo = "Maximum time to wait for the instruction to complete before declaring that instruction has failed. Default value is 60000";
        public const string AssignToInfo = "Name of the variable where the output from the instruction will be saved.";
        public const string LocatorInfo = "Identity of the control in context.";
        static IBrowser _browser = null;
        static object _padLock = new object();
        static System.Threading.Thread _ownerThread = null;
        protected Vibz.Contract.Data.DataHandler vList = null;
        internal static IBrowser Browser
        {
            get {
                if (_browser == null || _ownerThread == null || !_ownerThread.IsAlive)
                {
                    lock (_padLock)
                    {
                        if (_browser == null || _ownerThread == null || !_ownerThread.IsAlive)
                        {
                            Vibz.Contract.Log.LogElement progress = new Vibz.Contract.Log.LogElement("Initiating Browser.");
                            string configPath = new System.IO.FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName + "/browser.config";
                            Configuration.ConfigManager manager = Configuration.ConfigManager.LoadConfig(configPath);
                            string assembly = manager.Settings["BrowserAssembly"];
                            string clas = manager.Settings["BrowserClass"];
                            string init = manager.Settings["BrowserInitializingFunction"];
                            bool showBrowser = true;
                            Boolean.TryParse(manager.Settings["ShowBrowser"], out showBrowser);
                            _browser = (IBrowser)Reflection.Runtime.CreateInstanceAndInitialize(assembly, clas, init, new object[] { showBrowser });
                            _ownerThread = System.Threading.Thread.CurrentThread;
                        }
                    }
                }
                return _browser;
            }
        }
        string _endInfo = null;
        protected Exception GetBrowserException(Exception exc)
        {
            foreach (string key in BrowserStateInfo.Keys)
            {
                exc.Data.Add(key, BrowserStateInfo[key]);
            }
            return exc;
        }
        protected string GetInfo()
        {
            return _endInfo;
        }
        protected void SetInfo(string infoMessage)
        {
            _endInfo = infoMessage;
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                if (_endInfo == null)
                    _endInfo = "Instruction complete.";
                return new Vibz.Contract.Log.LogElement(_endInfo);
            }
        }
        protected Dictionary<string, string> BrowserStateInfo
        {
            get {
                Dictionary<string, string> retValue = new Dictionary<string, string>();
                if (_browser != null && _browser.Document != null)
                    retValue.Add("Url", _browser.Document.GetLocation());
                return retValue;
            }
        }
    }
}
