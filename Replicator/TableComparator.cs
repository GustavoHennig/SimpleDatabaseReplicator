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

namespace SimpleDatabaseReplicator
{
    public class TableComparator
    {

        public List<TableRow> SearchForObjectDifferences(Table source, Table dest)
        {
            List<TableRow> ret = new List<TableRow>();

            if (source != null && dest != null)
            {
                //Compares each source row with the same in the destination (using dictionary keys)
                foreach (TableRow riS in source.Data.Values)
                {
                    if (dest.Data.ContainsKey(riS.Key))
                    {
                        if (!riS.Equals(dest.Data[riS.Key]))
                        {
                            riS.DiferentFromDestinaion = true;
                            riS.NotExistsInDestination = false;
                            ret.Add(riS);
                        }
                    }
                    else
                    {
                        riS.DiferentFromDestinaion = true;
                        riS.NotExistsInDestination = true;
                        ret.Add(riS);
                    }
                }
            }
            return ret;
        }
    }
}
