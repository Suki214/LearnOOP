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

namespace ReflectionDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] BookingStatus = { "NoUse", "未提交", "已提交", "已取消", "受理中", "已退回", "已订妥", "已过期" };
        public MainWindow()
        {
            InitializeComponent();

            int orderId = 1;
            HotelOrder myOrder = GetItem(orderId);
            lbStatus.Text = BookingStatus[myOrder.StatusId];

        }

        private HotelOrder GetItem(object orderId)
        {
            return new HotelOrder(1,1);
        }
    }
}
