using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tetris
{
    internal class Box_I : Box
    {
        public Box_I(ref Grid grid)
        {
            this.grid = grid;
            for (int i = 0; i < 4; i++) rectangles[i].Fill = new SolidColorBrush(Colors.Red);
        }

        public override void Ready()
        {
            ShowAt(new Position(5, 0), ref grid);

            ActivityStatus = new Status();
            ActivityStatus.nextRelativePosition.Add(new Position(-1, 1));
            ActivityStatus.nextRelativePosition.Add(new Position(0, 0));
            ActivityStatus.nextRelativePosition.Add(new Position(1, -1));
            ActivityStatus.nextRelativePosition.Add(new Position(2, -2));
            ActivityStatus.NeedCheck.Add(true);
            ActivityStatus.NeedCheck.Add(true);
            ActivityStatus.NeedCheck.Add(false);
            ActivityStatus.NeedCheck.Add(true);
            ActivityStatus.Next = new Status();

            ActivityStatus.nextRelativePosition.Add(new Position(1, -1));
            ActivityStatus.nextRelativePosition.Add(new Position(0, 0));
            ActivityStatus.nextRelativePosition.Add(new Position(-1, 1));
            ActivityStatus.nextRelativePosition.Add(new Position(-2, 2));
            ActivityStatus.NeedCheck.Add(true);
            ActivityStatus.NeedCheck.Add(true);
            ActivityStatus.NeedCheck.Add(false);
            ActivityStatus.NeedCheck.Add(true);
            ActivityStatus.Next = ActivityStatus;

        }

        public override void ShowWaiting(ref Grid WaitingGrid)
        {
            ShowAt(new Position(2, 0), ref WaitingGrid);
        }

        private void ShowAt(Position p, ref Grid grid)
        {
            rectangles[0].SetValue(Grid.ColumnProperty, p.x + 0);
            rectangles[0].SetValue(Grid.RowProperty, p.y + 0);

            rectangles[1].SetValue(Grid.ColumnProperty, p.x + 0);
            rectangles[1].SetValue(Grid.RowProperty, p.y + 1);

            rectangles[2].SetValue(Grid.ColumnProperty, p.x + 0);
            rectangles[2].SetValue(Grid.RowProperty, p.y + 2);

            rectangles[3].SetValue(Grid.ColumnProperty, p.x + 0);
            rectangles[3].SetValue(Grid.RowProperty, p.y + 3);

            for (int i = 0; i < 4; i++) grid.Children.Add(rectangles[i]);
        }
    }
}