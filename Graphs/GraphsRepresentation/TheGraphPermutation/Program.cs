using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TheGraphPermutation
{
    public class GraphEdge
    {
        public GraphVertex ConnectedVertex { get; }

        public int EdgeWeight { get; }

        public GraphEdge(GraphVertex connectedVertex, int weight)
        {
            ConnectedVertex = connectedVertex;
            EdgeWeight = weight;
        }
    }

    public class GraphVertex
    {
        public int Name { get; }

        public List<GraphEdge> Edges { get; }

        public int CanopyIndex { get; set; }

        public GraphVertex(int vertexName)
        {
            Name = vertexName;
            Edges = new List<GraphEdge>();
        }

        public void AddEdge(GraphEdge newEdge)
        {
            Edges.Add(newEdge);
        }

        public void AddEdge(GraphVertex vertex, int edgeWeight)
        {
            AddEdge(new GraphEdge(vertex, edgeWeight));
        }

        public override string ToString() => Name.ToString();
    }

    public class Graph
    {
        public Dictionary<int, GraphVertex> Vertices { get; }

        public Graph()
        {
            Vertices = new Dictionary<int, GraphVertex>();
        }

        public void AddVertex(int vertexName)
        {
            if (!Vertices.ContainsKey(vertexName))
            {
                Vertices.Add(vertexName, new GraphVertex(vertexName));
            }
        }

        public GraphVertex FindVertex(int v)
        {
            if (Vertices.ContainsKey(v))
            {
                return Vertices[v];
            }
            return null;
        }

        public void AddEdge(int firstName, int secondName, int weight)
        {
            var v1 = FindVertex(firstName);
            var v2 = FindVertex(secondName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, weight);
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var N = A[0];
            var M = A[1];
            var graph = new Graph();
            for (int i = 0; i < M; i++)
            {
                A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                graph.AddVertex(A[0]);
                graph.AddVertex(A[1]);
                graph.AddEdge(A[0], A[1], 0);
            }

            var graph2 = new Graph();

            var k = Int32.Parse(Console.ReadLine().Trim());

            for (int i = 0; i < k; i++)
            {
                A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                graph2.AddVertex(A[0]);
                graph2.AddVertex(A[1]);
                graph2.AddEdge(A[0], A[1], 0);
            }

            Console.ReadKey();
        }
    }
}