using System;
using System.IO;

namespace VowelRecognition
{
    internal class Program
    {
        private static bool isVowel(char c)
        {
            return "aeiouAEIOU".IndexOf(c) >= 0;
        }

        public static void CountVowels(string s)
        {
            checked
            {
                long counter = 0;

                int lastNonVowel = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (isVowel(s[i]))
                    {
                        long count = ((long)s.Length - (long)i) * ((long)i + 1);
                        counter += count;
                    }
                    else
                    {
                        lastNonVowel = s[i];
                    }
                }

                Console.WriteLine(counter);
            }
            
        }

        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var s = Console.ReadLine();
                CountVowels(s);
            }
            Console.ReadKey();
        }
    }
}