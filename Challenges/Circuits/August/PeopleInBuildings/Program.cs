using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PeopleInBuildings
{
    internal class Program
    {
        private class Citizen
        {
            public int x { get; set; }
            public int y { get; set; }
            public int Id { get; set; }
        }

        private class Building
        {
            public List<Citizen> People { get; set; }

            public Building()
            {
                People = new List<Citizen>();
            }
        }

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var buildings = new List<Building>();
            var N = Int32.Parse(Console.ReadLine().Trim());

            var G = Int32.Parse(Console.ReadLine().Trim());
            var people = new List<Citizen>();
            for (int i = 0; i < N; i++)
            {
                var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                people.Add(new Citizen { x = A[0], y = A[1], Id = i + 1 });
            }
            var maxBuilding = N / G;
            for (int i = 0; i < maxBuilding; i++)
            {
                var building = new Building();
                building.People.AddRange(people);
                buildings.Add(building);
            }
            Console.WriteLine(buildings.Count);
            foreach (var b in buildings)
            {
                Console.WriteLine(b.People.Count);
                Console.WriteLine(string.Join(" ", b.People.Select(x => x.Id).ToArray()));
            }

            Console.ReadKey();
        }
    }
}