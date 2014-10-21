#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using System.Text.RegularExpressions;
#endregion

namespace MailCountAddIn2010
{
    public partial class ThisAddIn
    {
        #region variables
        #endregion

        #region Event Handler
        #region Plugin_Startup
        private void Plugin_Startup(object sender, System.EventArgs e)
        {
            MessageBox.Show("Plugin started", "MailCount",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            InitPlugin();

            ShowStats();
        }
        #endregion
        #region Plugin_Shutdown
        private void Plugin_Shutdown(object sender, System.EventArgs e)
        {
            MessageBox.Show("Plugin stopped", "MailCount",
                MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        #endregion
        #endregion


        private void InitPlugin()
        {
            DateTime dueTime = new DateTime(
                DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Now.Hour + 1, 0, 0);
            TimeSpan timeRemaining = dueTime.Subtract(DateTime.Now);

            System.Threading.Timer t = new System.Threading.Timer(
                new System.Threading.TimerCallback(TimerTick), null,
                Convert.ToInt32(timeRemaining.TotalMilliseconds), // start at next full hour
                60 * 60 * 1000); // repeat every hour

            MessageBox.Show(String.Format("Start timer in {0}", timeRemaining),
                "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TimerTick(object state)
        {
            ShowStats();
        }

        private void ShowStats()
        {
            try
            {
                DateTime yesterday = DateTime.Now.AddDays(-1).Date;
                long sentMails = CountSentEmails(yesterday);
                long receivedMails = CountReceivedEmails(yesterday);

                MessageBox.Show(String.Format(
                        "Now is {0:d}\r\n" +
                        "Yesterdays ({1:d}) sent {2} and received {3} mails.",
                            DateTime.Now, yesterday.Date, sentMails, receivedMails),
                    "MailCount",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error occurred while counting mail\r\n" + ex.ToString(), 
                    "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #region Private Methods
        #region CountSentEmails
        private long CountSentEmails(DateTime SearchDate, string ExcludeFolderNamePattern = null)
        {
            Regex exRx = null;

            if (!String.IsNullOrEmpty(ExcludeFolderNamePattern))
                exRx = new Regex(ExcludeFolderNamePattern,
                    RegexOptions.Compiled | RegexOptions.Singleline);

            return CountSentEmails(SearchDate, exRx);
        }

        private long CountSentEmails(DateTime SearchDate, Regex ExcludeFolderNameRegex)
        {
            Outlook.NameSpace ns = this.Application.GetNamespace("MAPI");
            Outlook.MAPIFolder sentFolder = ns.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);

            return CountFolderItems(sentFolder, SearchDate, ExcludeFolderNameRegex);
        }
        #endregion
        #region CountReceivedEmails
        private long CountReceivedEmails(DateTime SearchDate, string ExcludeFolderNamePattern = null)
        {
            Regex exRx = null;

            if (!String.IsNullOrEmpty(ExcludeFolderNamePattern))
                exRx = new Regex(ExcludeFolderNamePattern,
                    RegexOptions.Compiled | RegexOptions.Singleline);

            return CountSentEmails(SearchDate, exRx);
        }

        private long CountReceivedEmails(DateTime SearchDate, Regex ExcludeFolderNameRegex)
        {
            long itemCount = 0;
            Outlook.NameSpace ns = this.Application.GetNamespace("MAPI");

            foreach (Outlook.MAPIFolder f in ns.Folders)
                if (f.DefaultItemType == OlItemType.olMailItem)
                    itemCount += CountFolderItems(f, SearchDate, ExcludeFolderNameRegex);

            return itemCount;
        }
        #endregion
        #region CountFolderItems
        private long CountFolderItems(MAPIFolder Folder, DateTime SearchDate,
            string ExcludeFolderNamePattern = null)
        {
            Regex exRx = null;

            if (!String.IsNullOrEmpty(ExcludeFolderNamePattern))
                exRx = new Regex(ExcludeFolderNamePattern,
                    RegexOptions.Compiled | RegexOptions.Singleline);

            return CountFolderItems(Folder, SearchDate, exRx);
        }

        private long CountFolderItems(MAPIFolder Folder, DateTime SearchDate,
            Regex ExcludeFolderNameRegex)
        {
            long itemCount = 0;
            Items items = Folder.Items;
            items.SetColumns("SentOn");
            Folders folders = Folder.Folders;
            DateTime sd = SearchDate.Date;

            // count items in folder
            foreach (Object o in items)
            {
                if (o is Outlook.MailItem)
                {
                    MailItem mi = o as MailItem;
                    DateTime misd = mi.SentOn.Date;
                    if (misd == sd)
                        itemCount++;
                }
            }

            // count items in sub-folders
            foreach (Folder f in folders)
                if (ExcludeFolderNameRegex == null || !ExcludeFolderNameRegex.IsMatch(f.Name))
                    itemCount += CountFolderItems(f, SearchDate, ExcludeFolderNameRegex);

            return itemCount;
        }
        #endregion
        #region GetAllFolders
        private IEnumerable<MAPIFolder> GetAllFolders(Folders folders)
        {
            foreach (MAPIFolder f in folders)
            {
                yield return f;
                foreach (var subfolder in GetAllFolders(f.Folders))
                {
                    yield return subfolder;
                }
            }
        }
        #endregion
        #endregion

        #region VBA Excel code junk
        /*
            Sub writeCS(myDat, myVal, emailStr)
                Dim sendStr As String
                Set objHTTP = CreateObject("MSXML2.ServerXMLHTTP")
                URL = "http://www.crowdstatus.net/api" '"http://37.221.192.79:8080/api"
                objHTTP.Open "PUT", URL, False
                objHTTP.setRequestHeader "Content-Type", "application/x-www-form-urlencoded"
                sendStr = "vat=emails&"
                sendStr = sendStr & "value=" & myVal & "&"
                sendStr = sendStr & "timestamp=" & Format$(myDat, "yyyy-mm-dd") & "&"
                sendStr = sendStr & "author=" & emailStr
                objHTTP.Send (sendStr)    
            End Sub
         
            Sub FindAppts()
                Dim myStart As Date
                Dim myEnd As Date
                Dim objOutlook As Object, objnSpace As Object
                Dim oCalendar As Outlook.Folder
                Dim oItems As Outlook.Items
                Dim oItemsInDateRange As Outlook.Items
                Dim oFinalItems As Outlook.Items
                Dim oAppt As Outlook.AppointmentItem
                Dim strRestriction As String

                myStart = Date - 6
                myEnd = DateAdd("d", 1, myStart)
    
                Dim dict As Object
                Set dict = CreateObject("Scripting.Dictionary")

                Debug.Print "Start:", myStart
                Debug.Print "End:", myEnd
          
                'Construct filter for the next 30-day date range
                strRestriction = "[Start] >= '" & _
                Format$(myStart, "mm/dd/yyyy hh:mm AMPM") _
                & "' AND [End] <= '" & _
                Format$(myEnd, "mm/dd/yyyy hh:mm AMPM") & "'"
                'Check the restriction string
                Debug.Print strRestriction
                Set objOutlook = CreateObject("Outlook.Application")
                Set objnSpace = objOutlook.GetNamespace("MAPI")
                Set oCalendar = objnSpace.GetDefaultFolder(olFolderCalendar)
                Set oItems = oCalendar.Items
                oItems.IncludeRecurrences = True
                oItems.Sort "[Start]"
                'Restrict the Items collection for the 30-day date range
                Set oItemsInDateRange = oItems.Restrict(strRestriction)
                'Sort and Debug.Print final results
                For Each myItem In oItemsInDateRange
                    If Format$(myItem.Start, "dd.mm.yyyy") = Format$(myStart, "dd.mm.yyyy") Then
                        Debug.Print myItem.Start, myItem.Subject, myItem.Duration
                    End If
                Next
    
                writeData dict, 1
            End Sub
         */
        #endregion

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(Plugin_Startup);
            this.Shutdown += new System.EventHandler(Plugin_Shutdown);
        }

        #endregion
    }
}
