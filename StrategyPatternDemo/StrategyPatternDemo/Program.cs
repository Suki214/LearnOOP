using System;

using StrategyPatternDemo.SpringHelper;

namespace StrategyPatternDemo
{
    internal class Program
    {
        private const string MondayDiscountStrategyFileName =
                @"D:\GraspNET\2015-SSME-Som10-Academy-SRP and OCP-Examples\StrategyPatternDemo\StrategyPatternDemo\Config\Monday\Strategies.SpringConfig.xml";

        private const string TuesdayDiscountStrategyFileName =
                @"D:\GraspNET\2015-SSME-Som10-Academy-SRP and OCP-Examples\StrategyPatternDemo\StrategyPatternDemo\Config\Tuesday\Strategies.SpringConfig.xml";

        private const string CasherObjectName = "casher";

        private static SpringContext mySpringContext;

        private static void Main( string[] args )
        {
            SetupSpringContext( GetSpringConfigFileAccordingToParameter( args ) );
            var casher = mySpringContext.GetObject<Casher>( CasherObjectName );

            var instantNoodle = new Product( 200, ProductKind.A );
            var discount = casher.CalculateProductDiscount( instantNoodle );

            Console.WriteLine( discount );

            Console.ReadKey();
        }

        public static void SetupSpringContext( string configFileLocation )
        {
            mySpringContext = new SpringContext( new string[] {configFileLocation}, "myObjectContainer" );
        }

        public static string GetSpringConfigFileAccordingToParameter( string[] args )
        {
            if( null == args || args.Length <= 0 )
            {
                Console.WriteLine( "No input parameter provided, non-Standalone mode will be used." );
                return MondayDiscountStrategyFileName;
            }

            switch( args[ 0 ] )
            {
                case "mon":
                    Console.WriteLine( "config file for monday will be used." );
                    return MondayDiscountStrategyFileName;
                case "tue":
                    Console.WriteLine( "config file for Tuesday will be used." );
                    return TuesdayDiscountStrategyFileName;
                    break;
                default:
                    return MondayDiscountStrategyFileName;
            }
        }
    }
}