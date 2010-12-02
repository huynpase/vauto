using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract.Data;
namespace Vibz.Contract
{
    public interface IAssert : IInstruction
    {
        bool Assert(DataHandler vList);
    }
}
