using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphics
{
    internal class Cube
    {
        //Example cube class to demonstrate the use of 3D points and 3D rotation

        public int width = 0;
        public int height = 0;
        public int depth = 0;

        private double xRotation = 0D;
        private double yRotation = 0D;
        private double zRotation = 0D;

        private Math3D.Camera camera1 = new Math3D.Camera();
        private Math3D.Point3D cubeOrigin;

        public double RotateX
        {
            get => xRotation;
            set => xRotation = value;
        }

        public double RotateY
        {
            get => yRotation;
            set => yRotation = value;
        }

        public double RotateZ
        {
            get => zRotation;
            set => zRotation = value;
        }

        public Cube(int side)
        {
            width = side;
            height = side;
            depth = side;
            cubeOrigin = new Math3D.Point3D(width / 2, height / 2, depth / 2);
        }

        public Cube(int side, Math3D.Point3D origin)
        {
            width = side;
            height = side;
            depth = side;
            cubeOrigin = origin;
        }

        public Cube(int Width, int Height, int Depth)
        {
            width = Width;
            height = Height;
            depth = Depth;
            cubeOrigin = new Math3D.Point3D(width / 2, height / 2, depth / 2);
        }

        public Cube(int Width, int Height, int Depth, Math3D.Point3D origin)
        {
            width = Width;
            height = Height;
            depth = Depth;
            cubeOrigin = origin;
        }

        //Finds the othermost points. Used so when the cube is drawn on a bitmap,
        //the bitmap will be the correct size
        public static Rectangle getBounds(PointF[] points)
        {
            double left = points[0].X;
            double right = points[0].X;
            double top = points[0].Y;
            double bottom = points[0].Y;
            for (int i = 1; i < points.Length; i++)
            {
                if (points[i].X < left)
                    left = points[i].X;
                if (points[i].X > right)
                    right = points[i].X;
                if (points[i].Y < top)
                    top = points[i].Y;
                if (points[i].Y > bottom)
                    bottom = points[i].Y;
            }

            return new Rectangle(0, 0, (int)Math.Round(right - left), (int)Math.Round(bottom - top));
        }

        public Bitmap drawCube(Bitmap img, Point drawOrigin)
        {
            //FRONT FACE
            //Top Left - 7
            //Top Right - 4
            //Bottom Left - 6
            //Bottom Right - 5

            //Vars
            PointF[] point3D = new PointF[24]; //Will be actual 2D drawing points
                                               //Point tmpOrigin = new Point(100, 100);

            Math3D.Point3D point0 = new Math3D.Point3D(img.Width / 2 - drawOrigin.X, drawOrigin.Y - img.Height / 2, 0); //Used for reference

            //Zoom factor is set with the monitor width to keep the cube from being distorted
            double zoom = Screen.PrimaryScreen.Bounds.Width / 1.5;

            //Set up the cube
            Math3D.Point3D[] cubePoints = fillCubeVertices(width, height, depth);

            //Apply Rotations, moving the cube to a corner then back to middle
            cubePoints = Math3D.Translate(cubePoints, cubeOrigin, point0);
            cubePoints = Math3D.RotateZ(cubePoints, zRotation); //of Gimbal Lock
            cubePoints = Math3D.RotateY(cubePoints, yRotation); //rotations is the source
            cubePoints = Math3D.RotateX(cubePoints, xRotation); //The order of these
            cubePoints = Math3D.Translate(cubePoints, point0, cubeOrigin);

            //Convert 3D Points to 2D
            var degrees = 35;
            double cDegrees = (Math.PI * degrees) / 180.0;
            for (int i = 0; i < point3D.Length; i++)
            {
                var vec = cubePoints[i];

                point3D[i].X = (float)(Math.Cos(cDegrees) * vec.X - Math.Cos(cDegrees) * vec.Y) + drawOrigin.X;
                point3D[i].Y = (float)(Math.Sin(cDegrees) * vec.X + Math.Sin(cDegrees) * vec.Y - vec.Z) + drawOrigin.Y;
            }

            var g = Graphics.FromImage(img);
            Pen pen = new Pen(Color.Black, 1);

            for (int i = 0; i < 6; i++)
            {
                g.FillPolygon(new SolidBrush(Color.WhiteSmoke), FaceCube(point3D, i));
            }

            for (int i = 0; i < 6; i++)
            {
                g.DrawLines(pen, FaceCube(point3D, i));
            }

            g.Dispose(); //Clean-up

            return img;
        }

        public PointF[] FaceCube(PointF[] verts, int index)
        {
            var values = verts.Skip(index * 4).Take(4).ToList();
            values.Add(verts[index * 4]);
            return values.ToArray();
        }

        public static Math3D.Point3D[] fillCubeVertices(int width, int height, int depth)
        {
            Math3D.Point3D[] verts = new Math3D.Point3D[24];

            //front face
            verts[0] = new Math3D.Point3D(0, 0, 0);
            verts[1] = new Math3D.Point3D(0, height, 0);
            verts[2] = new Math3D.Point3D(width, height, 0);
            verts[3] = new Math3D.Point3D(width, 0, 0);

            //back face
            verts[4] = new Math3D.Point3D(0, 0, depth);
            verts[5] = new Math3D.Point3D(0, height, depth);
            verts[6] = new Math3D.Point3D(width, height, depth);
            verts[7] = new Math3D.Point3D(width, 0, depth);

            //left face
            verts[8] = new Math3D.Point3D(0, 0, 0);
            verts[9] = new Math3D.Point3D(0, 0, depth);
            verts[10] = new Math3D.Point3D(0, height, depth);
            verts[11] = new Math3D.Point3D(0, height, 0);

            //right face
            verts[12] = new Math3D.Point3D(width, 0, 0);
            verts[13] = new Math3D.Point3D(width, 0, depth);
            verts[14] = new Math3D.Point3D(width, height, depth);
            verts[15] = new Math3D.Point3D(width, height, 0);

            //top face
            verts[16] = new Math3D.Point3D(0, height, 0);
            verts[17] = new Math3D.Point3D(0, height, depth);
            verts[18] = new Math3D.Point3D(width, height, depth);
            verts[19] = new Math3D.Point3D(width, height, 0);

            //bottom face
            verts[20] = new Math3D.Point3D(0, 0, 0);
            verts[21] = new Math3D.Point3D(0, 0, depth);
            verts[22] = new Math3D.Point3D(width, 0, depth);
            verts[23] = new Math3D.Point3D(width, 0, 0);

            return verts;
        }
    }
}