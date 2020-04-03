using System.Drawing;

namespace Task3_v1
{
    internal class Surface
    {
        public Math3D.Point3D[] points;

        public Surface(Math3D.Point3D[] points)
        {
            this.points = points;
        }

        //These are to make the above functions workable with arrays of 3D points
        public static Surface RotateX(Surface surface, double degrees)
        {
            surface.points = Math3D.RotateX(surface.points, degrees);

            return surface;
        }

        public static Surface RotateY(Surface surface, double degrees)
        {
            surface.points = Math3D.RotateY(surface.points, degrees);

            return surface;
        }

        public static Surface RotateZ(Surface surface, double degrees)
        {
            surface.points = Math3D.RotateZ(surface.points, degrees);

            return surface;
        }

        public static Surface Translate(Surface surface, Math3D.Point3D oldOrigin, Math3D.Point3D newOrigin)
        {
            surface.points = Math3D.Translate(surface.points, oldOrigin, newOrigin);
            return surface;
        }

        public static Surface Move(Surface surface, Point drawOrigin)
        {
            surface.points = Math3D.Move(surface.points, drawOrigin);
            return surface;
        }
    }
}