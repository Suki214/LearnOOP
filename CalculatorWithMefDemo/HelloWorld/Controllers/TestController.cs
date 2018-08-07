using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return CustomerName + " in " + Address;
        }
    }
    public class TestController : Controller
    {
        // GET: Test
        public Customer GetCustomer()
        {
            Customer c = new Customer();
            c.Address = "Shanghai";
            c.CustomerName = "CC";
            return c;
        }
            
        public string GetString()
        {
            return "Hello World";
        }

        public ActionResult GetView()
        {
            return View("MyView");
        }
    }
}