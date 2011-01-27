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
using Vibz.Interpreter.Script;
using Vibz.Contract;
using Vibz.Interpreter.Script.FlowController;
using System.Reflection;
using Vibz.Contract.Log;
using Vibz.Contract.Macro;
namespace Vibz.Interpreter
{
    public class Executer : ITask
    {
        TaskState _state = TaskState.NotStarted;
        public TaskState State
        {
            get { return _state; }
        }
        public TaskType Type
        {
            get { return TaskType.Execute; }
        }
        string _message = "";
        public string Message { get { return _message; } }
        const string FlowContinues = " Script will continue to flow as mentioned.";
        Configuration.ConfigManager _config;
        FileParser _fParser;
        public Executer()
        {
            _state = TaskState.NotStarted;
        }
        public void Process_Init()
        {
            Vibz.Interpreter.Data.DataProcessor.Reset();
            Vibz.Interpreter.Configuration.InstructionManager.Reset();
            Vibz.Interpreter.Configuration.ReportManager.Reset();
            _state = TaskState.Processing;
        }
        public void Process(object param)
        {
            try
            {
                Process_Init();
                string filePath = ((object[])param).GetValue(0).ToString();
                
                int waitInterval = 0;
                int.TryParse(((object[])param).GetValue(1).ToString(), out waitInterval);

                if (!System.IO.File.Exists(filePath))
                    throw new Exception("Invalid path '" + filePath + "'.");
                _fParser = new FileParser(filePath);
                Version scriptVersion = new Version(_fParser.Version);
                Version frameworkVersion = new Version(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());

                if (scriptVersion.CompareTo(Plugin.PluginManager.SupportedVersion) == -1)
                    throw new Exception("The current automation framework does not support the version of VACS (compiled script). \r\n This is because the script is generated using lower version of framework.");

                if (frameworkVersion.CompareTo(scriptVersion) == -1)
                    LogQueue.Instance.Enqueue(new LogQueueElement("This script is generated using higher version of framework. It will continue to execute. In case it fails, you may need to upgrade to higher version of the tool.", LogSeverity.Warn));

                System.IO.FileInfo fi = new System.IO.FileInfo(filePath);
                CommonMacroVariables.Set("__currentpath", fi.DirectoryName);
                CommonMacroVariables.Set("__currentfile", fi.FullName);
                CommonMacroVariables.Set("__basepath", _fParser.BasePath);
                _fParser.ReportPath = Vibz.Helper.IO.CreateFolderPath(_fParser.ReportPath, Vibz.Helper.IOType.Folder);
                _config = Configuration.ConfigManager.LoadConfig(_fParser);

                if (!InstructionValueMap.Instance.ContainsKey("reportpath"))
                    InstructionValueMap.Instance.Add("reportpath", _fParser.ReportPath);
                else
                    InstructionValueMap.Instance["reportpath"] = _fParser.ReportPath;

                foreach (Function function in _fParser.FunctionList)
                {
                    LogElement fncLog = new LogElement("Executing function '" + function.Name + "'.");
                    try
                    {
                        function.Execute(function.DataSet, waitInterval);
                        fncLog.Add(function.Name + ": Executed.", LogSeverity.Info);
                        fncLog.Add(function.InfoEnd);
                    }
                    catch (Exception exc)
                    {
                        fncLog.Add("Testcase '" + function.Name + "' fail. " + Vibz.Contract.Log.LogException.GetFullException(exc), LogSeverity.Error);
                        fncLog.Add(ExecuteGlobalFunction("OnTestcaseFail", "Executing cleanup on Testcase fail."));
                    }
                    fncLog.Add(ExecuteGlobalFunction("OnTestcaseComplete", "Executing cleanup on Testcase complete."));
                    foreach (IReport report in Configuration.ReportManager.ReportList)
                    {
                        try
                        {
                            if (report.Status == ReportStatus.Active)
                                report.Export(fncLog);
                        }
                        catch (Exception exc)
                        {
                            LogQueue.Instance.Enqueue(new LogQueueElement("Unable to export function report. Processor: " + report.GetType().FullName + ". " + LogException.GetFullException(exc), LogSeverity.Trace));
                        }
                    }
                }
                _state = TaskState.Complete;
                _message = "Execution completed ";
            }
            catch (Exception exc)
            {
                _state = TaskState.Error;
                _message = "Execution failed. " + exc.Message;
            }
            finally
            {
                // Configuration.ConfigManager.UnLoadConfig();
            }
        }
        LogElement ExecuteGlobalFunction(string functionName, string initMessage)
        {
            if (_fParser.Global == null)
                return null;
            Function fFail = _fParser.Global.GetFunction(functionName);
            if (fFail == null)
                return null;
            LogElement glbLog = new LogElement(initMessage);
            if (fFail.Body.Instructions.Count > 0)
            {
                try
                {
                    fFail.Body.Execute(fFail.DataSet);
                    glbLog.Add(fFail.Body.InfoEnd);
                }
                catch (Exception iExc)
                {
                    glbLog.Add("Cleanup failed. " + iExc, LogSeverity.Error);
                }
            }
            return glbLog;
        }
    }
}
