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
using Vibz.IO;
using System.Xml.Serialization;
using Vibz.Contract.Attribute;
using Vibz.Contract;
using Vibz.Contract.Data;
namespace Vibz.IO.TextFile.Instruction.Fetch
{
    [TypeInfo(Author="Vibzworld", Details = "Writes/Overrites the text content in the given text file.",
        Version = "2.0")]
    public class Read : FetchBase
    {
        IData _content;
        public Read() {
            Type = InstructionType.Fetch;
        }
        public Read(string filepath)
        {
            FilePath = filepath;
            Type = InstructionType.Fetch;
        }
        public override IData Fetch()
        {
            IOBase iofile = IOFactory.GetIOFile(vList.Evaluate(FilePath));
            _content = iofile.Read();
            return _content;
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Read '" + _content.GetValue() + "' from '" + FilePath + "'.");
            }
        }
    }
}
