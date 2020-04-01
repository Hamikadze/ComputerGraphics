using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5_v2
{
    internal abstract class Polyhedron
    {
        public int width = 0;
        public int height = 0;
        public int depth = 0;
        public Pen pen;

        private double xRotation = 0D;
        private double yRotation = 0D;
        private double zRotation = 0D;

        public Math3D.Point3D Origin;

        public double RotateX
        {
            get => xRotation;
            set => xRotation = value;
        }

        public double RotateY
        {
            get => yRotation;
            set => yRotation = value;
        }

        public double RotateZ
        {
            get => zRotation;
            set => zRotation = value;
        }

        public Polyhedron(int side)
        {
            width = side;
            height = side;
            depth = side;
            Origin = new Math3D.Point3D(width / 2, height / 2, depth / 2);
        }

        public Polyhedron(int side, Math3D.Point3D origin)
        {
            width = side;
            height = side;
            depth = side;
            Origin = origin;
        }

        public Polyhedron(int Width, int Height, int Depth)
        {
            width = Width;
            height = Height;
            depth = Depth;
            Origin = new Math3D.Point3D(width / 2, height / 2, depth / 2);
        }

        public Polyhedron(int Width, int Height, int Depth, Math3D.Point3D origin)
        {
            width = Width;
            height = Height;
            depth = Depth;
            Origin = origin;
        }

        public void Calculate(Bitmap img, Point drawOrigin, Dictionary<Point, Tuple<double, Pen>> matrix)
        {
            Math3D.Point3D point0 = new Math3D.Point3D(img.Width / 2 - drawOrigin.X, drawOrigin.Y - img.Height / 2, 0); //Used for reference

            //Zoom factor is set with the monitor width to keep the cube from being distorted
            double zoom = Screen.PrimaryScreen.Bounds.Width / 1.5;

            //Set up the cube
            Surface[] cubePoints = fillVertices(width, height, depth);

            //Apply Rotations, moving the cube to a corner then back to middle
            cubePoints = Surface.Translate(cubePoints, Origin, point0);
            cubePoints = Surface.RotateZ(cubePoints, zRotation); //of Gimbal Lock
            cubePoints = Surface.RotateY(cubePoints, yRotation); //rotations is the source
            cubePoints = Surface.RotateX(cubePoints, xRotation); //The order of these
            cubePoints = Surface.Translate(cubePoints, point0, Origin);

            foreach (var surface in cubePoints)
            {
                FaceMatrix(surface, drawOrigin, matrix);
            }
        }

        public void FaceMatrix(Surface surface, Point drawOrigin, Dictionary<Point, Tuple<double, Pen>> matrix)
        {
            Polygon polygon = new Polygon(surface, pen);
            var z = polygon.Z(new Point(polygon.minX - 1, polygon.minY - 1));
            var zx = z;
            for (int i = polygon.minX; i <= polygon.maxX; i++) //TODO fix range if polygon
            {
                zx = polygon.Zx(zx);
                var zy = zx;
                for (int j = polygon.minY; j <= polygon.maxY; j++)
                {
                    zy = polygon.Zy(zy);
                    var position = polygon.IsPointInsidePolygon(new Point(i, j));
                    if (position)
                    {
                        var point = new Point(i, j);
                        var IN = false;

                        for (var index = 0; index < polygon.Surface.points.Length; index++)
                        {
                            if (index == polygon.Surface.points.Length - 1)
                            {
                                if (point_in_segment(point, polygon.Surface.points[index], polygon.Surface.points[0]))
                                {
                                    IN = true;
                                    break;
                                }
                            }
                            else
                            if (point_in_segment(point, polygon.Surface.points[index], polygon.Surface.points[index + 1]))
                            {
                                IN = true;
                                break;
                            }
                        }

                        if (matrix.TryGetValue(point, out Tuple<double, Pen> rValue))
                        {
                            if (rValue.Item1 > zy)
                            {
                                matrix[point] = new Tuple<double, Pen>(zy, IN ? Pens.Black : pen);
                            }
                        }
                        else
                        {
                            matrix.Add(point, new Tuple<double, Pen>(zy, IN ? Pens.Black : pen));
                        }
                    }
                }
            }
        }

        private bool point_in_segment(Point t, Math3D.Point3D p1, Math3D.Point3D p2)
        {
            double a = GetSide(t.X, t.Y, p1.X, p1.Y);
            double b = GetSide(p1.X, p1.Y, p2.X, p2.Y);
            double c = GetSide(p2.X, p2.Y, t.X, t.Y);
            return Math.Abs((a + c) - b) < 0.05;
        }

        private static double GetSide(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public PointF[] FaceCube(Surface surface, Point drawOrigin)
        {
            //Convert 3D Points to 2D
            var degrees = 35;
            double cDegrees = (Math.PI * degrees) / 180.0;
            var values = surface.points.Select(vec => new PointF(
                (float)(Math.Cos(cDegrees) * vec.X - Math.Cos(cDegrees) * vec.Y) + drawOrigin.X,
                (float)(Math.Sin(cDegrees) * vec.X + Math.Sin(cDegrees) * vec.Y - vec.Z) + drawOrigin.Y
            )).ToList();

            values.Add(values.First());
            return values.ToArray();
        }

        public abstract Surface[] fillVertices(int width, int height, int depth);
    }
}