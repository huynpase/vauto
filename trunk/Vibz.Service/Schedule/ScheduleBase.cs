using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Vibz.Service.Schedule.Event;

namespace Vibz.Service.Schedule
{
    public abstract class ScheduleBase : ISchedule
    {
        public class ScheduleDocument
        {
            public const string RootNode = "serviceschedules";
            public const string MaxThreadCount = "threadcount";
            public const string TickInterval = "tickinterval";
            public const string LogLevel = "loglevel";
            public class Schedule
            {
                public const string NodeName = "schedule";
                public const string Name = "name";
                public const string Type = "type";
                public const string InitialInvocation = "initialinvocation";
            }
        }
        string _name = "";
        public virtual string Name { get { return _name; } set { _name = value; } }

        List<IEvent> _eventList = null;
        public List<IEvent> EventList 
        { 
            get 
            {
                if (_eventList == null)
                    _eventList = new List<IEvent>();
                return _eventList; 
            } 
            set { _eventList = value; } 
        }

        public virtual ScheduleType Type { get { return ScheduleType.Periodic; } }

        DateTime _initialInvocation = DateTime.Now;
        public virtual DateTime InitialInvocation { get { return _initialInvocation; } set { _initialInvocation = value; } }

        public virtual bool NeedExecution 
        {
            get {
                return (_initialInvocation < DateTime.Now);
            }
        }
        public virtual void Load(XmlNode xNode)
        {
            if (xNode == null)
                return;

            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loading base schedule type.");

            if (xNode.Attributes[ScheduleDocument.Schedule.Name] == null)
                throw new Exception("Invalid schedule config. " + ScheduleDocument.Schedule.Name + " is missing for schedule.");

            _name = xNode.Attributes[ScheduleDocument.Schedule.Name].Value;

            if (xNode.Attributes[ScheduleDocument.Schedule.InitialInvocation] == null)
                throw new Exception("Invalid schedule config. " + ScheduleDocument.Schedule.InitialInvocation + " is missing for schedule '" + _name + "'.");

            DateTime.TryParse(xNode.Attributes[ScheduleDocument.Schedule.InitialInvocation].Value, out _initialInvocation);

            foreach (XmlNode xn in xNode.ChildNodes)
            {
                EventList.Add(GetEventElement(xn));
            }
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loaded base schedule type.");
        }
        IEvent GetEventElement(XmlNode node)
        {
            if (node.Name.ToLower() != EventBase.Event.NodeName)
                return null;

            if (node.Attributes[EventBase.Event.Type] == null)
                throw new Exception("Invalid schedule config. " + EventBase.Event.Type + " is missing for event.");

            IEvent evt = Config.ElementFactory.GetEventElement(node.Attributes[EventBase.Event.Type].Value);
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loading event type '" + node.Attributes[EventBase.Event.Type].Value + "'.");
            evt.Load(_name, node);
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loaded event type '" + node.Attributes[EventBase.Event.Type].Value + "'.");
            return evt;
        }
        
        public virtual XmlNode GetNode(XmlDocument doc)
        {
            return GetNode(doc, true);
        }
        public virtual XmlNode GetNode(XmlDocument doc, bool loadEvent)
        {
            XmlNode node = doc.CreateElement(ScheduleDocument.Schedule.NodeName);

            XmlAttribute attr = doc.CreateAttribute(ScheduleDocument.Schedule.Type);
            attr.Value = Type.ToString();
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(ScheduleDocument.Schedule.Name);
            attr.Value = Name;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(ScheduleDocument.Schedule.InitialInvocation);
            attr.Value = InitialInvocation.ToString();
            node.Attributes.Append(attr);

            if (loadEvent)
            {
                foreach (IEvent evt in EventList)
                {
                    node.AppendChild(evt.GetNode(doc));
                }
            }
            return node;
        }
        public virtual Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(ScheduleDocument.Schedule.Name, Name);
            param.Add(ScheduleDocument.Schedule.InitialInvocation, InitialInvocation.ToString());
            return param;
        }
        public virtual void SetParameters(Dictionary<string, string> param)
        {
            if (param.ContainsKey(ScheduleDocument.Schedule.Name))
            {
                if (_name == "")
                    _name = param[ScheduleDocument.Schedule.Name];
                else if (_name != param[ScheduleDocument.Schedule.Name])
                    throw new Exception("Name of a schedule can not be changed.");
            }
            if (param.ContainsKey(ScheduleDocument.Schedule.InitialInvocation))
            {
                if (!DateTime.TryParse(param[ScheduleDocument.Schedule.InitialInvocation], out _initialInvocation))
                    throw new Exception("Initial invocation must be a valid date time.");
            }
        }
        public Dictionary<string, string> MapParameters(Dictionary<string, string> param)
        {
            return Vibz.Helper.Dictionary.Map(param, GetParameters());
        }
    }
}
