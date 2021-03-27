using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.Helper
{
    public static class DbHelper
    {
        public static string CreateConnectionStringFromCrenditials(string server, string userName, string password)
        {

            return $"data source={server};integrated security=false;initial catalog=ReportGenerator;User ID={userName};Password={LoginHelper.Decrypt(password)}";
        }

        public static bool CheckServerIsUp(string server, string userName, string password)
        {
            var connectionString = CreateConnectionStringFromCrenditials(server, userName, password);
            using (var l_oConnection = new SqlConnection(connectionString))
            {
                try
                {
                    l_oConnection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
    }
}
