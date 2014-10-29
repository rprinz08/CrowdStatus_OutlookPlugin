namespace MailCountAddIn2010
{
    partial class MailCountRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MailCountRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabMailCount = this.Factory.CreateRibbonTab();
            this.tabGrpMailCount = this.Factory.CreateRibbonGroup();
            this.btnConfig = this.Factory.CreateRibbonButton();
            this.btnAbout = this.Factory.CreateRibbonButton();
            this.tabMailCount.SuspendLayout();
            this.tabGrpMailCount.SuspendLayout();
            // 
            // tabMailCount
            // 
            this.tabMailCount.Groups.Add(this.tabGrpMailCount);
            this.tabMailCount.Label = "Crowd Source";
            this.tabMailCount.Name = "tabMailCount";
            // 
            // tabGrpMailCount
            // 
            this.tabGrpMailCount.Items.Add(this.btnConfig);
            this.tabGrpMailCount.Items.Add(this.btnAbout);
            this.tabGrpMailCount.Label = "Mail-Count";
            this.tabGrpMailCount.Name = "tabGrpMailCount";
            // 
            // btnConfig
            // 
            this.btnConfig.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnConfig.Description = "Configure MailCount plugin";
            this.btnConfig.Image = global::MailCountAddIn2010.Properties.Resources.CsMailCountLogo;
            this.btnConfig.Label = "Configure";
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.ScreenTip = "Configure Mail-Count plugin";
            this.btnConfig.ShowImage = true;
            this.btnConfig.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConfig_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnAbout.Description = "About MailCount plugin";
            this.btnAbout.Image = global::MailCountAddIn2010.Properties.Resources.CsMailCounAboutIcon;
            this.btnAbout.Label = "About";
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ScreenTip = "Show additional infos about the Mail-Count plugin";
            this.btnAbout.ShowImage = true;
            this.btnAbout.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAbout_Click);
            // 
            // MailCountRibbon
            // 
            this.Name = "MailCountRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tabMailCount);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MailCountRibbon_Load);
            this.tabMailCount.ResumeLayout(false);
            this.tabMailCount.PerformLayout();
            this.tabGrpMailCount.ResumeLayout(false);
            this.tabGrpMailCount.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabMailCount;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup tabGrpMailCount;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConfig;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAbout;
    }

    partial class ThisRibbonCollection
    {
        internal MailCountRibbon MailCountRibbon
        {
            get { return this.GetRibbon<MailCountRibbon>(); }
        }
    }
}
