using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SoNP
{
    public class GraphEdge
    {
        /// <summary>
        /// Связанная вершина
        /// </summary>
        public GraphVertex ConnectedVertex { get; }

        /// <summary>
        /// Вес ребра
        /// </summary>
        public int EdgeWeight { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connectedVertex">Связанная вершина</param>
        /// <param name="weight">Вес ребра</param>
        public GraphEdge(GraphVertex connectedVertex, int weight)
        {
            ConnectedVertex = connectedVertex;
            EdgeWeight = weight;
        }
    }

    // <summary>
    /// Граф
    /// </summary>
    /// /// <summary>
    /// Вершина графа
    /// </summary>
    public class GraphVertex
    {
        /// <summary>
        /// Название вершины
        /// </summary>
        public int Name { get; }

        /// <summary>
        /// Список ребер
        /// </summary>
        public List<GraphEdge> Edges { get; }

        public int CanopyIndex { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="vertexName">Название вершины</param>
        public GraphVertex(int vertexName)
        {
            Name = vertexName;
            Edges = new List<GraphEdge>();
        }

        /// <summary>
        /// Добавить ребро
        /// </summary>
        /// <param name="newEdge">Ребро</param>
        public void AddEdge(GraphEdge newEdge)
        {
            Edges.Add(newEdge);
        }

        /// <summary>
        /// Добавить ребро
        /// </summary>
        /// <param name="vertex">Вершина</param>
        /// <param name="edgeWeight">Вес</param>
        public void AddEdge(GraphVertex vertex, int edgeWeight)
        {
            AddEdge(new GraphEdge(vertex, edgeWeight));
        }

        /// <summary>
        /// Преобразование в строку
        /// </summary>
        /// <returns>Имя вершины</returns>
        public override string ToString() => Name.ToString();
    }

    public class Graph
    {
        /// <summary>
        /// Список вершин графа
        /// </summary>
        public Dictionary<int, GraphVertex> Vertices { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Graph()
        {
            Vertices = new Dictionary<int, GraphVertex>();
        }

        /// <summary>
        /// Добавление вершины
        /// </summary>
        /// <param name="vertexName">Имя вершины</param>
        public void AddVertex(int vertexName)
        {
            Vertices.Add(vertexName, new GraphVertex(vertexName));
        }

        /// <summary>
        /// Поиск вершины
        /// </summary>
        /// <param name="vertexName">Название вершины</param>
        /// <returns>Найденная вершина</returns>
        public GraphVertex FindVertex(int v)
        {
            if (Vertices.ContainsKey(v))
            {
                return Vertices[v];
            }
            return null;
        }

        /// <summary>
        /// Добавление ребра
        /// </summary>
        /// <param name="firstName">Имя первой вершины</param>
        /// <param name="secondName">Имя второй вершины</param>
        /// <param name="weight">Вес ребра соединяющего вершины</param>
        public void AddEdge(int firstName, int secondName, int weight)
        {
            var v1 = FindVertex(firstName);
            var v2 = FindVertex(secondName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, weight);
                // v2.AddEdge(v1, weight);
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
            var n = A[0];
            var m = A[1];
            var k = A[2];
            var graph = new Graph();
            for (int i = 0; i < n; i++)
            {
                graph.AddVertex(i + 1);
            }
            for (int i = 0; i < m; i++)
            {
                var e = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                graph.AddEdge(e[0], e[1], 0);
            }
            int num_of_connected = 0;
            var visited = new bool[n + 1];

             num_of_connected = graph.Vertices.Count(x => x.Value.Edges != null);
            if (num_of_connected > k)
            {
                Console.WriteLine("-1");
            }
            else
            {
                Console.WriteLine((m - n + k));
            }
            Dfs(graph, 1, visited);
            Console.ReadKey();
        }

        private static void Dfs(Graph g, int root, bool[] visited)
        {
            //  Console.WriteLine(root);
            visited[root] = true;
            var v = g.FindVertex(root);
            if (v == null || v.Edges == null)
            {
                return;
            }
            foreach (var e in v.Edges)
            {
                if (!visited[e.ConnectedVertex.Name])
                {
                    Dfs(g, e.ConnectedVertex.Name, visited);
                }
            }
        }
    }
}