using System;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;
using ReportGenerator.Helper;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;

namespace ReportGenerator.Forms.Company
{
    public partial class frmCompany : DevForm
    {
        private int recordId = 0;
        private readonly string title;

        public frmCompany()
        {
            InitializeComponent();
            title = Text;
        }

        private void btnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CheckFields())
            {
                MessageBox.Show("Tüm alanları doldurunuz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("Veritabanı bağlantı testi");
            var isDbUp = DbHelper.CheckServerIsUp(txtSunucuAdi.Text, txtVeritabani.Text, txtKullaniciAdi.Text, LoginHelper.Encrypt(txtSifre.Text));
            splashScreenManager1.CloseWaitForm();
            if (!isDbUp)
            {
                MessageBox.Show("Veritabanı ile bağlantı kurulamadı!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (DbCommand command = cnn.CreateCommand("SP_UPSERT_COMPANY", CommandType.StoredProcedure))
            {
                cnn.AddParameter(command, "@Id", recordId);
                cnn.AddParameter(command, "@Name", txtSirketAdi.Text);
                cnn.AddParameter(command, "@ServerName", txtSunucuAdi.Text);
                cnn.AddParameter(command, "@UserName", txtKullaniciAdi.Text);
                cnn.AddParameter(command, "@DbName", txtVeritabani.Text);
                cnn.AddParameter(command, "@Password", LoginHelper.Encrypt(txtSifre.Text));

                cnn.ExecuteNonQuery(command);
                MessageBox.Show("Kayıt başarılı", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                InitList();
            }

        }

        private void InitList()
        {
            var companyList = cnn.GetData("SELECT * FROM Company", CommandType.Text);
            gcListe.DataSource = companyList;
        }

        private void ClearFields()
        {
            txtSirketAdi.Text = txtKullaniciAdi.Text =
            txtSifre.Text = txtSunucuAdi.Text =
            txtVeritabani.Text = "";
        }

        private bool CheckFields()
        {
            return !string.IsNullOrEmpty(txtSirketAdi.Text) && !string.IsNullOrEmpty(txtKullaniciAdi.Text)
                 && !string.IsNullOrEmpty(txtSifre.Text) && !string.IsNullOrEmpty(txtSunucuAdi.Text)
                 && !string.IsNullOrEmpty(txtVeritabani.Text);
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            InitList();
        }

        private void gvListe_RowClick(object sender, RowClickEventArgs e)
        {
            var grid = sender as GridView;
            recordId = Convert.ToInt32(grid.GetFocusedRowCellValue("Id"));
            txtSirketAdi.Text = grid.GetFocusedRowCellValue("Name").ToString();
            txtKullaniciAdi.Text = grid.GetFocusedRowCellValue("UserName").ToString();
            txtSifre.Text = LoginHelper.Decrypt(grid.GetFocusedRowCellValue("Password").ToString());
            txtSunucuAdi.Text = grid.GetFocusedRowCellValue("ServerName").ToString();
            txtVeritabani.Text = grid.GetFocusedRowCellValue("DbName").ToString();
            Text = $"{title} - {txtSirketAdi.Text}";
        }

        private void btnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            recordId = 0;
            ClearFields();
            Text = $"{title} - Yeni Kayıt";
        }

        private void btnSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (recordId < 1)
                {
                    MessageBox.Show("Kayıt seçiniz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var confirm = MessageBox.Show("Seçili kayıt silinecek, devam edilsin mi?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No) { return;  }
                using (DbCommand command = cnn.CreateCommand("SP_DELETE_COMPANY", CommandType.StoredProcedure))
                {
                    cnn.AddParameter(command, "@Id", recordId);
                    cnn.ExecuteNonQuery(command);
                    MessageBox.Show("Kayıt Silindi başarılı", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    InitList();
                    recordId = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}