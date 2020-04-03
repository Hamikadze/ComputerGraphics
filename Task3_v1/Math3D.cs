using System;
using System.Drawing;

namespace Task3_v1
{
    internal class Math3D
    {
        public class Point3D
        {
            //The Point3D class is rather simple, just keeps track of X Y and Z values,
            //and being a class it can be adjusted to be comparable
            public int X;

            public int Y;
            public int Z;

            public Point3D(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public Point3D(double x, double y, double z)
            {
                X = (int)x;
                Y = (int)y;
                Z = (int)z;
            }

            public Point3D(decimal x, decimal y, decimal z)
            {
                X = (int)x;
                Y = (int)y;
                Z = (int)z;
            }

            public Point3D()
            {
            }

            public override string ToString()
            {
                return "(" + X + ", " + Y + ", " + Z + ")";
            }

            public Point To2D()
            {
                return new Point(this.X + this.Y, this.Z + this.Y);
            }
        }

        internal class Line3D
        {
            public Point3D Point1;
            public Point3D Point2;

            public Line3D(Math3D.Point3D point1, Math3D.Point3D point2)
            {
                Point1 = point1;
                Point2 = point2;
            }

            public double GetSide()
            {
                return Math.Sqrt(Math.Pow(Point2.X - Point1.X, 2) + Math.Pow(Point2.Y - Point1.Y, 2) + Math.Pow(Point2.Z - Point1.Z, 2));
            }

            public Math3D.Point3D GetVector3D()
            {
                return new Math3D.Point3D(Point2.X - Point1.X, Point2.Y - Point1.Y, Point2.Z - Point1.Z);
            }
        }

        public class Camera
        {
            //For 3D drawing we need a point of perspective, thus the Camera
            public Point3D Position = new Point3D();
        }

        public static Point3D RotateX(Point3D point3D, double degrees)
        {
            //Here we use Euler's matrix formula for rotating a 3D point x degrees around the x-axis

            //[ 1    0        0   ]
            //[ 0   cos(x)  -sin(x)]
            //[ 0   sin(x) cos(x)]

            double cDegrees = (Math.PI * degrees) / 180.0f; //Convert degrees to radian for .Net Cos/Sin functions
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            int y = (int)((point3D.Y * cosDegrees) + (point3D.Z * -sinDegrees));
            int z = (int)((point3D.Y * sinDegrees) + (point3D.Z * cosDegrees));

            return new Point3D(point3D.X, y, z);
        }

        public static Point3D RotateY(Point3D point3D, double degrees)
        {
            //Y-axis

            //[ cos(x)   0    sin(x)]
            //[   0      1      0   ]
            //[-sin(x)   0    cos(x)]

            double cDegrees = (Math.PI * degrees) / 180.0; //Radians
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            int x = (int)((point3D.X * cosDegrees) + (point3D.Z * sinDegrees));
            int z = (int)((point3D.X * -sinDegrees) + (point3D.Z * cosDegrees));

            return new Point3D(x, point3D.Y, z);
        }

        public static Point3D RotateZ(Point3D point3D, double degrees)
        {
            //Z-axis

            //[ cos(x)  -sin(x) 0]
            //[ sin(x) cos(x) 0]
            //[    0     0     1]

            double cDegrees = (Math.PI * degrees) / 180.0; //Radians
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            int x = (int)((point3D.X * cosDegrees) + (point3D.Y * -sinDegrees));
            int y = (int)((point3D.X * sinDegrees) + (point3D.Y * cosDegrees));

            return new Point3D(x, y, point3D.Z);
        }

        public static Point3D Translate(Point3D points3D, Point3D oldOrigin, Point3D newOrigin)
        {
            //Moves a 3D point based on a moved reference point
            Point3D difference = new Point3D(newOrigin.X - oldOrigin.X, newOrigin.Y - oldOrigin.Y, newOrigin.Z - oldOrigin.Z);
            points3D.X += difference.X;
            points3D.Y += difference.Y;
            points3D.Z += difference.Z;
            return points3D;
        }

        public static Point3D Move(Point3D point3D, Point drawOrigin)
        {
            point3D.X += drawOrigin.X;
            point3D.Y += drawOrigin.Y;
            return point3D;
        }

        //These are to make the above functions workable with arrays of 3D points
        public static Point3D[] RotateX(Point3D[] points3D, double degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = RotateX(points3D[i], degrees);
            }
            return points3D;
        }

        public static Point3D[] RotateY(Point3D[] points3D, double degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = RotateY(points3D[i], degrees);
            }
            return points3D;
        }

        public static Point3D[] RotateZ(Point3D[] points3D, double degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = RotateZ(points3D[i], degrees);
            }
            return points3D;
        }

        public static Point3D[] Translate(Point3D[] points3D, Point3D oldOrigin, Point3D newOrigin)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = Translate(points3D[i], oldOrigin, newOrigin);
            }
            return points3D;
        }

        public static Point3D[] Move(Point3D[] points3D, Point drawOrigin)
        {
            for (var i = 0; i < points3D.Length; i++)
            {
                points3D[i] = Move(points3D[i], drawOrigin);
            }

            return points3D;
        }

        public static Line3D RotateX(Line3D line3D, double degrees)
        {
            line3D.Point1 = RotateX(line3D.Point1, degrees);
            line3D.Point2 = RotateX(line3D.Point2, degrees);
            return line3D;
        }

        public static Line3D RotateY(Line3D line3D, double degrees)
        {
            line3D.Point1 = RotateY(line3D.Point1, degrees);
            line3D.Point2 = RotateY(line3D.Point2, degrees);
            return line3D;
        }

        public static Line3D RotateZ(Line3D line3D, double degrees)
        {
            line3D.Point1 = RotateZ(line3D.Point1, degrees);
            line3D.Point2 = RotateZ(line3D.Point2, degrees);
            return line3D;
        }

        public static Line3D Translate(Line3D line3D, Point3D oldOrigin, Point3D newOrigin)
        {
            line3D.Point1 = Translate(line3D.Point1, oldOrigin, newOrigin);
            line3D.Point2 = Translate(line3D.Point2, oldOrigin, newOrigin);
            return line3D;
        }

        public static Line3D Move(Line3D line3D, Point drawOrigin)
        {
            line3D.Point1 = Move(line3D.Point1, drawOrigin);
            line3D.Point2 = Move(line3D.Point2, drawOrigin);
            return line3D;
        }
    }
}