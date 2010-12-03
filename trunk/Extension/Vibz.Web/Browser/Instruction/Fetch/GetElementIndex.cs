using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;
using Vibz.Contract.Data;

namespace Vibz.Web.Browser.Instruction.Fetch
{
    [TypeInfo(Details = "Returns index of the control node associated with given locator.",
        Version = "2.0")]
    public class GetElementIndex : FetchBase
    {

        [XmlAttribute("locator")]
        public string Locator;
        public GetElementIndex()
            : base()
        {
                    
        }
        public GetElementIndex(string locator, string assignto)
            : base()
        {
            Locator = locator;
            Output = assignto;
            
        }
        public override IData Fetch(Vibz.Contract.Data.DataHandler vList)
        {
            return new Vibz.Contract.Data.Text(Browser.Document.GetElementIndex(Locator).ToString());
        }
    }
}
