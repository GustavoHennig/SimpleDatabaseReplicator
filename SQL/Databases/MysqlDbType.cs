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
    public class MysqlDbType : BaseDbType
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

        public override string NullString
        {
            get
            {
                return "null";
            }
        }



        public override string GetDBFieldType(TableColumn f)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        public override string NullableField
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public override string NotNullableField
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public override string GetIdentityCommand(string name)
        {
            throw new NotImplementedException();
        }

        public override string SetIdentityCommand(string name, object value)
        {
            throw new NotImplementedException();
        }


        public override string GetSequenceName(string table, string field)
        {
            string sql = "SELECT `AUTO_INCREMENT` ";
            sql += " FROM  INFORMATION_SCHEMA.TABLES ";
            sql += " WHERE TABLE_NAME   = '" + table + "' ";
            //sql += " AND   TABLE_SCHEMA = 'plagius_1' ";
            //throw new NotImplementedException();

            return sql;
        }



        public override string AllTablesCommand
        {
            get { return "SHOW TABLES"; }
        }

        public override System.Data.Common.DbConnection BuildCoonnection(string connectionString)
        {
            return new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        }

        public override string FieldChar
        {
            get
            {
                return "`";
            }
        }
    }
}
