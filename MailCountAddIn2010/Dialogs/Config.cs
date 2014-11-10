#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace MailCountAddIn2010.Dialogs
{
    public partial class Config : Form
    {
        #region Variables
        MailCountAddIn2010.Config _configuration;
        #endregion

        #region Ctor / Dtor
        public Config(MailCountAddIn2010.Config Configuration)
        {
            _configuration = Configuration;
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

        #region Event Handler
        #region Form
        #region Load
        private void Config_Load(object sender, EventArgs e)
        {
            configBindingSource.DataSource = _configuration;
        }
        #endregion
        #region FormClosing
        private void Config_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                e.Cancel = true;
        }
        #endregion
        #endregion

        #region btnOK_Click
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Validate())
                this.DialogResult = DialogResult.None;
        }
        #endregion

        #region apiUriTextBox_Validating
        private void apiUriTextBox_Validating(object sender, CancelEventArgs e)
        {
            string error = null;
            try
            {
                Uri u = new Uri(apiUriTextBox.Text);
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                error = "Invalid URL.";
            }
            errorProvider1.SetError((Control)sender, error);
        }
        #endregion
        #region folderExcludePatternTextBox_Validating
        private void folderExcludePatternTextBox_Validating(object sender, CancelEventArgs e)
        {
            string error = null;

            folderExcludePatternTextBox.Text = folderExcludePatternTextBox.Text.Trim();
            if (String.IsNullOrWhiteSpace(folderExcludePatternTextBox.Text))
            {
                errorProvider1.SetError((Control)sender, error);
                return;
            }

            try
            {
                Regex r = new Regex(folderExcludePatternTextBox.Text);
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                error = "Invalid regular expression.";
            }
            errorProvider1.SetError((Control)sender, error);
        }
        #endregion
        #region trackSentEmailsTokenTextBox_Validating
        private void trackSentEmailsTokenTextBox_Validating(object sender, CancelEventArgs e)
        {
            string error = null;
            if (!trackSentEmailsCheckBox.Checked)
            {
                errorProvider1.SetError((Control)sender, error);
                return;
            }

            trackSentEmailsTokenTextBox.Text = trackSentEmailsTokenTextBox.Text.Trim();
            if (String.IsNullOrWhiteSpace(trackSentEmailsTokenTextBox.Text))
                error = "If track sent emails is checked a crowd status question token must be entered.";

            errorProvider1.SetError((Control)sender, error);
        }
        #endregion
        #region trackReceivedEmailsTokenTextBox_Validating
        private void trackReceivedEmailsTokenTextBox_Validating(object sender, CancelEventArgs e)
        {
            string error = null;
            if (!trackReceivedEmailsCheckBox.Checked)
            {
                errorProvider1.SetError((Control)sender, error);
                return;
            }

            trackReceivedEmailsTokenTextBox.Text = trackReceivedEmailsTokenTextBox.Text.Trim();
            if (String.IsNullOrWhiteSpace(trackReceivedEmailsTokenTextBox.Text))
                error = "If track received emails is checked a crowd status question token must be entered.";

            errorProvider1.SetError((Control)sender, error);
        }
        #endregion
        #region trackSentEmailsCheckBox_CheckedChanged
        private void trackSentEmailsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            trackSentEmailsTokenTextBox.ReadOnly = !trackSentEmailsCheckBox.Checked;
            ValidateControl(trackSentEmailsTokenTextBox);
        }
        #endregion
        #region trackReceivedEmailsCheckBox_CheckedChanged
        private void trackReceivedEmailsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            trackReceivedEmailsTokenTextBox.ReadOnly = !trackReceivedEmailsCheckBox.Checked;
            ValidateControl(trackReceivedEmailsTokenTextBox);
        }
        #endregion
        #endregion

        #region Private Methods
        #region ValidateControl
        private void ValidateControl(Control control)
        {
            Type type = control.GetType();
            type.InvokeMember("PerformControlValidation", 
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, 
                null, control, new object[] { true });
        }
        #endregion
        #endregion
    }
}
