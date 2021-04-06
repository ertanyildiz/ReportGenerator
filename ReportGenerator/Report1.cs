using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Wizard.Services;
using System.Collections.Generic;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Wizard.Model;

namespace ReportGenerator
{
    public partial class Report1 : DevExpress.XtraReports.UI.XtraReport, IConnectionStorageService
    {
        public Report1()
        {
            InitializeComponent();
        }

        public bool CanSaveConnection => throw new NotImplementedException();

        public bool Contains(string connectionName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SqlDataConnection> GetConnections()
        {
            throw new NotImplementedException();
        }

        public void SaveConnection(string connectionName, IDataConnection connection, bool saveCredentials)
        {
            throw new NotImplementedException();
        }
    }
}
