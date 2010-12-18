using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract.Data;
namespace Vibz.Solution.Element
{
    public class Function : SuiteElement
    {
        internal const string nFunction = "function";
        internal const string nBody = "body";
        internal const string nIncludeId = "id";
        public class Call
        {
            internal const string nName = "name";
            internal const string nCall = "call";
            public class Data
            {
                internal const string nName = "name";
                internal const string nData = "data";
            }
        }
        public Function()
        { }
        internal Function(string fullname, Project ownerProject)
        {
            _name = fullname.Substring(fullname.LastIndexOf("/") + 1);
            _ownerProject = ownerProject;
            if (!fullname.Contains("/"))
                throw new Exception("Invalid function reference.");
            _path = this.OwnerProject.FullName + fullname.Substring(0, fullname.LastIndexOf("/")) + "." + CaseFile.Extension;
        }
        internal Function(FileInfo fInfo, string name, Project ownerProject)
        {
            _name = name;
            _path = fInfo.FullName;
            _ownerProject = ownerProject;
        }
        [XmlIgnore()]
        public override ElementType Type { get { return ElementType.Function; } }

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

        internal string _fullname;
        [XmlAttribute(Element.SuiteElement.nReference)]
        public override string FullName
        {
            get
            {
                return base.FullName + "/" + Name;
            }
            set { _fullname = value; }
        }
        DataHandler _dataSet;
        [XmlElement(DataCollection.nData)]
        public DataHandler DataSet
        {
            get
            {
                if (_dataSet == null)
                {
                    _dataSet = new DataHandler();
                }
                return _dataSet;
            }
            set {
                _dataSet = value;
            }
        }
        public void UpdateData(string key, string value)
        {
            if (!DataSet.DataList.ContainsData(key))
                throw new Exception("Function " + this.FullName + " has no data argument with name '" + key + "'.");
            else
                DataSet.DataList.Update(key, new Vibz.Contract.Data.Text(value));
        }
        public void UpdateData(string key, IData value)
        {
            if (!DataSet.DataList.ContainsData(key))
                throw new Exception("Function " + this.FullName + " has no data argument with name '" + key + "'.");
            else
                DataSet.DataList.Update(key, value);
        }
        public void UpdateData(Variable data)
        {
            if (!DataSet.DataList.ContainsData(data.Name))
                throw new Exception("Function " + this.FullName + " has no data argument with name '" + data.Name + "'.");
            else
                DataSet.DataList.Update(data);
        }
        public override void UnLoad()
        { }
        public override void Load()
        {
            if (!File.Exists(_path))
                throw new Exception("Invalid Function file path.");
            this.OwnerProject.Queue.Enqueue(new Vibz.Contract.Log.LogQueueElement("Loading function '" + this.FullName + "'.", Vibz.Contract.Log.LogSeverity.Trace));
            XmlDocument doc = new XmlDocument();
            XmlNodeList xnlFnc = null;
            try
            {
                doc.Load(_path);
                xnlFnc = doc.SelectNodes(CaseFile.nSection + "/" + nFunction + "[@" + nName + "='" + _name + "']");
                if (xnlFnc.Count > 1)
                    throw new Exception("Multiple occurances of function '" + _name + "' found in '" + _path + "'.");

            }
            catch (Exception exc)
            {
                throw new Exception("Invalid case file content. " + exc.Message);
            }
            try
            {
                doc.Load(_path);
            }
            catch (Exception exc)
            {
                throw new Exception("Invalid Function content. " + exc.Message);
            }
            XmlNode xnData = doc.SelectSingleNode(CaseFile.nSection + "/" + nFunction + "[@" + nName + "='" + _name + "']/" + DataCollection.nData);
            if (xnData != null)
            {
                DataSet = DataHandler.Load(xnData, _path, Vibz.Interpreter.Data.DataProcessor.Instance);
            }
        }
        public override void SaveAs(string path) { }
        public override void Save() { }
        public static Function LoadFromSuite(string path, string fullname, int index, Project prj)
        {
            Function retValue = prj.CreateFunction(fullname);
            if (!File.Exists(path))
                throw new Exception("Invalid Function file path.");
            prj.Queue.Enqueue(new Vibz.Contract.Log.LogQueueElement("Loading function '" + fullname + "'.", Vibz.Contract.Log.LogSeverity.Trace));
            XmlDocument doc = new XmlDocument();
            XmlNodeList xnlFnc = null;
            try
            {
                doc.Load(retValue.Path);
                xnlFnc = doc.SelectNodes(SuiteFile.nSuite + "/" + nFunction + "[@" + nName + "='" + retValue.Name + "']");
                if (xnlFnc.Count > 1)
                    throw new Exception("Multiple occurances of function '" + retValue.Name + "' found in '" + retValue.Path + "'.");

            }
            catch (Exception exc)
            {
                throw new Exception("Invalid case file content. " + exc.Message);
            }
            try
            {
                doc.Load(path);
            }
            catch (Exception exc)
            {
                throw new Exception("Invalid Function content. " + exc.Message);
            }
            XmlNode xnData = doc.SelectSingleNode(SuiteFile.nSuite + "/" + nFunction + "[" + index.ToString() + "]/" + DataCollection.nData);
            if (xnData != null)
            {
                retValue.DataSet = DataHandler.Load(xnData, retValue.Path, Vibz.Interpreter.Data.DataProcessor.Instance);
            }
            return retValue;
        }

