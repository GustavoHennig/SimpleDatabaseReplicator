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
using SimpleDatabaseReplicator.SQL.Databases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SimpleDatabaseReplicator.Replicator;

namespace SimpleDatabaseReplicator.DB
{
    public class DbTaskRunner
    {
        protected DbCon dbConnection;
        protected BaseDbType dbType;
        protected MessageHandler messageHandler;

        public TaskProgress OnProgress;

        public DbTaskRunner(DbCon dbConnection, MessageHandler messageHandler)
        {
            this.dbConnection = dbConnection;
            this.dbType = dbConnection.DbConnectionInfo.DbType;
            this.messageHandler = messageHandler;
        }
    }
}
