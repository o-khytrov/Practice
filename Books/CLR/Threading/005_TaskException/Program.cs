using System;
using System.Threading;
using System.Threading.Tasks;

namespace _005_TaskException
{
    internal class Program
    {
        private static Int32 Sum(CancellationToken ct, Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
            {
                Console.WriteLine(sum);
                Thread.Sleep(20);
                // The following line throws OperationCanceledException when Cancel
                // is called on the CancellationTokenSource referred to by the token
                if (ct.IsCancellationRequested)
                {
                    return sum;
                }
                checked { sum += n; } // if n is large, this will throw System.OverflowException
            }
            return sum;
        }

        //private static int Sum(int n)
        //{
        //    Int32 sum = 0;
        //    for (; n > 0; n--)
        //    {
        //        checked { sum += n; }
        //        Console.Write(sum + " ");
        //        Thread.Sleep(20);
        //    }

        //    return sum;
        //}

        private static void Main(string[] args)
        {
            var source = new CancellationTokenSource();

            Task<int> t = new Task<int>(n => Sum(source.Token, (int)n), 500);

            TaskScheduler.UnobservedTaskException += OnTaskEerror;
            t.Start();
        Waiting:
            var k = Console.ReadKey();
            if (k.KeyChar.ToString().ToLower() == "c")
            {
                source.Cancel();
            }
            if (t.IsCompleted)
            {
                Console.WriteLine("!!!Completed!!!!");
                Console.WriteLine("Result {0}", t.Result);
            }
            else
            {
                Console.WriteLine("task is not completed");
                goto Waiting;
            }
        }

        private static void OnTaskEerror(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
        }
    }
}