using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace _08._AddressesByTown
{
    class StartUp
    {
        static void Main()
        {
            using (var db = new SoftUniDbContext())
            {
                var addresses = db.Addresses
                    .Include(a => a.Employees)
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Take(10)
                    .ToList();

                foreach (var address in addresses)
                {
                    var townId = address.TownId;
                    var town = db.Towns.Find(townId);

                    Console.WriteLine($"{address.AddressText}, {town.Name} - {address.Employees.Count} employees");
                }
            }
        }
    }
}
