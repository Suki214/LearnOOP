using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleClassLibrary
{
    class SaleService : ISaleService
    {
        public bool DeleteCustomer(int Cid)
        {
            var item = customerList.First(x => x.CustomerID == Cid);
            customerList.Remove(item);
            return true;
        }

        public List<Customer> GetAllCustomer()
        {
            return customerList;
        }

        public bool InsertCustomer(Customer obj)
        {
            customerList.Add(obj);
            return true;
        }

        public bool UpdateCustomer(Customer obj)
        {
            var list = customerList;
            customerList.Where(p => p.CustomerID == obj.CustomerID).Update(p => p.CustomerName = obj.CustomerName);
            return true;
        }

        public static List<Customer> customerList = new List<Customer>() {
        new Customer{CustomerID=1, CustomerName="Subject", Address="Pune", EmailId="test@yahoo.com" },
        new Customer{CustomerID=2, CustomerName="Rahul", Address="Pune", EmailId="test@yahoo.com" },
        new Customer{CustomerID=3, CustomerName="Mayur", Address="Pune", EmailId="test@yahoo.com" },        
        };      
    }
}
