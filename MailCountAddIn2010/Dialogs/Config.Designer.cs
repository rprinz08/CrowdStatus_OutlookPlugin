namespace MailCountAddIn2010.Dialogs
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label apiUriLabel;
            System.Windows.Forms.Label folderExcludePatternLabel;
            System.Windows.Forms.Label lastSentLabel;
            System.Windows.Forms.Label lastSentEmailsLabel;
            System.Windows.Forms.Label lastReceivedEmailsLabel;
            System.Windows.Forms.Label showDebugLabel;
            System.Windows.Forms.Label trackReceivedEmailsLabel;
            System.Windows.Forms.Label trackSentEmailsLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.apiUriTextBox = new System.Windows.Forms.TextBox();
            this.folderExcludePatternTextBox = new System.Windows.Forms.TextBox();
            this.lastSentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lastSentEmailsTextBox = new System.Windows.Forms.TextBox();
            this.lastReceivedEmailsTextBox = new System.Windows.Forms.TextBox();
            this.showDebugCheckBox = new System.Windows.Forms.CheckBox();
            this.showErrorsCheckBox = new System.Windows.Forms.CheckBox();
            this.showPopupsCheckBox = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dataFromLabel = new System.Windows.Forms.Label();
            this.trackReceivedEmailsCheckBox = new System.Windows.Forms.CheckBox();
            this.trackReceivedEmailsTokenTextBox = new System.Windows.Forms.TextBox();
            this.trackSentEmailsCheckBox = new System.Windows.Forms.CheckBox();
            this.trackSentEmailsTokenTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.configBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lastDateTextBox = new System.Windows.Forms.TextBox();
            apiUriLabel = new System.Windows.Forms.Label();
            folderExcludePatternLabel = new System.Windows.Forms.Label();
            lastSentLabel = new System.Windows.Forms.Label();
            lastSentEmailsLabel = new System.Windows.Forms.Label();
            lastReceivedEmailsLabel = new System.Windows.Forms.Label();
            showDebugLabel = new System.Windows.Forms.Label();
            trackReceivedEmailsLabel = new System.Windows.Forms.Label();
            trackSentEmailsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // apiUriLabel
            // 
            apiUriLabel.AutoSize = true;
            apiUriLabel.Location = new System.Drawing.Point(7, 11);
            apiUriLabel.Name = "apiUriLabel";
            apiUriLabel.Size = new System.Drawing.Size(41, 13);
            apiUriLabel.TabIndex = 0;
            apiUriLabel.Text = "Api &Uri:";
            // 
            // folderExcludePatternLabel
            // 
            folderExcludePatternLabel.AutoSize = true;
            folderExcludePatternLabel.Location = new System.Drawing.Point(7, 37);
            folderExcludePatternLabel.Name = "folderExcludePatternLabel";
            folderExcludePatternLabel.Size = new System.Drawing.Size(117, 13);
            folderExcludePatternLabel.TabIndex = 2;
            folderExcludePatternLabel.Text = "Folder Exclude &Pattern:";
            // 
            // lastSentLabel
            // 
            lastSentLabel.AutoSize = true;
            lastSentLabel.Location = new System.Drawing.Point(7, 66);
            lastSentLabel.Name = "lastSentLabel";
            lastSentLabel.Size = new System.Drawing.Size(70, 13);
            lastSentLabel.TabIndex = 4;
            lastSentLabel.Text = "Last &Sent on:";
            // 
            // lastSentEmailsLabel
            // 
            lastSentEmailsLabel.AutoSize = true;
            lastSentEmailsLabel.Location = new System.Drawing.Point(7, 117);
            lastSentEmailsLabel.Name = "lastSentEmailsLabel";
            lastSentEmailsLabel.Size = new System.Drawing.Size(88, 13);
            lastSentEmailsLabel.TabIndex = 8;
            lastSentEmailsLabel.Text = "Last Sent &Emails:";
            // 
            // lastReceivedEmailsLabel
            // 
            lastReceivedEmailsLabel.AutoSize = true;
            lastReceivedEmailsLabel.Location = new System.Drawing.Point(7, 143);
            lastReceivedEmailsLabel.Name = "lastReceivedEmailsLabel";
            lastReceivedEmailsLabel.Size = new System.Drawing.Size(112, 13);
            lastReceivedEmailsLabel.TabIndex = 10;
            lastReceivedEmailsLabel.Text = "Last &Received Emails:";
            // 
            // showDebugLabel
            // 
            showDebugLabel.AutoSize = true;
            showDebugLabel.Location = new System.Drawing.Point(7, 184);
            showDebugLabel.Name = "showDebugLabel";
            showDebugLabel.Size = new System.Drawing.Size(37, 13);
            showDebugLabel.TabIndex = 12;
            showDebugLabel.Text = "Show:";
            // 
            // trackReceivedEmailsLabel
            // 
            trackReceivedEmailsLabel.AutoSize = true;
            trackReceivedEmailsLabel.Location = new System.Drawing.Point(7, 238);
            trackReceivedEmailsLabel.Name = "trackReceivedEmailsLabel";
            trackReceivedEmailsLabel.Size = new System.Drawing.Size(120, 13);
            trackReceivedEmailsLabel.TabIndex = 19;
            trackReceivedEmailsLabel.Text = "&Track Received Emails:";
            // 
            // trackSentEmailsLabel
            // 
            trackSentEmailsLabel.AutoSize = true;
            trackSentEmailsLabel.Location = new System.Drawing.Point(7, 212);
            trackSentEmailsLabel.Name = "trackSentEmailsLabel";
            trackSentEmailsLabel.Size = new System.Drawing.Size(96, 13);
            trackSentEmailsLabel.TabIndex = 16;
            trackSentEmailsLabel.Text = "Tra&ck Sent Emails:";
            // 
            // apiUriTextBox
            // 
            this.apiUriTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configBindingSource, "ApiUri", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.apiUriTextBox.Location = new System.Drawing.Point(149, 8);
            this.apiUriTextBox.Name = "apiUriTextBox";
            this.apiUriTextBox.Size = new System.Drawing.Size(346, 20);
            this.apiUriTextBox.TabIndex = 1;
            this.apiUriTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.apiUriTextBox_Validating);
            // 
            // folderExcludePatternTextBox
            // 
            this.folderExcludePatternTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configBindingSource, "FolderExcludePattern", true));
            this.folderExcludePatternTextBox.Location = new System.Drawing.Point(149, 34);
            this.folderExcludePatternTextBox.Name = "folderExcludePatternTextBox";
            this.folderExcludePatternTextBox.Size = new System.Drawing.Size(346, 20);
            this.folderExcludePatternTextBox.TabIndex = 3;
            this.folderExcludePatternTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.folderExcludePatternTextBox_Validating);
            // 
            // lastSentDateTimePicker
            // 
            this.lastSentDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.configBindingSource, "LastSent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "d"));
            this.lastSentDateTimePicker.Location = new System.Drawing.Point(149, 60);
            this.lastSentDateTimePicker.Name = "lastSentDateTimePicker";
            this.lastSentDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.lastSentDateTimePicker.TabIndex = 5;
            // 
            // lastSentEmailsTextBox
            // 
            this.lastSentEmailsTextBox.CausesValidation = false;
            this.lastSentEmailsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configBindingSource, "LastSentEmails", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N0"));
            this.lastSentEmailsTextBox.Location = new System.Drawing.Point(149, 114);
            this.lastSentEmailsTextBox.Name = "lastSentEmailsTextBox";
            this.lastSentEmailsTextBox.ReadOnly = true;
            this.lastSentEmailsTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastSentEmailsTextBox.TabIndex = 9;
            this.lastSentEmailsTextBox.Text = "0";
            // 
            // lastReceivedEmailsTextBox
            // 
            this.lastReceivedEmailsTextBox.CausesValidation = false;
            this.lastReceivedEmailsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configBindingSource, "LastReceivedEmails", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N0"));
            this.lastReceivedEmailsTextBox.Location = new System.Drawing.Point(149, 140);
            this.lastReceivedEmailsTextBox.Name = "lastReceivedEmailsTextBox";
            this.lastReceivedEmailsTextBox.ReadOnly = true;
            this.lastReceivedEmailsTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastReceivedEmailsTextBox.TabIndex = 11;
            this.lastReceivedEmailsTextBox.Text = "0";
            // 
            // showDebugCheckBox
            // 
            this.showDebugCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.configBindingSource, "ShowDebug", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.showDebugCheckBox.Location = new System.Drawing.Point(149, 179);
            this.showDebugCheckBox.Name = "showDebugCheckBox";
            this.showDebugCheckBox.Size = new System.Drawing.Size(64, 24);
            this.showDebugCheckBox.TabIndex = 13;
            this.showDebugCheckBox.Text = "&Debug";
            this.showDebugCheckBox.UseVisualStyleBackColor = true;
            // 
            // showErrorsCheckBox
            // 
            this.showErrorsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.configBindingSource, "ShowErrors", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.showErrorsCheckBox.Location = new System.Drawing.Point(216, 179);
            this.showErrorsCheckBox.Name = "showErrorsCheckBox";
            this.showErrorsCheckBox.Size = new System.Drawing.Size(55, 24);
            this.showErrorsCheckBox.TabIndex = 14;
            this.showErrorsCheckBox.Text = "Err&ors";
            this.showErrorsCheckBox.UseVisualStyleBackColor = true;
            // 
            // showPopupsCheckBox
            // 
            this.showPopupsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.configBindingSource, "ShowPopups", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.showPopupsCheckBox.Location = new System.Drawing.Point(277, 179);
            this.showPopupsCheckBox.Name = "showPopupsCheckBox";
            this.showPopupsCheckBox.Size = new System.Drawing.Size(72, 24);
            this.showPopupsCheckBox.TabIndex = 15;
            this.showPopupsCheckBox.Text = "Pop&ups";
            this.showPopupsCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(420, 287);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(339, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dataFromLabel
            // 
            this.dataFromLabel.AutoSize = true;
            this.dataFromLabel.Location = new System.Drawing.Point(7, 92);
            this.dataFromLabel.Name = "dataFromLabel";
            this.dataFromLabel.Size = new System.Drawing.Size(56, 13);
            this.dataFromLabel.TabIndex = 6;
            this.dataFromLabel.Text = "Data from:";
            // 
            // trackReceivedEmailsCheckBox
            // 
            this.trackReceivedEmailsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.configBindingSource, "TrackReceivedEmails", true));
            this.trackReceivedEmailsCheckBox.Location = new System.Drawing.Point(149, 233);
            this.trackReceivedEmailsCheckBox.Name = "trackReceivedEmailsCheckBox";
            this.trackReceivedEmailsCheckBox.Size = new System.Drawing.Size(20, 24);
            this.trackReceivedEmailsCheckBox.TabIndex = 20;
            this.trackReceivedEmailsCheckBox.UseVisualStyleBackColor = true;
            this.trackReceivedEmailsCheckBox.CheckedChanged += new System.EventHandler(this.trackReceivedEmailsCheckBox_CheckedChanged);
            // 
            // trackReceivedEmailsTokenTextBox
            // 
            this.trackReceivedEmailsTokenTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configBindingSource, "TrackReceivedEmailsToken", true));
            this.trackReceivedEmailsTokenTextBox.Location = new System.Drawing.Point(175, 235);
            this.trackReceivedEmailsTokenTextBox.Name = "trackReceivedEmailsTokenTextBox";
            this.trackReceivedEmailsTokenTextBox.Size = new System.Drawing.Size(157, 20);
            this.trackReceivedEmailsTokenTextBox.TabIndex = 21;
            this.trackReceivedEmailsTokenTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.trackReceivedEmailsTokenTextBox_Validating);
            // 
            // trackSentEmailsCheckBox
            // 
            this.trackSentEmailsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.configBindingSource, "TrackSentEmails", true));
            this.trackSentEmailsCheckBox.Location = new System.Drawing.Point(149, 207);
            this.trackSentEmailsCheckBox.Name = "trackSentEmailsCheckBox";
            this.trackSentEmailsCheckBox.Size = new System.Drawing.Size(20, 24);
            this.trackSentEmailsCheckBox.TabIndex = 17;
            this.trackSentEmailsCheckBox.UseVisualStyleBackColor = true;
            this.trackSentEmailsCheckBox.CheckedChanged += new System.EventHandler(this.trackSentEmailsCheckBox_CheckedChanged);
            // 
            // trackSentEmailsTokenTextBox
            // 
            this.trackSentEmailsTokenTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configBindingSource, "TrackSentEmailsToken", true));
            this.trackSentEmailsTokenTextBox.Location = new System.Drawing.Point(175, 209);
            this.trackSentEmailsTokenTextBox.Name = "trackSentEmailsTokenTextBox";
            this.trackSentEmailsTokenTextBox.Size = new System.Drawing.Size(157, 20);
            this.trackSentEmailsTokenTextBox.TabIndex = 18;
            this.trackSentEmailsTokenTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.trackSentEmailsTokenTextBox_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // configBindingSource
            // 
            this.configBindingSource.DataSource = typeof(MailCountAddIn2010.Config);
            // 
            // lastDateTextBox
            // 
            this.lastDateTextBox.CausesValidation = false;
            this.lastDateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configBindingSource, "LastDate", true));
            this.lastDateTextBox.Location = new System.Drawing.Point(149, 88);
            this.lastDateTextBox.Name = "lastDateTextBox";
            this.lastDateTextBox.ReadOnly = true;
            this.lastDateTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastDateTextBox.TabIndex = 25;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 328);
            this.Controls.Add(this.lastDateTextBox);
            this.Controls.Add(this.trackSentEmailsTokenTextBox);
            this.Controls.Add(trackSentEmailsLabel);
            this.Controls.Add(this.trackSentEmailsCheckBox);
            this.Controls.Add(this.trackReceivedEmailsTokenTextBox);
            this.Controls.Add(trackReceivedEmailsLabel);
            this.Controls.Add(this.trackReceivedEmailsCheckBox);
            this.Controls.Add(this.dataFromLabel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.showPopupsCheckBox);
            this.Controls.Add(this.showErrorsCheckBox);
            this.Controls.Add(showDebugLabel);
            this.Controls.Add(this.showDebugCheckBox);
            this.Controls.Add(lastReceivedEmailsLabel);
            this.Controls.Add(this.lastReceivedEmailsTextBox);
            this.Controls.Add(lastSentEmailsLabel);
            this.Controls.Add(this.lastSentEmailsTextBox);
            this.Controls.Add(lastSentLabel);
            this.Controls.Add(this.lastSentDateTimePicker);
            this.Controls.Add(folderExcludePatternLabel);
            this.Controls.Add(this.folderExcludePatternTextBox);
            this.Controls.Add(apiUriLabel);
            this.Controls.Add(this.apiUriTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Config_FormClosing);
            this.Load += new System.EventHandler(this.Config_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource configBindingSource;
        private System.Windows.Forms.TextBox apiUriTextBox;
        private System.Windows.Forms.TextBox folderExcludePatternTextBox;
        private System.Windows.Forms.DateTimePicker lastSentDateTimePicker;
        private System.Windows.Forms.TextBox lastSentEmailsTextBox;
        private System.Windows.Forms.TextBox lastReceivedEmailsTextBox;
        private System.Windows.Forms.CheckBox showDebugCheckBox;
        private System.Windows.Forms.CheckBox showErrorsCheckBox;
        private System.Windows.Forms.CheckBox showPopupsCheckBox;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label dataFromLabel;
        private System.Windows.Forms.CheckBox trackReceivedEmailsCheckBox;
        private System.Windows.Forms.TextBox trackReceivedEmailsTokenTextBox;
        private System.Windows.Forms.CheckBox trackSentEmailsCheckBox;
        private System.Windows.Forms.TextBox trackSentEmailsTokenTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox lastDateTextBox;
    }
}