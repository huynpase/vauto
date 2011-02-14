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
using System.Diagnostics;

namespace Vibz.Service.Schedule.Event
{
    public class CommandEvent : EventBase
    {
        public class Event
        {
            public const string Command = "command";
            public const string WorkingDirectory = "workingdirectory";
            public const string Arguments = "arguments";
        }
        string _workingDirectory = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName; // Environment.CurrentDirectory;
        public virtual string WorkingDirectory { get { return _workingDirectory; } set { _workingDirectory = value; } }

        string _command = Environment.ExpandEnvironmentVariables("%comspec%");
        public virtual string Command { get { return _command; } set { _command = value; } }

        string _arguments;
        public virtual string Arguments { get { return _arguments; } set { _arguments = value; } }

        public override void InvokeTask()
        {
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Command: [" + Command + "]");
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Arguments: [" + Arguments + "]");
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "WorkingDirectory: [" + WorkingDirectory + "]");
            try
            {
                ProcessStartInfo pStartInfo = new ProcessStartInfo();
                pStartInfo.FileName = Command;
                pStartInfo.Arguments = Arguments;
                pStartInfo.UseShellExecute = false;
                pStartInfo.RedirectStandardError = true;
                Process p = Process.Start(pStartInfo);
                
                p.WaitForExit();
                
                if (p.ExitCode != 0)
                {
                    Result.Message = "Error occured. Process terminated. \r\n\t" + p.StandardError.ReadToEnd();
                    Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Execution failed: " + Result.Message);
                }
                else
                {
                    Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Execution completed successfully.");
                    Result.Message = "Execution completed successfully.";
                }
                Result.Status = EventStatus.Completed;
            }
            catch (Exception exc)
            {
                Result.Status = EventStatus.NoRun;
                Result.Message = "Error occured. " + exc.Message;
                Config.HistoryManager.History.Log(exc);
            }
        }
        public override void Load(string scheduleName, XmlNode xNode)
        {
            if (xNode == null)
                return;
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loading command event.");

            base.Load(scheduleName, xNode);


            if (xNode.Attributes[CommandEvent.Event.Command] != null)
                _command = xNode.Attributes[CommandEvent.Event.Command].Value;

            if (xNode.Attributes[CommandEvent.Event.WorkingDirectory] != null)
                _workingDirectory = xNode.Attributes[CommandEvent.Event.WorkingDirectory].Value;

            _arguments = xNode.InnerText;
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Loaded command event.");
        }
        public override XmlNode GetNode(XmlDocument doc)
        {
            XmlNode node = base.GetNode(doc);

            XmlAttribute attr = doc.CreateAttribute(Event.Command);
            attr.Value = Command;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(Event.WorkingDirectory);
            attr.Value = WorkingDirectory;
            node.Attributes.Append(attr);

            node.InnerText = Arguments;

            return node;
        }

        public override Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> param = base.GetParameters();
            param.Add(Event.Command, Command);
            param.Add(Event.WorkingDirectory, WorkingDirectory);
            param.Add(Event.Arguments, Arguments);
            return param;
        }
        public override void SetParameters(Dictionary<string, string> param)
        {
            if (param.ContainsKey(Event.Command))
            {
                _command = param[Event.Command];
            }
            if (param.ContainsKey(Event.Arguments))
            {
                _arguments = param[Event.Arguments];
            }
            if (param.ContainsKey(Event.Command))
            {
                _workingDirectory = param[Event.WorkingDirectory];
            }
            base.SetParameters(param);
        }
    }
}
