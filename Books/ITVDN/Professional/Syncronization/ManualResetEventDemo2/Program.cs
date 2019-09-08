using System;
using System.Threading;

namespace ManualResetEventDemo2
{
    internal class Program
    {
        private static ManualResetEvent manual = new ManualResetEvent(false);

        private static void Function()
        {
            Thread.Sleep(20);
            Console.WriteLine("Запущен поток {0}", Thread.CurrentThread.Name);
            for (int i = 0; i < 80; i++)
            {
                Console.Write(".");
                Thread.Sleep(20);
            }
            Console.WriteLine("\nЗавершен поток {0}", Thread.CurrentThread.Name);
            manual.Set();
        }

        private static void Main(string[] args)
        {
            Thread thread = new Thread(Function) { Name = "1" };
            thread.Start();

            Console.WriteLine("Приостановка выполнения первичного потока");
            manual.WaitOne();

            Console.WriteLine("Первичный поток возобновил работу");

            manual.Reset();

            thread = new Thread(Function) { Name = "2" };
            thread.Start();

            Console.WriteLine("Приостановка выполнения первичного потока");
            manual.WaitOne();

            Console.WriteLine("Первичный поток возобновил и завершил работу");

            Console.ReadKey();
        }
    }
}