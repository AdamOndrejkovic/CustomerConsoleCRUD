using System.Collections.Generic;
using Core.Entity;

namespace Core.DomainService
{
    public interface ICustomerRepository
    {
        //Grows slowly mainly to be able to do simple tasks with the storage
        Customer Create(Customer customer);
        Customer ReadById(int id);
        IEnumerable<Customer> ReadAll();
        Customer Update(Customer customerUpdate);
        Customer Delete(int id);
    }
}