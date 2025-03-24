namespace SimpleDatabaseReplicator.UI
{
    partial class DataPreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataPreview));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripCommands = new System.Windows.Forms.ToolStrip();
            this.cmbTables = new System.Windows.Forms.ToolStripComboBox();
            this.btnRunComparison = new System.Windows.Forms.ToolStripButton();
            this.btnApplyChangesToDB = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStripFilters = new System.Windows.Forms.ToolStrip();
            this.lblFilter = new System.Windows.Forms.ToolStripLabel();
            this.cmbFilterFields = new System.Windows.Forms.ToolStripComboBox();
            this.lblMin = new System.Windows.Forms.ToolStripLabel();
            this.txtFilterMin = new System.Windows.Forms.ToolStripTextBox();
            this.lblMax = new System.Windows.Forms.ToolStripLabel();
            this.txtFilterMax = new System.Windows.Forms.ToolStripTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAbort = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStripCommands.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStripFilters.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1525, 1042);
            this.dataGridView1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1531, 1048);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // toolStripCommands
            // 
            this.toolStripCommands.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.toolStripCommands.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripCommands.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.cmbTables, this.btnRunComparison, this.btnApplyChangesToDB, this.btnAbort });
            this.toolStripCommands.Location = new System.Drawing.Point(4, 33);
            this.toolStripCommands.Name = "toolStripCommands";
            this.toolStripCommands.Size = new System.Drawing.Size(743, 34);
            this.toolStripCommands.TabIndex = 1;
            this.toolStripCommands.Text = "toolStrip1";
            // 
            // cmbTables
            // 
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(260, 34);
            this.cmbTables.Text = "Select Table";
            this.cmbTables.SelectedIndexChanged += this.cmbTables_SelectedIndexChanged;
            // 
            // btnRunComparison
            // 
            this.btnRunComparison.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRunComparison.Image = (System.Drawing.Image)resources.GetObject("btnRunComparison.Image");
            this.btnRunComparison.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunComparison.Name = "btnRunComparison";
            this.btnRunComparison.Size = new System.Drawing.Size(146, 29);
            this.btnRunComparison.Text = "Run comparison";
            this.btnRunComparison.Click += this.btnRunComparison_Click;
            // 
            // btnApplyChangesToDB
            // 
            this.btnApplyChangesToDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnApplyChangesToDB.Image = (System.Drawing.Image)resources.GetObject("btnApplyChangesToDB.Image");
            this.btnApplyChangesToDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApplyChangesToDB.Name = "btnApplyChangesToDB";
            this.btnApplyChangesToDB.Size = new System.Drawing.Size(183, 29);
            this.btnApplyChangesToDB.Text = "Apply changes to DB";
            this.btnApplyChangesToDB.Click += this.btnApplyChangesToDB_Click;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatusBar });
            this.statusStrip1.Location = new System.Drawing.Point(0, 1121);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(41, 32);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(24, 25);
            this.lblStatusBar.Text = "...";
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            this.tableLayoutPanel2.SetColumnSpan(this.toolStripContainer1, 2);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1531, 1048);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(3, 3);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1531, 1115);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripCommands);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripFilters);
            // 
            // toolStripFilters
            // 
            this.toolStripFilters.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripFilters.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripFilters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblFilter, this.cmbFilterFields, this.lblMin, this.txtFilterMin, this.lblMax, this.txtFilterMax });
            this.toolStripFilters.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripFilters.Location = new System.Drawing.Point(4, 0);
            this.toolStripFilters.Name = "toolStripFilters";
            this.toolStripFilters.Size = new System.Drawing.Size(635, 33);
            this.toolStripFilters.TabIndex = 2;
            // 
            // lblFilter
            // 
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(50, 28);
            this.lblFilter.Text = "Filter";
            // 
            // cmbFilterFields
            // 
            this.cmbFilterFields.AutoSize = false;
            this.cmbFilterFields.Name = "cmbFilterFields";
            this.cmbFilterFields.Size = new System.Drawing.Size(260, 33);
            // 
            // lblMin
            // 
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(46, 28);
            this.lblMin.Text = "Min:";
            // 
            // txtFilterMin
            // 
            this.txtFilterMin.Name = "txtFilterMin";
            this.txtFilterMin.Size = new System.Drawing.Size(100, 33);
            // 
            // lblMax
            // 
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(49, 28);
            this.lblMax.Text = "Max:";
            // 
            // txtFilterMax
            // 
            this.txtFilterMax.Name = "txtFilterMax";
            this.txtFilterMax.Size = new System.Drawing.Size(100, 33);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.toolStripContainer1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.statusStrip1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1537, 1153);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnAbort
            // 
            this.btnAbort.Enabled = false;
            this.btnAbort.Image = Properties.Resources.cancel_64;
            this.btnAbort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(86, 29);
            this.btnAbort.Text = "Abort";
            this.btnAbort.Click += this.btnAbort_Click;
            // 
            // DataPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1537, 1153);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "DataPreview";
            this.Text = "Preview Diff Changes";
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStripCommands.ResumeLayout(false);
            this.toolStripCommands.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStripFilters.ResumeLayout(false);
            this.toolStripFilters.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStripCommands;
        private System.Windows.Forms.ToolStripButton btnRunComparison;
        private System.Windows.Forms.ToolStripButton btnApplyChangesToDB;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBar;
        private System.Windows.Forms.ToolStripComboBox cmbTables;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStripFilters;
        private System.Windows.Forms.ToolStripTextBox txtFilterMin;
        private System.Windows.Forms.ToolStripTextBox txtFilterMax;
        private System.Windows.Forms.ToolStripLabel lblFilter;
        private System.Windows.Forms.ToolStripComboBox cmbFilterFields;
        private System.Windows.Forms.ToolStripLabel lblMin;
        private System.Windows.Forms.ToolStripLabel lblMax;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripButton btnAbort;
    }
}