using System.Windows.Forms;

namespace SimpleDatabaseReplicator.UI
{
    partial class ReplicationTaskEdit
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplicationTaskEdit));
            tabPages = new TabControl();
            tabConnections = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            grpOrigem = new GroupBox();
            btnTestConnSource = new Button();
            cmdSource = new ComboBox();
            txtStringSource = new TextBox();
            lblSgbd1 = new Label();
            lblConnString1 = new Label();
            grpDestination = new GroupBox();
            btnTestConnDest = new Button();
            cmdDest = new ComboBox();
            txtStringDestination = new TextBox();
            lblSgbd2 = new Label();
            lblConnString2 = new Label();
            linkLabel1 = new LinkLabel();
            tabTables = new TabPage();
            tableLayoutPanel3 = new TableLayoutPanel();
            lnkRetrieveTables = new LinkLabel();
            btnSelectAll = new Button();
            btnMoveDown = new Button();
            btnUnselect = new Button();
            btnMoveUp = new Button();
            btnAdd = new Button();
            btnRemove = new Button();
            btnGraphMapping = new Button();
            txtTableFilter = new TextBox();
            lblTableFilter = new Label();
            lstTables = new ListView();
            columnTableSource = new ColumnHeader();
            columnTableDestination = new ColumnHeader();
            tabExceptions = new TabPage();
            grp = new GroupBox();
            btnRemoveField = new Button();
            btnAddField = new Button();
            txtEditField = new TextBox();
            lstExFields = new ListBox();
            tabErrors = new TabPage();
            btnLimparErros = new Button();
            lstErros = new ListBox();
            tabOthers = new TabPage();
            label5 = new Label();
            label6 = new Label();
            txtPostUpdate = new TextBox();
            txtIgnoreCondition = new TextBox();
            btnOk = new Button();
            btnCancelar = new Button();
            txtJobName = new TextBox();
            lblJobName = new Label();
            toolTips = new ToolTip(components);
            tableLayoutPanel2 = new TableLayoutPanel();
            tabPages.SuspendLayout();
            tabConnections.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            grpOrigem.SuspendLayout();
            grpDestination.SuspendLayout();
            tabTables.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tabExceptions.SuspendLayout();
            grp.SuspendLayout();
            tabErrors.SuspendLayout();
            tabOthers.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tabPages
            // 
            resources.ApplyResources(tabPages, "tabPages");
            tableLayoutPanel2.SetColumnSpan(tabPages, 3);
            tabPages.Controls.Add(tabConnections);
            tabPages.Controls.Add(tabTables);
            tabPages.Controls.Add(tabExceptions);
            tabPages.Controls.Add(tabErrors);
            tabPages.Controls.Add(tabOthers);
            tabPages.Name = "tabPages";
            tabPages.SelectedIndex = 0;
            // 
            // tabConnections
            // 
            tabConnections.Controls.Add(tableLayoutPanel1);
            resources.ApplyResources(tabConnections, "tabConnections");
            tabConnections.Name = "tabConnections";
            tabConnections.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(grpOrigem, 0, 0);
            tableLayoutPanel1.Controls.Add(grpDestination, 0, 1);
            tableLayoutPanel1.Controls.Add(linkLabel1, 0, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // grpOrigem
            // 
            resources.ApplyResources(grpOrigem, "grpOrigem");
            grpOrigem.Controls.Add(btnTestConnSource);
            grpOrigem.Controls.Add(cmdSource);
            grpOrigem.Controls.Add(txtStringSource);
            grpOrigem.Controls.Add(lblSgbd1);
            grpOrigem.Controls.Add(lblConnString1);
            grpOrigem.Name = "grpOrigem";
            grpOrigem.TabStop = false;
            // 
            // btnTestConnSource
            // 
            resources.ApplyResources(btnTestConnSource, "btnTestConnSource");
            btnTestConnSource.Name = "btnTestConnSource";
            btnTestConnSource.UseVisualStyleBackColor = true;
            btnTestConnSource.Click += btnTestConnSource_Click;
            // 
            // cmdSource
            // 
            resources.ApplyResources(cmdSource, "cmdSource");
            cmdSource.BackColor = System.Drawing.Color.Linen;
            cmdSource.DropDownStyle = ComboBoxStyle.DropDownList;
            cmdSource.FormattingEnabled = true;
            cmdSource.Name = "cmdSource";
            // 
            // txtStringSource
            // 
            resources.ApplyResources(txtStringSource, "txtStringSource");
            txtStringSource.BackColor = System.Drawing.Color.Linen;
            txtStringSource.Name = "txtStringSource";
            // 
            // lblSgbd1
            // 
            resources.ApplyResources(lblSgbd1, "lblSgbd1");
            lblSgbd1.Name = "lblSgbd1";
            // 
            // lblConnString1
            // 
            resources.ApplyResources(lblConnString1, "lblConnString1");
            lblConnString1.Name = "lblConnString1";
            // 
            // grpDestination
            // 
            resources.ApplyResources(grpDestination, "grpDestination");
            grpDestination.Controls.Add(btnTestConnDest);
            grpDestination.Controls.Add(cmdDest);
            grpDestination.Controls.Add(txtStringDestination);
            grpDestination.Controls.Add(lblSgbd2);
            grpDestination.Controls.Add(lblConnString2);
            grpDestination.Name = "grpDestination";
            grpDestination.TabStop = false;
            // 
            // btnTestConnDest
            // 
            resources.ApplyResources(btnTestConnDest, "btnTestConnDest");
            btnTestConnDest.Name = "btnTestConnDest";
            btnTestConnDest.UseVisualStyleBackColor = true;
            btnTestConnDest.Click += btnTestConnDest_Click;
            // 
            // cmdDest
            // 
            resources.ApplyResources(cmdDest, "cmdDest");
            cmdDest.BackColor = System.Drawing.Color.Linen;
            cmdDest.DropDownStyle = ComboBoxStyle.DropDownList;
            cmdDest.FormattingEnabled = true;
            cmdDest.Name = "cmdDest";
            // 
            // txtStringDestination
            // 
            resources.ApplyResources(txtStringDestination, "txtStringDestination");
            txtStringDestination.BackColor = System.Drawing.Color.Linen;
            txtStringDestination.Name = "txtStringDestination";
            // 
            // lblSgbd2
            // 
            resources.ApplyResources(lblSgbd2, "lblSgbd2");
            lblSgbd2.Name = "lblSgbd2";
            // 
            // lblConnString2
            // 
            resources.ApplyResources(lblConnString2, "lblConnString2");
            lblConnString2.Name = "lblConnString2";
            // 
            // linkLabel1
            // 
            resources.ApplyResources(linkLabel1, "linkLabel1");
            linkLabel1.Name = "linkLabel1";
            linkLabel1.TabStop = true;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // tabTables
            // 
            tabTables.Controls.Add(tableLayoutPanel3);
            resources.ApplyResources(tabTables, "tabTables");
            tabTables.Name = "tabTables";
            tabTables.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(tableLayoutPanel3, "tableLayoutPanel3");
            tableLayoutPanel3.Controls.Add(lnkRetrieveTables, 2, 0);
            tableLayoutPanel3.Controls.Add(btnSelectAll, 2, 1);
            tableLayoutPanel3.Controls.Add(btnMoveDown, 2, 7);
            tableLayoutPanel3.Controls.Add(btnUnselect, 2, 2);
            tableLayoutPanel3.Controls.Add(btnMoveUp, 2, 6);
            tableLayoutPanel3.Controls.Add(btnAdd, 2, 3);
            tableLayoutPanel3.Controls.Add(btnRemove, 2, 5);
            tableLayoutPanel3.Controls.Add(btnGraphMapping, 2, 4);
            tableLayoutPanel3.Controls.Add(txtTableFilter, 1, 0);
            tableLayoutPanel3.Controls.Add(lblTableFilter, 0, 0);
            tableLayoutPanel3.Controls.Add(lstTables, 0, 1);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // lnkRetrieveTables
            // 
            resources.ApplyResources(lnkRetrieveTables, "lnkRetrieveTables");
            lnkRetrieveTables.Name = "lnkRetrieveTables";
            lnkRetrieveTables.TabStop = true;
            lnkRetrieveTables.LinkClicked += lnkRetrieveTables_LinkClicked;
            // 
            // btnSelectAll
            // 
            resources.ApplyResources(btnSelectAll, "btnSelectAll");
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.UseVisualStyleBackColor = true;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // btnMoveDown
            // 
            resources.ApplyResources(btnMoveDown, "btnMoveDown");
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.UseVisualStyleBackColor = true;
            btnMoveDown.Click += btnMoveDown_Click;
            // 
            // btnUnselect
            // 
            resources.ApplyResources(btnUnselect, "btnUnselect");
            btnUnselect.Name = "btnUnselect";
            btnUnselect.UseVisualStyleBackColor = true;
            btnUnselect.Click += btnUnselect_Click;
            // 
            // btnMoveUp
            // 
            resources.ApplyResources(btnMoveUp, "btnMoveUp");
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.UseVisualStyleBackColor = true;
            btnMoveUp.Click += btnMoveUp_Click;
            // 
            // btnAdd
            // 
            resources.ApplyResources(btnAdd, "btnAdd");
            btnAdd.Name = "btnAdd";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            resources.ApplyResources(btnRemove, "btnRemove");
            btnRemove.Name = "btnRemove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnGraphMapping
            // 
            resources.ApplyResources(btnGraphMapping, "btnGraphMapping");
            btnGraphMapping.Name = "btnGraphMapping";
            btnGraphMapping.UseVisualStyleBackColor = true;
            btnGraphMapping.Click += btnGraphMapping_Click;
            // 
            // txtTableFilter
            // 
            resources.ApplyResources(txtTableFilter, "txtTableFilter");
            txtTableFilter.Name = "txtTableFilter";
            txtTableFilter.TextChanged += txtTableFilter_TextChanged;
            // 
            // lblTableFilter
            // 
            resources.ApplyResources(lblTableFilter, "lblTableFilter");
            lblTableFilter.Name = "lblTableFilter";
            // 
            // lstTables
            // 
            resources.ApplyResources(lstTables, "lstTables");
            lstTables.CheckBoxes = true;
            lstTables.Columns.AddRange(new ColumnHeader[] { columnTableSource, columnTableDestination });
            tableLayoutPanel3.SetColumnSpan(lstTables, 2);
            lstTables.FullRowSelect = true;
            lstTables.Name = "lstTables";
            tableLayoutPanel3.SetRowSpan(lstTables, 7);
            lstTables.UseCompatibleStateImageBehavior = false;
            lstTables.View = View.Details;
            lstTables.ItemChecked += lstTables_ItemChecked;
            lstTables.MouseDoubleClick += lstTables_MouseDoubleClick;
            // 
            // columnTableSource
            // 
            resources.ApplyResources(columnTableSource, "columnTableSource");
            // 
            // columnTableDestination
            // 
            resources.ApplyResources(columnTableDestination, "columnTableDestination");
            // 
            // tabExceptions
            // 
            tabExceptions.Controls.Add(grp);
            resources.ApplyResources(tabExceptions, "tabExceptions");
            tabExceptions.Name = "tabExceptions";
            tabExceptions.UseVisualStyleBackColor = true;
            // 
            // grp
            // 
            resources.ApplyResources(grp, "grp");
            grp.Controls.Add(btnRemoveField);
            grp.Controls.Add(btnAddField);
            grp.Controls.Add(txtEditField);
            grp.Controls.Add(lstExFields);
            grp.Name = "grp";
            grp.TabStop = false;
            // 
            // btnRemoveField
            // 
            resources.ApplyResources(btnRemoveField, "btnRemoveField");
            btnRemoveField.Name = "btnRemoveField";
            btnRemoveField.UseVisualStyleBackColor = true;
            btnRemoveField.Click += btnRemoveField_Click;
            // 
            // btnAddField
            // 
            resources.ApplyResources(btnAddField, "btnAddField");
            btnAddField.Name = "btnAddField";
            btnAddField.UseVisualStyleBackColor = true;
            btnAddField.Click += btnAddField_Click;
            // 
            // txtEditField
            // 
            txtEditField.BackColor = System.Drawing.Color.Linen;
            resources.ApplyResources(txtEditField, "txtEditField");
            txtEditField.Name = "txtEditField";
            // 
            // lstExFields
            // 
            resources.ApplyResources(lstExFields, "lstExFields");
            lstExFields.FormattingEnabled = true;
            lstExFields.Name = "lstExFields";
            // 
            // tabErrors
            // 
            tabErrors.Controls.Add(btnLimparErros);
            tabErrors.Controls.Add(lstErros);
            resources.ApplyResources(tabErrors, "tabErrors");
            tabErrors.Name = "tabErrors";
            tabErrors.UseVisualStyleBackColor = true;
            // 
            // btnLimparErros
            // 
            resources.ApplyResources(btnLimparErros, "btnLimparErros");
            btnLimparErros.Name = "btnLimparErros";
            btnLimparErros.UseVisualStyleBackColor = true;
            btnLimparErros.Click += btnLimparErros_Click;
            // 
            // lstErros
            // 
            resources.ApplyResources(lstErros, "lstErros");
            lstErros.FormattingEnabled = true;
            lstErros.Name = "lstErros";
            // 
            // tabOthers
            // 
            tabOthers.Controls.Add(label5);
            tabOthers.Controls.Add(label6);
            tabOthers.Controls.Add(txtPostUpdate);
            tabOthers.Controls.Add(txtIgnoreCondition);
            resources.ApplyResources(tabOthers, "tabOthers");
            tabOthers.Name = "tabOthers";
            tabOthers.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // txtPostUpdate
            // 
            resources.ApplyResources(txtPostUpdate, "txtPostUpdate");
            txtPostUpdate.Name = "txtPostUpdate";
            toolTips.SetToolTip(txtPostUpdate, resources.GetString("txtPostUpdate.ToolTip"));
            // 
            // txtIgnoreCondition
            // 
            resources.ApplyResources(txtIgnoreCondition, "txtIgnoreCondition");
            txtIgnoreCondition.Name = "txtIgnoreCondition";
            toolTips.SetToolTip(txtIgnoreCondition, resources.GetString("txtIgnoreCondition.ToolTip"));
            // 
            // btnOk
            // 
            resources.ApplyResources(btnOk, "btnOk");
            btnOk.Name = "btnOk";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancelar
            // 
            resources.ApplyResources(btnCancelar, "btnCancelar");
            btnCancelar.Name = "btnCancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtJobName
            // 
            resources.ApplyResources(txtJobName, "txtJobName");
            txtJobName.Name = "txtJobName";
            // 
            // lblJobName
            // 
            resources.ApplyResources(lblJobName, "lblJobName");
            lblJobName.Name = "lblJobName";
            // 
            // toolTips
            // 
            toolTips.IsBalloon = true;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(tableLayoutPanel2, "tableLayoutPanel2");
            tableLayoutPanel2.Controls.Add(btnOk, 1, 2);
            tableLayoutPanel2.Controls.Add(lblJobName, 0, 0);
            tableLayoutPanel2.Controls.Add(btnCancelar, 2, 2);
            tableLayoutPanel2.Controls.Add(txtJobName, 1, 0);
            tableLayoutPanel2.Controls.Add(tabPages, 0, 1);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // ReplicationTaskEdit
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(tableLayoutPanel2);
            Name = "ReplicationTaskEdit";
            tabPages.ResumeLayout(false);
            tabConnections.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            grpOrigem.ResumeLayout(false);
            grpOrigem.PerformLayout();
            grpDestination.ResumeLayout(false);
            grpDestination.PerformLayout();
            tabTables.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tabExceptions.ResumeLayout(false);
            grp.ResumeLayout(false);
            grp.PerformLayout();
            tabErrors.ResumeLayout(false);
            tabOthers.ResumeLayout(false);
            tabOthers.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabPages;
        private System.Windows.Forms.TabPage tabConnections;
        private System.Windows.Forms.GroupBox grpDestination;
        private ComboBox cmdDest;
        private TextBox txtStringDestination;
        private System.Windows.Forms.Label lblSgbd2;
        private System.Windows.Forms.Label lblConnString2;
        private System.Windows.Forms.GroupBox grpOrigem;
        private ComboBox cmdSource;
        private TextBox txtStringSource;
        private System.Windows.Forms.Label lblSgbd1;
        private System.Windows.Forms.Label lblConnString1;
        private System.Windows.Forms.TabPage tabTables;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabPage tabExceptions;
        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Button btnRemoveField;
        private System.Windows.Forms.Button btnAddField;
        private TextBox txtEditField;
        private System.Windows.Forms.ListBox lstExFields;
        private System.Windows.Forms.TabPage tabErrors;
        private System.Windows.Forms.Button btnLimparErros;
        private System.Windows.Forms.ListBox lstErros;
        private System.Windows.Forms.TabPage tabOthers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPostUpdate;
        private System.Windows.Forms.TextBox txtIgnoreCondition;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnGraphMapping;
        private System.Windows.Forms.LinkLabel lnkRetrieveTables;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnUnselect;
        private ListView lstTables;
        private Button btnMoveDown;
        private Button btnMoveUp;
        private TableLayoutPanel tableLayoutPanel1;
        private ColumnHeader columnTableSource;
        private Button btnTestConnSource;
        private Button btnTestConnDest;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox txtTableFilter;
        private Label lblTableFilter;
        private ColumnHeader columnTableDestination;
    }
}