using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Xml;
using Vibz.Contract.Log;

namespace Vibz.Solution.Element
{
    public class Project : Space
    {
        string _buildLocation = @"\\bin";
        public const string NodeName = "project";
        public const string BuildPath = "buildpath";
        public const string ApplicationGlobal = "appglobal";
        public const string ApplicationConfig = "appconfig";
        public const string ReportPath = "reportpath";
        public string BuildLocation
        {
            get { return MapPath(_buildLocation); }
        }
        string _appGlobalLocation = "/global.ag";
        public ApplicationGlobalFile AppGlobal
        {
            get {

                string globalFile = MapPath(_appGlobalLocation);
                if (File.Exists(globalFile))
                {
                    ApplicationGlobalFile global = CreateApplicationGlobal(new FileInfo(globalFile));
                    global.Load();
                    return global;
                }
                else
                    return null;
            }
        }
        string _appConfig = "/app.config";
        public ApplicationConfiguration AppConfig
        {
            get
            {

                string configFile = MapPath(_appConfig);
                if (File.Exists(configFile))
                {
                    ApplicationConfiguration config = new ApplicationConfiguration(configFile);
                    return config;
                }
                else
                    return null;
            }
        }

        string _rptPath = "/app.config";
        public string ReportDirectory
        {
            get { return MapPath(_rptPath);  }
        }
        internal string MapPath(string path)
        {
            return System.IO.Path.Combine(_path, path);
        }
        XmlDocument _xDoc = new XmlDocument();
        public Project(FileInfo fInfo)
            : base(fInfo.Directory)
        {
            this._ownerProject = this;

            LoadProjectParam(fInfo.FullName);
        }
        void LoadProjectParam(string prjPath)
        {
            try
            {
                _xDoc.Load(prjPath);
                XmlNode xNode = _xDoc.SelectSingleNode("//" + NodeName + "/" + BuildPath);
                if (xNode != null)
                    _buildLocation = xNode.InnerText.Replace('/', '\\');
                xNode = _xDoc.SelectSingleNode("//" + NodeName + "/" + ApplicationGlobal);
                if (xNode != null)
                    _appGlobalLocation = xNode.InnerText.Replace('/', '\\');
                xNode = _xDoc.SelectSingleNode("//" + NodeName + "/" + ApplicationConfig);
                if (xNode != null)
                    _appConfig = xNode.InnerText.Replace('/', '\\');
                xNode = _xDoc.SelectSingleNode("//" + NodeName + "/" + ReportPath);
                if (xNode != null)
                    _rptPath = xNode.InnerText.Replace('/', '\\');
            }
            catch (Exception exc)
            {
                throw new Exception("Invalid project or sollution.");
            }
        }
        public void Reset(Dictionary<string, string> param)
        {

            foreach (string key in param.Keys)
            {
                string value = param[key];
                string valueCheck = value.Replace('/', '\\');
                if (valueCheck.Contains(_path))
                    value = Vibz.Helper.IO.CreateRelativePath(_path, valueCheck);
                XmlNode xNode = _xDoc.SelectSingleNode("//" + NodeName + "/" + key);
                if (xNode != null)
                    xNode.InnerText = value;
                else
                {
                    XmlNode xNewNode = _xDoc.CreateElement(key);
                    xNewNode.InnerText = value;
                    XmlNode xParentNode = _xDoc.SelectSingleNode("//" + NodeName);
                    if (xParentNode != null)
                        xParentNode.AppendChild(xNewNode);
                }
            }
            _xDoc.Save(new Uri(_xDoc.BaseURI).LocalPath);
            LoadProjectParam(new Uri(_xDoc.BaseURI).LocalPath);
        }
        public LogQueue Queue
        {
            get {
                return LogQueue.Instance;
            }
        }

        public SuiteFile CreateSuite(string fullname)
        {
            return new SuiteFile(fullname, this);
        }
        public SuiteFile CreateSuite(FileInfo fInfo)
        {
            return new SuiteFile(fInfo, this);
        }
        public SuiteFile CreateSuite()
        {
            return new SuiteFile(this);
        }
        public IdentifierFile CreateIdentifier(FileInfo fInfo)
        {
            return new IdentifierFile(fInfo, this);
        }
        public Function CreateFunction(FileInfo fInfo, string name)
        {
            return new Function(fInfo, name, this);
        }
        public Function CreateFunction(string fullname)
        {
            return new Function(fullname, this);
        }
        public CaseFile CreateCase(FileInfo fInfo)
        {
            return new CaseFile(fInfo, this);
        }
        public ApplicationGlobalFile CreateApplicationGlobal(FileInfo fInfo)
        {
            return new ApplicationGlobalFile(fInfo, this);
        }
        public Space CreateSpace(DirectoryInfo dInfo)
        {
            return new Space(dInfo, this);
        }
    }
}
