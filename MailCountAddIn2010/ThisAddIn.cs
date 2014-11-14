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
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Win32;
using System.Globalization;
using Microsoft.Office.Core;
using System.Drawing;
#endregion

namespace MailCountAddIn2010
{
    public partial class ThisAddIn
    {
        // now using VisualStudio Online

        #region Variables
        //private string w;
        private System.Threading.Timer _t;
        private string _currentUsersEmailAddress;
        private Regex _folderExcludeRegex = null;
        private Config _cfg = null;
        #endregion

        #region Event Handler
        #region Plugin_Startup
        private void Plugin_Startup(object sender, System.EventArgs e)
        {
            _cfg = Config.Singleton;

            InitPlugin();

            if (_cfg.ShowDebug)
                MessageBox.Show("Plugin started.",
                    Config.PROD_SHORT_NAME + " (Debug)",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            ProcessData();
        }
        #endregion
        #region Plugin_Shutdown
        private void Plugin_Shutdown(object sender, System.EventArgs e)
        {
            DisposePlugin();

            if (_cfg.ShowDebug)
                MessageBox.Show("Plugin stopped.",
                    Config.PROD_SHORT_NAME + " (Debug)",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        #endregion
        #endregion

        #region Properties
        #region Configuration
        public Config Configuration
        {
            get { return _cfg; }
        }
        #endregion
        #endregion

        #region Private Methods
        #region InitPlugin
        private void InitPlugin()
        {
            DisposePlugin();
            _cfg.ReadConfig();

            _currentUsersEmailAddress = this.Application.ActiveExplorer().Session
                .CurrentUser.AddressEntry.GetExchangeUser().PrimarySmtpAddress;

            //DateTime dueTime = new DateTime(
            //    DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Now.Hour + 1, 0, 0);
            DateTime dueTime = new DateTime(
                DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 5, 0).AddDays(1);
            TimeSpan timeRemaining = dueTime.Subtract(DateTime.Now);

            _t = new System.Threading.Timer(
                new System.Threading.TimerCallback(TimerTick), null,
                Convert.ToInt32(timeRemaining.TotalMilliseconds), // start at next day 00:05:00
                24 * 60 * 60 * 1000); // repeat every day

            if (_cfg.ShowDebug)
                MessageBox.Show(String.Format("Start timer at {0} waiting {1}",
                        dueTime, timeRemaining),
                    Config.PROD_SHORT_NAME + " (Debug)",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region DisposePlugin
        private void DisposePlugin()
        {
            if (_t != null)
            {
                _t.Dispose();
                _t = null;
            }
        }
        #endregion

        #region TimerTick
        private void TimerTick(object state)
        {
            ProcessData();
        }
        #endregion
        #region ProcessData
        private void ProcessData()
        {
            DateTime today = DateTime.Now.Date;
            DateTime yesterday = today.AddDays(-1).Date;

            try
            {
                if (DateTime.Compare(today, _cfg.LastSent) <= 0)
                {
                    if (_cfg.ShowPopups)
                        MessageBox.Show(String.Format(
                                "Today is {0:d}\r\n" +
                                "Last time data was sent: {1:d}\r\n\r\n" +
                                "Not sending yesterdays {2:d} data as it was already sent!",
                                    DateTime.Now,
                                    _cfg.LastSent,
                                    yesterday.Date),
                            Config.PROD_SHORT_NAME,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                // count mails
                long totalSentMails = 0;
                long sentMails = CountSentEmails(
                    yesterday, out totalSentMails, _folderExcludeRegex);
                //MessageBox.Show(String.Format("Sent:\r\n{0}", w), "Message counts",
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);

                long totalReceivedMails = 0;
                long receivedMails = CountReceivedEmails(
                    yesterday, out totalReceivedMails, _folderExcludeRegex);
                //MessageBox.Show(String.Format("Received:\r\n{0}", w), "Message counts",
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_cfg.ShowPopups)
                    MessageBox.Show(String.Format(
                            "Today is {0:d}\r\n" +
                            "Last time data was sent: {1:d}\r\n\r\n" +
                            "Sending yesterdays {2:d}\r\n" +
                            "\tsent {3} ( from total {4} ) and \r\n" +
                            "\treceived {5} ( from total {6} ) e-mails\r\n" +
                            "\tfor user {7} to http://www.crowdstatus.net/",
                                DateTime.Now,
                                _cfg.LastSent,
                                yesterday.Date,
                                sentMails, totalSentMails,
                                receivedMails, totalReceivedMails,
                                _currentUsersEmailAddress),
                        Config.PROD_SHORT_NAME,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    // write registry
                    _cfg.LastSent = today;
                    _cfg.LastDate = yesterday;
                    _cfg.LastSentEmails = sentMails;
                    _cfg.LastReceivedEmails = receivedMails;
                    _cfg.WriteConfig();
                }
                catch { }

                // send data to service
                if (_cfg.TrackReceivedEmails)
                    SendToCrowdStatus(today, _currentUsersEmailAddress,
                        _cfg.TrackReceivedEmailsToken, receivedMails).Wait();

                if (_cfg.TrackSentEmails)
                    SendToCrowdStatus(today, _currentUsersEmailAddress,
                        _cfg.TrackSentEmailsToken, sentMails).Wait();
            }
            catch (System.Exception ex)
            {
                if (_cfg.ShowErrors)
                    MessageBox.Show("Error occurred while processing data for http://www.crowdstatus.net\r\n\r\n" +
                            ex.ToString(),
                        Config.PROD_SHORT_NAME + " error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CountSentEmails
        private long CountSentEmails(DateTime SearchDate, out long TotalCount,
            string ExcludeFolderNamePattern = null)
        {
            Regex exRx = null;

            if (!String.IsNullOrEmpty(ExcludeFolderNamePattern))
                exRx = new Regex(ExcludeFolderNamePattern,
                    RegexOptions.Compiled | RegexOptions.Singleline);

            return CountSentEmails(SearchDate, out TotalCount, exRx);
        }

        private long CountSentEmails(DateTime SearchDate, out long TotalCount, Regex ExcludeFolderNameRegex)
        {
            Outlook.NameSpace ns = this.Application.GetNamespace("MAPI");
            Outlook.MAPIFolder sentFolder = ns.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);

            //w = String.Empty;

            return CountFolderItems(sentFolder, SearchDate, out TotalCount, ExcludeFolderNameRegex);
        }
        #endregion
        #region CountReceivedEmails
        private long CountReceivedEmails(DateTime SearchDate, out long TotalCount,
            string ExcludeFolderNamePattern = null)
        {
            Regex exRx = null;

            if (!String.IsNullOrEmpty(ExcludeFolderNamePattern))
                exRx = new Regex(ExcludeFolderNamePattern,
                    RegexOptions.Compiled | RegexOptions.Singleline);

            return CountReceivedEmails(SearchDate, out TotalCount, exRx);
        }

        private long CountReceivedEmails(DateTime SearchDate, out long TotalCount,
            Regex ExcludeFolderNameRegex)
        {
            long itemCount = 0;
            TotalCount = 0;
            long tc = 0;
            Outlook.NameSpace ns = this.Application.GetNamespace("MAPI");

            //w = String.Empty;

            foreach (Outlook.MAPIFolder f in ns.Folders)
            {
                //MessageBox.Show(f.Name,
                //    "Folder Info",
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (f.DefaultItemType == OlItemType.olMailItem)
                {
                    tc = 0;
                    itemCount += CountFolderItems(f, SearchDate, out tc, ExcludeFolderNameRegex);
                    TotalCount += tc;
                }
            }

            return itemCount;
        }
        #endregion

        #region CountFolderItems
        private long CountFolderItems(Folder Folder, DateTime SearchDate,
            out long TotalCount, string ExcludeFolderNamePattern = null)
        {
            Regex exRx = null;

            if (!String.IsNullOrEmpty(ExcludeFolderNamePattern))
                exRx = new Regex(ExcludeFolderNamePattern,
                    RegexOptions.Compiled | RegexOptions.Singleline);

            return CountFolderItems(Folder, SearchDate, out TotalCount, exRx);
        }

        private long CountFolderItems(MAPIFolder Folder, DateTime SearchDate,
            out long TotalCount, Regex ExcludeFolderNameRegex)
        {
            long itemCount = 0;
            TotalCount = 0;
            long tc = 0;
            Items items = Folder.Items;
            try
            {
                items.SetColumns("SentOn");
            }
            catch { }
            Folders folders = Folder.Folders;

            if (Folder == null)
                return 0;

            if (ExcludeFolderNameRegex != null && ExcludeFolderNameRegex.IsMatch(Folder.Name))
                return 0;

            // count items in folder
            //w += Folder.Name + " (";

            foreach (Object o in items)
            {
                if (o is Outlook.MailItem)
                {
                    TotalCount++;
                    MailItem mi = o as MailItem;
                    if (DateTime.Compare(mi.SentOn.Date, SearchDate.Date) == 0)
                        itemCount++;
                }
            }

            //w += TotalCount.ToString() + ")\r\n";

            // count items in sub-folders
            foreach (Folder f in folders)
                if (ExcludeFolderNameRegex == null || !ExcludeFolderNameRegex.IsMatch(f.Name))
                {
                    tc = 0;
                    itemCount += CountFolderItems(f, SearchDate, out tc, ExcludeFolderNameRegex);
                    TotalCount += tc;
                }

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

        #region SendToCrowdStatus
        private async Task SendToCrowdStatus(
            DateTime SearchDate, string EmailAddress,
            string Token, long MailCount)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_cfg.ApiUri);
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(
                //    new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                /*
                HttpResponseMessage res = await client.PostAsync("api",
                                          new FormUrlEncodedContent(
                                              new Dictionary<string, string>
                                              {
                                                  { "vat", "emails" },
                                                  { "value", ReceivedMailCount.ToString() },
                                                  { "timestamp", SearchDate.Date.ToString("yyyy-MM-dd") },
                                                  { "author", EmailAddress }
                                              }));*/

                var req = new HttpRequestMessage(HttpMethod.Put, "/api");

                var keyValues = new List<KeyValuePair<string, string>>();
                keyValues.Add(new KeyValuePair<string, string>("vat", Token));
                keyValues.Add(new KeyValuePair<string, string>("author", EmailAddress));
                keyValues.Add(new KeyValuePair<string, string>("value", MailCount.ToString()));
                keyValues.Add(new KeyValuePair<string, string>("value_timestamp", SearchDate.Date.ToString("yyyy-MM-dd")));
                keyValues.Add(new KeyValuePair<string, string>("privacy", "1"));
                keyValues.Add(new KeyValuePair<string, string>("confidence", "100"));

                req.Content = new FormUrlEncodedContent(keyValues);
                string c = await req.Content.ReadAsStringAsync();

                if (_cfg.ShowDebug)
                    MessageBox.Show(String.Format(
                        "Request to {0}:\r\n\r\n{1}\r\n\r\nContent:\r\n{2}",
                            req.RequestUri, req.ToString(), c),
                        Config.PROD_SHORT_NAME + " (Debug)",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                HttpResponseMessage res = await client.SendAsync(req);

                c = await res.Content.ReadAsStringAsync();

                if (_cfg.ShowDebug)
                    MessageBox.Show(String.Format(
                        "Response from {0}:\r\n\r\n{1}\r\n\r\nContent:\r\n{2}",
                            res.RequestMessage.RequestUri, res.ToString(), c),
                        Config.PROD_SHORT_NAME + " (Debug)",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                res.EnsureSuccessStatusCode();
            }
        }
        #endregion
        #endregion

        #region VBA Excel code junk
        /*
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
