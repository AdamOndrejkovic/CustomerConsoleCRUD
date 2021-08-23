using System;
using Core.DomainService;
using Core.Entity;
using Static.Data.Repositories;

namespace CustomerConsoleCRUD
{
    public class Printer
    {
        private ICustomerRepository customerRepository;

        public Printer()
        {
            customerRepository = new CustomerRepository();
            Customer customer = new Customer
            {
                FirstName = "Bob",
                LastName = "Sparrow",
                Address = "Skolegade"
            };

            var customer2 = new Customer
            {
                FirstName = "Carl",
                LastName = "Bush",
                Address = "Koningsgade"
            };

            customerRepository.Create(customer);
            customerRepository.Create(customer2);

            Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");


            string[] menuItems =
            {
                "List All Customers",
                "Add Customer",
                "Delete Customer",
                "Edit Customer",
                "Exit"
            };

            var selection = ShowMenu(menuItems);
            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListCustomers();
                        break;
                    case 2:
                        AddCustomers();
                        break;
                    case 3:
                        DeleteCustomers();
                        break;
                    case 4:
                        EditCustomer();
                        break;
                    default:
                        break;
                }

                selection = ShowMenu(menuItems);
            }

            Console.WriteLine("Exited");
            Console.ReadLine();


        }

        private void EditCustomer()
        {
            var customer = FindCustomerById();
            Console.WriteLine("Customer to be edited");
            Console.WriteLine($"Name: {customer.FirstName} {customer.LastName} Address: {customer.Address}");
            Console.WriteLine("FirstName: ");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("LastName: ");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("Address: ");
            customer.Address = Console.ReadLine();

        }

        private Customer FindCustomerById()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            return customerRepository.ReadById(id);
        }

        private void DeleteCustomers()
        {
            var customerFound = FindCustomerById();

            if (customerFound != null)
            {
                customerRepository.Delete(customerFound.Id);
            }
        }

        private void AddCustomers()
        {
            Console.WriteLine("First Name:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Last Name:");
            var lastName = Console.ReadLine();

            Console.WriteLine("Address:");
            var address = Console.ReadLine();

            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            };

            customerRepository.Create(customer);
        }

        private void ListCustomers()
        {
            Console.WriteLine("\nList of Customers");
            var customers = customerRepository.ReadAll();
            foreach (var customer in customers)
            {
                Console.WriteLine(
                    $"Id: {customer.Id} Name: {customer.FirstName} {customer.FirstName} Address: {customer.Address}");
            }

            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found. Please add new one.");
            }

            Console.WriteLine("\n");
        }

        private int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select what you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)} :  {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection is < 1 or > 5
            )
            {
                Console.WriteLine("You need to select a number between 1-5");
            }

            return selection;
        }
        }
}