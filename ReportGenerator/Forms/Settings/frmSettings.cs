using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Common;
using ReportGenerator.Helper;

namespace ReportGenerator.Forms.Settings
{
    public partial class frmSettings : DevForm
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtRaporYolu.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {

            if (!CheckFields())
            {
                MessageBox.Show("Şifreler boş bırakılamaz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler aynı değil", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (DbCommand command = cnn.CreateCommand("SP_CHANGE_PASSWORD", CommandType.StoredProcedure))
            {
                cnn.AddParameter(command, "@Id", GlobalParams.UserId);
                cnn.AddParameter(command, "@Password", LoginHelper.HashPassword(txtSifre.Text));

                cnn.ExecuteNonQuery(command);
                MessageBox.Show("Şifre değiştirildi", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
        }

        private void ClearFields()
        {
            txtSifre.Text = txtSifreTekrar.Text = "";
        }

        private bool CheckFields()
        {
            return !string.IsNullOrEmpty(txtSifre.Text) && !string.IsNullOrEmpty(txtSifreTekrar.Text);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(txtRaporYolu.Text))
            {
                MessageBox.Show("Dosyalar için bir klasör seçiniz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (DbCommand command = cnn.CreateCommand("SP_UPDATE_REPORT_PATH", CommandType.StoredProcedure))
            {
                cnn.AddParameter(command, "@Path", txtRaporYolu.Text);

                cnn.ExecuteNonQuery(command);
                MessageBox.Show("Rapor dosyaları klasörü değiştirildi", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            InitReportPath();
            txtMailAdresi.Text = GetTestMailAddress();
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

        private void InitReportPath()
        {
            var dt = cnn.GetData("SELECT RefDescription From Referans WHERE RefName = 'REPORT_FILES_PATH'", CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                txtRaporYolu.Text = dt.Rows[0]["RefDescription"].ToString();
            }
        }

        private void btnMailAdresKaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMailAdresi.Text))
            {
                using (DbCommand command = cnn.CreateCommand("SP_UPSERT_TEST_EMAIL", CommandType.StoredProcedure))
                {
                    cnn.AddParameter(command, "@EmailAddress", txtMailAdresi.Text);
                    cnn.ExecuteNonQuery(command);
                    MessageBox.Show("Test Mail adresi değiştirildi", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Test Mail adresi boş olamaz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}