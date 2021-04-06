using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using ReportGenerator.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Transactions;
using System.Windows.Forms;

namespace ReportGenerator.Forms.Report
{
    public partial class frmReport : DevForm
    {
        private int recordId;
        private readonly string title;
        public frmReport()
        {
            InitializeComponent();
            title = Text;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            comboDosyaTipi.SelectedIndex = 0;
            InitList();
            InitCompanyList();
            InitDays();
        }

        private void btnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    if (!CheckFields())
                    {
                        MessageBox.Show("Tüm alanları doldurunuz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (string.IsNullOrEmpty(GetTestMailAddress()))
                    {
                        MessageBox.Show("Mail Ayarları yapılmadan rapor tanımlanamaz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    using (DbCommand command = cnn.CreateCommand("SP_UPSERT_REPORT", CommandType.StoredProcedure))
                    {
                        cnn.AddParameter(command, "@Id", recordId);
                        cnn.AddParameter(command, "@ReportName", txtRapor.Text);
                        cnn.AddParameter(command, "@SendTo", txtKimeRichTextBox.Text);
                        cnn.AddParameter(command, "@SendToBcc", txtKimeBCCRichTextBox.Text);
                        cnn.AddParameter(command, "@ReportFile", txtRaporTasarimDosyasi.Text);
                        cnn.AddParameter(command, "@FileFormat", comboDosyaTipi.SelectedItem.ToString());
                        cnn.AddParameter(command, "@ReportTime", dtpSaat.Value.ToString("HH:mm"));
                        cnn.AddParameter(command, "@SqlQuery", txtSorguRichTextBox.Text);
                        cnn.AddParameter(command, "@CompanyId", gleSirket.EditValue);
                        if (recordId < 1)
                        {
                            recordId = (int)cnn.ExecuteScalar(command);
                        }
                        else
                        {
                            cnn.ExecuteNonQuery(command);
                        }
                    }


                    var list = comboGunlerMultiSelect.Properties.GetItems().GetCheckedValues();
                    
                    foreach (object item in list)
                    {
                        using (DbCommand command = cnn.CreateCommand("SP_INSERT_REPORT_DAY", CommandType.StoredProcedure))
                        {
                            cnn.AddParameter(command, "@DayNumber", item);
                            cnn.AddParameter(command, "@ReportId", recordId);
                            cnn.ExecuteNonQuery(command);
                        }
                    }

                    MessageBox.Show("Kayıt başarılı", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    InitList();
                    recordId = 0;
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata! {ex.Message}");
            }

        }

        private void ClearFields()
        {
            gleSirket.EditValue = txtRapor.Text = txtKimeBCCRichTextBox.Text = txtKimeRichTextBox.Text = txtSorguRichTextBox.Text = txtRaporTasarimDosyasi.Text = "";
            comboGunlerMultiSelect.SetEditValue("");
        }

        private bool CheckFields()
        {
            return !string.IsNullOrEmpty(gleSirket.EditValue.ToString()) && !string.IsNullOrEmpty(txtRapor.Text) && !string.IsNullOrEmpty(txtKimeRichTextBox.Text) &&
                !string.IsNullOrEmpty(txtRaporTasarimDosyasi.Text) && !string.IsNullOrEmpty(txtSorguRichTextBox.Text)
                && !string.IsNullOrEmpty(comboGunlerMultiSelect.EditValue.ToString());
        }
        private void InitList()
        {
            var companyList = cnn.GetData("SP_SELECT_REPORT", CommandType.StoredProcedure);
            gcListe.DataSource = companyList;
        }

        private void InitDays()
        {
            var dt = cnn.GetData("SP_SELECT_DAYS", CommandType.StoredProcedure);
            comboGunlerMultiSelect.Properties.ValueMember = "RefDescription";
            comboGunlerMultiSelect.Properties.DisplayMember = "DAY_NAME";
            comboGunlerMultiSelect.Properties.DataSource = dt;
        }

        private void InitCompanyList()
        {
            var dt = cnn.GetData("SELECT * FROM Company", CommandType.Text);
            gleSirket.Properties.ValueMember = "Id";
            gleSirket.Properties.DisplayMember = "Name";
            gleSirket.Properties.DataSource = dt;
        }

        private void txtRaporTasarimDosyasi_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "REPX (*.repx)|*.repx|Tüm dosyalar (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtRaporTasarimDosyasi.Text = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata! {ex.Message}");
                }
            }
        }

        private void gvListe_RowClick(object sender, RowClickEventArgs e)
        {
            var grid = sender as GridView;
            recordId = Convert.ToInt32(grid.GetFocusedRowCellValue("Id"));
            var record = cnn.GetData($"SELECT * FROM Report WHERE Id = {recordId}", CommandType.Text);
            if (record.Rows.Count < 1) { return; }
            GetCurrentRecord(record);
            SetSelectedDays(recordId);
        }

