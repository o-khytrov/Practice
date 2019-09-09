﻿using System;

namespace _012_Proxy
{
    public interface IHuman
    {
        void Request();
    }

    internal class Operator : IHuman
    {
        public void Request()
        {
            Console.WriteLine("Operator");
        }
    }

    internal class Surrogate : IHuman
    {
        private IHuman @operator;

        public Surrogate(IHuman @operator)
        {
            this.@operator = @operator;
        }

        public void Request()
        {
            this.@operator.Request();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            IHuman bruce = new Operator();
            IHuman surrogate = new Surrogate(bruce);
            surrogate.Request();
        }
    }
}