        [XmlIgnore()]
        public override IElement Clone
        {
            get {
                Function fnc = this.OwnerProject.CreateFunction(new FileInfo(this.Path), this.Name);
                foreach (Variable dm in this.DataSet.DataList)
                {
                    fnc.DataSet.DataList.Add(dm.Name, dm.Data, dm._filePath, dm.InnerText);
                }
                return fnc;
            }
        }
        public override string GetCompiledText() 
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(_path);
            }
            catch (Exception exc)
            {
                throw new Exception("Invalid Function content. [" + Path + "]" + exc.Message);
            }
            this.OwnerProject.Queue.Enqueue(new Vibz.Contract.Log.LogQueueElement("Compiling function '" + this.FullName + "'.", Vibz.Contract.Log.LogSeverity.Trace));
            XmlNodeList xnlVar = doc.SelectNodes("//" + CaseFile.nSection + "/" + CaseFile.nInclude + "/@" + CaseFile.nReference);
            if (xnlVar != null)
            {
                foreach (XmlNode xnv in xnlVar)
                {
                    if (xnv.NodeType == XmlNodeType.Comment)
                        continue;
                    Includes.Add(xnv.Value);
                }
            }
            DataHandler idList = new DataHandler();
            xnlVar = doc.SelectNodes("//" + nFunction + "[@" + nName + "='" + this.Name + "']/" + CaseFile.nInclude + "/@" + Function.nIncludeId);
            if (xnlVar != null)
            {
                foreach (XmlNode xnv in xnlVar)
                {
                    if (xnv.NodeType == XmlNodeType.Comment)
                        continue;
                    IdentifierFile iFile = this.OwnerProject.CreateIdentifier(Reference.Resolve(this, xnv.Value));
                    iFile.Load();
                    idList.DataList.Merge(iFile.DataSet.DataList);
                }
            }
            XmlNode xn = doc.SelectSingleNode("//" + nFunction + "[@" + nName + "='" + this.Name + "']/" + nBody);
            if (xn == null)
                throw new Exception("Invalid function call. " + this.Name);
            string retValue = "<" + nFunction + " " + nName + "=\"" + this.Name + "\""  + " " + nReference + "=\"" + this.FullName + "\">";
            retValue += DataSet.DataList.GetCompiledText();
            XmlNodeList xnlParsed = ParseInstructionList(xn.ChildNodes, idList);
            if (xnlParsed != null)
            {
                xn.RemoveAll();
                while (xnlParsed.Count > 0)
                {
                    XmlNode xnNew = xnlParsed.Item(0);
                    xn.AppendChild(xnNew);
                }
            }
            retValue += xn.OuterXml;
            retValue += "</" + nFunction + ">";
            return retValue;
        }
        XmlNodeList ParseInstructionList(XmlNodeList xnInstructionList, DataHandler idList)
        {
            if (xnInstructionList == null || xnInstructionList.Count == 0)
                return null;
            XmlNode xnTemp = xnInstructionList.Item(0).OwnerDocument.CreateElement("temp");

            foreach (XmlNode xnInst in xnInstructionList)
            {
                if (xnInst.Name.ToLower() == Call.nCall)
                {
                    try
                    {
                        XmlNodeList xnlCall = ParseCall(xnInst, idList);
                        while (xnlCall.Count > 0)
                        {
                            XmlNode xnCallInst = xnlCall.Item(0);
                            xnTemp.AppendChild(xnCallInst);
                        }
                        continue;
                    }
                    catch (Exception exc)
                    {
                        throw new Exception(Vibz.Contract.Log.LogException.GetFullException(exc));
                    }
                }
                XmlNode xnInstCopy = xnInst.CloneNode(true);
                if (xnInstCopy.Attributes != null)
                {
                    foreach (XmlAttribute attr in xnInstCopy.Attributes)
                        attr.Value = Parse(attr.Value, idList);
                }

                XmlNodeList xnlInstParsed = ParseInstructionList(xnInstCopy.ChildNodes, idList);
                if (xnlInstParsed != null)
                {
                    while (xnInstCopy.ChildNodes.Count!=0)
                        xnInstCopy.RemoveChild(xnInstCopy.ChildNodes[0]);
                    while (xnlInstParsed.Count > 0)
                    {
                        XmlNode xnNew = xnlInstParsed.Item(0);
                        xnInstCopy.AppendChild(xnNew);
                    }
                }
                xnTemp.AppendChild(xnInstCopy);
            }
            return xnTemp.ChildNodes;
        }
        XmlNodeList ParseCall(XmlNode xnCall, DataHandler idList)
        {
            string function = (xnCall.Attributes[Call.nName] == null ? "" : xnCall.Attributes[Call.nName].Value);
            try
            {
                string funcName = function.Substring(function.LastIndexOf("/") + 1);
                FileInfo fi = Reference.ResolveFunction(this, function);
                Function fnc = this.OwnerProject.CreateFunction(fi, funcName);
                fnc.DataSet = DataHandler.Load(xnCall.SelectSingleNode(Call.Data.nData), Path, Vibz.Interpreter.Data.DataProcessor.Instance);

                string fncText = fnc.GetCompiledText();
                XmlNode node = (XmlNode)xnCall.OwnerDocument.CreateElement(Call.nCall);
                node.InnerXml = fncText;
                return node.SelectSingleNode("//" + Function.nBody).ChildNodes;
            }
            catch (Exception exc)
            {
                throw new Exception("--at function call " + function, exc);
            }
        }
        string Parse(string text, DataHandler idList)
        {
            if (text.StartsWith("@"))
            {
                if (DataSet.DataList.ContainsData(text.Remove(0, 1)))
                {
                    Variable dm = DataSet.DataList.Get(text.Remove(0, 1));
                    if (
                        (dm.Source == null || dm.Source == "" || dm.Source.ToLower() == Vibz.Contract.Data.Source.SourceType.Internal.ToString().ToLower()) &&
                        (dm.Type == null || dm.Type == "" || dm.Type.ToLower() == Vibz.Contract.Data.DataType.Scalar.ToString().ToLower())
                      )
                        return dm.InnerText;
                    else
                        return text;
                }
                else
                    return text;
            }
            if (text.StartsWith("$") && idList.DataList.ContainsData(text.Remove(0, 1)))
                return idList.DataList.Get(text.Remove(0, 1)).InnerText;
            return text;
        }
    }
}
