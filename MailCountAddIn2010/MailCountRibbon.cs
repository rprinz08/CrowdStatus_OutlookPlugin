using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace MailCountAddIn2010
{
    public partial class MailCountRibbon
    {
        private void MailCountRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnConfig_Click(object sender, RibbonControlEventArgs e)
        {
            MessageBox.Show("ribbon config");
        }

        private void btnAbout_Click(object sender, RibbonControlEventArgs e)
        {
            MessageBox.Show("ribbon about");
        }
    }
}
