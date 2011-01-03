using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Author="Vibzworld", Details = "Selects the window associated to given windowid.",
        Version = "2.0")]
    public class SelectWindow : ActionBase
    {
        [XmlAttribute("windowid")]
        public string WindowId;
        public SelectWindow()
            : base()
        {
                    
        }
        public SelectWindow(string windowId)
            : base()
        {
            WindowId = windowId;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.SelectWindow(WindowId);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Selected window '" + WindowId + "'.");
            }
        }
    }
}
