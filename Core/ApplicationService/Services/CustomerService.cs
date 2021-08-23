using System.Collections.Generic;
using System.Linq;
using Core.DomainService;
using Core.Entity;

namespace Core.ApplicationService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepo = customerRepository;
        }
        
        public Customer NewCustomer(string firstName, string lastName, string address)
        {
            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            };
            return customer;
        }

        public Customer CreateCustomer(Customer customer)
        {
            return _customerRepo.Create(customer);
        }

        public Customer FindCustomerById(int id)
        {
            return _customerRepo.ReadById(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepo.ReadAll().ToList();
        }

        public List<Customer> GetAllByFirstName(string name)
        {
            var list = _customerRepo.ReadAll(); // -> Not executed anything yet
            var queryContinued = list.Where(cust => cust.FirstName.Equals(name));
            queryContinued.OrderBy(customer => customer.FirstName);
            return queryContinued.ToList();
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            var customer = FindCustomerById(customerUpdate.Id);
            customer.FirstName = customerUpdate.FirstName;
            customer.LastName = customerUpdate.LastName;
            customer.Address = customerUpdate.Address;
            return customer;
        }

        public Customer DeleteCustomer(int id)
        {
           return _customerRepo.Delete(id);
        }
    }
}