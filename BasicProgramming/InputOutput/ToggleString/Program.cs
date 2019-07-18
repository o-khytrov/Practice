using System;
using System.IO;

namespace ToggleString
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            var s = Console.ReadLine();
            var a = s.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsUpper(a[i]))
                {
                    a[i] = char.ToLower(a[i]);
                }
                else
                {
                    a[i] = char.ToUpper(a[i]);
                }
            }
            s = new string(a);
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}