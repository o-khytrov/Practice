using System;
using System.Collections.Generic;
using System.Drawing;

namespace LostInTheCity
{
    // <summary>
    /// Граф
    /// </summary>
    /// /// <summary>
    /// Вершина графа
    /// </summary>
    public class GraphVertex
    {
        public PointF Point { get; set; }
        /// <summary>
        /// Название вершины
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Список ребер
        /// </summary>
        public List<GraphEdge> Edges { get; }

        public int Value { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="vertexName">Название вершины</param>
        public GraphVertex(string vertexName, int value)
        {
            Name = vertexName;
            Edges = new List<GraphEdge>();
            Value = value;
            var random = new Random();
            Point = new PointF(random.Next(10), random.Next(10));
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
}