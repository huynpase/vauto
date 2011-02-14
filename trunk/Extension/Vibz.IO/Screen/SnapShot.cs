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
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml.Serialization;
using Vibz.Contract;
using Vibz.Contract.Attribute;
using Vibz.Contract.Data;
namespace Vibz.IO.TextFile.Instruction.Action
{
    [TypeInfo(Author="Vibzworld", Details = "Captures the screenshot of the desktop at the moment.",
        Version = "2.0")]
    public class SnapShot : InstructionBase, IAction
    {
        string _filePath;
        [XmlAttribute("filepath")]
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        public SnapShot() {
            Type = InstructionType.Action;
        }
        public SnapShot(string filepath)
        {
            FilePath = filepath;
            Type = InstructionType.Action;
        }
        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Bitmap b;
            Graphics g;
            if (FilePath.ToLower().Contains("@{reportpath}"))
                FilePath = FilePath.ToLower().Replace("@{reportpath}", this.ValueMap["reportpath"]);

            if (FilePath.ToLower().Contains("{datetimestamp}"))
                FilePath = FilePath.ToLower().Replace("{datetimestamp}", Vibz.Helper.IO.FilterFolderChar(DateTime.Now.ToString()));

            FilePath = Vibz.Helper.IO.CreateFolderPath(FilePath, Vibz.Helper.IOType.File);

            try
            {
                b = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                g = Graphics.FromImage(b);
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                b.Save(FilePath, ImageFormat.Jpeg);
            }
            catch (System.ComponentModel.Win32Exception exc)
            {
                Vibz.Contract.Log.LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement("Execution invoked by service, could not capture screenshot.", Vibz.Contract.Log.LogSeverity.Warn));
            }
        }

        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Snapshot captured at '" + FilePath + "'.");
            }
        }
    }
}
