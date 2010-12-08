using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Vibz.Solution.Element;
using System.IO;
using System.Xml;
using Vibz.Contract.Log;
using Vibz.Security;
namespace Vibz.Solution
{
    public class Compiler : ITask
    {
        bool _encode = true;
        TaskState _state = TaskState.NotStarted;
        public TaskState State
        {
            get { return _state; }
        }
        public TaskType Type
        {
            get { return TaskType.Compile; }
        }
        string _message = "";
        public string Message { get { return _message; } }
        public Compiler()
        {
            _state = TaskState.NotStarted;
        }
        public Compiler(bool encode)
        {
            _state = TaskState.NotStarted;
            _encode = encode;
        }
        public void Process(object param)
        {
            _state = TaskState.Processing;
            IElement element = (IElement)((object[])param).GetValue(0);
            string destinationPath = ((object[])param).GetValue(1).ToString();
            Compile(element, destinationPath);
        }
        void Compile(IElement element, string destinationPath)
        {
            try
            {
                string vacsCode = GetCompiledText(element);
                System.IO.File.WriteAllText(destinationPath, (_encode ? Cryptograph.Encrypt(vacsCode, ((int)EncriptionKey.Vibz2).ToString()) : vacsCode));
                _state = TaskState.Complete;
                _message = "Compilation ";
            }
            catch (Exception exc)
            {
                _state = TaskState.Error;
                _message = "Compilation Error.\r\n" + exc.Message;
            }
        }
        string GetCompiledText(IElement element)
        {
            string code = "";
            string body = element.GetCompiledText();
            switch (element.Type)
            {
                case ElementType.Suite:
                    code = "<section version=\"" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + "\">";
                    foreach (string include in ((SuiteFile)element).Includes)
                        code += "<include ref=\"" + include + "\" />";
                    code += "<basepath><![CDATA[" + element.OwnerProject.Path + "]]></basepath>";
                    code += "<reportpath><![CDATA[" + element.OwnerProject.ReportDirectory + "]]></reportpath>";
                    code += "<global>";
                    ApplicationGlobalFile global = element.OwnerProject.AppGlobal;
                    if (global != null)
                    {
                        foreach (Function fnc in global.Functions)
                            code += fnc.GetCompiledText();
                    }
                    code += "</global>";
                    code += "<app>";
                    code += element.OwnerProject.AppConfig.ToString();
                    code += "</app>";
                    code += body;
                    code += "</section>";
                    break;
            }
            return IndentXMLString(code);
        }
        string IndentXMLString(string xml)
        {
            string outXml = string.Empty;
            MemoryStream ms = new MemoryStream();
            // Create a XMLTextWriter that will send its output to a memory stream (file)
            XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.Unicode);
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.LoadXml(xml);
                xtw.Formatting = Formatting.Indented;
                doc.WriteContentTo(xtw);
                xtw.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(ms);
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while indenting script. " + ex.Message);
            }
        }
        
    }
}
