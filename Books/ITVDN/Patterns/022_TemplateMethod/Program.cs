using System;

namespace _022_TemplateMethod
{
    // Шаблонный метод  в абстрактном классе задает последовательность шагов для формирования низкоуровневого алгоритма,
    //которые реализуються в конкретных классах

    //Позволяет разделить высокоуровневую реализацию от низкоуровневой
    internal abstract class TwoColorFlag
    {
        public void Draw()
        {
            DrawTopPart();
            DrawBottomPart();
        }

        protected abstract void DrawTopPart();

        protected abstract void DrawBottomPart();
    }

    internal class PolandFlag : TwoColorFlag
    {
        protected override void DrawTopPart()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(new string(' ', 7));
        }

        protected override void DrawBottomPart()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(new string(' ', 7));
        }
    }

    internal class GaitiFlag : TwoColorFlag
    {
        protected override void DrawTopPart()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string(' ', 7));
        }

        protected override void DrawBottomPart()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(new string(' ', 7));
        }
    }

    internal class UkraineFlag : TwoColorFlag
    {
        protected override void DrawBottomPart()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string(' ', 7));
        }

        protected override void DrawTopPart()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string(' ', 7));
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var flag = new UkraineFlag();
            flag.Draw();

            Console.WriteLine();
            var pFlag = new PolandFlag();
            pFlag.Draw();

            Console.WriteLine();
            var gFlag = new GaitiFlag();
            gFlag.Draw();
            Console.ReadKey();
        }
    }
}