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
using Task3_v1.Polyhedrons;

namespace Task5_v2
{
    public partial class Form1 : Form
    {
        private bool NewPosCheck;
        private int selectedIndex;
        private List<Figure> figures;
        private Point DrawOriginDefault;
        private int FigureSizeDefault;

        private Math3D.Point3D OriginPoints;

        private Polyhedron[] polyhedrons(int size, Math3D.Point3D origin) => new Polyhedron[]
            {
                new Cube(size,origin),
            };

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

        private void numericUpDownSize_ValueChanged(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
                figures[selectedIndex].ChangeSize((int)numericUpDownSize.Value);
        }

        private void numericUpDownPoint_ValueChanged(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
                figures[selectedIndex].DrawingOrigin = new Point((int)numericUpDownXPoint.Value, (int)numericUpDownYPoint.Value);
        }

        private void pictureBoxMain_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show($"{e.X} {e.Y}");
            if (NewPosCheck && selectedIndex != -1)
            {
                figures[selectedIndex].DrawingOrigin = new Point(e.X, e.Y);

                NewPosCheck = false;
                selectedIndex = -1;
            }
        }

        private void listBoxFigures_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                contextMenuStripFigures.Show(listBoxFigures, e.X, e.Y);
            }
        }

        private void contextMenuStripFigures_Opening(object sender, CancelEventArgs e)
        {
            toolStripComboBox1.SelectedIndex = -1;
            toolStripComboBox1.Text = "Add";
        }

        private void toolStripComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex != -1)
            {
                figures.Add(new Figure(polyhedrons(FigureSizeDefault, OriginPoints)[toolStripComboBox1.SelectedIndex], DrawOriginDefault));
            }
            contextMenuStripFigures.Close();
        }

        private void contextMenuStripFigures_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            listBoxFigures.Items.Clear();
            foreach (Figure figure in figures)
            {
                listBoxFigures.Items.Add(figure.Polyhedron.Name);
            }
        }

        private void removeToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            var index = listBoxFigures.SelectedIndex;
            if (index == -1)
                return;
            figures.RemoveAt(index);
            listBoxFigures.Items.Clear();
            foreach (Figure figure in figures)
            {
                listBoxFigures.Items.Add(figure.Polyhedron.Name);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Z_Buffer zBuffer = new Z_Buffer(figures);
            pictureBoxMain.Image = zBuffer.render(pictureBoxMain.Size, new Math3D.Point3D(tX.Value, tY.Value, tZ.Value));
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            OriginPoints = new Math3D.Point3D(pictureBoxMain.Width / 2, pictureBoxMain.Height / 2, 0);
            foreach (var polyhedron in polyhedrons(FigureSizeDefault, OriginPoints))
            {
                toolStripComboBox1.Items.Add(polyhedron.Name);
            }
            _controlsLink = new List<Tuple<NumericUpDown, TrackBar>> { new Tuple<NumericUpDown, TrackBar>(numericUpDownX, tX),
                new Tuple<NumericUpDown, TrackBar>(numericUpDownY, tY),
                new Tuple<NumericUpDown, TrackBar>(numericUpDownZ, tZ) };
            FigureSizeDefault = pictureBoxMain.Height / 3;
            DrawOriginDefault = new Point(pictureBoxMain.Width / 2, pictureBoxMain.Height / 2);
            figures = new List<Figure>() { };
            timer1.Start();
            contextMenuStripFigures_Closing(this, null);
        }

        private void setNewPosByMouseToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            NewPosCheck = true;
            selectedIndex = listBoxFigures.SelectedIndex;
        }

        private void listBoxFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = -1; //Magic trick
            if (listBoxFigures.SelectedIndex == -1)
                return;
            numericUpDownSize.Value = figures[listBoxFigures.SelectedIndex].Polyhedron.width;
            numericUpDownXPoint.Value = figures[listBoxFigures.SelectedIndex].DrawingOrigin.X;
            numericUpDownYPoint.Value = figures[listBoxFigures.SelectedIndex].DrawingOrigin.Y;
            selectedIndex = listBoxFigures.SelectedIndex;
        }
    }
}