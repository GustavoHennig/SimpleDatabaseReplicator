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
using SimpleDatabaseReplicator.SQL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleDatabaseReplicator.DB
{
    class DbTableLoader : DbTaskRunner
    {

        public DbTableLoader(DbCon dbConnection, MessageHandler messageHandler) : base(dbConnection, messageHandler)
        {
        }

        public Table LoadTableData(TableInfo table, TableInfo sourceTableForDDLComparison = null, string columnKeyName = "", long minValue = -1, long maxValue = -1, string retrieveDataCondition = null)
        {

            //SqlConnection con = new SqlConnection(ConnectionString);


            //SqlCommand com;

            Table tb = new Table(table);

            try
            {
                if (sourceTableForDDLComparison != null)
                {
                    //TODO:
                    //if (!db.TableExists(table.TableName))
                    //{
                    //    db.Ddl.CreateTable(sourceTableForDDLComparison);
                    //}
                }



                SqlQueryBuilder query = new SqlQueryBuilder(dbType).Select().From(table.TableName);
                string whereForCount = "";

                if (!string.IsNullOrWhiteSpace(retrieveDataCondition))
                {
                    query = query.Where(retrieveDataCondition);
                    whereForCount = retrieveDataCondition;
                }
                else if (!string.IsNullOrWhiteSpace(columnKeyName))
                {
                    query = query.WhereRowKeyBetween(columnKeyName, minValue, maxValue);
                }

                int progressMax = (int)dbConnection.CountRegs(table.TableName, whereForCount, dbType);

                using (IDataReader dr = dbConnection.ExecuteDataReader(query.ToString()))
                {

                    object[] col = new object[dr.FieldCount];

                    ArrayList l = new ArrayList();

                    TableRow rg;
                    long t;
                    t = DateTime.Now.Ticks;

                    while (dr.Read())
                    {
                        rg = new TableRow();

                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            rg.Data.Add(dr.GetName(i).ToUpper(), dr.GetValue(i));
                        }

                        rg.MontaKey(table.Keys);
                        tb.Data.Add(rg.Key, rg);

                        if (Replicator.AbortReplication)
                            throw new ApplicationException("Aborted");
                    }


                    if (table.EnableIdentitySync)
                    {
                        foreach (TableColumn rf2 in table.Columns)
                        {
                            if (rf2.IsAutoIncrement)
                            {


                                table.IdentityName = Convert.ToString(dbConnection.ExecuteScalar(dbType.GetSequenceName(table.TableName, rf2.Name)));
                                table.IdentityValue = Convert.ToInt64(dbConnection.ExecuteScalar(dbType.GetIdentityCommand(table.IdentityName)));

                                break;
                            }
                        }
                    }
                }
            }

            catch (Exception e)
            {
                messageHandler.SendError(e.Message);
                Debug.WriteLine(e.Message);
            }
            return tb;
        }

        public void LoadTableSchemaBatch(List<TableInfo> tables)
        {

            foreach (var table in tables.Where(w => !w.HasSchema))
            {
                LoadTableSchema(table, dbConnection);
            }
        }

        public void LoadTableSchema(TableInfo table)
        {
            LoadTableSchema(table, dbConnection);
        }


        private void LoadTableSchema(TableInfo table, DbCon db)
        {
            using (IDataReader dr = db.ExecuteDataReader("select * from " + dbType.FormatDbObj(table.TableName) + " WHERE 1 = 0"))
            {

                //Monta o Header
                DataTable dt = dr.GetSchemaTable(); // db

                TableColumn rf;

                foreach (DataRow drr in dt.Rows)
                {
                    rf = table.Columns.FirstOrDefault(o => o.Name == drr["ColumnName"].ToString());

                    if (rf == null)
                    {
                        rf = new TableColumn();
                        table.Columns.Add(rf);
                    }
                    rf.Checked = true;
                    //rf.Value = dr.GetValue(Convert.ToInt32(drr["ColumnOrdinal"]));
                    rf.Name = drr["ColumnName"].ToString();
                    rf.IsKey = Convert.ToBoolean((drr["IsKey"] is DBNull ? false : drr["IsKey"]));

                    rf.DefinedSize = Convert.ToInt32(drr["ColumnSize"]);
                    rf.AllowNull = Convert.ToBoolean(drr["AllowDBNull"]);
                    rf.TypeName = ((Type)drr["DataType"]).Name;
                    if (!(drr["NumericPrecision"] is DBNull))
                    {
                        rf.Precision = Convert.ToInt32(drr["NumericPrecision"]);
                    }
                    if (!(drr["NumericScale"] is DBNull))
                    {
                        rf.Decimals = Convert.ToInt32(drr["NumericScale"]);
                    }

                    rf.IsAutoIncrement = Convert.ToBoolean(drr["IsAutoIncrement"]);

                    if (rf.IsKey)
                    {
                        if (!table.Keys.Exists(o=> o.Equals(rf.Name, StringComparison.CurrentCultureIgnoreCase)))
                            table.Keys.Add(rf.Name);
                    }
                }

                if (table.Keys.Count == 1)
                {
                    table.ColumnKeyName = table.Keys[0];
                }
            }
        }
    }
}