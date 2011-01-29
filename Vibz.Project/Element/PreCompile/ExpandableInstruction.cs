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
using System.Xml;
using Vibz.Contract.Data;
using Vibz.Contract.Attribute;
namespace Vibz.Solution.Element.PreCompile
{
    public abstract class ExpandableInstruction
    {
        public abstract void ExpandInto(XmlNode xnInst, DataHandler idList, ref XmlNode xnTemp);
        static List<FunctionTypeInfo> _list;
        public static List<FunctionTypeInfo> List
        {
            get 
            {
                if (_list == null)
                {
                    _list = new List<FunctionTypeInfo>();
                    _list.Add(Call.Info);
                }
                return _list;
            }
        }
    }
}
