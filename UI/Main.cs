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
using SimpleDatabaseReplicator.DB;
using System.Threading;
using SimpleDatabaseReplicator.UI.Base;
using SimpleDatabaseReplicator.Properties;
using System.Runtime.InteropServices;
using SimpleDatabaseReplicator.Util;

namespace SimpleDatabaseReplicator.UI
{


    public partial class Main : BaseForm
    {

        SynchronizationContext windowsFormsContext;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private const int WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;


        private int Mx, My;
        public Main()
        {
            windowsFormsContext = SynchronizationContext.Current;
            InitializeComponent();

            LoadData();

            timer1.Enabled = true;

        }

        private void btnReplica_Click(object sender, EventArgs e)
        {
            Replicate(SelectetJob);
        }
        /*
        void r_erros(string msg)
        {
            lstErros.Items.Add(msg);
        }

        void r_statuspgb(int pos, int max)
        {

            pbar.Maximum = max;
            pbar.Value = pos;
            Application.DoEvents();
            statusBar.Refresh();

        }

        void r_status(string msg)
        {
            Status = msg;
            Application.DoEvents();
            statusBar.Refresh();
        }
        */





        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }


        private void AddJob()
        {

            ReplicationTaskInfo rti = new ReplicationTaskInfo("");
            EditJob ej = new EditJob(rti);
            ej.ShowDialog();

            if (rti != null)
            {
                AddJobToTheList(rti);
            }
        }


        private void Replicate(ReplicationTaskInfo job)
        {
            Replicator.AbortReplication = false;
            Thread thread = new Thread(() =>
            {
                Replicator rt = new Replicator(new MessageHandler(
                    windowsFormsContext, job, LogStatus, LogError
                    ));
                rt.Replicate(job);

            });
            thread.Name = "Replicator";
            thread.Start();
        }

        private void LogError(string message)
        {
            AppendToRtb(message + "\n", Color.Red);
        }

        private void LogStatus(string text)
        {
            AppendToRtb(text + "\n", Color.Blue);
        }

        public void RefreshControls()
        {
            //foreach (ReplicatingThread rt in Preferences.ReplicatingThreads)
            foreach (ReplicationTaskInfo job in Settings.Default.ReplicationTasks)
            {
                ListViewItem item;
                if (lvwJobs.Items.ContainsKey(job.Uid))
                {
                    item = lvwJobs.Items[job.Uid];
                }
                else
                {
                    item = lvwJobs.Items.Add(job.Uid, job.JobName, 0);
                    item.SubItems.Add(job.Status);
                    item.SubItems.Add(job.PbValue.ToString());
                    /*
                    ListViewBoundPanel xPanel = new ListViewBoundPanel();
                    ProgressBar xProgress = new ProgressBar();

                    xProgress.Dock = DockStyle.Fill;
                    xProgress.Maximum = Convert.ToInt32( rt.PbMax+20);
                    xProgress.Value = Convert.ToInt32( rt.PbValue+10);
                    lvwLog.Controls.Add(xPanel);
                    xPanel.Controls.Add(xProgress);
                    xPanel.OwnerListItem = item;
                    xPanel.CollumnNumber = 1;
                    */
                }
                if (item.SubItems[1].Text != job.Status)
                {
                    item.SubItems[1].Text = job.Status;
                }
                if (job.IsRunning)
                {
                    item.SubItems[2].Text = Convert.ToDouble(job.PbValue * 100 / (job.PbMax + 0.1)).ToString("0.00");
                }
                else if (item.SubItems[2].Text != " -- ")
                {
                    item.SubItems[2].Text = " -- ";
                }
            }

            /*
            for (int i = lvwLog.Items.Count - 1; i >= 0; i--)
            {
                if (!Preferences.ReplicatingThreads.IsRunnig(lvwLog.Items[i].Text))
                {
                    lvwLog.Items[i].SubItems[1].Text = "Stopped";
                }
            }
            */


        }

