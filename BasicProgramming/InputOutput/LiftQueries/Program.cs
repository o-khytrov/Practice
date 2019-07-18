using System;
using System.IO;
using System.Linq;

namespace LiftQueries
{
    internal class Elevetor
    {
        public int Flor { get; set; }
        public string Name { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var elevators = new Elevetor[]
            {
                new Elevetor{Flor =0, Name="A" },
                new Elevetor{Flor =7, Name="B" },
            };

            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var n = Int32.Parse(Console.ReadLine());
                var closestElevator = elevators.OrderBy(x => Math.Abs(x.Flor - n)).ThenByDescending(x => n - x.Flor).First();
                Console.WriteLine(closestElevator.Name);
                closestElevator.Flor = n;
            }
            Console.ReadKey();
        }
    }
}