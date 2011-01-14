using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract.Attribute;
using Vibz.Contract.Data;

namespace Vibz.Web.Browser.Instruction.Fetch
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Returns array of all the attributes of the control node associated with given locator.",
        Version = WebInstructionBase.Vesrion)]
    public class GetAttributeValues : FetchBase
    {

        [XmlAttribute("locator")][AttributeInfo(WebInstructionBase.LocatorInfo)]
        public string Locator;
        [XmlAttribute("attributename")]
        [AttributeInfo("Name of attribute")]
        public string AttributeName;
        public GetAttributeValues()
            : base()
        {
                    
        }
        public GetAttributeValues(string locator, string attributeName, string assignto)
            : base()
        {
            Locator = locator;
            AttributeName = attributeName;
            Output = assignto;
        }
        public override IData Fetch(Vibz.Contract.Data.DataHandler vList)
        {
            return new Vibz.Contract.Data.TextArray(Browser.Document.GetAllAttributes(Locator, AttributeName));
        }
    }
}
