using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Action.Synchronize
{
    [TypeInfo(Author="Vibzworld", Details = "Opens the given url in a new browser.",
        Version = "2.0")]
    public class OpenWindow : SynchronizeBase
    {
        [XmlAttribute("url")]
        public string Url;
        public OpenWindow()
            : base()
        {
                    
        }
        public OpenWindow(string url, int maxWait)
            : base()
        {
            MaxWait = maxWait;
            Url = url;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.OpenWindow(vList.Evaluate(Url), MaxWait);
        }
    }
}
