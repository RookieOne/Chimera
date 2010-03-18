using System.Collections.Generic;
using Chimera.Default.Controllers;
using Example.Customers.Domain.Customer;

namespace Example.Customers.Customers
{
    public class CustomersController : Controller
    {
        public IEnumerable<CustomerDto> Get(ICustomerRepository repository)
        {
            return repository.GetCustomers();
        }
    }
}