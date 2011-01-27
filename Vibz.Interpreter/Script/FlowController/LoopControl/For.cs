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
        Details = "For is a loop instruction which allows instruction or group of instructions to be executed for a specific number of times depending on the value of a loop counter.",
       Version = ScriptInfo.Version,
        HasIndeviduality = true)]
    public class For : InstructionBase, IAction
    {
        Vibz.Contract.Log.LogElement _progress;
        public For()
        {
            Type = InstructionType.Action;
        }

        [XmlAttribute("count")]
        [AttributeInfo("Number of iterations to perform. Count must be a valid integer.")]
        public string Count;

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
