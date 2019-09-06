using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace _013_AsyncAwait
{
    internal class MyClass
    {
        private int Operation()
        {
            Thread.Sleep(2000);
            return 2 + 2;
        }

        public Task<int> OperationAsync()
        {
            AsyncStateMachine stateMachine;
            stateMachine.outer = this;
            stateMachine.state = -1;
            stateMachine.builder = AsyncTaskMethodBuilder<int>.Create();
            stateMachine.builder.Start(ref stateMachine);
            return stateMachine.builder.Task;
        }

        private struct AsyncStateMachine : IAsyncStateMachine
        {
            public AsyncTaskMethodBuilder<int> builder;
            public MyClass outer;
            public int state;
            private TaskAwaiter<int> awaiter;

            public void MoveNext()
            {
                if (state == -1)
                {
                    Func<int> function = outer.Operation;
                    Task<int> task = Task<int>.Factory.StartNew(function);
                    awaiter = task.GetAwaiter();
                    state = 0;
                    builder.AwaitOnCompleted(ref awaiter, ref this);
                    return;
                }
                int result = awaiter.GetResult();
                builder.SetResult(result);
            }

            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                builder.SetStateMachine(stateMachine);
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            MyClass my = new MyClass();
            Task<int> task = my.OperationAsync();
            task.ContinueWith(t => Console.WriteLine("Результат {0}", t.Result));
            Console.ReadKey();
        }
    }
}