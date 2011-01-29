using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Vibz.Solution.Element
{
    public abstract class ElementBase : IElement
    {
        public ElementBase() { }
        public ElementBase(Project ownerProject)
        {
            _ownerProject = ownerProject;
        }
        internal const string nReference = "ref";
        internal const string nName = "name";
        internal bool _hasError = false;
        [XmlIgnore()]
        public bool HasError { get { return _hasError; } set { _hasError = value; } }
        internal string _error = null;
        [XmlIgnore()]
        public string Error { get { return _error; } set { _error = value; } }
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
        
        [XmlAttribute(Element.ElementBase.nReference)]
        public abstract string FullName { get; set; }
        internal string _name;
        [XmlAttribute(Element.SuiteElement.nName)]
        public string Name
        {
            get
            {
                if (_name == null || _name == "")
                    _name = "<No Name>";
                return _name;
            }
            set { _name = value; }
        }
        [XmlIgnore()]
        public abstract ElementType Type { get; }
        [XmlIgnore()]
        public virtual IElement Clone
        {
            get { return null; }
        }
        public abstract void Load();
        public virtual void Save() { }
        public virtual string GetCompiledText() { return ""; }
        public virtual void SaveAs(string path) { }
        Project _ownerProject;
        [XmlIgnore()]
        public virtual Project OwnerProject
        {
            get
            {
                return _ownerProject;
            }
        }
        internal void SetOwnerProject(Project owner)
        { _ownerProject = owner; }
    }
}
