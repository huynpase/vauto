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
using Vibz.Contract;
using Vibz.Contract.Attribute;

namespace Vibz.IO.TextFile.Instruction.Action
{
    [TypeInfo(Author="Vibzworld", Details = "Appends the text content in the given text file.",
       Version = "2.0")]
    public class Append : ActionBase
    {
        public Append() {
            Type = InstructionType.Action;
        }
        public Append(string filepath, string contentName)
        {
            FilePath = filepath;
            Content = contentName;
            Type = InstructionType.Action;
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            IOBase iofile = IOFactory.GetIOFile(FilePath);
            operation = new delOpern(iofile.Append);
            base.Execute(vList);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Appending '" + Content + "' into '" + FilePath + "'.");
            }
        }
    }
}
