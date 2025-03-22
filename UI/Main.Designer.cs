/*
 * HS Replicator - Gustavo Augusto Hennig
 * http://code.google.com/p/hsreplicator/
 *  
 * "The contents of this file are subject to the Mozilla Public License
 * Version 1.1 (the "License"); you may not use this file except in
 * compliance with the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 * 
 * Software distributed under the License is distributed on an "AS IS"
 * basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
 * License for the specific language governing rights and limitations
 * under the License.
 * The Initial Developer of the Original Code is Gustavo Augusto Hennig.
 */

using System.Drawing;
namespace SimpleDatabaseReplicator.UI
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDuplicate = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolbarMain = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homepageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnNewJob = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReplicateAll = new System.Windows.Forms.ToolStripButton();
            this.btnAbort = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvwJobs = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuContext.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolbarMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuContext
            // 
            this.menuContext.ImageScalingSize = new Size(24, 24);
            this.menuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.addToolStripMenuItem, this.editToolStripMenuItem1, this.mniDuplicate, this.mniDelete });
            this.menuContext.Name = "contextMenuStrip1";
            resources.ApplyResources(this.menuContext, "menuContext");
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            resources.ApplyResources(this.addToolStripMenuItem, "addToolStripMenuItem");
            this.addToolStripMenuItem.Click += this.tbtnNewJob_Click;
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            resources.ApplyResources(this.editToolStripMenuItem1, "editToolStripMenuItem1");
            this.editToolStripMenuItem1.Click += this.btnEdit_Click;
            // 
            // mniDuplicate
            // 
            this.mniDuplicate.Name = "mniDuplicate";
            resources.ApplyResources(this.mniDuplicate, "mniDuplicate");
            this.mniDuplicate.Click += this.mniDuplicate_Click;
            // 
            // mniDelete
            // 
            this.mniDelete.Name = "mniDelete";
            resources.ApplyResources(this.mniDelete, "mniDelete");
            this.mniDelete.Click += this.mniDelete_Click;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolTips
            // 
            this.toolTips.IsBalloon = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.toolbarMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // toolbarMain
            // 
            resources.ApplyResources(this.toolbarMain, "toolbarMain");
            this.tableLayoutPanel1.SetColumnSpan(this.toolbarMain, 2);
            this.toolbarMain.ImageScalingSize = new Size(24, 24);
            this.toolbarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripDropDownButton1, this.toolStripSeparator3, this.tbtnNewJob, this.btnEdit, this.toolStripSeparator1, this.btnReplicateAll, this.btnAbort, this.toolStripSeparator2, this.btnPreview });
            this.toolbarMain.Name = "toolbarMain";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.optionsToolStripMenuItem, this.homepageToolStripMenuItem1, this.aboutToolStripMenuItem1 });
            resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Click += this.optionsToolStripMenuItem_Click;
            // 
            // homepageToolStripMenuItem1
            // 
            this.homepageToolStripMenuItem1.Name = "homepageToolStripMenuItem1";
            resources.ApplyResources(this.homepageToolStripMenuItem1, "homepageToolStripMenuItem1");
            this.homepageToolStripMenuItem1.Click += this.homepageToolStripMenuItem1_Click;
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            resources.ApplyResources(this.aboutToolStripMenuItem1, "aboutToolStripMenuItem1");
            this.aboutToolStripMenuItem1.Click += this.aboutToolStripMenuItem1_Click;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // tbtnNewJob
            // 
            this.tbtnNewJob.Image = Properties.Resources.file_64;
            resources.ApplyResources(this.tbtnNewJob, "tbtnNewJob");
            this.tbtnNewJob.Name = "tbtnNewJob";
            this.tbtnNewJob.Click += this.tbtnNewJob_Click;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = Properties.Resources.edit_property_64;
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Click += this.btnEdit_Click;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnReplicateAll
            // 
            this.btnReplicateAll.Image = Properties.Resources.play_64;
            resources.ApplyResources(this.btnReplicateAll, "btnReplicateAll");
            this.btnReplicateAll.Name = "btnReplicateAll";
            this.btnReplicateAll.Click += this.btnReplicateAll_Click;
            // 
            // btnAbort
            // 
            resources.ApplyResources(this.btnAbort, "btnAbort");
            this.btnAbort.Image = Properties.Resources.cancel_64;
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Click += this.btnAbort_Click;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // btnPreview
            // 
            this.btnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnPreview, "btnPreview");
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Click += this.btnPreview_Click;
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainer1, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvwJobs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxLog);
            this.tableLayoutPanel1.SetRowSpan(this.splitContainer1, 2);
            this.splitContainer1.SplitterMoved += this.splitContainer1_SplitterMoved;
            // 
            // lvwJobs
            // 
            this.lvwJobs.CheckBoxes = true;
            this.lvwJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeader1, this.columnHeader2, this.columnHeader3 });
            this.lvwJobs.ContextMenuStrip = this.menuContext;
            resources.ApplyResources(this.lvwJobs, "lvwJobs");
            this.lvwJobs.FullRowSelect = true;
            this.lvwJobs.MultiSelect = false;
            this.lvwJobs.Name = "lvwJobs";
            this.lvwJobs.UseCompatibleStateImageBehavior = false;
            this.lvwJobs.View = System.Windows.Forms.View.Details;
            this.lvwJobs.ColumnWidthChanged += this.lvwJobs_ColumnWidthChanged;
            this.lvwJobs.MouseDoubleClick += this.lvwJobs_MouseDoubleClick;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // richTextBoxLog
            // 
            resources.ApplyResources(this.richTextBoxLog, "richTextBoxLog");
            this.richTextBoxLog.Name = "richTextBoxLog";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += this.timer1_Tick;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.FormClosing += this.Main_FormClosing;
            this.Load += this.Main_Load;
            this.menuContext.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolbarMain.ResumeLayout(false);
            this.toolbarMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
        }



        #endregion
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniDelete;
        private System.Windows.Forms.ToolStripMenuItem mniDuplicate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolbarMain;
        private System.Windows.Forms.ToolStripButton tbtnNewJob;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnReplicateAll;
        private System.Windows.Forms.ToolStripButton btnAbort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem homepageToolStripMenuItem1;
        private System.Windows.Forms.ListView lvwJobs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.ContextMenuStrip menuContext;
        private System.Windows.Forms.ToolStripButton btnPreview;
    }
}
