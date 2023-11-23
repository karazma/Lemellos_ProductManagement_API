using MySqlConnector;
using System;
using System.Data;
using System.Reflection;

namespace Product.Management.Common.MariaDataAccess
{
    public class DataHelper
    {
        private string m_txtConnectionString = null;
        private MySqlConnection OpenDatabase()
        {
            try
            {
                MySqlConnection dbConn = new MySqlConnection(m_txtConnectionString);
                dbConn.Open();
                return dbConn;
            }
            catch (System.Exception e)
            {
                throw new Exception("An unexpected error occurred in clsView_SQLData.OpenDatabase.  View inner exception information for details.", e);
            }
        }
        public void CloseDatabase(MySqlConnection dbConn)
        {
            try
            {
                dbConn.Close();
            }
            catch { }
        }
        public void ExecuteNonQuery(object query)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd = null;

            try
            {
                conn = OpenDatabase();
                if (query.GetType().Name != "OracleCommand")
                {
                    cmd = conn.CreateCommand();
                    cmd.CommandText = query.ToString();
                }
                else
                {
                    cmd = (MySqlCommand)query;
                    cmd.Connection = conn;
                }
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                throw new Exception("An unexpected error occurred in clsDataHelper.ExecuteQuery executing the query: " + cmd.CommandText, e);
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                if (conn != null)
                    CloseDatabase(conn);
            }
        }
        public DataTable ExecuteQuery(object query, string txtTableName)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataAdapter da = null;

            try
            {
                conn = OpenDatabase();
                if (query.GetType().Name != "OracleCommand")
                {
                    cmd = conn.CreateCommand();
                    cmd.CommandText = query.ToString();
                }
                else
                {
                    cmd = (MySqlCommand)query;
                    cmd.Connection = conn;
                }

                da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, txtTableName);

                DataTable newTable = ds.Tables[0];
                ds.Tables.Remove(newTable);
                ds.Dispose();

                return newTable;

            }
            catch (System.Exception e)
            {
                throw new Exception("An unexpected error occurred in clsDataHelper.ExecuteQuery executing the query: " + cmd.CommandText, e);
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                if (da != null)
                    da.Dispose();
                if (conn != null)
                    CloseDatabase(conn);
            }
        }
        public DataHelper(string txtConnectionString)
        {
            if (txtConnectionString.Length == 0)
                throw new Exception("Must supply a connection string to the database.");

            m_txtConnectionString = txtConnectionString;
        }
        private bool CompareVersions(byte[] v1, byte[] v2)
        {
            int i = 0;
            foreach (byte b in v1)
            {
                if (b != v2[i])
                    return false;
                i++;
            }
            return true;
        }
        private SqlDbType GetDBType(Type type)
        {
            switch (type.Name)
            {
                case "Guid":
                    return SqlDbType.UniqueIdentifier;

                case "Int32":
                    return SqlDbType.Int;

                case "String":
                    return SqlDbType.VarChar;

                case "Boolean":
                    return SqlDbType.Bit;

                case "DateTime":
                case "Date":
                    return SqlDbType.DateTime;

                default:
                    return SqlDbType.VarChar;
            }

        }
        public void LoadObject(object objToLoad, string txtQuery)
        {
            // execute the query
            DataTable dtData = ExecuteQuery(txtQuery, "basedata");
            // must return exactly one record...
            if (dtData.Rows.Count == 0)
                throw new Exception("Object data not found with the query: " + txtQuery);
            else if (dtData.Rows.Count > 1)
                throw new Exception("Query returned more than one row - query must return a unique row representing the object's data.  Query: " + txtQuery);

            // using reflection, set the object properties
            Type objectType = objToLoad.GetType();
            foreach (DataColumn col in dtData.Columns)
            {
                try
                {
                    PropertyInfo pi = objectType.GetProperty(col.ColumnName);
                    if (pi != null)
                        pi.SetValue(objToLoad, dtData.Rows[0][col.ColumnName], null);
                }
                catch (System.Exception e)
                {
                    // right now ignore errors - later might have special data loaders... ? 
                    Console.WriteLine(e.ToString());
                }

            }
        }

    }
}
