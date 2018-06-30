using System;

namespace EffectiveCPart5Demo
{
    class Program
    {
        static void Main( string[] args )
        {
            Logger logger = new Logger();
            logger.AddMsg( 1, "an error happens " );
            ConsoleLogger clogger = new ConsoleLogger();
            Console.ReadKey();
        }
    }
}