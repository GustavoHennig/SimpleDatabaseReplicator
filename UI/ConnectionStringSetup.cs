using FirebirdSql.Data.FirebirdClient;
using MySql.Data.MySqlClient;
using Npgsql;
using Org.BouncyCastle.Asn1.Cmp;
using SimpleDatabaseReplicator.DB;
using SimpleDatabaseReplicator.SQL.Databases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleDatabaseReplicator.UI
{
    public partial class ConnectionStringSetup : UserControl
    {

        public ConnectionStringSetup()
        {
            InitializeComponent();
            InitializeProviders();
            tbHost.TextChanged += UpdateConnectionString;
            tbPort.TextChanged += UpdateConnectionString;
            tbUsername.TextChanged += UpdateConnectionString;
            tbPassword.TextChanged += UpdateConnectionString;
            tbDatabase.TextChanged += UpdateConnectionString;
        }

        private void InitializeProviders()
        {
            cbProvider.Items.AddRange(DbTypeEnum.ListSorted.ToArray());
            //cbProvider.SelectedIndex = 0;
        }


        private void cbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateConnectionString();

        }
        private void UpdateConnectionString(object sender = null, EventArgs e = null)
        {



            DbTypeEnum dbType = cbProvider.SelectedItem as DbTypeEnum;

            if (dbType is null)
            {
                return;
            }

            if (int.TryParse(tbPort.Text, out int port))
            {
                tbPort.Text = port.ToString();
            }
            else
            {
                tbPort.Text = "";
            }

            var builder = dbType.DbConnectionStringFactory.Invoke();
            if (builder is SqlConnectionStringBuilder csb)
            {
                csb.DataSource = tbHost.Text;
                csb.UserID = tbUsername.Text;
                csb.Password = tbPassword.Text;
                csb.InitialCatalog = tbDatabase.Text;
            }
            else if (builder is NpgsqlConnectionStringBuilder csb2)
            {
                csb2.Host = tbHost.Text;
                csb2.Username = tbUsername.Text;
                csb2.Password = tbPassword.Text;
                csb2.Database = tbDatabase.Text;
                csb2.Port = port > 0 ? port : 5432;
            }
            else if (builder is FbConnectionStringBuilder csb3)
            {
                csb3.DataSource = tbHost.Text;
                csb3.UserID = tbUsername.Text;
                csb3.Password = tbPassword.Text;
                csb3.Database = tbDatabase.Text;
                csb3.Port = port > 0 ? port : 3050;

            }
            else if (builder is MySqlConnectionStringBuilder csb4)
            {
                csb4.Server = tbHost.Text;
                csb4.UserID = tbUsername.Text;
                csb4.Password = tbPassword.Text;
                csb4.Database = tbDatabase.Text;
                csb4.Port = (uint)port;
            }
            else if (builder is SQLiteConnectionStringBuilder csb5)
            {
                csb5.DataSource = tbDatabase.Text;
            }
            else
            {
                throw new NotImplementedException("Provider not implemented");
            }



            tbConnectionString.Text = builder.ConnectionString;
        }



        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbProvider.SelectedItem is null)
                    return;

                using (DbCon db = TestCreatingDbConnection(ConnectionString, cbProvider.SelectedItem as DbTypeEnum))
                {
                    Dialogs.Show("Connected successfully");

                }
            }
            catch (Exception ex)
            {
                Dialogs.ShowError(ex);
            }
        }

        public string ConnectionString
        {
            get
            {
                return tbConnectionString.Text;
            }
            set
            {
                tbConnectionString.Text = value;
                ParseConnectionString(value);
            }
        }

        public DbTypeEnum DbProvider
        {
            get { return cbProvider.SelectedItem as DbTypeEnum; }
            set
            {
                cbProvider.SelectedItem = value;

            }
        }

        private DbCon TestCreatingDbConnection(string connString, DbTypeEnum dbTypeSupported)
        {
            return DbCon.Create(connString, dbTypeSupported);
        }
        private void ParseConnectionString(string connectionString)
        {
            try
            {


                DbTypeEnum dbType = cbProvider.SelectedItem as DbTypeEnum;

                if (dbType is null)
                {
                    return;
                }

                var builder = dbType.DbConnectionStringFactory.Invoke();
                builder.ConnectionString = connectionString;

                if (builder is SqlConnectionStringBuilder csb)
                {
                    tbHost.Text = csb.DataSource;
                    tbUsername.Text = csb.UserID;
                    tbPassword.Text = csb.Password;
                    tbDatabase.Text = csb.InitialCatalog;
                }
                else if (builder is NpgsqlConnectionStringBuilder csb2)
                {
                    tbHost.Text = csb2.Host;
                    tbUsername.Text = csb2.Username;
                    tbPassword.Text = csb2.Password;
                    tbDatabase.Text = csb2.Database;
                    tbPort.Text = csb2.Port.ToString();
                }
                else if (builder is FbConnectionStringBuilder csb3)
                {
                    tbHost.Text = csb3.DataSource;
                    tbUsername.Text = csb3.UserID;
                    tbPassword.Text = csb3.Password;
                    tbDatabase.Text = csb3.Database;
                    tbPort.Text = csb3.Port.ToString();
                }
                else if (builder is MySqlConnectionStringBuilder csb4)
                {
                    tbHost.Text = csb4.Server;
                    tbUsername.Text = csb4.UserID;
                    tbPassword.Text = csb4.Password;
                    tbDatabase.Text = csb4.Database;
                    tbPort.Text = csb4.Port.ToString();
                }
                else if (builder is SQLiteConnectionStringBuilder csb5)
                {
                    tbDatabase.Text = csb5.DataSource;
                }
                else
                {
                    throw new NotImplementedException("Provider not implemented");
                }
            }
            catch (Exception ex)
            {

                Dialogs.ShowError(ex);
            }
        }


    }
}
