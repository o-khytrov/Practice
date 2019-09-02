using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace _000_AsyncResultImplementation
{
    public class Message : IMessage
    {
        IDictionary dictionary;

        public IDictionary Properties { get { return dictionary; } }

        public Message(WaitCallback asyncTask, AsyncCallback callback, object @object)
        {
            dictionary = new Hashtable();
            dictionary.Add("asyncTask", asyncTask);
            dictionary.Add("asyncCallback", callback);
            dictionary.Add("asyncState", @object);
        }



    }
}
