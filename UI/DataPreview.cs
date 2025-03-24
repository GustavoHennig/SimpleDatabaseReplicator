using SimpleDatabaseReplicator.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleDatabaseReplicator.UI
{
    public partial class DataPreview : Form
    {
        ReplicationTaskInfo replicationTaskInfo;
        SynchronizationContext windowsFormsContext;
        private List<TableRow> currentModifiedRows;

        Replicator replicator;
        ReplicationPreviewResult previewResult;
        MessageHandler messageHandler;
        public DataPreview()
        {
            InitializeComponent();
            windowsFormsContext = SynchronizationContext.Current;
            dataGridView1.CellFormatting += this.DataGridView1_CellFormatting;
            messageHandler = new MessageHandler(windowsFormsContext, LogStatus, LogError);
            replicator = new Replicator(messageHandler);

        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (currentModifiedRows == null || e.RowIndex >= currentModifiedRows.Count)
                return;

            var tableRow = currentModifiedRows[e.RowIndex];
            var columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (tableRow.Data.TryGetValue(columnName, out var cellValue) && cellValue.IsDifferent)
            {
                //e.CellStyle.BackColor = Color.Red;
                e.CellStyle.ForeColor = Color.Red; // optional for readability
            }
        }

        internal void SetData(ReplicationTaskInfo replicationTaskInfo)
        {
            this.replicationTaskInfo = replicationTaskInfo;

            cmbTables.Items.Clear();
            foreach (var item in replicationTaskInfo.SourceTables.Where(t => t.Checked))
            {
                cmbTables.Items.Add(item.FormattedTableName);
            }

        }

        private async void btnRunComparison_Click(object sender, EventArgs e)
        {

            await RunPreview(replicationTaskInfo);
        }
        private async Task RunPreview(ReplicationTaskInfo job)
        {
            Replicator.AbortReplication = false;

            // Check if a table is selected
            if (cmbTables.Text == "toolStripDropDownButton1" ||
                string.IsNullOrEmpty(cmbTables.Text))
            {
                MessageBox.Show("Please select a table first", "Table Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Find the selected table info
            TableInfo selectedTable = GetSelectedTableInfo();

            if (selectedTable == null)
            {
                MessageBox.Show("Selected table not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Set the selected table as checked for preview
            selectedTable.Checked = true;

            int.TryParse(txtFilterMin.Text, out int min);
            int.TryParse(txtFilterMax.Text, out int max);
            var syncParameters = new SyncParameters
            {
                CurMaxId = max,
                CurMinId = min,
                KeyField = cmbFilterFields.Text
            };

            try
            {


                btnRunComparison.Enabled = false;
                previewResult = await Task.Run(() => replicator.Preview(job, selectedTable, syncParameters));

                DisplayPreviewResults(selectedTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRunComparison.Enabled = true;
            }
        }

        public TableInfo GetSelectedTableInfo()
        {
            string selectedTableName = cmbTables.Text;

            // Find the selected table info
            TableInfo selectedTable = replicationTaskInfo.SourceTables.FirstOrDefault(t =>
                t.FormattedTableName == selectedTableName);

            return selectedTable;
        }

        private void DisplayPreviewResults(TableInfo tableInfo)
        {
            // Clear the DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            List<TableRow> modifiedRows = previewResult?.ModifiedRows;

            if (modifiedRows == null || modifiedRows.Count == 0)
            {
                // No differences found
                MessageBox.Show("No differences found between source and destination",
                    "Preview Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            currentModifiedRows = modifiedRows;

            // Create a DataTable to hold the preview results
            DataTable resultsTable = new DataTable();

            // Add operation type column
            resultsTable.Columns.Add("Operation", typeof(string));

            // Add key column(s)
            if (tableInfo.Keys.Count > 0)
            {
                foreach (string key in tableInfo.Keys)
                {
                    resultsTable.Columns.Add(key, typeof(string));
                }
            }
            else if (!string.IsNullOrEmpty(tableInfo.ColumnKeyName))
            {
                resultsTable.Columns.Add(tableInfo.ColumnKeyName, typeof(string));
            }

            // Get all column names from the first row
            if (modifiedRows.Count > 0)
            {
                var firstRow = modifiedRows[0].GetValues();
                foreach (var cell in firstRow)
                {
                    // Skip columns already added (keys)
                    if (!resultsTable.Columns.Contains(cell.Key))
                    {
                        resultsTable.Columns.Add(cell.Key, typeof(string));
                    }
                }
            }

            // Add rows to the DataTable
            foreach (TableRow row in modifiedRows)
            {
                DataRow newRow = resultsTable.NewRow();

                // Set operation type
                newRow["Operation"] = row.NotExistsInDestination ? "INSERT" : "UPDATE";

                // Set key values
                if (tableInfo.Keys.Count > 0)
                {
                    foreach (string key in tableInfo.Keys)
                    {
                        newRow[key] = row.Data[key].Value?.ToString() ?? "NULL";

                        //newRow. todo color
                    }
                }
                else if (!string.IsNullOrEmpty(tableInfo.ColumnKeyName))
                {
                    newRow[tableInfo.ColumnKeyName] = row.Data[tableInfo.ColumnKeyName].Value?.ToString() ?? "NULL";
                }

                // Set all other column values
                foreach (string columnName in row.Data.Keys)
                {
                    if (resultsTable.Columns.Contains(columnName))
                    {
                        newRow[columnName] = row.Data[columnName].Value?.ToString() ?? "NULL";
                    }
                }

                resultsTable.Rows.Add(newRow);
            }

            // Set the DataGridView data source
            dataGridView1.DataSource = resultsTable;

            // Format the DataGridView
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Refresh();

            // Display summary in status bar
            LogStatus($"Preview results: {modifiedRows.Count} differences found ({modifiedRows.Count(r => r.NotExistsInDestination)} inserts, {modifiedRows.Count(r => !r.NotExistsInDestination)} updates)");
        }


        private void LogStatus(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogStatus), text);
                return;
            }

            // If you have a status strip or label, update it here
            lblStatusBar.Text = $"{text}";
        }

        private void LogError(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogError), message);
                return;
            }

            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tableInfo = GetSelectedTableInfo();

            cmbFilterFields.Items.Clear();
            cmbFilterFields.Items.AddRange(tableInfo.Columns.Select(c => c.Name).ToArray());
            cmbFilterFields.SelectedIndex = cmbFilterFields.Items.IndexOf(tableInfo.ColumnKeyName);

        }

        private async void btnApplyChangesToDB_Click(object sender, EventArgs e)
        {
            try
            {
                // Disable the button during execution
                btnApplyChangesToDB.Enabled = false;

                DbConnectionInfo destinationConnectionInfo = new DbConnectionInfo(replicationTaskInfo.ConnectionStringDestination, replicationTaskInfo.DbProviderDestination);

                using DbCon dbDest = DbCon.Create(destinationConnectionInfo);

                //Execute Synchronization
                DbSyncRunner dbSyncRunner = new DbSyncRunner(dbDest, messageHandler);
                dbSyncRunner.OnProgress = delegate (double v, double max)
                {
                    //job.OnProgress(CalcProgress(curMinId, curMaxId, maxId, v, max), 100);
                };

                // Run the sync operation asynchronously
                await Task.Run(() => dbSyncRunner.ExecuteSyncIntoTable(previewResult.ModifiedRows, previewResult.TableDestination));

                MessageBox.Show("Sync complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable the button when done
                btnApplyChangesToDB.Enabled = true;
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            Replicator.AbortReplication = true;

        }
    }
}
