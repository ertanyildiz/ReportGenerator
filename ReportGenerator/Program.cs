using ReportGenerator.Company;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
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
            GlobalParams.conn = new DAL.Connection();
            Application.Run(new frmCompany());
            return;

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
    }
}
