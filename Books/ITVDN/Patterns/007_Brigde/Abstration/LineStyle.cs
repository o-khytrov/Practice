using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_Brigde.Abstration
{
    public abstract class LineStyle
    {
        public abstract Pen Draw(Color color);
    }
}
