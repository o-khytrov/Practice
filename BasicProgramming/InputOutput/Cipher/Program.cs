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
                    var offset = key;
                    if (char.IsLetter(c))
                    {
                        if (offset >= 26)
                        {
                            offset = offset % 26;
                        }
                        if (char.IsUpper(c))
                        {
                            var charsToEnd = 90 - c;
                            if (offset > charsToEnd)
                            {
                                c = (char)65;
                                offset -= charsToEnd + 1;
                            }
                        }
                        else
                        {
                            var charsToEnd = 122 - c;
                            if (offset > charsToEnd)
                            {
                                c = (char)97;
                                offset -= charsToEnd + 1;
                            }
                        }
                    }
                    if (char.IsDigit(c))
                    {
                        if (offset >= 10)
                        {
                            offset = offset % 10;
                        }

                        var charsToEnd = 57 - c;
                        if (offset > charsToEnd)
                        {
                            c = (char)48;
                            offset -= charsToEnd + 1;
                        }
                    }
                    a[i] = Convert.ToChar((int)c + offset);
                }
            }
            s = new string(a);
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}