using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    public class ViewModel
    {
        private List<HotelOrder> myOrders = new List<HotelOrder>();
        
        public ViewModel()
        {
            myOrders = GetResult();
            Orders = new ObservableCollection<HotelOrder>(myOrders);
        }

        private List<HotelOrder> GetResult()
        {
            List<HotelOrder> orders = new List<HotelOrder>();
            HotelOrder order1= new HotelOrder(1, "未提交");
            HotelOrder order2= new HotelOrder(2, "已提交");
            HotelOrder order3= new HotelOrder(3, "已订妥");
            HotelOrder order4= new HotelOrder(4, "未提交");
            HotelOrder order5= new HotelOrder(6, "已退回");

            orders.Add(order1);
            orders.Add(order2);
            orders.Add(order3);
            orders.Add(order4);
            orders.Add(order5);
            return orders;
        }

        public ObservableCollection<HotelOrder> Orders { get; set; }
    }
}
