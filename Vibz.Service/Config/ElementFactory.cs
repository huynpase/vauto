using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Service.Schedule;
using Vibz.Service.Schedule.Event;

namespace Vibz.Service.Config
{
    public class ElementFactory
    {
        public static ISchedule GetScheduleElement(ScheduleType type)
        {
            return GetScheduleElement(type, null);
        }
        public static ISchedule GetScheduleElement(ScheduleType type, ScheduleBase sch)
        {
            return GetScheduleElement(type.ToString(), sch);
        }
        internal static ISchedule GetScheduleElement(string type)
        {
            return GetScheduleElement(type, null);
        }
        internal static ISchedule GetScheduleElement(string type, ScheduleBase sch)
        {
            ISchedule retVal = null;
            switch (type.ToLower())
            {
                case "onetime":
                    retVal = new OneTimeSchedule();
                    break;
                case "periodicmask":
                    retVal = new PeriodicMaskedSchedule();
                    break;
                default:
                case "periodic":
                    retVal = new PeriodicSchedule();
                    break;
            }
            if (sch != null)
            {
                retVal.Name = sch.Name;
                retVal.EventList = sch.EventList;
            }
            return retVal;
        }
        public static IElementNode GetElement(object eleType, object eleMap)
        {
            if (eleType.GetType().FullName == typeof(ScheduleType).FullName)
            {
                return GetScheduleElement((ScheduleType)eleType, (ScheduleBase)eleMap);
            }
            else if (eleType.GetType().FullName == typeof(EventType).FullName)
            {
                return GetEventElement((EventType)eleType, (EventBase)eleMap);
            }
            return null;
        }
        public static IEvent GetEventElement(EventType type)
        {
            return GetEventElement(type, null);        
        }
        public static IEvent GetEventElement(EventType type, EventBase evt)
        {
            return GetEventElement(type.ToString(), evt);
        }
        internal static IEvent GetEventElement(string type)
        {
            return GetEventElement(type, null);
        }
        internal static IEvent GetEventElement(string type, EventBase evt)
        {
            IEvent retVal = null;
            switch (type.ToLower())
            {
                default:
                case "command":
                    retVal = new CommandEvent();
                    break;
            }
            if (evt != null)
            {
                retVal.Name = evt.Name;
                retVal.ScheduleName = evt.ScheduleName;
            }
            return retVal;
        }
    }
}
