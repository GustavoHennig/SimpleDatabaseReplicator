using System.Windows.Forms;

namespace SimpleDatabaseReplicator.UI
{
    partial class ReplicationTableEdit
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
            lstSource = new CheckedListBox();
            txtColumnKey = new TextBox();
            lblColumnKey = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTableName = new Label();
            txtTableName = new TextBox();
            lblColumsList = new Label();
            chkEnableBatchExecution = new CheckBox();
            lblBatch = new Label();
            txtBatchSize = new TextBox();
            btnCancel = new Button();
            btnOk = new Button();
            lnkLoadSchema = new LinkLabel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lstSource
            // 
            lstSource.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(lstSource, 4);
            lstSource.Location = new System.Drawing.Point(9, 108);
            lstSource.Margin = new Padding(9, 9, 9, 9);
            lstSource.Name = "lstSource";
            lstSource.Size = new System.Drawing.Size(807, 760);
            lstSource.TabIndex = 0;
            // 
            // txtColumnKey
            // 
            txtColumnKey.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtColumnKey.Location = new System.Drawing.Point(287, 1006);
            txtColumnKey.Margin = new Padding(9, 9, 9, 9);
            txtColumnKey.Name = "txtColumnKey";
            txtColumnKey.Size = new System.Drawing.Size(214, 31);
            txtColumnKey.TabIndex = 5;
            txtColumnKey.TextChanged += txtColumnKey_TextChanged;
            // 
            // lblColumnKey
            // 
            lblColumnKey.AutoSize = true;
            lblColumnKey.Location = new System.Drawing.Point(9, 1006);
            lblColumnKey.Margin = new Padding(9, 9, 9, 9);
            lblColumnKey.Name = "lblColumnKey";
            lblColumnKey.Size = new System.Drawing.Size(260, 50);
            lblColumnKey.TabIndex = 6;
            lblColumnKey.Text = "Column for range batch\r\n* must be numeric and indexed";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.02985F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.97015F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(lblTableName, 0, 0);
            tableLayoutPanel1.Controls.Add(txtTableName, 1, 0);
            tableLayoutPanel1.Controls.Add(lblColumsList, 0, 1);
            tableLayoutPanel1.Controls.Add(lstSource, 0, 2);
            tableLayoutPanel1.Controls.Add(chkEnableBatchExecution, 0, 3);
            tableLayoutPanel1.Controls.Add(lblBatch, 0, 4);
            tableLayoutPanel1.Controls.Add(txtBatchSize, 1, 4);
            tableLayoutPanel1.Controls.Add(lblColumnKey, 0, 5);
            tableLayoutPanel1.Controls.Add(txtColumnKey, 1, 5);
            tableLayoutPanel1.Controls.Add(btnCancel, 3, 6);
            tableLayoutPanel1.Controls.Add(btnOk, 1, 6);
            tableLayoutPanel1.Controls.Add(lnkLoadSchema, 3, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.Size = new System.Drawing.Size(825, 1156);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // lblTableName
            // 
            lblTableName.AutoSize = true;
            lblTableName.Location = new System.Drawing.Point(9, 22);
            lblTableName.Margin = new Padding(9, 22, 9, 9);
            lblTableName.Name = "lblTableName";
            lblTableName.Size = new System.Drawing.Size(104, 25);
            lblTableName.TabIndex = 10;
            lblTableName.Text = "Table Name";
            // 
            // txtTableName
            // 
            txtTableName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(txtTableName, 3);
            txtTableName.Location = new System.Drawing.Point(287, 22);
            txtTableName.Margin = new Padding(9, 22, 9, 9);
            txtTableName.Name = "txtTableName";
            txtTableName.ReadOnly = true;
            txtTableName.Size = new System.Drawing.Size(529, 31);
            txtTableName.TabIndex = 11;
            // 
            // lblColumsList
            // 
            lblColumsList.AutoSize = true;
            lblColumsList.Location = new System.Drawing.Point(9, 71);
            lblColumsList.Margin = new Padding(9, 9, 9, 3);
            lblColumsList.Name = "lblColumsList";
            lblColumsList.Size = new System.Drawing.Size(82, 25);
            lblColumsList.TabIndex = 0;
            lblColumsList.Text = "Columns";
            // 
            // chkEnableBatchExecution
            // 
            chkEnableBatchExecution.AutoSize = true;
            chkEnableBatchExecution.Location = new System.Drawing.Point(9, 910);
            chkEnableBatchExecution.Margin = new Padding(9, 9, 9, 9);
            chkEnableBatchExecution.Name = "chkEnableBatchExecution";
            chkEnableBatchExecution.Size = new System.Drawing.Size(218, 29);
            chkEnableBatchExecution.TabIndex = 3;
            chkEnableBatchExecution.Text = "Enable Batch Execution";
            chkEnableBatchExecution.UseVisualStyleBackColor = true;
            // 
            // lblBatch
            // 
            lblBatch.AutoSize = true;
            lblBatch.Location = new System.Drawing.Point(9, 957);
            lblBatch.Margin = new Padding(9, 9, 9, 9);
            lblBatch.Name = "lblBatch";
            lblBatch.Size = new System.Drawing.Size(91, 25);
            lblBatch.TabIndex = 12;
            lblBatch.Text = "Batch Size";
            // 
            // txtBatchSize
            // 
            txtBatchSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBatchSize.Location = new System.Drawing.Point(287, 957);
            txtBatchSize.Margin = new Padding(9, 9, 9, 9);
            txtBatchSize.Name = "txtBatchSize";
            txtBatchSize.Size = new System.Drawing.Size(214, 31);
            txtBatchSize.TabIndex = 9;
            txtBatchSize.Text = "20000";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(624, 1076);
            btnCancel.Margin = new Padding(10, 11, 10, 11);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(190, 69);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(btnOk, 2);
            btnOk.Location = new System.Drawing.Point(414, 1076);
            btnOk.Margin = new Padding(10, 11, 10, 11);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(190, 69);
            btnOk.TabIndex = 8;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // lnkLoadSchema
            // 
            lnkLoadSchema.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lnkLoadSchema.AutoSize = true;
            lnkLoadSchema.Location = new System.Drawing.Point(703, 62);
            lnkLoadSchema.Margin = new Padding(4, 0, 4, 0);
            lnkLoadSchema.Name = "lnkLoadSchema";
            lnkLoadSchema.Size = new System.Drawing.Size(118, 25);
            lnkLoadSchema.TabIndex = 13;
            lnkLoadSchema.TabStop = true;
            lnkLoadSchema.Text = "Load Schema";
            lnkLoadSchema.LinkClicked += lnkLoadSchema_LinkClicked;
            // 
            // ReplicationTableEdit
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(825, 1156);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ReplicationTableEdit";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Table Sync Settings";
            Load += GraphicMapping_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox lstSource;
        private System.Windows.Forms.TextBox txtColumnKey;
        private System.Windows.Forms.Label lblColumnKey;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblColumsList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private CheckBox chkEnableBatchExecution;
        private TextBox txtBatchSize;
        private Label lblTableName;
        private TextBox txtTableName;
        private Label lblBatch;
        private LinkLabel lnkLoadSchema;
    }
}