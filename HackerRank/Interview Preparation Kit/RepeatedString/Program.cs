using System;
using System.IO;

namespace RepeatedString
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var s = Console.ReadLine();
            var n = long.Parse(Console.ReadLine().Trim());
          
            long m = (n - (n % s.Length)) / s.Length;
            long ans = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    ans += m;
                }
            }
            for (int i = 0; i < n % s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    ans++;
                }
            }
            Console.WriteLine(ans);
            Console.ReadKey();
        }
    }
}