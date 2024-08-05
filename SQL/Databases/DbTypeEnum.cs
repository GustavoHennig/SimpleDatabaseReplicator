using Ardalis.SmartEnum;
using FirebirdSql.Data.FirebirdClient;
using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleDatabaseReplicator.SQL.Databases
{
    public class DbTypeEnum : SmartEnum<DbTypeEnum>
    {
        /// <summary>
        /// These static fields are serialized to JSON, so they cannot be changed.
        /// </summary>
        public static readonly DbTypeEnum SqlServer = new DbTypeEnum(nameof(SqlServer), "SQL Server", 0, typeof(SqlServerDbType), typeof(SqlConnectionStringBuilder));
        public static readonly DbTypeEnum Access = new DbTypeEnum(nameof(Access), "Access", 1, typeof(AccessDbType), typeof(OleDbConnectionStringBuilder));
        public static readonly DbTypeEnum Firebird = new DbTypeEnum(nameof(Firebird), "Firebird", 2, typeof(FirebirdDbType), typeof(FbConnectionStringBuilder));
        public static readonly DbTypeEnum Sqlite = new DbTypeEnum(nameof(Sqlite), "Sqlite", 3, typeof(SqLiteDbType), typeof(SQLiteConnectionStringBuilder));
        public static readonly DbTypeEnum Postgres = new DbTypeEnum(nameof(Postgres), "PostgreSQL", 4, typeof(PostgresDbType), typeof(NpgsqlConnectionStringBuilder));
        public static readonly DbTypeEnum Oracle = new DbTypeEnum(nameof(Oracle), "Oracle", 5, typeof(OracleDbType), typeof(DbConnectionStringBuilder));
        public static readonly DbTypeEnum MySql = new DbTypeEnum(nameof(MySql), "MySql", 6, typeof(MysqlDbType), typeof(MySqlConnectionStringBuilder));


        [JsonIgnore]
        public string DisplayName { get; private set; }

        [JsonIgnore]
        public Func<BaseDbType> DbTypeFactory { get; private set; }
        [JsonIgnore]
        public Func<DbConnectionStringBuilder> DbConnectionStringFactory { get; private set; }

        public static IEnumerable<DbTypeEnum> ListSorted => List.OrderBy(o => o.Value);
        private DbTypeEnum(string name, string displayName, int value, Type baseDbType, Type connStringBuilder) : base(name, value)
        {
            this.DisplayName = displayName;
            this.DbTypeFactory = () => (BaseDbType)Activator.CreateInstance(baseDbType);
            this.DbConnectionStringFactory = () => (DbConnectionStringBuilder)Activator.CreateInstance(connStringBuilder);
        }
    }
}
