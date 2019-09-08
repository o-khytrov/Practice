using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor_
{


    class Program
    {
        static object block = new object();
        static int counter;
        static Random random = new Random();

        static void Report()
        {
            while (true)
            {
                int count;
                try
                {
                    Monitor.Enter(block);
                    count = counter;
                }
                finally
                {

                    Monitor.Exit(block);
                }
                Console.WriteLine("{0} threads are active", count);
                Thread.Sleep(100);
            }
        }
        static void Function()
        {
            try
            {
                Monitor.Enter(block);
                counter++;

            }
            finally
            {
                Monitor.Exit(block);
            }
            int wait = random.Next(1000, 12000);
            Thread.Sleep(wait);

            try
            {
                Monitor.Enter(block);
                counter--;

            }
            finally
            {
                Monitor.Exit(block);
            }
        }

        static void Main(string[] args)
        {
            var reporter = new Thread(Report) { IsBackground = true };
            reporter.Start();
            var threads = new Thread[150];
            for (int i = 0; i < 150; i++)
            {
                threads[i] = new Thread(Function);
                threads[i].Start();
            }

            Thread.Sleep(15000);
        }
    }
}
