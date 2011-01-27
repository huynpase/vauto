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
    public class ScalarTextFile : ExternalData<Vibz.Contract.Data.Text>
    {
        TextFile _tFile;

        public override string Source
        { get { return Vibz.Contract.Data.Source.SourceType.Text.ToString(); } }
        Vibz.Contract.Data.Text _value;
        public override Vibz.Contract.Data.Text Value
        {
            get
            {
                if (_value == null)
                    _value = new Vibz.Contract.Data.Text();
                return _value;
            }
        }
        public override void Load(ParameterSet param)
        {
            _tFile = new TextFile();
            _tFile.Init(param);
            _value.Value = _tFile.Content;
        }
        public override void Export(ParameterSet param, Vibz.Contract.Data.Text data, DataExportMode mode)
        {
            _tFile = new TextFile();
            _tFile.Init(param);
            _tFile.Export(data.Value, mode);
        }
    }
}
