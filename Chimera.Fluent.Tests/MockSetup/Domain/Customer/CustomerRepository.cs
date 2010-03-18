using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;

namespace Chimera.Interaction.Tests.MockSetup.Domain.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        static CustomerRepository()
        {
            _customers = Builder<CustomerDto>.CreateListOfSize(10)
                .Build()
                .ToList();
        }

        public static CustomerDto CustomerSaved;
        static readonly List<CustomerDto> _customers;

        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _customers.ToList();
        }

        public CustomerDto GetById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }

        public void Save(CustomerDto c)
        {
            CustomerSaved = c;
        }
    }
}