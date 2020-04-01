using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_v2
{
    internal class Polygon
    {
        private double a;
        private double b;
        private double c;
        private double d;
        public int Width = 0;
        public int Height = 0;
        public int minX = 0;
        public int maxX = 0;
        public int minY = 0;
        public int maxY = 0;
        private Math3D.Point3D polyOrigin;

        public Surface Surface;
        private int _vertex;
        public Pen Pen;

        public Polygon(Surface surface, Pen pen)
        {
            this.Pen = pen;
            _vertex = surface.points.Length;
            Surface = surface;

            Width = (surface.points.Max(x => x.X) - surface.points.Min(x => x.X));
            Height = (surface.points.Max(x => x.Y) - surface.points.Min(x => x.Y));

            minX = surface.points.Min(x => x.X);
            maxX = surface.points.Max(x => x.X);
            minY = surface.points.Min(x => x.Y);
            maxY = surface.points.Max(x => x.Y);
        }

        public bool IsPointInsidePolygon(Point point)
        {
            float x = point.X;
            float y = point.Y;
            int n;
            bool flag = false;
            for (n = 0; n < Surface.points.Length; n++)
            {
                flag = false;
                var i1 = n < Surface.points.Length - 1 ? n + 1 : 0;
                while (true)
                {
                    var i2 = i1 + 1;
                    if (i2 >= Surface.points.Length)
                        i2 = 0;
                    if (i2 == (n < Surface.points.Length - 1 ? n + 1 : 0))
                        break;
                    var s = Math.Abs(Surface.points[i1].X * (Surface.points[i2].Y - Surface.points[n].Y) +
                                     Surface.points[i2].X * (Surface.points[n].Y - Surface.points[i1].Y) +
                                     Surface.points[n].X * (Surface.points[i1].Y - Surface.points[i2].Y));
                    var s1 = (int)Math.Abs(Surface.points[i1].X * (Surface.points[i2].Y - y) +
                                           Surface.points[i2].X * (y - Surface.points[i1].Y) +
                                           x * (Surface.points[i1].Y - Surface.points[i2].Y));
                    var s2 = (int)Math.Abs(Surface.points[n].X * (Surface.points[i2].Y - y) +
                                           Surface.points[i2].X * (y - Surface.points[n].Y) +
                                           x * (Surface.points[n].Y - Surface.points[i2].Y));
                    var s3 = (int)Math.Abs(Surface.points[i1].X * (Surface.points[n].Y - y) +
                                           Surface.points[n].X * (y - Surface.points[i1].Y) +
                                           x * (Surface.points[i1].Y - Surface.points[n].Y));
                    if (s == (s1 + s2 + s3))
                    {
                        flag = true;
                        break;
                    }
                    i1 += 1;
                    if (i1 >= Surface.points.Length)
                        i1 = 0;
                }
                if (!flag)
                    break;
            }
            return flag;
        }

        //public bool IsPointInsidePolygon(Point point)
        //{
        //    bool c = false;
        //    for (int i = 0, j = Surface.points.Length - 1; i < Surface.points.Length; j = i++)
        //    {
        //        if ((Surface.points[i].Y <= point.Y && point.Y < Surface.points[j].Y ||
        //             Surface.points[j].Y <= point.Y && point.Y < Surface.points[i].Y) &&
        //            Surface.points[j].Y - Surface.points[i].Y != 0 &&
        //            point.X > (Surface.points[j].X - Surface.points[i].X) * (point.Y - Surface.points[i].Y) / (Surface.points[j].Y - Surface.points[i].Y) + Surface.points[i].X)
        //            c = !c;
        //    }
        //    return c;
        //}

        //Уровнение точки Z
        public double Z(Point point)
        {
            int x1 = (int)Surface.points[0].X;
            int y1 = (int)Surface.points[0].Y;
            int z1 = (int)Surface.points[0].Z;

            int x2 = (int)Surface.points[1].X;
            int y2 = (int)Surface.points[1].Y;
            int z2 = (int)Surface.points[1].Z;

            int x3 = (int)Surface.points[2].X;
            int y3 = (int)Surface.points[2].Y;
            int z3 = (int)Surface.points[2].Z;

            int x = point.X;
            int y = point.Y;

            a = y1 * (z2 - z3) + y2 * (z3 - z1) + y3 * (z1 - z2);
            b = z1 * (x2 - x3) + z2 * (x3 - x1) + z3 * (x1 - x2);
            c = x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2);
            d = -(x1 * (y2 * z3 - y3 * z2) + x2 * (y3 * z1 - y1 * z3) + x3 * (y1 * z2 - y2 * z1));

            double z = -(a * x + b * y + d) / c;

            return z;
        }

        public double Zx(double Z)
        {
            return Z - a / c;
        }

        public double Zy(double Z)
        {
            return Z - b / c;
        }

        ////Уровнение поверхности
        //public double Det(Point point)
        //{
        //    int x1 = (int)Surface.points[0].X;
        //    int y1 = (int)Surface.points[0].Y;
        //    int z1 = (int)Surface.points[0].Z;

        //    int x2 = (int)Surface.points[1].X;
        //    int y2 = (int)Surface.points[1].Y;
        //    int z2 = (int)Surface.points[1].Z;

        //    int x3 = (int)Surface.points[2].X;
        //    int y3 = (int)Surface.points[2].Y;
        //    int z3 = (int)Surface.points[2].Z;

        //    int x = point.X;
        //    int y = point.Y;

        //    double a = y1 * (z2 - z3) + y2 * (z3 - z1) + y3 * (z1 - z2);
        //    double b = z1 * (x2 - x3) + z2 * (x3 - x1) + z3 * (x1 - x2);
        //    double c = x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2);
        //    double d = -(x1 * (y2 * z3 - y3 * z2) + x2 * (y3 * z1 - y1 * z3) + x3 * (y1 * z2 - y2 * z1));

        //    double z = -(a * x + b * y + d) / c;

        //    return z;
        //}
    }
}