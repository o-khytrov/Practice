using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _007_Brigde.Abstration
{
    public class Triangle : Shape
    {
        Point[] points = new Point[]
        {
            new Point(50,50),
            new Point(50,200),
            new Point(200,200)
        };
        public override void Draw(Form form, Color color)
        {
            base.Draw(form, color);
            this.graphics = form.CreateGraphics();
            this.graphics.DrawPolygon(pen, points);
        }
    }
}
