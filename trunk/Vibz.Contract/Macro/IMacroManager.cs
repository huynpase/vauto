using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Macro
{
    public interface IMacroManager
    {
        FunctionType GetFunction(string macro);
        FunctionType GetFunction(string macro, Type type);
    }
}
