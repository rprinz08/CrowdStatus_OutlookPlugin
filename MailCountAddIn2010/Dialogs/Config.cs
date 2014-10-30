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
    public partial class Config : Form
    {
        #region Ctor / Dtor
        public Config()
        {
            InitializeComponent();

            this.Text = String.Format("Configure {0}", Tools.AssemblyTitle);
        }
        #endregion

        #region Properties
        public string ApiUrl { get; set; }
        public DateTime LastSent { get; set; }
        public bool ShowDebugInfos { get; set; }
        public bool ShowInfos { get; set; }
        public bool ShowErrors { get; set; }
        #endregion
    }
}
