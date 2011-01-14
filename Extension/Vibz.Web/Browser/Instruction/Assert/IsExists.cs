using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Assert
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Checks existance of the control associated with given locator.",
        Version = WebInstructionBase.Vesrion)]
    public class IsExists : AssertBase
    {

        [XmlAttribute("locator")][AttributeInfo(WebInstructionBase.LocatorInfo)]
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
