using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _006_AsyncAwait_testing
{
    internal class MyClass
    {
        public void Operation()
        {
            Console.WriteLine("Operation ThreadId {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Begin");
            Thread.Sleep(2000);
            Console.WriteLine("End");
        }

        public async void OperationAsync()
        {
            MyClass.AsyncStateMachine stateMachine;
            stateMachine.outer = this;
            stateMachine.builder = AsyncVoidMethodBuilder.Create();
            stateMachine.state = -1;
            stateMachine.builder.Start(ref stateMachine);
        }

        private struct AsyncStateMachine : IAsyncStateMachine
        {
            public int state;
            public AsyncVoidMethodBuilder builder;
            public MyClass outer;
            public TaskAwaiter awaiter;

            public void MoveNext()
            {
                if (state == -1)
                {
                    Console.WriteLine("OperationAsync (Part I) ThreadID {0}\n", Thread.CurrentThread.ManagedThreadId);

                    Task task = new Task(outer.Operation);
                    task.Start();

                    state = 0;
                    TaskAwaiter awaiter = task.GetAwaiter();
                    builder.AwaitOnCompleted(ref awaiter, ref this);
                    return;
                }
                Console.WriteLine("OperationAsync (Part II) ThreadID {0}\n", Thread.CurrentThread.ManagedThreadId);
            }

            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                Console.WriteLine("\nМетод SetStateMachine ThreadID {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("stateMachine.GetHashCode         {0}", stateMachine.GetHashCode());
                Console.WriteLine("this.GetHashCode                 {0}\n", this.GetHashCode());
                this.builder.SetStateMachine(stateMachine);
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Main ThreadID {0}", Thread.CurrentThread.ManagedThreadId);

            var myClass = new MyClass();

            myClass.OperationAsync();

            Console.ReadKey();
        }
    }
}
