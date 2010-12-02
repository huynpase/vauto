using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract;
namespace Vibz.Solution.Element
{
    public abstract class SuiteElement : IElement, ICompile
    {
        internal const string nReference = "ref";
        internal const string nName = "name";
        internal Project _ownerProject;
        List<string> _includes;
        [XmlIgnore()]
        public List<string> Includes
        {
            get
            {
                if (_includes == null)
                    _includes = new List<string>();
                return _includes;
            }
        }
        [XmlIgnore()]
        public Project OwnerProject
        {
            get
            {
                return _ownerProject;
            }
        }
        [XmlIgnore()]
        public abstract ElementType Type { get; }

        [XmlAttribute(Element.SuiteElement.nName)]
        public abstract string Name { get; set; }
        internal string _fullname;
        [XmlAttribute(Element.SuiteElement.nReference)]
        public virtual string FullName
        {
            get
            {
                if (_fullname == null)
                {
                    if (_path == null || _path == "")
                        return "<No Name>";
                    FileInfo fi = new FileInfo(_path);
                    _fullname = fi.FullName.Substring(0, fi.FullName.LastIndexOf('.'));
                    _fullname = _fullname.Replace("\\", "/");
                    _fullname = _fullname.Replace(this.OwnerProject.FullName, "");
                }
                return _fullname;
            }
            set { _fullname = value; }
        }

        
        internal string _path;
        [XmlIgnore()]
        public string Path
        {
            get
            {
                if (_path == null || _path == "")
                    _path = "<No Path>";
                return _path;
            }
        }

        public abstract void SaveAs(string path);
        public abstract void Save();
        public abstract void Load();
        public abstract void UnLoad();
        [XmlIgnore()]
        public abstract IElement Clone { get; }
        public abstract string GetCompiledText();
    }
}
