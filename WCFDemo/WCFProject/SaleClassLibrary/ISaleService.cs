using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SaleClassLibrary
{
    [ServiceContract]
    interface ISaleService
    {
        [OperationContract]
        bool InsertCustomer(Customer obj);

        [OperationContract]
        bool UpdateCustomer(Customer obj);

        [OperationContract]
        bool DeleteCustomer(int Cid);

        [OperationContract]
        List<Customer> GetAllCustomer();
    }
}
