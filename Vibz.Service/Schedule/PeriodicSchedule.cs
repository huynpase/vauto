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

namespace Vibz.Service.Schedule
{
    public class PeriodicSchedule : ScheduleBase
    {
        public class Schedule
        {
            public const string Interval = "interval";
            public const string LastInvocation = "lastinvocation";
        }

        double _interval = 120000;
        public virtual double Interval { get { return _interval; } set { _interval = value; } }

        DateTime _lastInvocation;
        public virtual DateTime LastInvocation { get { return _lastInvocation; } set { _lastInvocation = value; } }

        public override ScheduleType Type { get { return ScheduleType.Periodic; } }

        public override bool NeedExecution 
        { 
            get 
            {
                if (base.NeedExecution)
                {
                    double durFirstLast = ((TimeSpan)LastInvocation.Subtract(InitialInvocation)).TotalMilliseconds;
                    int rem = 0;
                    int invCount = Math.DivRem((int)durFirstLast, (int)Interval, out rem);
                    int nextInv = (invCount + 1) * (int)Interval;
                    double durFirstNow = ((TimeSpan)DateTime.Now.Subtract(InitialInvocation)).TotalMilliseconds;
                    if (durFirstNow >= nextInv)
                    {
                        LastInvocation = DateTime.Now;
                        return true;
                    }
                    else
                        return false;
                }
                else return false;
            } 
        }
        public override void Load(XmlNode xNode)
        {
            if (xNode == null)
                return;
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loading periodic schedule type.");
            base.Load(xNode);

            if (xNode.Attributes[PeriodicSchedule.Schedule.Interval] == null)
                throw new Exception("Invalid Schedule config. " + PeriodicSchedule.Schedule.Interval + " is missing for schedule '" + Name + "'.");

            double.TryParse(xNode.Attributes[PeriodicSchedule.Schedule.Interval].Value, out _interval);

            if (xNode.Attributes[PeriodicSchedule.Schedule.LastInvocation] != null)
                DateTime.TryParse(xNode.Attributes[PeriodicSchedule.Schedule.LastInvocation].Value, out _lastInvocation);
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loaded periodic schedule type.");
        }
        public override XmlNode GetNode(XmlDocument doc)
        {
            XmlNode node = base.GetNode(doc);

            XmlAttribute attr = doc.CreateAttribute(PeriodicSchedule.Schedule.Interval);
            attr.Value = Interval.ToString();
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(PeriodicSchedule.Schedule.LastInvocation);
            attr.Value = LastInvocation.ToString();
            node.Attributes.Append(attr);

            return node;
        }
        public override Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> param = base.GetParameters();
            param.Add(PeriodicSchedule.Schedule.Interval, Interval.ToString());
            return param;
        }
        public override void SetParameters(Dictionary<string, string> param)
        {
            if (param.ContainsKey(PeriodicSchedule.Schedule.Interval))
            {
                if (!double.TryParse(param[PeriodicSchedule.Schedule.Interval], out _interval))
                    throw new Exception("Interval must be a valid number.");
            }
            base.SetParameters(param);
        }
    }
}
