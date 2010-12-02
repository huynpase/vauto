using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Action.Synchronize
{
    [TypeInfo(Details = "Wait till the control associated to the given locator gets loaded.",
        Version = "2.0")]
    public class WaitForControlLoad : SynchronizeBase
    {
        [XmlAttribute("locator")]
        public string Locator;
        public WaitForControlLoad()
            : base()
        {
                    
        }
        public WaitForControlLoad(string locator, int maxWait)
            : base()
        {
            Locator = locator;
            MaxWait = maxWait;
            
        }
        
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.WaitForControlLoad(Locator, MaxWait);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Waited for control '" + Locator + "' to load.");
            }
        }
    }
}
