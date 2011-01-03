using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Action
{
    public abstract class ActionBase : WebInstructionBase, IAction
    {
        public ActionBase()
        {
            Type = InstructionType.Action;
        }
        public virtual void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            throw new Exception("Execute is not a valid function for this command.");
        }
    }
}
