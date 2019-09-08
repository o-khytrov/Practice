using System;
using System.Threading;

namespace Foreground
{
    internal class Program
    {
        private static void Procedure()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
                Console.Write(".");
            }
            Console.WriteLine("\nSecondary thread finished");
        }

        private static void Main(string[] args)
        {
            Console.WriteLine(Environment.ProcessorCount);
            Thread thread = new Thread(Procedure);
            thread.IsBackground = true;
            thread.Start();
            Thread.Sleep(500);
            Console.WriteLine("\nPrimary thread finished");
        }
    }
}