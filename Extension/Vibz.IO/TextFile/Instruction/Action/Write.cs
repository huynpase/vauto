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
namespace Vibz.IO.TextFile.Instruction.Action
{
    [TypeInfo(Author="Vibzworld", Details = "Writes/Overrites the text content in the given text file.",
        Version = "2.0")]
    public class Write : ActionBase
    {
        public Write() {
            Type = InstructionType.Action;
        }
        public Write(string filepath, string content)
        {
            FilePath = filepath;
            Content = content;
            Type = InstructionType.Action;
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            IOBase iofile = IOFactory.GetIOFile(FilePath);
            operation = new delOpern(iofile.Write);
            base.Execute(vList);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Wrote '" + Content + "' into '" + FilePath + "'.");
            }
        }
    }
}
