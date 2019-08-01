using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnEquilateralTtriangle
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));
            for (int i = 3; i < 20; i++)
            {
                var line = Console.ReadLine();

                var n = i;
                var figure = new MainFigure(n);

                Console.WriteLine($"{n} {figure.numberOfRectangles} {n * n}");
            }

            Console.ReadKey();
        }
    }

    public class MainFigure
    {
        private const int sideLength = 200;

        public List<Coordinates> Points { get; set; }

        public Dictionary<int, List<int>> Stages { get; set; }
        public int numberOfRectangles { get; set; }

        public MainFigure(int n)
        {
            var totalNumber = n * n;
            Points = new List<Coordinates>();
            Stages = new Dictionary<int, List<int>>();

            var numberPerStage = (n * 2) - 1;
            for (int i = 0; i < n; i++)
            {
                var stage = new List<int>();
                var stargingNumber = 0;
                if (Stages.Any())
                {
                    stargingNumber = Stages[i - 1].Last() + 1;
                }

                for (int t = stargingNumber; t < stargingNumber + numberPerStage; t++)
                {
                    stage.Add(t);
                }
                Stages.Add(i, stage);
                numberPerStage = numberPerStage - 2;
            }

            for (int i = 0; i < totalNumber; i++)
            {
                var position = i;
                var stage = Stages.Single(x => x.Value.Contains(position)).Key;
                TriangleType type;
                if (!stage.IsOdd())
                {
                    if (position.IsOdd())
                    {
                        type = TriangleType.Down;
                    }
                    else
                    {
                        type = TriangleType.Up;
                    }
                }
                else
                {
                    if (position.IsOdd())
                    {
                        type = TriangleType.Up;
                    }
                    else
                    {
                        type = TriangleType.Down;
                    }
                }

                var currentX = sideLength * Stages[stage].IndexOf(position) / 2 + (sideLength / 2) * stage;
                var currentY = sideLength * stage;
                if (type == TriangleType.Up)
                {
                    if (stage == 0)
                    {
                        Points.Add(new Coordinates { x = currentX, y = currentY });

                        Points.Add(new Coordinates { x = currentX + sideLength, y = currentY });
                    }
                    Points.Add(new Coordinates { x = currentX + sideLength / 2, y = currentY + sideLength });
                }
            }

            CalculateRectangles();

            //Debug();
        }

        private void CalculateRectangles()
        {
            var points = Points.Distinct().ToList();
            foreach (var point in points)
            {
                var belowPoints = points.Where(p => p.y == point.y && p.x > point.x).ToList();
                var leftPoints = points.Where(p => p.x == point.x && p.y > point.y).ToList();
                if (belowPoints.Any() && leftPoints.Any())
                {
                    foreach (var leftPoint in leftPoints)
                    {
                        foreach (var belowPoint in points.Where(p => p.y == leftPoint.y && p.x > leftPoint.x).ToList())
                        {
                            if (belowPoints.Any(p => p.x == belowPoint.x))
                            {
                                numberOfRectangles++;
                            }
                        }
                    }
                }
            }
        }

        public struct Coordinates
        {
            public float x { get; set; }
            public float y { get; set; }
        }

        public enum TriangleType
        {
            Up,
            Down
        }
    }

    public static class Extensions
    {
        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }
    }
}