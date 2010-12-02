using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Vibz.Interpreter.Script.FlowController
{
    public class Include
    {
        [XmlAttribute("ref")]
        public string Path;
    }
}
