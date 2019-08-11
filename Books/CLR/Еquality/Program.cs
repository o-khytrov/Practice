using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Еquality
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Profit() { Amount = 1000, Description = "Q1" };
            var p2 = new Profit() { Amount = 1000, Description = "Q2" };

            Console.WriteLine(p1.CompareTo(p2));
            Console.WriteLine(p1 > p2);
            Console.WriteLine(p2 < p1);
            Console.WriteLine(p2 <= p1);
            Console.ReadKey();
        }

    }
}
