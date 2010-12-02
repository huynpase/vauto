using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using Vibz.Contract;
using Vibz.Contract.Data;
namespace Vibz.Interpreter.Script.FlowController
{
    public class Else : InstructionBase, IAction
    {
        Vibz.Contract.Log.LogElement _progress;
        public Else()
        {
            Type = InstructionType.Action;
        }
        Body _body;
        [XmlIgnore()]
        public Body Body
        {
            get
            {
                if (_body == null)
                {
                    _body = (Body)Serializer.ConvertXmlElementToInstruction(XBody);
                }
                return _body;
            }
            set
            {
                _body = value;
            }
        }
        [XmlAnyElement("body")]
        public XmlElement XBody;

        public void Execute(DataHandler vList)
        {
            _progress = new Vibz.Contract.Log.LogElement("Else start.");
            Body.Execute(vList);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd 
        { 
            get 
            {
                _progress.Add(Body.InfoEnd);
                return _progress;
            }
        }
    }
}
