using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract.Log;
namespace Vibz.Contract
{
    public enum ReportStatus { Active, Inactive }
    public interface IReport
    {
        string ReportPath { get; set; }
        string ReportName { get; set; }
        ReportStatus Status { get; set; }
        Dictionary<string, string> Configuration { get; set; }
        void Init(Dictionary<string, string> param);
        void Export(LogElement log);


    }
}
