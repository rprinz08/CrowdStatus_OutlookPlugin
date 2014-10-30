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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblApiURL = new System.Windows.Forms.Label();
            this.lblLastSent = new System.Windows.Forms.Label();
            this.lblShow = new System.Windows.Forms.Label();
            this.chkShowDebug = new System.Windows.Forms.CheckBox();
            this.chkShowInfo = new System.Windows.Forms.CheckBox();
            this.chkShowErrors = new System.Windows.Forms.CheckBox();
            this.txtLastSent = new System.Windows.Forms.TextBox();
            this.txtApiUrl = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblApiURL, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLastSent, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblShow, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkShowDebug, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkShowInfo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkShowErrors, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtLastSent, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtApiUrl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(426, 197);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblApiURL
            // 
            this.lblApiURL.AutoSize = true;
            this.lblApiURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApiURL.Location = new System.Drawing.Point(3, 0);
            this.lblApiURL.Name = "lblApiURL";
            this.lblApiURL.Size = new System.Drawing.Size(94, 30);
            this.lblApiURL.TabIndex = 0;
            this.lblApiURL.Text = "API Url:";
            // 
            // lblLastSent
            // 
            this.lblLastSent.AutoSize = true;
            this.lblLastSent.Location = new System.Drawing.Point(3, 30);
            this.lblLastSent.Name = "lblLastSent";
            this.lblLastSent.Size = new System.Drawing.Size(53, 13);
            this.lblLastSent.TabIndex = 1;
            this.lblLastSent.Text = "Last sent:";
            // 
            // lblShow
            // 
            this.lblShow.AutoSize = true;
            this.lblShow.Location = new System.Drawing.Point(3, 60);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(37, 13);
            this.lblShow.TabIndex = 2;
            this.lblShow.Text = "Show:";
            // 
            // chkShowDebug
            // 
            this.chkShowDebug.AutoSize = true;
            this.chkShowDebug.Location = new System.Drawing.Point(103, 63);
            this.chkShowDebug.Name = "chkShowDebug";
            this.chkShowDebug.Size = new System.Drawing.Size(83, 17);
            this.chkShowDebug.TabIndex = 3;
            this.chkShowDebug.Text = "Debug infos";
            this.chkShowDebug.UseVisualStyleBackColor = true;
            // 
            // chkShowInfo
            // 
            this.chkShowInfo.AutoSize = true;
            this.chkShowInfo.Location = new System.Drawing.Point(103, 93);
            this.chkShowInfo.Name = "chkShowInfo";
            this.chkShowInfo.Size = new System.Drawing.Size(94, 17);
            this.chkShowInfo.TabIndex = 4;
            this.chkShowInfo.Text = "Info messages";
            this.chkShowInfo.UseVisualStyleBackColor = true;
            // 
            // chkShowErrors
            // 
            this.chkShowErrors.AutoSize = true;
            this.chkShowErrors.Location = new System.Drawing.Point(103, 123);
            this.chkShowErrors.Name = "chkShowErrors";
            this.chkShowErrors.Size = new System.Drawing.Size(53, 17);
            this.chkShowErrors.TabIndex = 5;
            this.chkShowErrors.Text = "Errors";
            this.chkShowErrors.UseVisualStyleBackColor = true;
            // 
            // txtLastSent
            // 
            this.txtLastSent.Location = new System.Drawing.Point(103, 33);
            this.txtLastSent.Name = "txtLastSent";
            this.txtLastSent.Size = new System.Drawing.Size(142, 20);
            this.txtLastSent.TabIndex = 6;
            // 
            // txtApiUrl
            // 
            this.txtApiUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtApiUrl.Location = new System.Drawing.Point(103, 3);
            this.txtApiUrl.Name = "txtApiUrl";
            this.txtApiUrl.Size = new System.Drawing.Size(320, 20);
            this.txtApiUrl.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnOK);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(103, 153);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(320, 41);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(242, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(161, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 31);
            this.button2.TabIndex = 1;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 202);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Config";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblApiURL;
        private System.Windows.Forms.Label lblLastSent;
        private System.Windows.Forms.Label lblShow;
        private System.Windows.Forms.CheckBox chkShowDebug;
        private System.Windows.Forms.CheckBox chkShowInfo;
        private System.Windows.Forms.CheckBox chkShowErrors;
        private System.Windows.Forms.TextBox txtLastSent;
        private System.Windows.Forms.TextBox txtApiUrl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button2;
    }
}