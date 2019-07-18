using System;
using System.IO;

namespace Hello
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            Console.WriteLine("Hello Kirti");
        }
    }
}