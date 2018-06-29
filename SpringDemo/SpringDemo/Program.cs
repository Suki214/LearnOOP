using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpringDemo.SpringHelper;

namespace SpringDemo
{
    class Program
    {
        private const string MondayDiscountStrategyFileName =
                @"C:\Users\sxu\source\repos\SpringDemo\SpringDemo\Config\Monday\Strategies.SpringConfig.xml";

        private const string TuesdayDiscountStrategyFileName =
                @"C:\Users\sxu\source\repos\SpringDemo\SpringDemo\Config\Tuesday\Strategies.SpringConfig.xml";

        private const string CasherObjectName = "casher";

        private static SpringContext mySpringContext;

        static void Main(string[] args)
        {
            SetupSpringContext(GetSpringConfigFileAccordingToParameter(args));
            var casher = mySpringContext.GetObject<Casher>(CasherObjectName);

            var product = new Product(50, Product.ProductKind.B);
            var discount = casher.CalculateProductDiscount(product);
            Console.WriteLine(discount);
            Console.ReadKey();
        }

        private static string GetSpringConfigFileAccordingToParameter(string[] args)
        {
            if (null == args || args.Length <= 0)
            {
                Console.WriteLine("No input parameter provided, non-Standalone mode will be used.");
                return MondayDiscountStrategyFileName;
            }

            switch (args[0])
            {
                case "mon":
                    Console.WriteLine("config file for monday will be used.");
                    return MondayDiscountStrategyFileName;
                case "tue":
                    Console.WriteLine("config file for Tuesday will be used.");
                    return TuesdayDiscountStrategyFileName;
                default:
                    return MondayDiscountStrategyFileName;
            }
        }

        private static void SetupSpringContext(string configFileLocation)
        {
            mySpringContext = new SpringContext(new string[] { configFileLocation }, "myObjectContainer");
        }
    }
}
