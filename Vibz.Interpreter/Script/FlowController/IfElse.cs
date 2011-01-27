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
namespace Vibz.Interpreter.Script.FlowController
{
    public class IfElse : InstructionBase, IAction
    {
        ICondition _condition;
        [XmlIgnore()]
        public ICondition Condition
        {
            get
            {
                if (_condition == null)
                {
                    _condition = (ICondition)Operation.ConvertXmlElementToInstruction(XCondition);
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

        Block _instructionList;
        [XmlIgnore()]
        public Block InstructionList
        {
            get
            {
                if (_instructionList == null)
                {
                    _instructionList = (Block)Operation.ConvertXmlElementToInstruction(XBlock);
                }
                return _instructionList;
            }
            set
            {
                _instructionList = value;
            }
        }
        [XmlAnyElement("block")]
        public XmlElement XBlock;

        public bool Assert(VariableList vList)
        {
            if (!Condition.Assert(vList))
                return false;
            InstructionList.Execute(vList);
            return true;
        }
        public string InfoOnAssertPass { get { return "Case executed successfully."; } }
        public string InfoOnAssertFail { get { return "Case will not be executed as the condition has failed."; } }
    }
}
