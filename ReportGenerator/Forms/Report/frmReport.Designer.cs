﻿namespace ReportGenerator.Forms.Report
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
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
            this.btnRaporTest = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboGunlerMultiSelect = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.comboDosyaTipi = new System.Windows.Forms.ComboBox();
            this.gleSirket = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtpSaat = new System.Windows.Forms.DateTimePicker();
            this.txtMailAciklama = new System.Windows.Forms.RichTextBox();
            this.txtSorguRichTextBox = new System.Windows.Forms.RichTextBox();
            this.txtKimeBCCRichTextBox = new System.Windows.Forms.RichTextBox();
            this.txtKimeRichTextBox = new System.Windows.Forms.RichTextBox();
            this.txtRaporTasarimDosyasi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRaporGrupAdi = new System.Windows.Forms.TextBox();
            this.txtRapor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::ReportGenerator.WaitForm1), true, true);
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboGunlerMultiSelect.Properties)).BeginInit();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1063, 910);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gcListe);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(640, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 902);
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
            this.gcListe.Size = new System.Drawing.Size(420, 902);
            this.gcListe.TabIndex = 0;
            this.gcListe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvListe});
            // 
            // gvListe
            // 
            this.gvListe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn6,
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
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.MinWidth = 23;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 87;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Rapor Adı";
            this.gridColumn2.FieldName = "ReportName";
            this.gridColumn2.MinWidth = 23;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 87;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Şirket Adı";
            this.gridColumn3.FieldName = "Name";
            this.gridColumn3.MinWidth = 23;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
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
            this.btnYeni,
            this.btnRaporTest});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnKaydet, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSil),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnYeni, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRaporTest, true)});
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
            // btnRaporTest
            // 
            this.btnRaporTest.Caption = "Test";
            this.btnRaporTest.Id = 3;
            this.btnRaporTest.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRaporTest.ImageOptions.Image")));
            this.btnRaporTest.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRaporTest.ImageOptions.LargeImage")));
            this.btnRaporTest.Name = "btnRaporTest";
            this.btnRaporTest.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnRaporTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRaporTest_ItemClick);
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 940);
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
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 910);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1063, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 910);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboGunlerMultiSelect);
            this.panel1.Controls.Add(this.comboDosyaTipi);
            this.panel1.Controls.Add(this.gleSirket);
            this.panel1.Controls.Add(this.dtpSaat);
            this.panel1.Controls.Add(this.txtMailAciklama);
            this.panel1.Controls.Add(this.txtSorguRichTextBox);
            this.panel1.Controls.Add(this.txtKimeBCCRichTextBox);
            this.panel1.Controls.Add(this.txtKimeRichTextBox);
            this.panel1.Controls.Add(this.txtRaporTasarimDosyasi);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtRaporGrupAdi);
            this.panel1.Controls.Add(this.txtRapor);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 902);
            this.panel1.TabIndex = 0;
            // 
            // comboGunlerMultiSelect
            // 
            this.comboGunlerMultiSelect.Location = new System.Drawing.Point(188, 328);
            this.comboGunlerMultiSelect.MenuManager = this.barManager1;
            this.comboGunlerMultiSelect.Name = "comboGunlerMultiSelect";
            this.comboGunlerMultiSelect.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboGunlerMultiSelect.Size = new System.Drawing.Size(361, 22);
            this.comboGunlerMultiSelect.TabIndex = 5;
            // 
            // comboDosyaTipi
            // 
            this.comboDosyaTipi.FormattingEnabled = true;
            this.comboDosyaTipi.Items.AddRange(new object[] {
            "PDF",
            "Excel"});
            this.comboDosyaTipi.Location = new System.Drawing.Point(188, 571);
            this.comboDosyaTipi.Name = "comboDosyaTipi";
            this.comboDosyaTipi.Size = new System.Drawing.Size(362, 24);
            this.comboDosyaTipi.TabIndex = 9;
            // 
            // gleSirket
            // 
            this.gleSirket.EditValue = "";
            this.gleSirket.Location = new System.Drawing.Point(188, 28);
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
            this.gridColumn4,
            this.gridColumn5});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Id";
            this.gridColumn4.FieldName = "Id";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Şirket Adı";
            this.gridColumn5.FieldName = "Name";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // dtpSaat
            // 
            this.dtpSaat.CustomFormat = "HH:mm";
            this.dtpSaat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSaat.Location = new System.Drawing.Point(188, 370);
            this.dtpSaat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpSaat.Name = "dtpSaat";
            this.dtpSaat.ShowUpDown = true;
            this.dtpSaat.Size = new System.Drawing.Size(361, 23);
            this.dtpSaat.TabIndex = 6;
            // 
            // txtMailAciklama
            // 
            this.txtMailAciklama.Location = new System.Drawing.Point(188, 492);
            this.txtMailAciklama.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMailAciklama.Name = "txtMailAciklama";
            this.txtMailAciklama.Size = new System.Drawing.Size(361, 59);
            this.txtMailAciklama.TabIndex = 8;
            this.txtMailAciklama.Text = "";
            // 
            // txtSorguRichTextBox
            // 
            this.txtSorguRichTextBox.Location = new System.Drawing.Point(188, 413);
            this.txtSorguRichTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSorguRichTextBox.Name = "txtSorguRichTextBox";
            this.txtSorguRichTextBox.Size = new System.Drawing.Size(361, 59);
            this.txtSorguRichTextBox.TabIndex = 7;
            this.txtSorguRichTextBox.Text = "";
            // 
            // txtKimeBCCRichTextBox
            // 
            this.txtKimeBCCRichTextBox.Location = new System.Drawing.Point(188, 242);
            this.txtKimeBCCRichTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKimeBCCRichTextBox.Name = "txtKimeBCCRichTextBox";
            this.txtKimeBCCRichTextBox.Size = new System.Drawing.Size(361, 66);
            this.txtKimeBCCRichTextBox.TabIndex = 4;
            this.txtKimeBCCRichTextBox.Text = "";
            // 
            // txtKimeRichTextBox
            // 
            this.txtKimeRichTextBox.Location = new System.Drawing.Point(188, 156);
            this.txtKimeRichTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKimeRichTextBox.Name = "txtKimeRichTextBox";
            this.txtKimeRichTextBox.Size = new System.Drawing.Size(361, 66);
            this.txtKimeRichTextBox.TabIndex = 3;
            this.txtKimeRichTextBox.Text = "";
            // 
            // txtRaporTasarimDosyasi
            // 
            this.txtRaporTasarimDosyasi.Location = new System.Drawing.Point(189, 615);
            this.txtRaporTasarimDosyasi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRaporTasarimDosyasi.Name = "txtRaporTasarimDosyasi";
            this.txtRaporTasarimDosyasi.ReadOnly = true;
            this.txtRaporTasarimDosyasi.Size = new System.Drawing.Size(361, 23);
            this.txtRaporTasarimDosyasi.TabIndex = 10;
            this.txtRaporTasarimDosyasi.DoubleClick += new System.EventHandler(this.txtRaporTasarimDosyasi_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(61, 621);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Rapor Tasarımı";
            // 
            // txtRaporGrupAdi
            // 
            this.txtRaporGrupAdi.Location = new System.Drawing.Point(188, 113);
            this.txtRaporGrupAdi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRaporGrupAdi.Name = "txtRaporGrupAdi";
            this.txtRaporGrupAdi.Size = new System.Drawing.Size(361, 23);
            this.txtRaporGrupAdi.TabIndex = 2;
            // 
            // txtRapor
            // 
            this.txtRapor.Location = new System.Drawing.Point(188, 70);
            this.txtRapor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRapor.Name = "txtRapor";
            this.txtRapor.Size = new System.Drawing.Size(361, 23);
            this.txtRapor.TabIndex = 1;
            this.txtRapor.TextChanged += new System.EventHandler(this.txtRapor_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(61, 492);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Mail Açıklama";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 578);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Rapor Format";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 413);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Sorgu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 376);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Saat";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Kime BCC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Günler";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(61, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Rapor Grup Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rapor Adı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Şirket";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Grup Adı";
            this.gridColumn6.FieldName = "ReportDisplayName";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 94;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1063, 940);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmReport";
            this.Text = "Rapor Kartları";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboGunlerMultiSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleSirket.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpSaat;
        private System.Windows.Forms.RichTextBox txtKimeRichTextBox;
        private System.Windows.Forms.TextBox txtRapor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtSorguRichTextBox;
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
        private System.Windows.Forms.RichTextBox txtKimeBCCRichTextBox;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.GridLookUpEdit gleSirket;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.TextBox txtRaporTasarimDosyasi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboDosyaTipi;
        private DevExpress.XtraEditors.CheckedComboBoxEdit comboGunlerMultiSelect;
        private DevExpress.XtraBars.BarButtonItem btnRaporTest;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.RichTextBox txtMailAciklama;
        private System.Windows.Forms.TextBox txtRaporGrupAdi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}