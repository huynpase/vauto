using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;

namespace Vibz.IO.TextFile.Instruction.Action
{
    public abstract class ActionBase : IOInstructionBase, IAction
    {
        public virtual void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            base.Execute(vList);
        }
    }
}
