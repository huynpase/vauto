using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Action.Synchronize
{
    [TypeInfo(Author="Vibzworld", Details = "Wait till the document of the focussed browser gets loaded.",
        Version = "2.0")]
    public class WaitForPageLoad : SynchronizeBase
    {
        public WaitForPageLoad()
            : base()
        {
                    
        }
        public WaitForPageLoad(int maxWait)
            : base()
        {
            MaxWait = maxWait;
            
        }
        
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.WaitForPageLoad(MaxWait, true);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Waited for page load.");
            }
        }
    }
}
