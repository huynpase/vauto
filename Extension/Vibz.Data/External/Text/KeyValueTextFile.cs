using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract.Data;
using Vibz.Contract.Data.Source;

namespace Vibz.Data.External.Text
{
    public class KeyValueTextFile : ExternalData<KeyValueSet>
    {
        const string ListSeperationCharacter = "listseperationchar";
        const string ItemSeperationCharacter = "itemseperationchar";
        string _listSeperationChar = "\n";
        string _itemSeperationChar = "\t";
        TextFile _tFile;

        public override string Source
        { get { return Vibz.Contract.Data.Source.SourceType.Text.ToString(); } }
        KeyValueSet _value;
        public override KeyValueSet Value
        {
            get {
                if (_value == null)
                    _value = new KeyValueSet();
                return _value;
            }
        }
        public override void Load(ParameterSet param)
        {
            _tFile = new TextFile();
            _tFile.Init(param);

            if (param.GetParameter(ListSeperationCharacter) != null)
                _listSeperationChar = param.GetParameter(ListSeperationCharacter).Value;
            if (param.GetParameter(ItemSeperationCharacter) != null)
                _itemSeperationChar = param.GetParameter(ItemSeperationCharacter).Value;

            string[] dataList = _tFile.Content.Split(new string[] { _listSeperationChar }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string data in dataList)
            {
                string[] keyValue = data.Split(new string[] { _itemSeperationChar }, 2, StringSplitOptions.None);
                if (keyValue.Length == 0)
                    continue;
                if (keyValue.Length == 1)
                {
                    if (!_value.Contains(keyValue.GetValue(0).ToString()))
                        _value.Add(keyValue.GetValue(0).ToString(), "");
                    else
                        _value[keyValue.GetValue(0).ToString()] = "";
                    continue;
                }
                if (!_value.Contains(keyValue.GetValue(0).ToString()))
                    _value.Add(keyValue.GetValue(0).ToString(), keyValue.GetValue(1).ToString());
                else
                    _value[keyValue.GetValue(0).ToString()] = keyValue.GetValue(1).ToString();
            }
        }
        public override void Export(ParameterSet param, KeyValueSet data, DataExportMode mode)
        {
            _tFile = new TextFile();
            _tFile.Init(param);

            if (param.GetParameter(ListSeperationCharacter) != null)
                _listSeperationChar = param.GetParameter(ListSeperationCharacter).Value;
            if (param.GetParameter(ItemSeperationCharacter) != null)
                _itemSeperationChar = param.GetParameter(ItemSeperationCharacter).Value;
            
            string content="";
            foreach (string key in data.Keys)
            {
                content += key + _itemSeperationChar + data[key] + _listSeperationChar;
            }
            _tFile.Export(content, mode);
        }
    }
}
