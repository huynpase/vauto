using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;
using Vibz.Contract.Data;

namespace Vibz.Web.Browser.Instruction.Fetch
{
    [TypeInfo(Author="Vibzworld", Details = "Returns title of the document in the focussed window.",
        Version = "2.0")]
    public class GetTitle : FetchBase
    {
        public GetTitle()
            : base()
        {
                    
        }
        public GetTitle(string assignto)
            : base()
        {
            Output = assignto;
            
        }
        public override IData Fetch(Vibz.Contract.Data.DataHandler vList)
        {
            return new Vibz.Contract.Data.Text(Browser.Document.GetTitle());
        }
    }
}
