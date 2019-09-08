using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _007_Brigde.Abstration
{
    public class Square : Shape
    {

        public override void Draw(Form form, Color color)
        {
            base.Draw(form, color);
            this.graphics = form.CreateGraphics();
            this.graphics.DrawRectangle(pen, new Rectangle(new Point(50, 50), new Size(200, 200)));
        }
    }
}
