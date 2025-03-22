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

namespace SimpleDatabaseReplicator.SQL.Databases
{
    public class PostgresDbType : BaseDbType
    {
        public PostgresDbType()
        {
            this.KataCompiler = new SqlKata.Compilers.PostgresCompiler();
        }


        public override string GetIdentityCommand(string name)
        {

            string sql = " select last_value from  " + name;

            return sql;
        }

        public override string SetIdentityCommand(string name, object value)
        {

            string sql = " select setval('" + name + "', " + value + ") ";

            return sql;

        }

        public override string GetSequenceName(string table, string field)
        {

            string sql = " select * from pg_get_serial_sequence('" + table + "','" + field + "');";
            return sql;

        }

        public override string AllTablesCommand
        {
            get
            {
                string sql = @"
               select schemaname as schema_name, tablename as table_name 
               from pg_catalog.pg_tables  
               where schemaname not in ('information_schema','pg_catalog') 
               order by schemaname, tablename
";

                return sql;
            }
        }

          public override System.Data.Common.DbConnection BuildConnection(string connectionString)
        {
            System.Data.Common.DbConnection con = new Npgsql.NpgsqlConnection(connectionString);
         
            return con;
        }

        public override string LimitOffset(int limit, int offset)
        {
            return $" limit {limit} offset {offset}";
        }
    }
}
