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

namespace ComputerGraphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Cube cube;
        private int CubeSize;
        private Point DrawPoints;
        private List<Tuple<NumericUpDown, TrackBar>> _controlsLink;

        private void Form1_Load(object sender, EventArgs e)
        {
            _controlsLink = new List<Tuple<NumericUpDown, TrackBar>> { new Tuple<NumericUpDown, TrackBar>(numericUpDownX, tX),
                new Tuple<NumericUpDown, TrackBar>(numericUpDownY, tY),
                new Tuple<NumericUpDown, TrackBar>(numericUpDownZ, tZ) };
            numericUpDownSize.Value = pictureBoxMain.Height / 2;
            numericUpDownXPoint.Value = pictureBoxMain.Width / 2;
            numericUpDownYPoint.Value = pictureBoxMain.Height / 2;
            cube = new Cube(CubeSize);

            render(DrawPoints);
        }

        private void render(Point point)
        {
            //Set the rotation values
            cube.RotateX = tX.Value;
            cube.RotateY = tY.Value;
            cube.RotateZ = tZ.Value;

            //Cube is positioned based on center
            Point origin = new Point(point.X, point.Y);
            Cords cords = new Cords(pictureBoxMain.Width / 2, pictureBoxMain.Height / 2, 0);
            Bitmap img = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            img = cords.DrawCords(img);
            pictureBoxMain.Image = cube.drawCube(img, origin);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (var control in _controlsLink)
            {
                control.Item1.Value = 0;
                control.Item2.Value = 0;
            }
            numericUpDownSize.Value = pictureBoxMain.Height / 2;
            numericUpDownXPoint.Value = pictureBoxMain.Width / 2;
            numericUpDownYPoint.Value = pictureBoxMain.Height / 2;
            render(DrawPoints);
        }

        private void t_Scroll(object sender, EventArgs e)
        {
            var item = _controlsLink.Find(x => x.Item2.Name == ((TrackBar)sender).Name);
            item.Item1.Value = item.Item2.Value;
            render(DrawPoints);
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var item = _controlsLink.Find(x => x.Item1.Name == ((NumericUpDown)sender).Name);
            item.Item2.Value = (int)item.Item1.Value;
            render(DrawPoints);
        }

        private void numericUpDownSize_ValueChanged(object sender, EventArgs e)
        {
            CubeSize = (int)numericUpDownSize.Value;
            cube = new Cube(CubeSize);
            render(DrawPoints);
        }

        private void numericUpDownPoint_ValueChanged(object sender, EventArgs e)
        {
            DrawPoints = new Point((int)numericUpDownXPoint.Value, (int)numericUpDownYPoint.Value);
            render(DrawPoints);
        }
    }
}