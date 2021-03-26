using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.DAL
{
    public class DbField
    {
        string s_Field;
        string s_Operator;
        object s_Value;
        DbType d_DbType;

        public DbField() : this("", "", null, DbType.String)
        {
        }

        public DbField(string sField, string sOperator, object sValue, DbType dDbType)
        {
            this.Field = sField;
            this.Operator = sOperator;
            this.Value = sValue;
            this.FieldDbType = dDbType;
        }

        public string Field
        {
            get { return this.s_Field; }
            set { this.s_Field = value; }
        }
        public string Operator
        {
            get { return this.s_Operator; }
            set { this.s_Operator = value; }
        }
        public object Value
        {
            get { return this.s_Value; }
            set { this.s_Value = value; }
        }
        public DbType FieldDbType
        {
            get { return this.d_DbType; }
            set { this.d_DbType = value; }
        }

    }
}
