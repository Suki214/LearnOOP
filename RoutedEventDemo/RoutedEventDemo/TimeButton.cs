using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RoutedEventDemo
{
   public  class TimeButton:Button
    {
       public static readonly RoutedEvent ReportTimeRoutedEvent = EventManager.RegisterRoutedEvent("ReportTime", RoutingStrategy.Bubble, typeof(EventHandler<ReportTimeRoutedEventArgs>), typeof(TimeButton));

       public event RoutedEventHandler  ReportTime
       {
           add { this.AddHandler(ReportTimeRoutedEvent,value);}
           remove{this.RemoveHandler(ReportTimeRoutedEvent, value);}
       }

       protected override void OnClick()
       {
           base.OnClick();
           ReportTimeRoutedEventArgs rt = new ReportTimeRoutedEventArgs(ReportTimeRoutedEvent , this);
           rt.ClickTime=DateTime.Now;
           this.RaiseEvent(rt);
       }
    }
}
