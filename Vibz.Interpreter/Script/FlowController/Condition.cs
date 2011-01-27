/*
*	Copyright © 2011, The Vibzworld Team
*	All rights reserved.
*	http://code.google.com/p/vauto/
*	
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions
*	are met:
*	
*	- Redistributions of source code must retain the above copyright
*	notice, this list of conditions and the following disclaimer.
*	
*	- Neither the name of the Vibzworld Team, nor the names of its
*	contributors may be used to endorse or promote products
*	derived from this software without specific prior written
*	permission.
*/
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
    Details = "Condition instruction acts as container to hold one or more assert instructions. " +
        "The output is a boolean, calculated over varios assert statements operated with 'AND' or 'OR' operator",
     Version = ScriptInfo.Version,
      HasIndeviduality = true)]
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
        [AttributeInfo("Operator defines the logical grouping of its indevidual assert statements. \r\nDefault: And", typeof(ConditionOperator), false)]
        public ConditionOperator Operator 
        {
            get { return _operator; }
            set { _operator = value; }
        }

        bool _expected = true;
        [XmlAttribute("expected")]
        [AttributeInfo("Expected boolean output resulting out of operated assertions. \r\nDefault: true", false)]
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
                            _checks.Add((IAssert)Serializer.ConvertXmlElementToInstruction(Configuration.InstructionManager.Handlers, ele));
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
