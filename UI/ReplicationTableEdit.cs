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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimpleDatabaseReplicator.DB;
using SimpleDatabaseReplicator.UI.Base;
using System.Linq;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;
using SimpleDatabaseReplicator.Util;
using static SimpleDatabaseReplicator.TableInfo;

namespace SimpleDatabaseReplicator.UI
{
    public partial class ReplicationTableEdit : BaseForm
    {

        TableInfo tableSyncInfo;
        ReplicationTaskInfo replicationTaskInfo;

        public ReplicationTableEdit()
        {
            InitializeComponent();
        }

        private void linkedList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        internal void SetTable(TableInfo tableSyncInfo)
        {
            this.tableSyncInfo = tableSyncInfo;
            propertyGrid1.SelectedObject = tableSyncInfo;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

                SyncMode syncMode = (SyncMode)cmbSyncMode.SelectedIndex;


                if (syncMode == SyncMode.ByIdRange || syncMode == SyncMode.ByLimitOffset)
                {

                    if (int.TryParse(txtBatchSize.Text, out int idRangeSize) && idRangeSize > 0)
                    {
                        this.tableSyncInfo.SyncRangeSize = idRangeSize;
                    }
                    else
                    {
                        //TODO: show error message
                        throw new ApplicationException("Invalid Batch Size");
                    }

                    if (string.IsNullOrEmpty(txtColumnKey.Text))
                    {
                        txtColumnKey.Focus();
                        throw new ApplicationException("Column Key is required for this mode");

                    }
                }

                if (syncMode == SyncMode.ByLimitOffset && string.IsNullOrEmpty(txtColumnOrderBy.Text))
                {
                    txtColumnOrderBy.Focus();
                    throw new ApplicationException("Column Order By is required for ByLimitOffset mode");

                }

                this.tableSyncInfo.SynchronizationMode = syncMode;
                this.tableSyncInfo.ColumnKeyName = txtColumnKey.Text;
                this.tableSyncInfo.ColumnOrderByName = txtColumnOrderBy.Text;

                List<TableColumn> checkedList = GetCheckedItems().ToList();

                foreach (var v in checkedList)
                    v.Checked = true;

                foreach (var v in tableSyncInfo.Columns.Except(checkedList))
                    v.Checked = false;

                tableSyncInfo.TableName = txtTableName.Text;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private IEnumerable<TableColumn> GetCheckedItems()
        {
            foreach (ListViewItem item in lvwColumnsDetails.CheckedItems)
            {
                yield return (TableColumn)item.Tag;
            }
        }

        private void GraphicMapping_Load(object sender, EventArgs e)
        {
            if (!tableSyncInfo.IsSchemaLoaded)
            {
                LoadSchema();
            }
            //dbt.LoadTableSchema(tableSyncInfo.DestinationTable);

            txtColumnKey.Text = this.tableSyncInfo.ColumnKeyName;
            txtTableName.Text = tableSyncInfo.TableName;
            cmbSyncMode.SelectedIndex = (int)tableSyncInfo.SynchronizationMode;
            txtBatchSize.Text = tableSyncInfo.SyncRangeSize.ToString();
            txtColumnOrderBy.Text = this.tableSyncInfo.ColumnOrderByName;


            //chkIndenticalSrcDst.Checked;
            LoadColumnsList();


            foreach (var item in Settings.Default.TableEditColumnsColumnWidths)
            {
                lvwColumnsDetails.Columns[item.Key].Width = item.Value;
            }

        }



        internal void ReplicationTaskInfo(ReplicationTaskInfo jobEditting)
        {
            replicationTaskInfo = jobEditting;
        }

        private void txtColumnKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lnkLoadSchema_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tableSyncInfo.TableName = txtTableName.Text;
            LoadSchema();
            LoadColumnsList();
        }

        private void LoadColumnsList()
        {
            lvwColumnsDetails.Items.Clear();

            foreach (TableColumn c in tableSyncInfo.Columns)
            {
                var item = lvwColumnsDetails.Items.Add(c.Name);
                item.SubItems.Add(c.TypeName);
                item.SubItems.Add(c.DbTypeName);
                item.SubItems.Add((c.IsKey ? "PK" : ""));
                item.Checked = c.Checked;
                item.Tag = c;

            }


        }

        private void LoadSchema()
        {

            try
            {
                lnkLoadSchema.Text = "Load Schema (...)";
                using (DbCon db = DbCon.Create(replicationTaskInfo.ConnectionStringSource, replicationTaskInfo.DbProviderSource))
                {
                    DbSchemaLoader.LoadTableInfoSchema(db, tableSyncInfo);
                }
                txtColumnKey.Text = string.Join(",", tableSyncInfo.Keys);

                lnkLoadSchema.Text = "Load Schema (ok)";
            }
            catch (Exception)
            {
                lnkLoadSchema.Text = "Load Schema (failed)";
            }
        }

        private void lvwColumnsDetails_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            Settings.Default.TableEditColumnsColumnWidths[e.ColumnIndex] = lvwColumnsDetails.Columns[e.ColumnIndex].Width;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbSyncMode_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cmbSyncMode.SelectedIndex == 0)
            {
                txtBatchSize.Enabled = false;
                txtColumnKey.Enabled = true;
            }
            else if (cmbSyncMode.SelectedIndex == 1)
            {
                txtBatchSize.Enabled = true;
                txtColumnKey.Enabled = true;
            }
            else
            {
                txtBatchSize.Enabled = true;
                txtColumnKey.Enabled = true;
            }
        }
    }
}