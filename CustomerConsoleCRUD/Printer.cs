using System;
using System.Collections.Generic;
using System.Linq;
using Core.ApplicationService;
using Core.DomainService;
using Core.Entity;
using Static.Data.Repositories;

namespace CustomerConsoleCRUD
{
    public class Printer: IPrinter
    {
        private readonly ICustomerService _customerService;

        public Printer(ICustomerService customerService)
        {
            _customerService = customerService;
            InitData();
        }
        
        private void InitData()
        {
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

            _customerService.CreateCustomer(customer);
            _customerService.CreateCustomer(customer2);
        }

        public void StartUI()
        {
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
                        var customers = _customerService.GetAllCustomers();
                        ListCustomers(customers);
                        break;
                    case 2:
                        var firstName = AskQuestion("Firstname:");
                        var lastName = AskQuestion("Lastname:");
                        var address = AskQuestion("Address:");
                        var customerAdd = _customerService.NewCustomer(firstName,lastName,address);
                        _customerService.CreateCustomer(customerAdd);
                        break;
                    case 3:
                        var idForDelete = PrintFindCustomerId();
                        _customerService.DeleteCustomer(idForDelete);
                        break;
                    case 4:
                        var idForEdit = PrintFindCustomerId();
                        var customerToEdit = _customerService.FindCustomerById(idForEdit);
                        Console.WriteLine("Updating" + customerToEdit.FirstName + " " + customerToEdit.LastName);
                        var newFirstName = AskQuestion("Firstname: ");
                        var newLastName = AskQuestion("Lastname: ");
                        var newAddress = AskQuestion("Address: "); 
                        _customerService.UpdateCustomer(
                            new Customer()
                            {
                                Id = idForEdit,
                                FirstName = newFirstName,
                                LastName = newLastName,
                                Address = newAddress
                            });
                        break;
                    default:
                        break;
                }

                selection = ShowMenu(menuItems);
            }

            Console.WriteLine("Exited");
            Console.ReadLine();
        }

        //UI
        int PrintFindCustomerId()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            return id;
        }
        
        string AskQuestion(string question)
        {
            Console.WriteLine(question); 
            return Console.ReadLine();
        }
        
        private void ListCustomers(object o)
        {
            Console.WriteLine("\nList of Customers");
            var customers = _customerService.GetAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine(
                    $"Id: {customer.Id} Name: {customer.FirstName} {customer.FirstName} Address: {customer.Address}");
            }

            if (customers.Count() == 0)
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