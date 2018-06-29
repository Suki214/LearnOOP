using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo
{
   public class Context
    {
        private ILog myLog =null;

        public Context (ILog log)
        {
            myLog = log;
        }


        public void LogWrite(string logMessage)
        {
            myLog.LogWrite( logMessage);
        }
    }
}
