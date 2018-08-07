using System;
using System.Windows;

namespace GraphicsWithCommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Line line = new Line(new Point(1, 1), new Point(5, 8));
            Rectangle rectangle = new Rectangle(new Point(1, 1), new Point(5, 8));
            Circle circle = new Circle(new Point(2, 4), 5);

            Graphics graphics = new Graphics();
            graphics.Draw(line);
            graphics.Draw(rectangle);
            graphics.Undo();
            graphics.Draw(circle);

            Console.ReadLine();
        }
    }
}
