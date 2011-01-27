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
    public class Space : IElement
    {
        public const string SkipDirs = "skipdirectories";
        protected internal Project _ownerProject;
        protected internal string _skipDirs = ".svn";
        public string[] SkipDirectories
        {
            get { return _skipDirs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries); }
        }

        public Project OwnerProject
        {
            get
            {
                return _ownerProject;
            }
        }
        internal Space(DirectoryInfo dInfo)
        {
            _name = dInfo.Name;
            _path = dInfo.FullName;
        }
        internal Space(DirectoryInfo dInfo, Project ownerProject)
        {
            _name = dInfo.Name;
            _path = dInfo.FullName;
            _ownerProject = ownerProject;
        }
        

        public ElementType Type { get { return ElementType.Space; } }

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

        internal string _name;
        public string Name
        {
            get
            {
                if (_name == null || _name == "")
                    _name = "<No Name>";
                return _name;
            }
        }

        public string FullName
        {
            get
            {
                if ((_name == null || _name == "") || (_path == null || _path == ""))
                    return "<No Name>";
                string fullname = _path;
                fullname = fullname.Replace("\\", "/");
                return fullname + "/";
            }
        }

        internal string _path;
        public string Path
        {
            get
            {
                if (_path == null || _path == "")
                    _path = "<No Path>";
                return _path;
            }
        }
        public void SaveAs(string path)
        { }
        public void Save() { }
        public void Load()
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
                retValue.Add(CreateElementObject(type, fi));
            }
            return retValue;
        }
        IElement CreateElementObject(Type type, FileInfo fi)
        {
            IElement retValue = null;
            switch (type.Name.ToLower())
            {
                case "casefile":
                    retValue = this.OwnerProject.CreateCase(fi);
                    retValue.Load();
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
        public IElement Clone
        {
            get { return null; }
        }
        public string GetCompiledText() { return ""; }

    }
}
