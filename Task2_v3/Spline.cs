using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Task2_v3
{
    internal class Spline
    {
        public Spline(PointF[] input)
        {
            _points = input;
            _deltaPoints = new PointF[_points.Length - 1];

            for (int i = 0; i < _points.Length - 1; i++)
            {
                _deltaPoints[i] = new PointF(input[i + 1].X - input[i].X, input[i + 1].Y - input[i].Y);
            }

            _a = _points.Select(x => x.Y).ToArray();
            _b = new float[_points.Length];
            _c = new float[_points.Length - 1];
            _b[0] = A0;
            for (int i = 0; i < _deltaPoints.Length; i++)
            {
                _b[i + 1] = 2F * _deltaPoints[i].Y / _deltaPoints[i].X - _b[i];
            }

            for (int i = 0; i < _b.Length - 1; i++)
            {
                _c[i] = (_b[i + 1] - _b[i]) / (2 * _deltaPoints[i].X);
            }
        }

        public PointF[] GetSpline()
        {
            List<PointF> pointFsList = new List<PointF>();
            for (float i = _points.Min(x => x.X); i <= _points.Max(x => x.X); i += 0.1F)
            {
                var index = -1;
                for (int j = 0; j < _points.Length - 1; j++)
                {
                    if (_points[j].X <= i && i <= _points[j + 1].X)
                    {
                        index = j;
                        break;
                    }
                }
                pointFsList.Add(new PointF(i, S(index, i)));
            }
            return pointFsList.ToArray();
        }

        public Bitmap DrawSpline(Bitmap img)
        {
            var pointFsList = GetSpline();

            PointF scale = new PointF(1, 1);//new PointF((img.Width - 50) / pointFsList.Max(x => x.X), (img.Height - 50) / pointFsList.Max(x => x.Y));
            for (int i = 0; i < _points.Length; i++)
            {
                _points[i] = new PointF(img.Width / 2F + _points[i].X * scale.X, img.Height / 2F - _points[i].Y * scale.Y);
            }
            for (int i = 0; i < pointFsList.Length; i++)
            {
                pointFsList[i] = new PointF(img.Width / 2F + pointFsList[i].X * scale.X, img.Height / 2F - pointFsList[i].Y * scale.Y);
            }
            Graphics g = Graphics.FromImage(img);

            for (var index = 0; index < _points.Length; index++)
            {
                var _point = _points[index];
                g = DrawString(g, $"X{index + 1}", new PointF(_point.X - 16, _point.Y - 28));
            }

            g.DrawLines(new Pen(Color.Black, 2), _points.Select(x => new PointF(x.X, x.Y)).ToArray());
            g.DrawLines(Pens.Red, pointFsList.Select(x => new PointF(x.X, x.Y)).ToArray());
            return img;
        }

        public Graphics DrawString(Graphics g, string text, PointF point)
        {
            Font drawFont = new Font("Consolas", 11);
            g.DrawString(text, drawFont, Brushes.Black, point.X, point.Y);
            return g;
        }

        private PointF[] _points;
        private PointF[] _deltaPoints;

        public float S(int index, float x) =>
            (float)(_a[index] + _b[index] * (x - _points[index].X) + _c[index] * Math.Pow(x - _points[index].X, 2));

        public float A0 => 0F;

        private float[] _a;
        private float[] _b;
        private float[] _c;
    }
}