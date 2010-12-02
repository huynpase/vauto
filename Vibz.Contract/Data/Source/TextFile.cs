using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Vibz.Contract.Data.Source
{
    public class TextFile : ISource
    {
        const string Path = "path";
        string _filePath;
        public string FilePath
        {
            get
            {
                return _filePath;
            }
        }
        public void Init(ParameterSet param)
        {
            if (param.Count < 1)
                throw new Exception("Less parameters to load a text file.");

            if (param.GetParameter(Path) == null)
                throw new Exception("Parameter '" + TextFile.Path + "' is not provided.");

            _filePath = param.GetParameter(Path).Value;

            if (!File.Exists(_filePath))
            {
                FileStream fs = File.Create(_filePath);
                fs.Close();
            }
        }
        public virtual string Content 
        {
            get {
                return File.ReadAllText(_filePath);
            }
        }
        public virtual string[] Lines
        {
            get
            {
                return File.ReadAllLines(_filePath);
            }
        }
        public virtual void Export(string data, DataExportMode mode)
        {
            switch (mode.ToString().ToLower())
            { 
                case "insert":
                    File.AppendAllText(_filePath, "\r\n" + data);
                    break;
                case "update":
                    File.WriteAllText(_filePath, "\r\n" + data);
                    break;
            }
        }
        public virtual void Export(string[] data, DataExportMode mode)
        {
            switch (mode.ToString().ToLower())
            {
                case "insert":
                    foreach (string str in data)
                    {
                        File.AppendAllText(_filePath, "\r\n" + str);
                    }
                    break;
                case "update":
                    foreach (string str in data)
                    {
                        File.WriteAllText(_filePath, "\r\n" + str);
                    }
                    break;
            }
        }
    }
}
