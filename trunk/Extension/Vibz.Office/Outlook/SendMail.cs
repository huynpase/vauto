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
using Vibz.Contract;
using Vibz.Contract.Attribute;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Office;
using Outlook;

namespace Vibz.Office.Outlook
{
    [TypeInfo(Author = "Vibzworld", Details = "Sends the mail via Outlook.",
        Version = "2.0")]
    public class SendMail : InstructionBase, IAction
    {
        string _to;
        [XmlAttribute("to")]
        public string To
        {
            get { return _to; }
            set { _to = value; }
        }
        string _subject;
        [XmlAttribute("subject")]
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        string _body;
        [XmlAttribute("body")]
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
        string _attachment;
        [XmlAttribute("attachment")]
        public string Attachment
        {
            get { return _attachment; }
            set { _attachment = value; }
        }
        public SendMail()
        {
            Type = InstructionType.Action;
        }
        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            try
            {
                Application oApp = new Application();
                MailItem oMsg = (MailItem)oApp.CreateItem(OlItemType.olMailItem);
                Recipient oRecip = (Recipient)oMsg.Recipients.Add(To);
                oRecip.Resolve();
                oMsg.Subject = Subject;
                oMsg.Body = Body;
                Attachment oAttach;
                if (Attachment != null && Attachment != "")
                {
                    String sSource = Attachment;
                    String sDisplayName = "Attachment";
                    int iPosition = (int)oMsg.Body.Length + 1;
                    int iAttachType = (int)OlAttachmentType.olByValue;
                    oAttach = oMsg.Attachments.Add(sSource, iAttachType, iPosition, sDisplayName);
                }
                oMsg.Save();
                oMsg.Send();
                oRecip = null;
                oAttach = null;
                oMsg = null;
                oApp = null;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("{0} Exception caught: ", e);
            }
        }


        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Mail sent.");
            }
        }
    }
}
