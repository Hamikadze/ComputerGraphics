using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_v2
{
    internal class Surface
    {
        public Math3D.Point3D[] points;

        public Surface()
        {
            Random rnd = new Random();
            points = new Math3D.Point3D[3];
            for (int i = 0; i < 3; i++)
            {
                points[i] = new Math3D.Point3D
                {
                    X = rnd.Next(0, 400),
                    Y = rnd.Next(0, 400),
                    Z = rnd.Next(0, 400)
                };
            }
        }

        public Surface(Math3D.Point3D[] points)
        {
            this.points = points;
        }

        //These are to make the above functions workable with arrays of 3D points
        public static Surface[] RotateX(Surface[] surfaces, double degrees)
        {
            foreach (var surface in surfaces)
            {
                surface.points = Math3D.RotateX(surface.points, degrees);
            }

            return surfaces;
        }

        public static Surface[] RotateY(Surface[] surfaces, double degrees)
        {
            foreach (var surface in surfaces)
            {
                surface.points = Math3D.RotateY(surface.points, degrees);
            }

            return surfaces;
        }

        public static Surface[] RotateZ(Surface[] surfaces, double degrees)
        {
            foreach (var surface in surfaces)
            {
                surface.points = Math3D.RotateZ(surface.points, degrees);
            }

            return surfaces;
        }

        public static Surface[] Translate(Surface[] surfaces, Math3D.Point3D oldOrigin, Math3D.Point3D newOrigin)
        {
            foreach (var surface in surfaces)
            {
                surface.points = Math3D.Translate(surface.points, oldOrigin, newOrigin);
            }

            return surfaces;
        }
    }
}