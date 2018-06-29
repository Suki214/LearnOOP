using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternwithPush
{
    class SubjectEventArgs
    {
        private int temperature;
        private string area;

        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
            }
        }

        public string Area { get => area; set => area = value; }

        public SubjectEventArgs(int _temp, string _area)
        {
            temperature = _temp;
            area = _area;
        }
    }
}
