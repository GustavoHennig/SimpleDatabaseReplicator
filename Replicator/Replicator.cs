using SimpleDatabaseReplicator.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using System.Threading;

namespace SimpleDatabaseReplicator
{
    public class Replicator
    {
        public delegate void TaskProgress(double value, double max);
        public delegate void TaskEvent(ReplicationTaskInfo source, string message);

        private readonly MessageHandler _messageHandler;

        public Replicator(MessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        public void Replicate(ReplicationTaskInfo job, CancellationToken cancellationToken)
        {
            try
            {
                job.IsRunning = true;

                var sourceConnectionInfo = new DbConnectionInfo(job.ConnectionStringSource, job.DbProviderSource);
                var destinationConnectionInfo = new DbConnectionInfo(job.ConnectionStringDestination, job.DbProviderDestination);

                int totalTables = job.SourceTables.Count(w => w.Checked);
                int curTable = 1;

                using (var dbSource = DbCon.Create(sourceConnectionInfo))
                using (var dbDest = DbCon.Create(destinationConnectionInfo))
                {
                    foreach (var table in job.SourceTables.Where(w => w.Checked))
                    {
                        curTable = ExecuteTableReplication(job, totalTables, curTable, dbSource, dbDest, table, cancellationToken);
                    }
                }

                _messageHandler.SendStatus("Finished", job);
            }
            catch (Exception e)
            {
                _messageHandler.SendError(e.Message, job);
                _messageHandler.SendStatus("Error " + e.Message, job);
            }
            finally
            {
                job.LastReplicationTime = DateTime.Now;
                job.IsRunning = false;
            }
        }

        private int ExecuteTableReplication(ReplicationTaskInfo job, int totalTables, int curTable, DbCon dbSource, DbCon dbDest, TableInfo table, CancellationToken cancellationToken)
        {
            var syncParams = InitializeSyncParameters(table, dbSource);
            bool workDoneForThisTable = table.SynchronizationMode == TableInfo.SyncMode.AllAtOnce;

            do
            {
                UpdateSyncRanges(table, ref syncParams);

                LogSyncStatus(job, totalTables, curTable, table, syncParams);

                var sw = Stopwatch.StartNew();
                
                // Load tables in parallel
                var tableData = LoadSourceAndDestinationTables(job, table, dbSource, dbDest, syncParams, cancellationToken);
                Table sourceTable = tableData.SourceTable;
                Table destTable = tableData.DestinationTable;

                if (sourceTable.Data.Count == 0)
                {
                    workDoneForThisTable = CheckIfWorkDoneForTable(table, syncParams);
                }

                LogSyncProgress(job, sw);

                // Execute Synchronization
                SynchronizeTables(job, sourceTable, destTable, dbDest, syncParams, cancellationToken);
                if(cancellationToken.IsCancellationRequested){
                    throw new OperationCanceledException("Replication was cancelled.");
                }
            } while (!workDoneForThisTable);

            return curTable + 1;
        }

        public ReplicationPreviewResult Preview(ReplicationTaskInfo job, TableInfo selectedTable, SyncParameters syncParameters, CancellationToken cancellationToken)
        {
            try
            {
                job.IsRunning = true;

                var sourceConnectionInfo = new DbConnectionInfo(job.ConnectionStringSource, job.DbProviderSource);
                var destinationConnectionInfo = new DbConnectionInfo(job.ConnectionStringDestination, job.DbProviderDestination);

                List<TableRow> modifiedRows = new List<TableRow>();
                Table destTable = null;

                using (var dbSource = DbCon.Create(sourceConnectionInfo))
                using (var dbDest = DbCon.Create(destinationConnectionInfo))
                {
                    _messageHandler.SendStatus($"Loading table: {selectedTable.TableName} from source...", job);

                    var syncParams = InitializeSyncParameters(selectedTable, dbSource);

                    if(syncParameters.CurMaxId > 0 && syncParameters.CurMinId > -1 && !string.IsNullOrEmpty(syncParameters.KeyField))
                    {
                        syncParams.CurMinId = syncParameters.CurMinId;
                        syncParams.CurMaxId = syncParameters.CurMaxId;
                        syncParams.KeyField = syncParameters.KeyField;

                    }

                    UpdateSyncRanges(selectedTable, ref syncParams);

                    // Load tables using the same method as replication
                    var tableData = LoadSourceAndDestinationTables(job, selectedTable, dbSource, dbDest, syncParams, cancellationToken);
                    Table sourceTable = tableData.SourceTable;
                    destTable = tableData.DestinationTable;

                    // Compare tables and get differences
                    var tc = new TableComparator();
                    modifiedRows = tc.SearchForObjectDifferences(sourceTable, destTable);

                    _messageHandler.SendStatus($"Preview complete. Found {modifiedRows.Count} differences.", job);
                }

                return new ReplicationPreviewResult { 
                    ModifiedRows = modifiedRows,
                    TableDestination = destTable
                };
            }
            catch (Exception e)
            {
                _messageHandler.SendError(e.Message, job);
                _messageHandler.SendStatus("Error " + e.Message, job);
                return null;
            }
            finally
            {
                job.IsRunning = false;
            }
        }

        #region Helper Methods

        private SyncParameters InitializeSyncParameters(TableInfo table, DbCon dbSource)
        {
            var result = new SyncParameters
            {
                CurMinId = 0,
                CurMaxId = 0,
                Offset = -1,
                MaxId = 0
            };

            if (table.SynchronizationMode == TableInfo.SyncMode.ByIdRange)
            {
                // Disables limit/offset
                result.Offset = -1;
                
                if (!string.IsNullOrWhiteSpace(table.ColumnKeyName))
                    result.MaxId = dbSource.GetMax(table.TableSchema, table.TableName, table.ColumnKeyName);
            }

            return result;
        }

        private void UpdateSyncRanges(TableInfo table, ref SyncParameters syncParams)
        {
            if (table.SynchronizationMode == TableInfo.SyncMode.ByIdRange)
            {
                syncParams.CurMinId = syncParams.CurMaxId;
                syncParams.CurMaxId = syncParams.CurMinId + table.SyncRangeSize;
            }
            else if (table.SynchronizationMode == TableInfo.SyncMode.ByLimitOffset)
            {
                // It will require multiple runs for a full sync
                syncParams.Offset += table.SyncRangeSize;
            }
        }

        private void LogSyncStatus(ReplicationTaskInfo job, int totalTables, int curTable, TableInfo table, SyncParameters syncParams)
        {
            if (syncParams.CurMaxId > 0)
            {
                _messageHandler.SendStatus($"Table {curTable} of {totalTables} - Loading {table.TableName} [{syncParams.CurMinId}-{syncParams.CurMaxId}]", job);
            }
            else
            {
                _messageHandler.SendStatus($"Table {curTable} of {totalTables} - Loading {table.TableName} [{syncParams.Offset}]", job);
            }
        }

        private void LogSyncProgress(ReplicationTaskInfo job, Stopwatch sw)
        {
            _messageHandler.SendStatus($"({sw.ElapsedMilliseconds / 1000}s)", job, true);
            _messageHandler.SendStatus($"Syncing...", job, true);
            sw.Restart();
        }

        private bool CheckIfWorkDoneForTable(TableInfo table, SyncParameters syncParams)
        {
            if (table.SynchronizationMode == TableInfo.SyncMode.ByIdRange)
            {
                return syncParams.CurMaxId > syncParams.MaxId;
            }
            else if (table.SynchronizationMode == TableInfo.SyncMode.ByLimitOffset)
            {
                return true;
            }
            
            return false;
        }

        private TableLoadResult LoadSourceAndDestinationTables(
            ReplicationTaskInfo job, 
            TableInfo table, 
            DbCon dbSource, 
            DbCon dbDest, 
            SyncParameters syncParams,
            CancellationToken cancellationToken)
        {
            // Load Source Table (Async)
            var dbSourceLoader = new DbTableDataLoader(dbSource, _messageHandler);
            Task<Table> taskSourceTable = Task.Run(() =>
            {
                return dbSourceLoader.LoadTableData(
                    table, 
                    null, 
                    syncParams.KeyField ?? table.ColumnKeyName, 
                    table.ColumnOrderByName, 
                    syncParams.CurMinId, 
                    syncParams.CurMaxId, 
                    job.RetrieveDataCondition, 
                    table.SyncRangeSize, 
                    syncParams.Offset,
                    cancellationToken
                );
            }, cancellationToken);

            // Load Destination Table (Sync)
            var dbDestLoader = new DbTableDataLoader(dbDest, _messageHandler);
            Table destTable = dbDestLoader.LoadTableData(
                table, 
                table, 
                syncParams.KeyField ?? table.ColumnKeyName, 
                table.ColumnOrderByName, 
                syncParams.CurMinId, 
                syncParams.CurMaxId, 
                job.RetrieveDataCondition, 
                table.SyncRangeSize, 
                syncParams.Offset,
                cancellationToken
            );

            // Wait for source table to finish loading
            taskSourceTable.Wait(cancellationToken);
            Table sourceTable = taskSourceTable.Result;

            return new TableLoadResult
            {
                SourceTable = sourceTable,
                DestinationTable = destTable
            };
        }

        private void SynchronizeTables(
            ReplicationTaskInfo job, 
            Table sourceTable, 
            Table destTable, 
            DbCon dbDest, 
            SyncParameters syncParams,
            CancellationToken cancellationToken)
        {
            var dbSyncRunner = new DbSyncRunner(dbDest, _messageHandler);
            dbSyncRunner.OnProgress = (v, max) =>
            {
                job.OnProgress(CalcProgress(syncParams.CurMinId, syncParams.CurMaxId, syncParams.MaxId, v, max), 100);
            };

            dbSyncRunner.ExecuteInstructions(sourceTable, destTable, cancellationToken);
            job.OnProgress(CalcProgress(syncParams.CurMinId, syncParams.CurMaxId, syncParams.MaxId, 100, 100), 100);
        }

        private double CalcProgress(double curMinId, double curMaxId, double maxId, double batchValue, double batchCount)
        {
            if (batchCount == 0)
                batchCount = 1;
                
            double batchPercent = (batchValue * 100) / batchCount;

            if (maxId > 0 && curMaxId > 0)
            {
                double partValue = curMinId;
                batchPercent = (partValue * 100) / maxId;
            }

            return batchPercent;
        }

        #endregion
    }

    public class SyncParameters
    {
        public string KeyField { get; set; }
        public long CurMinId { get; set; }
        public long CurMaxId { get; set; }
        public long Offset { get; set; }
        public long MaxId { get; set; }
    }

    public class TableLoadResult
    {
        public Table SourceTable { get; set; }
        public Table DestinationTable { get; set; }
    }

    public class ReplicationPreviewResult
    {
        public List<TableRow> ModifiedRows { get; set; }
        public Table TableDestination { get; set; }
        public string Message { get; set; }
    }
}
