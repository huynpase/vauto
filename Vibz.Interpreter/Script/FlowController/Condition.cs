using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using Vibz.Contract;
using Vibz.Contract.Data;

namespace Vibz.Interpreter.Script.FlowController
{
    public class Condition : InstructionBase, ICondition
    {
        Vibz.Contract.Log.LogElement _progress;
        public Condition()
        {
            Type = InstructionType.Condition;
        }
        public Condition(bool expected, ConditionOperator optor)
        {
            _expected = expected;
            _operator = optor;
            Type = InstructionType.Condition;
        }

        ConditionOperator _operator = ConditionOperator.And;
        [XmlAttribute("operator")]
        public ConditionOperator Operator 
        {
            get { return _operator; }
            set { _operator = value; }
        }

        bool _expected = true;
        [XmlAttribute("expected")]
        public bool Expected 
        {
            get { return _expected; }
            set { _expected = value; }
        }

        List<IAssert> _checks;
        [XmlIgnore()]
        public List<IAssert> Checks
        {
            get
            {
                if (_checks == null)
                {
                    _checks = new List<IAssert>();
                    if (XChecks != null)
                    {
                        foreach (XmlElement ele in XChecks)
                        {
                            _checks.Add((IAssert)Serializer.ConvertXmlElementToInstruction(ele));
                        }
                    }
                }
                return _checks;
            }
            set
            {
                _checks = value;
            }
        }
        [XmlAnyElement()]
        public XmlElement[] XChecks;

        private IAssert _conditionOut = null;
        bool _result = false;
        public bool Assert(DataHandler vList)
        {
            _progress = new Vibz.Contract.Log.LogElement("Condition start.");
            bool flag = false;
            switch (Operator)
            { 
                case ConditionOperator.Or:
                    foreach (IAssert asrt in Checks)
                    {
                        _conditionOut = asrt;
                        if (asrt.Assert(vList))
                        {
                            flag = true;
                            break;
                        }
                    }
                    _result = (flag == _expected);
                    break;
                case ConditionOperator.And:
                default:
                    foreach (IAssert asrt in Checks)
                    {
                        _conditionOut = asrt;
                        if (!asrt.Assert(vList))
                        {
                            flag = true;
                            break;
                        }
                    }
                    _result = (!flag == _expected);
                    break;
            }
            return _result;
        }
        public override Vibz.Contract.Log.LogElement InfoEnd 
        { 
            get 
            { 
                _progress.Add(InnerInfo);
                return _progress;
            } 
        }
        private Vibz.Contract.Log.LogElement InnerInfo
        {
            get
            {
                if (_conditionOut == null)
                    return null;
                if (((_expected != _result) && _operator == ConditionOperator.And) 
                    || ((_expected == _result) && _operator == ConditionOperator.Or))
                    return _conditionOut.InfoEnd;
                else if(Checks.Count==1)
                    return _conditionOut.InfoEnd;
                else return null;
            }
        }
    }
}
