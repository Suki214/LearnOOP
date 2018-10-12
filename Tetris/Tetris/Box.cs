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

        public void AutoDown()
        {
            dispatcherTimer.Start();
        }

        public void Pause()
        {
            dispatcherTimer.IsEnabled = false;
            IsPause = true;
        }

        public bool IsOverlapping()
        {
            foreach(var r in rectangles)
            {
                int x = Convert.ToInt32((r as Rectangle).GetValue(Grid.ColumnProperty));
                int y = Convert.ToInt32((r as Rectangle).GetValue(Grid.RowProperty));
                if (Existence(x, y))
                    return true;
            }
            return false;
        }

        public void UnPause()
        {
            dispatcherTimer.IsEnabled = true;
            IsPause = false;
        }

        public void StopAction()
        {
            dispatcherTimer.Stop();
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

        public abstract void Ready();
        public abstract void ShowWaiting(ref Grid WaitingGrid);

        protected Status ActivityStatus;

        public bool ChangeShape()
        {
            if (IsPause) return false;

            return true;
        }
    }

    /// <summary>
    /// 定义一个方格坐标点
    /// </summary>
    class Position
    {
        public int x { get; set; }
        public int y { get; set; }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Position() { }
    }

    /// <summary>
    /// 定义方块形状循环链表，标记变形状态
    /// </summary>
    class Status
    {
        /// <summary>
        /// 方格[四个方块]下一次变形将要去的相对位置
        /// </summary>
        public List<Position> nextRelativePosition = new List<Position>(4);

        /// <summary>
        /// 是否需要检查方格[每个方块]到这个位置的可行性
        /// </summary>
        public List<bool> NeedCheck = new List<bool>(4);

        /// <summary>
        /// 指向下一状态
        /// </summary>
        public Status Next;
    }
}