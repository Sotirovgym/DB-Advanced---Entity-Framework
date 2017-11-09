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
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName
                })
                .ToList();

                foreach (var employee in employees)
                {
                    System.Console.WriteLine($"{employee.FirstName}");
                }
            }         
        }
    }
}
