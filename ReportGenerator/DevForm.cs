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
    }

}
