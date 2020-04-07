using System.Drawing;

namespace Task6_v2
{
    internal class Figure
    {
        public Polyhedron Polyhedron;
        public Point DrawingOrigin;

        public Figure(Polyhedron polyhedron, Point drawingOrigin)
        {
            DrawingOrigin = drawingOrigin;
            Polyhedron = polyhedron;
        }

        public void ChangeSize(int side)
        {
            Polyhedron.depth = side;
            Polyhedron.height = side;
            Polyhedron.width = side;
        }

        public void ChangeSize(int Width, int Height, int Depth)
        {
            Polyhedron.depth = Depth;
            Polyhedron.height = Height;
            Polyhedron.width = Width;
        }
    }
}