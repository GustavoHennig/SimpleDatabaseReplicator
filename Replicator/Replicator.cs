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

                DbConnectionInfo s = new DbConnectionInfo(job.ConnectionStringSource, job.DialectSource);
                DbConnectionInfo d = new DbConnectionInfo(job.ConnectionStringDestination, job.DialectDestination);

                /*
                d.status += new DlgStatusMsg(r_status);
                d.statuspgb += new DlgStatusPgb(r_statuspgb);
                d.everros += new DlgStatusMsg(r_erros);
                */

                string status = "Table {0} of {1} - {2}";

                int totalTables = job.TablesAvailable.Count(w => w.Checked);
                int curTable = 1;

                using (DbCon dbSource = s.CreateConnection())
                using (DbCon dbDest = d.CreateConnection())
                {
                    foreach (TableInfo table in job.TablesAvailable.Where(w => w.Checked))
                    {
                        bool workDoneForThisTable = table.CompareEntireTableAtOnce;

                        long curMinId = 0;
                        long curMaxId = 0;
                        string columnKeyName = null;
                        long maxId = 0;

                        if (!table.CompareEntireTableAtOnce)
                        {
                            columnKeyName = table.ColumnKeyName;
                            if (!string.IsNullOrWhiteSpace(columnKeyName))
                                maxId = dbSource.GetMax(table.TableName, columnKeyName);
                        }


                        do
                        {
                            curMinId = curMaxId;
                            curMaxId = curMinId + table.IdRangeSize;

                            messageHandler.SendStatus(string.Format(status, curTable, totalTables, "Loading " + table + " [" + curMinId + "-" + curMaxId + "]"));

                            //Load Source Table (Async)
                            DbTableLoader dblo1 = new DbTableLoader(dbSource, messageHandler);

                            Task<Table> taskTb1 = Task.Run(() =>
                            {
                                return dblo1.LoadTableData(table, null, columnKeyName, curMinId, curMaxId, job.RetrieveDataCondition);
                            });

                            //Load Destination Table (Sync)
                            DbTableLoader dblo2 = new DbTableLoader(dbDest, messageHandler);

                            Table tb2 = dblo2.LoadTableData(table, table, columnKeyName, curMinId, curMaxId, job.RetrieveDataCondition);

                            //Wait finish loading Source Table
                            taskTb1.Wait();
                            Table tb1 = taskTb1.Result;


                            if (tb1.Data.Count == 0)
                            {
                                workDoneForThisTable = curMaxId > maxId;
                            }

                            messageHandler.SendStatus(string.Format(status, curTable, totalTables, "Syncing " + table));

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
                    }
                }

                messageHandler.SendStatus("Finished");
            }
            catch (Exception e)
            {
                messageHandler.SendError(e.Message);
                messageHandler.SendStatus("Error " + e.Message);

            }
            finally
            {
                job.LastTimeReplicated = DateTime.Now.Ticks;
                job.IsRunning = false;
            }
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


        /*
        public void Repica(params string[] Tables ) {
            try
            {
                SincrDBS s = new SincrDBS();
                SincrDBS d = new SincrDBS();

                s.ConnectionString = SourceConnectionString;
                s.dialect =
                d.ConnectionString = DestinationConnectionString;
                d.status += new DlgStatusMsg(d_status);
                d.statuspgb += new DlgStatusPgb(d_statuspgb);
                d.everros += new DlgStatusMsg(d_everros);
                TableComparator tc = new TableComparator();

                foreach (string table in Tables)
                {
                    if (table != null)
                    {
                        status.Invoke("Carregando tabela: " + table + " da origem...");
                        Table tb1 = s.getTableData(table);
                        status.Invoke("Carregando tabela: " + table + " do destino...");
                        Table tb2 = d.getTableData(table);

                        status.Invoke("Analisando dados...");
                        List<RegItem> l = tc.getDiferentObjects(tb1, tb2);

                        status.Invoke("Executando instruções no banco destino...");
                        d.ExecuteInstructions(l, tb2);
                    }
                }
            }
            catch (Exception e) {
                erros.Invoke(e.Message);
            }
        }
        */
        /*
        void d_everros(string msg)
        {
            erros.Invoke(msg);
        }

        void d_statuspgb(int pos, int max)
        {
            statuspgb.Invoke(pos, max);
        }

        void d_status(string msg)
        {
            status.Invoke(msg);
        }
        */
    }
}
