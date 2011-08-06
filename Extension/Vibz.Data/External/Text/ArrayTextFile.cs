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
                {
                    _value = new TextArray();
                }
                return _value;
            }
        }
        public override void LoadData(ParameterSet param)
        {
            _tFile = new TextFile();
            _tFile.Init(param);
            Value.Parameters = _tFile.Parameters;

            if (param.GetParameter(SeperationCharacter) != null)
                _seperationChar = param.GetParameter(SeperationCharacter).Value;

            Value.Value = _tFile.Content.Split(new string[] { _seperationChar }, StringSplitOptions.RemoveEmptyEntries);
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
