using Spring.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyWithSpringDemo.SpringHelper
{
    class SpringContext : ISpringContext
    {
        public IApplicationContext ApplicationContext { get; set; }
        //public string[] v1;
        //public string v2;

        //public SpringContext(string[] v1, string v2)
        //{
        //    this.v1 = v1;
        //    this.v2 = v2;
        //}
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T GetObject<T>(string springObjectName) where T : class
        {
            if (string.IsNullOrEmpty(springObjectName))
            {
                throw new ArgumentNullException("springObjectName", "is null or empty");
            }

            T objectName = ApplicationContext.GetObject(springObjectName) as T;

            if (objectName == null)
            {
                throw new  NullReferenceException("cannot get context for this object");
            }
            return objectName;
        }
    }
}
