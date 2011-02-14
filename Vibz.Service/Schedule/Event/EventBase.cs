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
using System.Xml;

namespace Vibz.Service.Schedule.Event
{
    public abstract class EventBase : IEvent
    {
        public class Event
        {
            public const string NodeName = "event";
            public const string Name = "name";
            public const string Type = "type";
        }
        string _name = "";
        public virtual string Name { get { return _name; } set { _name = value; } }

        string _scheduleName = "";
        public virtual string ScheduleName { get { return _scheduleName; } set { _scheduleName = value; } }

        ExecutionResult _result;
        public virtual ExecutionResult Result 
        { 
            get {
                if (_result == null)
                    _result = new ExecutionResult();
                return _result; 
            } 
            set { 
                _result = value; 
            } 
        }

        public virtual EventType Type { get { return EventType.Command; } }

        public abstract void InvokeTask();
        public virtual void Invoke()
        {
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, Name + " invoke Begin.");
            Result.StartTime = DateTime.Now;
            try
            {
                InvokeTask();
            }
            catch (Exception exc)
            {
                Result.Message = "Error: " + exc.Message;
            }
            Result.Duration = DateTime.Now.Subtract(Result.StartTime);
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, Name + " invoke End.");
        }
        public virtual void Load(string scheduleName, XmlNode xNode)
        {
            if (xNode == null)
                return;
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loading base event.");

            if (xNode.Attributes[Event.Name] == null)
                throw new Exception("Invalid event defination. " + Event.Name + " is missing.");
            _name = xNode.Attributes[Event.Name].Value;
            _scheduleName = scheduleName;
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loaded base event.");
        
        }
        public virtual XmlNode GetNode(XmlDocument doc)
        {
            XmlNode node = doc.CreateElement(Event.NodeName);

            XmlAttribute attr = doc.CreateAttribute(Event.Name);
            attr.Value = Name;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(Event.Type);
            attr.Value = Type.ToString();
            node.Attributes.Append(attr);

            return node;
        }
        public virtual Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(Event.Name, Name);
            return param;
        }
        public virtual void SetParameters(Dictionary<string, string> param)
        {
            if (param.ContainsKey(Event.Name))
            {
                if (_name == "")
                    _name = param[Event.Name];
                else if (_name != param[Event.Name])
                    throw new Exception("Name of an event can not be changed.");

            }
        }
        public Dictionary<string, string> MapParameters(Dictionary<string, string> param)
        {
            return Vibz.Helper.Dictionary.Map(param, GetParameters());
        }
    }
}
