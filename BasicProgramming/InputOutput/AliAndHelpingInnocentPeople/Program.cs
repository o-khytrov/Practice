using System;
using System.IO;
using System.Linq;

namespace AliAndHelpingInnocentPeople
{
    public static class Extensions
    {
        public static bool IsEven(this int n)
        {
            return n % 2 == 0;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            var s = Console.ReadLine();
            var vowels = new char[] { 'A', 'E', 'I', 'O', 'U', 'Y' };
            bool valid = true;
            if (s.Any(x => vowels.Contains(x)))
            {
                valid = false;
            }
            if (valid)
            {
                for (int i = 0; i < s.Length - 1; i++)
                {
                    var c = s[i];
                    var next = s[i + 1];
                    if (char.IsDigit(c) && char.IsDigit(next))
                    {
                        if (!(Int32.Parse(c.ToString()) + Int32.Parse(next.ToString())).IsEven())
                        {
                            valid = false;
                            break;
                        }
                    }
                }
            }

            var message = valid ? "valid" : "invalid";

            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}