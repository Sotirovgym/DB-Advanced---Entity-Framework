using P02_DatabaseFirst.Data;
using System.Linq;

namespace P02_DatabaseFirst.Data
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniDbContext())
            {
                var employees = db.Employees
               .Select(e => new
               {
                   e.FirstName,
                   e.LastName,
                   e.MiddleName,
                   e.JobTitle,
                   e.Salary
               })
               .ToList();

                foreach (var employee in employees)
                {
                    System.Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
                }
            }
                     
        }
    }
}
