using System.IO;

namespace TheCastleGate
{
    using System;

    internal class Program
    {
        //Tap the gates as many times as there are unordered pairs
        //of distinct integers from 1 to N whose bit-wise XOR does not exceed N
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine());

            for (int t = 0; t < T; t++)
            {
                int count = 0;

                int n = int.Parse(Console.ReadLine());
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if ((i ^ j) <= n && (i ^ 1) >= 1)

                            ++count;
                    }
                }
                Console.WriteLine(count / 2);
            }

            Console.ReadKey();
        }
    }
}