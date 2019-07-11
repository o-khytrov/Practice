using System;
using System.IO;
using System.Linq;

namespace RoyAndProfilePicture
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var L = Int32.Parse(Console.ReadLine());
            var N = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var A = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                var W = A[0];
                var H = A[1];
                if (W < L || H < L)
                {
                    Console.WriteLine("UPLOAD ANOTHER");
                }
                else if (H == W)
                {
                    Console.WriteLine("ACCEPTED");
                }
                else
                {
                    Console.WriteLine("CROP IT");
                }
            }
            Console.ReadKey();
        }
    }
}