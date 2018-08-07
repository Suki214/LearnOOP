using System;
using System.Windows;

namespace GraphicsWithCommandPattern
{
    public class Rectangle : IGraphicsCommand
    {
        private Point topLeftPoint;
        private Point bottomRightPoint;
        public Rectangle(Point topLeft, Point bottomRight)
        {
            topLeftPoint = topLeft;
            bottomRightPoint = bottomRight;
        }

        public void Draw()
        {
            Console.WriteLine("Draw Rectangle: Top Left Point {0},  Bottom Right Point {1}", topLeftPoint.ToString(), bottomRightPoint.ToString());
        }

        public void Undo()
        {
            Console.WriteLine("Erase Rectangle: Top Left Point {0},  Bottom Right Point {1}", topLeftPoint.ToString(), bottomRightPoint.ToString());
        }
    }
}
