using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Vibz.Solution.Element
{
    [XmlRoot("suite")]
    public class SuiteFile : SuiteElement
    {
        internal const string nSuite = "suite";
        internal const string nReference = "ref";
        public const string Extension = Vibz.FileType.TestSuite;
        
        public SuiteFile()
        { }
        internal SuiteFile(Project ownerProject)
        {
            _ownerProject = ownerProject;
        }
        internal SuiteFile(string fullname, Project ownerProject)
        {
            _name = fullname.Substring(fullname.LastIndexOf("/") + 1);
            _ownerProject = ownerProject;
            _path = this.OwnerProject.FullName + fullname + "." + Extension;
        }
        internal SuiteFile(FileInfo fInfo, Project ownerProject)
        {
            _name = fInfo.Name.Replace(fInfo.Extension, "");
            _path = fInfo.FullName;
            _ownerProject = ownerProject;
        }
        [XmlIgnore()]
        public override ElementType Type { get { return ElementType.Suite; } }

        internal string _name;
        [XmlAttribute(Element.SuiteElement.nName)]
        public override string Name
        {
            get
            {
                if (_name == null || _name == "")
                    _name = "<No Name>";
                return _name;
            }
            set { _name = value; }
        }

        List<SuiteElement> _suiteElement;
        [XmlElement(typeof(SuiteFile), ElementName = SuiteFile.nSuite)]
        [XmlElement(typeof(Function), ElementName = Function.nFunction)]
        public List<SuiteElement> SuiteElements
        {
            get
            {
                if (_suiteElement == null)
                    _suiteElement = new List<SuiteElement>();
                return _suiteElement;
            }
            set { _suiteElement = value; }
        }
        public override void SaveAs(string path)
        {
            Serialize(path);
        }
        public override void Save() 
        {
            Serialize(this.Path);
        }
        void Serialize(string path)
        {
            FileInfo fInfo = new FileInfo(path);
            string tempFile = fInfo.Directory.FullName + "/_temporary_" + fInfo.Name;
            try
            {
                TextWriter writer = new StreamWriter(tempFile);
                XmlSerializer serializer = new XmlSerializer(typeof(SuiteFile));
                serializer.Serialize(writer, this);
                writer.Close();
                FileInfo tInfo= new FileInfo(tempFile);
                tInfo.CopyTo(path, true);
            }
            catch (Exception exc)
            {
                throw new Exception("Suite could not be saved. " + exc.Message, exc);
            }
            finally
            {
                if (File.Exists(tempFile))
                    new FileInfo(tempFile).Delete();
            }
        }
        public override void UnLoad()
        {
            SuiteElements.Clear();
        }
        public override void Load()
        {
            if (!File.Exists(_path))
                throw new Exception("Invalid Suite file reference. ['" + FullName + "']");
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(_path);
            }
            catch (Exception exc)
            {
                throw new Exception("Invalid Suite content. ['" + Path + "']" + exc.Message);
            }
            XmlNodeList xnl = doc.SelectNodes(SuiteFile.nSuite + "/child::node()");
            if (xnl == null)
                return;
            SuiteElements.Clear();
            int i = 0;
            foreach (XmlNode xn in xnl)
            {
                if (xn.NodeType == XmlNodeType.Comment)
                    continue;
                string fullname;
                if (xn.Attributes[nReference] == null)
                    throw new Exception("Required attribute '" + nReference + "' is missing from '" + xn.Name + "' element.");
                else
                    fullname = xn.Attributes[nReference].Value;
                switch(xn.Name.ToLower())
                {
                    case Function.nFunction:
                        Function fnc = Function.LoadFromSuite(this.Path, fullname, ++i, this.OwnerProject);
                        SuiteElements.Add(fnc);
                        break;
                    case SuiteFile.nSuite:
                        SuiteFile sut = this.OwnerProject.CreateSuite(fullname);
                        SuiteElements.Add(sut);
                        break;
                }
                
            }
        }
        [XmlIgnore()]
        public override IElement Clone
        {
            get
            {
                SuiteFile sut = this.OwnerProject.CreateSuite(new FileInfo(this.Path));
                foreach (SuiteElement se in this.SuiteElements)
                {
                    sut.SuiteElements.Add((SuiteElement)se.Clone);
                }
                return sut;
            }
        }
        public override string GetCompiledText() 
        {
            string retValue = "";
            this.OwnerProject.Queue.Enqueue(new Vibz.Contract.Log.LogQueueElement("Compiling suite '" + this.FullName + "'.", Vibz.Contract.Log.LogSeverity.Trace));
            foreach (SuiteElement se in this.SuiteElements)
            {
                switch (se.Type)
                { 
                    case ElementType.Suite:
                        se.Load();
                        break;
                    default:
                        break;
                }
                retValue += se.GetCompiledText();
                foreach (string include in se.Includes)
                {
                    if (!this.Includes.Contains(include))
                        this.Includes.Add(include);
                }
                se.UnLoad();
            }
            return retValue; 
        }
        public bool CheckRecursiveWith(SuiteFile suite)
        {
            if (this.FullName == suite.FullName)
                return true;
            SuiteFile sut = (SuiteFile)suite.Clone;
            sut.Load();
            foreach (SuiteElement se in sut.SuiteElements)
            {
                if (se.Type == ElementType.Suite && this.CheckRecursiveWith((SuiteFile)se))
                    return true;
            }
            return false;
        }

    }
}
