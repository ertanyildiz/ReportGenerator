using DevExpress.DataAccess.Wizard.Services;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using ReportGenerator.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportGenerator
{
    public partial class frmReportDesigner : Form
    {
        CustomConnectionStorageService connectionStorageService;
        public frmReportDesigner()
        {
            InitializeComponent();
            connectionStorageService = new CustomConnectionStorageService()
            {
                FileName = "connections.xml",
                IncludeApplicationConnections = false
            };
            ReplaceService(this.reportDesigner1, typeof(IConnectionStorageService), connectionStorageService);
            reportDesigner1.DesignPanelLoaded += DesignMdiControllerOnDesignPanelLoaded;
        }

        private void ReplaceService(IServiceContainer container, Type serviceType, object serviceInstance)
        {
            if (container.GetService(serviceType) != null)
                container.RemoveService(serviceType);
            container.AddService(serviceType, serviceInstance);
        }

        private void DesignMdiControllerOnDesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            ReplaceService(e.DesignerHost, typeof(IConnectionStorageService), connectionStorageService);
        }

        private void fmDesigner_Load(object sender, EventArgs e)
        {
            //Open new report
            XtraReport report = new XtraReport();
            this.reportDesigner1.OpenReport(report);
        }
    }
}
