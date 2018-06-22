using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    public class HotelOrder
    {
        //public string[] BookingStatus = { "NoUse", "未提交", "已提交", "已取消", "受理中", "已退回", "已订妥", "已过期" };


        private int orderId;
        private int statusId;
        public HotelOrder(int _orderId, int _statusId)
        {
            orderId = _orderId;
            statusId = _statusId;
        }

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public int StatusId
        {
            get { return statusId; }
            set { statusId = value; }
        }
    }
}
