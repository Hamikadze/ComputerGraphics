using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            CohenSutherland cohenSutherland = new CohenSutherland();
            Graphics g = Graphics.FromImage(bmp);
            g = cohenSutherland.DrawSurface(g,
                new Rectangle((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value,
                    (int)numericUpDown4.Value),
                bmp.Size,
                (int)numericUpDown5.Value);

            pictureBox1.Image = bmp;
        }
    }
}