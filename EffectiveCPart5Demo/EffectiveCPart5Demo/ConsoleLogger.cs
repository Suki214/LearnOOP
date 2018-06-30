using System;

namespace EffectiveCPart5Demo
{
    public class ConsoleLogger
    {
        private Logger logger = new Logger();

        public ConsoleLogger()
        {
            logger.Log += new AddMsgEventHandler( Logger_Log );
        }

        public void Logger_Log( object sender, LoggerEventArgs args )
        {
            Console.Error.Write( "there is an error happens with priority {0} and message is {1}", args.Priority, args.Msg );
        }
    }
}