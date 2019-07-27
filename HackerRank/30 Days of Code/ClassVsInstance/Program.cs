using System;
using System.IO;

namespace ClassVsInstance
{
    public class Person
    {
        public int age { get; set; }

        public Person(int age)
        {
            if (age > 0)
            {
                this.age = age;
            }
            else
            {
                this.age = 0;
                Console.WriteLine("Age is not valid, setting age to 0.");
            }
        }

        public void yearPasses()
        {
            age++;
        }

        public void amIOld()
        {
            if (age < 13)
            {
                Console.WriteLine("You are young.");
            }
            else if (age >= 13 && age < 18)
            {
                Console.WriteLine("You are a teenager.");
            }
            else
            {
                Console.WriteLine("You are old.");
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));
            int T = int.Parse(Console.In.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int age = int.Parse(Console.In.ReadLine());
                Person p = new Person(age);
                p.amIOld();
                for (int j = 0; j < 3; j++)
                {
                    p.yearPasses();
                }
                p.amIOld();
                Console.WriteLine();

                Console.ReadKey();
            }
        }
    }
}