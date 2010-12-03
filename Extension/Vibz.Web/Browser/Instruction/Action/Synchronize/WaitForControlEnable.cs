using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract;


namespace Vibz.Web.Browser.Instruction.Action.Synchronize
{
    [TypeInfo(Details = "Wait till the control associated to the given locator gets enabled.",
        Version = "2.0")]
    public class WaitForControlEnable : SynchronizeBase
    {
        [XmlAttribute("locator")]
        public string Locator;
        public WaitForControlEnable()
            : base()
        {
                    
        }
        public WaitForControlEnable(string locator, int maxWait)
            : base()
        {
            Locator = locator;
            MaxWait = maxWait;
            
        }
        
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.WaitForControlEnable(Locator, MaxWait);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Waited for control '" + Locator + "' to enable.");
            }
        }
    }
}
