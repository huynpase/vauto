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
    Details = "Case instruction goes within if statement. It perform conditional execution of specific set of instruction. " +
        "A case instruction has one condition block and a body section.",
     Version = ScriptInfo.Version,
      HasIndeviduality = true)]
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
                if (XBody == null)
                    throw new Exception("Expected 'Body' section is missing.");
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
