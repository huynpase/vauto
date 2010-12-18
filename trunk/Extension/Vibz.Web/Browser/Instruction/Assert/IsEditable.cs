using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Assert
{
    [TypeInfo(Author="Vibzworld", Details = "Checks if the control associated with given locator is editable or not.",
        Version = "2.0")]
    public class IsEditable : AssertBase
    {

        [XmlAttribute("locator")]
        public string Locator;
        public IsEditable()
            : base()
        {
                   
        }
        public IsEditable(string locator)
            : base()
        {
            Locator = locator;
            
        }
        public override bool Assert(Vibz.Contract.Data.DataHandler vList)
        {
            return Browser.Document.IsEditable(Locator);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Control '" + Locator + "' is " + (Result ? "editable" : "not editable") + ".");
            }
        }
    }
}
