using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using Vibz.Contract;
using Vibz.Contract.Data;
namespace Vibz.Interpreter.Script.FlowController.LoopControl
{
    public class For : InstructionBase, IAction
    {
        Vibz.Contract.Log.LogElement _progress;
        public For()
        {
            Type = InstructionType.Action;
        }

        [XmlAttribute("count")]
        public string Count;

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
            _progress = new Vibz.Contract.Log.LogElement("For start.");
            int cnt = Vibz.Helper.Math.TryGetInteger(vList.Evaluate(Count), 0);
            for (int i = 0; i < cnt; i++)
            {
                vList.DataList.Update(new Variable("index", new Vibz.Contract.Data.Text(i.ToString())));
                Body.Execute(vList);
                _progress.Add(Body.InfoEnd);
            }
        }
        public override Vibz.Contract.Log.LogElement InfoEnd 
        { 
            get 
            {
                return _progress;
            }
        }
    }
}
