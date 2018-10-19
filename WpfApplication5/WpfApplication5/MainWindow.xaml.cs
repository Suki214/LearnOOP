using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication5
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Container.grid = Grid1;
            Container.waitingGrid = grid3;
            grid4.DataContext = Result.GetInstance();
            Container.OnGameover += OnGameover;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up: Container.ActivityBox.ChangeShape();
                    break;
                case Key.Left: Container.ActivityBox.MoveLeft();
                    break;
                case Key.Right: Container.ActivityBox.MoveRight();
                    break;
                case Key.Down: Container.ActivityBox.MoveDown();
                    break;
                case Key.Space: Container.ActivityBox.FastDown();
                    break;
                default: break;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (Container.ActivityBox == null) Container.NewBoxReadyToDown();
            else
            {
                Container.Pause();

                if (MessageBox.Show("当前游戏还在进行中，您是否重新开始新游戏?", "警告", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Container.Stop();
                    button2.Content = "暂停";
                    Container.NewBoxReadyToDown();
                }
                else
                {
                  if(button2.Content.ToString()=="暂停")  Container.UnPause();
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString() == "暂停")
            {
                Container.Pause();
                (sender as Button).Content = "取消暂停";
            }
            else
            {
                Container.UnPause();
                (sender as Button).Content = "暂停";
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Container.Pause();
            if (MessageBox.Show("您是否结束游戏?", "警告", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Container.Stop();
                button2.Content = "暂停";
            }
            else
            {
                if (button2.Content.ToString() == "暂停") Container.UnPause();
            }
        }

        static private void OnGameover(object sender, EventArgs e)
        {
            MessageBox.Show("游戏结束！");
        }

    }
}
