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
            double zoom = (double)Screen.PrimaryScreen.Bounds.Width / 1.5;

            //Set up the cube
            Math3D.Point3D[] cubePoints = fillCubeVertices(width, height, depth);

            //Calculate the camera Z position to stay constant despite rotation
            Math3D.Point3D anchorPoint = (Math3D.Point3D)cubePoints[4]; //anchor point
            double cameraZ = -(((anchorPoint.X - cubeOrigin.X) * zoom) / cubeOrigin.X) + anchorPoint.Z;
            camera1.Position = new Math3D.Point3D(cubeOrigin.X, cubeOrigin.Y, cameraZ);

            //Apply Rotations, moving the cube to a corner then back to middle
            cubePoints = Math3D.Translate(cubePoints, cubeOrigin, point0);
            cubePoints = Math3D.RotateX(cubePoints, xRotation); //The order of these
            cubePoints = Math3D.RotateY(cubePoints, yRotation); //rotations is the source
            cubePoints = Math3D.RotateZ(cubePoints, zRotation); //of Gimbal Lock
            cubePoints = Math3D.Translate(cubePoints, point0, cubeOrigin);

            //Convert 3D Points to 2D
            for (int i = 0; i < point3D.Length; i++)
            {
                var vec = cubePoints[i];
                if (vec.Z - camera1.Position.Z >= 0)
                {
                    point3D[i].X = (int)((double)-(vec.X - camera1.Position.X) / (-0.1f) * zoom) + drawOrigin.X;
                    point3D[i].Y = (int)((double)(vec.Y - camera1.Position.Y) / (-0.1f) * zoom) + drawOrigin.Y;
                }
                else
                {
                    //tmpOrigin.X = (int)((double)(cubeOrigin.X - camera1.Position.X) / (double)(cubeOrigin.Z - camera1.Position.Z) * zoom) + drawOrigin.X;
                    //tmpOrigin.Y = (int)((double)-(cubeOrigin.Y - camera1.Position.Y) / (double)(cubeOrigin.Z - camera1.Position.Z) * zoom) + drawOrigin.Y;

                    point3D[i].X = (float)((vec.X - camera1.Position.X) / (vec.Z - camera1.Position.Z) * zoom + drawOrigin.X);
                    point3D[i].Y = (float)(-(vec.Y - camera1.Position.Y) / (vec.Z - camera1.Position.Z) * zoom + drawOrigin.Y);

                    point3D[i].X = (int)point3D[i].X;
                    point3D[i].Y = (int)point3D[i].Y;
                }
            }

            Graphics g = Graphics.FromImage(img);
            Pen pen = new Pen(Color.Black, 2);

            //Back Face
            g.DrawLine(pen, point3D[0], point3D[1]);
            g.DrawLine(pen, point3D[1], point3D[2]);
            g.DrawLine(pen, point3D[2], point3D[3]);
            g.DrawLine(pen, point3D[3], point3D[0]);

            //Front Face
            g.DrawLine(pen, point3D[4], point3D[5]);
            g.DrawLine(pen, point3D[5], point3D[6]);
            g.DrawLine(pen, point3D[6], point3D[7]);
            g.DrawLine(pen, point3D[7], point3D[4]);

            //Right Face
            g.DrawLine(pen, point3D[8], point3D[9]);
            g.DrawLine(pen, point3D[9], point3D[10]);
            g.DrawLine(pen, point3D[10], point3D[11]);
            g.DrawLine(pen, point3D[11], point3D[8]);

            //Left Face
            g.DrawLine(pen, point3D[12], point3D[13]);
            g.DrawLine(pen, point3D[13], point3D[14]);
            g.DrawLine(pen, point3D[14], point3D[15]);
            g.DrawLine(pen, point3D[15], point3D[12]);

            //Bottom Face
            g.DrawLine(pen, point3D[16], point3D[17]);
            g.DrawLine(pen, point3D[17], point3D[18]);
            g.DrawLine(pen, point3D[18], point3D[19]);
            g.DrawLine(pen, point3D[19], point3D[16]);

            //Top Face
            g.DrawLine(pen, point3D[20], point3D[21]);
            g.DrawLine(pen, point3D[21], point3D[22]);
            g.DrawLine(pen, point3D[22], point3D[23]);
            g.DrawLine(pen, point3D[23], point3D[20]);

            g.Dispose(); //Clean-up

            return img;
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