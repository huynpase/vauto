using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Vibz.IO.TextFile
{
    public class TextFile : IOBase
    {
        public TextFile(string filePath)
        {
            FilePath = filePath;
        }
        public override void Init(Dictionary<string, object> param)
        {
            if (param.ContainsKey("filepath"))
                throw new Exception("'filepath' is missing.");
            string filePath = param["filepath"].ToString();
            if (!System.IO.File.Exists(filePath))
                throw new Exception("Invalid File Path.");
            else
                FilePath = filePath;
        }
        public override void Write(object text)
        {
            System.IO.File.WriteAllText(FilePath, text.ToString());
        }
        public override void Append(object text)
        {
            System.IO.File.AppendAllText(FilePath, text.ToString());
        }
    }
}
