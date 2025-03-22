using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleDatabaseReplicator
{
    public class MessageHandler
    {


        public delegate void TaskProgress(double value, double max);
        public delegate void TaskEvent(string message);

        private TaskEvent OnStatusUI;
        private TaskEvent OnErrorUI;
        private SynchronizationContext windowsFormsContext;

        public MessageHandler(SynchronizationContext windowsFormsContext, TaskEvent onStatusUI, TaskEvent onErrorUI)
        {
            this.OnStatusUI = onStatusUI;
            this.OnErrorUI = onErrorUI;
            this.windowsFormsContext = windowsFormsContext;
        }

        public void SendError(string msg, ReplicationTaskInfo source)
        {
            source?.Errors.Add(msg);
            windowsFormsContext.Post((state) =>
            {
                OnErrorUI(msg);
            }, null);
        }

        public void SendStatus(string msg, ReplicationTaskInfo source, bool newLine = false)
        {
            if (source != null)
            {
                source.Status = msg;
                source.StatusLog.Add(msg);
            }
            windowsFormsContext.Post((state) =>
            {
                OnStatusUI(msg + (newLine ? "\n" :""));
            }, null);
        }


    }
}
