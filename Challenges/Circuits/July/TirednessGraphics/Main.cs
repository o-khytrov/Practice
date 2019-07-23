using System;
using System.Drawing;
using System.Windows.Forms;

namespace LostInTheCity
{
    public partial class Main : Form
    {
        public Processor Processor { get; set; }
        public GraphVisualizer Visualizer { get; set; }

        public Main()
        {
            InitializeComponent();
            SetupPictureBoxes();
            Processor = new Processor();
            Processor.Proces();
            DrawGrid();
            VisualizeGraph();

        }

        private void VisualizeGraph()
        {
            using (var visualization = new GraphVisualizer())
            {
                visualization.Graph = Processor.Graph;

                pictureBox2.Image = visualization.Visualize();
            }
        }

        private void DrawGrid()
        {
            using (var visualizer = new GridVisualizer())
            {
                visualizer.Start = Processor.Start;
                visualizer.Destination = Processor.Destination;
                visualizer.Canopies = Processor.Canopies;
                visualizer.Path = Processor.Path;
                pictureBox1.Image = visualizer.Visualize();
            }
            var answer = Processor.Answer();
            var srtAnwer = string.Join(Environment.NewLine, answer.ToArray());
            MessageBox.Show(srtAnwer);
        }

        private void DrawnewPath()
        {
            using (var visualizer = new GridVisualizer())
            {
                visualizer.Start = Processor.Start;
                visualizer.Destination = Processor.Destination;
                visualizer.Path = Processor.Path;
                pictureBox1.Image = visualizer.VisualizePath();
            }
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

            if (e.Button == MouseButtons.Right)
            {
                var menuItems = new MenuItem[]{
                    new MenuItem("Start", (o, args) => { Processor.Start = currentPoint;  Processor.Proces(); DrawGrid(); }),
                    new MenuItem("Destination", (o, args) => {Processor.Destination = currentPoint; Processor.Proces();  DrawGrid(); }),
                };

                var buttonMenu = new ContextMenu(menuItems);
                buttonMenu.Show((PictureBox)sender, new Point(e.X, e.Y));
            }
        }
    }
}