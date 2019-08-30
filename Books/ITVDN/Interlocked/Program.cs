using System;
using System.Threading;

namespace Interlocked
{
    internal class Program
    {
        private static long counter;
        private static object block = new object();

        private static void Procedure()
        {
            for (int i = 0; i < 1000000; i++)
            {
                lock (block)
                {
                    counter++;
                }
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Expected value of counter = 1000000");
            Thread[] threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(Procedure);
                threads[i].Start();
            }
            for (int i = 0; i < 5; i++)
            {
                threads[i].Join();
            }
            Console.WriteLine("Real value of counter = {0}", counter);
            Console.ReadKey();
        }
    }
}