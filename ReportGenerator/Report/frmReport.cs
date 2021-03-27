using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ReportGenerator.Report
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        private int recordId = 0;
        public frmReport()
        {
            InitializeComponent();
        }

        private void btnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CheckFields())
            {
                MessageBox.Show("Tüm alanları doldurunuz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private bool CheckFields()
        {
            return sirketLookUp.EditValue != null && !string.IsNullOrEmpty(txtRapor.Text) && !string.IsNullOrEmpty(txtKimeRichTextBox.Text) &&
                raporTasarimLookUp.EditValue != null && !string.IsNullOrEmpty(txtSorguRichTextBox.Text);
        }
    }
}