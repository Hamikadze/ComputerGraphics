using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_v2
{
    internal class Line
    {
        public Line(PointF point1, PointF point2)
        {
            this._point1 = point1;
            this._point2 = point2;
        }

        public PointF _point1;
        public PointF _point2;
    }

    internal class CohenSutherland
    {
        private int LEFT = 1;
        private int RIGHT = 2;
        private int BOT = 4;
        private int TOP = 8;

        public Graphics DrawSurface(Graphics g, Rectangle rectangle, Size screen, int count)
        {
            g.DrawRectangle(Pens.Green, rectangle);
            Random rnd = new Random();
            List<Line> lines = new List<Line>();
            for (int i = 0; i < count; i++)
            {
                var point1 = new PointF(rnd.Next(0, screen.Width), rnd.Next(0, screen.Height));
                var point2 = new PointF(rnd.Next(0, screen.Width), rnd.Next(0, screen.Height));
                lines.Add(new Line(point1, point2));
            }
            foreach (var lineR in lines)
            {
                var (state, line) = check(rectangle, lineR);
                if (state)
                {
                    g.DrawLine(Pens.Black, lineR._point1, lineR._point2);
                    g.DrawLine(new Pen(Color.Red, 2), line._point1, line._point2);
                }
                else
                {
                    g.DrawLine(Pens.Black, lineR._point1, lineR._point2);
                }
            }

            return g;
        }

        private int vcode(Rectangle r, PointF p)
        {
            return (p.X < r.X ? LEFT : 0) +
                   (p.X > r.X + r.Width ? RIGHT : 0) +
                   (p.Y < r.Y ? TOP : 0) +
                   (p.Y > r.Y + r.Height ? BOT : 0);
        }

        /* если отрезок ab не пересекает прямоугольник r, функция возвращает -1;
           если отрезок ab пересекает прямоугольник r, функция возвращает 0 и отсекает
           те части отрезка, которые находятся вне прямоугольника */

        public (bool, Line) check(Rectangle r, Line line)
        {
            PointF a = line._point1;
            PointF b = line._point2;
            PointF c;

            var codeA = vcode(r, a);
            var codeB = vcode(r, b);
            int code;

            while ((codeA | codeB) != 0)
            {
                if ((codeA & codeB) != 0)
                    return (false, new Line(new PointF(0, 0), new PointF(0, 0)));

                if (codeA != 0)
                {
                    code = codeA;
                    c = a;
                }
                else
                {
                    code = codeB;
                    c = b;
                }

                if ((code & LEFT) != 0)
                {
                    c.Y += (a.Y - b.Y) * (r.X - c.X) / (a.X - b.X);
                    c.X = r.X;
                }
                else if ((code & RIGHT) != 0)
                {
                    c.Y += (a.Y - b.Y) * (r.X + r.Width - c.X) / (a.X - b.X);
                    c.X = r.X + r.Width;
                }
                else if ((code & TOP) != 0)
                {
                    c.X += (a.X - b.X) * (r.Y - c.Y) / (a.Y - b.Y);
                    c.Y = r.Y;
                }
                else if ((code & BOT) != 0)
                {
                    c.X += (a.X - b.X) * (r.Y + r.Height - c.Y) / (a.Y - b.Y);
                    c.Y = r.Y + r.Height;
                }

                if (code == codeA)
                {
                    a = c;
                    codeA = vcode(r, a);
                }
                else
                {
                    b = c;
                    codeB = vcode(r, b);
                }
            }

            return (true, new Line(a, b));
        }
    }
}