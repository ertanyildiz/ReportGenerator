using System;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;
using ReportGenerator.Helper;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;

namespace ReportGenerator.Forms.Email
{
    public partial class frmEmail : DevForm
    {
        private int recordId = 0;
        private readonly string title;

        public frmEmail()
        {
            InitializeComponent();
            title = Text;
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            InitList();
            InitCompanyList();
            comboSSL.SelectedIndex = 0;
        }

        private void InitList()
        {
            var companyList = cnn.GetData("SP_SELECT_MAIL_CONFIG", CommandType.StoredProcedure);
            gcListe.DataSource = companyList;
        }

        private void InitCompanyList()
        {
            var dt = cnn.GetData("SELECT * FROM Company", CommandType.Text);
            gleSirket.Properties.ValueMember = "Id";
            gleSirket.Properties.DisplayMember = "Name";
            gleSirket.Properties.DataSource = dt;
        }

        private void btnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CheckFields())
            {
                MessageBox.Show("Tüm alanları doldurunuz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var testEmailAddress = GetTestMailAddress();
            if (string.IsNullOrEmpty(testEmailAddress))
            {
                MessageBox.Show("Lütfen ayarlardan test mail adresini ayarlayınız!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("Mail test ediliyor");
            if (!EmailHelper.SendEmail(txtSunucuAdi.Text, txtMailAdresi.Text, testEmailAddress, LoginHelper.Encrypt(txtSifre.Text), Convert.ToInt32(txtPort.Text), Convert.ToBoolean(comboSSL.SelectedItem)))
            {
                MessageBox.Show("Mail ayarlarında sorun var!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            splashScreenManager1.CloseWaitForm();

            using (DbCommand command = cnn.CreateCommand("SP_UPSERT_EMAIL_CONFIG", CommandType.StoredProcedure))
            {
                cnn.AddParameter(command, "@Id", recordId);
                cnn.AddParameter(command, "@MailAddress", txtMailAdresi.Text);
                cnn.AddParameter(command, "@FromWho", txtKimden.Text);
                cnn.AddParameter(command, "@ServerName", txtSunucuAdi.Text);
                cnn.AddParameter(command, "@Password", LoginHelper.Encrypt(txtSifre.Text));
                cnn.AddParameter(command, "@Port", txtPort.Text);
                cnn.AddParameter(command, "@Ssl", comboSSL.SelectedItem);
                cnn.AddParameter(command, "@CompanyId ", gleSirket.EditValue);

                cnn.ExecuteNonQuery(command);
                MessageBox.Show("Kayıt başarılı", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                InitList();
            }

        }

        

        private void ClearFields()
        {
            gleSirket.EditValue = txtMailAdresi.Text = 
            txtSifre.Text = txtKimden.Text =
            txtPort.Text = txtSunucuAdi.Text = "";
        }

        private bool CheckFields()
        {
            return !string.IsNullOrEmpty(txtMailAdresi.Text) 
                 && !string.IsNullOrEmpty(txtSifre.Text) && !string.IsNullOrEmpty(txtKimden.Text)
                 && !string.IsNullOrEmpty(txtSunucuAdi.Text) && !string.IsNullOrEmpty(txtPort.Text)
                 && !string.IsNullOrEmpty(gleSirket.EditValue.ToString());
        }
        

        private void gvListe_RowClick(object sender, RowClickEventArgs e)
        {
            var grid = sender as GridView;
            recordId = Convert.ToInt32(grid.GetFocusedRowCellValue("Id"));
            txtMailAdresi.Text = grid.GetFocusedRowCellValue("MailAddress").ToString();
            txtSifre.Text = LoginHelper.Decrypt(grid.GetFocusedRowCellValue("Password").ToString());
            txtKimden.Text = grid.GetFocusedRowCellValue("FromWho").ToString();
            txtSunucuAdi.Text = grid.GetFocusedRowCellValue("ServerName").ToString();
            txtPort.Text = grid.GetFocusedRowCellValue("Port").ToString();
            comboSSL.SelectedItem = grid.GetFocusedRowCellValue("Ssl"); ;
            gleSirket.EditValue = grid.GetFocusedRowCellValue("CompanyId"); ;
            Text = $"{title} - {txtMailAdresi.Text}";
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
                using (DbCommand command = cnn.CreateCommand("SP_DELETE_EMAIL_CONFIG", CommandType.StoredProcedure))
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

        private string GetTestMailAddress()
        {
            var dt = cnn.GetData("SELECT * FROM Referans WHERE RefName = 'TEST_EMAIL_ADDRESS'", CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["RefDescription"].ToString();
            }
            return "";
        }
    }
}