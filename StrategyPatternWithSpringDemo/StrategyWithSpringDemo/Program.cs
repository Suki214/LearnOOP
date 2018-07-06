using StrategyWithSpringDemo.SpringHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyWithSpringDemo
{
    class Program
    {
        private const string mondayStrategyFileName =
            @"C:\Users\sxu\source\OOPProjects\LearnOOP\StrategyPatternWithSpringDemo\StrategyWithSpringDemo\Configs\Monday\Strategies.SpringConfig.xml";
        private const string tuesdayStrategyFileName =
            @"C:\Users\sxu\source\OOPProjects\LearnOOP\StrategyPatternWithSpringDemo\StrategyWithSpringDemo\Configs\Tuesday\Strategies.SpringConfig.xml";

        private const string CasherObjectName = "Casher";

        private static SpringContext mySpringContext;

        static void Main(string[] args)
        {
            //without spring
            //Product p1 = new Product(222,Product.ProductKind.A);
            //MondayDiscountStrategy mon = new MondayDiscountStrategy();
            //Casher c = new Casher(mon);
            //Console.WriteLine(c.CalculateProductDiscount(p1));
            SetupSpringContext(GetSpringConfigFileAccordingtoParameter(args));
            var casher = mySpringContext.GetObject<Casher>(CasherObjectName);

            var product = new Product(222, Product.ProductKind.A);
            var discount = casher.CalculateProductDiscount(product);
            Console.WriteLine(discount);
            Console.ReadKey();
        }

        private static void SetupSpringContext(string v)
        {
            mySpringContext = new SpringContext();
        }

        private static string GetSpringConfigFileAccordingtoParameter(string[] args)
        {
            if(args==null || args.Length <= 0){
                Console.WriteLine("There is no input parameter, monday strategy will be used");
                return mondayStrategyFileName;
            }

            switch (args[0])
            {
                case "mon":
                    Console.WriteLine("Monday strategy will be used");
                    return mondayStrategyFileName;
                case "tue":
                    Console.WriteLine("Tuesday strategy will be used");
                    return tuesdayStrategyFileName;
                default:
                    Console.WriteLine("As a defalt, Monday strategy will be used");
                    return mondayStrategyFileName;
            }
        }
    }
}
