using System;
using System.Collections.Generic;
using Core.DomainService;
using Core.Entity;
using Static.Data.Repositories;

namespace CustomerConsoleCRUD
{
    class Program
    {
        private static ICustomerRepository customerRepository;
        static void Main(string[] args)
        {
            var printer = new Printer();
        }
    }
}
