using System;
using System.Collections.Generic;
using System.Text;
namespace Vibz.Contract.Data
{
    public interface IDataProcessor
    {
        void Export(Variable source, Variable destination, DataExportMode mode);
        string Evaluate(Variable var, params object[] args);
        string Evaluate(Variable var, string property);
        string Evaluate(Variable var, string method, params object[] args);
    }
}
