using ReportGenerator.Forms.Report;
using ReportGenerator.Forms.Settings;
using ReportGenerator.Helper;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ReportGenerator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (ConfigurationManager.ConnectionStrings["Main"] == null)
            {
                MessageBox.Show("Config dosyasında connection string bulunamadı!");
                return;
            }
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["DbName"]))
            {
                MessageBox.Show("Config dosyasında DbName bulunamadı!");
                return;
            }
            if (! DbHelper.CheckDatabaseExist(ConfigurationManager.ConnectionStrings["Main"].ConnectionString, ConfigurationManager.AppSettings["DbName"]))
            {
                MessageBox.Show("Lütfen script dosyasını database üzerinde çalıştırarak veritabanı oluşturun!");
                return;
            }
            GlobalParams.conn = new DAL.Connection();
            Application.Run(new frmLogin());
            if (GlobalParams.LoggedIn)
            {
                Application.Run(new frmMain());
            }
        }
    }

    public static class GlobalParams
    {
        public static DAL.Connection conn { get; set; }
        public static bool LoggedIn { get; set; }

        public static int UserId { get; set; }
    }
}
