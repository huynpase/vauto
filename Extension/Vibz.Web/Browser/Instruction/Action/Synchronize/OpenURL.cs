using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Action.Synchronize
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Opens the given url in current browser.",
        Version = WebInstructionBase.Vesrion)]
    public class OpenURL : SynchronizeBase
    {
        string _actUrl = "";
        [XmlAttribute("url")]
        public string Url;
        public OpenURL()
            : base()
        {
                    
        }
        public OpenURL(string url, int maxWait)
            : base()
        {
            MaxWait = maxWait;
            Url = url;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            _actUrl = vList.Evaluate(Url);
            Browser.LoadUrl(_actUrl, MaxWait);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Url '" + _actUrl + "' opened.");
            }
        }
    }
}
