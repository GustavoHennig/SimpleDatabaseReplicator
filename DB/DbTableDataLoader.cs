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
using SqlKata;
using SqlKata.Execution;
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
    class DbTableDataLoader : DbTaskRunner
    {

        public DbTableDataLoader(DbCon dbConnection, MessageHandler messageHandler) : base(dbConnection, messageHandler)
        {
        }

        public Table LoadTableData(TableInfo table,
                                   TableInfo sourceTableForDDLComparison,
                                   string columnKeyName,
                                   string columnOrderByName,
                                   long minValue,
                                   long maxValue,
                                   string retrieveDataCondition,
                                   int limit,
                                   long offset)
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


                var db = new QueryFactory(dbConnection.DB, dbType.KataCompiler);
                Query query = db.Query($"{table.TableSchema}.{table.TableName}");


                //SqlQueryBuilder query = new SqlQueryBuilder(dbType).Select().From(table.TableName);
                string whereForCount = "";

                if (!string.IsNullOrWhiteSpace(retrieveDataCondition))
                {
                    query = query.Where(retrieveDataCondition);
                    whereForCount = retrieveDataCondition;
                }
                if (!string.IsNullOrWhiteSpace(columnKeyName) && minValue > -1 && maxValue > 0 && !columnKeyName.Contains(','))
                {
                    query = query.WhereBetween(columnKeyName, minValue, maxValue);
                }
                if (limit > 0 && offset > -1)
                {
                    query = query.Limit(limit).Offset(offset);
                }

                if (!string.IsNullOrWhiteSpace(columnOrderByName))
                {
                    query = query.OrderBy(columnOrderByName);
                }

                int progressMax = (int)dbConnection.CountRegs(table.TableSchema, table.TableName, whereForCount);

                string sql1 = dbType.KataCompiler.Compile(query).ToString();


                using (IDataReader dr = dbConnection.ExecuteDataReader(sql1))
                {

                    object[] col = new object[dr.FieldCount];

                    //ArrayList l = new ArrayList();

                    TableRow row;
                    long t = DateTime.Now.Ticks;

                    while (dr.Read())
                    {
                        row = new TableRow();

                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            object dbValue = dr.GetValue(i);
                            if (dbValue == DBNull.Value)
                            {
                                dbValue = null;
                            }
                            row.Data.Add(dr.GetName(i), dbValue);
                        }

                        row.BuildCompositeKey(table.Keys, table.ColumnKeyName);
                        tb.Data.Add(row.KeyValue, row);

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

    }
}