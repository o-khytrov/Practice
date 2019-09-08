
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client(new CocaColaFactory());
            client.Run();

            client = new Client(new PepsiFactory());
            client.Run();

            client = new Client(new SchwepsFactory());
            client.Run();


            Console.ReadKey();
        }
    }
}
