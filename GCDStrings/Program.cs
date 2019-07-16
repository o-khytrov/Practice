using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDStrings
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
                var x = A[0];
                var y = A[1];
            }
        }
    }
}
