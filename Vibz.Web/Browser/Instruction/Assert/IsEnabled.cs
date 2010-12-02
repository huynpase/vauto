using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Assert
{
    [TypeInfo(Details = "Checks if the control associated with given locator is enabled or not.",
        Version = "2.0")]
    public class IsEnabled : AssertBase
    {

        [XmlAttribute("locator")]
        public string Locator;
        public IsEnabled()
            : base()
        {
                   
        }
        public IsEnabled(string locator)
            : base()
        {
            Locator = locator;
            
        }
        public override bool Assert(Vibz.Contract.Data.DataHandler vList)
        {
            return Browser.Document.IsEnabled(Locator);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Control '" + Locator + "' is " + (Result ? "enabled" : "not enabled") + ".");
            }
        }
        
    }
}
