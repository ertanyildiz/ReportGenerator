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
using System.Data.Common;
using ReportGenerator.Helper;
namespace ReportGenerator
{
    public partial class frmLogin : DevForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKullaniciAdi.Text) || string.IsNullOrEmpty(txtSifre.Text))
            {
                MessageBox.Show("Kullanıcı ve şifre boş olamaz!", "Giriş hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (DbCommand cmd = cnn.CreateCommand("SP_LOGIN", CommandType.StoredProcedure))
            {
                cnn.AddParameter(cmd, "@UserName", txtKullaniciAdi.Text);
                var userDt = cnn.GetData(cmd);
                if (userDt.Rows.Count > 0)
                {
                    var passwordCheck = LoginHelper.VerifyPassword(userDt.Rows[0]["Password"].ToString(), txtSifre.Text);
                    if (! passwordCheck)
                    {
                        MessageBox.Show("Kullanıcı veya şifre hatalı!", "Giriş hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    GlobalParams.LoggedIn = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı veya şifre hatalı!", "Giriş hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}