using System.Windows.Forms;

namespace SimpleDatabaseReplicator.UI
{
    partial class EditJob
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditJob));
            this.tabPages = new System.Windows.Forms.TabControl();
            this.tabConnections = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpOrigem = new System.Windows.Forms.GroupBox();
            this.btnTestConnSource = new System.Windows.Forms.Button();
            this.cmdSource = new System.Windows.Forms.ComboBox();
            this.txtStringSource = new System.Windows.Forms.TextBox();
            this.lblSgbd1 = new System.Windows.Forms.Label();
            this.lblConnString1 = new System.Windows.Forms.Label();
            this.grpDestination = new System.Windows.Forms.GroupBox();
            this.btnTestConnDest = new System.Windows.Forms.Button();
            this.cmdDest = new System.Windows.Forms.ComboBox();
            this.txtStringDestination = new System.Windows.Forms.TextBox();
            this.lblSgbd2 = new System.Windows.Forms.Label();
            this.lblConnString2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabTables = new System.Windows.Forms.TabPage();
            this.lstTables = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnUnselect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.lnkRetrieveTables = new System.Windows.Forms.LinkLabel();
            this.btnGraphMapping = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabExceptions = new System.Windows.Forms.TabPage();
            this.grp = new System.Windows.Forms.GroupBox();
            this.btnRemoveField = new System.Windows.Forms.Button();
            this.btnAddField = new System.Windows.Forms.Button();
            this.txtEditField = new System.Windows.Forms.TextBox();
            this.lstExFields = new System.Windows.Forms.ListBox();
            this.tabErrors = new System.Windows.Forms.TabPage();
            this.btnLimparErros = new System.Windows.Forms.Button();
            this.lstErros = new System.Windows.Forms.ListBox();
            this.tabOthers = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPostUpdate = new System.Windows.Forms.TextBox();
            this.txtIgnoreCondition = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.lblJobName = new System.Windows.Forms.Label();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPages.SuspendLayout();
            this.tabConnections.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpOrigem.SuspendLayout();
            this.grpDestination.SuspendLayout();
            this.tabTables.SuspendLayout();
            this.tabExceptions.SuspendLayout();
            this.grp.SuspendLayout();
            this.tabErrors.SuspendLayout();
            this.tabOthers.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPages
            // 
            resources.ApplyResources(this.tabPages, "tabPages");
            this.tableLayoutPanel2.SetColumnSpan(this.tabPages, 3);
            this.tabPages.Controls.Add(this.tabConnections);
            this.tabPages.Controls.Add(this.tabTables);
            this.tabPages.Controls.Add(this.tabExceptions);
            this.tabPages.Controls.Add(this.tabErrors);
            this.tabPages.Controls.Add(this.tabOthers);
            this.tabPages.Name = "tabPages";
            this.tabPages.SelectedIndex = 0;
            // 
            // tabConnections
            // 
            this.tabConnections.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.tabConnections, "tabConnections");
            this.tabConnections.Name = "tabConnections";
            this.tabConnections.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.grpOrigem, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpDestination, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.linkLabel1, 0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // grpOrigem
            // 
            resources.ApplyResources(this.grpOrigem, "grpOrigem");
            this.grpOrigem.Controls.Add(this.btnTestConnSource);
            this.grpOrigem.Controls.Add(this.cmdSource);
            this.grpOrigem.Controls.Add(this.txtStringSource);
            this.grpOrigem.Controls.Add(this.lblSgbd1);
            this.grpOrigem.Controls.Add(this.lblConnString1);
            this.grpOrigem.Name = "grpOrigem";
            this.grpOrigem.TabStop = false;
            // 
            // btnTestConnSource
            // 
            resources.ApplyResources(this.btnTestConnSource, "btnTestConnSource");
            this.btnTestConnSource.Name = "btnTestConnSource";
            this.btnTestConnSource.UseVisualStyleBackColor = true;
            this.btnTestConnSource.Click += new System.EventHandler(this.btnTestConnSource_Click);
            // 
            // cmdSource
            // 
            resources.ApplyResources(this.cmdSource, "cmdSource");
            this.cmdSource.BackColor = System.Drawing.Color.Linen;
            this.cmdSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdSource.FormattingEnabled = true;
            this.cmdSource.Name = "cmdSource";
            // 
            // txtStringSource
            // 
            resources.ApplyResources(this.txtStringSource, "txtStringSource");
            this.txtStringSource.BackColor = System.Drawing.Color.Linen;
            this.txtStringSource.Name = "txtStringSource";
            // 
            // lblSgbd1
            // 
            resources.ApplyResources(this.lblSgbd1, "lblSgbd1");
            this.lblSgbd1.Name = "lblSgbd1";
            // 
            // lblConnString1
            // 
            resources.ApplyResources(this.lblConnString1, "lblConnString1");
            this.lblConnString1.Name = "lblConnString1";
            // 
            // grpDestination
            // 
            resources.ApplyResources(this.grpDestination, "grpDestination");
            this.grpDestination.Controls.Add(this.btnTestConnDest);
            this.grpDestination.Controls.Add(this.cmdDest);
            this.grpDestination.Controls.Add(this.txtStringDestination);
            this.grpDestination.Controls.Add(this.lblSgbd2);
            this.grpDestination.Controls.Add(this.lblConnString2);
            this.grpDestination.Name = "grpDestination";
            this.grpDestination.TabStop = false;
            // 
            // btnTestConnDest
            // 
            resources.ApplyResources(this.btnTestConnDest, "btnTestConnDest");
            this.btnTestConnDest.Name = "btnTestConnDest";
            this.btnTestConnDest.UseVisualStyleBackColor = true;
            this.btnTestConnDest.Click += new System.EventHandler(this.btnTestConnDest_Click);
            // 
            // cmdDest
            // 
            resources.ApplyResources(this.cmdDest, "cmdDest");
            this.cmdDest.BackColor = System.Drawing.Color.Linen;
            this.cmdDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdDest.FormattingEnabled = true;
            this.cmdDest.Name = "cmdDest";
            // 
            // txtStringDestination
            // 
            resources.ApplyResources(this.txtStringDestination, "txtStringDestination");
            this.txtStringDestination.BackColor = System.Drawing.Color.Linen;
            this.txtStringDestination.Name = "txtStringDestination";
            // 
            // lblSgbd2
            // 
            resources.ApplyResources(this.lblSgbd2, "lblSgbd2");
            this.lblSgbd2.Name = "lblSgbd2";
            // 
            // lblConnString2
            // 
            resources.ApplyResources(this.lblConnString2, "lblConnString2");
            this.lblConnString2.Name = "lblConnString2";
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tabTables
            // 
            this.tabTables.Controls.Add(this.lstTables);
            this.tabTables.Controls.Add(this.btnMoveDown);
            this.tabTables.Controls.Add(this.btnMoveUp);
            this.tabTables.Controls.Add(this.btnUnselect);
            this.tabTables.Controls.Add(this.btnSelectAll);
            this.tabTables.Controls.Add(this.lnkRetrieveTables);
            this.tabTables.Controls.Add(this.btnGraphMapping);
            this.tabTables.Controls.Add(this.btnRemove);
            this.tabTables.Controls.Add(this.btnAdd);
            resources.ApplyResources(this.tabTables, "tabTables");
            this.tabTables.Name = "tabTables";
            this.tabTables.UseVisualStyleBackColor = true;
            // 
            // lstTables
            // 
            this.lstTables.CheckBoxes = true;
            this.lstTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstTables.FullRowSelect = true;
            resources.ApplyResources(this.lstTables, "lstTables");
            this.lstTables.Name = "lstTables";
            this.lstTables.UseCompatibleStateImageBehavior = false;
            this.lstTables.View = System.Windows.Forms.View.Details;
            this.lstTables.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstTables_ItemChecked);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // btnMoveDown
            // 
            resources.ApplyResources(this.btnMoveDown, "btnMoveDown");
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            resources.ApplyResources(this.btnMoveUp, "btnMoveUp");
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnUnselect
            // 
            resources.ApplyResources(this.btnUnselect, "btnUnselect");
            this.btnUnselect.Name = "btnUnselect";
            this.btnUnselect.UseVisualStyleBackColor = true;
            this.btnUnselect.Click += new System.EventHandler(this.btnUnselect_Click);
            // 
            // btnSelectAll
            // 
            resources.ApplyResources(this.btnSelectAll, "btnSelectAll");
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // lnkRetrieveTables
            // 
            resources.ApplyResources(this.lnkRetrieveTables, "lnkRetrieveTables");
            this.lnkRetrieveTables.Name = "lnkRetrieveTables";
            this.lnkRetrieveTables.TabStop = true;
            this.lnkRetrieveTables.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRetrieveTables_LinkClicked);
            // 
            // btnGraphMapping
            // 
            resources.ApplyResources(this.btnGraphMapping, "btnGraphMapping");
            this.btnGraphMapping.Name = "btnGraphMapping";
            this.btnGraphMapping.UseVisualStyleBackColor = true;
            this.btnGraphMapping.Click += new System.EventHandler(this.btnGraphMapping_Click);
            // 
            // btnRemove
            // 
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabExceptions
            // 
            this.tabExceptions.Controls.Add(this.grp);
            resources.ApplyResources(this.tabExceptions, "tabExceptions");
            this.tabExceptions.Name = "tabExceptions";
            this.tabExceptions.UseVisualStyleBackColor = true;
            // 
            // grp
            // 
            resources.ApplyResources(this.grp, "grp");
            this.grp.Controls.Add(this.btnRemoveField);
            this.grp.Controls.Add(this.btnAddField);
            this.grp.Controls.Add(this.txtEditField);
            this.grp.Controls.Add(this.lstExFields);
            this.grp.Name = "grp";
            this.grp.TabStop = false;
            // 
            // btnRemoveField
            // 
            resources.ApplyResources(this.btnRemoveField, "btnRemoveField");
            this.btnRemoveField.Name = "btnRemoveField";
            this.btnRemoveField.UseVisualStyleBackColor = true;
            this.btnRemoveField.Click += new System.EventHandler(this.btnRemoveField_Click);
            // 
            // btnAddField
            // 
            resources.ApplyResources(this.btnAddField, "btnAddField");
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.UseVisualStyleBackColor = true;
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click);
            // 
            // txtEditField
            // 
            this.txtEditField.BackColor = System.Drawing.Color.Linen;
            resources.ApplyResources(this.txtEditField, "txtEditField");
            this.txtEditField.Name = "txtEditField";
            // 
            // lstExFields
            // 
            resources.ApplyResources(this.lstExFields, "lstExFields");
            this.lstExFields.FormattingEnabled = true;
            this.lstExFields.Name = "lstExFields";
            // 
            // tabErrors
            // 
            this.tabErrors.Controls.Add(this.btnLimparErros);
            this.tabErrors.Controls.Add(this.lstErros);
            resources.ApplyResources(this.tabErrors, "tabErrors");
            this.tabErrors.Name = "tabErrors";
            this.tabErrors.UseVisualStyleBackColor = true;
            // 
            // btnLimparErros
            // 
            resources.ApplyResources(this.btnLimparErros, "btnLimparErros");
            this.btnLimparErros.Name = "btnLimparErros";
            this.btnLimparErros.UseVisualStyleBackColor = true;
            this.btnLimparErros.Click += new System.EventHandler(this.btnLimparErros_Click);
            // 
            // lstErros
            // 
            resources.ApplyResources(this.lstErros, "lstErros");
            this.lstErros.FormattingEnabled = true;
            this.lstErros.Name = "lstErros";
            // 
            // tabOthers
            // 
            this.tabOthers.Controls.Add(this.label5);
            this.tabOthers.Controls.Add(this.label6);
            this.tabOthers.Controls.Add(this.txtPostUpdate);
            this.tabOthers.Controls.Add(this.txtIgnoreCondition);
            resources.ApplyResources(this.tabOthers, "tabOthers");
            this.tabOthers.Name = "tabOthers";
            this.tabOthers.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtPostUpdate
            // 
            resources.ApplyResources(this.txtPostUpdate, "txtPostUpdate");
            this.txtPostUpdate.Name = "txtPostUpdate";
            this.toolTips.SetToolTip(this.txtPostUpdate, resources.GetString("txtPostUpdate.ToolTip"));
            // 
            // txtIgnoreCondition
            // 
            resources.ApplyResources(this.txtIgnoreCondition, "txtIgnoreCondition");
            this.txtIgnoreCondition.Name = "txtIgnoreCondition";
            this.toolTips.SetToolTip(this.txtIgnoreCondition, resources.GetString("txtIgnoreCondition.ToolTip"));
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtJobName
            // 
            resources.ApplyResources(this.txtJobName, "txtJobName");
            this.txtJobName.Name = "txtJobName";
            // 
            // lblJobName
            // 
            resources.ApplyResources(this.lblJobName, "lblJobName");
            this.lblJobName.Name = "lblJobName";
            // 
            // toolTips
            // 
            this.toolTips.IsBalloon = true;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.btnOk, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblJobName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancelar, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtJobName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tabPages, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // EditJob
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "EditJob";
            this.tabPages.ResumeLayout(false);
            this.tabConnections.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpOrigem.ResumeLayout(false);
            this.grpOrigem.PerformLayout();
            this.grpDestination.ResumeLayout(false);
            this.grpDestination.PerformLayout();
            this.tabTables.ResumeLayout(false);
            this.tabTables.PerformLayout();
            this.tabExceptions.ResumeLayout(false);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.tabErrors.ResumeLayout(false);
            this.tabOthers.ResumeLayout(false);
            this.tabOthers.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

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
        private ColumnHeader columnHeader1;
        private Button btnTestConnSource;
        private Button btnTestConnDest;
        private TableLayoutPanel tableLayoutPanel2;
    }
}