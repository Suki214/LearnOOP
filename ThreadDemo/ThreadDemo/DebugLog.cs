using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo
{
    public class DebugLog : ILog
    {
        public void LogWrite(string logMessage) => Debug.WriteLine(logMessage);
    }
}
