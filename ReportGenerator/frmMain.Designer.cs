namespace ReportGenerator
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSettings = new DevExpress.XtraBars.BarButtonItem();
            this.btnSirketKart = new DevExpress.XtraBars.BarButtonItem();
            this.btnRaporKart = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmailKart = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.staticUserName = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::ReportGenerator.WaitForm1), true, true);
            this.barBtnReportDesigner = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.AllowMinimizeRibbon = false;
            this.ribbon.CaptionBarItemLinks.Add(this.btnSettings);
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSettings,
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSirketKart,
            this.btnRaporKart,
            this.btnEmailKart,
            this.barButtonItem3,
            this.staticUserName,
            this.barBtnReportDesigner});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbon.Size = new System.Drawing.Size(1581, 193);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnSettings
            // 
            this.btnSettings.Caption = "Ayarlar";
            this.btnSettings.Id = 5;
            this.btnSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.ImageOptions.Image")));
            this.btnSettings.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.ImageOptions.LargeImage")));
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSettings_ItemClick);
            // 
            // btnSirketKart
            // 
            this.btnSirketKart.Caption = "Şirket";
            this.btnSirketKart.Id = 1;
            this.btnSirketKart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSirketKart.ImageOptions.Image")));
            this.btnSirketKart.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSirketKart.ImageOptions.LargeImage")));
            this.btnSirketKart.Name = "btnSirketKart";
            this.btnSirketKart.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnSirketKart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSirketKart_ItemClick);
            // 
            // btnRaporKart
            // 
            this.btnRaporKart.Caption = "Rapor";
            this.btnRaporKart.Id = 2;
            this.btnRaporKart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRaporKart.ImageOptions.Image")));
            this.btnRaporKart.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRaporKart.ImageOptions.LargeImage")));
            this.btnRaporKart.Name = "btnRaporKart";
            this.btnRaporKart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRaporKart_ItemClick);
            // 
            // btnEmailKart
            // 
            this.btnEmailKart.Caption = "Email";
            this.btnEmailKart.Id = 3;
            this.btnEmailKart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailKart.ImageOptions.Image")));
            this.btnEmailKart.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmailKart.ImageOptions.LargeImage")));
            this.btnEmailKart.Name = "btnEmailKart";
            this.btnEmailKart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmailKart_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Ayarlar";
            this.barButtonItem3.Id = 4;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // staticUserName
            // 
            this.staticUserName.Caption = "barStaticItem1";
            this.staticUserName.Id = 7;
            this.staticUserName.Name = "staticUserName";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Kartlar";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSirketKart);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRaporKart);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEmailKart);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnReportDesigner);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Ayarlar";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.staticUserName);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 760);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1581, 30);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // barBtnReportDesigner
            // 
            this.barBtnReportDesigner.Caption = "Rapor Tasarım";
            this.barBtnReportDesigner.Id = 8;
            this.barBtnReportDesigner.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnReportDesigner.ImageOptions.Image")));
            this.barBtnReportDesigner.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnReportDesigner.ImageOptions.LargeImage")));
            this.barBtnReportDesigner.Name = "barBtnReportDesigner";
            this.barBtnReportDesigner.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnReportDesigner_ItemClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1581, 790);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Raporman";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnSirketKart;
        private DevExpress.XtraBars.BarButtonItem btnRaporKart;
        private DevExpress.XtraBars.BarButtonItem btnEmailKart;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnSettings;
        private DevExpress.XtraBars.BarStaticItem staticUserName;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraBars.BarButtonItem barBtnReportDesigner;
    }
}