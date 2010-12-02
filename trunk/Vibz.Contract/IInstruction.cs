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
