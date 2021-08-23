using System;
using System.Collections.Generic;
using Core.ApplicationService;
using Core.ApplicationService.Services;
using Core.DomainService;
using Core.Entity;
using Microsoft.Extensions.DependencyInjection;
using Static.Data.Repositories;

namespace CustomerConsoleCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            //Add all dependencies
            serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddScoped<ICustomerService, CustomerService>();
            serviceCollection.AddScoped<IPrinter, Printer>();
            
            //build a provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();
        }
    }
}
