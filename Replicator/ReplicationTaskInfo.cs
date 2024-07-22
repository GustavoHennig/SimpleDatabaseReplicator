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
using System.Text.Json.Serialization;
using SimpleDatabaseReplicator.SQL;
using SimpleDatabaseReplicator.SQL.Databases;

namespace SimpleDatabaseReplicator
{
    public class ReplicationTaskInfo : ICloneable
    {

        public string Uid { get; set; } = Guid.NewGuid().ToString();

        public bool Enabled { get; set; }

        public BaseDbType.DbTypeSupported DialectSource { get; set; }
        public BaseDbType.DbTypeSupported DialectDestination { get; set; }

        public string ConnectionStringSource { get; set; }
        public string ConnectionStringDestination { get; set; }
        public string JobName { get; set; }
        public string PostUpdateSQL { get; set; }
        public string RetrieveDataCondition { get; set; }

        [JsonIgnore]
        public string Status { get; set; }

        [JsonIgnore]
        public double PbMax { get; set; }

        [JsonIgnore]
        public double PbValue { get; set; }

        [JsonIgnore]
        public List<string> StatusLog { get; set; } = new List<string>();

        [JsonIgnore]
        public List<string> Errors { get; set; } = new List<string>();

        public List<string> IgnoreFields { get; set; } = new List<string>();
        public List<TableInfo> TablesAvailable { get; set; } = new List<TableInfo>();

        [JsonIgnore]
        public bool IsRunning { get; set; }

        public long LastTimeReplicated { get; set; }
        private string connectionStringSource;

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
