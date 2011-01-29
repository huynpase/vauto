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
      Details = "Evaluate the given expression. ",
      Version = ScriptInfo.Version,
       HasIndeviduality = true)]
    public class Evaluate : InstructionBase, IFetch
    {
        [XmlAttribute("expression")]
        public string Expression = "";
        private string _output = "assignto";
        [XmlAttribute("assignto")]
        public string Output
        {
            get { return _output; }
            set { _output = value; }
        }
        public Evaluate()
        {
            Type = InstructionType.Fetch;
        }
        public Evaluate(string expression, string assignto)
            : base()
        {
            Expression = expression;
            Output = assignto;
            Type = InstructionType.Fetch;
        }
        public IData Fetch(Vibz.Contract.Data.DataHandler vList)
        {
            return new Vibz.Contract.Data.Text(vList.Evaluate(Expression));
        }
    }
}
