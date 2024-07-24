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
using System.ComponentModel;
using Humanizer;
using static Humanizer.On;

namespace SimpleDatabaseReplicator
{
    public class TableInfo
    {
        [ReadOnly(true)]
        [DisplayName("Table name")]
        public string TableName { get; set; }
        [ReadOnly(true)]
        [DisplayName("Schema and table name")]
        public string FormattedTableName { get; set; }
        [ReadOnly(true)]
        [DisplayName("Table schema")]
        public string TableSchema { get; set; }

        [Browsable(false)]
        public List<TableColumn> Columns { get; set; } = new List<TableColumn>();

        [DisplayName("Primary keys")]
        public List<string> Keys { get; set; } = new List<string>();

        public bool EnableIdentitySync { get; set; } = false;
        [Browsable(false)]
        public string IdentityName { get; set; } = null;
        [Browsable(false)]
        public long IdentityValue { get; set; } = 0;

        [DisplayName("Enable synchronization")]
        public bool Checked { get; set; } = false;

        /// <summary>
        /// All at once (entire table in memory)
        ///Batch execution (using PK or UNIQUE column range)
        ///Batch execution using LIMIT OFFSET (may require multiple synchronizations to sync all rows)
        /// </summary>
       
        [Category("Synchronization settings")]
        [DisplayName("Synchronization mode")]
        [Description(@"- All at once (entire table in memory)
- Batch execution (using PK or UNIQUE column range)
- Batch execution using LIMIT OFFSET (may require multiple synchronizations to sync all rows)")]
        public SyncMode SynchronizationMode { get; set; } = SyncMode.AllAtOnce;

        [DisplayName("Enable synchronization")]
        [Category("Synchronization settings")]
        [Description(@"Unique KEY, (also used for batch by range)
* must be indexed and UNIQUE
* must be numeric for batch by range")]
        public string ColumnKeyName { get; set; }
        [Category("Synchronization settings")]
        [DisplayName("Column used to sort all records\ntste")]
         [Description(@"* should be indexed")]
        public string ColumnOrderByName { get; set; }
        [Category("Synchronization settings")]
        [DisplayName("Batch size")]
        public int SyncRangeSize { get; set; } = 20000;

        public bool IgnoreConflictErrors { get; set; } = false;

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
            /// <summary>
            /// [Description("All at once (entire table in memory)")]
            /// </summary>
            AllAtOnce = 0,
            ByIdRange = 1,
            ByLimitOffset = 2
        }
    }
}
