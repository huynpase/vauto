using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract;


namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Details = "Checks the checkbox associated to the given locator.",
        Version = "2.0")]
    public class Check : ActionBase
    {
        [XmlAttribute("locator")]
        public string Locator;
        public Check() : base() { }
        public Check(string locator)
            : base()
        {
            Locator = locator;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.Check(Locator);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Checked the checkbox '" + Locator + "'.");
            }
        }
    }
}
