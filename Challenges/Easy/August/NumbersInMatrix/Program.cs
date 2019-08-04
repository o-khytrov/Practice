using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace NumbersInMatrix
{
    public class LongPoint
    {
        public long X;
        public long Y;
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var n = A[0];
            var m = A[1];
            var Q = A[2];
            var counter = 0;
            BigInteger total = m * n;
            BigInteger ones = 0;
            bool isIverted = false;
            var dict = new Dictionary<LongPoint, bool>();
            for (int q = 0; q < Q; q++)
            {
                A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                if (A.Length == 1) // invert matrix
                {
                    ones = total - ones;
                    isIverted = !isIverted;
                }
                else if (A.Length == 3)
                {
                    var point = new LongPoint { X = (long)A[0], Y = (long)A[1] };

                    if (!isIverted)
                    {
                        if (dict.ContainsKey(point))
                        {
                            if (dict[point])
                            {
                                ones++;
                            }
                            else
                            {
                                ones--;
                            }
                        }
                        else
                        {
                            ones++;
                        }
                    }
                    else
                    {
                        if (dict.ContainsKey(point))
                        {
                            if (dict[point])
                            {
                                ones--;
                            }
                            else
                            {
                                ones++;
                            }
                        }
                        else
                        {
                            ones--;
                        }
                    }
                }
            }

            Console.WriteLine(ones);
            Console.ReadKey();
        }
    }
}