/*  Started : 26 Sep 2007
    Developed by Worldlink Tech Team
    Third tier class to interact with database
  */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DBhandler
{
    public class DBAccess
    {
        //Open sqlconnection n return
        //protected static String strConn = ConfigurationSettings.AppSettings["Connection String"].ToString();
       
        static protected SqlConnection DBOpenconnection(string strConn)
        {           
            try
            {
                SqlConnection Tempconn = new SqlConnection(strConn);
                //if (Tempconn.State == ConnectionState.Open)
                //{
                //    DBCloseconnection(Tempconn);
                //}
               
                if (Tempconn.State == ConnectionState.Closed)
                    Tempconn.Open();
                return Tempconn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
                //error log
                //return null;
            }
            
        }
        static protected SqlConnection DBOpenconnection()
        {
            //SqlConnection Tempconn ;
            try
            {
                SqlConnection Tempconn = new SqlConnection(DAO.conString);
                //if (Tempconn.State == ConnectionState.Open)
                //{
                //    DBCloseconnection(Tempconn);
                //}
                Tempconn.ConnectionString = DAO.conString;
                if (Tempconn.State == ConnectionState.Closed)
                    Tempconn.Open();
                return Tempconn;
            }
            catch(Exception ex)
            {
                //error log
                throw new Exception(ex.ToString()); 
                //return null;
            }
             
        }
        //close connection if it is opened
        static public void DBCloseconnection(SqlConnection Tempconn)
        {
            try
            {
                if (Tempconn == null || Tempconn.State == ConnectionState.Open)
                {
                    Tempconn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace); 
                //error log
            }
        }
    }
    public class DAO : DBAccess
    {
        private static SqlConnection SQLconn;
        public static String conString = ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;

        public DAO()
        {
           
        }
        static public SqlConnection GetSqlConnection(string sQlConn)
        {
            try
            {
                return DBOpenconnection(sQlConn);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString()); 
            }
        }
        //find wheather the record is there in table, returns true if record found
        static public SqlConnection GetSqlConnection()
        {
            try
            {
                return DBOpenconnection(DAO.conString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        static public SqlDataReader getDataReader(string str4Conn, SqlCommand cmd)
        {

            try
            {
                SQLconn = DBOpenconnection(str4Conn);

                cmd.Connection = SQLconn;

                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString()); 
                //error log
                //return null;
            }
            finally
            {
                cmd.Dispose();
                // DBCloseconnection(SQLconn);
            }
        }
        static public SqlDataReader GetDataReader(string str4Conn, SqlCommand cmd)
        {
            try
            {
                SQLconn = DBOpenconnection(str4Conn);

                cmd.Connection = SQLconn;

                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                //error log
                //return null;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                cmd.Dispose();
                //DBCloseconnection(SQLconn);
            }
        }
        static public bool findRecord(string SQLQuery, string str4Conn)
        {
            SqlCommand cmd;
            SqlDataReader reader;
            bool isExist;
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                cmd = new SqlCommand(SQLQuery, SQLconn);
                reader = cmd.ExecuteReader();
                isExist = Convert.ToBoolean(reader.Read());
                reader.Dispose();
                return isExist;
            }
            catch (Exception ex)
            {
                //error log
                //return false;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                cmd = null;
                reader = null;
                DBCloseconnection(SQLconn);
            }
        }
        //returns SqlDataReader 
        static public SqlDataReader getDataReader(string SQLQuery, string str4Conn)
        {
            SqlCommand cmd=null;
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                cmd = new SqlCommand(SQLQuery, SQLconn);
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                //error log
                //return null;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                // DBCloseconnection(SQLconn);
            }
        }
        static public SqlDataReader getDataReader(string procedureName,SqlParameter[] param)
        {
            SqlCommand cmd=null;
            try
            {
                SQLconn = DBOpenconnection(DAO.conString);
                cmd = new SqlCommand();
                cmd.CommandText = procedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = SQLconn;
                foreach (SqlParameter p in param)
                {
                    cmd.Parameters.Add(p);
                }
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                //error log
                //return null;
                throw new Exception(ex.ToString());
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                // DBCloseconnection(SQLconn);
            }
        }
        //overloading function, returns datatable -
        static public DataTable getDataTable(string SQLQuery, string str4Conn)
        {
            SqlDataAdapter da;
            DataSet ds;
            try
            {
                ds = new DataSet();
                SQLconn = DBOpenconnection(str4Conn);
                da = new SqlDataAdapter(SQLQuery, SQLconn);
                da.Fill(ds, "01");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                //error log
                //return null;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                da = null;
                ds = null;
                DBCloseconnection(SQLconn);
            }
        }
        //overloading function, returns datatable -
        static public DataTable getDataTable(string fldname1, string fldname2, string tablename, string str4Conn)
        {
            SqlDataAdapter da;
            DataSet ds;
            string SQLQuery = "select " + fldname1 + ", " + fldname2 + " from " + tablename;
            ds = new DataSet();
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                da = new SqlDataAdapter(SQLQuery, SQLconn);
                da.Fill(ds, "01");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                //error log
                //return null;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                da = null;
                ds = null;
                DBCloseconnection(SQLconn);
            }
        }
        static public DataTable getDataTable(SqlDataAdapter da, string str4Conn)
        {
            DataSet ds = new DataSet();
            //SqlConnection conDB = new SqlConnection(ConnStr);
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                da.SelectCommand.Connection = SQLconn;
                da.SelectCommand.ExecuteNonQuery();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                //error log
                //return null;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                da = null;
                ds = null;
                DBCloseconnection(SQLconn);
            }
        }

        //Returns dataset -
        static public DataSet GetDataSet(string str4Conn, SqlCommand cmd)
        {
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                //da.SelectCommand = cmd;
                cmd.Connection = SQLconn;
                //da.SelectCommand.Connection = SQLconn;
                //da.SelectCommand.ExecuteNonQuery();
                da.Fill(ds, "tempTable");
                return ds;

            }
            catch (Exception ex)
            {
                return null;
                //throw new Exception(ex.ToString()); 
            }
            finally
            {
                cmd = null;
                ds = null;
                da = null;
                DBCloseconnection(SQLconn);
            }
        }

        static public DataSet GetDataSet(string str4Conn, SqlCommand cmd, string sTableName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = SQLconn;
                da.SelectCommand.ExecuteNonQuery();
                da.Fill(ds, sTableName);
                return ds;

            }
            catch (Exception ex)
            {
                //return null;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                cmd = null;
                ds = null;
                da = null;
                DBCloseconnection(SQLconn);
            }
        }
        static public DataSet getDataSet(SqlDataAdapter da, string str4Conn)
        {
            DataSet ds = new DataSet();
            //SqlConnection conDB = new SqlConnection(ConnStr);
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                da.SelectCommand.Connection = SQLconn;
                da.SelectCommand.ExecuteNonQuery();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                //error log
                //return null;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                da = null;
                ds = null;
                DBCloseconnection(SQLconn);
            }
        }
        static public DataSet getDataSet(string SQLQuery, string str4Conn)
        {
            SqlDataAdapter da;
            DataSet ds;
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                ds = new DataSet();
                da = new SqlDataAdapter(SQLQuery, str4Conn);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                //error log
                //return null;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                da = null;
                ds = null;
                DBCloseconnection(SQLconn);
            }
        }
        //Returns dataview
        static public DataView getDataView(string SQLQuery, string str4Conn)
        {
            SqlDataAdapter da;
            DataSet ds;
            DataTable dt;
            try
            {
                ds = new DataSet();
                da = new SqlDataAdapter(SQLQuery, str4Conn);
                da.Fill(ds, "01");
                dt = ds.Tables[0];
                return new DataView(dt);
            }
            catch (Exception ex)
            {
                //error log
                //return null;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                da = null;
                ds = null;
                DBCloseconnection(SQLconn);
            }
        }
        //overloading function, get the new value of given column parameter by adding 1
        static public double genNextCode(string colName, string tableName, string str4Conn)
        {
            DataView dv;
            try
            {
                dv = getDataView("select isnull(max( " + colName + "),0) from " + tableName, str4Conn);
                return Convert.ToDouble(dv[0][0]) + 1;
            }
            catch (Exception ex)
            {
                //error log
                //return -1;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                dv = null;
                DBCloseconnection(SQLconn);
            }
        }
        //overloading function, get the new value of given column parameter by adding 1
        static public double genNextCode(string colName, string tableName, double initialValue, string str4Conn)
        {
            DataView dv;
            try
            {
                dv = getDataView("select isnull(max( " + colName + ")," + initialValue + ") from " + tableName, str4Conn);
                return Convert.ToDouble(dv[0][0]) + 1;
            }
            catch (Exception ex)
            {
                //error log
                //return -1;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                dv = null;
                DBCloseconnection(SQLconn);
            }
        }
        //overloading function, get the new value of given column parameter by adding 1
        static public string genNextCode(string colName, string tableName, string startsWith, int Length, string str4Conn)
        {
            DataView dv;
            string newCode;
            try
            {
                if (Length > startsWith.Length)
                {
                    dv = getDataView("select isnull(max(" + colName + "),0) from " + tableName + " where " + colName + " like '" + startsWith + "%'", str4Conn);
                    if (dv[0][0].ToString() == "0")
                    {
                        newCode = "1";
                        newCode = startsWith + newCode.PadLeft(Length - startsWith.Length, '0');
                        return newCode;
                    }
                    else
                    {
                        string str = (dv[0][0]).ToString(); ;
                        newCode = str.Substring(startsWith.Length + 1) + 1;
                        newCode = startsWith + newCode.PadLeft(Length - startsWith.Length, '0');
                        return newCode;
                    }
                }
                else
                {
                    //error log
                    return "-1";
                }
            }
            catch (Exception ex)
            {
                //error log
                //return "-1";
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                dv = null;
                DBCloseconnection(SQLconn);
            }
        }
        // database manupulation(add,delete,update)
        static public Int16 ExecuteQuery(string SQLQuery, string str4Conn)
        {
            SqlCommand cmd;
            SqlTransaction transaction;
            Int16 rowsAffected;
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                cmd = new SqlCommand();
                transaction = SQLconn.BeginTransaction();
                cmd.Connection = SQLconn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQLQuery;
                cmd.Transaction = transaction;
                rowsAffected = Convert.ToInt16(cmd.ExecuteNonQuery());
                transaction.Commit();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                //return -1;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                cmd = null;
                transaction = null;
                DBCloseconnection(SQLconn);
            }
        }
        static public Int16 CreateTemporaryTable(string SQLQuery, string str4Conn)
        {
            SqlCommand cmd;
            SqlTransaction transaction;
            Int16 rowsAffected;
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                cmd = new SqlCommand();
                transaction = SQLconn.BeginTransaction();
                cmd.Connection = SQLconn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQLQuery;
                cmd.Transaction = transaction;
                rowsAffected = Convert.ToInt16(cmd.ExecuteNonQuery());
                transaction.Commit();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                //return -1;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                cmd = null;
                transaction = null;
                //DBCloseconnection(SQLconn);
            }
        }
        static public Int16 ExecuteQuery(string str4Conn, SqlCommand[] cmd)
        {
            SqlTransaction transaction;
            Int16 rowsAffected = 0;
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                transaction = SQLconn.BeginTransaction();
                for (int i = 0; i <= cmd.Length - 1; i++)
                {
                    cmd[i].Connection = SQLconn;
                    cmd[i].CommandType = CommandType.StoredProcedure;
                    cmd[i].Transaction = transaction;
                    rowsAffected = Convert.ToInt16(cmd[i].ExecuteNonQuery());
                }
                transaction.Commit();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                //return -1;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                cmd = null;
                transaction = null;
                DBCloseconnection(SQLconn);
            }
        }
        static public Int16 ExecuteQuery(string str4Conn, SqlCommand cmd)
        {
            SqlTransaction transaction;
            Int16 rowsAffected = 0;
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                transaction = SQLconn.BeginTransaction();
                cmd.Connection = SQLconn;                
                cmd.Transaction = transaction;
                rowsAffected = Convert.ToInt16(cmd.ExecuteNonQuery());
                transaction.Commit();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                //return -1;
                throw  ex; 
            }
            finally
            {
                cmd = null;
                transaction = null;
                DBCloseconnection(SQLconn);
            }
        }

        static public Int16 ExecuteQuery(string SQLQuery, string str4Conn, string[] sql)
        {
            SqlCommand cmd;
            SqlTransaction transaction;
            Int16 rowsAffected;
            try
            {
                SQLconn = DBOpenconnection(str4Conn);

                cmd = new SqlCommand();
                transaction = SQLconn.BeginTransaction();
                cmd.Connection = SQLconn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQLQuery;
                cmd.Transaction = transaction;
                rowsAffected = Convert.ToInt16(cmd.ExecuteNonQuery());
                transaction.Commit();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                //return -1;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                cmd = null;
                transaction = null;
                DBCloseconnection(SQLconn);
            }
        }
        static public string GetString(string SQLQuery, string str4Conn, string strColumnName)
        {
            SqlDataAdapter da;
            DataSet ds;
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                ds = new DataSet();
                da = new SqlDataAdapter(SQLQuery, str4Conn);
                da.Fill(ds, "01");
                if (ds.Tables["01"].Rows.Count > 0)
                    foreach (DataRow dr in ds.Tables["01"].Rows)
                        return dr[strColumnName].ToString();
                return "";
            }
            catch (Exception ex)
            {
                //error log
                //return "";
                throw new Exception(ex.ToString()); 
            }
            finally
            {

                da = null;
                ds = null;
                DBCloseconnection(SQLconn);
            }
            //return "";
        }

        //Check if Tour No exists in Tour Basic or Not
        static public int CheckTourNo(string str4Conn, SqlCommand cmd)
        {
            int nSelectPrimaryKey = 0;
            SqlDataAdapter da;
            DataSet ds;
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                ds = new DataSet();
                da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                cmd.Connection = SQLconn;


                da.Fill(ds, "01");
                if (ds.Tables["01"].Rows.Count == 0)
                {
                    nSelectPrimaryKey = -1;

                }
                else if (ds.Tables["01"].Rows.Count > 0)
                {
                    nSelectPrimaryKey = 1;

                }
                return nSelectPrimaryKey;

            }


            catch (Exception ex)
            {
                //error log
                //return -1;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                da = null;
                ds = null;
                DBCloseconnection(SQLconn);

            }

        }

        // gets the user type
        static public Int16 GetUserProfile(string SQLQuery, string str4Conn, ref int nVendorId, ref string sUserType)
        {
            Int16 nGetUserProfile = -1;
            SqlDataAdapter da;
            DataSet ds;
            try
            {
                ds = new DataSet();
                SQLconn = DBOpenconnection(str4Conn);
                da = new SqlDataAdapter(SQLQuery, SQLconn);
                da.Fill(ds, "01");
                if (ds.Tables["01"].Rows.Count == 0)
                    nGetUserProfile = 2;
                else if (ds.Tables["01"].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables["01"].Rows)
                    {
                        sUserType = dr["user_profile_user_type"].ToString();
                        nVendorId = int.Parse(dr["vendor_id"].ToString());
                    }
                    if (ds.Tables["01"].Columns["vendor_id"].ToString() == null)
                    {
                        nVendorId = 0;
                        nGetUserProfile = 1;
                    }
                    else
                    {

                        nGetUserProfile = 1;
                    }
                    nGetUserProfile = 2;
                }

                return nGetUserProfile;
            }
            catch (Exception ex)
            {
                //error log
                //return -1;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                da = null;
                ds = null;
                DBCloseconnection(SQLconn);
            }

        }

        static public DataTable GetDataTable(SqlCommand cmd, string str4Conn)
        {
            SqlDataAdapter da;
            DataSet ds;

            try
            {
                // cmd.Connection = new SqlConnection("str");
                SQLconn = DBOpenconnection(str4Conn);
                cmd.Connection = SQLconn;
                ds = new DataSet();
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "01");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                //error log
                //return null;
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                da = null;
                ds = null;
                DBCloseconnection(SQLconn);
            }

        }

        /// <summary>
        /// It returns a data table through data reader. so that, without breaking the active connection
        /// we can use data table
        /// </summary>
        /// <param name="cmd">Sqlcommand along with command text and open connection</param>
        /// <returns>Returns Datatable</returns>
        public static DataTable GetDataTable(SqlCommand cmd)
        {
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable temp = new DataTable();
            try
            {
                
                temp.Load(reader, LoadOption.OverwriteChanges);
                return temp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                temp.Dispose();
                reader.Dispose();
            }
        }

        /// <summary>
        /// Returns the datatable containing the records on the basis of storeprocedure
        /// </summary>
        /// <param name="storeProcedureName">Name of storeprocedure</param>
        /// <param name="parameters">Sqlparameters as array</param>
        /// <returns>Returns Datatable</returns>
        public static DataTable GetDataTable(String storeProcedureName, SqlParameter []parameters)
        {
            try
            {
                DataTable temp = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = DAO.GetSqlConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storeProcedureName;
                    if (parameters != null && parameters.Length>0)
                    {
                        foreach (SqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {                      
                        temp.Load(reader, LoadOption.OverwriteChanges);
                    }
                }
                return temp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }        
        }

        public static DataTable GetDataTable(String storeProcedureName, SqlCommand cmd)
        {
            try
            {
                DataTable temp = new DataTable();

                cmd.Connection = DAO.GetSqlConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storeProcedureName;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    temp.Load(reader, LoadOption.OverwriteChanges);
                }

                return temp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                cmd.Dispose();//added by prakash
            }
        }
        /// <summary>
        /// Finds the value and return true if found
        /// </summary>
        /// <param name="cmd">Sql command with where condition</param>
        /// <returns>Returns true if record found</returns>
        public static bool Find(SqlCommand cmd)
        {
            SqlConnection con = DAO.GetSqlConnection(DAO.conString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            try
            {
                cmd.Connection = con;
                Object obj = cmd.ExecuteScalar();
                if (obj != null)
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                con.Close();
            }
            //return false;
        }

        /// <summary>
        /// Executes the select statement and returns DataRow if record found.
        /// </summary>
        /// <param name="selectCommand">Select command as string</param>
        /// <returns>Returns DataRow or null on the basis of the record availability.</returns>
        public static DataRow Find(String selectCommand)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DAO.conString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(selectCommand, con))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds, "tempTable");
                            if (ds.Tables["tempTable"].Rows.Count > 0)
                                return ds.Tables["tempTable"].Rows[0];
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString()); 
            }
        }

        //Author: Wlinktech team
        //Created on : Sunday, December 16, 2007 
        /// <summary>
        /// Searches the value into specified table and returns true if available.
        /// </summary>
        /// <param name="tableName">The name of table where the record to be searched</param>
        /// <param name="fieldName">Database field name</param>
        /// <param name="fieldValue">Database filed value to be searched</param>
        /// <returns></returns>
        public static bool FindSingleByFieldAndValue(String tableName, String fieldName, String fieldValue)
        {
            SqlConnection con = DAO.GetSqlConnection(DAO.conString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select " + fieldName + " from " + tableName + " where " + fieldName + " = @fieldValue";
                cmd.Parameters.AddWithValue("@fieldValue", fieldValue);
                Object obj = cmd.ExecuteScalar();
                if (obj != null)
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                con.Close();
            }
        }

        //Author: Wlinktech team
        //Created on : Sunday, December 16, 2007 
        /// <summary>
        /// Executes the select query and returns true if receord found. It should be used only for search record.
        /// </summary>
        /// <param name="selectQuery">Sql select query to search record</param>
        /// <returns>Returns true, record found</returns>
        public static bool FindSingleByFieldAndValue(String selectQuery)
        {
            SqlConnection con = DAO.GetSqlConnection(DAO.conString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = selectQuery;
                Object obj = cmd.ExecuteScalar();
                if (obj != null)
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString()); 
            }
            finally
            {
                con.Close();
            }
        }
        public static String Find(String tableName, String filterField, String displayField, String filterValue )
        {
            SqlConnection con = DAO.GetSqlConnection(DAO.conString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select " + displayField + " from " + tableName + " where " + filterField + " = @filterValue";
                cmd.Parameters.AddWithValue("@filterValue", filterValue);
                object obj = cmd.ExecuteScalar();
                if (obj != null)
                    return obj.ToString();

                return String.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        //Author: Wlinktech team
        //Created on : Sunday, December 16, 2007 
        /// <summary>
        /// Executes the storeprocedure and returns dataset.
        /// </summary>
        /// <param name="storeProcedureName">Name of storeprocedure</param>
        /// <param name="sqlParams">paramaters as SqlParameters[]</param>
        /// <returns>Returns dataset with 'tempTable' tablename</returns>
        public static DataSet GetDataSetByStoreProcedure(String storeProcedureName, SqlParameter[] sqlParams)
        {
            try
            {
                using (SqlCommand cmdSelect = new SqlCommand())
                {
                    cmdSelect.Connection = DAO.GetSqlConnection(DAO.conString);
                    cmdSelect.CommandType = CommandType.StoredProcedure;
                    cmdSelect.CommandText = storeProcedureName;
                    if (sqlParams != null)
                    {
                        foreach (SqlParameter parm in sqlParams)
                        {
                            cmdSelect.Parameters.Add(parm);
                        }
                    }
                    using (SqlDataAdapter oAdapter = new SqlDataAdapter(cmdSelect))
                    {
                        DataSet ds = new DataSet();
                        oAdapter.Fill(ds, "tempTable");
                        return ds;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString()); 
            }
        }

        private static SqlConnection con = new SqlConnection(DAO.conString);

        /// <summary>
        /// Creates the temporary connection until application is closed.
        /// </summary>
        /// <returns>Returns sqlconnection</returns>
        public static SqlConnection GetTempConnection()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                return con;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString()); 
            }
        }

        /// <summary>
        /// Closes the active connection used for temporary tables. It automatically drops all temporary
        /// tables associated with this connection.
        /// </summary>
        public static void CloseTempConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString()); 
            }
        }

        /// <summary>
        /// Drops the particular temporary tables from the database.
        /// </summary>
        /// <param name="tableName">The name of Temporary table</param>
        public static void DropParticularTempTable(String tableName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = DAO.GetTempConnection();
                    cmd.CommandText = "IF(object_id('tempdb.." + tableName + "') IS NOT NULL) BEGIN DROP TABLE " + tableName + " END";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString()); 
            }
        }

        /// <summary>
        /// Drops the particular temporary tables from the database on the basis of supplied table array.
        /// </summary>
        /// <param name="tableName">The name of Temporary table</param>
        public static void DropParticularTempTable(String []tableNames)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = DAO.GetTempConnection();
                    foreach (String tableName in tableNames)
                    {
                        cmd.CommandText = "IF(object_id('tempdb.." + tableName + "') IS NOT NULL) BEGIN DROP TABLE " + tableName + " END";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// Executes the query on the basic of specified storeprocedure
        /// </summary>
        /// <param name="storeProcedureName">Name of storeprocedure</param>
        /// <param name="sqlParams">Sqlparameters</param>
        /// <returns>Returns number of rows affected.</returns>
        public static int ExecuteNonQuery(String storeProcedureName, SqlParameter []sqlParams)
        {
            try
            {
                int rowAffected = 0;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = DAO.GetSqlConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storeProcedureName;

                    if (cmd.Parameters.Count > 0)
                        cmd.Parameters.Clear();

                    if (sqlParams != null)
                    {
                        foreach (SqlParameter param in sqlParams)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    rowAffected = cmd.ExecuteNonQuery();
                }
                return rowAffected;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                DAO.GetSqlConnection().Close();
            }
        
        }


        static public SqlDataReader getDataReader(string procedureName)
        {
            SqlCommand cmd = null;
            try
            {
                SQLconn = DBOpenconnection(DAO.conString);
                cmd = new SqlCommand();
                cmd.CommandText = procedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = SQLconn;
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                //error log
                //return null;
                throw new Exception(ex.ToString());
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                // DBCloseconnection(SQLconn);
            }
        }

        static public int ExecuteScalar(string str4Conn, SqlCommand cmd)
        {
            SqlTransaction transaction;
            int nResult = 0;
            try
            {
                SQLconn = DBOpenconnection(str4Conn);
                transaction = SQLconn.BeginTransaction();
                cmd.Connection = SQLconn;
                cmd.Transaction = transaction;
                nResult = Convert.ToInt32 (cmd.ExecuteScalar());
                transaction.Commit();
                return nResult;
            }
            catch (Exception ex)
            {
                return 0;
                //throw ex;
            }
            finally
            {
                cmd = null;
                transaction = null;
                DBCloseconnection(SQLconn);
            }
        }
        
    }

}
