using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _004_TPL_Wait
{
    class Program
    {
        static void MyTask()
        {
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(25);
                Console.Write(".");
            }
        }

        static void Main(string[] args)
        {
            Task task = new Task(MyTask);
            task.Start();

            Thread.Sleep(500);

            Console.WriteLine("\ntask is completed = " + task.IsCompleted);

            //task.Wait();

            //while (!task.IsCompleted)
            //{
            //    Thread.Sleep(100);
            //}
            IAsyncResult asyncResult = task as IAsyncResult;
            ManualResetEvent waitHanle = asyncResult.AsyncWaitHandle as ManualResetEvent;
            waitHanle.WaitOne();
            Console.WriteLine("\ntask is completed = " + task.IsCompleted);

            Console.ReadKey();
        }

    }
}
