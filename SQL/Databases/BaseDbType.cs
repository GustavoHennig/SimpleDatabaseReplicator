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
using SimpleDatabaseReplicator.Properties;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SimpleDatabaseReplicator.SQL.Databases
{
    public abstract class BaseDbType
    {
        public abstract string LimitOffset(int limit, int offset);

        public abstract string FormatNumberValue(object value);
        public abstract string FormatStringValue(object value);
        public abstract string FormatDateValue(object value);
        public abstract string NullString { get; }
        public abstract string GetDBFieldType(TableColumn f);
        public abstract string GetIdentityCommand(string name);
        public abstract string SetIdentityCommand(string name, object value);
        public abstract string GetSequenceName(string table, string field);
        public abstract string AllTablesCommand { get; }
        public DbTypeSupported DbType;

        public abstract string NullableField
        {
            get;
        }
        public abstract string NotNullableField
        {
            get;
        }

        public virtual string FieldChar { get { return "\""; } }

        internal string GetFormattedValueForDb(TableColumn rf, object Value)
        {
            string ret = "";
            if (Value is System.DBNull)
            {
                ret = " " + NullString + " ";
            }
            else
            {
                switch (rf.TypeName)
                {
                    case "DateTime":

                        if (((DateTime)Value) < Preferences.Settings.MinDateTime)
                            Value = Preferences.Settings.MinDateTime;

                        ret = FormatDateValue(Value);
                        break;
                    case "Int32":
                    case "Int16":
                    case "Byte":
                        ret = Value.ToString();
                        break;
                    case "String":
                        //TODO: Remove backslashes
                        ret = FormatStringValue(Value);
                        break;
                    case "Decimal":
                    case "Float":
                    case "Single":
                    case "Double":
                        ret = FormatNumberValue(Value);
                        break;
                    default:
                        ret = Value.ToString();
                        break;
                }
            }
            return ret;
        }

        public abstract DbConnection BuildCoonnection(string connectionString);


        public string FormatDbObj(string dbObjName)
        {
            return FieldChar + dbObjName + FieldChar;
        }

        public static BaseDbType CreateInstance(DbTypeSupported type)
        {
            switch (type)
            {
                case DbTypeSupported.SqlServer:
                    return new SqlServerDbType();
                case DbTypeSupported.Access:
                    return new AccessDbType();
                case DbTypeSupported.Firebird:
                    return new FirebirdDbType();
                case DbTypeSupported.Postgres:
                    return new PostgresDbType();
                case DbTypeSupported.MySql:
                    return new MysqlDbType();
                case DbTypeSupported.SqlLite:
                    return new SqLiteDbType();
                case DbTypeSupported.Oracle:
                    return new OracleDbType();
                default:
                    throw new Exception(Resources.DbNotSup);
            }

        }

        public enum DbTypeSupported
        {
            SqlServer = 0,
            Access = 1,
            Firebird = 2,
            SqlLite = 3,
            Postgres = 4,
            Oracle = 5,
            MySql = 6,
            Odbc = 7

        }
    }
}
