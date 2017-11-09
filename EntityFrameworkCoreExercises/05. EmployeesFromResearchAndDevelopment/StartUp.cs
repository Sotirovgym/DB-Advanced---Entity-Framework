using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace _05._EmployeesFromResearchAndDevelopment
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniDbContext())
            {
                var employees = db.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                });

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:f2}");
                }
            }        
        }
    }
}
