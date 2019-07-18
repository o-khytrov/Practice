using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromicString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader(@"D:\Console.txt"));
            var s = Console.ReadLine();
            var isPalindromic = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[(s.Length - 1) - i])
                {
                    isPalindromic = false;
                }
            }
            var message = isPalindromic ? "YES" : "NO";
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
