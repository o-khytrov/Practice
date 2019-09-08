using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Program
    {
        public static void Main()
        {
            var col = new UserCollection();
            foreach (var item in col)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------");
            foreach (var item in col)
            {
                Console.WriteLine(item);
            }
          
            Console.ReadKey();
        }
    }
}
