#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace MailCountAddIn2010.Dialogs
{
    public partial class Results : Form
    {
        #region Variables
        private MailCountAddIn2010.Config _cfg;
        #endregion

        #region Ctor / Dtor
        public Results()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler
        #region Form
        #region Load
        private void Results_Load(object sender, EventArgs e)
        {
            try
            {
                _cfg = MailCountAddIn2010.Config.Singleton;
                webBrowser1.ScriptErrorsSuppressed = !_cfg.ShowErrors;

                Uri u = new Uri(new Uri(_cfg.ApiUri), "en/" +
                        _cfg.TrackReceivedEmailsToken + "?v=widget");

                if (_cfg.ShowDebug)
                    MessageBox.Show(String.Format(
                            "Show received e-mails result widget from URL {0}", u),
                        MailCountAddIn2010.Config.PROD_SHORT_NAME,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                webBrowser1.Navigate(u);
            }
            catch (System.Exception ex)
            {
                if (_cfg.ShowErrors)
                    MessageBox.Show("Error occurred while showing results\r\n\r\n" +
                            ex.ToString(),
                        MailCountAddIn2010.Config.PROD_SHORT_NAME + " error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #endregion
        #endregion
    }
}
