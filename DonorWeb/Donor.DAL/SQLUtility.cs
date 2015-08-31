using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Donor.DAL
{
    /// <summary>
    /// Summary description for DBUtility
    /// </summary>
    public class SQLUtility
    {
        /// <summary>
        /// Private variable declaration
        /// </summary>
        private SqlConnection sqlConn;
        private SqlCommand sqlComm;
        private SqlDataAdapter sqlDA;

        public SQLUtility()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Public Funtion OpenConnection
        /// Purpose of the funtion
        ///     - Read Database Connection Property from Web.config file
        ///     - Create Connection
        ///     - Initialize Command and Data Adapter Object
        /// </summary>  
        public void OpenConnection()
        {
            if (sqlConn == null)
            {
                sqlConn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connectionstring"].ToString());
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();
                sqlComm = new SqlCommand();
                sqlComm.Connection = sqlConn;
                sqlDA = new SqlDataAdapter();
            }
        }

        /// <summary>
        /// Private Funtion CloseConnection
        /// Purpose of the Function
        ///     - Check for Connection State    
        ///     - If Connection is open then close the Connectin Object
        /// </summary>
        public void CloseConnection()
        {
            if (sqlConn != null)
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }
        }

        /// <summary>
        /// Private Function DisposeConnection
        /// Purpose of the Function
        ///     - Check the Connection for null
        ///     - Check for Conection State is open or close
        ///     - Dispose the Connection Object    
        /// </summary>
        public void DisposeConnection()
        {
            if (sqlConn != null)
            {
                if (sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Dispose();
                    sqlConn = null;
                }
            }
        }

        /// <summary>
        /// Public Function RecordExist - Single Parameter
        /// Purpose of the function
        ///     - Check for record exist or not.
        ///     - Return bool value
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public bool RecordExist(string strSql)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.Text;
                sqlComm.CommandText = strSql;
                int intRows = (int)sqlComm.ExecuteScalar();
                if (intRows > 0)
                    return true;
                else
                    return false;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Function RecordExist - 2 Parameter
        /// Purpose of the function
        ///     - Receive Values in Parameter
        ///     - Check for record exist or not.
        ///     - Return bool value
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool RecordExist(string strSql, SqlParameter[] param)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.Text;
                sqlComm.CommandText = strSql;
                SqlParameter sqlParam = new SqlParameter();
                foreach (SqlParameter loopParam in param)
                {
                    sqlParam = loopParam;
                    sqlComm.Parameters.Add(sqlParam);
                }
                long intRows = (int)sqlComm.ExecuteScalar();
                if (intRows > 0)
                    return true;
                else
                    return false;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Function RecordExist - Stored Procedure
        /// Purpose of the function
        ///     - Receive Values in Parameter
        ///     - Check for record exist or not.
        ///     - Return bool value
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool SP_RecordExist(string strSql, SqlParameter[] param)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = strSql;
                SqlParameter sqlParam = new SqlParameter();
                foreach (SqlParameter loopParam in param)
                {
                    sqlParam = loopParam;
                    sqlComm.Parameters.Add(sqlParam);
                }
                long intRows = (int)sqlComm.ExecuteScalar();
                if (intRows > 0)
                    return true;
                else
                    return false;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Method executeSqlScalar
        /// purpose:-
        ///			-get the sql string and execute Query
        ///			-return the value returned by datasource
        /// </summary>
        /// <param name="strSql">SQL command</param>
        /// <returns>int(number return by aggreegate function).</returns>
        public int executeSqlScalar(string strSql)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.Text;
                sqlComm.CommandText = strSql;
                int intRows = (int)sqlComm.ExecuteScalar();
                return intRows;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Function SP Execute Scalar - Stored Procedure
        /// Purpose of the function
        ///     - Receive Values in Parameter
        ///     - Check for record exist or not.
        ///     - Return int value
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int SP_ExecuteSqlScalar(string strSql, SqlParameter[] param)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = strSql;
                SqlParameter sqlParam = new SqlParameter();
                foreach (SqlParameter loopParam in param)
                {
                    sqlParam = loopParam;
                    sqlComm.Parameters.Add(sqlParam);
                }
                return (int)sqlComm.ExecuteScalar();
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Function ExecuteNonQuery
        /// Purpose of the function
        ///     - Perform non query opertion with query stirng value
        ///     - return integer value
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string strSql)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.Text;
                sqlComm.CommandText = strSql;
                int intRows = sqlComm.ExecuteNonQuery();
                return intRows;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Function ExecuteNonQuery
        /// Purpose of the function
        ///     - Receive Value in Parameter
        ///     - Execute NonQuery - Insert,Update,Delete
        ///     - Return integer value
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>  
        public int ExecuteNonQuery(string strSql, SqlParameter[] param)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.Text;
                sqlComm.CommandText = strSql;
                SqlParameter sqlParam = new SqlParameter();
                foreach (SqlParameter loopParam in param)
                {
                    sqlParam = loopParam;
                    sqlComm.Parameters.Add(sqlParam);
                }
                int intRows = sqlComm.ExecuteNonQuery();
                return intRows;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Function ExecuteNonQuery For Stored Procedure
        /// Purpose of the Function
        /// Receive Parameter value and Execute Stored Procedure 
        /// Return Integer Value
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int ExecuteSP_NonQuery(string spName, SqlParameter[] param)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = spName;
                SqlParameter sqlParam = new SqlParameter();
                foreach (SqlParameter loopParam in param)
                {
                    sqlParam = loopParam;
                    sqlComm.Parameters.Add(sqlParam);
                }
                int intRows = sqlComm.ExecuteNonQuery();
                return intRows;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Function GetDataReader - Single Parameter
        /// Purpose of the function
        ///     - Execute DataReader
        ///     - Return DataReader 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(string strSql)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.Text;
                sqlComm.CommandText = strSql;
                SqlDataReader dReader;
                dReader = sqlComm.ExecuteReader(CommandBehavior.CloseConnection);
                return dReader;
            }
            finally
            {
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Function GetDataReader - 2 Parameter
        /// Purpose of the function
        ///     - Receive Value in Parameter
        ///     - Execute DataReader
        ///     - Return Data Reader
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>  
        public SqlDataReader GetDataReader(string strSql, SqlParameter[] param)
        {
            try
            {
                OpenConnection();
                SqlParameter sqlparam = new SqlParameter();
                sqlComm.CommandType = CommandType.Text;
                sqlComm.CommandText = strSql;
                sqlComm.Parameters.Clear();
                foreach (SqlParameter loopParam in param)
                {
                    sqlparam = loopParam;
                    sqlComm.Parameters.Add(sqlparam);
                }
                SqlDataReader dReader;
                dReader = sqlComm.ExecuteReader(CommandBehavior.CloseConnection);
                return dReader;
            }
            finally
            {
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Function SP_GetDataReader - With Parameter
        /// Purpose
        ///     - Execute Query using Store Procedure and return DataReader Object
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="spParam"></param>
        /// <returns></returns>    
        public SqlDataReader SP_GetDataReader(string spName, SqlParameter[] spParam)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = spName;
                SqlParameter param = new SqlParameter();
                SqlDataReader sqlDR;
                sqlComm.Parameters.Clear();
                foreach (SqlParameter loopParam in spParam)
                {
                    param = loopParam;
                    sqlComm.Parameters.Add(param);
                }
                sqlDR = sqlComm.ExecuteReader(CommandBehavior.CloseConnection);
                
                return sqlDR;
            }
            finally
            {
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Funtion GetDataTable
        /// Purpose
        ///     - Receive Value in Parameter    
        ///     - Return DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>   
        public DataTable GetDataTable(string strSql, SqlParameter[] param)
        {
            try
            {
                OpenConnection();
                SqlParameter SQLParam = new SqlParameter();
                sqlComm.CommandType = CommandType.Text;
                sqlComm.CommandText = strSql;
                sqlComm.Parameters.Clear();
                foreach (SqlParameter Loop_Param in param)
                {
                    SQLParam = Loop_Param;
                    sqlComm.Parameters.Add(SQLParam);
                }
                sqlDA.SelectCommand = sqlComm;
                DataTable DT = new DataTable();
                sqlDA.Fill(DT);
                return DT;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Funtion SP_GetDataTable - No Parameter
        /// Purpose
        ///     - Receive Value in Parameter    
        ///     - Return DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable SP_GetDataTable(string strSql)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = strSql;
                sqlDA.SelectCommand = sqlComm;
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                return dt;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Funtion SP_GetDataTable - With Parameter
        /// Purpose
        ///     - Receive Value in Parameter    
        ///     - Return DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>   
        public DataTable SP_GetDataTable(string strSql, SqlParameter[] param)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = strSql;
                SqlParameter SQLParam = new SqlParameter();
                sqlComm.Parameters.Clear();
                foreach (SqlParameter Loop_Param in param)
                {
                    SQLParam = Loop_Param;
                    sqlComm.Parameters.Add(SQLParam);
                }
                sqlDA.SelectCommand = sqlComm;
                DataTable DT = new DataTable();
                sqlDA.Fill(DT);
                return DT;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Created By Ranjan
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strSql)
        {
            try
            {
                OpenConnection();
                sqlDA = new SqlDataAdapter(strSql, sqlConn);
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                return dt;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Funtion GetDataSet
        /// Purpose
        ///     - Return DataSet 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string strSql)
        {
            try
            {
                OpenConnection();
                sqlDA = new SqlDataAdapter(strSql, sqlConn);
                DataSet DS = new DataSet();
                sqlDA.Fill(DS);
                return DS;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Funtion SP_GetDataSet
        /// Purpose        ///     
        ///     - Fetch the data from the datasource and return the data filled dataset
        /// </summary>
        /// <param name="strSql"></param>        
        /// <returns></returns>
        public DataSet SP_GetDataSet(string spName)
        {
            try
            {
                OpenConnection();
                SqlParameter SQLParam = new SqlParameter();
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = spName;
                sqlDA.SelectCommand = sqlComm;
                DataSet DS = new DataSet();
                sqlDA.Fill(DS);
                return DS;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Funtion SP_GetDataSet
        /// Purpose
        ///     - Receive Value in Parameter
        ///     - Fetch the data from the datasource and return the data filled dataset
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataSet SP_GetDataSet(string spName, SqlParameter[] param)
        {
            try
            {
                OpenConnection();
                SqlParameter SQLParam = new SqlParameter();
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = spName;
                sqlComm.Parameters.Clear();
                foreach (SqlParameter Loop_Param in param)
                {
                    SQLParam = Loop_Param;
                    sqlComm.Parameters.Add(SQLParam);
                }
                sqlDA.SelectCommand = sqlComm;
                DataSet DS = new DataSet();
                sqlDA.Fill(DS);
                return DS;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Funtion GetDataSet
        /// Purpose
        ///     - Receive Value in Parameter
        ///     - Fetch the data from the datasource and return the data filled dataset
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string strSql, SqlParameter[] param)
        {
            try
            {
                OpenConnection();
                SqlParameter SQLParam = new SqlParameter();
                sqlComm.CommandType = CommandType.Text;
                sqlComm.CommandText = strSql;
                sqlComm.Parameters.Clear();
                foreach (SqlParameter Loop_Param in param)
                {
                    SQLParam = Loop_Param;
                    sqlComm.Parameters.Add(SQLParam);
                }
                sqlDA.SelectCommand = sqlComm;
                DataSet DS = new DataSet();
                sqlDA.Fill(DS);
                return DS;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Funcion ExecuteSQLScalarObject
        /// Purpose
        ///     - Execute Scalar
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public object ExecuteSQLScalarObject(string strSQL)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.Text;
                sqlComm.CommandText = strSQL;
                object objectrows = (object)sqlComm.ExecuteScalar();
                return objectrows;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        /// <summary>
        /// Public Funcion ExecuteSQLScalarObject with two parameter
        /// Purpose
        ///     - Execute Scalar
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public object SP_ScalarObject(string spName, SqlParameter[] param)
        {
            try
            {
                OpenConnection();
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = spName;
                SqlParameter SQLParam = new SqlParameter();
                sqlComm.Parameters.Clear();
                foreach (SqlParameter Loop_Param in param)
                {
                    SQLParam = Loop_Param;
                    sqlComm.Parameters.Add(SQLParam);
                }
                object objectrows = (object)sqlComm.ExecuteScalar();
                return objectrows;
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }
    }
}