#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace MailCountAddIn2010.Dialogs
{
    partial class About : Form
    {
        #region Ctor / Dtor
        public About()
        {
            InitializeComponent();

            this.Text = String.Format("About {0}", Tools.AssemblyTitle);
            this.labelProductName.Text = Tools.AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", Tools.AssemblyVersion);
            this.labelCopyright.Text = Tools.AssemblyCopyright;
            this.labelCompanyName.Text = Tools.AssemblyCompany;
            this.textBoxDescription.Text = Tools.AssemblyDescription;
            this.labelWebLink.Text = " See www.crowdstatus.net for more infos.";
            this.labelWebLink.Links.Add(5, 19, "http://www.crowdstatus.net/en");
        }
        #endregion

        #region Event Handler
        #region labelWebLink_LinkClicked
        private void labelWebLink_LinkClicked(object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
        #endregion
        #endregion
    }
}
