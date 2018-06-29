using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorDemo.Tests
{
    [TestClass()]
    public class AddTests
    {
        //[TestMethod()]
        //public void AddTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void AddResultTest()
        {
            double a = 3;
            double b = 5;
            double actualResult = 8;
            Add add = new Add(a, b);

            Assert.AreEqual(add.Result(), actualResult);
        }
    }
}