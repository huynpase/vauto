using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using Vibz.Contract;
using Vibz.Contract.Data;
using Vibz.Contract.Attribute;
namespace Vibz.Interpreter.Script.FlowController
{
    [TypeInfo(Author = ScriptInfo.Author,
    Details = "Else is a container instruction, that holds the body instruction to be executed when all other cases have failed with their conditional logic.",
     Version = ScriptInfo.Version,
      HasIndeviduality = true)]
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
                    _body = (Body)Serializer.ConvertXmlElementToInstruction(Configuration.InstructionManager.Handlers, XBody);
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
