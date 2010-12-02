using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Vibz.Solution.Element
{
    public class ApplicationGlobalFile : CaseFile
    {
        public const string Extension = "ag";
        internal ApplicationGlobalFile(FileInfo fInfo, Project ownerProject)
            : base(fInfo, ownerProject)
        { }

        public override ElementType Type { get { return ElementType.ApplicationGlobal; } }
    }
}
