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
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (ConfigurationManager.ConnectionStrings["Main"] == null)
                {
                    throw new Exception("Config dosyasında connection string bulunamadı");
                }
                GlobalParams.conn = new DAL.Connection();
                Application.Run(new frmLogin());
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public static class GlobalParams
    {
        public static DAL.Connection conn { get; set; }
    }
}
