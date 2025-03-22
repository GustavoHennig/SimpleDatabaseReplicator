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
using System.Threading;
using SimpleDatabaseReplicator.DB;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;

namespace SimpleDatabaseReplicator
{
    public class Replicator
    {
        public static bool AbortReplication;

        public delegate void TaskProgress(double value, double max);
        public delegate void TaskEvent(ReplicationTaskInfo source, string message);

        MessageHandler messageHandler;

        public Replicator(MessageHandler messageHandler)
        {

            this.messageHandler = messageHandler;
        }


        public void Replicate(ReplicationTaskInfo job)
        {
            try
            {
                job.IsRunning = true;

                DbConnectionInfo sourceConnectionInfo = new DbConnectionInfo(job.ConnectionStringSource, job.DbProviderSource);
                DbConnectionInfo destinationConnectionInfo = new DbConnectionInfo(job.ConnectionStringDestination, job.DbProviderDestination);

                int totalTables = job.SourceTables.Count(w => w.Checked);
                int curTable = 1;

                using (DbCon dbSource = DbCon.Create(sourceConnectionInfo))
                using (DbCon dbDest = DbCon.Create(destinationConnectionInfo))
                {
                    foreach (TableInfo table in job.SourceTables.Where(w => w.Checked))
                    {
                        curTable = this.ExecuteTableReplication(job, totalTables, curTable, dbSource, dbDest, table);
                    }
                }

                messageHandler.SendStatus("Finished", job);
            }
            catch (Exception e)
            {
                messageHandler.SendError(e.Message, job);
                messageHandler.SendStatus("Error " + e.Message, job);

            }
            finally
            {
                job.LastReplicationTime = DateTime.Now;
                job.IsRunning = false;
            }
        }

        private int ExecuteTableReplication(ReplicationTaskInfo job, int totalTables, int curTable, DbCon dbSource, DbCon dbDest, TableInfo table)
        {
            bool workDoneForThisTable = table.SynchronizationMode == TableInfo.SyncMode.AllAtOnce;

            long curMinId = 0;
            long curMaxId = 0;
            long offset = 0;
            long maxId = 0;

            // TODO: Enable a way to import without local comparison


            if (table.SynchronizationMode == TableInfo.SyncMode.ByIdRange)
            {
                // disables limit/offset
                offset = -1;
                if (!string.IsNullOrWhiteSpace(table.ColumnKeyName))
                    maxId = dbSource.GetMax(table.TableSchema, table.TableName, table.ColumnKeyName);
            }


            do
            {
                if (table.SynchronizationMode == TableInfo.SyncMode.ByIdRange)
                {
                    curMinId = curMaxId;
                    curMaxId = curMinId + table.SyncRangeSize;
                }
                else if (table.SynchronizationMode == TableInfo.SyncMode.ByLimitOffset)
                {
                    // It will require multiple runs for a full sync
                    offset += table.SyncRangeSize;
                }

                if (curMaxId > 0)
                {
                    messageHandler.SendStatus($"Table {curTable} of {totalTables} - Loading {table.TableName} [{curMinId}-{curMaxId}]", job);
                }
                else
                {
                    messageHandler.SendStatus($"Table {curTable} of {totalTables} - Loading {table.TableName} [{offset}]", job);
                }

                Stopwatch sw = Stopwatch.StartNew();
                //Load Source Table (Async)
                DbTableDataLoader dblo1 = new DbTableDataLoader(dbSource, messageHandler);

                Task<Table> taskTb1 = Task.Run(() =>
                {
                    return dblo1.LoadTableData(table, null, table.ColumnKeyName, table.ColumnOrderByName, curMinId, curMaxId, job.RetrieveDataCondition, table.SyncRangeSize, offset);
                });

                //Load Destination Table (Sync)
                DbTableDataLoader dblo2 = new DbTableDataLoader(dbDest, messageHandler);

                Table tb2 = dblo2.LoadTableData(table, table, table.ColumnKeyName, table.ColumnOrderByName, curMinId, curMaxId, job.RetrieveDataCondition, table.SyncRangeSize, offset);

                //Wait finish loading Source Table
                taskTb1.Wait();
                Table tb1 = taskTb1.Result;


                if (tb1.Data.Count == 0)
                {
                    if (table.SynchronizationMode == TableInfo.SyncMode.ByIdRange)
                    {
                        workDoneForThisTable = curMaxId > maxId;
                    }
                    else if (table.SynchronizationMode == TableInfo.SyncMode.ByLimitOffset)
                    {
                        workDoneForThisTable = true;
                    }
                }

                messageHandler.SendStatus($"({sw.ElapsedMilliseconds / 1000}s)", job, true);
                messageHandler.SendStatus($"Table {curTable} of {totalTables} - Syncing {table.TableName}", job, true);
                sw.Restart();

                //Execute Synchronization
                DbSyncRunner dbSyncRunner = new DbSyncRunner(dbDest, messageHandler);
                dbSyncRunner.OnProgress = delegate (double v, double max)
                {
                    job.OnProgress(CalcProgress(curMinId, curMaxId, maxId, v, max), 100);
                };

                dbSyncRunner.ExecuteInstructions(tb1, tb2);


                job.OnProgress(CalcProgress(curMinId, curMaxId, maxId, 100, 100), 100);

                if (Replicator.AbortReplication)
                    throw new ApplicationException("Aborted");

            } while (!workDoneForThisTable);

            curTable++;
            return curTable;
        }

