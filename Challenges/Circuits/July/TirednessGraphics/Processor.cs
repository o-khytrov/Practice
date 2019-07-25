using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace LostInTheCity
{
    public class Processor
    {
        public List<Canopy> Canopies { get; set; }

        public int GeneralCost { get; set; }

        public Point Start { get; set; }
        public Point Destination { get; set; }

        public string Path { get; set; }
        public int CostOfDirectionChange { get; set; }

        public Graph Graph { get; set; }

        public Processor()
        {
            ReadInputs();
        }

        public void Proces()
        {
            BuildGraph();
            FindPath();
        }

        private void BuildGraph()
        {
            var canopies = Canopies
                .Where(x => x.P1.X <= Destination.X
                && x.P1.Y <= Destination.Y)
                .ToArray();

            Graph = new Graph();
            for (int i = 1; i <= Math.Max(Start.X, Destination.X); i++)
            {
                for (int j = 1; j <= Math.Max(Start.Y, Destination.Y); j++)
                {
                    Graph.AddVertex($"{i}:{j}");
                }
            }

            for (int i = 1; i <= Math.Max(Start.X, Destination.X); i++)
            {
                for (int j = 1; j <= Math.Max(Start.Y, Destination.Y); j++)
                {
                    var cost = GeneralCost;
                    Canopy bestCanopy = null;
                    var canopiesOver = canopies.Where(c => c.P1.X <= i && c.P2.X >= i && c.P1.Y <= j && c.P2.Y >= j);
                    if (canopiesOver.Any())
                    {
                        cost = canopiesOver.Min(x => x.Rate);
                        bestCanopy = canopiesOver.FirstOrDefault(x => x.Rate == cost);
                    }
                    var currentVertex = $"{i}:{j}";
                    var bottomVertex = $"{i}:{j + 1}";
                    var rightVertex = $"{i + 1}:{j}";
                    var leftVertex = $"{i - 1}:{j}";
                    var topVertex = $"{i}:{j - 1}";
                    Graph.FindVertex(currentVertex).CanopyIndex = bestCanopy?.Index ?? 0;
                    Graph.AddEdge(currentVertex, rightVertex, cost); // add edge to the rigtht
                    Graph.AddEdge(currentVertex, bottomVertex, cost); // add edge to the bottom
                    Graph.AddEdge(currentVertex, topVertex, cost); // add edge to the bottom
                    Graph.AddEdge(currentVertex, leftVertex, cost); // add edge to the bottom
                }
            }

            FindPath();
        }

        private void FindPath()
        {
            var dijkstra = new Dijkstra(Graph);

            Path = dijkstra.FindShortestPath($"{Start.X}:{Start.Y}", $"{Destination.X}:{Destination.Y}");
        }

        private void ReadInputs()
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var A1 = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

            var N = A1[0];
            var D = A1[1];
            CostOfDirectionChange = D;

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            GeneralCost = A[4];
            Start = new Point(A[0], A[1]);
            Destination = new Point(A[2], A[3]);

            Canopies = new List<Canopy>();
            for (int n = 0; n < N; n++)
            {
                var a = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

                var canopy = new Canopy
                {
                    P1 = new Point { X = a[0], Y = a[1] },
                    P2 = new Point { X = a[2], Y = a[3] },
                    Rate = a[4],
                    Index = n + 1,
                    Color = ColorHelper.GetRandomColor()
                };

                Canopies.Add(canopy);
            }
        }

        public List<string> Answer()
        {
            var strings = Path.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            var vertex = Graph.FindVertex(strings[0]);

            var lines = new List<string>() { vertex.Name.Replace(":", " ") };
            var index = vertex.CanopyIndex;

            for (int i = 1; i < strings.Length; i++)
            {
                vertex = Graph.FindVertex(strings[i]);
                if (vertex.CanopyIndex != index)
                {
                    var name = vertex.Name.Replace(":", " ");

                    var lastLine = lines.Last();
                    lastLine = lastLine + " " + name + " " + index;
                    lines[lines.Count - 1] = lastLine;

                    lines.Add(name);

                    index = vertex.CanopyIndex;
                }
            }
            var finalLine = lines.Last();
            if (finalLine.Split(' ').Count() < 5)
            {
                lines.Remove(finalLine);
            }
            return lines;
        }
    }
}