#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
#endregion

namespace MailCountAddIn2010
{
    public partial class MailCountRibbon
    {
        #region Event Handler
        #region MailCountRibbon
        #region Load
        private void MailCountRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }
        #endregion
        #endregion
        #region btnConfig
        #region Click
        private void btnConfig_Click(object sender, RibbonControlEventArgs e)
        {
            Config cfg = Config.Singleton;
            cfg.ReadConfig();

            Form f = new Dialogs.Config(cfg);
            DialogResult rc = f.ShowDialog();

            if (rc == DialogResult.OK)
                cfg.WriteConfig();
        }
        #endregion
        #endregion
        #region btnAbout
        #region Click
        private void btnAbout_Click(object sender, RibbonControlEventArgs e)
        {
            Form f = new Dialogs.About();
            f.ShowDialog();
        }
        #endregion
        #endregion
        #region btnResults
        #region Click
        private void btnResults_Click(object sender, RibbonControlEventArgs e)
        {
            Form f = new Dialogs.Results();
            f.ShowDialog();
        }
        #endregion
        #endregion
        #endregion
    }
}
