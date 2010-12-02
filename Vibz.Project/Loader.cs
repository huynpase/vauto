using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Solution.Element;
using System.IO;
using System.Xml;
namespace Vibz.Solution
{
    public class Loader
    {
        public static Project Load(string projectPath)
        {
            if (!File.Exists(projectPath))
                throw new Exception("Invalid Project path.");
            FileInfo diMain = new FileInfo(projectPath);
            Project prj = new Project(diMain);
            prj.Load();
            return prj;
        }
    }
}
