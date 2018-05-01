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
        private ReplicationTaskInfo source;

        public MessageHandler(SynchronizationContext windowsFormsContext, ReplicationTaskInfo source, TaskEvent onStatusUI, TaskEvent onErrorUI)
        {
            this.OnStatusUI = onStatusUI;
            this.OnErrorUI = onErrorUI;
            this.windowsFormsContext = windowsFormsContext;
            this.source = source;
        }

        public void SendError(string msg)
        {
            source.Errors.Add(msg);
            windowsFormsContext.Post((state) =>
            {
                OnErrorUI(msg);
            }, null);
        }

        public void SendStatus(string msg)
        {
            source.Status = msg;
            source.StatusLog.Add(msg);
            windowsFormsContext.Post((state) =>
            {
                
                OnStatusUI(msg);
            }, null);
        }


    }
}
