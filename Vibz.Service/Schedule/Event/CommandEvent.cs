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
        string _workingDirectory = Environment.CurrentDirectory;
        public virtual string WorkingDirectory { get { return _workingDirectory; } set { _workingDirectory = value; } }

        string _command = Environment.ExpandEnvironmentVariables("%comspec%");
        public virtual string Command { get { return _command; } set { _command = value; } }

        string _arguments;
        public virtual string Arguments { get { return _arguments; } set { _arguments = value; } }

        public override void InvokeTask()
        {
            Process p = new Process();
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Command: [" + Command + "]");
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "Arguments: [" + Arguments + "]");
            Config.HistoryManager.History.Log(Config.LogLevel.Debug, "WorkingDirectory: [" + WorkingDirectory + "]");
            p.StartInfo.FileName = Command;
            p.StartInfo.Arguments = Arguments;

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WorkingDirectory = WorkingDirectory;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            if (!p.Start())
            {
                Result.Status = EventStatus.NoRun;
                Result.Message = "Command event could not be started. " + p.StandardError.ReadToEnd();
            }
            
            p.WaitForExit();
            if (p.ExitCode != 0)
            {
                Result.Message = "Error occured. Process terminated. \r\n\t" + p.StandardError.ReadToEnd();            
            }
            Result.Status = EventStatus.Completed;
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
