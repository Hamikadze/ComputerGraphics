using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_v2
{
    internal class SandClock : Polyhedron
    {
        public override Pen pen { get; set; } = Pens.Salmon;
        public override string Name { get; set; } = "Песочные часы";

        public SandClock(int side, Math3D.Point3D origin) : base(side, origin)
        {
            width = side;
            height = side;
            depth = side;
            Origin = new Math3D.Point3D(origin.X, origin.Y, 0);
        }

        public SandClock(int Width, int Height, int Depth, Math3D.Point3D origin) : base(Width, Height, Depth, origin)
        {
            width = Width;
            height = Height;
            depth = Depth;
            Origin = new Math3D.Point3D(origin.X, origin.Y, 0);
        }

        public override Surface[] FillVertices(int width, int height, int depth)
        {
            var verts = new List<Surface>()
            {
                //bottom face
                new Surface(new []{
                    new Math3D.Point3D(0, height, 0),
                    new Math3D.Point3D(0, height, depth),
                    new Math3D.Point3D(width, height, depth),
                    new Math3D.Point3D(width, height, 0),}
                ),

                //right face
                new Surface(new []{
                    new Math3D.Point3D(width, height, 0),
                    new Math3D.Point3D(width, height, depth),
                    new Math3D.Point3D(width / 2, height / 2 , depth / 2),}
                ),

                //left face
                new Surface(new []{
                    new Math3D.Point3D(0, height, 0),
                    new Math3D.Point3D(0, height, depth),
                    new Math3D.Point3D(width / 2, height / 2, depth / 2),}
                ),

                //back face
                new Surface(new []{
                    new Math3D.Point3D(0, height, depth),
                    new Math3D.Point3D(width / 2, height /2 , depth / 2),
                    new Math3D.Point3D(width, height, depth),}
                ),

                //front face
                new Surface(new []{
                    new Math3D.Point3D(0, 0, 0),
                    new Math3D.Point3D(width / 2, height/2, depth / 2),
                    new Math3D.Point3D(width, 0, 0),}
                ),

                //front face
                new Surface(new []{
                new Math3D.Point3D(0, height, 0),
                new Math3D.Point3D(width / 2, height/2, depth / 2),
                new Math3D.Point3D(width, height, 0),}
                ),

                //back face
                new Surface(new []{
                new Math3D.Point3D(0, 0, depth),
                new Math3D.Point3D(width / 2, height /2 , depth / 2),
                new Math3D.Point3D(width, 0, depth),}
                ),

                //left face
                new Surface(new []{
                new Math3D.Point3D(0, 0, 0),
                new Math3D.Point3D(0, 0, depth),
                new Math3D.Point3D(width / 2, height / 2, depth / 2),}
                ),

                //right face
                new Surface(new []{
                new Math3D.Point3D(width, 0, 0),
                new Math3D.Point3D(width, 0, depth),
                new Math3D.Point3D(width / 2, height /2 , depth / 2),}
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