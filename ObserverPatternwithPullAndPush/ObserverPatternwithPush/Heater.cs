using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternwithPush
{
    class Heater:SubjectBase
    {
        public void BoilWater()
        {
            for(int i = 1; i < 101; i++)
            {
                if (i > 97)
                {
                    SubjectEventArgs e = new SubjectEventArgs(i,"Shanghai");
                    OnBoild(e);
                }
            }
        }

        protected virtual void OnBoild(SubjectEventArgs e)
        {
            Notify(e);
        }
    }
}
