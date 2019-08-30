using System;
using System.Threading;

namespace MutexSample
{
    internal class Program
    {
        private static Mutex mutex = new Mutex(false, "MyMutex");

        private static void Main(string[] args)
        {
            Thread[] threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(Function);
                threads[i].Name = i.ToString();

                threads[i].Start();
            }
            Console.ReadKey();
        }

        private static void Function()
        {
            mutex.WaitOne();
            Console.WriteLine("Thread {0} entered in protected area", Thread.CurrentThread.Name);
            Thread.Sleep(2000);
            Console.WriteLine("Thread {0} left in protected area\n", Thread.CurrentThread.Name);
            mutex.ReleaseMutex();
        }
    }
}