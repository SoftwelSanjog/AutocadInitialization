using System;
using System.Data;
using System.Data.SQLite;

namespace AutocadInitialization.Class
{


    public class SqliteClass
    {
        private string _dbPath;
        public string DBPath
        {
            get { return _dbPath; }
            set { _dbPath = value; }
        }

        public SqliteClass() { }

        /// <summary>
        /// Initialize Class with Dbpath
        /// </summary>
        /// <param name="dbpath"></param>
        public SqliteClass(string dbpath)
        {
            _dbPath = dbpath;
        }

        private string ConnectionString
        {
            get
            {
                string myConnString;
                myConnString = "Data Source=" + _dbPath + ";New=False;Compress=True;Synchronous=Off";
                return myConnString;
            }
        }

        public bool SetPassword(string password, string path)
        {
            SQLiteConnection conn;
            string myConnString;
            myConnString = "Data Source=" + path + ";New=False;Compress=True;Synchronous=Off";
            conn = new SQLiteConnection(myConnString);
            conn.Open();
            conn.ChangePassword(password);
            return conn.State == ConnectionState.Open;
        }

        /// <summary>
        /// Reads data from sqlite database
        /// </summary>
        /// <param name="ReadFields"></param>
        /// <param name="tableName"></param>
        /// <param name="Condition"></param>
        /// <param name="SortField"></param>
        /// <param name="SortOrder"></param>
        /// <param name="GroupByValue"></param>
        /// <returns> dataTable </returns>
        public DataTable ReadDataFromTable(string ReadFields, string tableName, string Condition = "", string SortField = "", string SortOrder = "ASC", string GroupByValue = "")
        {
            SQLiteConnection myconn = new SQLiteConnection();
            string Cmd;
            Cmd = "SELECT " + ReadFields + " FROM " + tableName;
            if (!string.IsNullOrEmpty(Condition))
            {
                Cmd = Cmd + " WHERE " + Condition;
            }
            if (!string.IsNullOrEmpty(GroupByValue.Trim()))
            {
                Cmd = Cmd + " GROUP BY " + GroupByValue;
            }
            if (!string.IsNullOrEmpty(SortField))
            {
                Cmd = Cmd + " ORDER BY " + SortField + " " + SortOrder;
            }
            try
            {
                DataTable tbl = new DataTable();
                myconn.ConnectionString = this.ConnectionString;
                myconn.Open();
                SQLiteDataAdapter OAdapter = new SQLiteDataAdapter(Cmd, myconn);
                OAdapter.Fill(tbl);
                return tbl;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                myconn.Dispose();
            }
        }

        /// <summary>
        /// Reads Data From sqlite database.
        /// </summary>
        /// <param name="cmdStr"></param>
        /// <returns> Datatable</returns>
        public DataTable ReadDataFromTable(string cmdStr)
        {
            SQLiteConnection myconn = new SQLiteConnection();
            try
            {
                myconn.ConnectionString = this.ConnectionString;
                myconn.Open();
                DataTable tbl = new DataTable();
                SQLiteDataAdapter OAdapter = new SQLiteDataAdapter(cmdStr, myconn);
                OAdapter.Fill(tbl);
                return tbl;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                myconn.Dispose();
            }
        }

        /// <summary>
        /// Delete Record from Sqlite Database.
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="sCondition"></param>
        /// <returns></returns>
        public bool DeleteRecord(string sTableName, string sCondition = "")
        {
            string Cmd;
            try
            {
                Cmd = "DELETE FROM " + sTableName;
                if (!string.IsNullOrEmpty(sCondition))
                {
                    Cmd = Cmd + " WHERE " + sCondition;
                }
                ExecuteByQuery(Cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Insert Record to Sqlite Database.
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="sFieldValue"></param>
        /// <param name="sFieldName"></param>
        /// <returns></returns>
        public bool InsertRecord(string sTableName, string sFieldValue, string sFieldName = "")
        {
            string Cmd;
            try
            {
                Cmd = "INSERT INTO " + sTableName;
                if (!string.IsNullOrEmpty(sFieldName))
                {
                    Cmd = Cmd + " ( " + sFieldName + " )";
                }
                Cmd = Cmd + " VALUES(";
                Cmd = Cmd + sFieldValue + ")";
                ExecuteByQuery(Cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update data in Sqlite Database.
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="sFieldValue"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public bool UpdateRecord(string sTableName, string sFieldValue, string condition = "")
        {
            string Cmd;
            try
            {
                Cmd = "UPDATE " + sTableName + " SET " + sFieldValue;
                if (!string.IsNullOrEmpty(condition))
                {
                    Cmd = Cmd + " WHERE " + condition;
                }
                ExecuteByQuery(Cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ExecuteByQuery(string sCmd)
        {
            SQLiteConnection myconn = new SQLiteConnection();
            try
            {
                myconn.ConnectionString = this.ConnectionString;
                myconn.Open();
                SQLiteCommand oSqlCmd;
                oSqlCmd = new SQLiteCommand(sCmd, myconn);
                oSqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myconn.Dispose();
            }
        }

        public long UserVersion()
        {
            SQLiteConnection myconn = new SQLiteConnection();
            try
            {
                myconn.ConnectionString = this.ConnectionString;
                myconn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(myconn))
                {
                    cmd.CommandText = "pragma user_version;";
                    return Convert.ToInt64(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                myconn.Close();
            }
        }

        public long IncreaseUserVersion()
        {
            SQLiteConnection myconn = new SQLiteConnection();
            try
            {
                myconn.ConnectionString = this.ConnectionString;
                myconn.Open();
                long version = UserVersion();
                using (SQLiteCommand cmd = new SQLiteCommand(myconn))
                {
                    cmd.CommandText = string.Format("PRAGMA user_version={0}", version + 1);
                    cmd.ExecuteNonQuery();
                }
                return UserVersion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                myconn.Close();
            }
        }

        public bool Transaction(string[] sSQLCmd)
        {
            SQLiteConnection myconn = new SQLiteConnection();
            SQLiteTransaction sqlTrans = null;
            SQLiteCommand oSqlCmds = new SQLiteCommand();
            myconn.ConnectionString = this.ConnectionString;
            myconn.Open();
            sqlTrans = myconn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                int i = 0;
                oSqlCmds.Connection = myconn;
                oSqlCmds.Transaction = sqlTrans;
                i = 0;
                while (i <= sSQLCmd.Length - 1)
                {
                    oSqlCmds.CommandText = sSQLCmd[i];
                    oSqlCmds.ExecuteNonQuery();
                    i++;
                }
                sqlTrans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    sqlTrans.Rollback();
                }
                catch (SQLiteException ex2)
                {
                    Console.WriteLine(ex2.Message);
                }
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                sSQLCmd = null;
                myconn.Dispose();
            }
        }
    }

}
