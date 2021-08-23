using System.Collections.Generic;
using Core.DomainService;
using Core.Entity;

namespace Static.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        static int id = 1;
        private static List<Customer> _customers = new List<Customer>();
        
        public Customer Create(Customer customer)
        {
            customer.Id = id++;
            _customers.Add(customer);
            return customer;
        }

        public Customer ReadById(int id)
        {
            foreach (var customer in _customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }

            return null;
        }

        public List<Customer> ReadAll()
        {
            return _customers;
        }

        public Customer Update(Customer customerUpdate)
        {
            var customerFromDB = this.ReadById(customerUpdate.Id);
            if (customerFromDB != null)
            {
                customerFromDB.FirstName = customerUpdate.FirstName;
                customerFromDB.LastName = customerUpdate.LastName;
                customerFromDB.Address = customerUpdate.Address;
                return customerFromDB;
            }

            return null;
        }

        public Customer Delete(int id)
        {
            var customerFound = ReadById(id);

            if (customerFound != null)
            {
                _customers.Remove(customerFound);
                return customerFound;
            }

            return null;
        }
    }
}