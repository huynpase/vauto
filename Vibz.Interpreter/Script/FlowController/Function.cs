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
using System.Xml.Serialization;
using Vibz.Contract;
using Vibz.Interpreter.Script.FlowController;
using Vibz.Contract.Common;
using Vibz.Contract.Data;
using Vibz.Contract.Macro;
namespace Vibz.Interpreter.Script.FlowController
{
    public class Function : InstructionBase, ISynchronize
    {
        private Body _body;
        private DataHandler _variables;
        [XmlIgnore()]
        Vibz.Contract.Log.LogElement _progress;

        [XmlAttribute("name")]
        public string Name;

        DataHandler _dataSet = null;
        [XmlElement(DataCollection.nData)]
        public DataHandler DataSet
        {
            get
            {
                if (_dataSet == null)
                    _dataSet = new DataHandler(Vibz.Interpreter.Data.DataProcessor.Instance, Configuration.MacroManager.Instance);
                return _dataSet;
            }
            set
            {
                if (value == null)
                    _dataSet = new DataHandler(Vibz.Interpreter.Data.DataProcessor.Instance, Configuration.MacroManager.Instance);
                else
                {
                    _dataSet = value;
                    _dataSet.DataProcessor = Vibz.Interpreter.Data.DataProcessor.Instance;
                    _dataSet.MacroParser = new MacroParser(Configuration.MacroManager.Instance, _dataSet);
                }
            }
        }

        [XmlElement("body")]
        public Body Body
        {
            get
            {
                if (_body == null)
                    _body = new Body();
                return _body;
            }
            set
            {
                _body = value;
            }
        }
        public void Execute()
        {
            Execute(0);
        }
        public void Execute(int waitInterval)
        {
            _progress = new Vibz.Contract.Log.LogElement("Executing function '" + Name + "'.");
            try
            {
                ParameterSet.SetParser(DataSet.MacroParser);
                this.Body.Execute(DataSet, waitInterval);
                _progress.Add(Body.InfoEnd);
            }
            catch (Exception exc)
            {
                string message = "Error occured while executing function '" + this.Name + "'. " + Vibz.Contract.Log.LogException.GetFullException(exc);

                if (this.OnError == StepToFollow.Break.ToString().ToLower())
                    throw new Exception(message);

                _progress.Add(message, Vibz.Contract.Log.LogSeverity.Warn);
            }
        }
        [XmlIgnore()]
        public const int DefaultWait = 60000;
        private int _maxWait;
        [XmlAttribute("maxwait")]
        public string MaxWaitToText
        {
            get
            {
                if (_maxWait == 0)
                    _maxWait = Function.DefaultWait;
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
                    _maxWait = Function.DefaultWait;
                return _maxWait;
            }
            set
            {
                _maxWait = value;
            }
        }
        private string _onTimeOut;
        [XmlAttribute("ontimeout")]
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
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return _progress;
            }
        }
    }
}
