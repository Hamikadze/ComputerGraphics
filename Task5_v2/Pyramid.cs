using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5_v2
{
    internal class Pyramid : Polyhedron
    {
        public Pyramid(int side) : base(side)
        {
            width = side;
            height = side;
            depth = side;
            Origin = new Math3D.Point3D(width / 2, height / 2, depth / 2);
            pen = Pens.Gold;
        }

        public Pyramid(int side, Math3D.Point3D origin) : base(side, origin)
        {
            width = side;
            height = side;
            depth = side;
            Origin = origin;
        }

        public Pyramid(int Width, int Height, int Depth) : base(Width, Height, Depth)
        {
            width = Width;
            height = Height;
            depth = Depth;
            Origin = new Math3D.Point3D(width / 2, height / 2, depth / 2);
        }

        public Pyramid(int Width, int Height, int Depth, Math3D.Point3D origin) : base(Width, Height, Depth, origin)
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
                new Math3D.Point3D(0, 0, 0),
                new Math3D.Point3D(width / 2, height, depth / 2),
                new Math3D.Point3D(width, 0, 0),}
                ),

                //back face
                new Surface(new []{
                new Math3D.Point3D(0, 0, depth),
                new Math3D.Point3D(width / 2, height, depth / 2),
                new Math3D.Point3D(width, 0, depth),}
                ),

                //left face
                new Surface(new []{
                new Math3D.Point3D(0, 0, 0),
                new Math3D.Point3D(0, 0, depth),
                new Math3D.Point3D(width / 2, height, depth / 2),}
                ),

                //right face
                new Surface(new []{
                new Math3D.Point3D(width, 0, 0),
                new Math3D.Point3D(width, 0, depth),
                new Math3D.Point3D(width / 2, height, depth / 2),}
                ),

                //bottom face
                new Surface(new []{
                new Math3D.Point3D(0, 0, 0),
                new Math3D.Point3D(0, 0, depth),
                new Math3D.Point3D(width, 0, depth),
                new Math3D.Point3D(width, 0, 0),}
                ),
            };
            return verts.ToArray();
        }
    }
}