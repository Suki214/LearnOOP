using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternDemo
{
    class DemoToImplementIdispose : IDisposable
    {
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                //dispose managed resource
            }

            //dispose un-managed resource
            disposed = true;
        }

        ~DemoToImplementIdispose()
        {
            Dispose(false);//必须false
        }
    }
}
