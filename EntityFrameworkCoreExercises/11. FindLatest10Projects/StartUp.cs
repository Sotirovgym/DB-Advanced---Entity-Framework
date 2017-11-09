using P02_DatabaseFirst.Data;
using System;
using System.Linq;
using System.Globalization;

namespace _11._FindLatest10Projects
{
    class StartUp
    {
        static void Main()
        {
            using (var db = new SoftUniDbContext())
            {
                var projects = db.Projects
                    .OrderByDescending(p => p.StartDate)
                    .Take(10)
                    .OrderBy(p => p.Name)
                    .ToList();

                foreach (var project in projects)
                {
                    var format = "M/d/yyyy h:mm:ss tt";
                    var startDate = project.StartDate.ToString(format, CultureInfo.InvariantCulture);

                    Console.WriteLine($"{project.Name}");
                    Console.WriteLine($"{project.Description}");
                    Console.WriteLine($"{startDate}");
                }
            }
        }
    }
}
