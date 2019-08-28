using System;
using System.IO;
using System.Linq;

namespace HealthOfAPerson
{
    internal class Program
    {
        private static long maxW = 0;
        private static long maxWIndex = 0;

        private class Person
        {
            public int[] Days { get; set; }
            public int Health { get; set; }
            public long J { get; set; }

            public long Walk()
            {
                var sqrt = Math.Sqrt(J);

                int day = 0;
                for (int i = 0; i < sqrt; i++)
                {
                    day++;
                    if (J % day == 0 && Health <= Days[i])
                    {
                        return day;
                    }
                  
                }
                if (Days.Length > J - 1 && Health <= Days[J - 1])
                {
                    return J;
                }
                return -1;
            }



        }

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var l = Console.ReadLine().Trim();
            var s = l;
            var T = Int32.Parse(l);
            for (int t = 0; t < T; t++)
            {
                l = Console.ReadLine().Trim();
                s = s + "$" + l;
                var A = l.Split(' ').Select(Int32.Parse).ToArray();

                var people = new Person[A[0]];
                var days = A[1];
                l = Console.ReadLine().Trim();
                s = s + "$" + l;
                var H = l.Split(' ').Select(Int32.Parse).ToArray();

                l = Console.ReadLine().Trim();
                s = s + "$" + l;
                var daysArr = l.Split(' ').Select(Int32.Parse).ToArray();
                var Days = new int[daysArr.Length + 1];
                daysArr.CopyTo(Days, 1);
                for (int i = 0; i < H.Length; i++)
                {
                    var p = new Person() { J = i + 1, Health = H[i], Days = Days };
                    Console.WriteLine(p.Walk());
                }
            }

            Console.ReadKey();
        }

        private static void Show(string s)
        {
            throw new Exception(s);
        }
    }
}