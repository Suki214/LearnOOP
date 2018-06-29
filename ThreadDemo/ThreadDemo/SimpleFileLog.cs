using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{
   public class SimpleFileLog:ILog
    {
        public void LogWrite(string logMessage)
        {
            var mExePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(mExePath + "\\" + "xian_log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception) { }
        }

        private void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}",
                                     DateTime.Now.ToLongTimeString(),
                                     DateTime.Now.ToLongDateString());

                txtWriter.WriteLine("  :Process {0} - {1} ",
                                     Process.GetCurrentProcess().Id,
                                     Process.GetCurrentProcess().ProcessName);

                txtWriter.WriteLine("  :Thread {0}{1} - {2} ",
                                     Thread.CurrentThread.ManagedThreadId,
                                     Thread.CurrentThread.IsBackground ? "" : " (UI)",
                                     Thread.CurrentThread.Name);

                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("> :{0}\r\n", logMessage);

                //txtWriter.WriteLine( "  :" );
                //txtWriter.WriteLine( "> :{0}\r\n", GetCurrentStackTrace() );

                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception) { }
        }

        private string GetCurrentStackTrace()
        {
            // the true value is used to include source file info
            var currentStack = new StackTrace(true);
            return currentStack.ToString();
        }
    }
}

