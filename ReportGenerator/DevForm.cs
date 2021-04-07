using DevExpress.XtraEditors;

namespace ReportGenerator
{
    public class DevForm : XtraForm
    {
        public virtual DAL.Connection cnn
        {
            get
            {
                return GlobalParams.conn;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DevForm
            // 
            this.ClientSize = new System.Drawing.Size(298, 260);
            this.IconOptions.Image = global::ReportGenerator.Properties.Resources.giza_son_logo_C3G_icon;
            this.Name = "DevForm";
            this.ResumeLayout(false);

        }
    }

}
