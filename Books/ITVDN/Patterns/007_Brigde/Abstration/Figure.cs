using System.Drawing;
using System.Windows.Forms;

namespace _007_Brigde.Abstration
{
    // Назначение паттерна Bridge это отделить абстракцию от реализации и создать возможность их независимого использования


    internal class Figure
    {
        public static void Draw(Form form, Shape shape, LineStyle lineStyle, Color color)
        {
            shape.implementor = lineStyle;
            shape.Draw(form, color);
        }
    }
}