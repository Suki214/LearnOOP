using System.Windows.Controls;
using System.Windows.Media;

namespace Tetris
{
    internal class Box_J : Box
    {
        public Box_J(ref Grid grid)
        {
            this.grid = grid;
            for (int i = 0; i < 4; i++) rectangles[i].Fill = new SolidColorBrush(Colors.Blue);
        }

        public override void Ready()
        {
            throw new System.NotImplementedException();
        }

        public override void ShowWaiting(ref Grid WaitingGrid)
        {
            //ShowAt
        }
    }
}