using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Action.Synchronize
{
    [TypeInfo(Author="Vibzworld", Details = "Wait till the given text gets loaded.",
        Version = "2.0")]
    public class WaitForTextLoad : SynchronizeBase
    {
        [XmlAttribute("text")]
        public string Text;
        public WaitForTextLoad()
            : base()
        {
                    
        }
        public WaitForTextLoad(string text, int maxWait)
            : base()
        {
            Text = text;
            MaxWait = maxWait;
            
        }
        
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.WaitForTextLoad(vList.Evaluate(Text), MaxWait);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Waited for text '" + Text + "' to load.");
            }
        }
    }
}
