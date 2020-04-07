using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task6_v2
{
    internal class Pixel3D
    {
        public double Z;
        public Color Color;

        public Pixel3D(double z, Color color)
        {
            Z = z;
            Color = color;
        }
    }

    internal class MatrixBuffer
    {
        private List<Figure> figures;

        public MatrixBuffer(List<Figure> figures)
        {
            this.figures = figures;
        }

        private new Pixel3D[,] _matrix;

        public Image render(Size screen, Math3D.Point3D point3D)
        {
            //Set the rotation values
            Bitmap img = new Bitmap(screen.Width, screen.Height);
            Graphics g = Graphics.FromImage(img);
            _matrix = new Pixel3D[screen.Width, screen.Height];
            var maxZ = 0D;
            foreach (var figure in figures)
            {
                figure.Polyhedron.RotateX = point3D.X;
                figure.Polyhedron.RotateY = point3D.Y;
                figure.Polyhedron.RotateZ = point3D.Z;
                var temp = figure.Polyhedron.Calculate(figure.DrawingOrigin, _matrix);
                if (temp > maxZ)
                {
                    maxZ = temp;
                }
            }

            for (int i = 0; i < screen.Width; i++)
            {
                for (int j = 0; j < screen.Height; j++)
                {
                    if (_matrix[i, j] != null)
                        g.DrawEllipse(new Pen(ControlPaint.Dark(_matrix[i, j].Color, (float)(_matrix[i, j].Z / 600)), 1), new Rectangle(i, j, 1, 1));
                }
            }
            g.Dispose(); //Clean-up
            return img;
        }
    }
}