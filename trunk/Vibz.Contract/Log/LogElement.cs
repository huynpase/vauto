using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Log
{
    public enum LogType { Element, Set }
    public enum LogSeverity { Error, Trace, Warn, Info }
    public class LogElement
    {
        internal string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        internal LogSeverity _severity;
        public LogSeverity Severity
        {
            get { return _severity; }
            set { _severity = LogSeverity.Trace; }
        }

        internal DateTime _time;
        public DateTime Time
        {
            get { return _time; }
        }

        public LogType Type
        {
            get { return LogType.Element; }
        }
        List<LogElement> _innerLog = new List<LogElement>();
        public List<LogElement> InnerLog
        {
            get { return _innerLog; }
            set { _innerLog = value; }
        }

        public LogElement(string message)
            :this(message, LogSeverity.Trace)
        { }
        public LogElement(string message, LogSeverity severity)
        {
            _time = DateTime.Now;
            Message = message;
            _severity = severity;
            LogQueue.Instance.Enqueue(new LogQueueElement(message, severity));
        }

        public LogElement Clone()
        {
            LogElement log = new LogElement(this.Message);
            log._time = this.Time;
            log.Severity = this.Severity;
            log.InnerLog = this.InnerLog;
            return log;
        }
        public void Add(string logMessage) { this.InnerLog.Add(new LogElement(logMessage)); }
        public void Add(string logMessage, LogSeverity severity) { this.InnerLog.Add(new LogElement(logMessage, severity)); }
        public void Add(LogElement log) { this.InnerLog.Add(log); }
        public override string ToString()
        {
            string retValue = Message;
            if (this.InnerLog != null && this.InnerLog.Count != 0)
            {
                foreach (LogElement ele in this.InnerLog)
                {
                    retValue += "\r\n" + ele.ToString();
                }
            }
            return retValue;
        } 
    }
}
