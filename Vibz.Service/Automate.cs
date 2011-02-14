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
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Xml;
//using System.Threading;
using System.Timers;
using Vibz.Service.Schedule;
using Vibz.Service.Schedule.Event;

namespace Vibz.Service
{
    public partial class Automate : ServiceBase
    {
        public const string VibzEventLog = "Application";
        public const string VibzEventLogSource = "Vibz.Service.Automate";
        public const string VibzServiceName = "VibzScheduler";
        public const string VibzServiceDisplayName = "Vibz Scheduled Automation Service";
        private System.Diagnostics.EventLog _AppEventLog;
        static Timer _timer = null;

        public Automate()
        {
            InitializeComponent();
            this._AppEventLog = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this._AppEventLog)).BeginInit();
            //
            // _AppEventLog
            //
            this._AppEventLog.Log = VibzEventLog;
            this._AppEventLog.Source = VibzEventLogSource;
            //
            // TimerService
            //
            this.ServiceName = "Vibz.Service.Automate";
            ((System.ComponentModel.ISupportInitialize)(this._AppEventLog)).EndInit();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                this._AppEventLog.WriteEntry("Vibz.Service.Automate start.");
                // Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loading Task config.");
                _timer = new Timer(Config.ConfigManager.Configuration.TickInterval);
                _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
                _timer.Enabled = true;
                Config.HistoryManager.History.Log(Vibz.Service.Config.LogLevel.Debug, "Timer enabled.");
                Config.HistoryManager.History.Log("Service started.");
            }
            catch (Exception exc)
            {
                this._AppEventLog.WriteEntry("Vibz.Service.Automate exited with error. " + exc.Message + "::" + exc.StackTrace);            
            }
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Config.ConfigManager.Configuration.UpdateLastInvocation();
            InvokeScheduledEvent();
        }

        void InvokeScheduledEvent()
        {
            try
            {
                Config.HistoryManager.History.Log(Vibz.Service.Config.LogLevel.Debug, "Task execution invoked.");
                System.Threading.Semaphore S = 
                    new System.Threading.Semaphore(Config.ConfigManager.Configuration.MaxThreadCount, 
                    Config.ConfigManager.Configuration.MaxThreadCount);

                Config.HistoryManager.History.Log(Vibz.Service.Config.LogLevel.Debug, "Config.ConfigManager.Configuration.ScheduleList:" + (Config.ConfigManager.Configuration.ScheduleList == null ? "null : No event to execute." : "not-null : " + Config.ConfigManager.Configuration.ScheduleList.Count.ToString() + " event to execute."));

                foreach (ISchedule schedule in Config.ConfigManager.Configuration.ScheduleList)
                {
                    Config.HistoryManager.History.Log(Vibz.Service.Config.LogLevel.Debug, "schedule:" + (schedule == null ? "No name" : schedule.Name));
                    try
                    {
                        if (schedule.NeedExecution)
                        {
                            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(ExecuteEvent), (object)schedule);
                            Config.ConfigManager.Configuration.UpdateSchedule(schedule);
                        }
                    }
                    catch (Exception ex)
                    {
                        Config.HistoryManager.History.Log(new Exception("Error occured while executing Event '" + schedule.Name + "'. " + ex.Message + "\r\n" + ex.StackTrace, ex));
                    }
                }
            }
            catch (Exception exc)
            {
                Config.HistoryManager.History.Log(new Exception("Error occured while invoking Event execution. " + exc.Message + "\r\n" + exc.StackTrace, exc));
            }
            finally
            {
                Config.HistoryManager.History.Log(Vibz.Service.Config.LogLevel.Debug, "All task invoked.");            
            }
        }
        public void ExecuteEvent(object scheduleObject)
        {
            ISchedule schedule = (ISchedule)scheduleObject;
            Config.HistoryManager.History.Log(Vibz.Service.Config.LogLevel.Debug, "Executing Event '" + schedule.Name + "'.");
            foreach (IEvent evt in schedule.EventList)
            {
                try
                {
                    evt.Invoke();
                    Config.HistoryManager.History.Log(evt);
                }
                catch (Exception exc)
                {
                    Config.HistoryManager.History.Log("Exception occured while performing event. " + exc.Message);
                }
            }
        }
        protected override void OnStop()
        {
            this._AppEventLog.WriteEntry("Vibz.Service.Automate stop.");
            Config.HistoryManager.History.Log("Service stoped.");
        }
    }
}
