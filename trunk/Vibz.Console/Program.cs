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
using System.IO;
using System.Diagnostics;
using Vibz.Interpreter;
using Vibz.Contract.Log;
using System.Threading;
using Vibz.Solution.Element;
using Vibz.Solution;

namespace Vibz.Console
{
    class Program
    {
        static Timer _timer = null;
        static bool _firstTimeExecution = true;
        static object _taskLock = new object();
        delegate void TaskDelegate(object param);
        static ITask _task;
        class Abbreviation
        {
            public const string FilePath = "f";
            public const string Compile = "c";
            public const string Execute = "r";
            public const string Schedule = "s";
            public const string CompileAndExecute = "cr";
            public const string CompileOutput = "co";
            public const string ProjectPath = "prj";
        }

        public class State
        {
            public int count = 0;
        }
        static void Main(string[] args)
        {
            bool doRun = false;
            bool doBuild = false;
            try
            {
                if (args.Length == 0)
                {
                    if (_firstTimeExecution)
                        Process.Start("cmd");
                    return;
                }
                if (args.Length == 1)
                {
                    switch (args.GetValue(0).ToString().ToLower())
                    {
                        case "help":
                        case "?":
                        case "/":
                            ShowWelcome();
                            ShowHelp();
                            return;
                        default:
                            break;
                    }
                }
                string path = "";
                Arguments CommandLine = new Arguments(args);

                if (CommandLine[Abbreviation.FilePath] != null)
                {
                    path = CommandLine[Abbreviation.FilePath];
                    if (!File.Exists(path))
                    {
                        throw new Exception("Invalid path. [" + path + "]");
                    }
                }
                else
                {
                    throw new Exception("Path is not defined !");
                }
                if (CommandLine[Abbreviation.Schedule] != null)
                {
                    if (!path.ToLower().EndsWith("." + Vibz.FileType.CompiledScropt))
                        throw new Exception("File of type [*." + Vibz.FileType.CompiledScropt + "] can only be scheduled.");

                    Process p = new Process();
                    p.StartInfo.FileName = "Vibz.Scheduler.exe";
                    p.StartInfo.Arguments = "\"" + path + "\"";

                    p.StartInfo.WorkingDirectory = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName;

                    if (!p.Start())
                        throw new Exception("Error occured while opening scheduler. " + p.StandardError.ReadToEnd() + ". Try scheduling it from Programs menu.");

                    return;
                }
                if (CommandLine[Abbreviation.Compile] != null)
                {
                    if (!path.ToLower().EndsWith("." + Vibz.FileType.TestSuite))
                        throw new Exception("File of type [*." + Vibz.FileType.TestSuite + "] can only be compiled.");
                    doBuild = true;
                }
                if (CommandLine[Abbreviation.CompileAndExecute] != null)
                {
                    if (!path.ToLower().EndsWith("." + Vibz.FileType.TestSuite))
                        throw new Exception("File of type [*." + Vibz.FileType.TestSuite + "] can only be compiled and executed.");
                    doBuild = true;
                    doRun = true;
                }

                if (doBuild == false || CommandLine[Abbreviation.Execute] != null)
                {
                    if (doBuild == false && !path.ToLower().EndsWith("." + Vibz.FileType.CompiledScropt))
                        throw new Exception("File of type [*." + Vibz.FileType.CompiledScropt + "] can only be executed.");
                    doRun = true;
                }

                _timer = new Timer(new TimerCallback(UpdateStatus), null, 0, 500);

                if (doBuild)
                {
                    if (CommandLine[Abbreviation.ProjectPath] == null)
                        throw new Exception("Project path is required for compilation.");
                    System.Console.WriteLine("Suite File: " + path + ".");

                    string prjPath = CommandLine[Abbreviation.ProjectPath];
                    Project prj = LoadProject(prjPath);

                    SuiteElement element = prj.CreateSuite(new FileInfo(path));
                    element.Load();

                    _task = new Compiler();

                    Thread taskThread = new Thread(new ParameterizedThreadStart(ExecuteInThread));
                    TaskDelegate tDelegate = new TaskDelegate(_task.Process);

                    if (!Directory.Exists(prj.BuildLocation))
                        Vibz.Helper.IO.CreateFolderPath(new DirectoryInfo(prj.BuildLocation));
                    string buildFile = prj.BuildLocation + "/" + element.Name + "." + Vibz.FileType.CompiledScropt;
                    object arg = new object[] { element, buildFile };

                    taskThread.SetApartmentState(ApartmentState.STA);
                    taskThread.Start(new object[] { tDelegate, arg, "Compilation" });


                    path = buildFile;
                }

                if (doRun)
                {
                    System.Console.WriteLine("Build Path: " + path + ".");

                    _task = new Executer();
                    Thread taskThread = new Thread(new ParameterizedThreadStart(ExecuteInThread));
                    TaskDelegate tDelegate = new TaskDelegate(_task.Process);

                    object arg = new object[] { path };

                    taskThread.SetApartmentState(ApartmentState.STA);
                    taskThread.Start(new object[] { tDelegate, arg, "Execution" });

                    taskThread.Join();
                }
            }
            catch (Exception exc)
            {
                System.Console.WriteLine("Process failed. \r\n\tError: " + exc.Message);
                System.IO.File.AppendAllText(Vibz.Helper.IO.CreateFolderPath(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "/logs/cmd.log", Vibz.Helper.IOType.File), DateTime.Now.ToString() + ": " + exc.Message + "\r\n" + exc.StackTrace);
                // System.Console.Read();
            }
            finally
            {
                _firstTimeExecution = false;
            }
        }
        static void ExecuteInThread(object param)
        {
            try
            {
                System.Threading.Monitor.Enter(_taskLock);
                TaskDelegate del = (TaskDelegate)((object[])param).GetValue(0);
                object arg = ((object[])param).GetValue(1);
                string process = ((object[])param).GetValue(2).ToString();
                System.Console.WriteLine(" " + process + " started.");
                del(arg);
                UpdateStatus(null);
                System.Console.WriteLine(" " + process + " completed.");
                System.Threading.Monitor.Exit(_taskLock);
            }
            catch (Exception exc)
            {
                System.Console.WriteLine("  Process failed in thread. \r\n\tError: " + exc.Message);
            }
            finally
            {
                System.Console.WriteLine(_task.State.ToString() + ": " + _task.Message);
            }
        }
        static Project LoadProject(string path)
        {
            System.IO.FileInfo fInfo = new System.IO.FileInfo(path);
            return Vibz.Solution.Loader.Load(path);
        }
        static void UpdateStatus(object state)
        {
            try
            {
                while (LogQueue.Instance.Count > 0)
                {
                    LogQueueElement ele = LogQueue.Instance.Dequeue();
                    System.Console.WriteLine("  " + ele.Severity.ToString() + ": " + ele.Message);
                    switch (ele.Severity)
                    {
                        case LogSeverity.Trace:
                        case LogSeverity.Warn:
                            break;
                        case LogSeverity.Error:
                            System.Console.WriteLine("   Done with error. Click here to see error message.");
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception exc)
            {
                System.Console.WriteLine("Process failed in status update. \r\n\tError: " + exc.Message);
            }
        } 
        static void ShowHelp()
        {
            System.Console.WriteLine("Syntax:");
            System.Console.WriteLine("  vauto [-{c|r|cr}] -f='compiled_script_path' [-prj='project_path']");
            System.Console.WriteLine(" ");
            System.Console.WriteLine("     path: Location of the compiled script file.");
            //System.Console.WriteLine("     rpt: Location for Report file to be generated.");
            //System.Console.WriteLine("     url: Browser Url (Startup url or may be the Login Url).");
            //System.Console.WriteLine("     host: Host Url.");
            //System.Console.WriteLine("     watch: Watch interval for the Blocker.");
        }
        static void ShowWelcome()
        {
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            System.Console.WriteLine("***************************************************");
            System.Console.WriteLine("*                                                 *");
            System.Console.WriteLine("*       Welcome to Vibz Automation Framework      *");
            System.Console.WriteLine("*                                                 *");
            System.Console.WriteLine("***************************************************");
            System.Console.WriteLine("Version: " + version);
        }
    }
}
