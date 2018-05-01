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

namespace SimpleDatabaseReplicator.UI
{
    public partial class EditJob : BaseForm
    {

        private ReplicationTaskInfo JobEditting;

        public EditJob(ReplicationTaskInfo JobEditting)
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

            foreach (FieldInfo mi in typeof(BaseDbType.DbTypeSupported).GetFields())
            {
                if (mi.IsLiteral && mi.IsStatic)
                {
                    cmdSource.Items.Insert(Convert.ToInt32(mi.GetRawConstantValue()), mi.Name);
                    cmdDest.Items.Insert(Convert.ToInt32(mi.GetRawConstantValue()), mi.Name);
                }
            }


            lstTables.Items.Clear();

            foreach (TableInfo item in JobEditting.TablesAvailable)
            {
                var lvi = CreateListViewItem(item);
                lstTables.Items.Add(lvi);
            }

            lstExFields.Items.Clear();
            foreach (string item in JobEditting.IgnoreFields)
            {
                lstExFields.Items.Add(item);
            }

            foreach (string erro in JobEditting.Errors)
            {
                lstErros.Items.Add(erro);
            }

            txtStringDestination.Text = JobEditting.ConnectionStringDestination;
            txtStringSource.Text = JobEditting.ConnectionStringSource;

            cmdSource.SelectedIndex = Convert.ToInt32(JobEditting.DialectSource);
            cmdDest.SelectedIndex = Convert.ToInt32(JobEditting.DialectDestination);
            txtJobName.Text = JobEditting.JobName;


            txtPostUpdate.Text = JobEditting.PostUpdateSQL;
            txtIgnoreCondition.Text = JobEditting.RetrieveDataCondition;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTable();
        }
        private ListViewItem CreateListViewItem(TableInfo tableInfo)
        {
            var lvi = new ListViewItem(tableInfo.TableName);
            lvi.Tag = tableInfo;
            lvi.Checked = tableInfo.Checked;
            lvi.Name = tableInfo.TableName;
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
            JobEditting.ConnectionStringDestination = txtStringDestination.Text;
            JobEditting.ConnectionStringSource = txtStringSource.Text;
            JobEditting.DialectDestination = (BaseDbType.DbTypeSupported)cmdDest.SelectedIndex;
            JobEditting.DialectSource = (BaseDbType.DbTypeSupported)cmdSource.SelectedIndex;

            JobEditting.TablesAvailable = lstTables.Items.Cast<ListViewItem>().Select(s => s.Tag as TableInfo).ToList();


            //TODO: Fill schema info at this point

            try
            {
                using (DbCon db = new DbConnectionInfo(JobEditting.ConnectionStringSource, JobEditting.DialectSource).CreateConnection())
                {
                    DbTableLoader dbt = new DbTableLoader(db, null);
                    dbt.LoadTableSchemaBatch(JobEditting.TablesAvailable.Where(w => w.Checked).ToList());
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



            if (!Preferences.Settings.jobs.Contains(JobEditting))
            {
                Preferences.Settings.jobs.Add(JobEditting);
            }

            Preferences.Save();

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
                List<TableInfo> tables;
                using (DbCon db = new DbConnectionInfo(txtStringSource.Text, (BaseDbType.DbTypeSupported)cmdSource.SelectedIndex).CreateConnection())
                    tables = db.GetAllTables();

                if (tables.Count > 0)
                {
                    lstTables.Items.AddRange(tables.Where(t => !lstTables.Items.ContainsKey(t.TableName)).Select(s => CreateListViewItem(s)).ToArray());
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

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

        private bool StartGraphicMapping(TableInfo tableInfo) {
            GraphicMapping graphicMapping = new GraphicMapping();
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
                }
            }
        }

        private void lstTables_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            (e.Item.Tag as TableInfo).Checked = e.Item.Checked;
        }

        private void btnTestConnDest_Click(object sender, EventArgs e)
        {
            try
            {
                using (DbCon db = CreateDbConn(true))
                    btnTestConnDest.Text = "Test (ok)";
            }
            catch (Exception)
            {
                btnTestConnDest.Text = "Test (error)";
            }


        }

        private void btnTestConnSource_Click(object sender, EventArgs e)
        {
            try
            {
                using (DbCon db = CreateDbConn(false))
                    btnTestConnSource.Text = "Test (ok)";
            }
            catch (Exception)
            {
                btnTestConnSource.Text = "Test (error)";
            }
        }


        private DbCon CreateDbConn(bool dest)
        {
            if (dest)
                return new DbConnectionInfo(txtStringDestination.Text, (BaseDbType.DbTypeSupported)cmdDest.SelectedIndex).CreateConnection();
            else
                return new DbConnectionInfo(txtStringSource.Text, (BaseDbType.DbTypeSupported)cmdSource.SelectedIndex).CreateConnection();
        }

    }


}