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
using System.Text;
using System.IO;
using System.Windows.Forms;
using SimpleDatabaseReplicator.UI;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace SimpleDatabaseReplicator
{
    class Program
    {
        static void Main(string[] args)
        {

            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            tzi.GetAdjustmentRules();

            Preferences.Load();

            if (args.Length > 0)
            {
                //Command line example: SimpleDatabaseReplicator.exe "sqlserver to postgres"
                var job = Preferences.Settings.jobs.FirstOrDefault(w => w.JobName == args[0]);
                if (job != null)
                {
                    SynchronousSynchronizationContext sync = new SynchronousSynchronizationContext();
                    Replicator r = new Replicator(new MessageHandler(
                        sync,
                        job, msg => Console.WriteLine(msg), msg => Console.WriteLine(msg)
                        ));
                    r.Replicate(job);
                    return;
                }
                else
                {
                    MessageBox.Show("Replication task not found");

                }
            }

            Application.Run(new Main());
        }




    class SynchronousSynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            this.Send(d, state);
        }
    }
}
}
