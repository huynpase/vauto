using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract.Data;
using Vibz.Contract.Data.Source;
namespace Vibz.Data.External.Text
{
    public class ArrayTextFile : ExternalData<TextArray>
    {
        const string SeperationCharacter = "seperationchar";
        string _seperationChar = "\n";
        TextFile _tFile;

        public override string Source
        { get { return Vibz.Contract.Data.Source.SourceType.Text.ToString(); } }
        TextArray _value;
        public override TextArray Value
        {
            get
            {
                if (_value == null)
                    _value = new TextArray();
                return _value;
            }
        }
        public override void Load(ParameterSet param)
        {
            _tFile = new TextFile();
            _tFile.Init(param);

            if (param.GetParameter(SeperationCharacter) != null)
                _seperationChar = param.GetParameter(SeperationCharacter).Value;

            _value.Value = _tFile.Content.Split(new string[] { _seperationChar }, StringSplitOptions.RemoveEmptyEntries);
        }
        public override void Export(ParameterSet param, TextArray data, DataExportMode mode)
        {
            _tFile = new TextFile();
            _tFile.Init(param);

            if (param.GetParameter(SeperationCharacter) != null)
                _seperationChar = param.GetParameter(SeperationCharacter).Value;

            _tFile.Export(data.Value, mode);
        }
    }
}
