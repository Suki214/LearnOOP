using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Container.grid = Grid1;
            Container.waitingGrid = Grid2;
           // LSGrid.DataContext = Result.GetInstance();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up: Container.ActivityBox.ChangeShape();
                    break;
                case Key.Down: Container.ActivityBox.MoveDown();
                    break;
                case Key.Left: Container.ActivityBox.MoveLeft();
                    break;
                case Key.Right: Container.ActivityBox.MoveRight();
                    break;
                case Key.Space: Container.ActivityBox.FastDown();
                    break;
                default:break;
            }
        }
    }
}
