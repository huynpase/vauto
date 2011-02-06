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
using Vibz.Contract;
using Vibz.Contract.Attribute;
using System.Xml.Serialization;

namespace Vibz.Interpreter.Script.FlowController.VariableControl
{
    [TypeInfo(Author = "Vibzworld",
      Details = "Asserts given boolean expression. ",
      Version = "2.0",
       HasIndeviduality = true)]
    public class AssertBool : InstructionBase, IAssert
    {
        [XmlAttribute("expression")]
        public string Expression = "";
        public AssertBool()
        {
            Type = InstructionType.Assert;
        }
        public bool Assert(Vibz.Contract.Data.DataHandler vList)
        {
            bool retValue = false;
            string evalText = vList.Evaluate(Expression);
            if (!bool.TryParse(evalText, out retValue))
            {
                if (Vibz.Helper.Math.IsNumber(evalText))
                    return (evalText == "0" ? false : true);
                else
                    throw new Exception("Expression evaluated to non boolean text.");
            }
            return retValue;
        }
    }
}
