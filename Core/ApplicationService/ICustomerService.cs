using System.Collections.Generic;
using Core.Entity;

namespace Core.ApplicationService
{
    public interface ICustomerService
    { 
        //Grows quickly and lot makes interactions possible
        //New Customer
        Customer NewCustomer(string firstName, string lastName, string address);
        //Create
        Customer CreateCustomer(Customer customer);
        //Read
        Customer FindCustomerById(int id);
        List<Customer> GetAllCustomers();

        List<Customer> GetAllByFirstName(string name);
        //Update
        Customer UpdateCustomer(Customer customerUpdate);
        //Delete
        Customer DeleteCustomer(int id);
    }
}