        private void SetSelectedDays(int recordId)
        {
            var days = cnn.GetData($"SELECT * FROM REPORTDAYS WHERE ReportId = {recordId}", CommandType.Text);
            var selectedDays = new List<string>();
            foreach (DataRow row in days.Rows)
            {
                selectedDays.Add(row["DayNumber"].ToString());
            }
            comboGunlerMultiSelect.SetEditValue(string.Join(",", selectedDays));
            comboGunlerMultiSelect.Refresh();
        }

        private void GetCurrentRecord(DataTable record)
        {
            gleSirket.EditValue = record.Rows[0]["CompanyId"];
            txtRapor.Text = record.Rows[0]["ReportName"].ToString();
            txtKimeBCCRichTextBox.Text = record.Rows[0]["SendTo"].ToString();
            txtKimeRichTextBox.Text = record.Rows[0]["SendToBcc"].ToString();
            comboDosyaTipi.SelectedItem = record.Rows[0]["FileFormat"];
            txtSorguRichTextBox.Text = record.Rows[0]["SqlQuery"].ToString();
            txtRaporTasarimDosyasi.Text = record.Rows[0]["ReportFile"].ToString();
            dtpSaat.Value = DateTime.ParseExact(record.Rows[0]["ReportTime"].ToString(), "HH:mm", CultureInfo.CurrentCulture);
            Text = $"{title} - {txtRapor.Text}";
        }

        private void btnSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (recordId < 1)
            {
                MessageBox.Show("Kayıt seçiniz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var confirm = MessageBox.Show("Seçili kayıt silinecek, devam edilsin mi?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) { return; }
            using (DbCommand command = cnn.CreateCommand("SP_DELETE_REPORT", CommandType.StoredProcedure))
            {
                cnn.AddParameter(command, "@Id", recordId);
                cnn.ExecuteNonQuery(command);
                MessageBox.Show("Kayıt Silindi başarılı", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                InitList();
                recordId = 0;
            }
        }

        private void btnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            recordId = 0;
            ClearFields();
            Text = $"{title} - Yeni Kayıt";
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

        private void btnRaporTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("Rapor Testi...");
                var testMailAddress = GetTestMailAddress();
                if (string.IsNullOrEmpty(testMailAddress))
                {
                    MessageBox.Show("Mail Ayarları yapılmadan rapor tanımlanamaz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (recordId < 1)
                {
                    MessageBox.Show("Lütfen bir kayıt seçiniz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataTable recordDt = null;
                using (DbCommand command = cnn.CreateCommand("SP_SELECT_REPORT_BY_ID", CommandType.StoredProcedure))
                {
                    cnn.AddParameter(command, "@Id", recordId);
                    recordDt = cnn.GetData(command);
                }
                if (recordDt?.Rows.Count < 1)
                {
                    MessageBox.Show("Kayıt bulunamadı!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    InitList();
                    return;
                }
                var row = recordDt.Rows[0];
                var servername = row["ServerName"].ToString();
                var userName = row["UserName"].ToString();
                var dbName = row["DbName"].ToString();
                var password = row["Password"].ToString();
                var dynamicConnectionString = DbHelper.CreateConnectionStringFromCrenditials(servername, dbName, userName, password);
                var reporConnection = new DAL.Connection("", dynamicConnectionString);
                var sqlQuery = row["SqlQuery"].ToString();
                var dt = reporConnection.GetData(sqlQuery, CommandType.Text);
                XtraReport xtraReport = new XtraReport();
                xtraReport.LoadLayout(row["ReportFile"].ToString());
                PdfExportOptions pdfExportOptions = new PdfExportOptions()
                {
                    PdfACompatibility = PdfACompatibility.PdfA1b
                };
                //TODO create raporman folder
                //bcc set failure

                xtraReport.DataSource = dt;
                xtraReport.DataMember = dt.TableName;
                var pdfPath = Path.Combine(Path.GetTempPath(), "raporman");
                string pdfExportFile = $"{Path.Combine(pdfPath, Path.GetRandomFileName())}.pdf";
                xtraReport.ExportToPdf(pdfExportFile, pdfExportOptions);

                EmailHelper.SendEmail(recordDt, pdfExportFile, new List<string> { row["ReportName"].ToString() });
                MessageBox.Show("Test başarılı", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test edilirken hata meydana geldi", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReportService.Log($"{ex.Message} - {ex.InnerException}", "HATA");
            }
            finally
            {
                splashScreenManager1.CloseWaitForm();
            }

        }
    }
}