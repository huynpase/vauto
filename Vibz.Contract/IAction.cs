using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract.Data;
namespace Vibz.Contract
{
    public interface IAction : IInstruction
    {
        void Execute(DataHandler vList);
    }
}
