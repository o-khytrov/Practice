using System;
using System.IO;
using System.Linq;
using System.Collections.Specialized;

namespace MaximizingExpressions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine().Trim());

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var B = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var C = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            int sum = 0;

            for (int i = 0; i < N; i++)
            {
                var a = new BitVector32(A[i]);
                var b = new BitVector32(B[i]);
                var c = new BitVector32(C[i]);
                var lSum = new BitVector32();


                for (int bit = 0; bit < 32; bit++)
                {
                    if (a[bit] && !b[bit])
                        lSum[bit] = true;

                   
                    if (!a[bit] && b[bit])
                        lSum[bit] = true;

                    if (a[bit] && b[bit] && !c[bit])
                        lSum[bit] = false;

                    if (a[bit] && !b[bit] && !c[bit])
                        lSum[bit] = true;

                    if (!a[bit] && b[bit] && !c[bit])
                        lSum[bit] = true;

                }
                Console.WriteLine(lSum.Data);
                sum += lSum.Data;
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }

        private static int Loop(int[] A, int[] B, int[] C, int i)
        {
            int local = 0;
            int maxD = 0;
            Console.WriteLine(C[i]);
            Console.WriteLine(Convert.ToString(C[i], 2));

            var bv = new BitVector32(i);

            for (int D = 1; D <= C[i]; D++)
            {



                if ((C[i] & D) == D)
                {
                    var b = (A[i] ^ (B[i] ^ D));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(new string(' ', 5) + "C[i]=" + C[i] + "; D=" + D + $"; {C[i]}&{D}=" + (C[i] & D) + "; B=" + b);
                    Console.ResetColor();
                    if (local < b)
                    {
                        local = b;
                        maxD = D;

                    }
                }
                else
                {
                    Console.WriteLine(new string(' ', 5) + "C[i]=" + C[i] + "; D=" + D + $"; {C[i]}&{D}=" + (C[i] & D));
                }



            }

            Console.WriteLine(new BitVector32(A[i]));
            Console.WriteLine(new BitVector32(B[i]));
            Console.WriteLine(new BitVector32(C[i]));
            //Console.WriteLine(new BitVector32(maxD) + " "+ maxD);
            Console.WriteLine(new BitVector32(local) + " " + local);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(' ', 10) + local);
            Console.ResetColor();
            return local;
        }
    }
}