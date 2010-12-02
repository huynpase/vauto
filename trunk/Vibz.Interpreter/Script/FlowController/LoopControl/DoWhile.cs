using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using Vibz.Contract;
using Vibz.Contract.Data;

namespace Vibz.Interpreter.Script.FlowController.LoopControl
{
    public class DoWhile : InstructionBase, IAction
    {
        Vibz.Contract.Log.LogElement _progress;

        public DoWhile()
        {
            Type = InstructionType.Action;
        }

        ICondition _condition;
        [XmlIgnore()]
        public ICondition Condition
        {
            get
            {
                if (_condition == null)
                {
                    _condition = (ICondition)Serializer.ConvertXmlElementToInstruction(XCondition);
                }
                return _condition;
            }
            set
            {
                _condition = value;
            }
        }
        [XmlAnyElement("condition")]
        public XmlElement XCondition;

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
            _progress = new Vibz.Contract.Log.LogElement("DoWhile start.");
            Body.Execute(vList);
            _progress.Add(Body.InfoEnd);
            while (Condition.Assert(vList))
            {
                _progress.Add(_condition.InfoEnd);
                _progress.Add("Condition Pass.");
                Body.Execute(vList);
                _progress.Add(Body.InfoEnd);
            }
            _progress.Add(_condition.InfoEnd);
            _progress.Add("Condition Fail.");
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
