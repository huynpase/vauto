using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Vibz.Interpreter.Script;
using Vibz.Interpreter.Script.FlowController;
using Vibz.Security;
namespace Vibz.Interpreter
{
    public class FileParser
    {
        Section _file;
        public FileParser(string filePath)
        {
            _file = Deserialize(filePath);
        }
        public string Version
        {
            get {
                return _file.Version;
            }
        }
        public Function GetFunction(string name)
        {
            return _file.GetFunction(name);
        }
        public Function[] FunctionList
        {
            get
            {
                return _file.Functions;
            }
        }
        public FunctionSet Global
        {
            get
            {
                return _file.Global;
            }
        }
        public XmlNode ConfigSection
        {
            get
            {
                return _file.ConfigSection;
            }
        }
        public string BasePath
        {
            get
            {
                return _file.BasePath;
            }
        }
        public string ReportPath
        {
            get
            {
                return _file.ReportPath;
            }
            set { _file.ReportPath = value; }
        }
        public static void Save(Section file, string fileName)
        {
            Serialize(file, fileName);
        }
        private static void Serialize(Section file, string fileName)
        {
            TextWriter writer = new StreamWriter(fileName);
            XmlSerializer serializer = new XmlSerializer(typeof(Section));
            serializer.Serialize(writer, file);
            writer.Close();
        }

        private static Section Deserialize(string fileName)
        {
            if (!System.IO.File.Exists(fileName))
                throw new Exception("Invalid file path.");
            try
            {
                TextReader reader = new StreamReader(fileName, true);

                string encodedCode = reader.ReadToEnd();
                string decodedCode = "";
                try
                {
                    decodedCode = Cryptograph.Decrypt(encodedCode, ((int)EncriptionKey.Vibz2).ToString());
                }
                catch (Exception exc)
                {
                    decodedCode = encodedCode;
                }
                byte[] codeByte = Encoding.ASCII.GetBytes(decodedCode);
                MemoryStream stream = new MemoryStream(codeByte);
                XmlSerializer serializer = new XmlSerializer(typeof(Section));
                Section file = (Section)serializer.Deserialize(stream);

                reader.Close();
                return file;                

            }
            catch (Exception exc)
            {
                throw new Exception("Invalid file format. " + exc.Message);                
            }
        }
        public List<string> IncludedAssemblies
        {
            get
            {
                List<string> retValue = new List<string>();
                foreach (Include inc in _file.IncludeList)
                {
                    retValue.Add(inc.Path.ToLower());
                }
                return retValue;
            }
        }
    }
}
