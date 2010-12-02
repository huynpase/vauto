using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Common
{
    public enum StepToFollow { Continue, Break }
    public interface ISynchronize
    {
        int MaxWait { get; set; }
        string OnTimeOut { get; set; }
    }
}
