using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Operators
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var d = double.Parse(Console.ReadLine().Trim(), System.Globalization.CultureInfo.InvariantCulture);

            var i = Int32.Parse(Console.ReadLine().Trim());// percentage

            var t = Int32.Parse(Console.ReadLine().Trim());// tax

            var tip = d.Percentage(i);
            var tax = d.Percentage(t);

            Console.WriteLine(Math.Round(d + tip + tax,0));
            Console.ReadKey();
        }

    }
    public static class Extensions
    {
        public static double Percentage(this double d, int percentage)
        {
            return (d / 100 * percentage);
        }
    }
}