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
    public class OneTimeSchedule : ScheduleBase
    {
        public override ScheduleType Type { get { return ScheduleType.OneTime; } }

        public override bool NeedExecution 
        { 
            get 
            {
                return base.NeedExecution;
            } 
        }
        public override void Load(XmlNode xNode)
        {
            if (xNode == null)
                return;
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loading onetime schedule type.");
            base.Load(xNode);

            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loaded onetime schedule type.");
        }
        public override XmlNode GetNode(XmlDocument doc)
        {
            XmlNode node = base.GetNode(doc);

            return node;
        }
        public override Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> param = base.GetParameters();
            return param;
        }
        public override void SetParameters(Dictionary<string, string> param)
        {
            base.SetParameters(param);
        }
    }
}
