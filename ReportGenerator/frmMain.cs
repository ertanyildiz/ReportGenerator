using System.Windows.Forms;
using DevExpress.XtraBars;
using ReportGenerator.Forms.Company;
using ReportGenerator.Forms.Report;
using ReportGenerator.Forms.Settings;

namespace ReportGenerator
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void OpenForm(Form frm)
        {
            splashScreenManager1.ShowWaitForm();

            int index = GetTabbedPageIndex(frm.GetType().ToString());

            if (index != -1)
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[index];
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }

            ribbon.Minimized = true;

            splashScreenManager1.CloseWaitForm();
        }

        private int GetTabbedPageIndex(string sForm)
        {
            int index = -1;
            int iPageCount = xtraTabbedMdiManager1.Pages.Count;

            for (int i = 0; i < iPageCount; i++)
            {
                if (xtraTabbedMdiManager1.Pages[i].MdiChild.GetType().ToString() == sForm)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        private void btnSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            var settings = new frmSettings();
            settings.Show();
        }

        private void btnRaporKart_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new frmReport());
        }

        private void btnSirketKart_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new frmCompany());
        }
    }
}