using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract.Macro;
namespace Vibz.Contract.Data
{
    public class ParameterSet : List<Parameter>
    {
        static MacroParser _mParser = null;
        public ParameterSet()
        { }
        public ParameterSet(MacroParser mParser)
        {
            _mParser = mParser;
        }
        public static void SetParser(MacroParser mParser)
        {
            _mParser = mParser;
        }
        public new void Add(Parameter param)
        {
            base.Add(param);
        }
        public Parameter GetParameter(string paramKey)
        {
            foreach (Parameter param in this)
            {
                if (param.Name == paramKey)
                {
                    if (_mParser != null)
                        param.Value = _mParser.Parse(param.Value);
                    return param;
                }
            }
            return null;
        }
    }
}
