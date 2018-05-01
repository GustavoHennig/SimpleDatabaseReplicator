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
using System.Linq;
using System.Text;

namespace SimpleDatabaseReplicator.SQL
{
    class SqlQueryBuilder
    {
        private StringBuilder query = new StringBuilder();
        private BaseDbType dialect;

        public SqlQueryBuilder(BaseDbType dialect)
        {
            this.dialect = dialect;
        }

        //public void Insert() {
        //    string strSQL = "";
        //    if (dialect is DialectSQLServer)
        //    {
        //        strSQL += "SET IDENTITY_INSERT " + dialect.FieldChar + table.TableName + dialect.FieldChar + " ON;";
        //    }


        //    strSQL += " insert into " + Dialect.FieldChar + TableName + Dialect.FieldChar + " ( ";
        //    string sqlValues = "";

        //    foreach (RegField reg in Header.Values)
        //    {

        //        if (Data.ContainsKey(reg.Name.ToUpper()))
        //        {
        //            strSQL += Dialect.FieldChar + reg.Name + Dialect.FieldChar + ", ";
        //            sqlValues += Dialect.getString(reg, Data[reg.Name.ToUpper()]) + ", ";
        //        }
        //    }

        //    strSQL = Functions.RemoveLastChars(strSQL, 2);
        //    strSQL += " ) values ( " + Functions.RemoveLastChars(sqlValues, 2);
        //    strSQL += " ) ";

        //    return strSQL;
        //}

        public SqlQueryBuilder Select(string fields = "*")
        {
            query.Append("select " + fields + " ");
            return this;
        }
        public SqlQueryBuilder From(string table)
        {
            query.Append(" from " + dialect.FormatDbObj( table )+ " ");
            return this;
        }

        public SqlQueryBuilder Where(string condition)
        {
            query.Append(" where " + condition);
            return this;
        }

        public SqlQueryBuilder WhereRowKeyBetween(string columnKey, long minValue, long maxValue)
        {
            query.Append(" where " + dialect.FormatDbObj(columnKey) + " >= " + minValue + " and " + dialect.FormatDbObj(columnKey) + " <= " + maxValue);
            return this;
        }

        public override string ToString()
        {
            return query.ToString();
        }
    }
}
