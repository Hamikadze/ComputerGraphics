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
        public TestTriangle(int side) : base(side)
        {
            width = side;
            height = side;
            depth = side;
            Origin = new Math3D.Point3D(width / 2, height / 2, depth / 2);
            pen = Pens.Green;
        }

        public TestTriangle(int side, Math3D.Point3D origin) : base(side, origin)
        {
            width = side;
            height = side;
            depth = side;
            Origin = origin;
        }

        public TestTriangle(int Width, int Height, int Depth) : base(Width, Height, Depth)
        {
            width = Width;
            height = Height;
            depth = Depth;
            Origin = new Math3D.Point3D(width / 2, height / 2, depth / 2);
        }

        public TestTriangle(int Width, int Height, int Depth, Math3D.Point3D origin) : base(Width, Height, Depth, origin)
        {
            width = Width;
            height = Height;
            depth = Depth;
            Origin = origin;
        }

        public override Surface[] fillVertices(int width, int height, int depth)
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