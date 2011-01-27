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
    Details = "If statement hold a set of conditional logic defined with one or more case statement. " + 
        "The first case whose condition passes will have its instructions executed. " +
        "An if can also have an else section to be executed when all other cases have failed " + 
        "with their conditional logic.",
     Version = ScriptInfo.Version,
      HasIndeviduality = true)]
    public class If : InstructionBase, IAction
    {
        Vibz.Contract.Log.LogElement _progress;
        public If()
        {
            Type = InstructionType.Action;
        }
        List<Case> _caseList;
        [XmlIgnore()]
        public List<Case> CaseList
        {
            get
            {
                if (_caseList == null)
                {
                    _caseList = new List<Case>();
                    if (XCases != null)
                    {
                        foreach (XmlElement ele in XCases)
                        {
                            _caseList.Add((Case)Serializer.ConvertXmlElementToInstruction(Configuration.InstructionManager.Handlers, ele));
                        }
                    }
                    else
                        throw new Exception("There must be one case within an if statement.");
                }
                return _caseList;
            }
            set
            {
                _caseList = value;
            }
        }
        [XmlAnyElement("case")]
        public XmlElement[] XCases;

        Else _else;
        [XmlIgnore()]
        public Else Else
        {
            get
            {
                if (_else == null)
                {
                    _else = (Else)Serializer.ConvertXmlElementToInstruction(Configuration.InstructionManager.Handlers, XElse);
                }
                return _else;
            }
            set
            {
                _else = value;
            }
        }   
        [XmlAnyElement("else")]
        public XmlElement XElse;

        Case _executedCase = null;
        public void Execute(DataHandler vList)
        {
            _progress = new Vibz.Contract.Log.LogElement("If start.");
            IEnumerator<Case> caseInst = CaseList.GetEnumerator();
            while (caseInst.MoveNext())
            {
                if (caseInst.Current.Assert(vList))
                {
                    _executedCase = caseInst.Current;
                    break;
                }
            }
            if (_executedCase == null && Else != null)
                Else.Execute(vList);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd 
        { 
            get 
            {
                _progress.Add(_executedCase != null ? (Vibz.Contract.Log.LogElement)_executedCase.InfoEnd : (Else != null ? (Vibz.Contract.Log.LogElement)Else.InfoEnd : null));
                return _progress;
            } 
        } 
    }
}
