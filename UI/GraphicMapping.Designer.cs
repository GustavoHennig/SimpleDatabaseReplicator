using System.Windows.Forms;

namespace SimpleDatabaseReplicator.UI
{
    partial class GraphicMapping
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
            this.lstSource = new System.Windows.Forms.CheckedListBox();
            this.txtColumnKey = new System.Windows.Forms.TextBox();
            this.lblColumnKey = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblColumsList = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkEnableBatchExecution = new System.Windows.Forms.CheckBox();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.lblTableName = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.lblBatch = new System.Windows.Forms.Label();
            this.lnkLoadSchema = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSource
            // 
            this.lstSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.lstSource, 4);
            this.lstSource.Location = new System.Drawing.Point(8, 90);
            this.lstSource.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.lstSource.Name = "lstSource";
            this.lstSource.Size = new System.Drawing.Size(663, 655);
            this.lstSource.TabIndex = 0;
            // 
            // txtColumnKey
            // 
            this.txtColumnKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColumnKey.Location = new System.Drawing.Point(229, 857);
            this.txtColumnKey.Margin = new System.Windows.Forms.Padding(8);
            this.txtColumnKey.Name = "txtColumnKey";
            this.txtColumnKey.Size = new System.Drawing.Size(169, 26);
            this.txtColumnKey.TabIndex = 5;
            this.txtColumnKey.TextChanged += new System.EventHandler(this.txtColumnKey_TextChanged);
            // 
            // lblColumnKey
            // 
            this.lblColumnKey.AutoSize = true;
            this.lblColumnKey.Location = new System.Drawing.Point(8, 857);
            this.lblColumnKey.Margin = new System.Windows.Forms.Padding(8);
            this.lblColumnKey.Name = "lblColumnKey";
            this.lblColumnKey.Size = new System.Drawing.Size(149, 20);
            this.lblColumnKey.TabIndex = 6;
            this.lblColumnKey.Text = "Column Primary Key";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.02985F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.97015F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblTableName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTableName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblColumsList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstSource, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkEnableBatchExecution, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblBatch, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtBatchSize, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblColumnKey, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtColumnKey, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lnkLoadSchema, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(679, 964);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lblColumsList
            // 
            this.lblColumsList.AutoSize = true;
            this.lblColumsList.Location = new System.Drawing.Point(8, 60);
            this.lblColumsList.Margin = new System.Windows.Forms.Padding(8, 8, 8, 2);
            this.lblColumsList.Name = "lblColumsList";
            this.lblColumsList.Size = new System.Drawing.Size(71, 20);
            this.lblColumsList.TabIndex = 0;
            this.lblColumsList.Text = "Columns";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(498, 900);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(171, 55);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnOk, 2);
            this.btnOk.Location = new System.Drawing.Point(309, 900);
            this.btnOk.Margin = new System.Windows.Forms.Padding(9);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(171, 55);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkEnableBatchExecution
            // 
            this.chkEnableBatchExecution.AutoSize = true;
            this.chkEnableBatchExecution.Location = new System.Drawing.Point(8, 775);
            this.chkEnableBatchExecution.Margin = new System.Windows.Forms.Padding(8);
            this.chkEnableBatchExecution.Name = "chkEnableBatchExecution";
            this.chkEnableBatchExecution.Size = new System.Drawing.Size(205, 24);
            this.chkEnableBatchExecution.TabIndex = 3;
            this.chkEnableBatchExecution.Text = "Enable Batch Execution";
            this.chkEnableBatchExecution.UseVisualStyleBackColor = true;
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchSize.Location = new System.Drawing.Point(229, 815);
            this.txtBatchSize.Margin = new System.Windows.Forms.Padding(8);
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.Size = new System.Drawing.Size(169, 26);
            this.txtBatchSize.TabIndex = 9;
            this.txtBatchSize.Text = "20000";
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(8, 18);
            this.lblTableName.Margin = new System.Windows.Forms.Padding(8, 18, 8, 8);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(94, 20);
            this.lblTableName.TabIndex = 10;
            this.lblTableName.Text = "Table Name";
            // 
            // txtTableName
            // 
            this.txtTableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTableName.Location = new System.Drawing.Point(229, 18);
            this.txtTableName.Margin = new System.Windows.Forms.Padding(8, 18, 8, 8);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(169, 26);
            this.txtTableName.TabIndex = 11;
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Location = new System.Drawing.Point(8, 815);
            this.lblBatch.Margin = new System.Windows.Forms.Padding(8);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(86, 20);
            this.lblBatch.TabIndex = 12;
            this.lblBatch.Text = "Batch Size";
            // 
            // lnkLoadSchema
            // 
            this.lnkLoadSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkLoadSchema.AutoSize = true;
            this.lnkLoadSchema.Location = new System.Drawing.Point(568, 52);
            this.lnkLoadSchema.Name = "lnkLoadSchema";
            this.lnkLoadSchema.Size = new System.Drawing.Size(108, 20);
            this.lnkLoadSchema.TabIndex = 13;
            this.lnkLoadSchema.TabStop = true;
            this.lnkLoadSchema.Text = "Load Schema";
            this.lnkLoadSchema.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLoadSchema_LinkClicked);
            // 
            // GraphicMapping
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(679, 964);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GraphicMapping";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Table Sync Settings";
            this.Load += new System.EventHandler(this.GraphicMapping_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

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