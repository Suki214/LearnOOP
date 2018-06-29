using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternwithPull
{
    class Heater:SubjectBase
    {
        private int myTemperature;

        public int Temperature
        {
            get
            {
                return myTemperature;
            }
        }

        public void BoilWater()
        {
            for(int i = 1; i < 101; i++)
            {
                if (i > 97)
                {
                    myTemperature = i;
                    OnBoild();
                }
            }
        }

        protected virtual void OnBoild()
        {
            Notify(this);
        }
    }
}
