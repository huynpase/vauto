using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract
{
    public interface IMacroFunction
    {
        string Evaluate(object param);
    }
}
