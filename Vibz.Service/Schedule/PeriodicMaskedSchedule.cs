using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Vibz.Service.Schedule
{
    public class PeriodicMaskedSchedule : PeriodicSchedule
    {
        public class Schedule
        {
            public const string MaskedHourBegin = "maskedhourbegin";
            public const string MaskedHourEnd = "maskedhourend";
            public const string MaskedDayBegin = "maskeddaybegin";
            public const string MaskedDayEnd = "maskeddayend";
        }

        int _maskedHourBegin;
        public virtual int MaskedHourBegin { get { return _maskedHourBegin; } set { _maskedHourBegin = value; } }

        int _maskedHourEnd;
        public virtual int MaskedHourEnd { get { return _maskedHourEnd; } set { _maskedHourEnd = value; } }

        int _maskedDayBegin;
        public virtual int MaskedDayBegin { get { return _maskedDayBegin; } set { _maskedDayBegin = value; } }

        int _maskedDayEnd;
        public virtual int MaskedDayEnd { get { return _maskedDayEnd; } set { _maskedDayEnd = value; } }

        public override ScheduleType Type { get { return ScheduleType.PeriodicMask; } }

        public override bool NeedExecution 
        { 
            get 
            {
                if (base.NeedExecution)
                {
                    int hourNow = DateTime.Now.Hour;
                    bool needExecution = ((_maskedHourEnd > _maskedHourBegin)
                        ?!((_maskedHourBegin <= hourNow) && (hourNow < _maskedHourEnd))
                        : ((_maskedHourBegin > hourNow) && (hourNow >= _maskedHourEnd)));
                    if (!needExecution)
                        return false;

                    int dayNow = (int)DateTime.Now.DayOfWeek;
                    needExecution = ((_maskedDayEnd > _maskedDayBegin)
                        ? !((_maskedDayBegin <= dayNow) && (dayNow < _maskedDayEnd))
                        : ((_maskedDayBegin > dayNow) && (dayNow >= _maskedDayEnd)));

                    return needExecution;
                }
                else return false;
            } 
        }
        public override void Load(XmlNode xNode)
        {
            if (xNode == null)
                return;
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loading periodic masked schedule type.");
            base.Load(xNode);

            if (xNode.Attributes[PeriodicMaskedSchedule.Schedule.MaskedHourBegin] == null)
                throw new Exception("Invalid Schedule config. " + PeriodicMaskedSchedule.Schedule.MaskedHourBegin + " is missing for schedule '" + Name + "'.");
            int.TryParse(xNode.Attributes[PeriodicMaskedSchedule.Schedule.MaskedHourBegin].Value, out _maskedHourBegin);

            if (xNode.Attributes[PeriodicMaskedSchedule.Schedule.MaskedHourEnd] == null)
                throw new Exception("Invalid Schedule config. " + PeriodicMaskedSchedule.Schedule.MaskedHourEnd + " is missing for schedule '" + Name + "'.");
            int.TryParse(xNode.Attributes[PeriodicMaskedSchedule.Schedule.MaskedHourEnd].Value, out _maskedHourEnd);

            if (xNode.Attributes[PeriodicMaskedSchedule.Schedule.MaskedDayBegin] == null)
                throw new Exception("Invalid Schedule config. " + PeriodicMaskedSchedule.Schedule.MaskedDayBegin + " is missing for schedule '" + Name + "'.");
            int.TryParse(xNode.Attributes[PeriodicMaskedSchedule.Schedule.MaskedDayBegin].Value, out _maskedDayBegin);

            if (xNode.Attributes[PeriodicMaskedSchedule.Schedule.MaskedDayEnd] == null)
                throw new Exception("Invalid Schedule config. " + PeriodicMaskedSchedule.Schedule.MaskedDayEnd + " is missing for schedule '" + Name + "'.");
            int.TryParse(xNode.Attributes[PeriodicMaskedSchedule.Schedule.MaskedDayEnd].Value, out _maskedDayEnd);

            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loaded periodic masked schedule type.");
        }
        public override XmlNode GetNode(XmlDocument doc)
        {
            XmlNode node = base.GetNode(doc);

            XmlAttribute attr = doc.CreateAttribute(PeriodicMaskedSchedule.Schedule.MaskedHourBegin);
            attr.Value = MaskedHourBegin.ToString();
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(PeriodicMaskedSchedule.Schedule.MaskedHourEnd);
            attr.Value = MaskedHourEnd.ToString();
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(PeriodicMaskedSchedule.Schedule.MaskedDayBegin);
            attr.Value = MaskedDayBegin.ToString();
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(PeriodicMaskedSchedule.Schedule.MaskedDayEnd);
            attr.Value = MaskedDayEnd.ToString();
            node.Attributes.Append(attr);

            return node;
        }
        public override Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> param = base.GetParameters();
            param.Add(PeriodicMaskedSchedule.Schedule.MaskedHourBegin, MaskedHourBegin.ToString());
            param.Add(PeriodicMaskedSchedule.Schedule.MaskedHourEnd, MaskedHourEnd.ToString());
            param.Add(PeriodicMaskedSchedule.Schedule.MaskedDayBegin, MaskedDayBegin.ToString());
            param.Add(PeriodicMaskedSchedule.Schedule.MaskedDayEnd, MaskedDayEnd.ToString());
            return param;
        }
        public override void SetParameters(Dictionary<string, string> param)
        {
            if (param.ContainsKey(PeriodicMaskedSchedule.Schedule.MaskedHourBegin))
            {
                if (!int.TryParse(param[PeriodicMaskedSchedule.Schedule.MaskedHourBegin], out _maskedHourBegin))
                    throw new Exception("MaskedHourBegin must be a valid number.");
                if (_maskedHourBegin > 24 || _maskedHourBegin < 0)
                    throw new Exception("MaskedHourBegin must be between 0 to 24.");
            }
            if (param.ContainsKey(PeriodicMaskedSchedule.Schedule.MaskedHourEnd))
            {
                if (!int.TryParse(param[PeriodicMaskedSchedule.Schedule.MaskedHourEnd], out _maskedHourEnd))
                    throw new Exception("MaskedHourEnd must be a valid number.");
                if (_maskedHourEnd > 24 || _maskedHourEnd < 0)
                    throw new Exception("MaskedHourEnd must be between 0 to 24.");
            }
            if (param.ContainsKey(PeriodicMaskedSchedule.Schedule.MaskedDayBegin))
            {
                if (!int.TryParse(param[PeriodicMaskedSchedule.Schedule.MaskedDayBegin], out _maskedDayBegin))
                    throw new Exception("MaskedDayBegin must be a valid number.");
                if (_maskedDayBegin > 6 || _maskedDayBegin < 0)
                    throw new Exception("MaskedDayBegin must be between 0 to 6.");
            }
            if (param.ContainsKey(PeriodicMaskedSchedule.Schedule.MaskedDayEnd))
            {
                if (!int.TryParse(param[PeriodicMaskedSchedule.Schedule.MaskedDayEnd], out _maskedDayEnd))
                    throw new Exception("MaskedDayEnd must be a valid number.");
                if (_maskedDayEnd > 6 || _maskedDayEnd < 0)
                    throw new Exception("MaskedDayEnd must be between 0 to 6.");
            }
            base.SetParameters(param);
        }
    }
}
