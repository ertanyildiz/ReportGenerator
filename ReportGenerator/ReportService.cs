using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using ReportGenerator.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    public class ReportService
    {
        public int TestIT()
        {
            var cnn = new DAL.Connection();
            var currentTime = DateTime.Now.ToString("HH:mm");
            var currentDay = (int) DateTime.Now.DayOfWeek;
            var raporlar = new DataTable();
            using (var command = cnn.CreateCommand("SP_SELECT_REPORT_BY_TIME", CommandType.StoredProcedure))
            {
                //localConnection.AddParameter(command, "@DayNumber", currentDay);
                //localConnection.AddParameter(command, "@ReportTime", currentTime);
                cnn.AddParameter(command, "@DayNumber", 1);
                cnn.AddParameter(command, "@ReportTime", "14:54");
                raporlar = cnn.GetData(command);
            }
            if (raporlar.Rows.Count < 1) { return -1; }
            foreach (DataRow row in raporlar.Rows)
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

                // Specify the path for the exported PDF file.  
                string pdfExportFile =
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                    @"\Downloads\" +
                    row["ReportName"].ToString() +
                    ".pdf";

                // Export the report.
                xtraReport.ExportToPdf(pdfExportFile, pdfExportOptions);
            }

            //TODO: mailgönder

            return raporlar.Rows.Count;
        }
    }
}
