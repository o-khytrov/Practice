using System.Collections.Generic;
using System.Drawing;

namespace LostInTheCity
{
    public class Canopy
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public int Rate { get; set; }
        public Color Color { get; set; }
        public int Index { get; set; }
        public override string ToString()
        {
            return $"{P1.X} {P1.Y} {P2.X} {P2.Y}";
        }
    }
    

}
