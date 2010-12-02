using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Vibz.Helper
{
    public enum IOType { File, Folder }
    public class IO
    {
        public static string CreateFolderPath(string path, IOType pType)
        {
            if (path.Trim() == "")
                return "";
            if (path.Contains("{DATETIMESTAMP}"))
                path = path.Replace("{DATETIMESTAMP}", FilterFolderChar(DateTime.Now.ToString()));

            string folderPath = "";
            switch (pType)
            {
                case IOType.File:
                    folderPath = path.Substring(0, path.LastIndexOfAny(new char[] { '\\', '/' }));
                    break;
                case IOType.Folder:
                    folderPath = path;
                    break;
                default:
                    throw new Exception("This plug type is not supported.");
            }
            Directory.CreateDirectory(folderPath);
            return path;
        }
        public static string FilterFolderChar(string text)
        {
            return text.Replace("/", "").Replace(":", "").Replace("\\", "").Replace(" ", "");
        }
        public static string CreateRelativePath(string absolutePath, string relativeTo)        
        {            
            string[] absoluteDirectories = absolutePath.Split('\\');            
            string[] relativeDirectories = relativeTo.Split('\\');            
            //Get the shortest of the two paths            
            int length = absoluteDirectories.Length < relativeDirectories.Length ? absoluteDirectories.Length : relativeDirectories.Length;            
            //Use to determine where in the loop we exited            
            int lastCommonRoot = -1;            
            int index;            
            //Find common root            
            for (index = 0; index < length; index++)                
                if (absoluteDirectories[index] == relativeDirectories[index])                    
                    lastCommonRoot = index;  
                else
                    break; 
            //If we didn't find a common prefix then throw   
            if (lastCommonRoot == -1) 
                throw new ArgumentException("Paths do not have a common base");
            //Build up the relative path 
            StringBuilder relativePath = new StringBuilder();
            //Add on the ..       
            for (index = lastCommonRoot + 1; 
                index < absoluteDirectories.Length; index++)
                if (absoluteDirectories[index].Length > 0)
                    relativePath.Append("..\\");
            //Add on the folders  
            for (index = lastCommonRoot + 1; index < relativeDirectories.Length - 1; index++)   
                relativePath.Append(relativeDirectories[index] + "\\");  
            relativePath.Append(relativeDirectories[relativeDirectories.Length - 1]);
            return relativePath.ToString();   
        }
        public static void CreateFolderPath(DirectoryInfo directory)
        {
            if (!directory.Parent.Exists)
                CreateFolderPath(directory.Parent);
            directory.Create();
        }
    }
}
