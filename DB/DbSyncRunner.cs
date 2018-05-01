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
                int prg = 0;
                int max = l.Count;

                SqlQueryGenerator rib = new SqlQueryGenerator(dest.TableInfo, dbType);

                foreach (TableRow ri in l)
                {
                    if (ri.DiferentFromDestinaion)
                    {
                        string sql = rib.CreateExcecutionQuery(ri.Data, ri.NotExistsInDestination);

                        try
                        {
                            intAffected += dbConnection.ExecuteSQL(sql);
                            if (!string.IsNullOrEmpty(postUpdateSQL))
                            {
                                // TODO: It's needed to run on source
                                //  bd.ExecuteSQL(rib.getPostUpdate(JobCallBack.PostUpdateSQL));
                            }
                        }
                        catch (Exception erro)
                        {
                            messageHandler.SendError(erro.Message + " SQL: " + sql);
                        }

                        nroRegs++;

                        prg++;
                        if (prg > 300)
                        {
                            messageHandler.SendStatus(string.Format("Syncing {0}: {1}/{2}  (OK: {3} | Errors: {4})", dest.TableInfo.TableName, nroRegs, max, intAffected, (nroRegs - intAffected)));
                            OnProgress(nroRegs, max);
                            prg = 0;

                        }
                        if (Replicator.AbortReplication)
                            throw new ApplicationException("Aborted");
                    }

                }
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception e)
            {
                messageHandler.SendError(e.Message);
            }
        }

    }
}
