using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Wizard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.Helper
{
    public class CustomConnectionProviderService : IConnectionProviderService
    {
        public SqlDataConnection LoadConnection(string connectionName)
        {
            // Specify custom connection parameters.
            return new SqlDataConnection(connectionName,
                new MsSqlConnectionParameters("localhost", "dataBaseName", "userName", "password", MsSqlAuthorizationType.Windows));
        }
    }
}
