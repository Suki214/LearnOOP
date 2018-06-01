using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Heater:SubjectBase
    {
        private string myType;
        private string myName;
        private int myTemperature;

        public Heater(string type, string name)
        {
            myType = type;
            myName = name;
            myTemperature = 0;
        }
        public string Type
        {
            get
            {
                return myType;
            }
        }

        public string Name
        {
            get
            {
                return myName;
            }
        }

        public Heater() : this("RealFire 001", "China Xi'an") { }

        protected virtual void OnBoiled()
        {
            base.Notify();
        }

        public void BoiledWater()
        {
            for(int i = 1; i < 100; i++)
            {
                myTemperature = i;
                if (i > 97)
                {
                    OnBoiled();
                }
            }
        }
    }
}
