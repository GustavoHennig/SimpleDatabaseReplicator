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
using SimpleDatabaseReplicator.SQL;
using System.Reflection;
using SimpleDatabaseReplicator.UI.Base;
using SimpleDatabaseReplicator.DB;
using SimpleDatabaseReplicator.SQL.Databases;
using System.Linq;
using SimpleDatabaseReplicator.Util;

namespace SimpleDatabaseReplicator.UI
{
    public partial class ReplicationTaskEdit : BaseForm
    {

        private ReplicationTaskInfo JobEditting;

        public ReplicationTaskEdit(ReplicationTaskInfo JobEditting)
        {
            this.JobEditting = JobEditting;

            InitializeComponent();


            LoadData();
        }

        private void AdicionaStatus(string msg)
        {
            lstErros.Items.Add(msg);
            if (lstErros.Items.Count > 500)
            {
                lstErros.Items.RemoveAt(0);
            }
        }
        private void LoadData()
        {

            lstTables.Items.Clear();
            PopulateListView(JobEditting.SourceTables, JobEditting.DestinationTables);


            lstExFields.Items.Clear();
            foreach (string item in JobEditting.IgnoreFields)
            {
                lstExFields.Items.Add(item);
            }

            foreach (string erro in JobEditting.Errors)
            {
                lstErros.Items.Add(erro);
            }

            connectionStringSetupSource.DbProvider = JobEditting.DbProviderSource;
            connectionStringSetupDestination.DbProvider = JobEditting.DbProviderDestination;

            connectionStringSetupDestination.ConnectionString = JobEditting.ConnectionStringDestination;
            connectionStringSetupSource.ConnectionString = JobEditting.ConnectionStringSource;

            
            txtJobName.Text = JobEditting.JobName;


            txtPostUpdate.Text = JobEditting.PostUpdateSQL;
            txtIgnoreCondition.Text = JobEditting.RetrieveDataCondition;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTable();
        }
        private ListViewItem CreateListViewItem(TableInfo tableInfoSource, TableInfo tableInfoDestination = null)
        {
            var lvi = new ListViewItem();// $"{tableInfoDestination.TableSchema}.{tableInfoDestination.TableName}");
            lvi.SubItems.Add("");
            if (tableInfoDestination != null)
                lvi.SubItems[columnTableDestination.Index].Text = tableInfoDestination.FormattedTableName;

            lvi.SubItems[columnTableSource.Index].Text = tableInfoSource.FormattedTableName;
            lvi.Tag = tableInfoSource;
            lvi.Checked = tableInfoSource.Checked;
            lvi.Name = tableInfoSource.FormattedTableName;
            return lvi;
        }

