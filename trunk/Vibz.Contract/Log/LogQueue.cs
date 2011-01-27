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
    public struct LogQueueElement {
        public string Message;
        public LogSeverity Severity;
        public string ThreadId;
        public LogQueueElement(string message, LogSeverity severity)
        {
            Message = message;
            Severity = severity;
            ThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
        }
    }
    public class LogQueue : Queue<LogQueueElement>
    {
        static object _padlock = new object();
        static LogQueue _progress;
        int _errorCount;
        int _warnCount;
        LogQueue()
        { }
        public static LogQueue Instance
        {
            get {
                if (_progress == null)
                {
                    lock (_padlock)
                    {
                        if (_progress == null)
                        {
                            _progress = new LogQueue();
                        }
                    }
                }
                return _progress;
            }
        }
        public void Reset()
        {
            _progress = null;
        }
        public new void Enqueue(LogQueueElement element)
        {
            base.Enqueue(element);
            switch (element.Severity)
            { 
                case LogSeverity.Error:
                    _errorCount++;
                    break;
                case LogSeverity.Warn:
                    _warnCount++;
                    break;
            }
        }
        public int ErrorCount
        {
            get { return _errorCount; }
        }
        public int WarnCount
        {
            get { return _warnCount; }
        }
    }
}
