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
namespace Vibz.IO.Window
{
    [TypeInfo(Author="Vibzworld", Details = "Shows an windows alert with given text message.",
        Version = "2.0")]
    public class TextAlert : InstructionBase, IAction
    {
        string _message;
        [XmlAttribute("message")]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        int _duration;
        [XmlAttribute("duration")]
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        ExitMode _emode = ExitMode.AutoClose;
        [XmlAttribute("exit")]
        public string EMode
        {
            get { return _emode.ToString().ToLower(); }
            set 
            {
                switch (value.ToLower())
                { 
                    case "userclose":
                        _emode = ExitMode.UserClose;
                        break;
                    default:
                    case "autoclose":
                        _emode = ExitMode.AutoClose;
                        break;
                }
            }
        }
        DisplayMode _dmode = DisplayMode.FadeIn;
        [XmlAttribute("display")]
        public string DMode
        {
            get { return _dmode.ToString().ToLower(); }
            set
            {
                switch (value.ToLower())
                {
                    case "static":
                        _dmode = DisplayMode.Static;
                        break;
                    
                    case "crawlin":
                        _dmode = DisplayMode.CrawlIn;
                        break;
                    case "fadecrawlin":
                        _dmode = DisplayMode.FadeCrawlIn;
                        break;
                    default:
                    case "fadein":
                        _dmode = DisplayMode.FadeIn;
                        break;
                }
            }
        }
        Direction _direction = Direction.RightToLeft;
        [XmlAttribute("direction")]
        public string Motion
        {
            get { return _direction.ToString().ToLower(); }
            set
            {
                switch (value.ToLower())
                {
                    case "lefttoright":
                        _direction = Direction.LeftToRight;
                        break;
                    case "righttoleft":
                        _direction = Direction.RightToLeft;
                        break;
                    case "toptobottom":
                        _direction = Direction.TopToBottom;
                        break;
                    default:
                    case "bottomtotop":
                        _direction = Direction.BottomToTop;
                        break;
                }
            }
        }
        Position _position = Position.BottomRight;
        [XmlAttribute("position")]
        public string Location
        {
            get { return _position.ToString().ToLower(); }
            set
            {
                switch (value.ToLower())
                {
                    case "bottomright":
                        _position = Position.BottomRight;
                        break;
                    default:
                    case "center":
                        _position = Position.Center;
                        break;
                }
            }
        }
        public TextAlert() {
            Type = InstructionType.Action;
        }
        public TextAlert(string message)
        {
            Message = message;
            Type = InstructionType.Action;
        }
        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            TextAlertForm frm = new TextAlertForm(vList.Evaluate(Message), _dmode, _emode, _direction, _position, _duration);
            frm.ShowDialog();
        }

        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Message alert '" + Message + "' shown.");
            }
        }
    }
}
