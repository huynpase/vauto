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
using System.Reflection;
using Vibz.Interpreter;
using System.Windows.Forms;

namespace Vibz.Studio
{
    public class Spider
    {
        static object _objEx = null;

        public static Executer GetExecuter(object[] param)
        {
            //Type type = null;
            //if (_objEx == null)
            //{
            //    string assembly = System.Configuration.ConfigurationSettings.AppSettings["ExtractorAssembly"];
            //    string cls = System.Configuration.ConfigurationSettings.AppSettings["ExtractorClass"];
            //    type = GetAssembly(assembly).GetType(cls, true, true);
            //    _objEx = Activator.CreateInstance(type);
            //}
            //_objEx.GetType().InvokeMember("Init", BindingFlags.Default | BindingFlags.InvokeMethod, null, _objEx, param);
            //return (IBrowser)_objEx;
            return null;
        }
        private static Assembly GetAssembly(string assemblyPath)
        {
            try
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(Assembly.GetExecutingAssembly().Location);
                string assemblyFullPath = fi.Directory.FullName + "/" + assemblyPath;
                if (System.IO.File.Exists(assemblyFullPath))
                {
                    AssemblyName assemblyName = AssemblyName.GetAssemblyName(assemblyFullPath);
                    return Assembly.Load(assemblyName);
                }
                else
                    throw new Exception("Invalid assembly path.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, new Exception("Error occured at Engine.LoadAssembly"));
            }
        }
    }
}
