using System;
using System.Threading;

namespace Threads
{
    internal class Program
    {
        private static void Function()
        {
            Console.WriteLine("Id of secondary thread {0}", Thread.CurrentThread.ManagedThreadId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 160; i++)
            {
                Thread.Sleep(20);
                Console.Write(".");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Secondary thread finished");
        }

        private static void Main()
        {
            Console.WriteLine("Id of primary thread {0}", Thread.CurrentThread.ManagedThreadId);

            Thread thread = new Thread(Function);
            thread.Start();

            thread.Join();

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 160; i++)
            {
                Thread.Sleep(20);
                Console.Write("-");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Secondary thread finished");
            Console.ReadKey();
        }
    }
}