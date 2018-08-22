using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializableDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializableDemo.Tests
{
    [TestClass()]
    public class ThreadClassTests
    {  
    [TestMethod()]
        public void getMaxSumTest()
        {
            int[] arr = new int[] {3, 2,1};
            
            int result=ThreadClass.getMaxSum(arr);
            Assert.AreEqual(result,4);
        }
    }
}