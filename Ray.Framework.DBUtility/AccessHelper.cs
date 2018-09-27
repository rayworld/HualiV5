using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using Ray.Framework.Encrypt;

namespace Ray.Framework.DBUtility
{
    public abstract class AccessHelper
    {
        private AccessHelper() { }

        // Hashtable to store cached parameters
        private static readonly Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        //Database connection strings  
        #region ConnectionString
        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName, bool encryptable)
        {
            string connectionString = "";

            try
            {
                connectionString = ConfigurationManager.ConnectionStrings[configName].ConnectionString;
                return encryptable == true ? EncryptHelper.Decrypt(connectionString) : connectionString;
            }
            catch
            {
                throw new Exception("未能取得该名称的连接设置！");
            }
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            return GetConnectionString(configName, true);
        }

        /// <summary>
        /// 重载
        /// 不写参数是加密的，写了就不加密
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return GetConnectionString("AccessConnectionString", true);
        }

        /// <summary>
        /// 重载
        /// 不写参数是加密的，写了就不加密
        /// </summary>
        /// <param name="encryptable"></param>
        /// <returns></returns>
        public static string GetConnectionString(bool encryptable)
        {
            return GetConnectionString("AccessConnectionString", false);
        }

        #endregion

        #region ExecuteNonQuery

        /// <summary>
        /// Execute a OleDbCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OleDbConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {

            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, string cmdText, params OleDbParameter[] commandParameters)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, string cmdText)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, cmdText, null);
        }

        /// <summary>
        /// Execute a OleDbCommand (that returns no resultset) against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(OleDbConnection connection, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {

            OleDbCommand cmd = new OleDbCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// Execute a OleDbCommand (that returns no resultset) using an existing SQL Transaction 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">an existing sql transaction</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(OleDbTransaction trans, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion

        #region ExecuteDataSet

        /// <summary>
        /// ExecuteDataSet
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                try
                {
                    adp.Fill(ds);
                    cmd.Parameters.Clear();
                }
                finally
                {
                    adp.Dispose();
                }
                return ds;
            }

        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionString, string cmdText, params OleDbParameter[] commandParameters)
        {
            return ExecuteDataSet(connectionString, CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionString, string cmdText)
        {
            return ExecuteDataSet(connectionString, CommandType.Text, cmdText);
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string connectionString,string cmdText)
        {
            return ExecuteDataSet(connectionString, CommandType.Text, cmdText, null).Tables[0];
        }


        #endregion

        #region ExecuteReader

        /// <summary>
        /// Execute a OleDbCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OleDbConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>A SqlDataReader containing the results</returns>
        public static OleDbDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection(connectionString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="CmdText"></param>
        /// <param name="commamdParameters"></param>
        /// <returns></returns>
        public static OleDbDataReader ExecuteReader(string connectionString, string CmdText, params OleDbParameter[] commamdParameters)
        {
            return ExecuteReader(connectionString, CommandType.Text, CmdText, commamdParameters);
        }
        #endregion

        #region ExecuteScalar

        /// <summary>
        /// Execute a OleDbCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OleDbConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// Execute a OleDbCommand that returns the first column of the first record against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(OleDbConnection connection, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {

            OleDbCommand cmd = new OleDbCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="CmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionString, string CmdText, params OleDbParameter[] commandParameters)
        {
            return ExecuteScalar(connectionString, CommandType.Text, CmdText, commandParameters);
        }

        #endregion

        #region CacheParamerters

        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of SqlParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params OleDbParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }
        #endregion

        #region GetCacheParameters

        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached SqlParamters array</returns>
        public static OleDbParameter[] GetCachedParameters(string cacheKey)
        {
            OleDbParameter[] cachedParms = (OleDbParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            OleDbParameter[] clonedParms = new OleDbParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (OleDbParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        #endregion

        #region PrepareCommand
        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">OleDbCommand object</param>
        /// <param name="conn">OleDbConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">OleDbParameters to use in the command</param>
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, CommandType cmdType, string cmdText, OleDbParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion

    }
}
