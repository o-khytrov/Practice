using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LostInStrings
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var list = new List<string>();
            var S = Console.ReadLine();
            list.Add(S);

            var Q = Int32.Parse(Console.ReadLine().Trim());
            for (int i = 0; i < Q; i++)
            {
                var A = Console.ReadLine().Trim().Split(' ').ToArray();
                var q = Int32.Parse(A[0]);
                var p = Int32.Parse(A[1]);
                var n = Int32.Parse(A[2]);
                string c = string.Empty; ;
                if (q != 2)
                {
                    c = A[3];
                }

                string newStr;
                switch (q)
                {
                    case 1:
                        newStr = list[n - 1].Substring(0, (p - 1 > list[n - 1].Length) ? list[n - 1].Length : p - 1) + c;
                        list.Add(newStr);
                        break;

                    case 2:
                        newStr = list[n - 1].Substring(0, (p - 1 > list[n - 1].Length) ? list[n - 1].Length : p - 1);
                        list.Add(newStr);
                        break;

                    case 3:
                        var found = false;
                        for (int j = p - 1; j <= n - 1; j++)
                        {
                            if (list[j].StartsWith(c))
                            {
                                found = true;
                                break;
                            }
                        }
                        if (found)
                        {
                            Console.WriteLine("yes");
                        }
                        else
                        {
                            Console.WriteLine("no");
                        }
                        break;

                    default:
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}