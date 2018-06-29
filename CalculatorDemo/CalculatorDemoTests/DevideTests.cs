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
    public class DevideTests
    {
        //[TestMethod()]
        //public void DevideTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void DevideResultTestPass()
        {
            double a = 3;
            double b = 5;
            double actualResult = 0.6;
            Devide devide = new Devide(a, b);

            Assert.AreEqual(devide.Result(), actualResult);
        }

        [TestMethod()]
        public void DevideResultTestFail()
        {
            double a = 3;
            double b = 0;
            double actualResult = 0.6;
            Devide devide = new Devide(a, b);

            Assert.AreEqual(devide.Result(), actualResult);
        }
    }
}