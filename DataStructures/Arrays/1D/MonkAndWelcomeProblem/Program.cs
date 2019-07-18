using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkAndWelcomeProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine().Trim());

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

            var B = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var C = new int[N];

            for (int i = 0; i < N; i++)
            {
                C[i] = A[i] + B[i];
            }
            Console.WriteLine(string.Join(" ", C));
            Console.ReadKey();
        }
    }
}
