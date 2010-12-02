using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Report;
using Vibz.Contract.Log;
using Vibz.Contract;
namespace Vibz.Report
{
    public abstract class ReportBase : IReport
    {
        string _filepath = "";
        bool _isFirstAccess = true;
        ReportStatus _status = ReportStatus.Active;
        public ReportStatus Status
        {
            get
            {
                return _status;
            }
            set { _status = value; }
        }

        string _name = "";
        public string ReportName
        {
            get { return _name; }
            set { _name = value; }
        }

        string _reportpath = "";
        public string ReportPath
        {
            get { return _reportpath; }
            set { _reportpath = value; }
        }

        Dictionary<string, string> _configuration;
        public Dictionary<string, string> Configuration
        {
            get
            {
                if (_configuration == null)
                    _configuration = new Dictionary<string, string>();
                return _configuration;
            }
            set { _configuration = value; }
        }
        public virtual void Init(Dictionary<string, string> param)
        {
            _filepath = param["FilePath"];
            _isFirstAccess = true;
            
        }
        protected string FilePath
        {
            get {
                if (_isFirstAccess)
                {
                    if (_filepath.ToLower().Contains("@{reportpath}"))
                        _filepath = _filepath.ToLower().Replace("@{reportpath}", _reportpath);

                    if (System.IO.File.Exists(_filepath))
                        System.IO.File.Delete(_filepath);
                    // _filepath = Vibz.Helper.IO.CreateFolderPath(_filepath, Vibz.Helper.IOType.File);
                    _isFirstAccess = false;
                }
                return _filepath;            
            }
        }
        public abstract void Export(LogElement log);
    }
}
