﻿using System.Collections.Generic;
using System.Text;

namespace LostInTheCity
{
    public class Graph
    {
        /// <summary>
        /// Список вершин графа
        /// </summary>
        public Dictionary<string, GraphVertex> Vertices { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Graph()
        {
            Vertices = new Dictionary<string, GraphVertex>();
        }

        /// <summary>
        /// Добавление вершины
        /// </summary>
        /// <param name="vertexName">Имя вершины</param>
        public void AddVertex(string vertexName, int value)
        {
            Vertices.Add(vertexName, new GraphVertex(vertexName, value));
        }

        /// <summary>
        /// Поиск вершины
        /// </summary>
        /// <param name="vertexName">Название вершины</param>
        /// <returns>Найденная вершина</returns>
        public GraphVertex FindVertex(string vertexName)
        {
            if (Vertices.ContainsKey(vertexName))
            {
                return Vertices[vertexName];
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

        public string WebGraphviz()
        {
            var sb = new StringBuilder();
            sb.AppendLine("digraph finite_state_machine {");
            foreach (var v in Vertices)
            {
                foreach (var e in v.Value.Edges)
                {
                    sb.AppendLine($"\"{v.Value.Name}({v.Value.Value})\" -> \"{e.ConnectedVertex.Name}({e.ConnectedVertex.Value})\"  [ label = \"{e.EdgeWeight}\" ];");
                }
            }
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}