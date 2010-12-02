using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 
using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Details = "Drags the element on source locator and drops it on destination locator.",
        Version = "2.0")]
    public class DragAndDrop : ActionBase
    {
        [XmlAttribute("sourcelocator")]
        public string SourceLocator;
        [XmlAttribute("destinationlocator")]
        public string DestinationLocator;
        public DragAndDrop()
            : base()
        {
                    
        }
        public DragAndDrop(string sourceLocator, string destinationLocator)
            : base()
        {
            SourceLocator = sourceLocator;
            DestinationLocator = destinationLocator;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.DragAndDrop(SourceLocator, DestinationLocator);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Dragged control '" + SourceLocator + "' over '" + DestinationLocator + "'.");
            }
        }
    }
}
