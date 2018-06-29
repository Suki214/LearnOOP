using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternwithPush
{
    class SubjectBase : IObservable
    {
        List<IObserver> containers = new List<IObserver>(); 
        public void Register(IObserver observer)
        {
            containers.Add(observer);
        }

        public void UnRegister(IObserver observer)
        {
            containers.Remove(observer);
        }

        protected virtual void Notify(SubjectEventArgs e )
        {
            foreach (IObserver obs in containers)
            {
                obs.Update(e);
            }
        }
    }
}
