using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {

        var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

        var n = A[0];

        var d = A[1];
        A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
        var px = A[0];
        var py = A[1];
        var s = A[2];
        var c = A[3];

    }
}