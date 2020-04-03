using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_v1
{
    internal class DrawGrid
    {
        private List<Math3D.Line3D> grid;

        private double xRotation = 0D;
        private double yRotation = 0D;
        private double zRotation = 0D;

        public Math3D.Point3D Origin;

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

        public Bitmap Draw(Bitmap img, Point drawOrigin, Math3D.Point3D originPoints, Surface surface)
        {
            Origin = originPoints;
            Math3D.Point3D point0 = originPoints; //Used for reference

            //Set up the cube
            Surface points = surface;

            //Apply Rotations, moving the cube to a corner then back to middle
            points = Surface.Translate(points, Origin, point0);
            points = Surface.RotateZ(points, zRotation); //of Gimbal Lock
            points = Surface.RotateY(points, yRotation); //rotations is the source
            points = Surface.RotateX(points, xRotation); //The order of these
            points = Surface.Translate(points, point0, Origin);

            grid = SurfaceGrid.Calculate(points);

            //Convert 3D Points to 2D
            List<Line> lines = new List<Line>();
            var degrees = 10;
            double cDegrees = Math.PI * degrees / 180.0;
            foreach (var vec in grid)
            {
                var line = new Line(
                    new Point(
                        (int)(Math.Cos(cDegrees) * (vec.Point1.X - vec.Point1.Z)) + drawOrigin.X,
                        (int)(Math.Sin(cDegrees) * (vec.Point1.X + vec.Point1.Z) + vec.Point1.Y) + drawOrigin.Y
                        ),
                    new Point(
                        (int)(Math.Cos(cDegrees) * (vec.Point2.X - vec.Point2.Z)) + drawOrigin.X,
                        (int)(Math.Sin(cDegrees) * (vec.Point2.X + vec.Point2.Z) + vec.Point2.Y) + drawOrigin.Y
                        )
                );
                lines.Add(line);
            }

            var g = Graphics.FromImage(img);
            Pen pen = new Pen(Color.Purple, 1);

            for (int i = 0; i < lines.Count; i++)
            {
                g.DrawLine(pen, lines[i].Point1, lines[i].Point2);
            }
            Cords cords = new Cords(originPoints);
            cords.Draw(img);
            g.Dispose(); //Clean-up

            return img;
        }
    }
}