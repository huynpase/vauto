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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;
using Vibz.Interpreter.Script;
using Vibz.Contract.Macro;
using Vibz.Interpreter.Plugin;
using Vibz.Contract;
using Vibz.Contract.Log;
namespace Vibz.Interpreter.Configuration
{
    public class ConfigManager
    {
        
        static ConfigManager _instance = null;
        static object _padLock = new object();
        FileParser _fParser;
        ConfigManager(FileParser fParser)
        {
            _fParser = fParser;
            InstructionManager.LoadInternalClasses(_fParser);
        }
        
        public static ConfigManager LoadConfig(FileParser fParser)
        {
            _instance = new ConfigManager(fParser);
            return _instance;
        }

        public static ConfigManager Instance
        {
            get {
                if (_instance == null)
                    throw new Exception("Configuration handler is not yet initialized.");
                return _instance;
            }
        }

        internal FileParser ExecutionUnit
        {
            get {
                return _fParser;
            }
        }

        static byte[] GetAssemblyStream(string filename)
        {
            FileStream fin = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] bin = new byte[16384];
            long rdlen = 0;
            long total = fin.Length;
            int len;
            MemoryStream memStream = new MemoryStream((int)total);
            rdlen = 0;
            while (rdlen < total)
            {
                len = fin.Read(bin, 0, 16384);
                memStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }
            // done with input file
            fin.Close();
            return memStream.ToArray();
            //return Assembly.Load(memStream.ToArray());
        }

        public static Vibz.Interpreter.Plugin.PluginAssembly LoadTypes(string assembly, Type[] iTypeList)
        {
            Assembly asm = Assembly.LoadFile(Vibz.Reflection.Runtime.GetAbsolutePath(assembly));
            return LoadTypes(asm, iTypeList);
        }
        public static Vibz.Interpreter.Plugin.PluginAssembly LoadTypes(Assembly asm, Type[] iTypeList)
        {
            try
            {
                System.Type[] types = asm.GetTypes();
                IEnumerator classes = types.GetEnumerator();
                Vibz.Interpreter.Plugin.PluginAssembly retValue = new Vibz.Interpreter.Plugin.PluginAssembly(asm.Location);
                while (classes.MoveNext())
                {
                    System.Type current = (System.Type)classes.Current;
                    if (!current.IsAbstract)
                    {
                        bool isRequired = false;
                        Type iFace = null;
                        foreach (Type iType in iTypeList)
                        {
                            if (current.GetInterface(iType.FullName) != null)
                            {
                                iFace = iType;
                                isRequired = true;
                                break;
                            }
                        }
                        if (isRequired)
                            retValue.Add(current.FullName.ToLower(), new FunctionType(current, iFace));
                    }
                }
                return retValue;
            }
            catch (System.Reflection.ReflectionTypeLoadException ex1)
            {
                string eMessage = "";
                foreach (Exception e in ex1.LoaderExceptions)
                {
                    eMessage += e.Message;
                }
                throw new Exception(ex1.Message + ". " + eMessage);
            }
            catch (Exception exc)
            {
                throw new Exception("Error loading assembly '" + asm.Location + "'. " + exc.Message);
            }
        }
    }
}
