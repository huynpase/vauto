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

namespace Vibz.Solution.Element
{
    public class Space : ElementBase
    {
        public const string SkipDirs = "skipdirectories";
        protected internal string _skipDirs = ".svn";
        public string[] SkipDirectories
        {
            get { return _skipDirs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries); }
        }

        internal Space(DirectoryInfo dInfo)
        {
            _name = dInfo.Name;
            _path = dInfo.FullName;
        }
        internal Space(DirectoryInfo dInfo, Project ownerProject)
            : base(ownerProject)
        {
            _name = dInfo.Name;
            _path = dInfo.FullName;
        }
        

        public override ElementType Type { get { return ElementType.Space; } }

        List<IElement> _subElements;
        public List<IElement> SubElements
        {
            get
            {
                if (_subElements == null)
                    _subElements = new List<IElement>();
                return _subElements;
            }
            set { _subElements = value; }
        }

        public override string FullName
        {
            get
            {
                if ((_name == null || _name == "") || (_path == null || _path == ""))
                    return "<No Name>";
                string fullname = _path;
                fullname = fullname.Replace("\\", "/");
                return fullname + "/";
            }
            set { throw new Exception("Full name can not be set for this file."); }        
        }

        public override void Load()
        {
            SubElements.Clear();
            DirectoryInfo diMain = new DirectoryInfo(_path);
            DirectoryInfo[] diSub = diMain.GetDirectories();
            foreach (DirectoryInfo di in diSub)
            {
                bool loadDirectory=true;
                foreach (string dir in SkipDirectories)
                {
                    if (di.Name.ToLower() == dir.ToLower())
                    {
                        loadDirectory = false;
                        break;
                    }
                }
                if (!loadDirectory)
                    continue;
                Space spc = this.OwnerProject.CreateSpace(di);
                spc._path = di.FullName;
                spc.Load();
                SubElements.Add(spc);
            }

            SubElements.AddRange(LoadFileType(diMain, typeof(CaseFile)));
            SubElements.AddRange(LoadFileType(diMain, typeof(SuiteFile)));
            SubElements.AddRange(LoadFileType(diMain, typeof(IdentifierFile)));
            SubElements.AddRange(LoadFileType(diMain, typeof(ApplicationGlobalFile)));
        }
        List<IElement> LoadFileType(DirectoryInfo diMain, Type type)
        {
            List<IElement> retValue = new List<IElement>();

            FileInfo[] fiSub = diMain.GetFiles("*." + GetExtension(type), SearchOption.TopDirectoryOnly);
            foreach (FileInfo fi in fiSub)
            {
                try
                {
                    retValue.Add(CreateElementObject(type, fi));
                }
                catch (Exception exc)
                { 
                    // File Load error
                    // Bring this error out on UI with error signal on file name
                }
            }
            return retValue;
        }
        ElementBase CreateElementObject(Type type, FileInfo fi)
        {
            ElementBase retValue = null;
            switch (type.Name.ToLower())
            {
                case "casefile":
                    retValue = this.OwnerProject.CreateCase(fi);
                    try
                    {
                        retValue.Load();
                    }
                    catch (Exception exc)
                    {
                        retValue._hasError = true;
                        retValue._error = exc.Message;
                    }
                    break;
                case "suitefile":
                    retValue = this.OwnerProject.CreateSuite(fi);
                    break;
                case "identifierfile":
                    retValue = this.OwnerProject.CreateIdentifier(fi);
                    break;
                case "applicationglobalfile":
                    retValue = this.OwnerProject.CreateApplicationGlobal(fi);
                    break;
            }
            return retValue;
        }
        string GetExtension(Type type)
        {
            switch (type.Name.ToLower())
            {
                case "casefile":
                    return CaseFile.Extension;
                case "suitefile":
                    return SuiteFile.Extension;
                case "identifierfile":
                    return IdentifierFile.Extension;
                case "applicationglobalfile":
                    return ApplicationGlobalFile.Extension;
                default:
                    return "";
            }
        }
    }
}
