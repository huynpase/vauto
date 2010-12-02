using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Data
{
    public interface IData
    {
        string Source { get; }
        string Type { get; }
        string Evaluate(params object[] args);
        string Evaluate(string property);
        string Evaluate(string method, params object[] args);
    }
}
