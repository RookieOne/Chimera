using System.Collections.Generic;

namespace Chimera.Interaction.Tests.MockSetup.Domain.Customer
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDto> GetCustomers();
        CustomerDto GetById(int id);
        void Save(CustomerDto c);
    }
}