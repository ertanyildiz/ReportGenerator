using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using ReportGenerator.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    public class ReportService
    {
        public int TestIT()
        {
            try
            {
                var emailConfig = GetEmailConfig();
                if (emailConfig.Rows.Count < 1)
                {
                    Log("Email konfigurasyonu yapılmamış. Rapor gönderilemez!", "HATA");
                    return 0;
                }
                var reports = GetCurrentReports();
                if (reports.Rows.Count < 1) { return 0; }
                var pdfPath = Path.Combine(Path.GetTempPath(), "raporman");
                if (!Directory.Exists(pdfPath))
                {
                    Directory.CreateDirectory(pdfPath);
                }
                var pdfFileNames = new List<string>();
                var emailAddresses = reports.Rows[0]["SendTo"].ToString();
                var emailAddressesBcc = reports.Rows[0]["SendToBcc"].ToString();
                var reportNames = new List<string>();
                foreach (DataRow row in reports.Rows)
                {
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
                    xtraReport.DataSource = dt;
                    xtraReport.DataMember = dt.TableName;

                    //pdf file name
                    string pdfExportFile = $"{Path.Combine(pdfPath, Path.GetRandomFileName())}.pdf";
                    //get file pdf file Name
                    pdfFileNames.Add(pdfExportFile);
                    //get report names
                    reportNames.Add(row["ReportName"].ToString());

                    // Export the report.
                    xtraReport.ExportToPdf(pdfExportFile, pdfExportOptions);
                }
                var finalPdfFileName = $"{Path.Combine(pdfPath, Path.GetRandomFileName())}.pdf";
                EmailHelper.MergePDFs(finalPdfFileName, pdfFileNames);
                EmailHelper.SendEmail(reports, finalPdfFileName, reportNames);
                CultureInfo turkish = new CultureInfo("tr-TR");
                string dayName = DateTime.Now.ToString("dddd", turkish);
                Log($"{dayName} {DateTime.Now:HH:mm} Maili gönderildi", "BİLGİ");
                return reports.Rows.Count;
            }
            catch (Exception ex)
            {
                Log($"{ex.Message}- {ex.InnerException} {ex.StackTrace}", "HATA");
            }
            return 0;
        }

        private DataTable GetCurrentReports()
        {
            var cnn = new DAL.Connection();
            var currentTime = DateTime.Now.ToString("HH:mm");
            var currentDay = (int)DateTime.Now.DayOfWeek;
            var reports = new DataTable();
            using (var command = cnn.CreateCommand("SP_SELECT_REPORT_BY_TIME", CommandType.StoredProcedure))
            {
                cnn.AddParameter(command, "@DayNumber", currentDay);
                cnn.AddParameter(command, "@ReportTime", currentTime);
                //cnn.AddParameter(command, "@DayNumber", 1);
                //cnn.AddParameter(command, "@ReportTime", "14:55");
                reports = cnn.GetData(command);
                cnn.Close();
            }
            return reports;
        }

        public static void Log(string description, string type)
        {
            var cnn = new DAL.Connection();
            using (var command = cnn.CreateCommand("SP_INSERT_LOG", CommandType.StoredProcedure))
            {
                description = $"{DateTime.Now} - {description}";
                cnn.AddParameter(command, "@Description", description);
                cnn.AddParameter(command, "@Type", type);
                cnn.ExecuteNonQuery(command);
                cnn.Close();
            }
        }

        private DataTable GetEmailConfig()
        {
            var cnn = new DAL.Connection();
            var dt = new DataTable();
            using (var command = cnn.CreateCommand("SELECT * FROM EmailConfig", CommandType.Text))
            {
                dt = cnn.GetData(command);
                cnn.Close();
            }
            return dt;
        }
    }
}
