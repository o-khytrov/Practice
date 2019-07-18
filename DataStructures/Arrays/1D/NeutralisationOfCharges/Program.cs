using System;
using System.IO;

namespace NeutralisationOfCharges
{
    internal class Program
    {
        private static String stack = "";
        private static int top = 0;

        public static void remove(String a)
        {
            stack = a.Substring(0, a.Length - 1);
            top--;
        }

        public static void add(char a)
        {
            stack += a;
            top++;
        }

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine().Trim());
            var s = Console.ReadLine().ToCharArray();

            for (int i = 0; i < s.Length; i++)
            {
                var t = s[i];
                if (top != 0 && stack[top - 1] == t)
                {
                    remove(stack);
                }
                else
                {
                    add(t);
                }
            }
            Console.WriteLine(stack.Length);
            Console.WriteLine(stack);
            Console.ReadKey();
        }
    }
}