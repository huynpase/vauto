using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Vibz.Helper;
using System.Xml.Serialization;
using Vibz.Contract.Common;
namespace Vibz.Web.Browser.Instruction.Action.Synchronize
{
    public abstract class SynchronizeBase : ActionBase, ISynchronize
    {
        [XmlIgnore()]
        public const int DefaultWait = 60000;
        private int _maxWait;
        [XmlAttribute("maxwait")]
        [Vibz.Contract.Attribute.AttributeInfo(WebInstructionBase.MaxWaitInfo,null,false)]
        public string MaxWaitToText
        {
            get
            {
                if (_maxWait == 0)
                    _maxWait = SynchronizeBase.DefaultWait;
                return _maxWait.ToString();
            }
            set 
            {
                _maxWait = Vibz.Helper.Math.TryGetInteger(value);
            }
        }
        public int MaxWait
        {
            get
            {
                if (_maxWait == 0)
                    _maxWait = SynchronizeBase.DefaultWait;
                return _maxWait;
            }
            set
            {
                _maxWait = value;
            }
        }
        private string _onTimeOut;
        [XmlAttribute("ontimeout")]
        [Vibz.Contract.Attribute.AttributeInfo(WebInstructionBase.OnTimeOutInfo, typeof(StepToFollow), false)]
        public string OnTimeOut
        {
            get
            {
                if (_onTimeOut == null)
                    _onTimeOut = StepToFollow.Break.ToString();
                return _onTimeOut.ToLower();
            }
            set
            {
                if (value.ToLower() == StepToFollow.Break.ToString().ToLower()
                    || value.ToLower() == StepToFollow.Continue.ToString().ToLower())
                    _onTimeOut = value.ToLower();
                else
                    throw new Exception("Encountered invalid option '" + value + "' for ontimeout. Available options are 'continue or break'.");
            }
        }
    }
}
