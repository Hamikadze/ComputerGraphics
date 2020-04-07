using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_v2
{
    internal class TestTriangle : Polyhedron
    {
        public override Pen pen { get; set; } = Pens.Plum;
        public override string Name { get; set; } = "Треугольник";

        public TestTriangle(int side, Math3D.Point3D origin) : base(side, origin)
        {
            width = side;
            height = side;
            depth = side;
            Origin = new Math3D.Point3D(origin.X - width / 2, origin.Y - height / 2, origin.Z);
        }

        public TestTriangle(int Width, int Height, int Depth, Math3D.Point3D origin) : base(Width, Height, Depth, origin)
        {
            width = Width;
            height = Height;
            depth = Depth;
            Origin = new Math3D.Point3D(origin.X - width / 2, origin.Y - height / 2, origin.Z);
        }

        public override Surface[] FillVertices(int width, int height, int depth)
        {
            var verts = new List<Surface>()
            {
                //front face
                new Surface(new []{
                    new Math3D.Point3D(150,150,150),
                    new Math3D.Point3D(250,250,50),
                    new Math3D.Point3D(300,100,50),}
                ),
            };
            return verts.ToArray();
        }
    }
}