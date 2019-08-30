using System;
using System.Threading;

namespace ThreadSampleJoin
{
    public class Program
    {
        private static void WriteChar(char chr, int count, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(20);
                Console.Write(chr);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Method2()
        {
            Console.WriteLine("\nSecondary thread #{0}", Thread.CurrentThread.GetHashCode());
            WriteChar('2', 80, ConsoleColor.Blue);
            Thread thread = new Thread(Method3);

            thread.Start();
            thread.Join();
            WriteChar('2', 80, ConsoleColor.Blue);
            Console.WriteLine("\nSecondary thread finished");

        }
        static void Method3()
        {
            Console.WriteLine("\nThrird thread #{0}", Thread.CurrentThread.GetHashCode());
            WriteChar('3', 80, ConsoleColor.Yellow);

            Console.WriteLine("\nThrird thread finished");

        }
        private static void Main()
        {
            Console.WriteLine("Primary thread #{0}", Thread.CurrentThread.GetHashCode());
            WriteChar('1', 80, ConsoleColor.Green);

            Thread thread = new Thread(Method2);

            thread.Start();
            thread.Join();
            WriteChar('1', 80, ConsoleColor.Green);
            Console.WriteLine("\nPrimary thread finished");

            Console.ReadKey();
        }
    }
}