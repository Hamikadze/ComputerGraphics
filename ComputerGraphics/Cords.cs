﻿using System;
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
        public static Math3D.Point3D Ox3D;
        public static Math3D.Point3D Oy3D;
        public static Math3D.Point3D Oz3D;

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

        public Bitmap Draw(Bitmap img)
        {
            Graphics g = Graphics.FromImage(img);
            var point0 = new Point(Ox, Oy);
            if (Ox != int.MinValue)
            {
                var degrees = 30;
                double cDegrees = Math.PI * degrees / 180.0;
                var x = (int)(Math.Cos(cDegrees) * (img.Width - 0));
                var y = (int)(Math.Sin(cDegrees) * (img.Width + 0) + Oy);
                var point1 = new Point(x, y);
                g.DrawLine(Pens.Black, point0, point1);
                g = DrawString(g, "X", new Point(point1.X - 16, point1.Y - 32));
                Ox3D = new Math3D.Point3D(x, y, 0);
            }

            if (Oy != int.MinValue)
            {
                var degrees = 30;
                double cDegrees = Math.PI * degrees / 180.0;
                var x = (int)(Math.Cos(cDegrees) * (Ox - 0));
                var y = (int)(Math.Sin(cDegrees) * (Ox + 0) + img.Height);
                var point1 = new Point(x, y);
                g.DrawLine(Pens.Black, point0, point1);
                g = DrawString(g, "Y", new Point(point1.X, point1.Y - 32));
                Oy3D = new Math3D.Point3D(x, y, 0);
            }

            if (Oz != int.MinValue)
            {
                var degrees = 30;
                double cDegrees = Math.PI * degrees / 180.0;
                var x = (int)(Math.Cos(cDegrees) * (Ox - img.Height));
                var y = (int)(Math.Sin(cDegrees) * (Ox + img.Height) + Oy);
                var point1 = new Point(x, y);
                g.DrawLine(Pens.Black, point0, point1);
                g = DrawString(g, "Z", new Point(point1.X - 16, point1.Y));
                Oz3D = new Math3D.Point3D(0, 0, 10);
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