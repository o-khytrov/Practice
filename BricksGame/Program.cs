using System;
using System.IO;

namespace BricksGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            var B = Int32.Parse(Console.ReadLine());
            var motu = "Motu";
            var paltu = "Patlu";
            var player = paltu;
            int c = 1;
            while (B > 0)
            {
                player = paltu;
                B -= c;
                if (B <= 0)
                    break;

                var briksToTake = c * 2;
                player = motu;
                B -= briksToTake;
                c++;
            }

            Console.WriteLine(player);
            Console.ReadKey();
        }
    }
}