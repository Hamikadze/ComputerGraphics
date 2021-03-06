﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    internal class Math3D
    {
        public class Point3D
        {
            //The Point3D class is rather simple, just keeps track of X Y and Z values,
            //and being a class it can be adjusted to be comparable
            public double X;

            public double Y;
            public double Z;

            public Point3D(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public Point3D(float x, float y, float z)
            {
                X = (double)x;
                Y = (double)y;
                Z = (double)z;
            }

            public Point3D(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public Point3D()
            {
            }

            public override string ToString()
            {
                return "(" + X + ", " + Y + ", " + Z + ")";
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

            double cDegrees = Math.PI * degrees / 180.0f; //Convert degrees to radian for .Net Cos/Sin functions
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double y = point3D.Y * cosDegrees + point3D.Z * -sinDegrees;
            double z = point3D.Y * sinDegrees + point3D.Z * cosDegrees;

            return new Point3D(point3D.X, y, z);
        }

        public static Point3D RotateY(Point3D point3D, double degrees)
        {
            //Y-axis

            //[ cos(x)   0    sin(x)]
            //[   0      1      0   ]
            //[-sin(x)   0    cos(x)]

            double cDegrees = Math.PI * degrees / 180.0; //Radians
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double x = point3D.X * cosDegrees + point3D.Z * sinDegrees;
            double z = point3D.X * -sinDegrees + point3D.Z * cosDegrees;

            return new Point3D(x, point3D.Y, z);
        }

        public static Point3D RotateZ(Point3D point3D, double degrees)
        {
            //Z-axis

            //[ cos(x)  -sin(x) 0]
            //[ sin(x) cos(x) 0]
            //[    0     0     1]

            double cDegrees = Math.PI * degrees / 180.0; //Radians
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double x = point3D.X * cosDegrees + point3D.Y * -sinDegrees;
            double y = point3D.X * sinDegrees + point3D.Y * cosDegrees;

            return new Point3D(x, y, point3D.Z);
        }

        public static Point3D RotateM(Point3D point3D, Point3D rVector, double degrees)
        {
            //Y-axis

            //[ cos(x)   0    sin(x)]
            //[   0      1      0   ]
            //[-sin(x)   0    cos(x)]

            double cDegrees = Math.PI * degrees / 180.0; //Radians
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double x = point3D.X * (cosDegrees + (1 - cosDegrees) * Math.Pow(rVector.X, 2)) +
                       point3D.Y * ((1 - cosDegrees) * rVector.X * rVector.Y - sinDegrees * rVector.Z) +
                       point3D.Z * ((1 - cosDegrees) * rVector.X * rVector.Z + sinDegrees * rVector.Y);
            double y = point3D.X * ((1 - cosDegrees) * rVector.Y * rVector.X + sinDegrees * rVector.Z) +
                       point3D.Y * (cosDegrees + (1 - cosDegrees) * Math.Pow(rVector.Y, 2)) +
                       point3D.Z * ((1 - cosDegrees) * rVector.Y * rVector.Z - sinDegrees * rVector.X);
            double z = point3D.X * ((1 - cosDegrees) * rVector.Z * rVector.X - sinDegrees * rVector.Y) +
                       point3D.Y * ((1 - cosDegrees) * rVector.Z * rVector.Y - sinDegrees * rVector.X) +
                       point3D.Z * (cosDegrees + (1 - cosDegrees) * Math.Pow(rVector.Z, 2));

            return new Point3D(x, y, z);
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

        public static Point3D[] RotateM(Point3D[] points3D, Point3D rVector, double degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = RotateM(points3D[i], rVector, degrees);
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
    }
}