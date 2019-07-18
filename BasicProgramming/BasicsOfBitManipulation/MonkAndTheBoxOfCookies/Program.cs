using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkAndTheBoxOfCookies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var N = Int32.Parse(Console.ReadLine());
                for (int i = 0; i < N; i++)
                {
                    var d = Int32.Parse(Console.ReadLine());
                    Console.WriteLine(Convert.ToString(d,2));
                }
            }

            Console.ReadKey();
        }
    }
}
