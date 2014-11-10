using System;
using System.Collections.Generic;
using System.ComponentModel;
#region Usings
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
                MailCountAddIn2010.Config cfg = new MailCountAddIn2010.Config();
                Uri u = new Uri(new Uri(cfg.ApiUri), "en/" + cfg.TrackReceivedEmailsToken + "?v=widget");
                webBrowser1.Navigate(u);
            }
            catch { }
        }
        #endregion
        #endregion
        #endregion
    }
}
