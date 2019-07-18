using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalWord
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeNumbers = new int[] { 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113 };
            Console.SetIn(new StreamReader("Console.txt"));
            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var N = Int32.Parse(Console.ReadLine());
                var word = Console.ReadLine();
                var array = word.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    if (primeNumbers.Contains(array[i]))
                    {

                    }
                    var mag = primeNumbers.OrderBy(x => Math.Abs(x - array[i])).First();
                    array[i] = (char)mag;

                }
                word = new string(array);
                Console.WriteLine(word);
            }
            Console.ReadKey();
        }
    }
}
