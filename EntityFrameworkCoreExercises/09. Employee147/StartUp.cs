using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace _09._Employee147
{
    class StartUp
    {
        static void Main()
        {
            using (var db = new SoftUniDbContext())
            {
                var employees = db.Employees
                    .Include(e => e.EmployeesProjects)
                    .ThenInclude(e => e.Project)
                    .Where(e => e.EmployeeId == 147)
                    .ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

                    foreach (var project in employee.EmployeesProjects.OrderBy(e => e.Project.Name))
                    {                      
                        Console.WriteLine($"{project.Project.Name}");
                    }
                }

            }
        }
    }
}
