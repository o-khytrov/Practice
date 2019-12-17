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

namespace JackIsAwesome
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dict1 = new Dictionary<char, int>();
            var dict2 = new Dictionary<int, char>();
            var c = 'a';
            for (int i = 1; i < 27; i++)
            {
                dict1.Add(c, i);
                dict2.Add(i, c);
                c++;
            }
            Console.SetIn(new StreamReader(@"Console.txt"));
            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var s1 = Console.ReadLine();
                var reversed = s1.ToCharArray().Reverse().ToArray();
                var arr = s1.ToCharArray();
                var ret = new char[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    var index = (dict1[arr[i]] + dict1[reversed[i]]);
                    if (index > dict1.Count())
                    {
                        index = index - dict1.Count();
                    }
                    ret[i] += dict2[index];
                }
                Console.WriteLine(new string(ret));
            }
            Console.ReadKey();
        }
    }
}