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
using Vibz.Contract.Log;
namespace Vibz.Contract
{
    public enum ReportStatus { Active, Inactive }
    public interface IReport
    {
        string ReportPath { get; set; }
        string ReportName { get; set; }
        ReportStatus Status { get; set; }
        Dictionary<string, string> Configuration { get; set; }
        void Init(Dictionary<string, string> param);
        void Export(LogElement log);


    }
}
