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

namespace Vibz.Plugin.Plug.IO
{
    internal class AddOrReplacePlug : IOPlugBase
    {
        string _source = "";
        public AddOrReplacePlug(string source, string path, PlugType type)
            : base(path, type)
        {
            
            _source = source;
            CheckSourcePath();
        }
        
        public AddOrReplacePlug(string source, string path, string type)
            : base(path, type)
        {
            _source = source;
            CheckSourcePath();
        }
        bool CheckSourcePath()
        {
            switch (_type)
            {
                case PlugType.File:
                    if (!File.Exists(_source))
                        throw new Exception("Source file '" + _source + "' not found.");
                    break;
                case PlugType.Folder:
                    if (!Directory.Exists(_source))
                        throw new Exception("Source folder '" + _source + "' not found.");
                    break;
            }
            return true;
        }

        public override bool Execute()
        {
            if (!ExecutionNeeded || !CanExecute)
                return false;
            Vibz.Helper.IO.CreateFolderPath(_filePath, (_type == PlugType.File ? Vibz.Helper.IOType.File : Vibz.Helper.IOType.Folder));
            switch (_type)
            {
                case PlugType.File:
                    File.Copy(_source, _filePath, true);
                    break;
                case PlugType.Folder:
                    CopyDirectory(_source, _filePath, true);
                    break;
            }
            return true;
        }
        static bool CopyDirectory(string SourcePath, string DestinationPath, bool overwriteexisting)
        {
            bool ret = false;
            try
            {
                SourcePath = SourcePath.EndsWith(@"\") ? SourcePath : SourcePath + @"\";
                DestinationPath = DestinationPath.EndsWith(@"\") ? DestinationPath : DestinationPath + @"\";

                if (Directory.Exists(SourcePath))
                {
                    if (Directory.Exists(DestinationPath) == false)
                        Directory.CreateDirectory(DestinationPath);

                    foreach (string fls in Directory.GetFiles(SourcePath))
                    {
                        FileInfo flinfo = new FileInfo(fls);
                        flinfo.CopyTo(DestinationPath + flinfo.Name, overwriteexisting);
                    }
                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo drinfo = new DirectoryInfo(drs);
                        if (CopyDirectory(drs, DestinationPath + drinfo.Name, overwriteexisting) == false)
                            ret = false;
                    }
                }
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }
    }
}
