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
namespace SimpleDatabaseReplicator
{

    public class TableColumn
    {
        public string Name { get; set; }
        public bool IsKey{ get; set; }
        public string TypeName{ get; set; }
        public int DefinedSize{ get; set; }
        public bool AllowNull{ get; set; }
        public int Precision{ get; set; }
        public int Decimals{ get; set; }
        public bool IsAutoIncrement{ get; set; }
        public string AutoIncrementName{ get; set; }
        public bool Checked{ get; set; }
        public string DbTypeName { get;  set; }

        public override string ToString()
        {
            return (IsKey ? "[PK] " : "") +  Name;
        }
    }
}
