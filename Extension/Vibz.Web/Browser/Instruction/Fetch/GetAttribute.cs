using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract.Attribute;
using Vibz.Contract.Data;

namespace Vibz.Web.Browser.Instruction.Fetch
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Returns value of attribute for the control node associated with given locator.",
        Version = WebInstructionBase.Vesrion)]
    public class GetAttribute : FetchBase
    {

        [XmlAttribute("locator")][AttributeInfo(WebInstructionBase.LocatorInfo)]
        public string Locator;
        public GetAttribute()
            : base()
        {
                    
        }
        public GetAttribute(string locator, string assignto)
            : base()
        {
            Locator = locator;
            Output = assignto;
            
        }
        public override IData Fetch(Vibz.Contract.Data.DataHandler vList)
        {
            return new Vibz.Contract.Data.Text(Browser.Document.GetFirstAttribute(Locator));
        }
    }
}
