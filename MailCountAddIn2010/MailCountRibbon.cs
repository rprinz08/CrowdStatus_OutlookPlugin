﻿#region Usings
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
            Form f = new Dialogs.Config();
            f.ShowDialog();
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
        #endregion
    }
}