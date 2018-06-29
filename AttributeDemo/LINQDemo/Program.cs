using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductionCollection col = Product.GetSampleCollection();
            //PrintProductionTitle();

            //for (int i = 0; i <= col.Count-1; i++)
            //{
            //    string line = col[i].ToString();
            //    Console.WriteLine(line);
            //}

            //foreach (Product item in col)
            //{
            //    string line = item.ToString();
            //    Console.WriteLine(line);
            //}

            //var query = from x in col
            //            where x.Category == "Beer"
            //            orderby x.Code
            //            select new { Title = x.Name.ToUpper(), Code = x.Code };

            //foreach (var item in query)
            //{
            //    Console.WriteLine("{0}, {1}", item.Code, item.Title);
            //}

            List<object> list = new List<object>();
            list.Add(100);
            list.Add(DateTime.Now);
            list.Add("Have fun");
            list.Add("Interesting");

            //var query = list.OfType<string>().Where(x => x.StartsWith("H"));

            var query = list.Cast<int>();
            foreach (object obj in query)
            {
                Console.Write(obj);
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        //private static void PrintProductionTitle()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
