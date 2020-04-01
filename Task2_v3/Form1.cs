using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2_v3
{
    public partial class Form1 : Form
    {
        private List<NumericUpDown> numericUpDowns;

        private PointF[] pointFs = {
                new PointF(-450, 200),
                new PointF(-400,0),
                new PointF(-350,-47),
                new PointF(-300, -100),
                new PointF(-200, -26),
                new PointF(-100, 200),
                new PointF(0, 104),
                new PointF(100, 0),
                new PointF(300, -100),
                new PointF(400, 0),
            };

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDowns = new List<NumericUpDown>() {
                numericUpDown1,
                numericUpDown2,
                numericUpDown3,
                numericUpDown4,
                numericUpDown5,
                numericUpDown6,
                numericUpDown7,
                numericUpDown8,
                numericUpDown9,
                numericUpDown10,
                numericUpDown11,
                numericUpDown12,
                numericUpDown13,
                numericUpDown14,
                numericUpDown15,
                numericUpDown16,
                numericUpDown17,
                numericUpDown18,
                numericUpDown19,
                numericUpDown20
            };

            for (int i = 0; i < pointFs.Length; i++)
            {
                numericUpDowns[i * 2].Value = (decimal)pointFs[i].Y;
                numericUpDowns[i * 2 + 1].Value = (decimal)pointFs[i].X;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void Render(PointF[] pointFs)
        {
            pointFs = pointFs.OrderBy(x => x.X).ToArray();
            for (int i = 0; i < numericUpDowns.Count / 2; i++)
            {
                numericUpDowns[i * 2].Value = (decimal)pointFs[i].Y;
                numericUpDowns[i * 2 + 1].Value = (decimal)pointFs[i].X;
            }

            Cords cords = new Cords(drawBox.Width / 2, drawBox.Height / 2);
            Spline spline = new Spline(pointFs);

            Bitmap img = new Bitmap(drawBox.Width, drawBox.Height);

            img = cords.DrawCords(img);
            drawBox.Image = spline.DrawSpline(img);
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            PointF[] pointFs = new PointF[numericUpDowns.Count / 2];
            for (int i = 0; i < numericUpDowns.Count / 2; i++)
            {
                pointFs[i] = (new PointF((float)numericUpDowns[i * 2 + 1].Value, (float)numericUpDowns[i * 2].Value));
            }
            Render(pointFs.ToArray());
        }
    }
}