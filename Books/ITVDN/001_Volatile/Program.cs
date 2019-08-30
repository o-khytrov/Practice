using System;
using System.Threading;

namespace _001_Volatile
{
    internal class Program
    {
        private static bool stop;

        private static void Main(string[] args)
        {
            Thread thread = new Thread(Function);
            thread.Start();

            Thread.Sleep(2000);

            stop = true;
            Console.WriteLine("Main waiting for secondary thread.");
            thread.Join();
        }

        private static void Function()
        {
            int x = 0;
            while (!stop)
            {
                x++;
            }
            Console.WriteLine("Function thread stopped x={0}", x);
        }
    }
}