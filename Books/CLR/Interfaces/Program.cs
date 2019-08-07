using System;

namespace Interfaces
{
    public interface ISumator
    {
        int Calculate(int a, int b);
    }

    public interface IMultiplyer
    {
        int Calculate(int a, int b);
    }

    public class Calculator : ISumator, IMultiplyer
    {
        int IMultiplyer.Calculate(int a, int b)
        {
            return a * b;
        }

         int ISumator.Calculate(int a, int b)
        {
            return a + b;
        }
    }
    public class ProCalculator : Calculator
    {

    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var calc = new Calculator();
            var a = 5;
            var b = 8;
            Console.WriteLine((calc as IMultiplyer).Calculate(a, b));
            Console.WriteLine((calc as ISumator).Calculate(a, b));

            var proCalc = new ProCalculator();
            Console.WriteLine((proCalc as IMultiplyer).Calculate(a, b));
            Console.WriteLine((proCalc as ISumator).Calculate(a, b));

            Console.ReadKey();
        }
    }
}