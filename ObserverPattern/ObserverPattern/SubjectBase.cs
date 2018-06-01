using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class SubjectBase : IObservable
    {
        private List<IObserver> container = new List<IObserver>();

        protected virtual void Notify()
        {
            foreach (IObserver obj in container)
            {
                obj.Update();
            }
        }

        public void Register(IObserver obj)
        {
            container.Add(obj);
        }

        public void UnRegister(IObserver obj)
        {
            container.Remove(obj);
        }
        
    }
}
