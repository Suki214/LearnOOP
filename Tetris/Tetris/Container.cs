using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tetris
{
    class Container
    {
        static public Grid grid;
        static public Grid waitingGrid;
        static  public Box WaitingBox { get; set; }
        static public Box ActivityBox { get; set; }

        static public event EventHandler OnGameOver;

        static public void NewBoxReadyToDown()
        {
            if (grid == null) new Exception("缺少活动区域");
            if (waitingGrid == null) new Exception("缺少等候区域");

            waitingGrid.Children.Clear();

            if (waitingGrid == null) ActivityBox = BoxFactory.GetRandomBox(ref grid);
        }

        public static void Pause()
        {
            if (ActivityBox != null) ActivityBox.Pause();
        }

        public static void UnPause()
        {
            if (ActivityBox != null) ActivityBox.UnPause();
        }
    }
}
