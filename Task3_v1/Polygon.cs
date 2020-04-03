using System.Drawing;
using System.Linq;

namespace Task3_v1
{
    internal class Polygon
    {
        private double _a;
        private double _b;
        private double _c;
        private double _d;
        public int Width = 0;
        public int Height = 0;
        public int MinX = 0;
        public int MaxX = 0;
        public int MinY = 0;
        public int MaxY = 0;

        public Surface Surface;
        public Pen Pen;

        public Polygon(Surface surface, Pen pen)
        {
            this.Pen = pen;
            Surface = surface;

            Width = (surface.points.Max(x => x.X) - surface.points.Min(x => x.X));
            Height = (surface.points.Max(x => x.Y) - surface.points.Min(x => x.Y));

            MinX = surface.points.Min(x => x.X);
            MaxX = surface.points.Max(x => x.X);
            MinY = surface.points.Min(x => x.Y);
            MaxY = surface.points.Max(x => x.Y);
        }

        public bool IsPointInsidePolygon(Point point)
        {
            bool c = false;
            for (int i = 0, j = Surface.points.Length - 1; i < Surface.points.Length; j = i++)
            {
                if ((Surface.points[i].Y <= point.Y && point.Y < Surface.points[j].Y ||
                     Surface.points[j].Y <= point.Y && point.Y < Surface.points[i].Y) &&
                    Surface.points[j].Y - Surface.points[i].Y != 0 &&
                    point.X > (Surface.points[j].X - Surface.points[i].X) * (point.Y - Surface.points[i].Y) / (Surface.points[j].Y - Surface.points[i].Y) + Surface.points[i].X)
                    c = !c;
            }
            return c;
        }

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

            _a = y1 * (z2 - z3) + y2 * (z3 - z1) + y3 * (z1 - z2);
            _b = z1 * (x2 - x3) + z2 * (x3 - x1) + z3 * (x1 - x2);
            _c = x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2);
            _d = -(x1 * (y2 * z3 - y3 * z2) + x2 * (y3 * z1 - y1 * z3) + x3 * (y1 * z2 - y2 * z1));

            double z = -(_a * x + _b * y + _d) / _c;

            return z;
        }

        public double Zx(double Z)
        {
            return Z - _a / _c;
        }

        public double Zy(double Z)
        {
            return Z - _b / _c;
        }
    }
}