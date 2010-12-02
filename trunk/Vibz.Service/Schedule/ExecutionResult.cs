using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Service.Schedule.Event;

namespace Vibz.Service.Schedule
{
    public class ExecutionResult
    {
        public DateTime StartTime = DateTime.Now;
        public TimeSpan Duration = TimeSpan.FromMinutes(0);
        public EventStatus Status = EventStatus.NoRun;
        public string Message = "";
        public override string ToString()
        {
            return StartTime.ToShortTimeString() + ": " + Duration.ToString() + " " + Status.ToString() + " " + Message;
        }
    }
}
