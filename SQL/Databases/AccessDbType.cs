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
    public class AccessDbType : BaseDbType
    {
                public override string GetDBFieldType(TableColumn f)
        {
            string ret = "";
            switch (f.TypeName)
            {
                case "Int16":
                    ret = "smallint";
                    break;
                case "DateTime":
                    ret = "smalldatetime";
                    break;
                case "Byte":
                    ret = "tinyint";
                    break;
                case "Int32":
                case "Int64":
                    ret = "integer";
                    break;
                case "String":
                    //UPGRADE_WARNING: Couldn't resolve default property of object RS.Fields. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (f.DefinedSize > 255)
                    {
                        ret = "ntext";
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
            throw new NotImplementedException();
        }


        public override string AllTablesCommand
        {
            get { throw new NotImplementedException(); }
        }


        public override System.Data.Common.DbConnection BuildConnection(string connectionString)
        {
           return new System.Data.OleDb.OleDbConnection(connectionString);
        }
    }
}
