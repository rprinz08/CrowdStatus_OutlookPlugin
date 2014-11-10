#region Usings
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace MailCountAddIn2010
{
    public class Config
    {
        #region Constants
        public const string PROD_ID = "MailCountAddIn2010";
        public const string PROD_SHORT_NAME = "CrowdSource MailCount";
        public const string PROD_LONG_NAME = "CrowdSource Outlook 2010 mail count plugin";
        public const string PROD_DESCRIPTION = "Tracks your current email count " +
            "(and ONLY the count of your sent and received emails - nothing else) " +
            "per day on www.croudstatus.net";

        private const string REG_SOFTWARE_KEY_NAME = "Software";
        private const string REG_COMPANY_KEY_NAME = "MIN.at";
        private const string REG_PRODUCT_KEY_NAME = PROD_ID;

        private const string CONFIG_API_URI_NAME = "ApiUri";
        private const string CONFIG_API_URI_DEFAULT = "http://www.crowdstatus.net/api";

        private const string CONFIG_LAST_SENT_NAME = "LastSent";
        private static readonly DateTime CONFIG_LAST_SENT_DEFAULT = DateTime.MinValue;

        private const string CONFIG_LAST_DATE_NAME = "LastDataDate";
        private static readonly DateTime CONFIG_LAST_DATE_DEFAULT = DateTime.MinValue;

        private const string CONFIG_LAST_SENT_MAILS_NAME = "LastSentMails";
        private const long CONFIG_LAST_SENT_MAILS_DEFAULT = 0;
        private const string CONFIG_LAST_RECEIVED_MAILS_NAME = "LastReceivedMails";
        private const long CONFIG_LAST_RECEIVED_MAILS_DEFAULT = 0;

        private const string CONFIG_TRACK_SENT_MAILS_NAME = "TrackSent";
        private const bool CONFIG_TRACK_SENT_MAILS_DEFAULT = true;
        private const string CONFIG_TRACK_SENT_MAILS_TOKEN_NAME = "TrackSentToken";
        private const string CONFIG_TRACK_SENT_MAILS_TOKEN_DEFAULT = "sent_emails";

        private const string CONFIG_TRACK_RECEIVED_MAILS_NAME = "TrackReceived";
        private const bool CONFIG_TRACK_RECEIVED_MAILS_DEFAULT = true;
        private const string CONFIG_TRACK_RECEIVED_MAILS_TOKEN_NAME = "TrackReceivedToken";
        private const string CONFIG_TRACK_RECEIVED_MAILS_TOKEN_DEFAULT = "emails";

        private const string CONFIG_SHOW_POPUPS_NAME = "ShowPopups";
        private const bool CONFIG_SHOW_POPUPS_DEFAULT = true;

        private const string CONFIG_SHOW_ERRORS_NAME = "ShowErrors";
        private const bool CONFIG_SHOW_ERRORS_DEFAULT = true;

        private const string CONFIG_SHOW_DEBUG_NAME = "ShowDebug";
        private const bool CONFIG_SHOW_DEBUG_DEFAULT = true;

        private const string CONFIG_FOLDER_EXCLUDE_PATTERN_NAME = "FolderExcludePattern";
        private const string CONFIG_FOLDER_EXCLUDE_PATTERN_DEFAULT = "^[Vv]ault";
        #endregion

        #region Variables
        private readonly string _swRegistryRoot;

        private string _configApiUri = CONFIG_API_URI_DEFAULT;
        private DateTime _configLastSent = CONFIG_LAST_SENT_DEFAULT;

        private DateTime _configLastDate = CONFIG_LAST_DATE_DEFAULT;
        private long _lastSentEmails = CONFIG_LAST_SENT_MAILS_DEFAULT;
        private long _lastReceivedEmails = CONFIG_LAST_RECEIVED_MAILS_DEFAULT;

        private bool _trackSentEmails = CONFIG_TRACK_SENT_MAILS_DEFAULT;
        private string _trackSentEmailsToken = CONFIG_TRACK_SENT_MAILS_TOKEN_DEFAULT;

        private bool _trackReceivedEmails = CONFIG_TRACK_RECEIVED_MAILS_DEFAULT;
        private string _trackReceivedEmailsToken = CONFIG_TRACK_RECEIVED_MAILS_TOKEN_DEFAULT;

        private bool _configShowPopups = CONFIG_SHOW_POPUPS_DEFAULT;
        private bool _configShowDebug = CONFIG_SHOW_DEBUG_DEFAULT;
        private bool _configShowErrors = CONFIG_SHOW_ERRORS_DEFAULT;

        private string _configFolderExcludePattern = CONFIG_FOLDER_EXCLUDE_PATTERN_DEFAULT;
        private Regex _folderExcludeRegex = null;
        #endregion

        #region Ctor / Dtor
        public Config()
        {
            _swRegistryRoot = String.Format(@"{0}\{1}\{2}",
                Config.REG_SOFTWARE_KEY_NAME,
                Config.REG_COMPANY_KEY_NAME,
                Config.REG_PRODUCT_KEY_NAME);

            ReadConfig();
        }
        #endregion

        #region Properties
        #region RegistryRoot
        public string RegistryRoot
        {
            get { return _swRegistryRoot; }
        }
        #endregion

        #region ApiUri
        public string ApiUri
        {
            get { return _configApiUri; }
            set { _configApiUri = value; }
        }
        #endregion

        #region LastSent
        public DateTime LastSent
        {
            get { return _configLastSent; }
            set { _configLastSent = value; }
        }
        #endregion
        #region LastDate
        public DateTime LastDate
        {
            get { return _configLastDate; }
            set { _configLastDate = value; }
        }
        #endregion
        #region LastSentEmails
        public long LastSentEmails
        {
            get { return _lastSentEmails; }
            set { _lastSentEmails = value; }
        }
        #endregion
        #region LastReceivedEmails
        public long LastReceivedEmails
        {
            get { return _lastReceivedEmails; }
            set { _lastReceivedEmails = value; }
        }
        #endregion

        #region TrackSentEmails
        public bool TrackSentEmails
        {
            get { return _trackSentEmails; }
            set { _trackSentEmails = value; }
        }
        #endregion
        #region TrackSentEmailsToken
        public string TrackSentEmailsToken
        {
            get { return _trackSentEmailsToken; }
            set { _trackSentEmailsToken = value; }
        }
        #endregion

        #region TrackReceivedEmails
        public bool TrackReceivedEmails
        {
            get { return _trackReceivedEmails; }
            set { _trackReceivedEmails = value; }
        }
        #endregion
        #region TrackReceivedEmailsToken
        public string TrackReceivedEmailsToken
        {
            get { return _trackReceivedEmailsToken; }
            set { _trackReceivedEmailsToken = value; }
        }
        #endregion

        #region ShowPopups
        public bool ShowPopups
        {
            get { return _configShowPopups; }
            set { _configShowPopups = value; }
        }
        #endregion
        #region ShowDebug
        public bool ShowDebug
        {
            get { return _configShowDebug; }
            set { _configShowDebug = value; }
        }
        #endregion
        #region ShowErrors
        public bool ShowErrors
        {
            get { return _configShowErrors; }
            set { _configShowErrors = value; }
        }
        #endregion

        #region FolderExcludePattern
        public string FolderExcludePattern
        {
            get { return _configFolderExcludePattern; }
            set
            {
                _configFolderExcludePattern = value;
                _folderExcludeRegex = CreateFolderExcludeRegex(_configFolderExcludePattern);
            }
        }
        #endregion
        #region FolderExcludeRegex
        public Regex FolderExcludeRegex
        {
            get { return _folderExcludeRegex; }
        }
        #endregion
        #endregion

        #region Public Methods
        #region ReadConfig
        public void ReadConfig()
        {
            try
            {
                _configApiUri = RegApiUri();

                _configLastSent = RegLastSent();
                _configLastDate = RegLastDate();
                _lastSentEmails = RegLastSentEmails();
                _lastReceivedEmails = RegLastReceivedEmails();

                _trackSentEmails = RegTrackSentEmails();
                _trackSentEmailsToken = RegTrackSentEmailsToken();

                _trackReceivedEmails = RegTrackReceivedEmails();
                _trackReceivedEmailsToken = RegTrackReceivedEmailsToken();

                _configShowPopups = RegShowPopups();
                _configShowDebug = RegShowDebug();
                _configShowErrors = RegShowErrors();

                _configFolderExcludePattern = RegFolderExcludePattern();

                WriteConfig();

                if (_configShowDebug)
                    MessageBox.Show(String.Format(
                        "Current plugin configuration values are:\r\n\r\n" +
                        "{0} = ({1})\r\n{2} = ({3})\r\n{4} = ({5})\r\n{6} = ({7})\r\n{8} = ({9})\r\n",
                        CONFIG_SHOW_POPUPS_NAME, _configShowPopups,
                        CONFIG_SHOW_DEBUG_NAME, _configShowDebug,
                        CONFIG_API_URI_NAME, _configApiUri,
                        CONFIG_LAST_SENT_NAME, _configLastSent,
                        CONFIG_FOLDER_EXCLUDE_PATTERN_NAME, _configFolderExcludePattern),
                        PROD_SHORT_NAME + " (Debug)",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                if (_configShowErrors)
                    MessageBox.Show("Error occurred while configuring plugin\r\n" +
                            ex.ToString(),
                        PROD_SHORT_NAME + " error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region WriteConfig
        public void WriteConfig()
        {
            try
            {
                RegApiUri(_configApiUri);

                RegLastSent(_configLastSent);
                RegLastDate(_configLastDate);
                RegLastSentEmails(_lastSentEmails);
                RegLastReceivedEmails(_lastReceivedEmails);

                RegTrackSentEmails(_trackSentEmails);
                RegTrackSentEmailsToken(_trackSentEmailsToken);

                RegTrackReceivedEmails(_trackReceivedEmails);
                RegTrackReceivedEmailsToken(_trackReceivedEmailsToken);

                RegShowPopups(_configShowPopups);
                RegShowDebug(_configShowDebug);
                RegShowErrors(_configShowErrors);

                RegFolderExcludePattern(_configFolderExcludePattern);
                _folderExcludeRegex = CreateFolderExcludeRegex(_configFolderExcludePattern);
            }
            catch (System.Exception ex)
            {
                if (_configShowErrors)
                    MessageBox.Show("Error occurred while writing plugin configuration\r\n" +
                            ex.ToString(),
                        PROD_SHORT_NAME + " error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #endregion

        #region Private Methods
        #region ApiUri
        private string RegApiUri()
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            string value = null;

            try
            {
                value =
                    addInSwKey.GetValue(CONFIG_API_URI_NAME, CONFIG_API_URI_DEFAULT) as String;
            }
            catch { value = null; }
            if (value == null)
                value = CONFIG_API_URI_DEFAULT;

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();

            return value;
        }

        private void RegApiUri(string Value)
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            try
            {
                addInSwKey.SetValue(CONFIG_API_URI_NAME,
                    Value, RegistryValueKind.String);
            }
            catch { }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();
        }
        #endregion

        #region LastSent
        private DateTime RegLastSent()
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            DateTime value = CONFIG_LAST_SENT_DEFAULT;

            try
            {
                value =
                    DateTime.ParseExact(
                        addInSwKey.GetValue(CONFIG_LAST_SENT_NAME, CONFIG_LAST_SENT_DEFAULT) as String,
                        "yyyyMMdd", CultureInfo.InvariantCulture);
            }
            catch
            {
                value = CONFIG_LAST_SENT_DEFAULT;
            }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();

            return value;
        }

        private void RegLastSent(DateTime Value)
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            try
            {
                addInSwKey.SetValue(CONFIG_LAST_SENT_NAME,
                    Value.ToString("yyyyMMdd"), RegistryValueKind.String);
            }
            catch { }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();
        }
        #endregion
        #region LastDate
        private DateTime RegLastDate()
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            DateTime value = CONFIG_LAST_DATE_DEFAULT;

            try
            {
                value =
                    DateTime.ParseExact(
                        addInSwKey.GetValue(CONFIG_LAST_DATE_NAME, CONFIG_LAST_DATE_DEFAULT) as String,
                        "yyyyMMdd", CultureInfo.InvariantCulture);
            }
            catch
            {
                value = CONFIG_LAST_DATE_DEFAULT;
            }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();

            return value;
        }

        private void RegLastDate(DateTime Value)
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            try
            {
                addInSwKey.SetValue(CONFIG_LAST_DATE_NAME,
                    Value.ToString("yyyyMMdd"), RegistryValueKind.String);
            }
            catch { }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();
        }
        #endregion
        #region LastSentEmails
        private long RegLastSentEmails()
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            long value = CONFIG_LAST_SENT_MAILS_DEFAULT;

            try
            {
                value = Convert.ToInt64(addInSwKey.GetValue(CONFIG_LAST_SENT_MAILS_NAME,
                    CONFIG_LAST_SENT_MAILS_DEFAULT));
            }
            catch
            {
                value = CONFIG_LAST_SENT_MAILS_DEFAULT;
            }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();

            return value;
        }

        private void RegLastSentEmails(long Value)
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            try
            {
                addInSwKey.SetValue(Config.CONFIG_LAST_SENT_MAILS_NAME,
                    Value, RegistryValueKind.DWord);
            }
            catch { }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();
        }
        #endregion
        #region LastReceivedEmails
        private long RegLastReceivedEmails()
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            long value = CONFIG_LAST_RECEIVED_MAILS_DEFAULT;

            try
            {
                value = Convert.ToInt64(addInSwKey.GetValue(CONFIG_LAST_RECEIVED_MAILS_NAME,
                    CONFIG_LAST_RECEIVED_MAILS_DEFAULT));
            }
            catch
            {
                value = CONFIG_LAST_RECEIVED_MAILS_DEFAULT;
            }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();

            return value;
        }

        private void RegLastReceivedEmails(long Value)
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            try
            {
                addInSwKey.SetValue(Config.CONFIG_LAST_RECEIVED_MAILS_NAME,
                    Value, RegistryValueKind.DWord);
            }
            catch { }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();
        }
        #endregion

        #region TrackSentEmails
        private bool RegTrackSentEmails()
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            bool value = CONFIG_TRACK_SENT_MAILS_DEFAULT;

            try
            {
                value = (Convert.ToUInt32(addInSwKey.GetValue(CONFIG_TRACK_SENT_MAILS_NAME,
                    CONFIG_TRACK_SENT_MAILS_DEFAULT)) > 0);
            }
            catch
            {
                value = CONFIG_TRACK_SENT_MAILS_DEFAULT;
            }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();

            return value;
        }

        private void RegTrackSentEmails(bool Value)
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            try
            {
                addInSwKey.SetValue(CONFIG_TRACK_SENT_MAILS_NAME,
                    (Value ? 1 : 0), RegistryValueKind.DWord);
            }
            catch { }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();
        }
        #endregion
        #region TrackSentEmailsToken
        private string RegTrackSentEmailsToken()
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            string value = CONFIG_TRACK_SENT_MAILS_TOKEN_DEFAULT;

            try
            {
                value =
                        addInSwKey.GetValue(CONFIG_TRACK_SENT_MAILS_TOKEN_NAME,
                            CONFIG_TRACK_SENT_MAILS_TOKEN_DEFAULT) as String;
            }
            catch
            {
                value = null;
            }
            if (value == null)
                value = CONFIG_TRACK_SENT_MAILS_TOKEN_DEFAULT;

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();

            return value;
        }

        private void RegTrackSentEmailsToken(string Value)
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            try
            {
                addInSwKey.SetValue(CONFIG_TRACK_SENT_MAILS_TOKEN_NAME,
                    Value, RegistryValueKind.String);
            }
            catch { }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();
        }
        #endregion

        #region TrackReceivedEmails
        private bool RegTrackReceivedEmails()
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            bool value = CONFIG_TRACK_RECEIVED_MAILS_DEFAULT;

            try
            {
                value = (Convert.ToUInt32(addInSwKey.GetValue(CONFIG_TRACK_RECEIVED_MAILS_NAME,
                    CONFIG_TRACK_RECEIVED_MAILS_DEFAULT)) > 0);
            }
            catch
            {
                value = CONFIG_TRACK_RECEIVED_MAILS_DEFAULT;
            }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();

            return value;
        }

        private void RegTrackReceivedEmails(bool Value)
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            try
            {
                addInSwKey.SetValue(CONFIG_TRACK_RECEIVED_MAILS_NAME,
                    (Value ? 1 : 0), RegistryValueKind.DWord);
            }
            catch { }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();
        }
        #endregion
        #region TrackReceivedEmailsToken
        private string RegTrackReceivedEmailsToken()
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            string value = CONFIG_TRACK_RECEIVED_MAILS_TOKEN_DEFAULT;

            try
            {
                value =
                        addInSwKey.GetValue(CONFIG_TRACK_RECEIVED_MAILS_TOKEN_NAME,
                            CONFIG_TRACK_RECEIVED_MAILS_TOKEN_DEFAULT) as String;
            }
            catch
            {
                value = null;
            }
            if (value == null)
                value = CONFIG_TRACK_RECEIVED_MAILS_TOKEN_DEFAULT;

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();

            return value;
        }

        private void RegTrackReceivedEmailsToken(string Value)
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            try
            {
                addInSwKey.SetValue(CONFIG_TRACK_RECEIVED_MAILS_TOKEN_NAME,
                    Value, RegistryValueKind.String);
            }
            catch { }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();
        }
        #endregion

        #region ShowPopups
        private bool RegShowPopups()
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            bool value = CONFIG_SHOW_POPUPS_DEFAULT;

            try
            {
                value = (Convert.ToUInt32(addInSwKey.GetValue(CONFIG_SHOW_POPUPS_NAME,
                    CONFIG_SHOW_POPUPS_DEFAULT)) > 0);
            }
            catch
            {
                value = CONFIG_SHOW_POPUPS_DEFAULT;
            }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();

            return value;
        }

        private void RegShowPopups(bool Value)
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            try
            {
                addInSwKey.SetValue(CONFIG_SHOW_POPUPS_NAME,
                    (Value ? 1 : 0), RegistryValueKind.DWord);
            }
            catch { }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();
        }
        #endregion
        #region ShowDebug
        private bool RegShowDebug()
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            bool value = CONFIG_SHOW_DEBUG_DEFAULT;

            try
            {
                value = (Convert.ToUInt32(addInSwKey.GetValue(CONFIG_SHOW_DEBUG_NAME,
                    CONFIG_SHOW_DEBUG_DEFAULT)) > 0);
            }
            catch
            {
                value = CONFIG_SHOW_DEBUG_DEFAULT;
            }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();

            return value;
        }

        private void RegShowDebug(bool Value)
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            try
            {
                addInSwKey.SetValue(CONFIG_SHOW_DEBUG_NAME,
                    (Value ? 1 : 0), RegistryValueKind.DWord);
            }
            catch { }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();
        }
        #endregion
        #region ShowErrors
        private bool RegShowErrors()
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            bool value = CONFIG_SHOW_ERRORS_DEFAULT;

            try
            {
                value = (Convert.ToUInt32(addInSwKey.GetValue(CONFIG_SHOW_ERRORS_NAME,
                    CONFIG_SHOW_ERRORS_DEFAULT)) > 0);
            }
            catch
            {
                value = CONFIG_SHOW_ERRORS_DEFAULT;
            }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();

            return value;
        }

        private void RegShowErrors(bool Value)
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            try
            {
                addInSwKey.SetValue(CONFIG_SHOW_ERRORS_NAME,
                    (Value ? 1 : 0), RegistryValueKind.DWord);
            }
            catch { }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();
        }
        #endregion

        #region FolderExcludePattern
        private string RegFolderExcludePattern()
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            string value = CONFIG_FOLDER_EXCLUDE_PATTERN_DEFAULT;

            try
            {
                value =
                        addInSwKey.GetValue(CONFIG_FOLDER_EXCLUDE_PATTERN_NAME,
                            CONFIG_FOLDER_EXCLUDE_PATTERN_DEFAULT) as String;
            }
            catch
            {
                value = null;
            }
            if (value == null)
                value = CONFIG_FOLDER_EXCLUDE_PATTERN_DEFAULT;

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();

            return value;
        }

        private void RegFolderExcludePattern(string Value)
        {
            RegistryKey userSwKey = Registry.CurrentUser.OpenSubKey(REG_SOFTWARE_KEY_NAME, true);
            RegistryKey minSwKey = userSwKey.CreateSubKey(REG_COMPANY_KEY_NAME);
            RegistryKey addInSwKey = minSwKey.CreateSubKey(REG_PRODUCT_KEY_NAME);

            try
            {
                addInSwKey.SetValue(CONFIG_FOLDER_EXCLUDE_PATTERN_NAME,
                    Value, RegistryValueKind.String);
            }
            catch { }

            addInSwKey.Close();
            minSwKey.Close();
            userSwKey.Close();
        }
        #endregion

        #region CreateFolderExcludeRegex
        private Regex CreateFolderExcludeRegex(string ExcludePattern)
        {
            Regex excludeRegex = null;
            try
            {
                if (!String.IsNullOrWhiteSpace(ExcludePattern))
                    excludeRegex = new Regex(_configFolderExcludePattern,
                        RegexOptions.Singleline | RegexOptions.Compiled);
            }
            catch
            {
                excludeRegex = null;
            }

            return excludeRegex;
        }
        #endregion
        #endregion
    }
}
