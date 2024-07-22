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
using System.Text;

namespace SimpleDatabaseReplicator.SQL
{
    class SqlQueryGenerator
    {
        //public Dictionary<string, TableColumn> Header = new Dictionary<string, TableColumn>();
        // public Dictionary<string, object> Data = new Dictionary<string, object>();
        //public string table.TableName;
        private TableInfo table;
        private BaseDbType dialect;

        public SqlQueryGenerator(TableInfo table, BaseDbType dialect)
        {
            //  this.table.TableName = table.TableName;
            //this.Header = Header;
            this.table = table;
            this.dialect = dialect;
        }

        public string BuildUpdateString(Dictionary<string, object> Data)
        {
            string strSQL = " update " + dialect.FieldChar + table.TableName + dialect.FieldChar + " set ";

            foreach (TableColumn reg in table.Columns)
            {
                if (!reg.IsKey)
                {
                    if (Data.ContainsKey(reg.Name.ToUpper()))
                    {
                        strSQL += dialect.FieldChar + reg.Name + dialect.FieldChar + " = " + dialect.GetFormattedValueForDb(reg, Data[reg.Name.ToUpper()]) + ", ";
                    }
                }
            }

            strSQL = StringExtensions.RemoveLastChars(strSQL, 2);
            strSQL += getWhereCondition(Data);

            return strSQL;

        }

        public string CreateExcecutionQuery(Dictionary<string, object> data, bool isNew)
        {
            if (isNew)
            {
                return BuildInsertString(data);
            }
            else
            {
                return BuildUpdateString(data);
            }
        }

        public string BuildInsertString(Dictionary<string, object> Data)
        {
            string strSQL = "";
            if (dialect is SqlServerDbType)
            {
                strSQL += "SET IDENTITY_INSERT " + dialect.FieldChar + table.TableName + dialect.FieldChar + " ON;";
            }


            strSQL += " insert into " + dialect.FieldChar + table.TableName + dialect.FieldChar + " ( ";
            string sqlValues = "";

            foreach (TableColumn reg in table.Columns)
            {

                if (Data.ContainsKey(reg.Name.ToUpper()))
                {
                    strSQL += dialect.FieldChar + reg.Name + dialect.FieldChar + ", ";
                    sqlValues += dialect.GetFormattedValueForDb(reg, Data[reg.Name.ToUpper()]) + ", ";
                }
            }

            strSQL = StringExtensions.RemoveLastChars(strSQL, 2);
            strSQL += " ) values ( " + StringExtensions.RemoveLastChars(sqlValues, 2);
            strSQL += " ) ";

            return strSQL;
        }

        //public string getSelectString(Dictionary<string, object> Data)
        //{
        //    string strSQL = " select count(*) as cnt from " + Dialect.FieldChar + table.TableName + Dialect.FieldChar + " ";

        //    strSQL += getWhereCondition(Data);

        //    return strSQL;

        //}

        //public string getPostUpdate(string body, Dictionary<string, object> Data)
        //{

        //    return body.ToLower().Replace("<table>", table.TableName).Replace("<where>", getWhereCondition(Data));

        //}



        private string getWhereCondition(Dictionary<string, object> Data)
        {

            string sql = " where ";
            bool ok = false;
            foreach (TableColumn reg in table.Columns)
            {
                if (reg.IsKey)
                {
                    sql += reg.Name + " = " + dialect.GetFormattedValueForDb(reg, Data[reg.Name.ToUpper()]) + " and ";
                    ok = true;
                }
            }

            if (!ok)
                throw new ApplicationException("Impossible to build where clause without a PrimaryKey");

            sql = StringExtensions.RemoveLastChars(sql, 4);

            return sql;
        }



    }


}
