using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_v1
{
    internal class SurfaceGrid
    {
        private const double N = 50;

        public static List<Math3D.Line3D> Calculate(Surface surface)
        {
            var grid = new List<Math3D.Line3D>();
            grid.AddRange(
                SeparateOpposite(new Math3D.Line3D(surface.points[0], surface.points[1]), new Math3D.Line3D(surface.points[3], surface.points[2]))
            );

            grid.AddRange(
                SeparateOpposite(new Math3D.Line3D(surface.points[1], surface.points[2]), new Math3D.Line3D(surface.points[0], surface.points[3]))
            );
            return grid;
        }

        private static List<Math3D.Line3D> SeparateOpposite(Math3D.Line3D line1, Math3D.Line3D line2)
        {
            var list = new List<Math3D.Line3D>();

            var vector1 = line1.GetVector3D();
            var vector2 = line2.GetVector3D();

            var stepX1 = vector1.X / N;
            var stepY1 = vector1.Y / N;
            var stepZ1 = vector1.Z / N;

            var stepX2 = vector2.X / N;
            var stepY2 = vector2.Y / N;
            var stepZ2 = vector2.Z / N;

            for (int i = 0; i <= N; i++)
            {
                Math3D.Line3D line3D = new Math3D.Line3D(
                    new Math3D.Point3D(line1.Point1.X + stepX1 * i, line1.Point1.Y + stepY1 * i, line1.Point1.Z + stepZ1 * i),
                    new Math3D.Point3D(line2.Point1.X + stepX2 * i, line2.Point1.Y + stepY2 * i, line2.Point1.Z + stepZ2 * i)
                    );
                list.Add(line3D);
            }

            return list;
        }

        public static List<Math3D.Line3D> RotateX(List<Math3D.Line3D> lines, double degrees)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = Math3D.RotateX(lines[i], degrees);
            }
            return lines;
        }

        public static List<Math3D.Line3D> RotateY(List<Math3D.Line3D> lines, double degrees)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = Math3D.RotateY(lines[i], degrees);
            }
            return lines;
        }

        public static List<Math3D.Line3D> RotateZ(List<Math3D.Line3D> lines, double degrees)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = Math3D.RotateZ(lines[i], degrees);
            }
            return lines;
        }

        public static List<Math3D.Line3D> Translate(List<Math3D.Line3D> lines, Math3D.Point3D oldOrigin, Math3D.Point3D newOrigin)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = Math3D.Translate(lines[i], oldOrigin, newOrigin);
            }
            return lines;
        }

        public static List<Math3D.Line3D> Move(List<Math3D.Line3D> lines, Point drawOrigin)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = Math3D.Move(lines[i], drawOrigin);
            }
            return lines;
        }
    }
}