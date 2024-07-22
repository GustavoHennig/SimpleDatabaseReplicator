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
using System.Diagnostics;
using System.Text;

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

        public Dictionary<string, object> Data = new Dictionary<string, object>();


        public void BuildCompositeKey(List<string> keys)
        {
            string key = "";
            foreach (string lkey in keys)
            {
                key += Convert.ToString(Data[lkey]);
            }
            KeyValue = key;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                try
                {
                    TableRow ri = (TableRow)obj;


                    foreach (string k in Data.Keys)
                    {
                        if (ri.Data.ContainsKey(k))
                        {
                            if (!ObjectComparison.EquivalentValue(Data[k], ri.Data[k]))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            //TODO: Schema is different
                        }
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
