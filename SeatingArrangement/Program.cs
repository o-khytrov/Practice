/*
 * https://www.hackerearth.com/practice/basic-programming/input-output/basics-of-input-output/practice-problems/algorithm/seating-arrangement-1/
 Akash and Vishal are quite fond of travelling. They mostly travel by railways. They were travelling in a train one day and they got interested in the seating arrangement of their compartment. The compartment looked something like

So they got interested to know the seat number facing them and the seat type facing them. The seats are denoted as follows :

Window Seat : WS
Middle Seat : MS
Aisle Seat : AS

You will be given a seat number, find out the seat number facing you and the seat type, i.e. WS, MS or AS.

INPUT
First line of input will consist of a single integer T denoting number of test-cases. Each test-case consists of a single integer N denoting the seat-number.

OUTPUT
For each test case, print the facing seat-number and the seat-type, separated by a single space in a new line.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SeatingArrangement
{
    internal class Program
    {
        private const int Places = 108;
        private const int PlacesInBlock = 12;

        private static void Place(int place)
        {
            var dict = new Dictionary<string, int[]>
            {
                { "AS", new int[]{9,4,3,10 } },
                { "MS", new int[]{ 8,5,2,11} },
                { "WS", new int[]{ 7,6,1,12} },
            };
            var descr = string.Empty;
            var numberInBlock = (place % PlacesInBlock);
            numberInBlock = (numberInBlock == 0) ? PlacesInBlock : numberInBlock;
            var block = 1;
            var startOfBlock = 1;
            var endOfBlock = PlacesInBlock;

            while (block * PlacesInBlock < place)
            {
                block++;
                startOfBlock += PlacesInBlock;
                endOfBlock += PlacesInBlock;
            }

            var opposite = startOfBlock + (endOfBlock - place);
            descr = dict.FirstOrDefault(x => x.Value.Contains(numberInBlock)).Key;
            //Console.WriteLine($"place:{place}; number in block:{numberInBlock}; row:{row}; place in row:{placeInRow}; descr:{descr}");
            Console.WriteLine($"{opposite} {descr}");
        }

        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader(@"D:\Console.txt"));
            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var p = Int32.Parse(Console.ReadLine());
                Place(p);
            }
            Console.ReadKey();
        }
    }
}