using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using Vibz.Contract;
using Vibz.Contract.Data;
namespace Vibz.Interpreter.Script.FlowController
{
    public class If : InstructionBase, IAction
    {
        Vibz.Contract.Log.LogElement _progress;
        public If()
        {
            Type = InstructionType.Action;
        }
        List<Case> _caseList;
        [XmlIgnore()]
        public List<Case> CaseList
        {
            get
            {
                if (_caseList == null)
                {
                    _caseList = new List<Case>();
                    if (XCases != null)
                    {
                        foreach (XmlElement ele in XCases)
                        {
                            _caseList.Add((Case)Serializer.ConvertXmlElementToInstruction(ele));
                        }
                    }
                    else
                        throw new Exception("There must be one case within an if statement.");
                }
                return _caseList;
            }
            set
            {
                _caseList = value;
            }
        }
        [XmlAnyElement("case")]
        public XmlElement[] XCases;

        Else _else;
        [XmlIgnore()]
        public Else Else
        {
            get
            {
                if (_else == null)
                {
                    _else = (Else)Serializer.ConvertXmlElementToInstruction(XElse);
                }
                return _else;
            }
            set
            {
                _else = value;
            }
        }   
        [XmlAnyElement("else")]
        public XmlElement XElse;

        Case _executedCase = null;
        public void Execute(DataHandler vList)
        {
            _progress = new Vibz.Contract.Log.LogElement("If start.");
            IEnumerator<Case> caseInst = CaseList.GetEnumerator();
            while (caseInst.MoveNext())
            {
                if (caseInst.Current.Assert(vList))
                {
                    _executedCase = caseInst.Current;
                    break;
                }
            }
            if (_executedCase == null && Else != null)
                Else.Execute(vList);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd 
        { 
            get 
            {
                _progress.Add(_executedCase != null ? (Vibz.Contract.Log.LogElement)_executedCase.InfoEnd : (Else != null ? (Vibz.Contract.Log.LogElement)Else.InfoEnd : null));
                return _progress;
            } 
        } 
    }
}
