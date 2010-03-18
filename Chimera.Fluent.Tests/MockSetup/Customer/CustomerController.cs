using Chimera.Default.Controllers;
using Chimera.Default.Routing;
using Chimera.Framework.Routing;
using Chimera.Interaction.Tests.MockSetup.Domain.Customer;

namespace Chimera.Interaction.Tests.MockSetup.Customer
{
    public class CustomerController : Controller
    {
        public CustomerDto Edit(ICustomerRepository repository, int id)
        {
            return repository.GetById(id);
        }

        public IRoute Save(ICustomerRepository repository, CustomerDto customer)
        {
            repository.Save(customer);

            return new Route("success", "customer")
                .AddParameter("customer", customer);
        }
    }
}