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
using Vibz.Contract.Attribute;
using System.Net.Mail;
using System.Net.Mime;
using Vibz.Contract;
using System.Xml.Serialization;

namespace Vibz.Net.SMTP
{
    [TypeInfo(Author = "Vibzworld", Details = "Sends the mail via Outlook.",
        Version = "2.0")]
    public class SendMail : InstructionBase, IAction
    {
        // Ref: http://www.codeproject.com/KB/IP/GmailSmtp.aspx
        string _fromUserId;
        [XmlAttribute("fromuserid")]
        public string FromUserId
        {
            get { return _fromUserId; }
            set { _fromUserId = value; }
        }
        string _fromPassword;
        [XmlAttribute("frompassword")]
        public string FromPassword
        {
            get { return _fromPassword; }
            set { _fromPassword = value; }
        }
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
        MailMessage mail = new MailMessage();
        public SendMail()
	    {
            Type = InstructionType.Action;
	    }
        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            FromUserId = vList.Evaluate(FromUserId);
            FromPassword = vList.Evaluate(FromPassword);
            To = vList.Evaluate(To);
            Subject = vList.Evaluate(Subject);
            Body = vList.Evaluate(Body);
            Send();
        }
		private void Send()
	    {
		    using (MailMessage mailMessage = 
			    new MailMessage(new MailAddress(FromUserId),
		        new MailAddress(To)))
	            {
		            mailMessage.Body = Body;
		            mailMessage.Subject = Subject;
		            try
	                {
		                SmtpClient SmtpServer = new SmtpClient();
		                SmtpServer.Credentials = 
		                    new System.Net.NetworkCredential(FromUserId, FromPassword);
		                SmtpServer.Port = 587;
		                SmtpServer.Host = "smtp.gmail.com";
		                SmtpServer.EnableSsl = true;
		                mail = new MailMessage();
		                String[] addr = To.Split(',');
		                mail.From = new MailAddress(FromUserId);
		                Byte i;
		                for (i = 0; i < addr.Length; i++)
		                mail.To.Add(addr[i]);
		                mail.Subject = Subject;
		                mail.Body = Body;
	                    mail.IsBodyHtml = true;
	                    mail.DeliveryNotificationOptions = 
		                    DeliveryNotificationOptions.OnFailure;
	                    mail.ReplyTo = new MailAddress(To);
	                    SmtpServer.Send(mail);	
                    }
		            catch (Exception ex)
	                {
                        throw new Exception("Error while sending mail. " + ex.Message);
	                }
                }
        }
    }
}
