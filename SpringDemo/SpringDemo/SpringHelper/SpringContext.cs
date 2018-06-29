using Spring.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringDemo.SpringHelper
{
    class SpringContext
    {
        public IApplicationContext ApplicationContext { get; set; }
        private string[] v1;
        private string v2;

        public SpringContext(string[] v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public T GetObject<T>(string springObjectName) where T : class
        {
            if (String.IsNullOrEmpty(springObjectName))
            {
                throw new ArgumentNullException("springObjectName", "is null or empty.");
            }

            T springObject = ApplicationContext.GetObject(springObjectName) as T;

            if (springObject == null)
            {
                throw new NullReferenceException("Unable to retrieve instance from spring context.");
            }

            return springObject;
        }
    }
}
