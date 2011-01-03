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
        public const string OnTimeOutInfo = "This setting determines how the execution should proceed when time out occurs before instruction has completed.";
        public const string MaxWaitInfo = "Maximum time to wait for the instruction to complete before declaring that instruction has failed. Default value is 60000";
        public const string AssignToInfo = "Name of the variable where the output from the instruction will be saved.";
        public const string LocatorInfo = "Identity of the control in context.";
        static IBrowser _browser = null;
        static object _padLock = new object();
        internal static IBrowser Browser
        {
            get {
                if (_browser == null)
                {
                    lock (_padLock)
                    {
                        if (_browser == null)
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
                        }
                    }
                }
                return _browser;
            }
        }
    }
}
