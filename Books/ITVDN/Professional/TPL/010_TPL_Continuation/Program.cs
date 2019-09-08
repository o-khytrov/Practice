using System;
using System.Threading;
using System.Threading.Tasks;

namespace _010_TPL_Continuation
{
    internal class Program
    {
        private static void MyTask()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write(".");
            }
        }

        private static void ContinuationTask()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write("-");
            }
        }

        private static void Main(string[] args)
        {
            var task = new Task(MyTask);

            var continuationTask = task.ContinueWith(t => ContinuationTask());

            task.Start();

            Console.ReadKey();
        }
    }
}