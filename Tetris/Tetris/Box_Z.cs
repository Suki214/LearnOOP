using System.Windows.Controls;

namespace Tetris
{
    internal class Box_Z : Box
    {
        public Box_Z(ref Grid grid)
        {
            this.grid = grid;
        }

        public override void Ready()
        {
            throw new System.NotImplementedException();
        }

        public override void ShowWaiting(ref Grid WaitingGrid)
        {
            throw new System.NotImplementedException();
        }
    }
}