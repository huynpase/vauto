using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Data.Source.Text;
using Vibz.Data.Type.Scalar;
namespace Vibz.Data.External.Text
{
    public class ScalarText: TextFile, IScalar
    {
        public ScalarText(string filePath)
            : base(filePath)
        { }
        public object Value
        {
            get { return base.Content; }
        }
    }
}
