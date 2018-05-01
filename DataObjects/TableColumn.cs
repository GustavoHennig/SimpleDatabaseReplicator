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
        public string Name;
        public bool IsKey;
        public string TypeName;
        public int DefinedSize;
        public bool AllowNull;
        public int Precision;
        public int Decimals;
        public bool IsAutoIncrement;
        public string AuldIncrementName;
        public bool Checked;

        public override string ToString()
        {
            return (IsKey ? "[PK] " : "") +  Name;
        }
    }
}