        private void AddTable()
        {

            TableInfo tableInfo = new TableInfo();

            if (StartGraphicMapping(tableInfo))
            {


                if (lstTables.SelectedIndices.Count > 0 && lstTables.SelectedIndices[0] >= 0)
                {
                    lstTables.Items.Insert(lstTables.SelectedIndices[0], CreateListViewItem(tableInfo));
                    //  JobEditting.TablesToProcess.Insert(lstTables.SelectedIndex, txtInsert.Text);
                }
                else
                {
                    lstTables.Items.Add(CreateListViewItem(tableInfo));
                    //JobEditting.TablesToProcess.Add(txtInsert.Text);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = lstTables.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstTables.Items.RemoveAt(lstTables.SelectedIndices[i]);
            }
        }
        private void btnLimparErros_Click(object sender, EventArgs e)
        {
            lstErros.Items.Clear();
        }

        private void AddField()
        {
            if (lstExFields.SelectedIndex >= 0)
            {
                lstExFields.Items.Insert(lstExFields.SelectedIndex, txtEditField.Text);
            }
            else
            {
                lstExFields.Items.Add(txtEditField.Text);
            }
            txtEditField.SelectAll();
        }

        private void SaveChanges()
        {
            JobEditting.ConnectionStringDestination = connectionStringSetupDestination.ConnectionString;
            JobEditting.ConnectionStringSource =  connectionStringSetupSource.ConnectionString;
            JobEditting.DbProviderDestination =  connectionStringSetupDestination.DbProvider;
            JobEditting.DbProviderSource = connectionStringSetupSource.DbProvider;

            JobEditting.SourceTables = lstTables.Items.Cast<ListViewItem>().Select(s => s.Tag as TableInfo).ToList();


            //TODO: Fill schema info at this point

            try
            {
                using (DbCon db = DbCon.Create(JobEditting.ConnectionStringSource, JobEditting.DbProviderSource))
                {

                    DbSchemaLoader.LoadTableInfoSchema(db, JobEditting.SourceTables.Where(w => w.Checked));
                }
            }
            catch (Exception)
            {

            }
            JobEditting.IgnoreFields.Clear();

            foreach (string item in lstExFields.Items)
            {
                JobEditting.IgnoreFields.Add(item);
            }

            //JobEditting.Errors.Clear();

            //foreach (string erro in lstErros.Items)
            //{
            //    JobEditting.Errors.Add(erro);
            //}


            JobEditting.JobName = txtJobName.Text;
            JobEditting.PostUpdateSQL = txtPostUpdate.Text;
            JobEditting.RetrieveDataCondition = txtIgnoreCondition.Text;



            if (!Settings.Default.ReplicationTasks.Contains(JobEditting))
            {
                Settings.Default.ReplicationTasks.Add(JobEditting);
            }

            Settings.Save();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveChanges();

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddField_Click(object sender, EventArgs e)
        {
            AddField();

        }

        private void btnRemoveField_Click(object sender, EventArgs e)
        {
            if (lstExFields.SelectedIndex >= 0)
            {
                //JobEditting.TablesToProcess.RemoveAt(lstTables.SelectedIndex);
                lstExFields.Items.RemoveAt(lstExFields.SelectedIndex);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.connectionstrings.com");
        }

        private void lnkRetrieveTables_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                List<TableInfo> tablesSource;
                using (DbCon db = DbCon.Create(connectionStringSetupSource.ConnectionString, connectionStringSetupSource.DbProvider))
                    tablesSource = DbSchemaLoader.GetAllTables(db);

                List<TableInfo> tablesDestination;
                using (DbCon db = DbCon.Create(connectionStringSetupDestination.ConnectionString, connectionStringSetupDestination.DbProvider))
                    tablesDestination = DbSchemaLoader.GetAllTables(db);

                PopulateListView(tablesSource, tablesDestination);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }
        }

        public void PopulateListView(List<TableInfo> tablesSource, List<TableInfo> tablesDestination)
        {
            if (tablesSource.Count > 0)
            {
                lstTables.Items.AddRange(tablesSource.Where(t => !lstTables.Items.ContainsKey(t.FormattedTableName))
                                               .Select(tbSource => CreateListViewItem(tbSource))
                                               .ToArray());
            }

            foreach (var tb in tablesDestination)
            {
                var lvi = lstTables.Items[tb.FormattedTableName];
                if (lvi != null)
                {
                    lvi.SubItems[columnTableDestination.Index].Text = tb.FormattedTableName;
                    lvi.Tag = tb;
                }
                else
                {
                    CreateListViewItem(tb);
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstTables.Items.Count; i++)
            {
                lstTables.Items[i].Checked = true;
            }

        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstTables.Items.Count; i++)
            {
                lstTables.Items[i].Checked = false;
            }


        }

        private void btnGraphMapping_Click(object sender, EventArgs e)
        {
            if (lstTables.SelectedItems.Count > 0)
            {
                StartGraphicMapping(lstTables.SelectedItems[0].Tag as TableInfo);
            }
        }

        private bool StartGraphicMapping(TableInfo tableInfo)
        {
            ReplicationTableEdit graphicMapping = new ReplicationTableEdit();
            graphicMapping.SetTable(tableInfo);
            graphicMapping.ReplicationTaskInfo(this.JobEditting);
            return graphicMapping.ShowDialog() == DialogResult.OK;
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstTables.SelectedItems)
            {
                if (lvi.Index > 0)
                {
                    int index = lvi.Index - 1;
                    lstTables.Items.RemoveAt(lvi.Index);
                    lstTables.Items.Insert(index, lvi);
                    lvi.EnsureVisible();
                }
            }

        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstTables.SelectedItems)
            {
                if (lvi.Index >= 0 && lvi.Index < lstTables.Items.Count)
                {
                    int index = lvi.Index + 1;
                    lstTables.Items.RemoveAt(lvi.Index);
                    lstTables.Items.Insert(index, lvi);
                    lvi.EnsureVisible();
                }
            }
        }

        private void lstTables_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            (e.Item.Tag as TableInfo).Checked = e.Item.Checked;
        }

        private void txtTableFilter_TextChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstTables.Items)
            {
                bool found = item.Text.Contains(txtTableFilter.Text);
                item.BackColor = found ? Color.DeepSkyBlue : Color.White;
                if (found)
                    item.EnsureVisible();
            }
        }

        private void lstTables_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnGraphMapping.PerformClick();
        }

        private void connectionStringSetup1_Load(object sender, EventArgs e)
        {

        }
    }


}