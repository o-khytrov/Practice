using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader(@"D:\Console.txt"));
            var N = Int32.Parse(Console.ReadLine());
            var A = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
            long a = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                a = a * A[i] % (Convert.ToInt32(Math.Pow(10, 9)) + 7);
            }
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
