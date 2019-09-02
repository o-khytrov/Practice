using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _000_AsyncResultImplementation
{
    public class AsyncResult : IAsyncResult, IMessageSink
    {
        IMessage message;

        WaitCallback asyncTask;
        AsyncCallback asyncCallback;
        object asyncState;
        ManualResetEvent waitHandle;
        bool isCompleted;
        public bool isInvokeAsyncCallback;

        #region IAsyncResult implementation
        public object AsyncState { get { return asyncState; } }

        public bool CompletedSynchronously { get { return false; } }

        public WaitHandle AsyncWaitHandle { get { return waitHandle; } }

        public bool IsCompleted { get { return isCompleted; } }
        #endregion


        #region IMessageSink Implementation


        public IMessageSink NextSink => throw new NotImplementedException();


        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            throw new NotImplementedException();
        }

        public IMessage SyncProcessMessage(IMessage msg)
        {
            this.message = msg;
            asyncTask = (WaitCallback)message.Properties["asyncTask"];
            asyncCallback = (AsyncCallback)message.Properties["asyncCallback"];
            asyncState = message.Properties["asyncState"];
            waitHandle = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(AsyncTask, this);
            return message;
        }

        void AsyncTask(object asyncResult)
        {
            if (asyncTask != null)
            {
                asyncTask.Invoke(null);
            }
            if (asyncCallback != null)
            {
                isInvokeAsyncCallback = true;
                asyncCallback.Invoke(this);
            }
            waitHandle.Set();
            isCompleted = true;
        }

        #endregion
    }
}
