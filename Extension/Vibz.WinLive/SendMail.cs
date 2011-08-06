using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract.Attribute;
using Vibz.Contract;
using System.Runtime.InteropServices;

namespace Vibz.WinLive
{
    [TypeInfo(Author = "Vibzworld", Details = "Sends the mail via Outlook.",
        Version = "2.0")]
    public class SendMail : InstructionBase, IAction
    {
        #region Constants

        private const string sSubject = "You got spammed!";

        #endregion

        #region Variables

        List<MapiRecipDesc> aoRecipients = new List<MapiRecipDesc>();

        #endregion

        #region Classes

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class MapiMessage
        {
            public int iReserved;
            public string sSubject;
            public string sNoteText;
            public string sMessageType;
            public string sDateReceived;
            public string sConversationID;
            public int iFlags;
            public IntPtr oOriginator;
            public int iRecipCount;
            public IntPtr oRecips;
            public int iFileCount;
            public IntPtr iFiles;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class MapiRecipDesc
        {
            public int iReserved;
            public int iRecipClass;
            public string sName;
            public string sAddress;
            public int iIDSize;
            public IntPtr iEntryID;
        }

        #endregion

        #region Constructors

        public SendMail()
        {
            // Default constructor
            MapiMessage oMsg = new MapiMessage();
            oMsg.sSubject = sSubject;
            MapiRecipDesc recipient = new MapiRecipDesc();
            recipient.iRecipClass = 1;
            recipient.sName = "mail_id";
            aoRecipients.Add(recipient);
            oMsg.oRecips = GetRecipients(out oMsg.iRecipCount);
            int iError = MAPISendMail(new IntPtr(0), new IntPtr(0), oMsg, 9, 0);
        }

        #endregion

        #region Methods

        [DllImport("Mapi32.dll")]
        static extern int MAPISendMail(IntPtr oSess, IntPtr oHwnd, MapiMessage sMsg, int iFlag, int iRsv);

        IntPtr GetRecipients(out int iReciCount)
        {
            //
            // This method gets the mentioned recipient mail id
            //
            iReciCount = 0;
            if (aoRecipients.Count == 0)
                return IntPtr.Zero;

            int iSize = Marshal.SizeOf(typeof(MapiRecipDesc));
            IntPtr oIntPtr = Marshal.AllocHGlobal(aoRecipients.Count * iSize);

            int iPtr = (int)oIntPtr;
            foreach (MapiRecipDesc oReciDesc in aoRecipients)
            {
                Marshal.StructureToPtr(oReciDesc, (IntPtr)iPtr, false);
                iPtr += iSize;
            }

            iReciCount = aoRecipients.Count;
            return oIntPtr;
        }

        #endregion

        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            throw new Exception("Not implemented");
        }
    }
}
