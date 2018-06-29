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
    public class MultiplyTests
    {
        //[TestMethod()]
        //public void MultiplyTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void MultiplyResultTest()
        {
            double a = 3;
            double b = 5;
            double actualResult = 15;
            Multiply multiply = new Multiply(a, b);

            Assert.AreEqual(multiply.Result(), actualResult);
        }
    }
}