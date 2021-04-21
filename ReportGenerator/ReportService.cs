using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using ReportGenerator.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private const string MERGE_PDF = "1";
        public int RunService()
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
                var pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "raporman");
                if (!Directory.Exists(pdfPath))
                {
                    Directory.CreateDirectory(pdfPath);
                }
                var pdfFileNames = new List<string>();
                var reportNames = new List<string>();
                var mergePDF = ConfigurationManager.AppSettings["PDFBirlestir"];
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

                    var pdfFileNameWithDate = $"{row["ReportName"]}_{DateTime.Now.AddDays(-1):dd.MM.yyyy}-{DateTime.Now:fff}";
                    //pdf file name
                    string pdfExportFile = $"{Path.Combine(pdfPath, pdfFileNameWithDate)}.pdf";
                    //get file pdf file Name
                    pdfFileNames.Add(pdfExportFile);
                    //get report names
                    reportNames.Add(row["ReportName"].ToString());

                    // Export the report.
                    xtraReport.ExportToPdf(pdfExportFile, pdfExportOptions);
                }

                if (mergePDF == MERGE_PDF)
                {
                    var finalPdfFileName = Path.Combine(pdfPath, $"{reportNames.FirstOrDefault()}_{reportNames.Count}_{DateTime.Now.AddDays(-1):dd.MM.yyyy}.pdf");
                    EmailHelper.MergePDFs(finalPdfFileName, pdfFileNames);
                    pdfFileNames.Clear();
                    pdfFileNames.Add(finalPdfFileName);
                }
                EmailHelper.SendEmail(reports, pdfFileNames);
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
            var currentDay = (DateTime.Now.DayOfWeek == 0) ? 7 : (int)DateTime.Now.DayOfWeek;
            var reports = new DataTable();
            using (var command = cnn.CreateCommand("SP_SELECT_REPORT_BY_TIME", CommandType.StoredProcedure))
            {
                cnn.AddParameter(command, "@DayNumber", currentDay);
                cnn.AddParameter(command, "@ReportTime", currentTime);
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
