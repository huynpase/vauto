using System;
using System.Collections.Generic;
using System.Text;
using Vibz.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml.Serialization;
using Vibz.Contract;
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

            b = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(b);
            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            b.Save(FilePath, ImageFormat.Jpeg);
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
