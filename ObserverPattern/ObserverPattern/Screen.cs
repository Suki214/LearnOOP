using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Screen : IObserver
    {
        public string BackgroundColor;
        public string MessageShow;
        public void Update()
        {
            BackgroundColor = "Red";
            MessageShow = "The water is about boiled";
        }
    }
}
