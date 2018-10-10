using System.Windows.Controls;

namespace Tetris
{
    internal class Box_J : Box
    {
        public Box_J(ref Grid grid)
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