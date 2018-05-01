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
using SimpleDatabaseReplicator.SQL;
using SimpleDatabaseReplicator.SQL.Databases;

namespace SimpleDatabaseReplicator
{
    public class ReplicationTaskInfo : ICloneable
    {

        public string Uid = Guid.NewGuid().ToString();

        public bool Enabled;

        public BaseDbType.DbTypeSupported DialectSource;
        public BaseDbType.DbTypeSupported DialectDestination;

        public string ConnectionStringSource;
        public string ConnectionStringDestination;
        public string JobName;
        public string PostUpdateSQL;
        public string RetrieveDataCondition;

        [System.Xml.Serialization.XmlIgnore]
        [NonSerialized]
        public string Status;

        [System.Xml.Serialization.XmlIgnore]
        [NonSerialized]
        public double PbMax;

        [System.Xml.Serialization.XmlIgnore]
        [NonSerialized]
        public double PbValue;

        [System.Xml.Serialization.XmlIgnore]
        [NonSerialized]
        public List<string> StatusLog = new List<string>();

        [System.Xml.Serialization.XmlIgnore]
        [NonSerialized]
        public List<string> Errors = new List<string>();

        public List<string> IgnoreFields = new List<string>();
        public List<TableInfo> TablesAvailable = new List<TableInfo>();


        [System.Xml.Serialization.XmlIgnore]
        [NonSerialized]
        public bool IsRunning;

        public long LastTimeReplicated;

        public ReplicationTaskInfo()
        {
            //For serialization only
        }

        public ReplicationTaskInfo(string Name)
        {
            this.JobName = Name;
        }

        public void OnProgress(double vl, double max)
        {
            //public Action<int, int> OnProgress;
            PbMax = max;
            PbValue = vl;
        }

        public override string ToString()
        {
            return JobName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new ReplicationTaskInfo(this.JobName)
            {
                Enabled = Enabled,
                IgnoreFields = IgnoreFields,
                PostUpdateSQL = PostUpdateSQL,
                RetrieveDataCondition = RetrieveDataCondition,
                DialectDestination = DialectDestination,
                DialectSource = DialectSource,
                ConnectionStringDestination = ConnectionStringDestination,
                ConnectionStringSource = ConnectionStringSource,
                TablesAvailable = TablesAvailable,
                Uid = Guid.NewGuid().ToString()
            };
        }
    }

}
