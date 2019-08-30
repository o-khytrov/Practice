using System;
using System.Threading;

namespace ManualResetEventDemo
{
    internal class Program
    {
        private static ManualResetEventSlim manual = new ManualResetEventSlim(false);

        private static void Main(string[] args)
        {
            new Thread(Function1).Start();
            new Thread(Function2).Start();

            Thread.Sleep(500);
            Console.WriteLine("Press any key to set ManualResetEvent into signal state");
            Console.ReadKey();
            manual.Set();
            Console.ReadKey();
        }

        private static void Function1()
        {
            Console.WriteLine("Thread 1 is launched and is waiting for a signal");
            manual.Wait();
            Console.WriteLine("Thread 1 is finished");
        }

        private static void Function2()
        {
            Console.WriteLine("Thread 2 is launched and is waiting for a signal");
            manual.Wait();
            Console.WriteLine("Thread 2 is finished");
        }
    }
}