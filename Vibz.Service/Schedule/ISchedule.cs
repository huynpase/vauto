using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Vibz.Service.Schedule.Event;

namespace Vibz.Service.Schedule
{
    public interface ISchedule : IElementNode
    {
        ScheduleType Type { get; }
        List<IEvent> EventList { get; set; }
        bool NeedExecution { get; }
        void Load(XmlNode xNode);
    }
}
