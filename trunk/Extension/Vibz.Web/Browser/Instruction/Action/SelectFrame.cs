using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Selects the frame associated to given frame-locator.",
        Version = WebInstructionBase.Vesrion)]
    public class SelectFrame : ActionBase
    {
        [XmlAttribute("framelocator")]
        public string FrameLocator;
        public SelectFrame()
            : base()
        {
                    
        }
        public SelectFrame(string frameLocator)
            : base()
        {
            FrameLocator = frameLocator;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.SelectFrame(FrameLocator);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Selected frame '" + FrameLocator + "'.");
            }
        }
    }
}
