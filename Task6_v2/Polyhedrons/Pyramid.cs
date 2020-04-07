﻿using System.Collections.Generic;
using System.Drawing;

namespace Task6_v2.Polyhedrons
{
    internal class Pyramid : Polyhedron
    {
        public override Color pen { get; set; } = Color.Aquamarine;
        public override string Name { get; set; } = "Пирамида";

        public Pyramid(int side, Math3D.Point3D origin) : base(side, origin)
        {
            width = side;
            height = side;
            depth = side;
            Origin = new Math3D.Point3D(origin.X, origin.Y, 0);
        }

        public Pyramid(int Width, int Height, int Depth, Math3D.Point3D origin) : base(Width, Height, Depth, origin)
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