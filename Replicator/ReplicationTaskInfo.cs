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
using Ardalis.SmartEnum.SystemTextJson;
using SimpleDatabaseReplicator.SQL;
using SimpleDatabaseReplicator.SQL.Databases;

namespace SimpleDatabaseReplicator
{
    public class ReplicationTaskInfo : ICloneable
    {

        public string Uid { get; set; } = Guid.NewGuid().ToString();

        public bool Enabled { get; set; }

        [JsonConverter(typeof(SmartEnumNameConverter<DbTypeEnum, int>))]
        public DbTypeEnum DbProviderSource { get; set; }
        [JsonConverter(typeof(SmartEnumNameConverter<DbTypeEnum, int>))]
        public DbTypeEnum DbProviderDestination { get; set; }

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
        public List<TableInfo> SourceTables { get; set; } = new List<TableInfo>();
        public List<TableInfo> DestinationTables { get; set; } = new List<TableInfo>();

        [JsonIgnore]
        public bool IsRunning { get; set; }

        public DateTime LastReplicationTime { get; set; }

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
                DbProviderDestination = DbProviderDestination,
                DbProviderSource = DbProviderSource,
                ConnectionStringDestination = ConnectionStringDestination,
                ConnectionStringSource = ConnectionStringSource,
                SourceTables = SourceTables,
                Uid = Guid.NewGuid().ToString()
            };
        }
    }

}
