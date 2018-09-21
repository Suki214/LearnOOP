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
        public Grid grid;
        public Grid waitingGrid;
        public Box waitingBox { get; set; }
        public Box activityBox { get; set; }
    }
}
