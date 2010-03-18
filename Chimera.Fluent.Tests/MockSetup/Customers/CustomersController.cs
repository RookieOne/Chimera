using System.Collections.Generic;
using Chimera.Default.Controllers;
using Chimera.Interaction.Tests.MockSetup.Domain.Customer;

namespace Chimera.Interaction.Tests.MockSetup.Customers
{
    public class CustomersController : Controller
    {
        public IEnumerable<CustomerDto> Get(ICustomerRepository repository)
        {
            return repository.GetCustomers();
        }
    }
}