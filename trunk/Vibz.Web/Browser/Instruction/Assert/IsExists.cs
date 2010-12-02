using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Assert
{
    [TypeInfo(Details = "Checks existance of the control associated with given locator.",
        Version = "2.0")]
    public class IsExists : AssertBase
    {

        [XmlAttribute("locator")]
        public string Locator;
        public IsExists()
            : base()
        {
                   
        }
        public IsExists(string locator)
            : base()
        {
            Locator = locator;
            
        }
        public override bool Assert(Vibz.Contract.Data.DataHandler vList)
        {
            return Browser.Document.IsExists(Locator);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Control '" + Locator + "' " + (Result ? "exists" : "does not exists") + ".");
            }
        }
    }
}
