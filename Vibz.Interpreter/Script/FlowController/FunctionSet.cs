using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Vibz.Interpreter.Script.FlowController
{
    public class FunctionSet
    {
        ArrayList _function = new ArrayList();
        [XmlElement("function")]
        public Function[] Functions
        {
            get
            {
                Function[] retValue = new Function[_function.Count];
                _function.CopyTo(retValue);
                return retValue;
            }
            set 
            {
                foreach (Function c in value)
                {
                    c.DataSet.DataProcessor = Vibz.Interpreter.Data.DataProcessor.Instance;
                    _function.Add(c);
                }
            }
        }
        public void AddFunction(Function function)
        {
            _function.Add(function);
        }
        public Function GetFunction(string name)
        {
            if (Functions == null)
                return null;
            foreach (Function function in Functions)
            {
                if (function.Name.ToLower() == name.ToLower())
                    return function;
            }
            return null;
        }
    }
}
