using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    internal class Cords
    {
        public int Ox;
        public int Oy;
        public int Oz = int.MinValue;

        public Cords(Point point)
        {
            Ox = point.X;
            Oy = point.Y;
        }

        public Cords(int ox, int oy, int oz)
        {
            Ox = ox;
            Oy = oy;
            Oz = oz;
        }

        public Bitmap DrawCords(Bitmap img)
        {
            Graphics g = Graphics.FromImage(img);
            var point0 = new Point(Ox, Oy);
            if (Ox != int.MinValue)
            {
                var point1 = new Point(Ox + img.Width / 2, Oy + img.Height / 2);
                g.DrawLine(Pens.Black, point0, point1);
                g = DrawString(g, "X", new Point(point1.X - 16, point1.Y));
            }

            if (Oy != int.MinValue)
            {
                var point1 = new Point(Ox - img.Width / 2, Oy + img.Height / 2);
                g.DrawLine(Pens.Black, point0, point1);
                g = DrawString(g, "Y", new Point(point1.X, point1.Y));
            }

            if (Oz != int.MinValue)
            {
                var point1 = new Point(Ox, Oy - img.Height / 2);
                g.DrawLine(Pens.Black, point0, point1);
                g = DrawString(g, "Z", new Point(point1.X - 16, point1.Y));
            }
            return img;
        }

        public Graphics DrawString(Graphics g, string text, Point point)
        {
            Font drawFont = new Font("Consolas", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            g.DrawString(text, drawFont, drawBrush, point.X, point.Y);
            return g;
        }
    }
}