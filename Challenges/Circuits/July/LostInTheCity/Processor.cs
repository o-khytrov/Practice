using System;
using System.IO;
using System.Linq;

namespace LostInTheCity
{
    public class Processor
    {
        public Graph Graph { get; set; }

        public Processor()
        {
            ReadInputs();
        }

        private void ReadInputs()
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine().Trim());
            for (int t = 0; t < T; t++)
            {
                var a1 = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var n = a1[0]; // number of vertices
                var m = a1[1]; // number of edges
                var s = a1[2]; // number central city
                Graph = new Graph();

                var a2 = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                for (int c = 0; c < a2.Length; c++)
                {
                    var cityNumber = (c+1).ToString();
                    Graph.AddVertex(cityNumber, a2[c]);
                }
                for (int i = 0; i < m; i++)
                {
                    var a3 = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                    Graph.AddEdge(a3[0].ToString(), a3[1].ToString(), 1);
                }
                var stringPresentation = Graph.WebGraphviz();
            }
           
        }
    }
}