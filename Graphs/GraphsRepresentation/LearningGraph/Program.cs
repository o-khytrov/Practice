using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LearningGraph
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

            var n = A[0];// number of nodes
            var m = A[1];// number ofd edges
            var k = A[2];// k

            var graph = new Graph();
            A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

            for (int i = 0; i < A.Length; i++)
                graph.AddVertex(A[i]);
            for (int i = 0; i < m; i++)
            {

                A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                graph.AddEdge(A[0], A[1], 0);
            }
            Console.ReadKey();
        }
    }
}