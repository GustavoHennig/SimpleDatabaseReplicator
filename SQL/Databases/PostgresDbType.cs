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
        

        public override string FormatNumberValue(object value)
        {
            return value.ToString().Replace(',', '.');
        }

        public override string FormatStringValue(object value)
        {
            return "'" + ((string)value).Replace("'", "''") + "'";
        }

        public override string FormatDateValue(object value)
        {
            return "'" + ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss") + "'";
        }

        public override string   NullString
        {
            get
            {
                return "null";
            }
        }

        public override  string GetDBFieldType(TableColumn f)
        {
            string ret = "";
            switch (f.TypeName)
            {
                case "Int16":
                    ret = "int2";
                    break;
                case "DateTime":
                    ret = "date";
                    break;
                case "Byte":
                    ret = "tinyint";
                    break;
                case "Int32":
                    ret = "int4";
                    break;
                case "Int64":
                    ret = "int8";
                    break;
                case "String":
                    //UPGRADE_WARNING: Couldn't resolve default property of object RS.Fields. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (f.DefinedSize > 255)
                    {
                        ret = "text";
                    }
                    else
                    {
                        ret = "Varchar(" + f.DefinedSize + ")";
                    }

                    break;
                case "Double":
                case "Float":
                case "Decimal":
                    ret = "money";
                    break;
                case "Char[]":
                    ret = "char(" + f.DefinedSize + ")";
                    break;
                default:
                    //TODO: Exception
                    break;
            }
            return ret;
        }


        public override  string NotNullableField
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }


        public  override string GetIdentityCommand(string name)
        {

            string sql = " select last_value from  " + name;

            return sql;
        }

        public override  string SetIdentityCommand(string name, object value)
        {

            string sql = " select setval('"+name+"', "+value+") ";

            return sql;

        }

        public  override string GetSequenceName(string table, string field)
        {

            string sql = " select * from pg_get_serial_sequence('" + table + "','" + field + "');";
            return sql;

        }


        public override  string AllTablesCommand
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

        public override string NullableField
        {
            get { return " null "; }
        }

        public override System.Data.Common.DbConnection BuildConnection(string connectionString)
        {
            System.Data.Common.DbConnection con = new Npgsql.NpgsqlConnection(connectionString);
            // new Npgsql.NpgsqlConnection().
            //con = (DbConnection)pgcon;
            //                    con = 

            //DbTransaction trans = con.BeginTransaction();
            //trans.Commit();
            //trans.Rollback();
            return con;
        }

        public override string LimitOffset(int limit, int offset)
        {
            return $" limite {limit} offset {offset}";
        }
    }
}
