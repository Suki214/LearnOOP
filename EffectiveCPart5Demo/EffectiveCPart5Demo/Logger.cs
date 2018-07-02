using System;

namespace EffectiveCPart5Demo
{
    public class LoggerEventArgs : EventArgs
    {
        public string Msg;
        public int Priority;

        public LoggerEventArgs( int priority, string msg )
        {
            Priority = priority;
            Msg = msg;
            Console.WriteLine("LoggereventArgs");
        }
    }

    public delegate void AddMsgEventHandler( object sender, LoggerEventArgs args );

    public class Logger
    {
        private static Logger myOnlyLogger = null;

        static Logger()
        {
            myOnlyLogger = new Logger();
        }

        public Logger SingleLogger
        {
            get
            {
                return myOnlyLogger;
            }
        }

        public event AddMsgEventHandler Log;

        public void AddMsg( int priority, string msg )
        {
            AddMsgEventHandler l = Log;
            if( l != null )
                l( null, new LoggerEventArgs( priority, msg ) );
        }
    }
}