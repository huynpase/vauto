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
       Details = "Initialize a variable of given type.",
      Version = ScriptInfo.Version,
       HasIndeviduality = true)]
    public class Define : InstructionBase, IAction
    {
        [XmlAttribute("var")]
        [AttributeInfo("Identity for the variable", true)]
        public string Variable;
        [XmlAttribute("type")]
        [AttributeInfo("Datatype of the variable", typeof(Vibz.Contract.Data.DataType), true)]
        public string DataType;
        public Define()
        {
            Type = InstructionType.Action;
        }
        public Define(string var, string type)
            : base()
        {
            DataType = type;
            Variable = var;
            Type = InstructionType.Action;
        }
        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Vibz.Contract.Data.IData obj = Vibz.Contract.Data.DataHandler.DefineData(DataType);
            vList.DataList.Update(new Var(Variable, obj));
        }
    }
}
