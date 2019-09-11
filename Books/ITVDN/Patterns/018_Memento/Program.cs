using System;

namespace _018_Memento
{
    //Обеспечивает временное хранения состояния объекта

    //Хранитель
    internal class Backpack
    {
        public Backpack(string contents)
        {
            this.Clothes = contents;
        }

        public string Clothes { get; private set; }
    }

    //Хозяин
    internal class Man
    {
        public string Clothes { get; set; }

        public void Dress(Backpack backpack)
        {
            Clothes = backpack.Clothes;
        }

        public Backpack Undress()
        {
            return new Backpack(Clothes);
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            Man David = new Man();
            Robot Asimo = new Robot();
            David.Clothes = "Футболка, Джинсы, Кеды";
            Asimo.Backpack = David.Undress();

            David.Clothes = "Шорты спортивные";

            David.Dress(Asimo.Backpack);

            Console.ReadKey();
        }
    }

    //Посыльный
    internal class Robot
    {
        public Backpack Backpack { get; set; }
    }
}