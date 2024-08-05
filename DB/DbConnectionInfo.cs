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
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System;
using SimpleDatabaseReplicator.SQL;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Threading;
using SimpleDatabaseReplicator.SQL.Databases;
using static SimpleDatabaseReplicator.SQL.Databases.BaseDbType;

namespace SimpleDatabaseReplicator.DB
{
    public class DbConnectionInfo
    {

        public string ConnectionString { get; set; } = "";
        public BaseDbType DbType { get; set; }

        public DbConnectionInfo(string connStr, DbTypeEnum type)
        {
            this.ConnectionString = connStr;
            this.DbType = BaseDbType.CreateInstance(type);
        }


        public void CheckTableSchema(TableInfo tableInfo)
        {
            //TODO:
        }


    }

}
