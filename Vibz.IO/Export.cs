using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Vibz.Contract;
using Vibz.Contract.Data;
namespace Vibz.IO
{
    [TypeInfo(Details = "Exports the data into given file.",
        Version = "2.0")]
    public class Export : InstructionBase, IAction
    {
        [XmlAttribute("source")]
        public string Source;
        [XmlAttribute("destination")]
        public string Destination;
        [XmlAttribute("mode")]
        public string ExportMode = "insert";
        public Export()
        {
            Type = InstructionType.Action;
        }
        public Export(string source, string destination, string exportMode)
            : base()
        {
            Source = source;
            Destination = destination;
            ExportMode = exportMode;
            Type = InstructionType.Action;
        }
        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Variable var = null;
            if (Source.StartsWith("@"))
            {
                string key = Source.Substring(1);
                if (vList.DataList.ContainsData(key))
                    var = vList.DataList.Get(key);
            }
            if(var==null)
                var = new Variable("__data__", new Text(vList.Evaluate(Source)));

            Variable data = null;
            if (Destination.StartsWith("@"))
            {
                string key = Destination.Substring(1);
                if (vList.DataList.ContainsData(key))
                    data = vList.DataList.Get(key);
            }
            if (data == null || data.Source == Vibz.Contract.Data.Source.SourceType.Internal.ToString())
                throw new Exception("Destination must be an external file.");

            vList.DataProcessor.Export(var, data, (ExportMode.ToLower() == DataExportMode.Insert.ToString().ToLower() ? DataExportMode.Insert : DataExportMode.Update));
        }
    }
}
