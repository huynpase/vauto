using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract.Data;
using Vibz.Contract.Data.Source;
namespace Vibz.Data.External.Text
{
    public class DataTableTextFile : ExternalData<DataTable>
    {
        const string RowSeperationCharacter = "rowseperationchar";
        const string ColSeperationCharacter = "colseperationchar";
        string _rowSeperationChar = "\n";
        string _colSeperationChar = "\t";
        TextFile _tFile;

        public override string Source
        { get { return Vibz.Contract.Data.Source.SourceType.Text.ToString(); } }
        DataTable _value;
        public override DataTable Value
        {
            get
            {
                if (_value == null)
                    _value = new DataTable();
                return _value;
            }
        }
        public override void Load(ParameterSet param)
        {
            _tFile = new TextFile();
            _tFile.Init(param);

            if (param.GetParameter(RowSeperationCharacter) != null)
                _rowSeperationChar = param.GetParameter(RowSeperationCharacter).Value;
            if (param.GetParameter(ColSeperationCharacter) != null)
                _colSeperationChar = param.GetParameter(ColSeperationCharacter).Value;

            string[] rowDataList = _tFile.Content.Split(new string[] { _rowSeperationChar }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string rowData in rowDataList)
            {
                string[] rowValues = rowData.Split(new string[] { _colSeperationChar }, StringSplitOptions.None);
                _value.AddRow(rowValues);
            }
        }
        public override void Export(ParameterSet param, DataTable data, DataExportMode mode)
        {
            _tFile = new TextFile();
            _tFile.Init(param);
            
            if (param.GetParameter(RowSeperationCharacter) != null)
                _rowSeperationChar = param.GetParameter(RowSeperationCharacter).Value;
            if (param.GetParameter(ColSeperationCharacter) != null)
                _colSeperationChar = param.GetParameter(ColSeperationCharacter).Value;

            string content = "";
            foreach (System.Data.DataRow row in data.Rows)
            {
                foreach (object value in row.ItemArray)
                {
                    content += value + _colSeperationChar;                
                }
                if (content.Trim() != "")
                    content = content.Remove(content.LastIndexOf(_colSeperationChar));
                content += _rowSeperationChar;
            }
            _tFile.Export(content, mode);
        }
    }
}
