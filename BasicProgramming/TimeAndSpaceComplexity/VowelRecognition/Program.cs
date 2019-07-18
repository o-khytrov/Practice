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
            int counter = 0;


            for (int i = 0; i < s.Length; i++)
            {
                if (isVowel(s[i]))
                {
                    counter++;
                    var prefix = i + 1;
                    var suffix = s.Length - i;
                    counter += (suffix * (suffix + 1) / 2);
                    counter += (prefix * (prefix + 1) / 2);
                }
            }

            Console.WriteLine(counter);
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