using System;
using System.Threading;

namespace SemaphoreDemo
{
    internal class Program
    {
        private static Semaphore pool;

        private static void Function(object number)
        {
            pool.WaitOne();
            Console.WriteLine("Thread {0} occupied slot of semaphore", number);
            Thread.Sleep(2000);
            Console.WriteLine("Thread {0} ------> left the slot", number);

            pool.Release();
        }

        private static void Main(string[] args)
        {
            pool = new Semaphore(5, 5, "MySemaphore");


            for (int i = 1; i <= 40; i++)
            {
                new Thread(Function).Start(i);
                Thread.Sleep(500);
            }
            Console.ReadKey();
        }
    }
}