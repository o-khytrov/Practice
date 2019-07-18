using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystery
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            int n;
            var ints = new List<int>();
            while (Int32.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine(Convert.ToString(n,2));
            }
            
            Console.ReadKey();
        }

    }
}