        private double CalcProgress(double curMinId, double curMaxId, double maxId, double batchValue, double batchCount)
        {

            /*
             batchCount 100
             batchValue  X
             */
            if (batchCount == 0)
                batchCount = 1;
            double batchPercent = (batchValue * 100) / batchCount;



            if (maxId > 0 && curMaxId > 0)
            {
                /*
                 curMaxId = 100
                 curMinId = 0
                */
                double partValue = curMinId;

                batchPercent = (partValue * 100) / maxId;
            }
            else
            {
                return batchPercent;
            }



            return batchPercent;

        }

        public ReplicationPreviewResult Preview(ReplicationTaskInfo job, TableInfo selectedTable)
        {
            try
            {
                job.IsRunning = true;

                DbConnectionInfo sourceConnectionInfo = new DbConnectionInfo(job.ConnectionStringSource, job.DbProviderSource);
                DbConnectionInfo destinationConnectionInfo = new DbConnectionInfo(job.ConnectionStringDestination, job.DbProviderDestination);

                List<TableRow> modifiedRows = new List<TableRow>();
                Table destTable;
                using (DbCon dbSource = DbCon.Create(sourceConnectionInfo))
                using (DbCon dbDest = DbCon.Create(destinationConnectionInfo))
                {
                    // Load the selected table
                    messageHandler.SendStatus($"Loading table: {selectedTable.TableName} from source...", job);

                    long curMinId = 0;
                    long curMaxId = 0;
                    long offset = -1;
                    long maxId = 0;

                    if (selectedTable.SynchronizationMode == TableInfo.SyncMode.ByIdRange)
                    {
                        // disables limit/offset
                        offset = -1;
                        if (!string.IsNullOrWhiteSpace(selectedTable.ColumnKeyName))
                            maxId = dbSource.GetMax(selectedTable.TableSchema, selectedTable.TableName, selectedTable.ColumnKeyName);
                    }

                    if (selectedTable.SynchronizationMode == TableInfo.SyncMode.ByIdRange)
                    {
                        curMaxId = curMinId + selectedTable.SyncRangeSize;
                    }
                    else if (selectedTable.SynchronizationMode == TableInfo.SyncMode.ByLimitOffset)
                    {
                        // Preview with offset
                        offset += selectedTable.SyncRangeSize;
                    }

                    // Load Source Table
                    DbTableDataLoader dbSourceLoader = new DbTableDataLoader(dbSource, messageHandler);
                    Table sourceTable = dbSourceLoader.LoadTableData(
                        selectedTable,
                        null,
                        selectedTable.ColumnKeyName,
                        selectedTable.ColumnOrderByName,
                        curMinId,
                        curMaxId,
                        job.RetrieveDataCondition,
                        selectedTable.SyncRangeSize,
                        offset
                    );

                    // Load Destination Table
                    DbTableDataLoader dbDestLoader = new DbTableDataLoader(dbDest, messageHandler);
                    destTable = dbDestLoader.LoadTableData(
                        selectedTable,
                        selectedTable,
                        selectedTable.ColumnKeyName,
                        selectedTable.ColumnOrderByName,
                        curMinId,
                        curMaxId,
                        job.RetrieveDataCondition,
                        selectedTable.SyncRangeSize,
                        offset
                    );

                    // Compare tables and get differences
                    TableComparator tc = new TableComparator();
                    modifiedRows = tc.SearchForObjectDifferences(sourceTable, destTable);

                    messageHandler.SendStatus($"Preview complete. Found {modifiedRows.Count} differences.", job);
                }

                return new ReplicationPreviewResult { ModifiedRows = modifiedRows,
                TableDestination = destTable};
            }
            catch (Exception e)
            {
                messageHandler.SendError(e.Message, job);
                messageHandler.SendStatus("Error " + e.Message, job);
                return null;
            }
            finally
            {
                job.IsRunning = false;
            }
        }

    }

    public class ReplicationPreviewResult
    {
        public List<TableRow> ModifiedRows { get; set; }
        public Table TableDestination { get; set; }
        public string Message { get; set; }
    }
}
