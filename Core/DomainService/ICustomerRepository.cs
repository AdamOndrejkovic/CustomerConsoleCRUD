using System.Collections.Generic;
using Core.Entity;

namespace Core.DomainService
{
    public interface ICustomerRepository
    {
        Customer Create(Customer customer);
        Customer ReadById(int id);
        List<Customer> ReadAll();
        Customer Update(Customer customerUpdate);
        Customer Delete(int id);
    }
}