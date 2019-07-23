using System;
using System.Drawing;

namespace LostInTheCity
{
    public static class ColorHelper
    {
        public static Random Random { get; set; }

        static ColorHelper()
        {
            Random = new Random();
        }

        public static Color GetRandomColor()
        {
            return Color.FromArgb(Random.Next(256), Random.Next(256), Random.Next(256));
        }
    }
}