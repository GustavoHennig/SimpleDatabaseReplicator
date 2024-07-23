using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDatabaseReplicator.DB
{
    internal class DbSchemaLoader
    {


        /// <summary>
        /// Get list of all table without schema
        /// </summary>
        /// <returns></returns>
        public static List<TableInfo> GetAllTables(DbCon dbCon)
        {

            List<TableInfo> ret = new List<TableInfo>();
            using (IDataReader dr = dbCon.ExecuteDataReader(dbCon.DbConnectionInfo.DbType.AllTablesCommand))
            {
                while (dr.Read())
                {
                    ret.Add(new TableInfo(dbCon.DbConnectionInfo.DbType, dr["schema_name"] as string, dr["table_name"] as string));
                }

            }
            return ret;
        }


        public static void LoadTableInfoSchema(DbCon dbCon, IEnumerable<TableInfo> tables)
        {

            foreach (var table in tables.Where(w => !w.IsSchemaLoaded))
            {
                LoadTableInfoSchema(dbCon, table);
            }
        }

        public static void LoadTableInfoSchema(DbCon db, TableInfo table)
        {

            var dbType = db.DbConnectionInfo.DbType;
            string sql = @$"
select * 
from {dbType.FormatDbObj(table.TableSchema)}.{dbType.FormatDbObj(table.TableName)} WHERE 1 = 0";

            using (IDataReader dr = db.ExecuteDataReader(sql))
            {

                //Monta o Header
                DataTable dt = dr.GetSchemaTable(); // db

                TableColumn rf;

                foreach (DataRow drr in dt.Rows)
                {
                    rf = table.Columns.FirstOrDefault(o => o.Name == drr["ColumnName"].ToString());

                    if (rf == null)
                    {
                        rf = new TableColumn();
                        table.Columns.Add(rf);
                    }
                    rf.Checked = true;
                    //rf.Value = dr.GetValue(Convert.ToInt32(drr["ColumnOrdinal"]));
                    rf.Name = drr["ColumnName"].ToString();
                    rf.IsKey = Convert.ToBoolean((drr["IsKey"] is DBNull ? false : drr["IsKey"]));

                    rf.DefinedSize = Convert.ToInt32(drr["ColumnSize"]);
                    if(drr["AllowDBNull"] is DBNull)
                    {
                        rf.AllowNull = true;
                    }
                    else
                    {
                        rf.AllowNull = Convert.ToBoolean(drr["AllowDBNull"]);
                    }
                    rf.TypeName = ((Type)drr["DataType"]).Name;
                    if (!(drr["NumericPrecision"] is DBNull))
                    {
                        rf.Precision = Convert.ToInt32(drr["NumericPrecision"]);
                    }
                    if (!(drr["NumericScale"] is DBNull))
                    {
                        rf.Decimals = Convert.ToInt32(drr["NumericScale"]);
                    }

                    rf.IsAutoIncrement = Convert.ToBoolean(drr["IsAutoIncrement"]);

                    if (rf.IsKey)
                    {
                        if (!table.Keys.Exists(o => o.Equals(rf.Name, StringComparison.CurrentCultureIgnoreCase)))
                            table.Keys.Add(rf.Name);
                    }
                }

                if (table.Keys.Count == 1)
                {
                    table.ColumnKeyName = table.Keys[0];
                }
            }
        }

    }
}
