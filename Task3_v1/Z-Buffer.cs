using System;
using System.Collections.Generic;
using System.Drawing;

namespace Task3_v1
{
    internal class Z_Buffer
    {
        private List<Figure> figures;

        public Z_Buffer(List<Figure> figures)
        {
            this.figures = figures;
        }

        private new Tuple<double, Pen>[,] _matrix;

        public Image render(Size screen, Math3D.Point3D point3D)
        {
            //Set the rotation values
            Bitmap img = new Bitmap(screen.Width, screen.Height);
            Graphics g = Graphics.FromImage(img);
            _matrix = new Tuple<double, Pen>[screen.Width, screen.Height];

            foreach (var figure in figures)
            {
                figure.Polyhedron.RotateX = point3D.X;
                figure.Polyhedron.RotateY = point3D.Y;
                figure.Polyhedron.RotateZ = point3D.Z;

                figure.Polyhedron.Calculate(figure.DrawingOrigin, _matrix);
            }

            for (int i = 0; i < screen.Width; i++)
            {
                for (int j = 0; j < screen.Height; j++)
                {
                    if (_matrix[i, j] != null)
                        g.DrawEllipse(_matrix[i, j].Item2, new Rectangle(i, j, 1, 1));
                }
            }
            g.Dispose(); //Clean-up
            return img;
        }
    }
}