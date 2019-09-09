using System;

namespace _014_Command
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            var calculator = new Calculator();
            int result = 0;

            result = calculator.Add(5);
            Console.WriteLine(result);

            result = calculator.Sub(1);
            Console.WriteLine(result);

            result = calculator.Mul(2);
            Console.WriteLine(result);

            result = calculator.Add(2);
            Console.WriteLine(result);

            result = calculator.Redo(1);
            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}