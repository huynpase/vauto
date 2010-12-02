using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Interpreter.Configuration
{
    public class Register
    {
        public const string NodeName = "configuration";
        public const string VersionSupport = "versionsupport";
        public class Include
        {
            public const string NodeName = "include";
            public const string Name = "name";
            public const string Reference = "ref";
            public const string Path = "path";
            public const string Status = "status";
            public const string Config = "config";
            public class Param
            {
                public const string NodeName = "param";
                public const string Name = "name";
                public const string Value = "value";
            }
        }
    }
}
