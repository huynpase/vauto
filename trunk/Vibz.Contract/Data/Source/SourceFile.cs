using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Data.Source
{
    public abstract class SourceFile
    {
        ParameterSet _parameters;
        public ParameterSet Parameters
        {
            get {
                if (_parameters == null)
                    _parameters = new ParameterSet();
                return _parameters; }
            set { _parameters = value; }
        }
        public void Init(ParameterSet paramSet)
        {
            _parameters = paramSet;
            Initialize(paramSet);
        }
        public abstract void Initialize(ParameterSet paramSet);
    }
}
