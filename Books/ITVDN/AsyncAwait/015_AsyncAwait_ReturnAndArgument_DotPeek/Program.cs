using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _015_AsyncAwait_ReturnAndArgument_DotPeek
{
    internal class MyClass
    {
        private double Operation(object argument)
        {
            Thread.Sleep(2000);
            return (double)argument * (double)argument;
        }

        public Task<double> OperationAsync(double argument)
        {
            AsyncStateMachine stateMachine;
            stateMachine.outer = this;
            stateMachine.argument = argument;
            stateMachine.state = -1;
            stateMachine.builder = AsyncTaskMethodBuilder<double>.Create();

            stateMachine.builder.Start(ref stateMachine);

            return stateMachine.builder.Task;

        }

        struct AsyncStateMachine : IAsyncStateMachine
        {
            public MyClass outer;
            public int state;
            public AsyncTaskMethodBuilder<double> builder;
            public double argument;

            TaskAwaiter<double> awaiter;

            public void MoveNext()
            {
                if (state == -1)
                {
                    Func<object, double> function = outer.Operation;
                    Task<double> task = Task<double>.Factory.StartNew(function, argument);
                    awaiter = task.GetAwaiter();
                    state = 0;
                    builder.AwaitOnCompleted(ref awaiter, ref this);
                    return;

                }

                double result = awaiter.GetResult();
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
            var task = my.OperationAsync(2);
            task.ContinueWith(t => Console.WriteLine("Результат {0}", t.Result));
            Console.ReadKey();
        }
    }
}
