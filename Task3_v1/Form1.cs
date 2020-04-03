using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task3_v1;

namespace Task5_v2
{
    public partial class Form1 : Form
    {
        private bool NewPosCheck;
        private int selectedIndex;
        private Point DrawOriginDefault;
        private int FigureSizeDefault;
        private Math3D.Point3D OriginPoints;

        //private Polyhedron[] polyhedrons(int size, Math3D.Point3D origin) => new Polyhedron[]
        //    {
        //        new Cube(size,origin),
        //    };

        private List<Tuple<NumericUpDown, TrackBar>> _controlsLink;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void t_Scroll(object sender, EventArgs e)
        {
            var item = _controlsLink.Find(x => x.Item2.Name == ((TrackBar)sender).Name);
            item.Item1.Value = item.Item2.Value;
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var item = _controlsLink.Find(x => x.Item1.Name == ((NumericUpDown)sender).Name);
            item.Item2.Value = (int)item.Item1.Value;
        }

        private void pictureBoxMain_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show($"{e.X} {e.Y}");
            if (NewPosCheck && selectedIndex != -1)
            {
                switch (selectedIndex)
                {
                    case 0:
                        numericUpDown3.Value = e.X;
                        numericUpDown2.Value = e.Y;
                        break;

                    case 1:

                        numericUpDown6.Value = e.X;
                        numericUpDown5.Value = e.Y;
                        break;

                    case 2:

                        numericUpDown9.Value = e.X;
                        numericUpDown8.Value = e.Y;
                        break;

                    case 3:
                        numericUpDown12.Value = e.X;
                        numericUpDown11.Value = e.Y;

                        break;
                }

                NewPosCheck = false;
                selectedIndex = -1;
            }
        }

        private DrawGrid grid;

        private void timer1_Tick(object sender, EventArgs e)
        {
            grid = new DrawGrid
            {
                RotateX = tX.Value,
                RotateY = tY.Value,
                RotateZ = tZ.Value
            };
            Bitmap img = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            Surface surface = new Surface(new[]
            {
                new Math3D.Point3D(numericUpDown3.Value, numericUpDown2.Value,numericUpDown1.Value),
                new Math3D.Point3D(numericUpDown6.Value, numericUpDown5.Value,numericUpDown4.Value),
                new Math3D.Point3D(numericUpDown9.Value, numericUpDown8.Value,numericUpDown7.Value),
                new Math3D.Point3D(numericUpDown12.Value, numericUpDown11.Value,numericUpDown10.Value),
            });
            pictureBoxMain.Image = grid.Draw(img, DrawOriginDefault, OriginPoints, surface);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            OriginPoints = new Math3D.Point3D(pictureBoxMain.Width / 2, pictureBoxMain.Height / 2, 0);
            _controlsLink = new List<Tuple<NumericUpDown, TrackBar>> {
                new Tuple<NumericUpDown, TrackBar>(numericUpDownX, tX),
                new Tuple<NumericUpDown, TrackBar>(numericUpDownY, tY),
                new Tuple<NumericUpDown, TrackBar>(numericUpDownZ, tZ)
            };
            FigureSizeDefault = pictureBoxMain.Height / 3;
            DrawOriginDefault = new Point(pictureBoxMain.Width / 2, pictureBoxMain.Height / 2);
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedIndex = 0;
            NewPosCheck = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedIndex = 1;
            NewPosCheck = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedIndex = 2;
            NewPosCheck = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectedIndex = 3;
            NewPosCheck = true;
        }
    }
}