using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.Helper
{
    public static class DbHelper
    {
        public static string CreateConnectionStringFromCrenditials(string server, string userName, string password)
        {

            return $"data source={server};integrated security=SSPI;initial catalog=ReportGenerator;User ID={userName};Password={LoginHelper.Decrypt(password)}";
        }
    }
}
