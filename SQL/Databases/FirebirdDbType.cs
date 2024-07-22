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
    public class FirebirdDbType : BaseDbType
    {
        

        public override string FormatNumberValue(object value)
        {
            return  value.ToString().Replace(',', '.');
        }

        public override string FormatStringValue(object value)
        {
            return "'" + ((string)value).Replace("'","''") + "'";
        }

        public override string FormatDateValue(object value)
        {
            return "'" + ((DateTime)value).ToString("MM/dd/yyyy HH:mm:ss") + "'";
        }

        public  override string NullString
        {
            get
            { 
                return "null";
            }
        }

     

        public override string GetDBFieldType(TableColumn f)
        {
            string ret = "";
            switch (f.TypeName)
            {
                case "Int16":
                    ret = "smallint";
                    break;
                case "DateTime":
                    ret = "TIMESTAMP";
                    break;
                case "Byte":
                    ret = "SMALLINT";
                    break;
                case "Int32":
                case "Int64":
                    ret = "integer";
                    break;
                case "String":
                    //UPGRADE_WARNING: Couldn't resolve default property of object RS.Fields. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                   /* if (f.DefinedSize > 255)
                    {
                        ret = "ntext";
                    }
                    else
                    {*/
                        ret = "Varchar(" + f.DefinedSize + ")";
                   // }

                    break;
                
                case "Decimal":
                    ret = "Decimal(15,6)";
                    break;
                case "Double":
                    ret = "DOUBLE PRECISION";
                    break;
                case "Float":
                case "Single":
                    ret = "Float";
                    break;
                case "Char[]":
                    ret = "char(" + f.DefinedSize + ")";
                    break;
                default:
                    ret = " unknowed ";
                    //TODO: Exception
                    break;
            }
            return ret;
        }


        public override string NullableField
        {
            get
            {
                return " ";
            }
        }

        public override string NotNullableField
        {
            get
            {
                return "NOT NULL";
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
            throw new NotImplementedException();
        }


        public override string AllTablesCommand
        {
            get { throw new NotImplementedException(); }
        }

        public override System.Data.Common.DbConnection BuildConnection(string connectionString)
        {
            return new FirebirdSql.Data.FirebirdClient.FbConnection(connectionString);
        }
    }
}

