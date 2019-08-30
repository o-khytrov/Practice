using System;
using System.Threading;

namespace EventWaitHandleNs
{
    internal class Program
    {
        private static AutoResetEvent auto = new AutoResetEvent(false);

        private static void Main(string[] args)
        {
            Thread thread = new Thread(Function);
            thread.Start();

            Thread.Sleep(500);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to set AutoResetEvent into signal state");
            Console.ReadKey();
            auto.Set();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to set AutoResetEvent into signal state");
            Console.ReadKey();
            auto.Set();

            Console.ReadKey();
        }

        private static void Function()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Red");
            auto.WaitOne();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Yellow");
            auto.WaitOne();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Green");
        }
    }
}