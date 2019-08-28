using System;
using System.Collections.Generic;
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
            public int J { get; set; }

            public long Walk()
            {
                var number = J;
                List<int> factors = new List<int>();
                int max = (int)Math.Sqrt(number);  //round down
                for (int factor = 1; factor <= max; ++factor)
                {
                    if (number % factor == 0)
                    {
                        if (factor < Days.Length && Days[factor] >= Health)
                        {
                            return factor;
                        }

                        if (factor != number / factor)
                        {
                            factors.Add(number / factor);
                        }
                    }
                }
                factors.Reverse();
                foreach (var day in factors)
                {
                    if (day < Days.Length && Days[day] >= Health)
                    {
                        return day;
                    }
                }

                return -1;
            }
        }
        public static long Walk(int J, int Health, int[] Days)
        {
            var number = J;
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);  //round down
            for (int factor = 1; factor <= max; ++factor)
            {
                if (number % factor == 0)
                {
                    if (factor < Days.Length && Days[factor] >= Health)
                    {
                        return factor;
                    }

                    if (factor != number / factor)
                    {
                        factors.Add(number / factor);
                    }
                }
            }
       
            for (int i = factors.Count; i-- > 0;)
            {
                var day = factors[i];
                if (day > Days.Length)
                {
                    break;
                }
                else
                {
                    if (Days[day] >= Health)
                    {
                        return day;
                    }
                }
            }
           
            return -1;
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
                var H = l.Split(' ');

                l = Console.ReadLine().Trim();
                s = s + "$" + l;
                var daysArr = l.Split(' ').Select(Int32.Parse).ToArray();
                var Days = new int[daysArr.Length + 1];
                daysArr.CopyTo(Days, 1);
                for (int i = 0; i < H.Length; i++)
                {
                    //var p = new Person() { J = i + 1, Health = Int32.Parse(H[i]), Days = Days };
                    //Console.WriteLine(p.Walk());
                    Console.WriteLine(Walk(i + 1, Int32.Parse(H[i]), Days));
                }
            }

            Console.ReadKey();
        }

    }
}