using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Vibz.Solution.Element
{
    internal static class Reference
    {
        public static FileInfo ResolveFunction(Function function, string reference)
        {
            if (!File.Exists(function.Path))
                throw new Exception("Invalid Function File path. [" + function.Path + "]");
            string retValue = "";
            //string funcName = reference.Substring(reference.LastIndexOf("/") + 1);
            FileInfo fi = new FileInfo(function.Path);
            if (!reference.Contains("/")) return fi;
            string funcRefFilePath = reference.Substring(0, reference.LastIndexOf("/")) + "." + CaseFile.Extension;
            retValue = Path.Combine(fi.Directory.FullName, funcRefFilePath);
            if (File.Exists(retValue)) return new FileInfo(retValue);
            retValue = function.OwnerProject.MapPath(funcRefFilePath);
            if (File.Exists(retValue)) return new FileInfo(retValue);
            throw new Exception("Invalid function reference path. [" + reference + "]");
        }
        public static FileInfo Resolve(IElement element, string reference)
        {
            if (!File.Exists(element.Path))
                throw new Exception("Invalid File path. [" + element.Path + "]");
            string retValue = "";
            switch (reference.ToLower())
            { 
                case ".":
                    retValue = element.Path;
                    break;
                default:
                    FileInfo fi = new FileInfo(element.Path);
                    retValue = Path.Combine(fi.Directory.FullName, reference);
                    if (File.Exists(retValue))  break;
                    retValue = element.OwnerProject.MapPath(reference);
                    if (File.Exists(retValue)) break;
                    throw new Exception("Invalid reference path. [" + reference + "]");
            }
            return new FileInfo(retValue);
        }
    }
}
