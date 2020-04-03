using System;
using System.Drawing;

namespace Task3_v1
{
    internal class Line
    {
        public Point Point1;
        public Point Point2;

        public Line(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public double GetSide()
        {
            return Math.Sqrt(Math.Pow(Point2.X - Point1.X, 2) + Math.Pow(Point2.Y - Point1.Y, 2));
        }

        public Point GetVector3D()
        {
            return new Point(Point2.X - Point1.X, Point2.Y - Point1.Y);
        }
    }
}