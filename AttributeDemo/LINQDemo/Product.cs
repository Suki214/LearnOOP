using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public DateTime ProduceDate { get; set; }

        
        public static ProductionCollection GetSampleCollection()
        {
            ProductionCollection collection = new ProductionCollection(
             new Product { Id = 1, Code = "1001", Category = "Red Wine", Name = "A", Price = 10, ProduceDate = Convert.ToDateTime("2018/6/16") },
             new Product { Id = 3, Code = "2001", Category = "White Spirit", Name = "B", Price = 11, ProduceDate = Convert.ToDateTime("2018/6/15") },
             new Product { Id = 4, Code = "2013", Category = "White Spirit", Name = "C", Price = 12, ProduceDate = Convert.ToDateTime("2018/6/14") },
             new Product { Id = 8, Code = "3001", Category = "Beer", Name = "D", Price = 103, ProduceDate = Convert.ToDateTime("2018/6/13") },
             new Product { Id = 11, Code = "1003", Category = "Red Wine", Name = "E", Price = 140, ProduceDate = Convert.ToDateTime("2018/6/12") },
             new Product { Id = 15, Code = "1007", Category = "Red Wine", Name = "F", Price = 105, ProduceDate = Convert.ToDateTime("2018/6/21") },
             new Product { Id = 17, Code = "3009", Category = "Beer", Name = "G", Price = 160, ProduceDate = Convert.ToDateTime("2018/6/11") }
            );
            return collection;
        }
        public override string ToString()
        {
            return String.Format("{0}{1}{2}{3}{4}{5}", this.Id.ToString().PadLeft(2), this.Category.PadLeft(15), this.Code.PadLeft(7), this.Name.PadLeft(17)
                , this.Price.ToString().PadLeft(20),this.ProduceDate.ToString("yyyy-M-d").PadLeft(13));
        }

        //public Product(int id, string name, string code, string category, decimal price, DateTime produceDate)
        //{
        //    Id = id;
        //    Name = name;
        //    Code = code;
        //    Category = category;
        //    Price = price;
        //    ProduceDate = produceDate;
        //}
    }
}
