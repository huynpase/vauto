using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using Vibz.Contract;
using Vibz.Contract.Data;

namespace Vibz.Web.Browser.Instruction.Fetch
{
    [TypeInfo(Details = "Returns value for the control node associated with given locator.",
       Version = "2.0")]
    public class GetValue : FetchBase
    {

        [XmlAttribute("locator")]
        public string Locator;
        public GetValue() 
            : base()
        {
                    
        }
        public GetValue(string locator, string assignto)
            : base()
        {
            Locator = locator;
            Output = assignto;
            
        }
        public override IData Fetch(Vibz.Contract.Data.DataHandler vList)
        {
            return new Vibz.Contract.Data.Text(Browser.Document.GetValue(Locator));
        }
    }
}
