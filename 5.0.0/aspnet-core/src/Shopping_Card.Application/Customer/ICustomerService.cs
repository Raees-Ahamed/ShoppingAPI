using Shopping_Card.Customer.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Card.Customer
{
    public interface ICustomerService
    {
       IEnumerable<CustomerBO> GetAllCustomer();
    }
}
