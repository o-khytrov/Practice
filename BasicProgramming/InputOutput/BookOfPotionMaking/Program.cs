using System;
using System.IO;
using System.Linq;

namespace BookOfPotionMaking
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var s = Console.ReadLine();
            var legal = true;
            var sum = 0;
            int c = 1;
            if (s.Length != 10)
            {
                legal = false;
            }
            if (legal)
            {
                var A = s.ToCharArray().Select(x => Int32.Parse(x.ToString())).ToArray();
                for (int i = 0; i < A.Length; i++)
                {
                    sum = sum + A[i] * c;
                    c++;
                }
            }
            if (sum % 11 != 0)
            {
                legal = false;
            }

            var message = legal ? "Legal ISBN" : "Illegal ISBN";
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}