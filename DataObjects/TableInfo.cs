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
using System.Collections;
using SimpleDatabaseReplicator.SQL.Databases;

namespace SimpleDatabaseReplicator
{
    public class TableInfo
    {
        public string TableName { get; set; }
        public string FormattedTableName { get; set; }
        public string TableSchema { get; set; }

        public List<TableColumn> Columns { get; set; } = new List<TableColumn>();

        public List<string> Keys { get; set; } = new List<string>();

        public bool EnableIdentitySync { get; set; } = false;
        public string IdentityName { get; set; } = null;
        public long IdentityValue { get; set; } = 0;
        public bool Checked { get; set; } = false;
        public SyncMode SynchronizationMode { get; set; } = SyncMode.AllAtOnce;
        
        public string ColumnKeyName { get; set; }
        public string ColumnOrderByName { get; set; }
        public int SyncRangeSize { get; set; } = 20000;

        public TableInfo()
        {
            //For Serialization only
        }

        public TableInfo(BaseDbType dbType, string schemaName, string tableName)
        {
            TableSchema = schemaName;
            TableName = tableName;
            FormattedTableName = $"{schemaName}.{tableName}";
        }

        public bool IsSchemaLoaded
        {
            get
            {
                return Columns.Count > 0;
            }
        }


        public override string ToString()
        {
            return Columns.ToString();
        }

        public override bool Equals(object obj)
        {
            TableInfo ti = obj as TableInfo;
            if (ti != null)
                return TableName.Equals(ti.TableName);
            else return false;
        }

        public override int GetHashCode()
        {
            return TableName.GetHashCode();
        }
        public enum SyncMode
        {
            AllAtOnce = 0,
            ByIdRange = 1,
            ByLimitOffset = 2
        }
    }
}
