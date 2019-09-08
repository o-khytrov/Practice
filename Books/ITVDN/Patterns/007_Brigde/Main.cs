using _007_Brigde.Abstration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _007_Brigde
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.Text = "Brigde";
            this.BackColor = Color.White;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Figure.Draw(this, new Triangle(), new DashDotLine(), Color.Turquoise);
            Figure.Draw(this, new Pentagon(), new DotLine(), Color.Blue);
        }
    }
}
