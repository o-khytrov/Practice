using System;
using System.IO;

namespace Cipher
{
    internal class Program
    {
        //A becomes E, Y becomes C, 9 becomes 3,
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var s = Console.ReadLine();
            var key = Int32.Parse(Console.ReadLine());
            var a = s.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {
                var c = a[i];
                if (char.IsDigit(c) || char.IsLetter(c))
                {
                    if (c == 'A')
                    {
                        a[i] = 'E';
                    }
                    else if (c == 'Y')
                    {
                        a[i] = 'C';
                    }
                    else if (c == '9')
                    {
                        a[i] = '3';
                    }
                    else
                    {
                        var offset = key;
                        if (char.IsLetter(c) && offset > 26)
                        {
                            offset = offset % 26;
                        }
                        if (char.IsDigit(c) && offset > 10)
                        {
                            offset = offset % 10;
                        }
                        a[i] = Convert.ToChar((int)c + offset);
                    }
                }
            }
            s = new string(a);
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}