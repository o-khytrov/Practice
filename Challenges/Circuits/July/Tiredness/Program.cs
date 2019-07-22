using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;

public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

/// <summary>
/// Информация о вершине
/// </summary>
public class GraphVertexInfo
{
    /// <summary>
    /// Вершина
    /// </summary>
    public GraphVertex Vertex { get; set; }

    /// <summary>
    /// Не посещенная вершина
    /// </summary>
    public bool IsUnvisited { get; set; }

    /// <summary>
    /// Сумма весов ребер
    /// </summary>
    public int EdgesWeightSum { get; set; }

    /// <summary>
    /// Предыдущая вершина
    /// </summary>
    public GraphVertex PreviousVertex { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="vertex">Вершина</param>
    public GraphVertexInfo(GraphVertex vertex)
    {
        Vertex = vertex;
        IsUnvisited = true;
        EdgesWeightSum = int.MaxValue;
        PreviousVertex = null;
    }
}

/// <summary>
/// Алгоритм Дейкстры
/// </summary>
public partial class Dijkstra
{
    private Graph graph;

    private List<GraphVertexInfo> infos;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="graph">Граф</param>
    public Dijkstra(Graph graph)
    {
        this.graph = graph;
    }

    /// <summary>
    /// Инициализация информации
    /// </summary>
    private void InitInfo()
    {
        infos = new List<GraphVertexInfo>();
        foreach (var v in graph.Vertices)
        {
            infos.Add(new GraphVertexInfo(v));
        }
    }

    /// <summary>
    /// Получение информации о вершине графа
    /// </summary>
    /// <param name="v">Вершина</param>
    /// <returns>Информация о вершине</returns>
    private GraphVertexInfo GetVertexInfo(GraphVertex v)
    {
        foreach (var i in infos)
        {
            if (i.Vertex.Equals(v))
            {
                return i;
            }
        }

        return null;
    }

    /// <summary>
    /// Поиск непосещенной вершины с минимальным значением суммы
    /// </summary>
    /// <returns>Информация о вершине</returns>
    public GraphVertexInfo FindUnvisitedVertexWithMinSum()
    {
        var minValue = int.MaxValue;
        GraphVertexInfo minVertexInfo = null;
        foreach (var i in infos)
        {
            if (i.IsUnvisited && i.EdgesWeightSum < minValue)
            {
                minVertexInfo = i;
                minValue = i.EdgesWeightSum;
            }
        }

        return minVertexInfo;
    }

    /// <summary>
    /// Поиск кратчайшего пути по названиям вершин
    /// </summary>
    /// <param name="startName">Название стартовой вершины</param>
    /// <param name="finishName">Название финишной вершины</param>
    /// <returns>Кратчайший путь</returns>
    public string FindShortestPath(string startName, string finishName)
    {
        return FindShortestPath(graph.FindVertex(startName), graph.FindVertex(finishName));
    }

    /// <summary>
    /// Поиск кратчайшего пути по вершинам
    /// </summary>
    /// <param name="startVertex">Стартовая вершина</param>
    /// <param name="finishVertex">Финишная вершина</param>
    /// <returns>Кратчайший путь</returns>
    public string FindShortestPath(GraphVertex startVertex, GraphVertex finishVertex)
    {
        InitInfo();
        var first = GetVertexInfo(startVertex);
        first.EdgesWeightSum = 0;
        while (true)
        {
            var current = FindUnvisitedVertexWithMinSum();
            if (current == null)
            {
                break;
            }

            SetSumToNextVertex(current);
        }

        return GetPath(startVertex, finishVertex);
    }

    /// <summary>
    /// Вычисление суммы весов ребер для следующей вершины
    /// </summary>
    /// <param name="info">Информация о текущей вершине</param>
    private void SetSumToNextVertex(GraphVertexInfo info)
    {
        info.IsUnvisited = false;
        foreach (var e in info.Vertex.Edges)
        {
            var nextInfo = GetVertexInfo(e.ConnectedVertex);
            var sum = info.EdgesWeightSum + e.EdgeWeight;
            if (sum < nextInfo.EdgesWeightSum)
            {
                nextInfo.EdgesWeightSum = sum;
                nextInfo.PreviousVertex = info.Vertex;
            }
        }
    }

    /// <summary>
    /// Формирование пути
    /// </summary>
    /// <param name="startVertex">Начальная вершина</param>
    /// <param name="endVertex">Конечная вершина</param>
    /// <returns>Путь</returns>
    private string GetPath(GraphVertex startVertex, GraphVertex endVertex)
    {
        var path = endVertex.ToString() + ";";
        while (startVertex != endVertex)
        {
            endVertex = GetVertexInfo(endVertex).PreviousVertex;
            path = endVertex.ToString() + ";" + path;
        }

        return path;
    }
}

public class Graph
{
    /// <summary>
    /// Список вершин графа
    /// </summary>
    public List<GraphVertex> Vertices { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public Graph()
    {
        Vertices = new List<GraphVertex>();
    }

    /// <summary>
    /// Добавление вершины
    /// </summary>
    /// <param name="vertexName">Имя вершины</param>
    public void AddVertex(string vertexName)
    {
        Vertices.Add(new GraphVertex(vertexName));
    }

    /// <summary>
    /// Поиск вершины
    /// </summary>
    /// <param name="vertexName">Название вершины</param>
    /// <returns>Найденная вершина</returns>
    public GraphVertex FindVertex(string vertexName)
    {
        foreach (var v in Vertices)
        {
            if (v.Name.Equals(vertexName))
            {
                return v;
            }
        }

        return null;
    }

    /// <summary>
    /// Добавление ребра
    /// </summary>
    /// <param name="firstName">Имя первой вершины</param>
    /// <param name="secondName">Имя второй вершины</param>
    /// <param name="weight">Вес ребра соединяющего вершины</param>
    public void AddEdge(string firstName, string secondName, int weight)
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
    public string Name { get; }

    /// <summary>
    /// Список ребер
    /// </summary>
    public List<GraphEdge> Edges { get; }

    public int CanopyIndex { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="vertexName">Название вершины</param>
    public GraphVertex(string vertexName)
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
    public override string ToString() => Name;
}

public class Canopy
{
    public Point P1 { get; set; }
    public Point P2 { get; set; }
    public int Rate { get; set; }

    public int Index { get; set; }

    public override string ToString()
    {
        return $"{P1.X} {P1.Y} {P2.X} {P2.Y}";
    }
}

/// </summary>
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
                var canopiesOver = canopies.Where(c => c.P1.X <= i && c.P2.X >= i && c.P1.Y < j && c.P2.Y > j);
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
                // Color = ColorHelper.GetRandomColor()
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

internal class Program
{
    private static void Main(string[] args)
    {
        var processor = new Processor();
        processor.Proces();
        var answer = processor.Answer();
        Console.WriteLine(answer.Count);
        foreach (var line in answer)
        {
            Console.WriteLine(line);
        }
    }
}