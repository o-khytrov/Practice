using System.Drawing;
using System.Windows.Forms;

namespace _007_Brigde.Abstration
{
    public abstract class Shape
    {
        protected Graphics graphics = null;
        public LineStyle implementor = null;

        public Pen pen = null;

        public virtual void Draw(Form form, Color color)
        {
            this.graphics = form.CreateGraphics();
            this.pen = implementor.Draw(color);
        }
    }
}