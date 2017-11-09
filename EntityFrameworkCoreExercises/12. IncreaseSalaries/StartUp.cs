using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace _12._IncreaseSalaries
{
    class StartUp
    {
        static void Main()
        {
            using (var db = new SoftUniDbContext())
            {
                var employees = db.Employees
                    .Where(e => e.DepartmentId == 1 || e.DepartmentId == 2
                    || e.DepartmentId == 4 || e.DepartmentId == 11)
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList();

                foreach (var employee in employees)
                {
                    employee.Salary *= 1.12m;
                    db.SaveChanges();

                    Console.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
                }
            }
        }
    }
}
