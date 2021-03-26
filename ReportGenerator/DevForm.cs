using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.Helper
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
