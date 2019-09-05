using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace _011_AsyncAwait_Continuation_DotPeek
{
    internal class MyClass
    {
        public void Operation()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Основная задача");
        }

        public Task OperationAsync()
        {
            AsyncStateMachine stateMachine;
            stateMachine.outer = this;
            stateMachine.builder = AsyncTaskMethodBuilder.Create();
            stateMachine.state = -1;
            stateMachine.builder.Start(ref stateMachine);
            return stateMachine.builder.Task;
        }

        private struct AsyncStateMachine : IAsyncStateMachine
        {
            public AsyncTaskMethodBuilder builder;
            public MyClass outer;
            public int state;
            private TaskAwaiter awaiter;

            public void MoveNext()
            {
                if (state == -1)
                {
                    awaiter = Task.Factory.StartNew(outer.Operation).GetAwaiter();
                    state = 0;
                    builder.AwaitOnCompleted(ref awaiter, ref this);
                    return;
                }
                //задача помечается как успешно выполненная
                //тогда срабатывает продолжение
                builder.SetResult();
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
            Task task = my.OperationAsync();
            task.ContinueWith(t => Console.WriteLine("\nПродолжение задачи."));
            Console.WriteLine("Первичный поток завершил работу. ThreadID {0}", Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }
    }
}