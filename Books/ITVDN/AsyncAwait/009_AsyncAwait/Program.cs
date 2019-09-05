using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _009_AsyncAwait
{
    class Program
    {
        class MyClass
        {
            int Operation()
            {
                Console.WriteLine("Операция выполняется в потоке ThreadID {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
                return 2 + 2;
            }

            public async void OperationsAsync()
            {
                AsyncStateMachine stateMachine;
                stateMachine.outer = this;
                stateMachine.builder = AsyncVoidMethodBuilder.Create();
                stateMachine.state = -1;
                stateMachine.builder.Start(ref stateMachine);

            }

            struct AsyncStateMachine : IAsyncStateMachine
            {
                public MyClass outer;

                public AsyncVoidMethodBuilder builder;
                public int state;
                TaskAwaiter<int> awaiter;

                public void MoveNext()
                {
                    if (state == -1)
                    {
                        Func<int> function = outer.Operation;
                        Task<int> task = Task<int>.Factory.StartNew(function);
                        state = 0
;
                        awaiter = task.GetAwaiter();

                        builder.AwaitOnCompleted(ref awaiter, ref this);
                        return;
                    }
                    int result = awaiter.GetResult();
                    Console.WriteLine("\nРезультат {0}, ThreadID {1}\n", result, Thread.CurrentThread.ManagedThreadId);
                }

                public void SetStateMachine(IAsyncStateMachine stateMachine)
                {
                    builder.SetStateMachine(stateMachine);
                }
            }
        }

        static void Main(string[] args)
        {
            MyClass my = new MyClass();
            my.OperationsAsync();
            Console.WriteLine("Первичный поток завершил работу. ThreadID {0}", Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();

        }
    }
}
