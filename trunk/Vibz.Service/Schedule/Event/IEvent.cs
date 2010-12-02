using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Vibz.Service.Schedule.Event
{
    public interface IEvent : IElementNode
    {
        string ScheduleName { get; set; }
        EventType Type { get; }
        ExecutionResult Result { get; set; }
        void Invoke();
        void Load(string scheduleName, XmlNode xNode);
    }
}
