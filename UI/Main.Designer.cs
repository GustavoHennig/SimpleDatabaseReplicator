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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            menuContext = new System.Windows.Forms.ContextMenuStrip(components);
            addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            mniDuplicate = new System.Windows.Forms.ToolStripMenuItem();
            mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolTips = new System.Windows.Forms.ToolTip(components);
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            toolbarMain = new System.Windows.Forms.ToolStrip();
            toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            homepageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            tbtnNewJob = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            btnReplicateAll = new System.Windows.Forms.ToolStripButton();
            btnAbort = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            lvwJobs = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            richTextBoxLog = new System.Windows.Forms.RichTextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            menuContext.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            toolbarMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuContext
            // 
            menuContext.ImageScalingSize = new Size(24, 24);
            menuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { addToolStripMenuItem, editToolStripMenuItem1, mniDuplicate, mniDelete });
            menuContext.Name = "contextMenuStrip1";
            resources.ApplyResources(menuContext, "menuContext");
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            resources.ApplyResources(addToolStripMenuItem, "addToolStripMenuItem");
            addToolStripMenuItem.Click += tbtnNewJob_Click;
            // 
            // editToolStripMenuItem1
            // 
            editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            resources.ApplyResources(editToolStripMenuItem1, "editToolStripMenuItem1");
            editToolStripMenuItem1.Click += btnEdit_Click;
            // 
            // mniDuplicate
            // 
            mniDuplicate.Name = "mniDuplicate";
            resources.ApplyResources(mniDuplicate, "mniDuplicate");
            mniDuplicate.Click += mniDuplicate_Click;
            // 
            // mniDelete
            // 
            mniDelete.Name = "mniDelete";
            resources.ApplyResources(mniDelete, "mniDelete");
            mniDelete.Click += mniDelete_Click;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolTips
            // 
            toolTips.IsBalloon = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(toolbarMain, 0, 0);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // toolbarMain
            // 
            resources.ApplyResources(toolbarMain, "toolbarMain");
            tableLayoutPanel1.SetColumnSpan(toolbarMain, 2);
            toolbarMain.ImageScalingSize = new Size(24, 24);
            toolbarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripDropDownButton1, toolStripSeparator3, tbtnNewJob, btnEdit, toolStripSeparator1, btnReplicateAll, btnAbort, toolStripSeparator2 });
            toolbarMain.Name = "toolbarMain";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { optionsToolStripMenuItem, homepageToolStripMenuItem1, aboutToolStripMenuItem1 });
            resources.ApplyResources(toolStripDropDownButton1, "toolStripDropDownButton1");
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(optionsToolStripMenuItem, "optionsToolStripMenuItem");
            optionsToolStripMenuItem.Click += optionsToolStripMenuItem_Click;
            // 
            // homepageToolStripMenuItem1
            // 
            homepageToolStripMenuItem1.Name = "homepageToolStripMenuItem1";
            resources.ApplyResources(homepageToolStripMenuItem1, "homepageToolStripMenuItem1");
            homepageToolStripMenuItem1.Click += homepageToolStripMenuItem1_Click;
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            resources.ApplyResources(aboutToolStripMenuItem1, "aboutToolStripMenuItem1");
            aboutToolStripMenuItem1.Click += aboutToolStripMenuItem1_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            // 
            // tbtnNewJob
            // 
            tbtnNewJob.Image = Properties.Resources.file_64;
            resources.ApplyResources(tbtnNewJob, "tbtnNewJob");
            tbtnNewJob.Name = "tbtnNewJob";
            tbtnNewJob.Click += tbtnNewJob_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.edit_property_64;
            resources.ApplyResources(btnEdit, "btnEdit");
            btnEdit.Name = "btnEdit";
            btnEdit.Click += btnEdit_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnReplicateAll
            // 
            btnReplicateAll.Image = Properties.Resources.play_64;
            resources.ApplyResources(btnReplicateAll, "btnReplicateAll");
            btnReplicateAll.Name = "btnReplicateAll";
            btnReplicateAll.Click += btnReplicateAll_Click;
            // 
            // btnAbort
            // 
            resources.ApplyResources(btnAbort, "btnAbort");
            btnAbort.Image = Properties.Resources.cancel_64;
            btnAbort.Name = "btnAbort";
            btnAbort.Click += btnAbort_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // splitContainer1
            // 
            resources.ApplyResources(splitContainer1, "splitContainer1");
            tableLayoutPanel1.SetColumnSpan(splitContainer1, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lvwJobs);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(richTextBoxLog);
            tableLayoutPanel1.SetRowSpan(splitContainer1, 2);
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // lvwJobs
            // 
            lvwJobs.CheckBoxes = true;
            lvwJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            lvwJobs.ContextMenuStrip = menuContext;
            resources.ApplyResources(lvwJobs, "lvwJobs");
            lvwJobs.FullRowSelect = true;
            lvwJobs.MultiSelect = false;
            lvwJobs.Name = "lvwJobs";
            lvwJobs.UseCompatibleStateImageBehavior = false;
            lvwJobs.View = System.Windows.Forms.View.Details;
            lvwJobs.ColumnWidthChanged += lvwJobs_ColumnWidthChanged;
            lvwJobs.MouseDoubleClick += lvwJobs_MouseDoubleClick;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(columnHeader3, "columnHeader3");
            // 
            // richTextBoxLog
            // 
            resources.ApplyResources(richTextBoxLog, "richTextBoxLog");
            richTextBoxLog.Name = "richTextBoxLog";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(tableLayoutPanel1);
            Name = "Main";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            menuContext.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            toolbarMain.ResumeLayout(false);
            toolbarMain.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
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
    }
}
