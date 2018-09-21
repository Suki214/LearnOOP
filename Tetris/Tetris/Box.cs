using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tetris
{
    abstract class Box
    {
        protected IList<Rectangle> rectangles = new List<Rectangle>(4);
        DispatcherTimer dispatcherTimer;
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
            throw new NotImplementedException();
        }
    }
}