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
namespace Vibz.Contract
{
    public enum InstructionType { Action, Fetch, Assert, Loop, Condition, Block }
    public interface IInstruction
    {
        InstructionValueMap ValueMap { get; }
        string OnError { get; set; }
        InstructionType Type { get; set; }
        Vibz.Contract.Log.LogElement InfoEnd { get; }
        XmlElement Serialize();
        //object RetrieveAbsoluteValue(string name, VariableList vList);
    }
}
