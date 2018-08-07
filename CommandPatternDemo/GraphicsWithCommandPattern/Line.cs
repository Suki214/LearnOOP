using System;
using System.Windows;

namespace GraphicsWithCommandPattern
{
    public class Line : IGraphicsCommand
    {
        private Point startPoint;
        private Point endPoint;

        public Line(Point s,Point e)
        {
            startPoint = s;
            endPoint = e;
        }
        public void Draw()
        {
            Console.WriteLine("Draw a line: from {0} to {1}", startPoint.ToString(), endPoint.ToString());
        }

        public void Undo()
        {
            Console.WriteLine("Erase the line: from {0} to {1}", startPoint.ToString(), endPoint.ToString());
        }
    }
}
