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
using SimpleDatabaseReplicator.DataObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace SimpleDatabaseReplicator
{
    public class TableRow
    {

        public bool NotExistsInDestination;
        public bool DifferentFromDestination;

        /// <summary>
        /// For memory-only comparison
        /// </summary>
        public string KeyValue;

        public Dictionary<string, TableCell> Data = new Dictionary<string, TableCell>();

        public IEnumerable<KeyValuePair< string, object>> GetValues()
        {
            foreach (KeyValuePair<string, TableCell> kv in Data)
            {
                yield return new KeyValuePair<string, object>(kv.Key, kv.Value.Value);
            }
        }
        public void BuildCompositeKey(List<string> keys, string manualDefinedKey)
        {
            string key;
            if (keys.Count == 0 && !string.IsNullOrEmpty(manualDefinedKey))
            {
                key = Convert.ToString(Data[manualDefinedKey].Value);
            }
            else
            {
                key = "";
                foreach (string lkey in keys)
                {
                    key += Convert.ToString(Data[lkey].Value);
                }
            }
            KeyValue = key;

        }
    }
}
