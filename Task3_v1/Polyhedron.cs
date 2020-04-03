using System;
using System.Drawing;

namespace Task3_v1
{
    internal abstract class Polyhedron
    {
        public int width = 0;
        public int height = 0;
        public int depth = 0;
        public virtual Pen pen { get; set; } = Pens.Gray;
        public virtual string Name { get; set; } = "Многоугольник";

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

        public Polyhedron(int side, Math3D.Point3D origin)
        {
            width = side;
            height = side;
            depth = side;
            Origin = new Math3D.Point3D(origin.X, origin.Y, 0);
        }

        public Polyhedron(int Width, int Height, int Depth, Math3D.Point3D origin)
        {
            width = Width;
            height = Height;
            depth = Depth;
            Origin = new Math3D.Point3D(origin.X, origin.Y, 0);
        }

        public void Calculate(Point drawOrigin, Tuple<double, Pen>[,] matrix)
        {
            Math3D.Point3D point0 = new Math3D.Point3D(0, 0, 0); //Used for reference

            //Set up the cube
            Surface[] cubePoints = Surface.Move(FillVertices(width, height, depth), drawOrigin);

            //Apply Rotations, moving the cube to a corner then back to middle
            cubePoints = Surface.Translate(cubePoints, Origin, point0);
            cubePoints = Surface.RotateZ(cubePoints, zRotation); //of Gimbal Lock
            cubePoints = Surface.RotateY(cubePoints, yRotation); //rotations is the source
            cubePoints = Surface.RotateX(cubePoints, xRotation); //The order of these
            cubePoints = Surface.Translate(cubePoints, point0, Origin);

            foreach (var surface in cubePoints)
            {
                FaceMatrix(surface, matrix);
            }
        }

        public void FaceMatrix(Surface surface, Tuple<double, Pen>[,] matrix)
        {
            Polygon polygon = new Polygon(surface, pen);
            var z = polygon.Z(new Point(polygon.MinX - 1, polygon.MinY - 1));
            var zx = z;
            for (int i = polygon.MinX; i <= polygon.MaxX; i++) //TODO fix range if polygon
            {
                zx = polygon.Zx(zx);
                var zy = zx;
                for (int j = polygon.MinY; j <= polygon.MaxY; j++)
                {
                    zy = polygon.Zy(zy);
                    var position = polygon.IsPointInsidePolygon(new Point(i, j));
                    if (!position) continue;
                    var point = new Point(i, j);
                    var IN = false;

                    for (var index = 0; index < polygon.Surface.points.Length; index++)
                    {
                        if (index == polygon.Surface.points.Length - 1)
                        {
                            if (!PointInSegment(point, polygon.Surface.points[index], polygon.Surface.points[0]))
                                continue;
                            IN = true;
                            break;
                        }

                        if (!PointInSegment(point, polygon.Surface.points[index],
                            polygon.Surface.points[index + 1])) continue;
                        IN = true;
                        break;
                    }

                    if (i < 0 || j < 0 || i >= matrix.GetLength(0) || j >= matrix.GetLength(1)) continue;
                    if (matrix[i, j] == null || matrix[i, j].Item1 > zy)
                    {
                        matrix[i, j] = new Tuple<double, Pen>(zy, IN ? Pens.Black : pen);
                    }
                }
            }
        }

        private static bool PointInSegment(Point t, Math3D.Point3D p1, Math3D.Point3D p2)
        {
            double a = GetSide(t.X, t.Y, p1.X, p1.Y);
            double b = GetSide(p1.X, p1.Y, p2.X, p2.Y);
            double c = GetSide(p2.X, p2.Y, t.X, t.Y);
            return Math.Abs((a + c) - b) < 0.05;
        }

        private static double GetSide(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public abstract Surface[] FillVertices(int width, int height, int depth);
    }
}