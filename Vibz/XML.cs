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
using System.IO;

namespace Vibz
{
    public class XML : XmlDocument
    {
        static Dictionary<string, XML> _listXml = new Dictionary<string, XML>();
        string _path = "";
        static object _lock = new object();
        private XML()
        { }
        public static XML GetDocument(string path)
        {
            return GetDocument(path, null);
        }
        public static XML GetDocument(string path, string newDocumentText)
        {
            return GetDocument(path, newDocumentText, false);
        }
        public static XML GetDocument(string path, string newDocumentText, bool reload)
        {
            string fullpath = new FileInfo(path).FullName.ToLower();
            if (!_listXml.ContainsKey(fullpath) || reload)
            {
                lock (_lock)
                {
                    if (!_listXml.ContainsKey(fullpath) || reload)
                    {
                        XML doc = new XML();
                        try
                        {
                            if (!File.Exists(path))
                            {
                                if (newDocumentText == null)
                                    throw new Exception("File '" + path + "' not exists.");
                                doc.LoadXml(newDocumentText);
                            }
                            else
                                doc.Load(fullpath);
                            doc._path = fullpath;
                        }
                        catch (Exception exc)
                        {
                            throw new Exception("Error loading Xml file. " + exc.Message);
                        }
                        if (!_listXml.ContainsKey(fullpath))
                            _listXml.Add(fullpath, doc);
                        else
                            _listXml[fullpath] = doc;
                    }
                }
            }
            return _listXml[fullpath];
        }
        public void Save()
        {
            base.Save(this._path);
        }
    }
}
