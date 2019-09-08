using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _007_Brigde.Abstration
{
    public class Pentagon : Shape
    {
        Point[] points = new Point[]
        {
            new Point(10,10),
            new Point(10,100),
            new Point(50,65),
            new Point(100,100),
            new Point(85,40)
        };
        public override void Draw(Form form, Color color)
        {


            base.Draw(form, color);
            this.graphics = form.CreateGraphics();
            this.graphics.DrawPolygon(pen, points);

        }
    }
}
