using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System;
using System.Linq;

namespace _06._AddingNewAddressAndUpdatingEmployee
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniDbContext();

            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            db.Addresses.Add(address);

            Employee employee = null;

            employee = db.Employees
                .Where(e => e.LastName == "Nakov")
                .FirstOrDefault();

            employee.Address = address;

            db.SaveChanges();

            var employees = db.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new
                {
                    e.Address.AddressText
                });

            foreach (var emp in employees)
            {
                Console.WriteLine(emp.AddressText);
            }
            
        }
    }
}
