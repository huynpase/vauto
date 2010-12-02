using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract.Data.Source;

namespace Vibz.Contract.Data
{
    public abstract class ExternalData<T> : IData
    {
        public abstract T Value { get; }
        public abstract string Source { get; }
        public abstract void Load(ParameterSet param);
        public abstract void Export(ParameterSet param, T data, DataExportMode mode);
        public string Type 
        {
            get { return ((IData)Value).Type; }
        }
        public string Evaluate(params object[] args)
        {
            return ((IData)Value).Evaluate(args);
        }
        public string Evaluate(string property)
        {
            return ((IData)Value).Evaluate(property);        
        }
        public virtual string Evaluate(string method, params object[] args)
        {
            return ((IData)Value).Evaluate(method, args);
        }
    }
}
