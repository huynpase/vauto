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
using System.IO;
using Vibz.Contract.Data;

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
        public override IData Read()
        {
            return new Vibz.Contract.Data.Text(System.IO.File.ReadAllText(FilePath));
        }
        public override void Append(object text)
        {
            System.IO.File.AppendAllText(FilePath, text.ToString());
        }
    }
}
