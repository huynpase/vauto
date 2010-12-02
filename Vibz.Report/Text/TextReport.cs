using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Report;
using Vibz.Contract.Log;
using Vibz.Contract;
namespace Vibz.Report.Text
{
    public class TextReport : ReportBase
    {
        string _format = "";

        public void Init(Dictionary<string, string> param)
        {
            base.Init(param);
            _format = param["Format"];
        }
        public override void Export(LogElement log)
        {
            Write(log, 0);
        }
        void Write(LogElement log, int indent)
        {
            string indentText = "";
            for (int i = 0; i < indent; i++)
                indentText += "\t";
            string logMessage =log.Time.ToString() + " : " + log.Severity.ToString() + " -" + indentText + log.Message;
            if (_format.Trim() != "")
                logMessage = _format.Replace("{DateTime}", log.Time.ToString()).
                    Replace("{Severity}", log.Severity.ToString()).
                    Replace("{Indent}", indentText).
                    Replace("{Message}", log.Message);

            System.IO.File.AppendAllText(FilePath, "\r\n" + logMessage);
            indent++;
            foreach (LogElement iLog in log.InnerLog)
            {
                Write(iLog, indent);
            }
            indent--;
        }
    }
}
