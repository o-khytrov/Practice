using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Priority2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key...");
            Console.ReadLine();

            Console.WriteLine("Priority of primary thread by default : {0}", Thread.CurrentThread.Priority);
            var pt = new PriorityTest();
            var threads = new Thread[5];
            for (int i = 0; i < 5; i++)
                threads[i] = new Thread(pt.Method);
            threads[0].Priority = ThreadPriority.Lowest;
            for (int i = 1; i < 5; i++)
            {
                threads[i].Priority = ThreadPriority.Highest;
            }

            threads[0].Start();
            Thread.Sleep(2000);
            for (int i = 1; i < 5; i++)
            {
                threads[i].Start();
            }
            Thread.Sleep(10000);
            Console.WriteLine("Primary thread woke up and stands between hight priority threads");
            pt.stop = true;
            Console.ReadKey();
        }
    }
    class PriorityTest
    {

        public bool stop = false;
        public void Method()
        {
            Console.WriteLine("Thread {0,3} with priority {1,11} started work", Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.Priority);
            long count = 1;
            Func<double, double> fib = null;

            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;
            for (int i = 0; i < 43; i++)
            {
                fib(i);
            }

            Console.WriteLine("Thread {0,3} with priority {1,11} started work. Count = {2,13}", Thread.CurrentThread.ManagedThreadId,
     Thread.CurrentThread.Priority, count.ToString("N0"));
        }

    }
}
