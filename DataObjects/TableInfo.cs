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

namespace SimpleDatabaseReplicator
{
    public class TableInfo
    {
        public string TableName;
        public List<TableColumn> Columns = new List<TableColumn>();
        public List<string> Keys = new List<string>();

        public bool EnableIdentitySync = false;
        public string IdentityName = null;
        public long IdentityValue = 0;
        public bool Checked = false;
        public bool CompareEntireTableAtOnce = true;
        public bool UseLimitOffset = true;
        public string ColumnKeyName;
        public int IdRangeSize = 20000;

        public TableInfo()
        {
            //For Serialization only
        }

        public TableInfo(string tableName)
        {
            TableName = tableName;
        }

        public bool HasSchema
        {
            get
            {
                return Columns.Count > 0;
            }
        }
        public override string ToString()
        {
            return TableName.ToString();
        }

        public override bool Equals(object obj)
        {
            TableInfo ti = obj as TableInfo;
            if (ti != null)
                return this.TableName.Equals(ti.TableName);
            else return false;
        }
        public override int GetHashCode()
        {
            return this.TableName.GetHashCode();
        }

    }
}
