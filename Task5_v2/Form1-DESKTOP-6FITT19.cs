using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Polygon triangle = new Polygon(new[]{
                new PointF(0, 0),
                new PointF(0, 2),
                new PointF(1, 0)   }, Pens.Blue);
            Polygon rectangle = new Polygon(new[]
            {
                new PointF(0, 1),
                new PointF(0, 2),
                new PointF(2, 2),
                new PointF(2, 1),
            }, Pens.Red);
            Polygon poly5 = new Polygon(new[]
            {
                new PointF(1, 1),
                new PointF(1, 2),
                new PointF(2, 3),
                new PointF(2, 2),
                new PointF(2, 1),
            }, Pens.Gold);
            List<Polygon> polygons = new List<Polygon>() { triangle, rectangle, poly5 };

            Matrix matrix = new Matrix();
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);

            List<int> temp = new List<int>();

            for (int x = 0; x < bmp.Height; x++)
            {
                for (int y = 0; y < bmp.Width; y++)
                {
                    double[] z = new double[polygons.Count];
                    for (var index = 0; index < polygons.Count; index++)
                    {
                        var polygon = polygons[index];
                        if (polygon.PnPoly(polygon.points, new PointF(x, y)))
                        {
                            z[index] = matrix.Z(new PointF(x, y), polygon.surface.points);

                            temp.Add((int)z[index]);
                        }
                        else
                        {
                            z[index] = double.MinValue;
                        }
                    }

                    if (z.Any(i => i != Double.MinValue))
                    {
                        var i = z.ToList().IndexOf(z.Max());
                        g.DrawEllipse(polygons[i].pen, new Rectangle(x * 30, y * 30, 30, 30));
                    }
                }
            }

            pictureBox1.Image = bmp;
        }
    }
}