using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Details = "UnChecks the checkbox associated to the given locator.",
        Version = "2.0")]
    public class UnCheck : ActionBase
    {
        [XmlAttribute("locator")]
        public string Locator;
        public UnCheck():base() {
                    
        }
        public UnCheck(string locator)
            : base()
        {
            Locator = locator;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.UnCheck(Locator);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Unchecked the checkbox '" + Locator + "'.");
            }
        }
    }
}
