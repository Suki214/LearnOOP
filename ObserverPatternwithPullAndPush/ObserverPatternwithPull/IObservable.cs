using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternwithPull
{
    interface IObservable
    {
        void Register(IObserver observer);
        void UnRegister(IObserver observer);
    }
}
