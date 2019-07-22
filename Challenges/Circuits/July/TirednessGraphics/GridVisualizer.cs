using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TirednessGraphics
{
    public class GridVisualizer : IDisposable
    {
        public static Graphics Graphics { get; set; }
        public Bitmap Bitmap { get; set; }
        public Point Start { get; set; }
        public Point Destination { get; set; }
        public List<Canopy> Canopies { get; set; }
        public string Path { get; set; }

        public GridVisualizer()
        {
            Bitmap = new Bitmap(2000, 2000);
            Graphics = Graphics.FromImage(Bitmap);
            Graphics.ScaleTransform(60.0f, 60.0f);
        }

        private static void DrawGrid()
        {
            Font drawFont = new Font("Arial", 0.4f);

            int cellSize = 1;
            int numOfCells = 200;
            var CellPen = new Pen(Color.Gray, 0.05f);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            for (int y = 0; y < numOfCells; ++y)
            {
                Graphics.DrawLine(CellPen, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
                Graphics.DrawString((y + 1).ToString(), drawFont, drawBrush, 0, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                Graphics.DrawLine(CellPen, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
                Graphics.DrawString((x + 1).ToString(), drawFont, drawBrush, x * cellSize, 0);
            }
        }

        private void DrawVertex(int number)
        {
            Font drawFont = new Font("Arial", 0.3f);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            var maxX = Math.Max(Destination.X, Start.X);
            var maxY = Math.Max(Destination.Y, Start.Y);
            var restX = number - maxX;
            var x = 0;
            var y = 0;
            if (number <= maxX)
            {
                x = number - 1;
                y = 0;
            }
            else
            {
                var doubleRow = (double)number / (double)maxX;
                var row = (int)Math.Ceiling(doubleRow);
                y = row - 1;
                var dif = Math.Abs(number - maxX * row);
                if (dif == 0)
                {
                    x = maxX;
                }
                else
                {
                    x = maxX - dif;
                }
                x = x - 1;
            }
            Pen mypen = new Pen(Brushes.Black, 0.05f);
            Graphics.DrawString(number.ToString(), drawFont, drawBrush, x + 0.25f, y + 0.25f);
            Graphics.DrawEllipse(mypen, x, y, 0.8f, 0.8f);
        }

        public void DrawRoute()
        {
            using (var routePen = new Pen(Color.Red, 0.1f))
            {
                var strings = Path.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                var points = new Point[strings.Length];
                for (int i = 0; i < strings.Length; i++)
                {
                    var A = strings[i].Split(':').Select(Int32.Parse).ToArray();
                    points[i] = new Point(A[0], A[1]);
                }
                for (int i = 0; i < points.Length - 1; i++)
                {
                    var startPoint = points[i];
                    var nestPoint = points[i + 1];
                    Graphics.DrawLine(routePen, startPoint.X - 0.5f, startPoint.Y - 0.5f, nestPoint.X - 0.5f, nestPoint.Y - 0.5f);
                }
            }
        }

        private static void DrawPoint(Point point, Color color)
        {
            using (var brush = new SolidBrush(color))
            {
                var rect = new Rectangle(point.X - 1, point.Y - 1, 1, 1);
                Graphics.FillRectangle(brush, rect);
            }
        }

        private void DrawCanopies()
        {
            Font drawFont = new Font("Arial", 0.3f);

            foreach (var canpy in Canopies)
            {
                var color = canpy.Color;
                using (SolidBrush drawBrush = new SolidBrush(color))
                using (Pen p = new Pen(color, 0.3f))
                {
                    Graphics.DrawRectangle(p, canpy.P1.X - 1, canpy.P1.Y - 1, (canpy.P2.X - canpy.P1.X) + 1, canpy.P2.Y - canpy.P1.Y + 1);
                    Graphics.DrawString(canpy.Rate.ToString(), drawFont, drawBrush, canpy.P1.X, canpy.P1.Y);
                }
            }
        }

        public void Dispose()
        {
            Graphics.Dispose();
        }

        public Bitmap Visualize()
        {
            DrawGrid();

            DrawPoint(Start, Color.Green);

            DrawPoint(Destination, Color.Red);
            DrawCanopies();
            DrawRoute();
            return Bitmap;
        }

        public Bitmap VisualizePath()
        {
            DrawPoint(Start, Color.Green);

            DrawPoint(Destination, Color.Red);
            DrawRoute();
            return Bitmap;
        }
    }
}