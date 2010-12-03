using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.IO
{
    public abstract class IOBase
    {
        private string _path;
        public string FilePath
        {
            get { return _path; }
            set { _path = value; }
        }
        public abstract void Init(Dictionary<string, object> param);
        public abstract void Write(object text);
        public abstract void Append(object text);
    }
}
