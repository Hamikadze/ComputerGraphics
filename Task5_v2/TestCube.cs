using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_v2
{
    internal class TestCube : Polyhedron
    {
        public TestCube(int side) : base(side)
        {
            width = side;
            height = side;
            depth = side;
            Origin = new Math3D.Point3D(width / 2, height / 2, depth / 2);

            pen = Pens.Blue;
        }

        public TestCube(int side, Math3D.Point3D origin) : base(side, origin)
        {
            width = side;
            height = side;
            depth = side;
            Origin = origin;
        }

        public TestCube(int Width, int Height, int Depth) : base(Width, Height, Depth)
        {
            width = Width;
            height = Height;
            depth = Depth;
            Origin = new Math3D.Point3D(width / 2, height / 2, depth / 2);
        }

        public TestCube(int Width, int Height, int Depth, Math3D.Point3D origin) : base(Width, Height, Depth, origin)
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
                new Math3D.Point3D(100,50,100),
                new Math3D.Point3D(100,250,100),
                new Math3D.Point3D(250,250,100),
                new Math3D.Point3D(250, 50, 100),}
                ),
            };
            return verts.ToArray();
        }
    }
}