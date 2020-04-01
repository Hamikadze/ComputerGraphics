using System.Drawing;

namespace Task2_v3
{
    internal class Cords
    {
        public int Ox;
        public int Oy;

        public Cords(Point point)
        {
            Ox = point.X;
            Oy = point.Y;
        }

        public Cords(int ox, int oy)
        {
            Ox = ox;
            Oy = oy;
        }

        public Bitmap DrawCords(Bitmap img)
        {
            Graphics g = Graphics.FromImage(img);
            var point0 = new Point(Ox, Oy);
            if (Ox != int.MinValue)
            {
                var point1 = new Point(Ox + img.Width / 2, Oy);
                var point2 = new Point(Ox - img.Width / 2, Oy);

                g.DrawLine(Pens.Black, point0, point1);
                g.DrawLine(Pens.Black, point0, point2);

                for (int i = 0; i < img.Width / 2; i += 10)
                {
                    g.DrawLine(Pens.Black, i, img.Height / 2 - 3, i, img.Height / 2 + 3);
                    g.DrawLine(Pens.Black, img.Width / 2 + i, img.Height / 2 - 3, img.Width / 2 + i, img.Height / 2 + 3);
                }
                g = DrawString(g, "X", 16, new Point(point1.X - 16, point1.Y - 32));
            }

            if (Oy != int.MinValue)
            {
                var point1 = new Point(Ox, Oy + img.Height / 2);
                var point2 = new Point(Ox, Oy - img.Height / 2);

                g.DrawLine(Pens.Black, point0, point1);
                g.DrawLine(Pens.Black, point0, point2);

                for (int i = 0; i < img.Height / 2; i += 10)
                {
                    g.DrawLine(Pens.Black, img.Width / 2 - 3, i, img.Width / 2 + 3, i);
                    g.DrawLine(Pens.Black, img.Width / 2 - 3, img.Height / 2 + i, img.Width / 2 + 3, img.Height / 2 + i);
                }

                g = DrawString(g, "Y", 16, new Point(point1.X, point1.Y - 32));
            }
            return img;
        }

        public Graphics DrawString(Graphics g, string text, int size, Point point)
        {
            Font drawFont = new Font("Consolas", size);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            g.DrawString(text, drawFont, drawBrush, point.X, point.Y);
            return g;
        }
    }
}