using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz
{
    public enum TaskState { NotStarted, Processing, Complete, Error }
    public enum TaskType { Compile, Execute }
    public interface ITask
    {
        string Message { get; }
        TaskState State { get; }
        TaskType Type { get; }
        void Process(object param);
    }
}
