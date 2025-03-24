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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlKata;
using SqlKata.Execution;
using System.Diagnostics;

namespace SimpleDatabaseReplicator.DB
{
    public class DbSyncRunner : DbTaskRunner
    {

        public DbSyncRunner(DbCon dbConnection, MessageHandler messageHandler) : base(dbConnection, messageHandler)
        {
        }

        public void ExecuteInstructions(Table source, Table dest)
        {
            TableComparator tc = new TableComparator();

            /*
            if(Preferences.JobAtual.DDLEnabled){
                VerifyTable(dest.TableName, source);
            } 
            */

            List<TableRow> modifiedRows = tc.SearchForObjectDifferences(source, dest);
            ExecuteSyncIntoTable(modifiedRows, dest);

            if (source.TableInfo.EnableIdentitySync)
            {
                SyncIndetidy(source.TableInfo, dest.TableInfo);
            }
        }

        private void SyncIndetidy(TableInfo source, TableInfo dest)
        {
            if (source.IdentityValue > 0 && dest.IdentityName != null)
            {

                long identity = Convert.ToInt64(dbConnection.ExecuteScalar(dbType.SetIdentityCommand(dest.IdentityName, source.IdentityValue)));

            }
        }

        public void ExecuteSyncIntoTable(List<TableRow> l, Table dest, string postUpdateSQL = null)
        {

            try
            {
                int intAffected = 0;
                int nroRegs = 0;
                int max = l.Count(t => t.DifferentFromDestination);
                int cntErrors = 0;
                int cntSkipped = 0;

                if (max == 0)
                {
                    messageHandler.SendStatus($"Syncing {dest.TableInfo.TableName}: nothing different", null, true);
                    return;
                }

                var db = new QueryFactory(dbConnection.DB, dbType.KataCompiler);

                Stopwatch sw = Stopwatch.StartNew();
                foreach (TableRow ri in l)
                {
                    if (!ri.DifferentFromDestination)
                        continue;
                    try
                    {
                        if (ri.NotExistsInDestination)
                        {

                            //TODO: read config before this check
                            //TODO: should no enter for AllAtOnce
                            bool exists = false;
                            if (dest.TableInfo.SynchronizationMode == TableInfo.SyncMode.ByLimitOffset)
                            {
                                throw new ApplicationException("AllAtOnce not implemented");

                                var query = db.Query(dest.TableInfo.FormattedTableName);

                                foreach (var key in dest.TableInfo.Keys)
                                {
                                    query = query.Where(key, ri.Data[key].Value);
                                }
                                exists = db.Exists(query);
                            }

                            if (!exists)
                            {
                                // todo: improve this, very slow
                                intAffected += db
                                    .Query(dest.TableInfo.FormattedTableName)
                                    .Insert( values: ri.GetValues());
                            }
                            else
                            {
                                cntSkipped++;
                            }
                        }
                        else
                        {
                            var query = db.Query(dest.TableInfo.TableName);

                            foreach (var key in dest.TableInfo.Keys)
                            {
                                query = query.Where(key, ri.Data[key].Value);
                            }

                            intAffected += query.Update(ri.GetValues());

                            // For debug:
                            //dbType.KataCompiler.Compile(db.Query(dest.TableInfo.TableName).Where(dest.TableInfo.ColumnKeyName, ri.Key).AsUpdate(ri.Data)).Sql.ToString();
                        }
                        ///db.Query(dest.TableInfo.TableName).Where(dest.TableInfo.ColumnKeyName, ri.Key).AsUpdate(ri.Data).ToString(); 

                        if (!string.IsNullOrEmpty(postUpdateSQL))
                        {
                            // TODO: It's needed to run on source
                            //  bd.ExecuteSQL(rib.getPostUpdate(JobCallBack.PostUpdateSQL));
                        }
                    }
                    catch (Exception error)
                    {
                        cntErrors++;
                        messageHandler.SendError(error.Message, null);
                    }

                    nroRegs++;

                    if (sw.ElapsedMilliseconds > 500)
                    {

                        messageHandler.SendStatus($"Syncing {dest.TableInfo.TableName}: {nroRegs}/{max}  (Affected: {intAffected} | Skipped: {cntSkipped} | Errors: {cntErrors}){sw.ElapsedMilliseconds}ms", null, true);
                        OnProgress(nroRegs, max);
                        sw.Restart();
                    }
                    if (Replicator.AbortReplication)
                        throw new ApplicationException("Aborted");
                }


            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception e)
            {
                messageHandler.SendError(e.Message, null);
            }
        }

    }
}
