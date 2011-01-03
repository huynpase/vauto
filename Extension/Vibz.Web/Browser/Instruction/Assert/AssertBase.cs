using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Assert
{
    public abstract class AssertBase : WebInstructionBase, IAssert
    {
        internal bool Result = false;
        public AssertBase()
        {
            Type = InstructionType.Assert;
        }
        public virtual bool Assert(Vibz.Contract.Data.DataHandler vList)
        {
            throw new Exception("Assert is not a valid function for this command.");
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Assert " + (Result ? "pass" : "fail") + ".");
            }
        }
    }
}
