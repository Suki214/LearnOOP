using System;
using System.Windows;

namespace GraphicsWithCommandPattern
{
    public class Circle : IGraphicsCommand
    {
        private Point centerPoint;
        private int radius;

        public Circle(Point c, int r)
        {
            centerPoint = c;
            radius = r;
        }
        public void Draw()
        {
            Console.WriteLine("Draw Circle: Center Point {0},  Radius {1}", centerPoint.ToString(), radius.ToString());
        }

        public void Undo()
        {
            Console.WriteLine("Erase Circle: Center Point {0},  Radius {1}", centerPoint.ToString(), radius.ToString());
        }
    }
}
