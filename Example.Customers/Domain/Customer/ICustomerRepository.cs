using System.Collections.Generic;

namespace Example.Customers.Domain.Customer
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDto> GetCustomers();
        CustomerDto GetById(int id);
        void Save(CustomerDto c);
    }
}