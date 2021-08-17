using System;
using System.Collections.Generic;

namespace CustomerConsoleCRUD
{
    class Program
    {
        private static int id = 1;
        private static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                Id = id++,
                FirstName = "Bob",
                LastName = "Sparrow",
                Address = "Skolegade"
            };
            
            customers.Add(customer);
            customers.Add(new Customer
            {
                Id = id++,
                FirstName = "Carl",
                LastName = "Bush",
                Address = "Koningsgade"
            });

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

        private static void EditCustomer()
        {
            var customer = findCustomerById();
            Console.WriteLine("Customer to be edited");
            Console.WriteLine($"Name: {customer.FirstName} {customer.LastName} Address: {customer.Address}");
            Console.WriteLine("FirstName: ");
            customer.FirstName = Console.ReadLine();
            
            Console.WriteLine("LastName: ");
            customer.LastName = Console.ReadLine();
            
            Console.WriteLine("Address: ");
            customer.Address = Console.ReadLine();
            
        }

        private static Customer findCustomerById()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Please insert a number");
            }
            
            foreach (var customer in customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }

            return null;
        }

        private static void DeleteCustomers()
        {
            var customerFound = findCustomerById();

            if (customerFound != null)
            {
                customers.Remove(customerFound);
            }
        }

        private static void AddCustomers()
        {
            Console.WriteLine("First Name:");
            var firstName = Console.ReadLine(); 
            
            Console.WriteLine("Last Name:");
            var lastName = Console.ReadLine();  
            
            Console.WriteLine("Address:");
            var address = Console.ReadLine();

            customers.Add(new Customer
                {
                    Id = id++,
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address
                }
            );
        }

        private static void ListCustomers()
        {
            Console.WriteLine("\nList of Customers");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Id: {customer.Id} Name: {customer.FirstName} {customer.FirstName} Address: {customer.Address}");
            }

            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found. Please add new one.");
            }

            Console.WriteLine("\n");
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select what you want to do:\n");
            
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i+1)} :  {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(),out selection)
                   || selection is < 1 or > 5
            )
            {
                Console.WriteLine("You need to select a number between 1-5");
            }
            
            return selection;
        }
    }
}
