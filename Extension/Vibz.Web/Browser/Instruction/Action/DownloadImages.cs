using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Author="Vibzworld", Details="Downloads all images from current page.", 
        Version="2.0")]
    public class DownloadImages : ActionBase
    {
        int _count;
        [XmlAttribute("folderpath")]
        public string FolderPath;
        public DownloadImages()
            : base()
        {
                    
        }
        public DownloadImages(string folderPath)
            : base()
        {
            FolderPath = folderPath;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            _count = Browser.DownloadAllImages(Vibz.Contract.Macro.CommonMacroVariables.Get("__currentpath"), FolderPath);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Downloaded '" + _count + "' images from current page into '" + FolderPath + "'.");
            }
        }
    }
}
