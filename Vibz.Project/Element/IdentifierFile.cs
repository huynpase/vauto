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
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract.Data;
namespace Vibz.Solution.Element
{
    public class IdentifierFile : ElementBase
    {
        internal const string nControls = "controls";
        internal const string nControl = "control";
        internal const string nName = "name";

        internal IdentifierFile(FileInfo fInfo, Project ownerProject)
            : base(ownerProject)
        {
            _name = fInfo.Name;
            _path = fInfo.FullName;
        }

        public const string Extension = Vibz.FileType.Identifier;
        public override ElementType Type { get { return ElementType.Identifier; } }

        public override string FullName
        {
            get
            {
                if (_name == null || _name == "")
                    _name = "<No Name>";
                return _name;
            }
            set { _name = value; }
        }

        DataHandler _dataSet;
        public DataHandler DataSet
        {
            get
            {
                if (_dataSet == null)
                {
                    _dataSet = new DataHandler();
                }
                return _dataSet;
            }
            set
            {
                _dataSet = value;
            }
        }
        public override void Load()
        {
            this.OwnerProject.Queue.Enqueue(new Vibz.Contract.Log.LogQueueElement("Loading identifier file '" + this.FullName + "'.", Vibz.Contract.Log.LogSeverity.Trace));
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(Path);
            }
            catch (Exception exc)
            {
                throw new Exception("Invalid Identifier file content. [" + Path + "]" + exc.Message);
            }
            XmlNodeList xnlVar = doc.SelectNodes("//" + IdentifierFile.nControls + "/" + IdentifierFile.nControl);
            if (xnlVar != null)
            {
                foreach (XmlNode xnv in xnlVar)
                {
                    if (xnv.NodeType == XmlNodeType.Comment)
                        continue;
                    if (xnv.Attributes[IdentifierFile.nName] != null)
                        DataSet.DataList.Add(xnv.Attributes[IdentifierFile.nName].Value, new Vibz.Contract.Data.Text(xnv.InnerText), Path, xnv.InnerText);
                }
            }
        }
    }
}
