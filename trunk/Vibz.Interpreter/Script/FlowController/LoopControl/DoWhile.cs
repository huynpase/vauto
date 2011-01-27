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

namespace Vibz.Interpreter.Script.FlowController.LoopControl
{
    [TypeInfo(Author = ScriptInfo.Author,
        Details = "DoWhile is a loop instruction which allows code to be executed repeatedly based on a given Boolean condition. It differs from while loop in the sence it executes instruction first and then checks the condition.",
        Version = ScriptInfo.Version, 
        HasIndeviduality=true)]
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
                    _condition = (ICondition)Serializer.ConvertXmlElementToInstruction(Configuration.InstructionManager.Handlers, XCondition);
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
