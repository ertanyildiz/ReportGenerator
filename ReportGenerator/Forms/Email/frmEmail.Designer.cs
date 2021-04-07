namespace ReportGenerator.Forms.Email
{
    partial class frmEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmail));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gcListe = new DevExpress.XtraGrid.GridControl();
            this.gvListe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnKaydet = new DevExpress.XtraBars.BarButtonItem();
            this.btnSil = new DevExpress.XtraBars.BarButtonItem();
            this.btnYeni = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.comboSSL = new System.Windows.Forms.ComboBox();
            this.gleSirket = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMailAdresi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtSunucuAdi = new System.Windows.Forms.TextBox();
            this.txtKimden = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::ReportGenerator.WaitForm1), true, true);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleSirket.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1063, 631);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gcListe);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(640, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 623);
            this.panel2.TabIndex = 1;
            // 
            // gcListe
            // 
            this.gcListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcListe.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcListe.Location = new System.Drawing.Point(0, 0);
            this.gcListe.MainView = this.gvListe;
            this.gcListe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcListe.MenuManager = this.barManager1;
            this.gcListe.Name = "gcListe";
            this.gcListe.Size = new System.Drawing.Size(420, 623);
            this.gcListe.TabIndex = 0;
            this.gcListe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvListe});
            // 
            // gvListe
            // 
            this.gvListe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gvListe.DetailHeight = 431;
            this.gvListe.GridControl = this.gcListe;
            this.gvListe.Name = "gvListe";
            this.gvListe.OptionsBehavior.Editable = false;
            this.gvListe.OptionsView.ShowAutoFilterRow = true;
            this.gvListe.OptionsView.ShowGroupPanel = false;
            this.gvListe.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvListe_RowClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.MinWidth = 23;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 87;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Şirket Adı";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.MinWidth = 23;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 87;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Email Adresi";
            this.gridColumn3.FieldName = "MailAddress";
            this.gridColumn3.MinWidth = 23;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 87;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnKaydet,
            this.btnSil,
            this.btnYeni});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnKaydet),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSil),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnYeni, true)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Caption = "Kaydet";
            this.btnKaydet.Id = 0;
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.LargeImage")));
            this.btnKaydet.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnKaydet.ShortcutKeyDisplayString = "CTRL+S";
            this.btnKaydet.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.btnKaydet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKaydet_ItemClick);
            // 
            // btnSil
            // 
            this.btnSil.Caption = "Sil";
            this.btnSil.Id = 1;
            this.btnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.Image")));
            this.btnSil.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.LargeImage")));
            this.btnSil.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.btnSil.Name = "btnSil";
            this.btnSil.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSil.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSil_ItemClick);
            // 
            // btnYeni
            // 
            this.btnYeni.Caption = "Yeni";
            this.btnYeni.Id = 2;
            this.btnYeni.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYeni.ImageOptions.Image")));
            this.btnYeni.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnYeni.ImageOptions.LargeImage")));
            this.btnYeni.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnYeni.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnYeni_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1063, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 661);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1063, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 631);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1063, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 631);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.comboSSL);
            this.panel1.Controls.Add(this.gleSirket);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtMailAdresi);
            this.panel1.Controls.Add(this.txtSifre);
            this.panel1.Controls.Add(this.txtSunucuAdi);
            this.panel1.Controls.Add(this.txtKimden);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 623);
            this.panel1.TabIndex = 0;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(188, 213);
            this.txtPort.MenuManager = this.barManager1;
            this.txtPort.Name = "txtPort";
            this.txtPort.Properties.Mask.EditMask = "d";
            this.txtPort.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPort.Size = new System.Drawing.Size(361, 22);
            this.txtPort.TabIndex = 6;
            // 
            // comboSSL
            // 
            this.comboSSL.FormattingEnabled = true;
            this.comboSSL.Items.AddRange(new object[] {
            "true",
            "false"});
            this.comboSSL.Location = new System.Drawing.Point(188, 251);
            this.comboSSL.Name = "comboSSL";
            this.comboSSL.Size = new System.Drawing.Size(361, 24);
            this.comboSSL.TabIndex = 7;
            // 
            // gleSirket
            // 
            this.gleSirket.EditValue = "";
            this.gleSirket.Location = new System.Drawing.Point(188, 19);
            this.gleSirket.MenuManager = this.barManager1;
            this.gleSirket.Name = "gleSirket";
            this.gleSirket.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleSirket.Properties.NullText = "";
            this.gleSirket.Properties.PopupView = this.gridView2;
            this.gleSirket.Size = new System.Drawing.Size(362, 22);
            this.gleSirket.TabIndex = 0;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Id";
            this.gridColumn7.FieldName = "Id";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Şirket Adı";
            this.gridColumn8.FieldName = "Name";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Şirket";
            // 
            // txtMailAdresi
            // 
            this.txtMailAdresi.Location = new System.Drawing.Point(188, 57);
            this.txtMailAdresi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMailAdresi.Name = "txtMailAdresi";
            this.txtMailAdresi.Size = new System.Drawing.Size(361, 23);
            this.txtMailAdresi.TabIndex = 1;
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(188, 174);
            this.txtSifre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(361, 23);
            this.txtSifre.TabIndex = 5;
            // 
            // txtSunucuAdi
            // 
            this.txtSunucuAdi.Location = new System.Drawing.Point(188, 135);
            this.txtSunucuAdi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSunucuAdi.Name = "txtSunucuAdi";
            this.txtSunucuAdi.Size = new System.Drawing.Size(361, 23);
            this.txtSunucuAdi.TabIndex = 3;
            // 
            // txtKimden
            // 
            this.txtKimden.Location = new System.Drawing.Point(188, 96);
            this.txtKimden.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKimden.Name = "txtKimden";
            this.txtKimden.Size = new System.Drawing.Size(361, 23);
            this.txtKimden.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "SSL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Sunucu Adı";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Şifre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Kimden";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mail Adresi";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // frmEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 661);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::ReportGenerator.Properties.Resources.giza_son_logo_C3G_icon;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmEmail";
            this.Text = "Email Tanımları";
            this.Load += new System.EventHandler(this.frmCompany_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleSirket.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtKimden;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnKaydet;
        private DevExpress.XtraBars.BarButtonItem btnSil;
        private DevExpress.XtraBars.BarButtonItem btnYeni;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gcListe;
        private DevExpress.XtraGrid.Views.Grid.GridView gvListe;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.TextBox txtMailAdresi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.GridLookUpEdit gleSirket;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSunucuAdi;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtPort;
        private System.Windows.Forms.ComboBox comboSSL;
        private System.Windows.Forms.Label label8;
    }
}