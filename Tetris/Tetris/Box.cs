using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tetris
{
    abstract class Box
    {
        /// <summary>
        /// 定义四个方格组成图形
        /// </summary>
        protected IList<Rectangle> rectangles = new List<Rectangle>(4);

        DispatcherTimer dispatcherTimer;

        public bool IsPause { get; private set; }

        public Box()
        {
            for(int i = 0; i < 4; i++)
            {
                rectangles.Add(new Rectangle());
                rectangles[i].Width = 24;
                rectangles[i].Height = 24;
            }

            dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            dispatcherTimer.Tick += new EventHandler(Timer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(450 - Result.GetInstance().Level * 50);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!MoveDown())
            {
                dispatcherTimer.Stop();
                OnButtom(this, null);
            }
        }

        public event EventHandler OnButtom;

        private bool MoveDown()
        {
            return Move(0, 1);
        }

        protected bool Move(int _x, int _y)
        {
            if (IsPause) return false;
            for(int i = 0; i < 4; i++)
            {
                int x = Convert.ToInt32(rectangles[i].GetValue(Grid.ColumnProperty)) + _x;
                int y = Convert.ToInt32(rectangles[i].GetValue(Grid.RowProperty)) + _y;
                if (Existence(x, y)) return false;
                if (!InGrid(x, y)) return false;
            }
            for (int i = 0; i < 4; i++)
            {
                rectangles[i].SetValue(Grid.ColumnProperty, Convert.ToInt32(rectangles[i].GetValue(Grid.ColumnProperty)) + _x);
                rectangles[i].SetValue(Grid.RowProperty, Convert.ToInt32(rectangles[i].GetValue(Grid.RowProperty)) + _y);
            }
            return true;
        }

        /// <summary>
        /// 判断由数值 x, y标示的行列值是否在Grid范围内
        /// </summary>
        protected bool InGrid(int x, int y)
        {
            if (x >= 13 || y >= 20 || x < 0 || y < 0) return false;
            return true;
        }

        protected Grid grid;
        /// <summary>
        /// 判断x行y列是否包含方格
        /// </summary>
        protected bool Existence(int x, int y)
        {
            foreach(var r in grid.Children)
            {
                if(r is Rectangle)
                {
                    if (rectangles.Contains(r as Rectangle)) return false;
                    if (Convert.ToInt32((r as Rectangle).GetValue(Grid.ColumnProperty)) == x && Convert.ToInt32((r as Rectangle).GetValue(Grid.RowProperty)) == y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}