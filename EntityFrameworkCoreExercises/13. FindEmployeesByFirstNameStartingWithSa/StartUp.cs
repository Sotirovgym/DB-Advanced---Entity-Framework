using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace _13._FindEmployeesByFirstNameStartingWithSa
{
    class StartUp
    {
        static void Main()
        {
            using (var db = new SoftUniDbContext())
            {
                var employees = db.Employees
                    .Where(e => e.FirstName.Substring(0, 2) == "Sa")
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle,
                        e.Salary
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
                }
            }
        }
    }
}
