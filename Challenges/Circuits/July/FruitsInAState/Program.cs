using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FruitsInAState
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));


            Console.ReadKey();
        }
    }
}