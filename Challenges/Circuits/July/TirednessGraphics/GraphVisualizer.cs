using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace LostInTheCity
{
    public class GraphVisualizer : IDisposable
    {
        public Graph Graph { get; set; }

        public static Pen BlackPen { get; set; }
        public static StringFormat StringFormat { get; set; }
        public static Font NodeNameFont { get; set; }
        public static Font EdgeWeightFont { get; set; }

        private static Graphics Graphics { get; set; }
        private static Single VertexRadius { get; set; }
        private static Bitmap Bitmap { get; set; }

        public GraphVisualizer()
        {
            Bitmap = new Bitmap(2000, 2000);
            Graphics = Graphics.FromImage(Bitmap);
            Graphics.ScaleTransform(100.0f, 100.0f);

            BlackPen = new Pen(Color.Black, 0.01f);

            StringFormat = new StringFormat();
            StringFormat.LineAlignment = StringAlignment.Center;
            StringFormat.Alignment = StringAlignment.Center;
            NodeNameFont = new Font("Arial", 0.3f); ;
            EdgeWeightFont = new Font("Arial", 0.1f); ;

            VertexRadius = 0.5f;
        }

        public Bitmap Visualize()
        {
            foreach (var kvp in Graph.Vertices)
                DrawVertex(kvp.Value);

            return Bitmap;
        }

        private static void DrawVertex(GraphVertex v)
        {
            using (GraphicsPath capPath = new GraphicsPath())
            {
                var color = ColorHelper.GetRandomColor();
                var brush = new SolidBrush(color);
                var pen = new Pen(color, 0.03f);
                var point = GetVertexTopLeftPoint(v);
                var centerPoint = VertexCenterPoint(point);
                var rect = new RectangleF(point.X, point.Y, 1, 1);
                int edgeCounterH = 1;
                int edgeCounterV = 1;
                capPath.AddLine(-1, -2, 1, -2);
                capPath.AddLine(-1, -2, 0, 0);
                capPath.AddLine(1, -2, 0, 0);

                pen.CustomEndCap = new CustomLineCap(null, capPath);
                foreach (var e in v.Edges)
                {
                    var connectionPoint = VertexCenterPoint(GetVertexTopLeftPoint(e.ConnectedVertex));
                    var from = centerPoint;
                    var offsetV = 0.1f * edgeCounterV;
                    var offsetH = 0.1f * edgeCounterH;
                    if (connectionPoint.X > centerPoint.X)
                    {
                        from.X += VertexRadius;
                        connectionPoint.X -= VertexRadius;
                        edgeCounterV++;
                        connectionPoint.Y += offsetV;
                        from.Y += offsetV;
                    }
                    else if (connectionPoint.X < centerPoint.X)
                    {
                        from.X -= VertexRadius;
                        connectionPoint.X += VertexRadius;
                    }

                    if (connectionPoint.Y > from.Y)
                    {
                        from.Y += VertexRadius;
                        connectionPoint.Y -= VertexRadius;
                        edgeCounterH++;
                        connectionPoint.X += offsetH;
                        from.X += offsetH;
                    }
                    else if ((connectionPoint.Y < from.Y))
                    {
                        from.Y -= VertexRadius;
                        connectionPoint.Y += VertexRadius;
                    }

                    Graphics.DrawLine(pen, from, connectionPoint);
                    Graphics.DrawString(e.EdgeWeight.ToString(), EdgeWeightFont, brush, new RectangleF(from.X, from.Y, 2, 2));
                }

                Graphics.DrawEllipse(pen, rect);
                Graphics.DrawString(v.Name, NodeNameFont, Brushes.Black, rect, StringFormat);
            }
        }

        private static PointF VertexCenterPoint(PointF p)
        {
            return new PointF(p.X + VertexRadius, p.Y + VertexRadius);
        }

        private static PointF GetVertexTopLeftPoint(GraphVertex v)
        {
            var coordinates = v.Name.Split(':').Select(x => Int32.Parse(x.Trim())).ToArray();
            var point = new PointF(coordinates[0] * 2 - 1, coordinates[1] * 2 - 1);
            return point;
        }

        public void Dispose()
        {
            Graphics.Dispose();
            BlackPen.Dispose();
            NodeNameFont.Dispose();
            EdgeWeightFont.Dispose();
        }
    }
}