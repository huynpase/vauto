using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Vibz.Solution.Element
{
    public class CaseFile : IElement
    {
        internal const string nSection = "section";
        internal const string nInclude = "include";
        internal const string nReference = "ref";
        public const string Extension = Vibz.FileType.TestCase;
        Project _ownerProject;
        public Project OwnerProject
        {
            get
            {
                return _ownerProject;
            }
        }
        internal CaseFile(FileInfo fInfo, Project ownerProject)
        {
            _name = fInfo.Name;
            _path = fInfo.FullName;
            _ownerProject = ownerProject;
        }

        public virtual ElementType Type { get { return ElementType.Case; } }

        List<IElement> _functions;
        public List<IElement> Functions
        {
            get {
                if (_functions == null)
                    _functions = new List<IElement>();
                return _functions;
            }
            set { _functions = value; }
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
                if (_name == null || _name == "")
                    _name = "<No Name>";
                return _name;
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
        public void SaveAs(string path) { }
        public void Save() { }
        public void Load()
        {
            if (!File.Exists(_path))
                throw new Exception("Invalid " + this.GetType().Name + " path.");
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(_path);
            }
            catch (Exception exc)
            {
                throw new Exception("Invalid " + this.GetType().Name + " content. " + exc.Message);
            }
            XmlNodeList xnl = doc.SelectNodes("//function/@name");
            if (xnl == null)
                return;
            Functions.Clear();
            foreach (XmlNode xn in xnl)
            {
                if (xn.NodeType == XmlNodeType.Comment)
                    continue;
                Functions.Add(this.OwnerProject.CreateFunction(new FileInfo(_path), xn.Value));
            }
        }
        public IElement Clone { get { return null; } }
        public string GetCompiledText() { return ""; }
    }
}