        private void EditSelectedItem()
        {
            if (lvwJobs.SelectedItems.Count == 1)
            {
                //Job job = (Job)lvwLog.SelectedItems[0].Tag;
                EditJob ej = new EditJob(SelectetJob);
                ej.ShowDialog();
                lvwJobs.SelectedItems[0].Text = SelectetJob.JobName;
            }
        }

        private void LoadData()
        {
            lvwJobs.Items.Clear();

            foreach (ReplicationTaskInfo job in Settings.Default.ReplicationTasks)
            {
                AddJobToTheList(job);
            }
        }

        private void AddJobToTheList(ReplicationTaskInfo job)
        {

            ListViewItem item = lvwJobs.Items.Add(job.Uid, job.JobName, 0);
            item.Tag = job;
            item.SubItems.Add("");
            item.SubItems.Add("0");
            /*
            item.SubItems[1].Text = rt.Status;
            item.SubItems[2].Text = Convert.ToDouble(rt.PbValue * 100 / (rt.PbMax + 0.1)).ToString("0.00");
            */
        }

        private ReplicationTaskInfo SelectetJob
        {
            get
            {
                if (lvwJobs.SelectedItems.Count > 0)
                {
                    return (ReplicationTaskInfo)lvwJobs.SelectedItems[0].Tag;
                }
                else
                {
                    throw new Exception("No item selected");
                }
            }
        }

        private void lvwLog_MouseMove(object sender, MouseEventArgs e)
        {
            Mx = e.X;
            My = e.Y;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Replicator.AbortReplication = true;
            Settings.Save();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void homepageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/GustavoHennig/SimpleDatabaseReplicator");
            }
            catch (Exception)
            {
            }
        }

        private void tbtnNewJob_Click(object sender, EventArgs e)
        {
            AddJob();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void btnReplicateAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvw in lvwJobs.CheckedItems)
            {
                ReplicationTaskInfo job = lvw.Tag as ReplicationTaskInfo;
                Replicate(job);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            Replicator.AbortReplication = true;

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void AppendToRtb(string text, Color color)
        {
            try
            {

                richTextBoxLog.SelectionStart = richTextBoxLog.TextLength;
                richTextBoxLog.SelectionLength = 0;

                richTextBoxLog.SelectionColor = color;
                richTextBoxLog.AppendText(text);
                richTextBoxLog.SelectionColor = richTextBoxLog.ForeColor;
                ScrollToBottom(richTextBoxLog);

                if (richTextBoxLog.TextLength > 32000)
                    richTextBoxLog.Text = richTextBoxLog.Text.Substring(10000);


            }
            catch (Exception)
            {
            }
        }

        private void mniDuplicate_Click(object sender, EventArgs e)
        {
            if (lvwJobs.SelectedItems.Count == 1)
            {
                ListViewItem lvi = lvwJobs.SelectedItems[0].Clone() as ListViewItem;
                lvi.Tag = (lvi.Tag as ReplicationTaskInfo).Clone();
                lvi.Name = (lvi.Tag as ReplicationTaskInfo).Uid;
                lvwJobs.Items.Add(lvi);
                Settings.Default.ReplicationTasks.Add(lvi.Tag as ReplicationTaskInfo);
            }

            Settings.Save();
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {

            for (int i = lvwJobs.SelectedItems.Count - 1; i >= 0; i--)
            {
                var lvi = lvwJobs.SelectedItems[i];
                lvwJobs.Items.Remove(lvi);
                Settings.Default.ReplicationTasks.Remove(lvi.Tag as ReplicationTaskInfo);
            }

            Settings.Save();
        }

        public static void ScrollToBottom(RichTextBox MyRichTextBox)
        {
            SendMessage(MyRichTextBox.Handle, WM_VSCROLL, (IntPtr)SB_PAGEBOTTOM, IntPtr.Zero);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }
    }
}