using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Chimera.Framework.Extensions;
using FizzWare.NBuilder;

namespace Example.Customers.Domain.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        static CustomerRepository()
        {
            _customers = Builder<CustomerDto>.CreateListOfSize(10)
                .Build()
                .ToList();
        }

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
            MessageBox.Show("Save Customer {0} {1}".FormatWith(c.Id, c.Name));
        }
    }
}