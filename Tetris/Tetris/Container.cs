using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

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

            if (WaitingBox == null) WaitingBox = BoxFactory.GetRandomBox(ref grid);
            waitingGrid.Children.Clear();

            if (waitingGrid == null) ActivityBox = BoxFactory.GetRandomBox(ref grid);
            else ActivityBox = WaitingBox;

            ActivityBox.OnButtom += ActivityBox_OnButtom;
            ActivityBox.Ready();
            ActivityBox.AutoDown();

            WaitingBox = BoxFactory.GetRandomBox(ref grid);
            waitingGrid.Children.Clear();
            WaitingBox.ShowWaiting(ref waitingGrid);

            if (ActivityBox.IsOverlapping())
            {
                ActivityBox.Pause();
                if (OnGameOver != null) OnGameOver(null, null);
            }
        }

        public static void ActivityBox_OnButtom(object sender, EventArgs e)
        {
            Result.GetInstance().CalculateScore(RemoveLine());
            NewBoxReadyToDown();
        }

        private static int RemoveLine()
        {
            if (grid == null) new Exception("缺少活动区域");
            int[] lineCount = new int[24];
            for (int i = 0; i < 24; i++) lineCount[i] = 0;
            int removeLineCount = 0;
            foreach(var r in grid.Children)
            {
                if(r is Rectangle)
                {
                    int x = Convert.ToInt32((r as Rectangle).GetValue(Grid.RowProperty));
                    lineCount[x]++;
                }
            }
            for(int i = 23; i >= 0; i--)
            {
                if (lineCount[i] >= 14)
                {
                    for(int j = 0; j < grid.Children.Count; j++)
                    {
                        if(grid.Children[j] is Rectangle)
                        {
                            if(Convert.ToInt32((grid.Children[j] as Rectangle).GetValue(Grid.RowProperty)) == i + removeLineCount)
                            {
                                grid.Children.Remove(grid.Children[j] as Rectangle);
                                j--;
                            }
                        }
                    }

                    foreach(var r in grid.Children)
                    {
                        if(r is Rectangle)
                        {
                            if(Convert.ToInt32((r as Rectangle).GetValue(Grid.RowProperty)) < i + removeLineCount)
                            {
                                (r as Rectangle).SetValue(Grid.RowProperty, Convert.ToInt32((r as Rectangle).GetValue(Grid.RowProperty)) + 1);
                            }
                        }
                    }
                    removeLineCount++;
                }
            }

            return removeLineCount;

        }

        public static void Pause()
        {
            if (ActivityBox != null) ActivityBox.Pause();
        }

        public static void UnPause()
        {
            if (ActivityBox != null) ActivityBox.UnPause();
        }

        public static void Stop()
        {
            if (ActivityBox != null) ActivityBox.StopAction();
            ActivityBox = null;
            WaitingBox = null;
            grid.Children.Clear();
            waitingGrid.Children.Clear();
            Result.GetInstance().Level = 1;
            Result.GetInstance().Score = 0;
        }
    }
}
