using System;
using System.Drawing;
using System.Windows.Forms;

namespace LostInTheCity
{
    public partial class Main : Form
    {
        public Processor Processor { get; set; }

        public Main()
        {
            InitializeComponent();
            SetupPictureBoxes();
            Processor = new Processor();
        }

        private void SetupPictureBoxes()
        {
            panel1.AutoScroll = true;

            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            panel2.AutoScroll = true;
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;

            pictureBox1.Image = new Bitmap(2000, 2000);
            pictureBox2.Image = new Bitmap(10000, 10000);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var x = (int)Math.Floor((double)e.X / 60) + 1;
            var y = (int)Math.Floor((double)e.Y / 60) + 1;
            var currentPoint = new Point(x, y);
        }
    }
}