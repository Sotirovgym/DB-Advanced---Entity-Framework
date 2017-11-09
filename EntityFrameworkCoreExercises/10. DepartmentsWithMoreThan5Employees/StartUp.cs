using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace _10._DepartmentsWithMoreThan5Employees
{
    class StartUp
    {
        static void Main()
        {
            using (var db = new SoftUniDbContext())
            {
                var departments = db.Departments
                    .Include(d => d.Employees)
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .ThenBy(d => d.Name)
                    .ToList();

                foreach (var department in departments)
                {
                    var managerId = department.ManagerId;
                    var manager = db.Employees.Find(managerId);

                    Console.WriteLine($"{department.Name} - {manager.FirstName} {manager.LastName}");

                    var orderedEmployeesByDepartment = department.Employees
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .ToList();

                    foreach (var employee in orderedEmployeesByDepartment)
                    {
                        Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                    }
                    Console.WriteLine("----------");
                }
            }
        }
    }
}
