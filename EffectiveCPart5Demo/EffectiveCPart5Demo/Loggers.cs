using System.ComponentModel;

namespace EffectiveCPart5Demo
{
    public class Loggers
    {
        private static EventHandlerList handlers = new EventHandlerList();

        public static void AddLogger( string system, AddMsgEventHandler ev )
        {
            handlers[ system ] = ev;
        }

        public static void RemoveLogger( string system, AddMsgEventHandler ev )
        {
            handlers[ system ] = null;
        }

        public static void AddMsg( string system, int priority, string msg )
        {
            if( !string.IsNullOrEmpty( system ) )
            {
                AddMsgEventHandler l = handlers[system] as AddMsgEventHandler;
                LoggerEventArgs args = new LoggerEventArgs( priority,msg );
                if( l != null )
                {
                    l( null, args );
                }

                l = handlers[ "" ] as AddMsgEventHandler;
                if (l != null)
                {
                    l(null, args);
                }
            }
        }
    }
}