using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RoutedEventDemo
{
  public   class ReportTimeRoutedEventArgs : RoutedEventArgs
    {
      public ReportTimeRoutedEventArgs(RoutedEvent re, object resource):base(re,resource)
      {    
      }

      public DateTime ClickTime { get; set; }
    }
}
