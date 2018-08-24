using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqDemo.Models.Tests
{
    [TestClass()]
    public class LinqValueCalculatorTests
    {
        private Product[] products = {
                                         new Product{Name="Kayak",Catogory="Watersports",Price=275M},
                                         new Product{Name="Lifejacket",Catogory="Watersports",Price=48.95M},
                                         new Product{Name="Soccer ball",Catogory="Soccer",Price=19.50M},
                                         new Product{Name="Corner flag",Catogory="Soccer",Price=34.95M}
                                     };

        [TestMethod()]
        public void Sum_Products_Correctly()
        {
            //准备
            //var discounter = new MinimumDiscountHelper();
            //var target = new LinqValueCalculator(discounter);
            //var goalTotal = products.Sum(e => e.Price);
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            var target = new LinqValueCalculator(mock.Object);

            //动作
            var result = target.ValueProducts(products);

            //断言
            Assert.AreEqual(products.Sum(e=>e.Price), result);
        }
    }
}