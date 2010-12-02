using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract
{
    public enum ConditionOperator { And , Or }
    public interface ICondition : IAssert
    {
        ConditionOperator Operator { get; set; }
        bool Expected { get; set; }
        List<IAssert> Checks { get; set; }
    }
}
