/*
*	Copyright © 2011, The Vibzworld Team
*	All rights reserved.
*	http://code.google.com/p/vauto/
*	
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions
*	are met:
*	
*	- Redistributions of source code must retain the above copyright
*	notice, this list of conditions and the following disclaimer.
*	
*	- Neither the name of the Vibzworld Team, nor the names of its
*	contributors may be used to endorse or promote products
*	derived from this software without specific prior written
*	permission.
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Log
{
    public enum LogType { Element, Set }
    public enum LogSeverity { Error = 4, Warn = 3, Info = 2, Trace = 1 }
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
        string _threadId = "";
        public string ThreadId
        {
            get { return _threadId; }
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
            _threadId = System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
            LogQueue.Instance.Enqueue(new LogQueueElement(message, severity));
        }

        public LogElement Clone()
        {
            LogElement log = new LogElement(this.Message);
            log._time = this.Time;
            log.Severity = this.Severity;
            log.InnerLog = this.InnerLog;
            log._threadId = this.ThreadId;
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
                    if (ele != null)
                        retValue += "\r\n" + ele.ToString();
                }
            }
            return retValue;
        } 
    }
}
