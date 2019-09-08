using System;
using System.Threading;

namespace ThreadPool_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Start of the program");
            Report();


            ThreadPool.QueueUserWorkItem(Task1);
            Report();

            ThreadPool.QueueUserWorkItem(new WaitCallback(Task2));
            Report();

            Thread.Sleep(3000);
            Console.WriteLine("Finish of program");
            Report();
            Console.ReadKey();

        }

        private static void Task1(Object state)
        {
            Thread.CurrentThread.Name = "1";
            Console.WriteLine("Thread {0} started\n", Thread.CurrentThread.Name);
            Thread.Sleep(2000);
            Console.WriteLine("Thread {0} finished work\n", Thread.CurrentThread.Name);
        }

        private static void Task2(Object state)
        {
            Thread.CurrentThread.Name = "2";
            Console.WriteLine("Thread {0}\n", Thread.CurrentThread.Name);
            Thread.Sleep(500);
            Console.WriteLine("Thread {0} finished work\n", Thread.CurrentThread.Name);
        }

        private static void Report()
        {
            Thread.Sleep(200);
            int availableWorkThreads, availableIOThreads, maxWorkThreads, maxIOThreads;
            ThreadPool.GetAvailableThreads(out availableWorkThreads, out availableIOThreads);
            ThreadPool.GetMaxThreads(out maxWorkThreads, out maxIOThreads);

            Console.WriteLine("Work threads available    {0} from {1}", availableWorkThreads, maxWorkThreads);
            Console.WriteLine("IO threads available      {0} from {1}", availableIOThreads, maxIOThreads);
        }
    }
}