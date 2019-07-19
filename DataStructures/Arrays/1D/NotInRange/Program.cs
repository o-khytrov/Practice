using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NotInRange
{
    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Interval()
        {
            Start = 0;
            End = 0;
        }

        public Interval(int s, int e)
        {
            Start = s;
            End = e;
        }

        public static void quicksort(List<Interval> list, int start, int end)
        {
            int i, j, central;
            int pivot;
            central = (start + end) / 2;
            pivot = list[central].Start;
            i = start;
            j = end;
            do
            {
                while (list[i].Start < pivot) j++;
                while (list[j].Start > pivot) j--;
                {
                    if (i < j)
                    {
                        Interval temp;
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                        j++;
                        j--;
                    }
                }
            } while (i <= j);
            if (start < j)
            {
                quicksort(list, start, j);
            }
            if (i < end)
            {
                quicksort(list, i, end);
            }
        }

        public static List<Interval> Merge(List<Interval> intervals)
        {
            if (intervals == null || intervals.Count == 0) return intervals;
            quicksort(intervals, 0, intervals.Count - 1);
            int i = 0;
            var res = new List<Interval>();
            while (i < intervals.Count)
            {
                var interval = intervals[i];
                var insertar = interval;
                while (i + 1 < intervals.Count && intervals[i + 1].Start <= interval.End)
                {
                    insertar = new Interval(Math.Min(interval.Start, intervals[i + 1].Start), Math.Max(interval.End, intervals[i + 1].End));
                    interval = insertar;
                    i++;
                }
                res.Add(insertar);
                i++;
            }
            return res;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine().Trim());
            long total = 0;
            var max = (long)Math.Pow(10, 6);
            var ranges = new List<int[]>();
            for (int i = 0; i < N; i++)
            {
                var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                ranges.Add(A);
            }
            ranges = ranges.OrderBy(x => x[0]).ToList();
            for (int i = 1; i <= max; i++)
            {
                var range = ranges.FirstOrDefault(x => i >= x[0] && i <= x[1]);
                if (range == null)
                {
                    total += i;
                }
                else
                {
                    i = range[1];
                }
            }
            Console.WriteLine(total);
            Console.ReadKey();
        }
    }
}