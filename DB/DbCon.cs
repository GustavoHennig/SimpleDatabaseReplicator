/**
 * Copyright 2006-2018 Gustavo Augusto Hennig
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 **/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SimpleDatabaseReplicator.SQL;
using System.Data.Common;
using SimpleDatabaseReplicator.SQL.Databases;


namespace SimpleDatabaseReplicator.DB
{
    public class DbCon : IDisposable
    {

        private DbConnection dbConnection;
        public DbConnectionInfo DbConnectionInfo;

        public DbCon(DbConnectionInfo dbConnectionInfo)
        {
            DbConnectionInfo = dbConnectionInfo;
            dbConnection = dbConnectionInfo.DbType.BuildCoonnection(dbConnectionInfo.ConnectionString);
            CheckConnection();
        }

        public object ExecuteScalar(string sql)
        {
            using (IDbCommand com = dbConnection.CreateCommand())
            {
                com.CommandText = sql;
                return com.ExecuteScalar();
            }
        }

        public int ExecuteSQL(string SQL)
        {

            CheckConnection();
            using (IDbCommand com = dbConnection.CreateCommand())
            {
                com.CommandText = SQL;

                return com.ExecuteNonQuery();
            }

        }



        private void CheckConnection()
        {
            if (dbConnection.State != System.Data.ConnectionState.Open)
            {
                dbConnection.Open();
            }
        }


        /// <summary>
        /// Must be disposed
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IDataReader ExecuteDataReader(string sql)
        {

            CheckConnection();
            IDbCommand com = dbConnection.CreateCommand();
            com.CommandText = sql;
            //SqlDataReader dr = com.ExecuteReader(System.Data.CommandBehavior.KeyInfo);
            //
            return com.ExecuteReader(System.Data.CommandBehavior.KeyInfo | CommandBehavior.SequentialAccess);

        }


        public long CountRegs(string table, string RetrieveDataCondition, BaseDbType dialect)
        {
            string sql = "select count(*) from " + dialect.FormatDbObj(table) + " " + RetrieveDataCondition;
            using (IDataReader dr = this.ExecuteDataReader(sql))
                if (dr.Read())
                {
                    return Convert.ToInt64(dr.GetValue(0));
                }
                else
                {
                    return 0;
                }
        }

        public bool TableExists(string tablename)
        {
            CheckConnection();
            DataTable dt = dbConnection.GetSchema("Tables");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[2].ToString().ToUpper() == tablename.ToUpper())
                {
                    return true;
                }

            }
            return false;
        }


        /// <summary>
        /// Get list of all table without schema
        /// </summary>
        /// <returns></returns>
        public List<TableInfo> GetAllTables()
        {

            List<TableInfo> ret = new List<TableInfo>();
            using (IDataReader dr = ExecuteDataReader(DbConnectionInfo.DbType.AllTablesCommand))
            {
                while (dr.Read())
                {
                    ret.Add(new TableInfo(Convert.ToString(dr[0])));
                }

            }
            return ret;
        }

        public long GetMax(string tableName, string fiedName)
        {

            using (IDataReader dr = ExecuteDataReader("select max(" + DbConnectionInfo.DbType.FormatDbObj(fiedName) + ") mx from " + DbConnectionInfo.DbType.FormatDbObj(tableName)))
            {
                if (dr.Read())
                {
                    object o = dr[0];
                    if (o == null || o is DBNull)
                        return 0;
                    else
                        return long.Parse(o.ToString());
                }
            }
            return 0;
        }


        public void Close()
        {
            dbConnection.Close();
        }

        public void Dispose()
        {
            if (dbConnection != null)
            {
                try
                {
                    dbConnection.Close();
                }
                catch (Exception)
                {
                }
            }
        }



    }
}
