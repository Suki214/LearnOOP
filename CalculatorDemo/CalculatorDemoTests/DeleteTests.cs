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
    public class DeleteTests
    {

        //[TestMethod()]
        //public void DeleteTest()
        //{
        //    Assert.Fail();
        //}
        
        
        [TestMethod()]
        public void DeleteResultTest()
        {
            double a = 3;
            double b = 5;
            double actualResult = -2;
            Delete delete = new Delete(a, b);
            
            Assert.AreEqual(delete.Result(), actualResult );
        }
    }
}