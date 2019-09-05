using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_Parallel.ForEach
{
    class Program
    {
        class Element
        {
            public int A { get; set; }
        }

        static void Main(string[] args)
        {


            IList<Element> elements = new List<Element>();

            for (int i = 0; i < 100000000; i++)
            {
                elements.Add(new Element
                {
                    A = i
                });

                Stopwatch timer = new Stopwatch();

                timer.Start();
                foreach (var element in elements)
                {
                    element.A = 111 * 222 * 333 / 444;
                }
                timer.Stop();
                Console.WriteLine("Regular ForEach loop  {0}", timer.ElapsedTicks);
                timer.Reset();

                timer.Start();
                Parallel.ForEach(elements, el => el.A = 111 * 222 * 333 / 444);
                timer.Stop();
                Console.WriteLine("Parallel ForEach loop {0}", timer.ElapsedTicks);
                Console.WriteLine("\nMain Thread is finished");

                Console.ReadKey();
            }
        }
    }
}
