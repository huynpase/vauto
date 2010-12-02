using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Data.Source
{
    public interface ISource
    {
        void Init(ParameterSet paramSet);
    }
}
