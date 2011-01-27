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
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract;
using Vibz.Contract.Data;
using Vibz.Contract.Attribute;
namespace Vibz.Interpreter.Script.FlowController.VariableControl
{
    [TypeInfo(Author = ScriptInfo.Author,
     Details = "Stores the data into given variable.",
      Version = ScriptInfo.Version,
       HasIndeviduality = true)]
    public class Set : InstructionBase, IAction
    {
        [XmlAttribute("var")]
        public string Variable;
        [XmlAttribute("value")]
        public string Value;
        public Set()
        {
            Type = InstructionType.Action;
        }
        public Set(string value, string var)
            : base()
        {
            Value = value;
            Variable = var;
            Type = InstructionType.Action;
        }
        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Vibz.Contract.Data.IData obj = new Vibz.Contract.Data.Text(vList.Evaluate(Value));
            vList.DataList.Update(new Variable(Variable, obj));
            Vibz.Contract.Log.LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement("Value " + obj.ToString() + " assigned to " + Variable, Vibz.Contract.Log.LogSeverity.Trace));
        }
    }
}
