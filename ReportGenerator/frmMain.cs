using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using ReportGenerator.Company;

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

        private void btnSirketKart_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new frmCompany());
        }
    }
}