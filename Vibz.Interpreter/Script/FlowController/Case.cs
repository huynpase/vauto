using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using Vibz.Contract;
using Vibz.Contract.Data;
namespace Vibz.Interpreter.Script.FlowController
{
    public class Case : InstructionBase, IAssert
    {
        Vibz.Contract.Log.LogElement _progress;

        public Case()
        {
            Type = InstructionType.Assert;
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

        bool _result = false;
        public bool Assert(DataHandler vList)
        {
            _progress = new Vibz.Contract.Log.LogElement("Case start.");
            if (Condition.Assert(vList))
            {
                _progress.Add(_condition.InfoEnd);
                _progress.Add("Condition Pass.");
                Body.Execute(vList);
                _result = true;
            }
            else
            {
                _progress.Add(_condition.InfoEnd);
                _progress.Add("Condition Fail.");
            }
            return _result;
        }
        public override Vibz.Contract.Log.LogElement InfoEnd 
        { 
            get 
            {
                if (_result)
                    _progress.Add(Body.InfoEnd);
                return _progress;
            }
        }
    }
}
