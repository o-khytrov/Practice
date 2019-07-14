using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var A = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                var N = A[0];
                var M = A[1];
                if (M % N == 0)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
            Console.ReadKey();
        }
    }
}
