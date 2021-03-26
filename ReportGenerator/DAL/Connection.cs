using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.DAL
{
    public class Connection
    {
        #region Private variables

        string sConfigText;
        string sCnnString;
        private readonly string sProvider = "System.Data.SqlClient";

        DbProviderFactory oProvider;
        DbTransaction trn;

        public DbConnection con { get; set; }
        #endregion

        #region Constructor & DeConstructor

        /// <summary>
        /// Web.Config dosyasında 'Main' ile başlayan connectionstring ve provider ile çalışacaktır.
        /// </summary>
        public Connection() : this("Main") { }

        /// <summary>
        /// Web.Config dosyasında, buraya gönderilen deðer ile başlayan connectionstring ve provider ile çalışacaktır.
        /// </summary>
        /// <param name="sConfigTextOption">Web.Config dosyasında connectionstring ve provider key'lerinin aynı kelimeleri</param>
        public Connection(string sConfigTextOption, string dynamicConnectionString = "")
        {
            sConfigText = sConfigTextOption;
            GetConfigInfo(dynamicConnectionString);
        }

        public void Dispose()
        {
            try
            {
                if (con != null)
                {
                    con.Close();
                    GC.ReRegisterForFinalize(con);
                    GC.SuppressFinalize(con);
                    con = null;
                }
            }
            catch
            {

            }
        }

        private void GetConfigInfo(string dynamicConnectionString)
        {
            sCnnString = string.IsNullOrEmpty(dynamicConnectionString) ?  System.Configuration.ConfigurationManager.ConnectionStrings[sConfigText].ToString()
                : dynamicConnectionString;
        }

        private string Provider
        {
            get { return System.Configuration.ConfigurationManager.AppSettings[sConfigText + "Provider"]; }
        }
        private string ServerName
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["Server"].ToString(); }
        }
        private string DataBaseName
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["DataBase"].ToString(); }
        }
        private string ConnectionTimeOut
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["ConnectionTimeOut"].ToString(); }
        }
        private string CommandTimeOut
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["CommandTimeOut"].ToString(); }
        }
        #endregion

        #region Opening & Closing Connection

        /// <summary>
        /// connection objesi için provider yaratılır.
        /// bu provider web.config'te belirltilmelidir.
        /// </summary>
        private void CreateProvider()
        {
            try
            {
                oProvider = DbProviderFactories.GetFactory(sProvider);
            }
            catch (Exception exc)
            {
                this.Dispose();
                throw new Exception(exc.Message);
            }
        }

        /// <summary>
        /// connection objesinin instance olarak yaratılır, henüz connection açılmamıştır.
        /// </summary>
        private void CreateConnectionObject()
        {
            try
            {
                con = oProvider.CreateConnection();
                con.ConnectionString = sCnnString;
            }
            catch (Exception exc)
            {
                this.Dispose();
                throw new Exception(exc.Message);
            }
        }

        /// <summary>
        /// Connection oluturulur. 
        /// </summary>
        /// <param name="bTransaction">ışlemler Transaction içersinde yapılacaksa bu alan 'true' gönderilmelidir.</param>
        /// <returns>Connection işlemleri hatasız ise 'true' gönderilir, yoksa hata 'throw' edilir.</returns>
        public bool Open(bool bTransaction)
        {
            try
            {
                if (oProvider == null) CreateProvider();
                if (con == null) CreateConnectionObject();
                if (con.State == ConnectionState.Closed) con.Open();
                if (bTransaction) trn = con.BeginTransaction();

                return true;
            }
            catch (DataException dex)
            {
                this.Dispose();
                throw dex;
            }
            catch (System.Exception exc)
            {
                this.Dispose();
                throw new Exception(exc.Message);
            }
        }

        /// <summary>
        /// Connection kapatılır.
        /// </summary>
        /// <returns>Connection kapama işlemi hatasız ise 'true' gönderilir, yoksa hata 'throw' edilir.</returns>
        public bool Close()
        {
            try
            {
                con.Close();
                if (trn != null)
                {
                    trn.Dispose();
                }
                return true;
            }
            catch
            {
                this.Dispose();
                return false;
            }
        }

        #endregion

        #region Creating Command

        public DbCommand CreateCommand()
        {
            return CreateCommand("", CommandType.Text);
        }

        public DbCommand CreateCommand(string sSQL)
        {
            return CreateCommand(sSQL, CommandType.Text);
        }

        /// <summary>
        /// SQL işlemleri için otomatik command tanımlanır.
        /// </summary>
        /// <param name="sSQL">SQL Cümlesi</param>
        /// <param name="cmdType">Command Tipi, sp veya text</param>
        /// <returns>otomatik oluşturulmuş command</returns>
        public DbCommand CreateCommand(string sSQL, CommandType cmdType)
        {
            this.Open(false);

            try
            {
                DbCommand cmd = con.CreateCommand();

                cmd.CommandText = sSQL;
                cmd.Connection = con;
                cmd.CommandType = cmdType;

                if (trn != null)
                {
                    cmd.Transaction = trn;
                }

                return cmd;
            }
            catch (Exception exc)
            {
                this.Dispose();
                throw new Exception(exc.Message);
            }
        }

        public DbCommand CreateCommand(string sSQL, CommandType cmdType, DbFieldCollection fields)
        {
            if (fields == null)
            {
                fields = new DbFieldCollection();
            }

            DbCommand cmd_select = CreateCommand(sSQL, cmdType);

            string main_sql = "";
            try
            {
                main_sql = GetData(cmd_select).Rows[0][0].ToString();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            string sWhere = "";
            string sParam = "";
            DbField cl = null;

            for (int i = 0; i < fields.Count; i++)
            {
                cl = fields[i];

                sParam = cl.Field.Trim();
                if (sParam.LastIndexOf(".") > 0)
                {
                    sParam = sParam.Substring(sParam.LastIndexOf(".") + 1);
                }
                if (sWhere.IndexOf("@" + sParam) > 0)
                {
                    sParam = sParam + i.ToString();
                }

                switch (cl.FieldDbType)
                {
                    case DbType.Date:
                    case DbType.DateTime:
                        sWhere += "CONVERT(VARCHAR, " + cl.Field.Trim() + ", 112) " + cl.Operator + " CONVERT(VARCHAR, @" + sParam + ",112) AND ";
                        break;
                    default:
                        sWhere += cl.Field.Trim() + " " + cl.Operator + " @" + sParam + " AND ";
                        break;
                }
            }
            if (sWhere != "")
            {
                int index = main_sql.LastIndexOf("WHERE");

                if (index > 0)
                {
                    main_sql = main_sql.Insert(index + 5, " " + sWhere);
                }
            }

            DbCommand cmd = CreateCommand(main_sql.Replace("\n", " ").Replace("\t", " ").Replace("\r", " "));

            object oValue;
            cl = null;

            for (int i = 0; i < fields.Count; i++)
            {
                cl = fields[i];

                sParam = cl.Field.Trim();
                if (sParam.LastIndexOf(".") > 0)
                {
                    sParam = sParam.Substring(sParam.LastIndexOf(".") + 1);
                }
                if (cmd.Parameters.Contains("@" + sParam))
                {
                    sParam = sParam + i.ToString();
                }

                oValue = cl.Value;
                switch (cl.Operator)
                {
                    case "LIKE":
                        oValue = oValue.ToString().Replace("*", "%");
                        break;
                }

                AddParameter(cmd, "@" + sParam, cl.FieldDbType, oValue);
            }

            return cmd;
        }

        public DbCommand CreateCommand(string sSQL, CommandType cmdType, DbFieldCollection coll, bool bRecord)
        {
            string sParam;
            DbCommand cmd = CreateCommand(sSQL, cmdType);

            foreach (DbField field in coll)
            {
                sParam = field.Field.Trim();
                if (sParam.LastIndexOf(".") > 0)
                {
                    sParam = sParam.Substring(sParam.LastIndexOf(".") + 1);
                }
                if (field.Value == null || field.Value.ToString() == "")
                    AddParameter(cmd, "@" + sParam, field.FieldDbType, DBNull.Value);
                else
                    AddParameter(cmd, "@" + sParam, field.FieldDbType, field.Value);
            }
            return cmd;
        }

        private object ConvertDateTime(object oDate)
        {
            if (oDate == null || oDate.ToString() == "")
                return DBNull.Value;
            else
                return Convert.ToDateTime(oDate);
        }

        /// <summary>
        /// SQL işlemleri başarılı ise commit çağrılır, commit bütün son işlemndir. 
        /// </summary>
        public void Commit()
        {
            try
            {
                trn.Commit();
            }
            catch (Exception exc)
            {
                this.Dispose();
                throw new Exception(exc.Message);
            }
        }

        /// <summary>
        /// SQL işlemleri başarısız ise rollback çaðrılır, bütün işlemler geri alınır.
        /// </summary>
        public void Rollback()
        {
            try
            {
                trn.Rollback();
            }
            catch (Exception exc)
            {
                this.Dispose();
                throw new Exception(exc.Message);
            }
        }

        #endregion

        #region Define Parameter
        /// <summary>
        /// Command objesi için parametre oluşturulması.
        /// </summary>
        /// <param name="cmd">Current DBCommand</param>
        /// <param name="sParameterName">Parametre Adı</param>
        /// <param name="oValue">Parametrenin deðeri</param>
        public void AddParameter(DbCommand cmd, string sParameterName, object oValue)
        {
            DbParameter prm = cmd.CreateParameter();
            prm.Value = oValue;
            prm.ParameterName = sParameterName;

            cmd.Parameters.Add(prm);
        }

        /// <summary>
        /// Command objesi için parametre oluşturulması.
        /// </summary>
        /// <param name="cmd">Current DBCommand</param>
        /// <param name="sParameterName">Parametre Adı</param>
        /// <param name="dbType">Parametrenin database'de belirtilmiş tipi</param>
        /// <param name="oValue">Parametrenin deðeri</param>
        public void AddParameter(DbCommand cmd, string sParameterName, DbType dbType, object oValue)
        {
            DbParameter prm = cmd.CreateParameter();
            prm.Value = oValue;
            prm.ParameterName = sParameterName;
            prm.DbType = dbType;

            cmd.Parameters.Add(prm);
        }

        /// <summary>
        /// Command objesi için parametre oluşturulması.
        /// </summary>
        /// <param name="cmd">Current DBCommand</param>
        /// <param name="sParameterName">Parametre Adı</param>
        /// <param name="dbType">Parametrenin database'de belirtilmiş tipi</param>
        /// <param name="iSize">Parametrenin database'de belirtilmiş büyüklüðü</param>
        /// <param name="oValue">Parametrenin deðeri</param>
        public void AddParameter(DbCommand cmd, string sParameterName, DbType dbType, int iSize, object oValue)
        {
            DbParameter prm = cmd.CreateParameter();
            prm.Value = oValue;
            prm.ParameterName = sParameterName;
            prm.DbType = dbType;
            prm.Size = iSize;

            cmd.Parameters.Add(prm);
        }

        /// <summary>
        /// Command objesi için parametre oluşturulması.
        /// </summary>
        /// <param name="cmd">Current DBCommand</param>
        /// <param name="sParameterName">Parametre Adı</param>
        /// <param name="dbType">Parametrenin database'de belirtilmiş tipi</param>
        /// <param name="iSize">Parametrenin database'de belirtilmiş büyüklüðü</param>
        /// <param name="paramDirection">Parametrenin yönü(input-output)</param>
        /// <param name="oValue">Parametrenin deðeri</param>
        public void AddParameter(DbCommand cmd, string sParameterName, DbType dbType, int iSize, ParameterDirection paramDirection, object oValue)
        {
            DbParameter prm = cmd.CreateParameter();
            prm.Value = oValue;
            prm.ParameterName = sParameterName;
            prm.DbType = dbType;
            prm.Size = iSize;
            prm.Direction = paramDirection;

            cmd.Parameters.Add(prm);
        }
        #endregion

        #region Get Data with DataTable

        /// <summary>
        /// Gönderilen Query çalıştırılır, Query'den dönen deðerler DataTable olarak geriye döndürülür.
        /// </summary>
        /// <param name="sSQL">SQL Query</param>
        /// <returns>Query sonucunda dönen deðerler</returns>
        public DataTable GetData(string sSQL)
        {
            this.Open(false);
            DbCommand cmd = this.CreateCommand(sSQL);

            return GetData(cmd);
        }

        /// <summary>
        /// Gönderilen Query çalıştırılır, Query'den dönen deðerler DataTable olarak geriye döndürülür.
        /// </summary>
        /// <param name="sSQL">SQL Query</param>
        /// <returns>Query sonucunda dönen deðerler</returns>
        public DataTable GetData(string spName, CommandType cmdType)
        {
            this.Open(false);
            DbCommand cmd = this.CreateCommand(spName, cmdType);

            return GetData(cmd);
        }

        /// <summary>
        /// Gönderilen Query çalıştırılır, Query'den dönen deðerler DataTable olarak geriye döndürülür.
        /// </summary>
        /// <param name="cmd">SQL Query içeren DbCommand</param>
        /// <returns>Query sonucunda dönen deðerler</returns>
        public DataTable GetData(DbCommand cmd)
        {
            this.Open(false);

            DbDataAdapter da = oProvider.CreateDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataSet GetDataSet(DbCommand cmd)
        {
            this.Open(false);

            DbDataAdapter da = oProvider.CreateDataAdapter();
            da.SelectCommand = cmd;

            DataSet dt = new DataSet();
            da.Fill(dt);

            return dt;
        }
        #endregion

        #region Executing Command or Query
        /// <summary>
        /// SQL cümlesi çalıştırılır.
        /// </summary>
        /// <param name="sSQL">SQL Cümlesi</param>
        public void ExecuteNonQuery(string sSQL)
        {
            ExecuteNonQuery(this.CreateCommand(sSQL));
        }




        /// <summary>
        /// ExecuteNonQuery ile etkilenen row sayısı döndürülür
        /// </summary>
        /// <param name="sSQL">SQL Cümlesi</param>
        public int ExecuteNonQueryReturn(DbCommand cmd)
        {
            try
            {
                if (this.con.State != ConnectionState.Open) this.Open(false);
                if (this.trn != null) cmd.Transaction = this.trn;
                return cmd.ExecuteNonQuery();

            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        /// <summary>
        /// DbCommand şeklinde gönderilen SQL cümlesi çalıştırılır.
        /// </summary>
        /// <param name="cmd">DbCommand</param>
        public void ExecuteNonQuery(DbCommand cmd)
        {
            try
            {
                if (this.con.State != ConnectionState.Open) this.Open(false);
                if (this.trn != null) cmd.Transaction = this.trn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        /// <summary>
        /// SQL cümlesi çalıştırılır, geriye sql cümlesinden dönen ilk bilgi döndürülür.
        /// </summary>
        /// <param name="sSQL">SQL Cümlesi</param>
        /// <returns>SQL cümlesinden dönen ilk bilgi</returns>
        public object ExecuteScalar(string sSQL)
        {
            return ExecuteScalar(this.CreateCommand(sSQL));
        }

        /// <summary>
        /// SQL cümlesi çalıştırılır, geriye sql cümlesinden dönen ilk bilgi döndürülür.
        /// </summary>
        /// <param name="cmd">DbCommand Objesi</param>
        /// <returns>DbCommand objesibden dönen ilk bilgi</returns>
        public object ExecuteScalar(DbCommand cmd)
        {
            try
            {
                if (this.con.State != ConnectionState.Open) this.Open(false);
                if (this.trn != null) cmd.Transaction = this.trn;
                return cmd.ExecuteScalar();
            }
            catch (Exception exc)
            {
                this.Dispose();
                throw new Exception(exc.Message);
            }
        }

        /////// <summary>
        /////// SQL cümlesi çalıştırılır ve geriye dönen değeri verinin tipine göre generic liste olarak geri döndürür.
        /////// </summary>
        /////// <param name="cmd">DbCommand Objesi</param>
        /////// <param name="gcfr">Reader dan collection nesnesi yaratan delegate</param>
        /////// <returns>verinin tipine göre generic liste</returns>
        //public List<Object> ExecuteReaderCmd(DbCommand cmd, Solice.DataAccessLayer.DataAccessLayerBaseClass.GenerateListFromReader glfr)
        //{
        //    this.Open(false);

        //    List<Object> GenericList = new List<Object>();
        //    using (cnn)
        //    {
        //        cmd.Connection = cnn;
        //        GenericList = glfr(cmd.ExecuteReader());
        //        return (GenericList);
        //    }
        //}

        /// <summary>
        /// SQL cümlesi çalıştırılır, geriye en son çalıştırılan Identity bilgisi döndürülür.
        /// </summary>
        /// <param name="sSQL">SQL Cümlesi</param>
        /// <returns>Identity bilgisi</returns>
        public object ExecuteReturnID(string sSQL)
        {
            return ExecuteReturnID(this.CreateCommand(sSQL));
        }

        /// <summary>
        /// DbCommand çalıştırılır, geriye en son çalıştırılan Identity bilgisi döndürülür.
        /// </summary>
        /// <param name="cmd">DbCommand</param>
        /// <returns>Identity</returns>
        public object ExecuteReturnID(DbCommand cmd)
        {
            try
            {
                if (this.con.State != ConnectionState.Open) this.Open(false);
                string sSQL = cmd.CommandText;
                if (sSQL.Substring(sSQL.Length - 1, 1) != ";") sSQL += ";";
                cmd.CommandText = sSQL + "SELECT SCOPE_IDENTITY()";
                if (this.trn != null) cmd.Transaction = this.trn;
                return cmd.ExecuteScalar();
            }
            catch (Exception exc)
            {
                this.Dispose();
                throw new Exception(exc.Message);
            }
        }

        #endregion
    }
}
