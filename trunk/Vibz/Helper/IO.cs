/*
*	Copyright © 2011, The Vibzworld Team
*	All rights reserved.
*	http://code.google.com/p/vauto/
*	
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions
*	are met:
*	
*	- Redistributions of source code must retain the above copyright
*	notice, this list of conditions and the following disclaimer.
*	
*	- Neither the name of the Vibzworld Team, nor the names of its
*	contributors may be used to endorse or promote products
*	derived from this software without specific prior written
*	permission.
*/
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
            {
                if (relativeDirectories.Length == 1)
                    return Path.Combine(absolutePath, relativeTo);
                else
                    throw new ArgumentException("Paths do not have a common base");
            }
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
        public static FileInfo GetLastUpdatedFileInDirectory(DirectoryInfo directoryInfo, string pattern)
        {
            FileInfo[] files = (pattern == null || pattern == "" ? directoryInfo.GetFiles() : directoryInfo.GetFiles("*" + pattern + "*"));

            FileInfo lastUpdatedFile = null;
            DateTime lastUpdate = new DateTime(2000, 1, 1);

            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > lastUpdate)
                {
                    lastUpdatedFile = file;
                    lastUpdate = file.LastAccessTime;
                }
            }

            return lastUpdatedFile;
        }
    }
}
