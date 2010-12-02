using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Vibz.Service.Schedule;
using Vibz.Service.Schedule.Event;

namespace Vibz.Service.History
{
    public class HistoryEvent : HistoryBase
    {
        public class EventNode
        {
            public const string NodeName = "event";
            public const string Name = "name";
            public const string StartTime = "starttime";
            public const string Duration = "duration";
            public const string Result = "result";
        }
        public HistoryEvent() { }
        public HistoryEvent(IEvent evt)
        {
            LogTime = DateTime.Now;
            _result = evt.Result;
            _name = evt.Name;
        }

        public override HistoryType Type { get { return HistoryType.Event; } }
        
        public override string Message { get { return _result.Message; } set { _result.Message = value; } }

        string _name="No_name";
        public string Name { get { return _name; } set { _name = value; } }

        ExecutionResult _result = new ExecutionResult();
        public ExecutionResult Result { get { return _result; } set { _result = value; } }


        public override void Load(XmlNode xNode)
        {
            if (xNode == null)
                return;
            
            base.Load(xNode);

            if (xNode.Attributes[HistoryEvent.EventNode.Name] == null)
                throw new Exception("Invalid history file. " + HistoryEvent.EventNode.Name + " is missing for Event history.");

            if (xNode.Attributes[HistoryEvent.EventNode.StartTime] == null)
                throw new Exception("Invalid history file. " + HistoryEvent.EventNode.StartTime + " is missing for Event history.");

            if (xNode.Attributes[HistoryEvent.EventNode.Duration] == null)
                throw new Exception("Invalid history file. " + HistoryEvent.EventNode.Duration + " is missing for Event history.");

            _name = xNode.Attributes[HistoryEvent.EventNode.Name].Value;

            DateTime date = DateTime.MinValue;
            DateTime.TryParse(xNode.Attributes[HistoryEvent.EventNode.StartTime].Value, out date);
            _result.StartTime = date;

            int mSec=0;
            int.TryParse(xNode.Attributes[HistoryEvent.EventNode.Duration].Value, out mSec);
            _result.Duration = new TimeSpan(0, 0, 0, 0, mSec);

            if (xNode.Attributes[HistoryEvent.EventNode.Result] == null)
                _result.Status = EventStatus.Completed;
            else
            {
                string result = xNode.Attributes[HistoryEvent.EventNode.Result].Value;
                switch (result.ToLower())
                {
                    case "completed":
                        _result.Status = EventStatus.Completed;
                        break;
                    case "norun":
                        _result.Status = EventStatus.NoRun;
                        break;
                }
            }
            if (xNode.InnerText != null)
                Message = xNode.InnerText;
        }

        public override XmlNode GetNode(XmlDocument doc)
        {
            XmlNode xNode = base.GetNode(doc);

            XmlAttribute attr = doc.CreateAttribute(EventNode.Name);
            attr.Value = Name;
            xNode.Attributes.Append(attr);

            attr = doc.CreateAttribute(EventNode.StartTime);
            attr.Value = Result.StartTime.ToString();
            xNode.Attributes.Append(attr);

            attr = doc.CreateAttribute(EventNode.Duration);
            attr.Value = Result.Duration.TotalMilliseconds.ToString();
            xNode.Attributes.Append(attr);

            attr = doc.CreateAttribute(EventNode.Result);
            attr.Value = Result.Status.ToString();
            xNode.Attributes.Append(attr);

            XmlCDataSection cdata = doc.CreateCDataSection(Message);
            xNode.AppendChild(cdata);
            return xNode;
        }
    }
}
