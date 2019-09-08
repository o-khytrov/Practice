using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAbort
{
    class Program
    {
        static void Procedure()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            while (true)
            {
                try
                {
                    Thread.Sleep(10);
                    Console.Write(".");
                }
                catch (ThreadAbortException)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThreadAbortException");
                    for (int i = 0; i < 160; i++)
                    {
                        Thread.Sleep(20);
                        Console.Write(".");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Thread.ResetAbort();
                }
            }
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(Procedure);
            thread.Start();
            Thread.Sleep(2000);
            thread.Abort();

            thread.Join();
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                Thread.Sleep(20);
                Console.Write("-");
            }
        }
    }
}
